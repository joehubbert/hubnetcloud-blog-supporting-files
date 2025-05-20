CREATE PROCEDURE [dbo].[spGetAllCustomerNoteType]
AS

SELECT
[Customer Note Type Id],
[Customer Note Type],
[Active Status]
FROM [dbo].[vwCustomerNoteType]