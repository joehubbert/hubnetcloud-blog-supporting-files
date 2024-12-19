CREATE PROCEDURE [dbo].[spCreateProductNote]
	@productId UNIQUEIDENTIFIER,
	@productNote NVARCHAR(MAX),
	@productNoteTitle NVARCHAR(50),
	@productNoteTypeId UNIQUEIDENTIFIER
AS
INSERT INTO [dbo].[ProductNote]
(
	[ProductId],
	[ProductNote],
	[ProductNoteTitle],
	[ProductNoteTypeId]
)
VALUES
(
	@productId,
	@productNote,
	@productNoteTitle,
	@productNoteTypeId
)