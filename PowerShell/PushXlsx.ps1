import-module psexcel

$xlsxFile = $args[0];

function checkFile($file) {
    if ($file -eq $null) {
        Write-Host "Syntax:> PushXlsx some-project.xlsx"
        return $false
    }
    elseif (!(Test-Path $file)) {
        Write-Host "ERROR: $file does not exist."
        return $false
    } else {
        Write-Host "Pushing XLSX file=$xlsxFile";
        return $true
    }
}

function importData() {
    if (checkFile($xlsxFile)) {
        Write-Host "API Project"
        $global:xlsxProject = import-xlsx -path $xlsxFile -sheet "EffortlessAPIProject"|select -first 1
        Write-Host "Roles"
        $global:xlsxRoles = import-xlsx -path $xlsxFile -sheet "Roles"
        Write-Host "Tables"
        $global:xlsxProjectTables = import-xlsx -path $xlsxFile -sheet "Tables"
        Write-Host "Columns"
        $global:xlsxTableColumns = import-xlsx -path $xlsxFile -sheet "Columns"
        Write-Host "Lexicon Terms"
        $global:xlsxLexiconTerms = import-xlsx -path $xlsxFile -sheet "LexiconTerms"
        return $true
    } else {
        return $false
    }
}

function updateProject() {
    Write-Host "UPDATING Project now " $xlsxProject.Name
    $where = "Name='$($xlsxProject.Name)'" -replace " ","\ "
    Write-Host "USING WHERE CLAUSE: '$($where)'"
    $eapiProjectPayload = eapi GetEffortlessAPIProjects -where $where|convertfrom-json
    if (($eapiProjectPayload -eq $null) -or ($eapiProjectPayload.length > 1)) {
        Write-Host "MULTIPLE PROJECTS APPEAR TO HAVE THAT NAME.  Please contact EAPI Support for further assistance.";
    } else {
        $global:eapiProject = $eapiProjectPayload|select -expand EffortlessAPIProjects|select -first 1
        Write-Host "FOUND PROJECT" $eapiProject.Name
        Add-Member -InputObject $xlsxProject -NotePropertyName "EffortlessAPIProjectId" -NotePropertyValue $eapiProject.EffortlessAPIProjectId

        @{EffortlessAPIProject = $xlsxProject}|convertto-json|out-file ./project-payload.json
        $updatedProject = eapi UpdateEffortlessAPIProject -bodyFile ./project-payload.json

        $where = "Project='$($eapiProject.RowKey)'" -replace " ","\ "
        $headVersionPayload = eapi GetProjectVersions -where $where|convertfrom-json
        if ($headVersionPayload.ErrorMessage -ne $null) {
            Write-Host "ERROR Finding head version with Where: " $where $headVersionPayload.ErrorMessage
        } else {
            $global:eapiHeadVersion = $headVersionPayload.ProjectVersions[0];
            if ($eapiHeadVersion.Name -eq $null) {
                Write-Host "NO MATCHING VERSIONS LOCATED, where... " $where
                Write-Host $headVersionPayload|covnertto-json -depth 10
            } else {
                Write-Host "FOUND HEAD VERSION" $eapiHeadVersion.Name
            }
        }
    }
}

