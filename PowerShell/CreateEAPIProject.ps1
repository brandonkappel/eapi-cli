Import-Module PSExcel

Function CreateEAPIProject {
	param ($name, $airtableId)

	echo "NAME: $name."
	if (($name -eq $null) -or ($airtableId -eq $null)) {
		echo "Syntax: CreateEAPIProject {name} {airtableId}"
	} else {
		$where = "Name='$name'";
		echo "WHERE $where with airtableId $airtableId"
		$result = eapi GetEFfortlessAPIProjects -as Developer -where $where | convertfrom-json
		if ($result.ErrorMessage -ne $null){
			$result|select -expand ErrorMessage
		}
		else {
			$matches = $result|select -expand EffortlessAPIProjects
			echo "THESE ARE THE MATCHES:"
			$matches
			if ($matches.length -eq 0) {
				$account = cat ~/.eapi/EffortlessAPIAccount.json|convertfrom-json
				$services = cat ~/.eapi/EffortlessAPIServices.json|convertfrom-json;
				$airtableServiceId = $services|where Name -eq 'airtable'|select -expand EffortlessAPIServiceId
				echo "AIRTABLESERVICE ID";
				$airtableServiceId
				$endpoints = cat ~/.eapi/ServiceHostEndpoints.json|convertfrom-json;
				$largeId = $endpoints|where Name -eq 'Large-EAPIEndpoint-EffortlessApi-EC2'|select -expand ServiceHostEndpointId
				Write-Host "AIRTABLESERVICE ID " $airtableServiceId " LARGE ID: " $largeId
				if ($account -eq $null) {
					echo "Can't find EffortlessAPI Account - SaveiWhoAmI and eapi -reloadCache first."
				} elseif ($endpoints -eq $null) {
					echo "> eapi -reloadCache first."
				} else {
					$projPayload = @{EffortlessAPIProject=@{Name=$name;EffortlessApiService=$airtableServiceId;Account=$account.EffortlessAPIAccountId;AirtableId=$airtableId;GuestRole="Guest";UserRole="User";AdminRole="Admin";ProjectStage="Development";ProjectType="Commercial"}}|convertto-json
					$projPayload
					$projPayload|out-file ./data/project.json

					$response = eapi AddEffortlessAPIProject -bodyFile ./data/project.json|convertfrom-json
					$response
					$response|convertto-json|out-file ./data/project.json
					$project = $response|select -expand EffortlessAPIProject

					$projectId = $project|select -expand EffortlessAPIProjectId

					$projectEmail = @{ProjectEmail=@{Project=$projectId;Account=$account.EffortlessAPIAccountId}}|convertto-json
					$projectEmail|out-file ./data/projectemail.json
					$response = eapi AddProjectEmail -bodyFile ./data/projectemail.json|convertfrom-json
					$response

					echo "Stage"
					$stagePayload = @{ProjectStage=@{Project=$projectId;Stage="develop";HeadStage=$null;TemplateTaskEndpoint=$largeId}}|convertto-json
					$stagePayload|out-file ./data/projectstage.json
					$response = eapi AddProjectStage -bodyFile ./data/projectstage.json|convertfrom-json
					$response
					

					$stageAdded = $response|select -expand ProjectStage
					$projWithHeadStage = @{EffortlessAPIProjectId=$project.EffortlessAPIProjectId;HeadStage=$stageAdded|select -expand ProjectStageId}
					@{EffortlessAPIProject=$projWithHeadStage}|convertto-json|out-file ./data/projectWithHeadStage.json
					eapi UpdateEffortlessAPIProject -bodyFile ./data/projectWithHeadStage.json

					echo "Project Version"
					$projectVersion = @{ProjectVersion=@{Project=$projectId;ProjectStage=$stageId}}|convertto-json
					$projectVersion|out-file ./data/projectversion.json
					$response = eapi AddProjectVersion -bodyFile ./data/projectversion.json|convertfrom-json
					$projectVersion =$response|select -expand ProjectVersion

					$projVersionId=$projectVersion|select -expand ProjectVersionId

					@{ProjectStage=@{ProjectStageId=$stageAdded.ProjectStageId;ActiveVersion=$projVersionId}}|convertto-json|out-file ./data/stageStageWithVersion.json
					$response = eapi UpdateProjectStage -bodyFile ./data/stageStageWithVersion.json
					$response


					echo "Guest Role"
					$guestRole = @{ProjectRole=@{ProjectVersion=$projVersionId;Name="Guest";}}|convertto-json
					$guestRole |out-file ./data/guestRole.json
					$response = eapi AddProjectRole -bodyFile ./data/guestRole.json|convertfrom-json
					$response

					echo "Admin Role"
					$adminRole = @{ProjectRole=@{ProjectVersion=$projVersionId;Name="Admin";HasAccessByDefault="true";CanReadByDefault="true";CanCreateByDefault="true";CanUpdateByDefault="true";CanDeleteByDefault="true"}}|convertto-json
					$adminRole|out-file ./data/adminRole.json
					$response = eapi AddProjectRole -bodyFile ./data/adminRole.json|convertfrom-json
					$response


				}
			}
		}
	}
}