import-module psexcel

function AddRoles() {
    Write-Host "Adding roles  to the project.... "
    $versionName = $global:headVersion.Name;
    $where = "ProjectVersion='$versionName'" -replace " ","\ "
    Write-Host "Downloading project roles: " $where
    $global:projectRoles = eapi GetProjectRoles -MaxPages 99 -where $where|convertfrom-json|select -expand ProjectRoles|sort-object -property SortOrder|select Name,DefaultHasAccess,DefaultCRUD,DefaultAirtableWhere
}

function AddTableCRUD([Parameter(ValueFromPipeline)]
                    [PSObject[]]	
                    $table) {
     BEGIN {}
     PROCESS {
        $trws = $global:tableRoleWheres;
        Write-Host "ADDING TABLE CRUD for: " $table.Name
        foreach ($role in $global:projectRoles) {
            $roleName = $role.Name;
            # Write-host " ::: PROJECT TABLEID: " $table.ProjectTableId
            $trw = $global:tableRoleWheres|where {($_.TableName -eq $table.ToName) -and ($_.RoleName -eq $role.Name)}|select -first 1
            $callCRUD = "";
            $defaultCRUD = "";
            $airtableWhere = "";
            $hasAccess = ($role.DefaultHasAccess) -or (($trw -ne $null) -and ($trw.HasAccess))
            # Write-Host "HAS ACCESS? " $role.HasAccessByDefault $hasAccess
            if ($hasAccess) {
                $callCRUD = $role|select -expand DefaultCRUD;
                $defaultCRUD = $role|select -expand DefaultCRUD
                $airtableWhere = $role|select -expand DefaultAirtableWhere
                # Write-Host $callRUD " - " $defaultCRUD " - WHERE " $airtableWhere "   --- TABLE ROLE WHERE ---  " $trw|convertto-json
                if ($trw -ne $null) {
                    Write-Host "TABLE ROLE CRUD: " $trw
                    $callCRUD = $trw.DefaultCallCRUD;
                    $defaultCRUD = $trw.DefaultCRUD;
                    $airtableWhere = $trw.AirtableWhereClause;
                }
            }

            $table|Add-Member -NotePropertyName "$($roleName)CallCRUD" -NotePropertyValue $callCRUD -TypeName "String" -Force
            $table|Add-Member -NotePropertyName "Default$($roleName)CRUD" -NotePropertyValue $defaultCRUD -TypeName "String" -Force
            $table|Add-Member -NotePropertyName "$($roleName)AirtableWhere" -NotePropertyValue $airtableWhere -TypeName "String" -Force
        }
        return $table;
     }
     END {}
}

function AddTables() {
    $versionName = $global:headVersion.Name;
    $where = "ProjectVersion='$versionName'" -replace " ","\ "
    Write-Host "Downloading project tables: " $where
    $global:tableRoleWheres = eapi GetTableRoleWheres -where $where|convertfrom-json|select -expand TableRoleWheres
    WRite-host "Downloading CRCs" $where
    $global:columnRoleCRUDs = eapi GetColumnRoleCRUDs -MaxPages 99 -where $where|convertfrom-json|select -expand ColumnRoleCRUDs
    Write-Host "TABLE ROLE WHEREs..." $global:tableRoleWheres.length
    $global:projectTables = eapi GetProjectTables -where $where|convertfrom-json|select -expand ProjectTables|sort-object -property SortOrder|select Name,ToName,Description,PluralName,DisplayName,AirtableName,TableGroup,SortOrder|AddTableCRUD
}

function AddColumnCRUD([Parameter(ValueFromPipeline)]
                    [PSObject[]]	
                    $tableColumn) {
     BEGIN {}
     PROCESS {
        foreach ($role in $global:projectRoles) {            
            $roleName = $role.Name;

            $crud = "";

            $crc = $global:columnRoleCRUDs|where {($_.TableName -eq $tableColumn.TableName) -and ($_.ColumnName -eq $tableColumn.ToName) -and ($_.RoleName -eq $role.Name)}|select -first 1
            if ($crc -eq $null) {
                $trw = $global:tableRoleWheres|where {($_.TableName -eq $tableColumn.TableName) -and ($_.RoleName -eq $role.Name)}|select -first 1
                if ($trw -eq $null) {
                    $crud = $role.DefaultCRUD;
                    # Write-Host "ROLE COLUMN CRUD: " $tableColumn.Name $role.Name $crud
                } else {
                    $crud = $trw.DefaultCRUD;
                    # Write-Host "TRW COLUMN CRUD: " $tableColumn.Name $role.Name $crud
                }
            } else {
                $crud = $crc.CRUD;
                Write-Host "CRC CRUD: " $tableColumn.Name $role.Name $crud
            }


            $tableColumn | Add-Member -NotePropertyName "$($roleName)CRUD" -NotePropertyValue $crud -TypeName "String" -Force
        }
        return $tableColumn;
     }
     END {}
}

function AddColumns {
    $versionName = $global:headVersion.Name;
    $where = "ProjectVersion='$versionName'" -replace " ","\ "
    Write-Host "Downloading project columns: " $where
    $global:tableColumns = eapi GetTableColumns -MaxPages 99 -where $where|convertfrom-json|select -expand TableColumns|sort-object -property TableName,SortOrder|select TableName,Name,ToName,DisplayName,RelationshipType,Description,DefaultValue,SortOrder,IsCollection,IsObsolete,IsRequired,IsReadonly,IsUnique,DataType,Length|AddColumnCRUD
}


function AddLexiconTerms{
    $versionName = $global:headVersion.Name;
    $where = "ProjectVersion='$versionName'" -replace " ","\ "
    Write-Host "Downloading project lexiconTerms: " $where
    $global:lexiconTerms = eapi GetProjectLexiconTerms -where $where|convertfrom-json|select -expand ProjectLexiconTerms|sort-object -property SortOrder|select From,Message,To,IsDirectMessage
}

function WriteXlsxFile() {
    Write-Host "Writing to project";
    $global:eapiProject|select Name,Description,AirtableId,UserTable,EmailColumnName,RoleColumnName,GuestRole,UserRole,AdminRole,Alias|export-xlsx -path "./$global:xlsxName" -worksheet "EffortlessAPIProject"
    
    $projectRoles = $global:projectRoles
    $global:projectRoles|export-xlsx -path "./$global:xlsxName" -worksheet Roles    
    Write-Host "Adding roles to the project.... " $projectRoles.length
    $projectTables = $global:projectTables
    $projectTables|export-xlsx -path "./$global:xlsxName" -worksheet Tables
    Write-Host "Those were the" $global:projectTables.length " tables..."
    $tableColumns = $global:tableColumns
    $tableColumns|export-xlsx -path "./$global:xlsxName" -worksheet Columns
    Write-Host "Adding columns to the project.... " $tableColumns.length
    $lexiconTerms = $global:lexiconTerms
    $lexiconTerms|export-xlsx -path "./$global:xlsxName" -worksheet LexiconTerms
    Write-Host "Adding lexicon terms to the project.... " $lexiconTerms.length

}

if ($global:headVersion -eq $null) {
    Write-Host "Must run 'SelectProject your-eapi-alias' first..."
} else {
    Write-Host "PROJET VERSION: " $global:headVersion.Name
    AddRoles
    AddTables
    AddColumns
    AddLexiconTerms
    WriteXlsxFile
}