if ($global:eapiProject -eq $null) {
    Write-Host "No EffortlessAPI project currently checked out."
} else {
    Write-Host "Current EffortlessAPI Project: " $global:eapiProject.Name
}