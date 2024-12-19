CREATE PROCEDURE [dbo].[spUpdateProductNoteType]
	@productNoteType NVARCHAR(50),
	@productNoteTypeId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[ProductNoteType]
SET
	[ProductNoteType] = @productNoteType
WHERE [ProductNoteTypeId] = @productNoteTypeId