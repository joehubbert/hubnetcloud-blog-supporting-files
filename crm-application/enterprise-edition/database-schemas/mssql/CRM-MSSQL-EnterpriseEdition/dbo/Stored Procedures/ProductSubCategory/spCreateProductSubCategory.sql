CREATE PROCEDURE [dbo].[spCreateProductSubCategory]
	@activeStatus BIT,
	@productCategoryId UNIQUEIDENTIFIER,
	@productSubCategory NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #ProductSubCategoryTemp
			(
				[ProductCategoryId] UNIQUEIDENTIFIER NOT NULL,
				[ProductSubCategory] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #ProductSubCategoryTemp
			(
				[ProductCategoryId],
				[ProductSubCategory],
				[ActiveStatus]
			)
			VALUES
			(
				@productCategoryId,
				@productSubCategory,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[ProductSubCategory] PSC
				INNER JOIN #ProductSubCategoryTemp PSCT ON PSC.[ProductSubCategory] = PSCT.[ProductSubCategory]
				WHERE PSC.[ProductSubCategory] = PSCT.[ProductSubCategory]
			)
			THROW 50000, 'Product Sub Category already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[ProductSubCategory] AS target
			USING #ProductSubCategoryTemp AS source
			ON target.[ProductSubCategory] = source.[ProductSubCategory]
			AND target.[ProductCategoryId] = source.[ProductCategoryId]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[ProductCategoryId],
				[ProductSubCategory],
				[ActiveStatus]
			)
			VALUES
			(
				source.[ProductCategoryId],
				source.[ProductSubCategory],
				source.[ActiveStatus]
			);

			DROP TABLE #ProductSubCategoryTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END