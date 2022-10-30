param applicationResourceGroup string
param applicationUserManagedIdentityName string
param appServicePlanName string
param appServicePlanSKUFamily string
param appServicePlanSKUName string
param appServicePlanSKUSize string
param appServicePrivateDNSZoneName string
param appServiceSiteName string
param azureActiveDirectoryB2CDirectoryCountryCode string
param azureActiveDirectoryB2CDirectoryDisplayName string
param azureActiveDirectoryB2CDirectoryName string
param azureActiveDirectoryB2CDirectorySKU string
@secure()
param azureActiveDirectoryTenantId string
param azureSQLDatabaseName string
param azureSQLDatabaseSKUName string
param azureSQLDatabaseSKUTier string
@secure()
param azureSQLLogicalServerAADAuthLoginName string
@secure()
param azureSQLLogicalServerAADAuthPrincipalType string
@secure()
param azureSQLLogicalServerAADAuthSID string
param azureSQLLogicalServerName string
@secure()
param azureSQLLogicalServerSQLAuthPassword string
@secure()
param azureSQLLogicalServerSQLAuthUsername string
param dataResourceGroup string
param environmentName string
param keyVaultName string
param keyVaultPrivateDNSZoneName string
param managementResourceGroup string
param networkResourceGroup string
@secure()
param powerBIEmbeddedResourceAdministrator string
param powerBIEmbeddedResourceName string
param powerBIEmbeddedResourceSKUCapacity int
param powerBIEmbeddedResourceSKUName string
param resourceLocation string
param sqlDatabasePrivateDNSZoneName string
param virtualNetworkAddressSpace string
param virtualNetworkName string
param virtualNetworkPrivateEndpointSubnetAddressSpace string
param virtualNetworkPrivateEndpointSubnetName string

module virtualNetwork 'Deploy Virtual Network.bicep' = {
  name: 'deployVirtualNetwork'
  scope: resourceGroup(networkResourceGroup)
  params: {
    environmentName: environmentName
    resourceLocation: resourceLocation
    virtualNetworkAddressSpace: virtualNetworkAddressSpace
    virtualNetworkName: virtualNetworkName
    virtualNetworkPrivateEndpointSubnetAddressSpace: virtualNetworkPrivateEndpointSubnetAddressSpace
    virtualNetworkPrivateEndpointSubnetName: virtualNetworkPrivateEndpointSubnetName
  }
}

module applicationUserManagedIdentity 'Deploy User Managed Identity.bicep' = {
  name: 'deployApplicatonUserManagedIdentity'
  scope: resourceGroup(managementResourceGroup)
  params: {
    environmentName: environmentName
    resourceLocation: resourceLocation
    userManagedIdentityName: applicationUserManagedIdentityName
  }
}

module appServicePrivateDNSZone 'Deploy Private DNS Zone.bicep' = {
  name: 'deployAppServicePrivateDNSZone'
  scope: resourceGroup(networkResourceGroup)
  params:{
    environmentName: environmentName
    privateDNSZoneName: appServicePrivateDNSZoneName
    resourceLocation: resourceLocation
  }
}

module keyVaultPrivateDNSZone 'Deploy Private DNS Zone.bicep' = {
  name: 'deployKeyVaultPrivateDNSZone'
  scope: resourceGroup(networkResourceGroup)
  params:{
    environmentName: environmentName
    privateDNSZoneName: keyVaultPrivateDNSZoneName
    resourceLocation: resourceLocation
  }
}

module sqlDatabasePrivateDNSZone 'Deploy Private DNS Zone.bicep' = {
  name: 'deploySQLDatabasePrivateDNSZone'
  scope: resourceGroup(networkResourceGroup)
  params:{
    environmentName: environmentName
    privateDNSZoneName: sqlDatabasePrivateDNSZoneName
    resourceLocation: resourceLocation
  }
}

module keyVault 'Deploy Key Vault.bicep' = {
  name: 'deployAzureKeyVault'
  scope: resourceGroup(managementResourceGroup)
  dependsOn: [
    keyVaultPrivateDNSZone
  ]
  params: {
    azureActiveDirectoryTenantId: azureActiveDirectoryTenantId
    environmentName: environmentName
    keyVaultName: keyVaultName
    resourceLocation: resourceLocation
  }
}

