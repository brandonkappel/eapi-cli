Write-Host "Selecting project with Alias=" $args[0]
rm .\qbo-demo.xlsx
# rm ".\EffortlessAPI - DB.xlsx"

$proj = $eapiProjects|where Alias -eq $args[0]
if ($proj -eq $null) {
    Write-Host "ERROR: Project" $args[0] "not found"
} else {

    $where = "RECORD_ID()='$($proj.EffortlessAPIProjectId)'";
    $updatedProjectPayload = eapi GetEffortlessAPIProjects -where $where
    $updatedProject = $updatedProjectPayload|convertfrom-json|select -expand EffortlessAPIProjects
    $global:eapiProject = $updatedProject
    $projectName = $global:eapiProject.Name;
    $global:xlsxName = "$projectName.xlsx";

    if ((Test-Path $global:xlsxName)) {
        Write-Host "$global:xlsxName already exists - either check it in or delete it first.";
    } else {

        $headVersion = $proj.HeadVersion    
        $where = ("Record_ID()='$headVersion'") -replace " ","\ ";
        $versions = eapi GetProjectVersions -where $where|convertfrom-json|select -expand ProjectVersions
        $version = $versions|select -first 1
        if ($version -eq $null) {
            Write-Host "HEAD VERSION for project not found.";
        } else {
            $global:headVersion = $version
        }

        Write-Host " -- CURRENT PROJECT SELECTED --"
        $global:eapiProject
        $global:headVersion
        ./DownloadProjectTables.ps1
    }
}

