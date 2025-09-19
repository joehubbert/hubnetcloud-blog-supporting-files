CREATE PROCEDURE [dbo].[spUpdateProductImage]
	@productId UNIQUEIDENTIFIER,
	@productImage VARBINARY(MAX),
	@productImageAltText NVARCHAR(150) = NULL,
	@productImageCaption NVARCHAR(255) = NULL,
	@productImageDisplayOrder TINYINT,
	@productImageId UNIQUEIDENTIFIER,
	@productImageIsThumbnail BIT
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

		UPDATE [dbo].[ProductImage]
		SET
			[ProductId] = @productId,
			[ProductImage] = @productImage,
			[ProductImageAltText] = @productImageAltText,
			[ProductImageCaption] = @productImageCaption,
			[ProductImageDisplayOrder] = @productImageDisplayOrder,
			[ProductImageIsThumbnail] = @productImageIsThumbnail
		WHERE
			[ProductImageId] = @productImageId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END