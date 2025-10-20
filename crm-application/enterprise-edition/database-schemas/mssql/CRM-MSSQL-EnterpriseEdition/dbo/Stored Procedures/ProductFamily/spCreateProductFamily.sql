CREATE PROCEDURE [dbo].[spCreateProductFamily]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER,
	@productFamily NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #ProductFamilyTemp
			(
				[CompanyConfigurationId] UNIQUEIDENTIFIER NOT NULL,
				[ProductFamily] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #ProductFamilyTemp
			(
				[CompanyConfigurationId],
				[ProductFamily],
				[ActiveStatus]
			)
			VALUES
			(
				@companyConfigurationId,
				@productFamily,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[ProductFamily] PC
				INNER JOIN #ProductFamilyTemp PCT ON PC.[CompanyConfigurationId] = PCT.[CompanyConfigurationId]
				AND PC.[ProductFamily] = PCT.[ProductFamily]
				WHERE PC.[CompanyConfigurationId] = PCT.[CompanyConfigurationId]
				AND PC.[ProductFamily] = PCT.[ProductFamily]
			)
			THROW 50000, 'Product Family already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[ProductFamily] AS target
			USING #ProductFamilyTemp AS source
			ON target.[CompanyConfigurationId] = source.[CompanyConfigurationId]
			AND target.[ProductFamily] = source.[ProductFamily]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[CompanyConfigurationId],
				[ProductFamily],
				[ActiveStatus]
			)
			VALUES
			(
				source.[CompanyConfigurationId],
				source.[ProductFamily],
				source.[ActiveStatus]
			);

			DROP TABLE #ProductFamilyTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END