function updateRoles() {
    Write-Host "Udating roles" $xlsxRoles.length
    Write-Host "EAPI PROJECT ID" $eapiProject.EffortlessAPIProjectId

    foreach ($xlsxRole in $xlsxRoles) {
        $xlsxRole|Add-Member -NotePropertyName "ProjectVersion" -NotePropertyValue $eapiHeadVersion.ProjectVersionId
    }
    
    # $eapiHeadVersion|convertto-json

    $rolesWhere = "ProjectVersion='$($eapiHeadVersion.Name)'" -replace " ","\ "
    Write-Host "FIND ROLES WHERE CLAUSE: " $rolesWhere
    $dbProjectRolesPayload = eapi GetProjectRoles -where $rolesWhere|convertfrom-json
    if ($dbProjectRolesPayload.ErrorMessage -ne $null) {
        Write-Host("ERROR: ", $dbProjectRolesPayload.ErrorMessage)
    } else {
        $dbProjectRoles = $dbProjectRolesPayload|select -expand ProjectRoles
        
        foreach ($xlsxProjectRole in $xlsxRoles) {
            Write-Host "Checking if Role $($xlsxProjectRole.Name) exists in the DB";
            $dbProjectRole = $dbProjectRoles|where Name -eq $xlsxProjectRole.Name
            if ($dbProjectRole -eq $null) {
                if ($addMissing -ne "a") {
                    $addMissing = Read-Host "Adding missing role $($xlsxProjectRole.Name) to the project?  y/n/a"                    
                }
                if (($addMissing -eq "y") -or ($addMissing -eq "a")) {
                    @{ProjectRole=$xlsxProjectRole}|convertto-json|out-file ./new-role-payload.json
                    $addRolePayload = eapi AddProjectRole -bodyFile ./new-role-payload.json|convertfrom-json
                    Write-Host "Added Role"
                    $addRolePayload|convertto-json
                    if ($addRolePayload.ErrorMessage -ne $null) {
                        Write-Host "ERROR ADDING NEW ROLE: " $addRolePayload.ErrorMessage
                    } else {
                        $dbProjectRoles = $dbProjectRoles + $addRolePayload.ProjectRole;
                        Write-Host "ADDING NEW ROLE FOR: " $xlsxProjectRole.Name
                        $dbProjectRoles|convertto-json
                    }
                }
            } else {
                $xlsxProjectRole|Add-Member -NotePropertyName "ProjectRoleId" -NotePropertyValue $dbProjectRole.ProjectRoleId                
            }
        }
        Write-Host "final XLSX PROJECT ROLES (to post): " 
        Write-Host ($xlsxRoles|select Name,DefaultHasAccess,DefaultCRUD,DefaultAirtableWhere,ProjectRoleId|convertto-json -depth 10)
        foreach ($xlsxRole in $xlsxRoles) {
            if ($xlsxRole.DefaultCRUD -eq $null) {
                $xlsxRole.DefaultCRUD = "None"
            }
            Write-Host "Expanding CRUD statement into Can...ByDefault fields..." $xlsxRole.DefaultCRUD
            Add-Member -InputObject $xlsxRole -NotePropertyName "CanCreateByDefault" -NotePropertyValue $xlsxRole.DefaultCRUD.Contains("C")
            Add-Member -InputObject $xlsxRole -NotePropertyName "CanReadByDefault" -NotePropertyValue $xlsxRole.DefaultCRUD.Contains("R")
            Add-Member -InputObject $xlsxRole -NotePropertyName "CanUpdateByDefault" -NotePropertyValue $xlsxRole.DefaultCRUD.Contains("U")
            Add-Member -InputObject $xlsxRole -NotePropertyName "CanDeleteByDefault" -NotePropertyValue $xlsxRole.DefaultCRUD.Contains("D")
        }
        @{ProjectRoles=$xlsxRoles}|convertto-json|out-file project-roles-payload.json
        $updatedRoles = eapi UpdateProjectRole -bodyFile .\project-roles-payload.json
    }
}
function updateTables {
    Write-Host "Udating tables" $xlsxProjectTables.length

    foreach ($xlsxProjectTable in $xlsxProjectTables) {
        $xlsxProjectTable|Add-Member -NotePropertyName "ProjectVersion" -NotePropertyValue $eapiHeadVersion.ProjectVersionId
    }
    
    # $eapiHeadVersion|convertto-json
    foreach ($xlsxProjectTable in $xlsxProjectTables) {
        $xlsxProjectTable.SortOrder=[int]$xlsxProjectTable.SortOrder;
    }

    $tablesWhere = "ProjectVersion='$($eapiHeadVersion.Name)'" -replace " ","\ "
    Write-Host "FIND TABLES WHERE CLAUSE: " $tablesWhere
    $dbProjectTablesPayload = eapi GetProjectTables -where $tablesWhere|convertfrom-json
    if ($dbProjectTablesPayload.ErrorMessage -ne $null) {
        Write-Host("ERROR: ", $dbProjectTablesPayload.ErrorMessage)
    } else {
        $dbProjectTables = $dbProjectTablesPayload|select -expand ProjectTables
        
        foreach ($xlsxProjectTable in $xlsxProjectTables) {
            Write-Host "Checking if Table $($xlsxProjectTable.Name) exists in the DB";
            $dbProjectTable = $dbProjectTables|where Name -eq $xlsxProjectTable.Name
            if ($dbProjectTable -eq $null) {
                if ($addMissing -ne "a") {
                    $addMissing = Read-Host "Adding missing table $($xlsxProjectTable.Name) to the project?  y/n/a"                
                }
                if (($addMissing -eq "y") -or ($addMissing -eq "a")) {
                    @{ProjectTable=$xlsxProjectTable}|convertto-json|out-file ./new-table-payload.json
                    $addTablePayload = eapi AddProjectTable -bodyFile ./new-table-payload.json
                    Write-Host "Added Table" $addTablePayload
                    $addTablePayload|convertto-json
                    if ($addTablePayload.ErrorMessage -ne $null) {
                        Write-Host "ERROR ADDING NEW TABLE: " $addTablePayload.ErrorMessage
                    } else {
                        $dbProjectTables = $dbProjectTables + $addTablePayload.ProjectTable;
                        Write-Host "ADDING NEW TABLE FOR: " $xlsxProjectTable.Name
                        $dbProjectTables|convertto-json
                    }
                }
            } else {
                $xlsxProjectTable|Add-Member -NotePropertyName "ProjectTableId" -NotePropertyValue $dbProjectTable.ProjectTableId                
                $xlsxProjectTable|Add-Member -NotePropertyName "RowKey" -NotePropertyValue $dbProjectTable.Rowkey
            }
        }
        Write-Host "final XLSX PROJECT TABLES (to post): " 
        Write-Host ($xlsxTables|select Name,DefaultHasAccess,DefaultCRUD,DefaultAirtableWhere,ProjectTableId|convertto-json -depth 10)
        @{ProjectTables=$xlsxProjectTables}|convertto-json|out-file project-tables-payload.json
        $updatedTables = eapi UpdateProjectTable -bodyFile .\project-tables-payload.json
    }
}
function updateColumns {
    Write-Host "Udating columns" $xlsxTableColumns.length

    foreach ($xlsxProjectTable in $xlsxProjectTables) {
        $tableColls = $xlsxTableColumns|where TableName -eq $xlsxProjectTable.Name
        Write-Host "FOUND " $tableColls.length + " columns for table " $xlsxProjectTable.Name
        foreach ($tableColl in $tableColls) {
            Add-Member -InputObject $tableColl -NotePropertyName "ProjectTable" -NotePropertyValue $xlsxProjectTable.ProjectTableId;
            Write-Host "TABLE COLUMN: " $tableColl|convertto-json
        }
    }

    # $eapiHeadVersion|convertto-json
    foreach ($xlsxTableColumn in $xlsxTableColumns) {
        $xlsxTableColumn.SortOrder=[int]$xlsxTableColumn.SortOrder;
        $xlsxTableColumn.Length=[int]$xlsxTableColumn.Length;
    }

    $tablesWhere = "ProjectVersion='$($eapiHeadVersion.Name)'" -replace " ","\ "
    Write-Host "FIND TABLES WHERE CLAUSE: " $tablesWhere
    $dbTableColumnsPayload = eapi GetTableColumns -where $tablesWhere|convertfrom-json
    if ($dbTableColumnsPayload.ErrorMessage -ne $null) {
        Write-Host("ERROR: ", $dbTableColumnsPayload.ErrorMessage)
    } else {
        $dbTableColumns = $dbTableColumnsPayload|select -expand TableColumns
        $addMissing = "n"
        foreach ($xlsxTableColumn in $xlsxTableColumns) {
            Write-Host "Checking if TableColumn $($xlsxTableColumn.Name) exists in the DB";
            $dbTableColumn = $dbTableColumns|where Name -eq $xlsxTableColumn.Name
            if ($dbTableColumn -eq $null) {
                Write-Host "DB Column Change: " $addMissing
                if ($addMissing -ne "a") {
                    $addMissing = Read-Host "Adding missing column $($xlsxTableColumn.Name) to the project?  y/n/a"                
                }
                if (($addMissing -eq "y") -or ($addMissing -eq "a")) {
                    @{TableColumn=$xlsxTableColumn}|convertto-json|out-file ./new-table-column-payload.json
                    $addTablePayload = eapi AddTableColumn -bodyFile ./new-table-column-payload.json|convertfrom-json
                    Write-Host "Added Table" ($addTablePayload|convertto-json)
                    $addTablePayload|convertto-json
                    if ($addTablePayload.ErrorMessage -ne $null) {
                        Write-Host "ERROR ADDING NEW TABLE: " $addTablePayload.ErrorMessage
                    } else {
                        $dbTableColumns = $dbTableColumns + $addTablePayload.TableColumn;
                        Write-Host "ADDING NEW TABLE COLUM FOR: " $xlsxTableColumn.Name
                    }
                }
            } else {
                $xlsxTableColumn|Add-Member -NotePropertyName "TableColumnId" -NotePropertyValue $dbTableColumn.TableColumnId                
            }
        }
        Write-Host "final XLSX PROJECT TABLES (to post): " 

        @{TableColumns=$xlsxTableColumns}|convertto-json|out-file table-columns-payload.json
        $updatedColumns = eapi UpdateTableColumns -bodyFile .\table-columns-payload.json
    }
}
function updateLexiconTerms {
    Write-Host "Udating lexicon terms" $xlsxLexiconTerms.length
    
    # $eapiHeadVersion|convertto-json
    Write-host $xlsxRoles|convertto-json
    foreach ($xlsxLexiconTerm in $xlsxLexiconTerms) {
        $from = $xlsxRoles|where Name -eq $xlsxLexiconTerm.From|select -first 1
        $to = $xlsxRoles|where Name -eq $xlsxLexiconTerm.To|select -first 1
        $xlsxLexiconTerm|Add-Member -notePropertyName FromRole -NotePropertyValue $from.ProjectRoleId
        $xlsxLexiconTerm|Add-Member -notePropertyName ToRole -NotePropertyValue $to.ProjectRoleId        
        $xlsxLexiconTerm|Add-Member -notePropertyName ProjectVersion -NotePropertyValue $eapiHeadVersion.ProjectVersionId
    }

    $lexiconTermsWhere = "ProjectVersion='$($eapiHeadVersion.Name)'" -replace " ","\ "
    Write-Host "FIND LEXICON COLUMSN WHERE CLAUSE: " $lexiconTermsWhere

    $dbLexiconTermsPayload = eapi GetProjectLexiconTerms -where $lexiconTermsWhere|convertfrom-json
    $dbLexiconTermsPayload|convertto-json

    if ($dbLexiconTermsPayload.ErrorMessage -ne $null) {
        Write-Host("ERROR: ", $dbLexiconTermsPayload.ErrorMessage)
    } else {
        $dbLexiconTerms = $dbLexiconTermsPayload|select -expand ProjectLexiconTerms
        $addMissing = "n"
        foreach ($xlsxLexiconTerm in $xlsxLexiconTerms) {
            Write-Host "Checking if LexiconTerm $($xlsxLexiconTerm.Name) exists in the DB";
            $dbLexiconTerm = $dbLexiconTerms|where From -eq $xlsxLexiconTerm.From
            if ($dbLexiconTerm -eq $null) {
                Write-Host "NEW Lexicon Term: " $addMissing
                if ($addMissing -ne "a") {
                    $addMissing = Read-Host "Adding missing lexiconTerm $($xlsxLexiconTerm.From): '$($xlsxLexiconTerm.Message)' => $($xlsxLexiconTerm.To) to the project?  y/n/a"                
                }
                if (($addMissing -eq "y") -or ($addMissing -eq "a")) {
                    @{ProjectLexiconTerm=$xlsxLexiconTerm}|convertto-json|out-file ./new-project-lexiconterm-payload.json
                    $addProjectLexiconTermPayload = eapi AddProjectLexiconTerm -bodyFile ./new-project-lexiconterm-payload.json|convertfrom-json
                    Write-Host "Added Lexicon Term" ($addProjectLexiconTermPayload|convertto-json)
                    if ($addProjectLexiconTermPayload.ErrorMessage -ne $null) {
                        Write-Host "ERROR ADDING Lexicon Term: " $addProjectLexiconTermPayload.ErrorMessage
                    } else {
                        $dbLexiconTerms = $dbLexiconTerms + $addProjectLexiconTermPayload.ProjectLexiconTerms;
                        Write-Host "ADDING NET Lexicon Term: " $xlsxLexiconTerm.Name
                    }
                }
            } else {
                $xlsxTableColumn|Add-Member -NotePropertyName "TableColumnId" -NotePropertyValue $dbTableColumn.TableColumnId                
            }
        }
        Write-Host "final XLSX PROJECT TABLES (to post): " 

        @{TableColumns=$xlsxTableColumns}|convertto-json|out-file table-columns-payload.json
        $updatedColumns = eapi UpdateTableColumns -bodyFile .\table-columns-payload.json
    }
}

if (importData($xlsxFile)) {
    Write-Host "" "" "" "" ""
    updateProject;
    Write-Host "" "" "" "" ""
    updateRoles
    Write-Host "" "" "" "" ""
    updateTables
    Write-Host "" "" "" "" ""
    updateColumns
    Write-Host "" "" "" "" ""
    updateLexiconTerms
}



