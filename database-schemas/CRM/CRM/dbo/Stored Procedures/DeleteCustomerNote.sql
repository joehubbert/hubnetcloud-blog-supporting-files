CREATE PROCEDURE [dbo].[DeleteCustomerNote]
	@customerNoteId UNIQUEIDENTIFIER
AS
DELETE FROM [dbo].[CustomerNote]
WHERE [CustomerNoteId] = @customerNoteId