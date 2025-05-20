CREATE PROCEDURE [dbo].[spGetAllNoteForCustomer]
	@customerId UNIQUEIDENTIFIER
AS

SELECT
[Customer Note Id],
[Customer Note Title],
[Customer Note Type],
[Customer Note],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwCustomerNoteSummary]
WHERE [Customer Id] = @customerId