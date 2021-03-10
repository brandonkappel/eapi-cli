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
        $global:xlsxProject = import-xlsx -path $xlsxFile -sheet "EffortlessAPIProject"
        Write-Host "Roles"
        $global:xlsxRoles = import-xlsx -path $xlsxFile -sheet "Roles"
        Write-Host "Tables"
        $global:xlsxTables = import-xlsx -path $xlsxFile -sheet "Tables"
        Write-Host "Columns"
        $global:xlsxColumns = import-xlsx -path $xlsxFile -sheet "Columns"
        Write-Host "Lexicon Terms"
        $global:xlsxLexiconTerms = import-xlsx -path $xlsxFile -sheet "LexiconTerms"
        return $true
    } else {
        return $false
    }
}


if (importData($xlsxFile)) {
    $xlsxProject = $global:xlsxProject|select -first 1;
    Write-Host "UPDATING Project now " $xlsxProject.Name
    $where = "Name='$($xlsxProject.Name)'" -replace " ","\ "
    $where
    $eapiProjectPayload = eapi GetEffortlessAPIProjects -where $where|convertfrom-json
    if (($eapiProjectPayload -eq $null) -or ($eapiProjectPayload.length > 1)) {
        Write-Host "MULTIPLE PROJECTS APPEAR TO HAVE THAT NAME.  Please contact EAPI Support for further assistance.";
    } else {
        $eapiProject = $eapiProjectPayload|select -expand EffortlessAPIProjects|select -first 1

        
        $xlsxProject|Add-Member -NotePropertyName "EffortlessAPIProjectId" -NotePropertyValue $eapiProject.EffortlessAPIProjectId
        Write-Host $xlsxProject|convertto-json -depth 10

        @{EffortlessAPIProject = $xlsxProject}|convertto-json|out-file ./project-payload.json
        eapi UpdateEffortlessAPIProject -bodyFile ./project-payload.json
    }

}


