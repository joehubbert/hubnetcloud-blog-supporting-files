CREATE PROCEDURE [dbo].[spCreateProductCategory]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER,
	@productCategory NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #ProductCategoryTemp
			(
				[CompanyConfigurationId] UNIQUEIDENTIFIER NOT NULL,
				[ProductCategory] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #ProductCategoryTemp
			(
				[CompanyConfigurationId],
				[ProductCategory],
				[ActiveStatus]
			)
			VALUES
			(
				@companyConfigurationId,
				@productCategory,
				@activeStatus
			)

			IF EXISTS
			(
			SELECT *
			FROM [dbo].[ProductCategory] PC
			INNER JOIN #ProductCategoryTemp PCT ON PC.[CompanyConfigurationId] = PCT.[CompanyConfigurationId]
			AND PC.[ProductCategory] = PCT.[ProductCategory]
			WHERE PC.[CompanyConfigurationId] = PCT.[CompanyConfigurationId]
			AND PC.[ProductCategory] = PCT.[ProductCategory]
			)
			THROW 50000, 'Product Category already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[ProductCategory] AS target
			USING #ProductCategoryTemp AS source
			ON target.[CompanyConfigurationId] = source.[CompanyConfigurationId]
			AND target.[ProductCategory] = source.[ProductCategory]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[CompanyConfigurationId],
				[ProductCategory],
				[ActiveStatus]
			)
			VALUES
			(
				source.[CompanyConfigurationId],
				source.[ProductCategory],
				source.[ActiveStatus]
			);

			DROP TABLE #ProductCategoryTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END