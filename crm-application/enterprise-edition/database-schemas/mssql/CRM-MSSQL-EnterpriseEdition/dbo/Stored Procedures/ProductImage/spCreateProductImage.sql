CREATE PROCEDURE [dbo].[spCreateProductImage]
	@productId UNIQUEIDENTIFIER,
	@productImage VARBINARY(MAX),
	@productImageAltText NVARCHAR(150) = NULL,
	@productImageCaption NVARCHAR(255) = NULL,
	@productImageDisplayOrder TINYINT,
	@productImageIsThumbnail BIT
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			INSERT INTO [dbo].[ProductImage]
			(
				[ProductId],
				[ProductImage],
				[ProductImageAltText],
				[ProductImageCaption],
				[ProductImageDisplayOrder],
				[ProductImageIsThumbnail]
			)
			VALUES
			(
				@productId,
				@productImage,
				@productImageAltText,
				@productImageCaption,
				@productImageDisplayOrder,
				@productImageIsThumbnail
			);

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END