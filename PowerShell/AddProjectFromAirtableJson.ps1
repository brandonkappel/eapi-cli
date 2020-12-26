
function ParseAirtable() {
	$airtable = cat airtable.json|ConvertFrom-Json
	$airtableName=$airtable|select -expand name;
	# Write-Host("RAW AIRTABLE");
	# Write-Host($airtable|ConvertTo-Json);	
	Write-Host("Would you like to rename?")
	$finalName = Read-Host "New Name (press enter to leave unchanged) " $airtableName;
	if (($finalName -eq $null) -or ($finalName -eq "")) {
		$finalName=$airtableName
	}
	$airtable.name=$finalName;
	$airtable
}

function GetFinalResult() {
	$airtable = ParseAirtable;
	$airtable
}

Write-Host "Getting final result...";
$final = GetFinalResult;
$final|convertto-json -depth 10|out-file ./data/airtable.json
$projName = $final|select -expand name
$projAirtableId = $final|select -expand id

Write-Host "Final Airtable Result: " $projName $projAirtableId " Creating project now...";
. ./CreateEAPIProject.ps1
CreateEAPIProject "$projname" "$projAirtableId"