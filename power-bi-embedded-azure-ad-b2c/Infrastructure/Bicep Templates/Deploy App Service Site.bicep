param appServicePlanName string
param appServiceSiteName string
param environmentName string
param managementResourceGroup string
param resourceLocation string
param userManagedIdentityName string

resource appServicePlan 'Microsoft.Web/serverfarms@2022-03-01' existing = {
  name: appServicePlanName
}

resource userManagedIdentity 'Microsoft.ManagedIdentity/userAssignedIdentities@2022-01-31-preview' existing = {
  name: userManagedIdentityName
  scope: resourceGroup(managementResourceGroup)
}

resource appServiceSite 'Microsoft.Web/sites@2022-03-01' = {
  name: appServiceSiteName
  location: resourceLocation
  tags: {
    enivronment: environmentName
  }
  kind: 'app'
  identity: {
    type: 'UserAssigned'
    userAssignedIdentities: userManagedIdentity
  }
  properties: {
    clientAffinityEnabled: true
    clientCertEnabled: false
    clientCertMode: 'Optional'
    containerSize: 0
    dailyMemoryTimeQuota: 0
    enabled: true
    hostNamesDisabled: false
    httpsOnly: true
    hyperV: false
    isXenon: false
    keyVaultReferenceIdentity: 'UserAssigned'
    publicNetworkAccess: 'Enabled'
    redundancyMode: 'None'
    reserved: false
    scmSiteAlsoStopped: false
    serverFarmId: appServicePlan.id
    siteConfig: {
      acrUseManagedIdentityCreds: false
      alwaysOn: false
      autoHealEnabled: false
      defaultDocuments: [
        'Default.htm'
        'Default.html'
        'Default.asp'
        'index.htm'
        'index.html'
        'iisstart.htm'
        'default.aspx'
        'index.php'
        'hostingstart.html'
    ]
      detailedErrorLoggingEnabled: false
      ftpsState: 'FtpsOnly'
      functionAppScaleLimit: 0
      functionsRuntimeScaleMonitoringEnabled: false
      http20Enabled: true
      httpLoggingEnabled: false
      keyVaultReferenceIdentity: 'UserAssigned'
      logsDirectorySizeLimit: 35
      managedPipelineMode: 'Integrated'
      minimumElasticInstanceCount: 0
      minTlsVersion: '1.2'
      netFrameworkVersion: '4.0'
      numberOfWorkers: 1
      phpVersion: '7.4'
      preWarmedInstanceCount: 0
      publicNetworkAccess: 'Allow'
      publishingUsername: '$${appServiceSiteName}'
      remoteDebuggingEnabled: false
      requestTracingEnabled: false
      scmIpSecurityRestrictionsUseMain: false
      scmMinTlsVersion: '1.2'
      scmType: 'ExternalGit'
      use32BitWorkerProcess: false
      virtualApplications: [
        {
            virtualPath: '/'
            physicalPath: 'site\\wwwroot'
            preloadEnabled: false
        }
    ]
      vnetName: 'string'
      vnetPrivatePortsCount: 1
      vnetRouteAllEnabled: true
      websiteTimeZone: 'UTC'
      webSocketsEnabled: false
    }
    storageAccountRequired: false
    virtualNetworkSubnetId: 'string'
    vnetContentShareEnabled: true
    vnetImagePullEnabled: true
    vnetRouteAllEnabled: true
  }
}
