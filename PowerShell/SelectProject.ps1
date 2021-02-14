$proj = $eapiProjects|where Alias -eq $args[0]
if ($proj -eq $null) {
    Write-Host "ERROR: Project" $args[0] "not found"
} else {
    $global:eapiProject = $proj
    $headVersion = $proj.HeadVersion    
    $where = ("Record_ID()='$headVersion'") -replace " ","\ ";
    $versions = eapi GetProjectVersions -where $where|convertfrom-json|select -expand ProjectVersions
    $version = $versions|select -first 1
    if ($version -eq $null) {
        Write-Host "HEAD VERSION for project not found.";
    } else {
        $global:headVersion = $version
    }
}

Write-Host " -- CURRENT PROJECT SELECTED --"
$global:eapiProject
$global:headVersion