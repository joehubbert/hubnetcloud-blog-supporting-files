param azureAccountId string
param azureAccountObjectId string
param b2cDirectoryName string
param publicIpAddress string
param resourceLocation string
param resourcePrefix string
param websiteURLSuffix string

resource appServicePlan 'Microsoft.Web/serverfarms@2023-01-01' = {
  name: '${resourcePrefix}-asp'
  location: resourceLocation
  sku: {
    name: 'B2'
    tier: 'Basic'
    size: 'B2'
    family: 'B'
    capacity: 1
  }
  kind: 'linux'
  properties: {
    perSiteScaling: false
    elasticScaleEnabled: false
    maximumElasticWorkerCount: 1
    isSpot: false
    reserved: true
    isXenon: false
    hyperV: false
    targetWorkerCount: 0
    targetWorkerSizeId: 0
    zoneRedundant: false
  }
}

resource b2bIdentity 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' = {
  name: '${resourcePrefix}-b2b-umi'
  location: resourceLocation
}

resource b2cIdentity 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' = {
  name: '${resourcePrefix}-b2c-umi'
  location: resourceLocation
}

resource logAnalyticsWorkspace 'Microsoft.OperationalInsights/workspaces@2022-10-01' = {
  name: '${resourcePrefix}-log-analytics-workspace'
  location: resourceLocation
  properties: {
    defaultDataCollectionRuleResourceId: 'string'
    features: {
      enableLogAccessUsingOnlyResourcePermissions: true
      immediatePurgeDataOn30Days: true
    }
    publicNetworkAccessForIngestion: 'Enabled'
    publicNetworkAccessForQuery: 'Enabled'
    retentionInDays: 30
    sku: {
      name: 'PerGB2018'
    }
  }
}

resource pbiEmbedded 'Microsoft.PowerBIDedicated/capacities@2021-01-01' = {
  name: '${resourcePrefix}pbiembedded'
  location: resourceLocation
  sku: {
    name: 'A1'
    tier: 'PBIE_Azure'
  }
  properties: {
    administration: {
      members: [
        azureAccountId
      ]
    }
  }
}

resource b2bAppInsights 'Microsoft.Insights/components@2020-02-02' = {
  name: '${resourcePrefix}-b2b-appi'
  dependsOn: [
    logAnalyticsWorkspace
  ]
  location: resourceLocation
  kind: 'web'
  properties: {
    Application_Type: 'web'
    IngestionMode: 'LogAnalytics'
    publicNetworkAccessForIngestion: 'Enabled'
    publicNetworkAccessForQuery: 'Enabled'
    WorkspaceResourceId: logAnalyticsWorkspace.id
  }
}

resource b2cAppInsights 'Microsoft.Insights/components@2020-02-02' = {
  name: '${resourcePrefix}-b2c-appi'
  dependsOn: [
    logAnalyticsWorkspace
  ]
  location: resourceLocation
  kind: 'web'
  properties: {
    Application_Type: 'web'
    IngestionMode: 'LogAnalytics'
    publicNetworkAccessForIngestion: 'Enabled'
    publicNetworkAccessForQuery: 'Enabled'
    WorkspaceResourceId: logAnalyticsWorkspace.id
  }
}

resource b2bSite 'Microsoft.Web/sites@2023-01-01' = {
  name: '${resourcePrefix}-${websiteURLSuffix}-b2b'
  dependsOn: [
    appServicePlan, b2bIdentity
  ]
  location: resourceLocation
  kind: 'app,linux'
  identity:{
    type: 'UserAssigned'
    userAssignedIdentities: {
      '${b2bIdentity.id}': {}
    }
  }
  properties: {
    enabled: true
    serverFarmId: appServicePlan.id
    reserved: true
    vnetRouteAllEnabled: true
    siteConfig: {
      numberOfWorkers: 1
      linuxFxVersion: 'DOTNETCORE|8.0'
      minTlsVersion: '1.2'
    }
    clientCertMode: 'Required'
    httpsOnly: true
    publicNetworkAccess: 'Enabled'
  }
}

resource b2bSiteAppInsightsExtentsion 'Microsoft.Web/sites/siteextensions@2023-01-01' = {
  parent: b2bSite
  name: 'Microsoft.ApplicationInsights.AzureWebSites'
  dependsOn: [
    b2bAppInsights
  ]
}

resource b2bSiteLogging 'Microsoft.Web/sites/config@2023-01-01' = {
  parent: b2bSite
  name: 'appsettings'
  dependsOn: [
    b2bSiteAppInsightsExtentsion
  ]
  properties: {
    APPINSIGHTS_INSTRUMENTATIONKEY: b2bAppInsights.properties.InstrumentationKey
  }
}

resource b2bSiteAppInsightsLogSettings 'Microsoft.Web/sites/config@2023-01-01' = {
  parent: b2bSite
  name: 'logs'
  properties: {
    applicationLogs: {
      fileSystem: {
        level: 'Warning'
      }
    }
    httpLogs: {
      fileSystem: {
        retentionInMb: 40
        enabled: true
      }
    }
    failedRequestsTracing: {
      enabled: true
    }
    detailedErrorMessages: {
      enabled: true
    }
  }
}

