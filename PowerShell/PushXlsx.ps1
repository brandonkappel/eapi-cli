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
                $addMissing = Read-Host "Adding missing role $($xlsxProjectRole.Name) to the project?  y/n"                
                if ($addMissing -eq "y") {
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
function updateTables() {
    Write-Host "Udating tables" $xlsxProjectTables.length
}
function updateColumns() {
    Write-Host "Udating columns" $xlsxTableColumns.length
}
function updateLexiconTerms() {
    Write-Host "Udating lexicon terms" $xlsxLexiconTerms.length
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



