CREATE PROCEDURE [dbo].[spUpdateCustomerNoteType]
	@activeStatus BIT,
	@customerNoteType NVARCHAR(50),
	@customerNoteTypeId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[CustomerNoteType]
SET
	[ActiveStatus] = @activeStatus,
	[CustomerNoteType] = @customerNoteType
WHERE [CustomerNoteTypeId] = @customerNoteTypeId