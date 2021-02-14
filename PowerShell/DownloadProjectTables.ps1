import-module psexcel
if ($global:headVersion -eq $null) {
    Write-Host "Must run 'SelectProject your-eapi-alias' first..."
} else {
    $versionName = $global:headVersion.Name;
    $where = "ProjectVersion='$versionName'" -replace " ","\ "
    Write-Host "Downloading project tables: " $where
    $projectTables = eapi GetProjectTables -where $where|convertfrom-json|select -expand ProjectTables|sort-object -property SortOrder
    $projectTables|format-table
    $global:projectTables = $projectTables|select ProjectTableId,Name,PluralName,Description,SortOrder
    $global:projectTables|export-xlsx -path ./projecttables.xlsx
    Write-Host "Those were the" $global:projectTables.length " tables..."
}