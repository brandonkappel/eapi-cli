$global:eapiProjects = eapi geteffortlessapiprojects|convertfrom-json|select -expand EffortlessAPIProjects|select EffortlessAPIProjectId,RowKey,Name,Description,AccountName,AirtableId,Alias,CreatedOn,ModifiedOn,GuestRole,UserRole,AdminRole,LastPublished,HeadVersion,OwnerEmail|Sort-Object -Descending -property ModifiedOn,LastPublished
Write-Host "All EffortlessAPI Projects: "
$global:eapiProjects|format-table
