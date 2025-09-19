CREATE PROCEDURE [dbo].[spGetAllOrderForProduct]
	@productId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Product Id],
			[Order Id],
			[Order Type Id],
			[Order Type],
			[Product Quantity],
			[Product Order Value]
			FROM [dbo].[vwOrderProduct]
			WHERE [Product Id] = @productId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END