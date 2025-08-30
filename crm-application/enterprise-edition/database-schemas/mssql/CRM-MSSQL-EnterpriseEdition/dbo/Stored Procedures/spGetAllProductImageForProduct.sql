CREATE PROCEDURE [dbo].[spGetAllProductImageForProduct]
	@productId UNIQUEIDENTIFIER
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
			[Created Timestamp UTC],
			[Created By],
			[Created Timestamp UTC],
			[Modified By]
			FROM [dbo].[vwProductImage]
			WHERE [Product Id] = @productId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END