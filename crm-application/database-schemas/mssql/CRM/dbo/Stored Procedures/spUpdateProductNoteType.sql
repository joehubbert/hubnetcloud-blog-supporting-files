CREATE PROCEDURE [dbo].[spUpdateProductNoteType]
	@activeStatus BIT,
	@productNoteType NVARCHAR(50),
	@productNoteTypeId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[ProductNoteType]
SET
	[ActiveStatus] = @activeStatus,
	[ProductNoteType] = @productNoteType
WHERE [ProductNoteTypeId] = @productNoteTypeId