module keyVaultRBACPermissions 'Deploy Azure Resource Manager Role-Based Access Control Permission.bicep' = {
  name: 'deployKeyVaultRBACPermissions'
  scope: resourceGroup(managementResourceGroup)
  dependsOn: [
    applicationUserManagedIdentity, keyVault
  ]
  params:{
    keyVaultName: keyVaultName
    managementResourceGroup: managementResourceGroup
    userManagedIdentityName: applicationUserManagedIdentityName
  }
}

module azureSQLDatabaseLogicalServer 'Deploy Azure SQL Logical Server.bicep' = {
  name: 'deployAzureSQLDatabaseLogicalServer'
  scope: resourceGroup(dataResourceGroup)
  dependsOn: [
    sqlDatabasePrivateDNSZone
  ]
  params:{
    azureActiveDirectoryTenantId: azureActiveDirectoryTenantId
    azureSQLLogicalServerAADAuthLoginName: azureSQLLogicalServerAADAuthLoginName
    azureSQLLogicalServerAADAuthPrincipalType: azureSQLLogicalServerAADAuthPrincipalType
    azureSQLLogicalServerAADAuthSID: azureSQLLogicalServerAADAuthSID
    azureSQLLogicalServerName: azureSQLLogicalServerName
    azureSQLLogicalServerSQLAuthPassword: azureSQLLogicalServerSQLAuthPassword
    azureSQLLogicalServerSQLAuthUsername: azureSQLLogicalServerSQLAuthUsername
    environmentName: environmentName
    resourceLocation: resourceLocation
  }
}

module azureSQLDatabase 'Deploy Azure SQL Database.bicep' = {
  name: 'deployAzureSQLDatabase'
  scope: resourceGroup(dataResourceGroup)
  dependsOn: [
    azureSQLDatabaseLogicalServer, keyVaultRBACPermissions
  ]
  params:{
    azureSQLDatabaseName: azureSQLDatabaseName
    azureSQLDatabaseSKUName: azureSQLDatabaseSKUName
    azureSQLDatabaseSKUTier: azureSQLDatabaseSKUTier
    azureSQLLogicalServerName: azureSQLLogicalServerName
    environmentName: environmentName
    resourceLocation: resourceLocation
  }
}

module azureActiveDirectoryB2C 'Deploy Azure Active Directory B2C Directory.bicep' = {
  name: 'deployazureActiveDirectoryB2C'
  scope: resourceGroup(applicationResourceGroup)
  params:{
    azureActiveDirectoryB2CDirectoryCountryCode: azureActiveDirectoryB2CDirectoryCountryCode
    azureActiveDirectoryB2CDirectoryDisplayName: azureActiveDirectoryB2CDirectoryDisplayName
    azureActiveDirectoryB2CDirectoryName: azureActiveDirectoryB2CDirectoryName
    azureActiveDirectoryB2CDirectorySKU: azureActiveDirectoryB2CDirectorySKU
    environmentName: environmentName
    resourceLocation: resourceLocation
  }
}

module appServicePlan 'Deploy App Service Plan.bicep' = {
  name: 'deployAppServicePlan'
  scope: resourceGroup(applicationResourceGroup)
  params: {
    appServicePlanName: appServicePlanName
    appServicePlanSKUFamily: appServicePlanSKUFamily
    appServicePlanSKUName: appServicePlanSKUName
    appServicePlanSKUSize: appServicePlanSKUSize
    environmentName: environmentName
    resourceLocation: resourceLocation
  }
}

module appServiceSite 'Deploy App Service Site.bicep' = {
  name: 'deployAppServiceSite'
  scope: resourceGroup(applicationResourceGroup)
  dependsOn: [
    appServicePlan, appServicePrivateDNSZone, keyVaultRBACPermissions
  ]
  params: {
    appServicePlanName: appServicePlanName
    appServiceSiteName: appServiceSiteName
    environmentName: environmentName
    managementResourceGroup: managementResourceGroup
    resourceLocation: resourceLocation
    userManagedIdentityName: applicationUserManagedIdentityName
  }
}

module powerBIEmbedded 'Deploy Power BI Embedded.bicep' = {
  name: 'deployPowerBIEmbedded'
  scope: resourceGroup(applicationResourceGroup)
  params: {
    environmentName: environmentName
    powerBIEmbeddedResourceAdministrator: powerBIEmbeddedResourceAdministrator
    powerBIEmbeddedResourceName: powerBIEmbeddedResourceName
    powerBIEmbeddedResourceSKUCapacity: powerBIEmbeddedResourceSKUCapacity
    powerBIEmbeddedResourceSKUName: powerBIEmbeddedResourceSKUName
    resourceLocation: resourceLocation
  }
}


