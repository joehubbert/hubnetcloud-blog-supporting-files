CREATE PROCEDURE [dbo].[spUpdateCustomerNote]
	@customerNote NVARCHAR(MAX),
	@customerNoteId UNIQUEIDENTIFIER,
	@customerNoteTitle NVARCHAR(50),
	@customerNoteTypeId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[CustomerNote]
SET 
	[CustomerNote] = @customerNote,
	[CustomerNoteTitle] = @customerNoteTitle,
	[CustomerNoteTypeId] = @customerNoteTypeId
WHERE [CustomerNoteId] = @customerNoteId