CREATE VIEW [dbo].[vwMarketingChannel]
AS

SELECT
[MarketingChannelId] AS [Marketing Channel Id],
[MarketingChannel] AS [Marketing Channel],
[ActiveStatus] AS [Active Status],
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] AS [Modified By]
FROM [dbo].[MarketingChannel]