Import-Module PSExcel

Write-Host("Updating EffortlessAPIProjects to EAPIProjects.xlsx");
eapi geteffortlessapiprojects|convertfrom-json|select -expand EffortlessAPIProjects|select EffortlessAPIProjectId,Name,Description,AccountName,AirtableId,Alias,CreatedOn,ModifiedOn,UserTable,RoleTable,GuestRole,UserRole,AdminRole,LastPublished,OwnerEmail|Sort-Object -Descending -property ModifiedOn,LastPublished|export-xlsx ./EAPIProjects.xlsx -clearsheet
start EAPIProjects.xlsx