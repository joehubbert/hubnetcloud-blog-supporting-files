CREATE VIEW [dbo].[vwDeploymentLog]
AS

SELECT
[DeploymentLogId] AS [Deployment Log Id],
[DatabaseVersion] AS [Database Version],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By]
FROM [dbo].[DeploymentLog]