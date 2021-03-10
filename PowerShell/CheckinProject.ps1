if (!(Test-Path 'ProjectTables.xlsx')) {
    Write-Host "Project tables doesn't exist"
} else{
    $projecttables=import-xlsx -path .\ProjectTables.xlsx
    @{ProjectTables=$projecttables|select-object ProjectTableId,Description,TableGroup, @{ n = "SortOrder"; e = {[int]($_.SortOrder)} } }|convertto-json|out-file payload.json
    eapi UpdateProjectTable -bodyFile payload.json
    $dt = get-date -format "yyyy_MM_dd_hh_mm_ss"
    $fn = [String]".\projecttables_$dt.xlsx"
    Write-Host "File Name: " $fn
    Rename-Item -Path .\projecttables.xlsx -NewName $fn

    $global:eapiProject = $null;
    $global:projectTables = $null;
}

