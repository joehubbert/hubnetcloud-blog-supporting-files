CREATE PROCEDURE [dbo].[spUpdateProductNote]
	@productNote NVARCHAR(4000),
	@productNoteId UNIQUEIDENTIFIER,
	@productNoteTitle NVARCHAR(50),
	@productNoteTypeId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[ProductNote]
SET 
	[ProductNote] = @productNote,
	[ProductNoteTitle] = @productNoteTitle,
	[ProductNoteTypeId] = @productNoteTypeId
WHERE [ProductNoteId] = @productNoteId