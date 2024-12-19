CREATE PROCEDURE [dbo].[spGetCustomerType]
	@customerTypeId UNIQUEIDENTIFIER
AS

SELECT
[Customer Type Id],
[Customer Type],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwCustomerType]
WHERE [Customer Type Id] = @customerTypeId