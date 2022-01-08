##Pick an Azure region nearest to where you are located
Get-AzLocation

##Set paremeters to be used by ARM template

$resourceGroupName = ''
$deploymentLocation = '' ##Must be a location property of the output from the previous command
$resourceRandomName = '' #Must be globally unique and sixteen characters or less
$tenantId = (Get-AzTenant).Id
$currentUser = (Get-AzContext).Account.Id
$principalObjectId = (Get-AzADUser -UserPrincipalName $currentUser).Id

##Deploy the resource group
New-AzSubscriptionDeployment -Location $deploymentLocation -TemplateFile '<Insert full path to folder>\arm-template-resource-group.json' -resourceGroupName $resourceGroupName -deploymentLocation $deploymentlocation

##Deploy the resources
New-AzResourceGroupDeployment -ResourceGroupName $resourceGroupName -TemplateFile '<Insert full path to folder>\arm-template-resources.json' -deploymentLocation $deploymentlocation -resourceRandomName $resourceRandomName -tenantId $tenantId -principalObjectId $principalObjectId