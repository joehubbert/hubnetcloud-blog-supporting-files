##Run if Az PowerShell module is not already installed
Install-Module Az -AllowClobber 

##Run if Az PowerShell module is already installed but update check is required 
Update-Module Az

Import-Module Az

Connect-AzAccount

##Set our variables 
$vaultName = '<Enter previously created ' 
$databricksWorkspaceName = '<Enter your workspace name>' 
$servicePrincipalName = $databricksWorkspaceName + '-ServicePrincipal' 
$servicePrincipalScope = '/subscriptions/<subscriptionid>/resourceGroups/<resourcegroupname>/<providers/Microsoft.Storage/storageAccounts/<storageaccountname>'

##Create Azure AD Service Principal 
$createServicePrincipal = New-AzADServicePrincipal -DisplayName $servicePrincipalName -Role 'Storage Blob Data Contributor' -Scope $servicePrincipalScope

##Save service principal client id in KeyVault 
Set-AzKeyVaultSecret -VaultName $vaultName -Name 'databricks-service-principal-client-id' -SecretValue (ConvertTo-SecureString -AsPlainText ($createServicePrincipal.ApplicationId)) 

##Save service principal secret in KeyVault 
Set-AzKeyVaultSecret -VaultName $vaultName -Name 'databricks-service-principal-secret' -SecretValue $createServicePrincipal.Secret