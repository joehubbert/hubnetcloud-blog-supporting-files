CREATE PROCEDURE [dbo].[spGetAllCustomerNoteType]
AS

SELECT
[CustomerNoteTypeId] AS [Customer Note Type Id],
[CustomerNoteType] AS [Customer Note Type]
FROM [dbo].[CustomerNoteType]