resource b2cSite 'Microsoft.Web/sites@2023-01-01' = {
  name: '${resourcePrefix}-${websiteURLSuffix}-b2c'
  dependsOn: [
    appServicePlan, b2cIdentity
  ]
  location: resourceLocation
  kind: 'app,linux'
  identity:{
    type: 'UserAssigned'
    userAssignedIdentities: {
      '${b2cIdentity.id}': {}
    }
  }
  properties: {
    enabled: true
    serverFarmId: appServicePlan.id
    reserved: true
    vnetRouteAllEnabled: true
    siteConfig: {
      numberOfWorkers: 1
      linuxFxVersion: 'DOTNETCORE|8.0'
      minTlsVersion: '1.2'
    }
    clientCertMode: 'Required'
    httpsOnly: true
    publicNetworkAccess: 'Enabled'
  }
}

resource b2cSiteAppInsightsExtentsion 'Microsoft.Web/sites/siteextensions@2023-01-01' = {
  parent: b2cSite
  name: 'Microsoft.ApplicationInsights.AzureWebSites'
  dependsOn: [
    b2bAppInsights
  ]
}

resource b2cSiteLogging 'Microsoft.Web/sites/config@2023-01-01' = {
  parent: b2cSite
  name: 'appsettings'
  dependsOn: [
    b2cSiteAppInsightsExtentsion
  ]
  properties: {
    APPINSIGHTS_INSTRUMENTATIONKEY: b2cAppInsights.properties.InstrumentationKey
  }
}

resource b2cSiteAppInsightsLogSettings 'Microsoft.Web/sites/config@2023-01-01' = {
  parent: b2cSite
  name: 'logs'
  properties: {
    applicationLogs: {
      fileSystem: {
        level: 'Warning'
      }
    }
    httpLogs: {
      fileSystem: {
        retentionInMb: 40
        enabled: true
      }
    }
    failedRequestsTracing: {
      enabled: true
    }
    detailedErrorMessages: {
      enabled: true
    }
  }
}

resource logicalSQLServer 'Microsoft.Sql/servers@2023-08-01-preview' = {
  name: '${resourcePrefix}-${websiteURLSuffix}-db'
  location: resourceLocation
  properties: {
    administrators: {
      azureADOnlyAuthentication: true
      administratorType: 'ActiveDirectory'
      login: azureAccountId
      principalType: 'User'
      sid: azureAccountObjectId
      tenantId: subscription().tenantId
    }
    minimalTlsVersion: '1.2'
    publicNetworkAccess: 'Enabled'
    restrictOutboundNetworkAccess: 'Disabled'
  }
}

resource logicalSQLServerFWRuleAllowAzureIps 'Microsoft.Sql/servers/firewallRules@2023-08-01-preview' = {
  parent: logicalSQLServer
  name: 'AllowAllWindowsAzureIps'
}

resource logicalSQLServerFWRuleAllowCurrentIp 'Microsoft.Sql/servers/firewallRules@2023-08-01-preview' = {
  parent: logicalSQLServer
  name: 'AllowClientIp'
  properties: {
    startIpAddress: publicIpAddress
    endIpAddress: publicIpAddress
  }
}

resource authenticationSQLDatabase 'Microsoft.Sql/servers/databases@2023-08-01-preview' = {
  parent: logicalSQLServer
  name: '${resourcePrefix}-authentication'
  location: resourceLocation
  sku: {
    name: 'Basic'
    tier: 'Basic'
    capacity: 5
  }
  properties: {
    availabilityZone: 'NoPreference'
    catalogCollation: 'SQL_Latin1_General_CP1_CI_AS'
    collation: 'Latin1_General_CI_AS'
    createMode: 'Default'
    isLedgerOn: false
    licenseType: 'LicenseIncluded'
    readScale: 'Disabled'
    requestedBackupStorageRedundancy: 'Geo'
    zoneRedundant: false
  }
}

resource reportingSQLDatabase 'Microsoft.Sql/servers/databases@2023-08-01-preview' = {
  parent: logicalSQLServer
  name: '${resourcePrefix}-reporting'
  location: resourceLocation
  sku: {
    name: 'Basic'
    tier: 'Basic'
    capacity: 5
  }
  properties: {
    availabilityZone: 'NoPreference'
    catalogCollation: 'SQL_Latin1_General_CP1_CI_AS'
    collation: 'Latin1_General_CI_AS'
    createMode: 'Default'
    isLedgerOn: false
    licenseType: 'LicenseIncluded'
    readScale: 'Disabled'
    requestedBackupStorageRedundancy: 'Geo'
    zoneRedundant: false
  }
}

resource b2cTenant 'Microsoft.AzureActiveDirectory/b2cDirectories@2023-05-17-preview' = {
  name: '${resourcePrefix}-b2c-directory'
  location: resourceLocation
  sku: {
    name: 'PremiumP1'
    tier: 'A0'
  }
  properties: {
  }
}
