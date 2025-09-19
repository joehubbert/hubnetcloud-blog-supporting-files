CREATE PROCEDURE [dbo].[spCreateSalesRegion]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER,
	@salesRegion NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #SalesRegionTemp
			(
				[SalesRegion] NVARCHAR(50) NOT NULL,
				[CompanyConfigurationId] UNIQUEIDENTIFIER NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #SalesRegionTemp
			(
				[SalesRegion],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				@salesRegion,
				@companyConfigurationId,
				@activeStatus
			)

			IF EXISTS
			(
			SELECT *
			FROM [dbo].[SalesRegion] SR
			INNER JOIN #SalesRegionTemp SRT ON SR.[SalesRegion] = SRT.[SalesRegion]
			AND SR.[CompanyConfigurationId] = SRT.[CompanyConfigurationId]
			WHERE SR.[SalesRegion] = SRT.[SalesRegion]
			AND SR.[CompanyConfigurationId] = SRT.[CompanyConfigurationId]
			)
			THROW 50000, 'Sales Region already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[SalesRegion] AS target
			USING #SalesRegionTemp AS source
			ON target.[SalesRegion] = source.[SalesRegion]
			AND target.[CompanyConfigurationId] = source.[CompanyConfigurationId]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[SalesRegion],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				source.[SalesRegion],
				source.[CompanyConfigurationId],
				source.[ActiveStatus]
			);

			DROP TABLE #SalesRegionTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END