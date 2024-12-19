CREATE PROCEDURE [dbo].[spUpdateCustomerNoteType]
	@customerNoteType NVARCHAR(50),
	@customerNoteTypeId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[CustomerNoteType]
SET
	[CustomerNoteType] = @customerNoteType
WHERE [CustomerNoteTypeId] = @customerNoteTypeId