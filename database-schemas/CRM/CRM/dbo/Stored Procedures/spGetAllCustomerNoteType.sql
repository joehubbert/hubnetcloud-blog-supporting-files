CREATE PROCEDURE [dbo].[spGetAllCustomerNoteType]
AS

SELECT
[Customer Note Type Id],
[Customer Note Type]
FROM [dbo].[vwCustomerNoteType]