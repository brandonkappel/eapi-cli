$projecttables=import-xlsx -path .\projecttables.xlsx
@{ProjectTables=$projecttables}|convertto-json|out-file payload.json
eapi UpdateProjectTable -bodyFile payload.json
$dt = get-date -format "yyyy-MM-dd-hh:mm:ss"
mv projecttables.xlsx "projecttables_$dt.xlsx"