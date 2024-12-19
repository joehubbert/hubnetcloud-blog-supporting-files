CREATE PROCEDURE [dbo].[spGetProductNoteType]
	@productNoteTypeId UNIQUEIDENTIFIER
AS

SELECT
[Product Note Type Id],
[Product Note Type],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwProductNoteType]
WHERE [Product Note Type Id] = @productNoteTypeId