$payload = eapi geteffortlessapiprojects -where "ModifiedOn>DATEADD(Today(),-3,'month')"|convertfrom-json
if ($payload.ErrorMessage -ne $null) {
    Write-Host $payload.ErrorMessage
} else {
    $global:eapiProjects = $payload|select -expand EffortlessAPIProjects|select RowKey,Name,Description,AccountName,AirtableId,Alias,CreatedOn,ModifiedOn,GuestRole,UserRole,AdminRole,LastPublished,HeadVersion,EffortlessAPIProjectId,OwnerEmail|Sort-Object -Descending -property ModifiedOn,LastPublished
    Write-Host "All EffortlessAPI Projects: "
    $global:eapiProjects|format-table
}