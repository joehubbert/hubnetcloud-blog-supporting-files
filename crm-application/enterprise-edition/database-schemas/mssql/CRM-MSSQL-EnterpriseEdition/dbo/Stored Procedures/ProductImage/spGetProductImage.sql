CREATE PROCEDURE [dbo].[spGetProductImage]
	@productImageId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Product Id],
			[Product Name],
			[Product Image Id],
			[Product Image],
			[Product Image Alt Text],
			[Product Image Caption],
			[Product Image Display Order],
			[Product Image Is Thumbnail],
			[Created Timestamp UTC],
			[Created By],
			[Created Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwProductImage]
			WHERE [Product Image Id] = @productImageId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END