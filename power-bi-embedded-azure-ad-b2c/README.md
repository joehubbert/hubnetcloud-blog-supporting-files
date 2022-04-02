# Introduction 
This is a Blazor server-side application written in C# (.NET6) to be executed in the context of Azure AD B2C. 
It renders Power BI Embedded reports that are stored in Azure AD B2B.
It applies row-level security in the context of the Azure AD B2C user.

# Getting Started
You'll need to do the following:

- Create an app registration in your B2B tenant.
- Enable service principal access to Power BI from the Power BI Admin portal.
- Give that app registration admin permissions on the required Power BI workspace. Lower permissions do not work unfortunately.
- Create an app registration in your B2C tenant.
- Setup a lookup database that can take the users' e-mail address from the claim, lookup an integer value from the database that matches to the corresponding organisation id.
   - The reason why GUIDs haven't been used is that Power BI does not handle GUIDs as a native data type and interprets them as strings which has an adverse effect on performance.
- Store the connection string for the sql server in key vault. The Authentication type should be Active Directory Default
- Store the workspace id for the Power BI workspace in key vault.
- Store the report id for the relevant report in key vault with a name for the secret relevant to the report.
   - It is also possible to use different Power BI datasets within your embedded report but that is outside of the scope of this demo.

If developing locally **DO NOT USE IN PRODUCTION** :
- You can hardcode values in appsettings.json in the solution

If developing for Azure, you can leave the values in appsettings.json blank and inject values using either the Azure App Configuration Service/Azure App Service with linked Key Vault secrets or hardcoded values. This is much more advisable for both development/production scenarios.

# Build and Test
- Ensure that the B2B app registration has redirect URIs (Web) to point to the local IIS Express debug session
- Ensure that the B2C app registration has redirect URIs (Web) to point to the local IIS Express debug session