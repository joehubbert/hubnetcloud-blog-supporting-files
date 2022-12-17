
param networkSecurityGroupName string
param networkSecurityGroupRuleAccess string
param networkSecurityGroupRuleDescription string
param networkSecurityGroupRuleDestinationAddressPrefix string
param networkSecurityGroupRuleDestinationPortRange string
param networkSecurityGroupRuleDirection string
param networkSecurityGroupRulePriority int
param networkSecurityGroupRuleProtocol string
param networkSecurityGroupRuleSourceAddressPrefix string
param networkSecurityGroupRuleSourcePortRange string
param networkSecurityGroupRuleName string

resource networkSecurityGroup 'Microsoft.Network/networkSecurityGroups@2022-05-01' existing = {
  name: networkSecurityGroupName
}

resource networkSecurityGroupRule 'Microsoft.Network/networkSecurityGroups/securityRules@2022-05-01' = {
  name: networkSecurityGroupRuleName
  parent: networkSecurityGroup
  properties: {
    access: networkSecurityGroupRuleAccess
    description: networkSecurityGroupRuleDescription
    destinationAddressPrefix: networkSecurityGroupRuleDestinationAddressPrefix
    destinationAddressPrefixes: [
      networkSecurityGroupRuleDestinationAddressPrefix
    ]
    destinationPortRange: networkSecurityGroupRuleDestinationPortRange
    destinationPortRanges: [
      networkSecurityGroupRuleDestinationPortRange
    ]
    direction: networkSecurityGroupRuleDirection
    priority: networkSecurityGroupRulePriority
    protocol: networkSecurityGroupRuleProtocol
    sourceAddressPrefix: networkSecurityGroupRuleSourceAddressPrefix
    sourceAddressPrefixes: [
      networkSecurityGroupRuleSourceAddressPrefix
    ]
    sourcePortRange: networkSecurityGroupRuleSourcePortRange
    sourcePortRanges: [
      networkSecurityGroupRuleSourcePortRange
    ]
  }
}
