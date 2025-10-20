CREATE VIEW [dbo].[vwMarketingChannel]
AS

SELECT
[MarketingChannelId] AS [Marketing Channel Id],
[MarketingChannel] AS [Marketing Channel],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By],
[RowVersion] AS [Row Version]
FROM [dbo].[MarketingChannel]