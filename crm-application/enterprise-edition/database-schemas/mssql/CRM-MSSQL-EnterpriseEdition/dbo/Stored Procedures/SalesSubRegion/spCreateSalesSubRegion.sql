CREATE PROCEDURE [dbo].[spCreateSalesSubRegion]
	@activeStatus BIT,
	@salesRegionId UNIQUEIDENTIFIER,
	@salesSubRegion NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #SalesSubRegionTemp
			(
				[SalesRegionId] UNIQUEIDENTIFIER NOT NULL,
				[SalesSubRegion] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #SalesSubRegionTemp
			(
				[SalesRegionId],
				[SalesSubRegion],
				[ActiveStatus]
			)
			VALUES
			(
				@salesRegionId,
				@salesSubRegion,
				@activeStatus
			)

			IF EXISTS
			(
			SELECT *
			FROM [dbo].[SalesSubRegion] SRM
			INNER JOIN #SalesSubRegionTemp SRMT ON SRM.[SalesRegionId] = SRMT.[SalesRegionId]
			AND SRM.[SalesSubRegion] = SRMT.[SalesSubRegion]
			WHERE SRM.[SalesRegionId] = SRMT.[SalesRegionId]
			AND SRM.[SalesSubRegion] = SRMT.[SalesSubRegion]
			)
			THROW 50000, 'Sales Sub Region already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[SalesSubRegion] AS target
			USING #SalesSubRegionTemp AS source
			ON target.[SalesRegionId] = source.[SalesRegionId]
			AND target.[SalesSubRegion] = source.[SalesSubRegion]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[SalesRegionId],
				[SalesSubRegion],
				[ActiveStatus]
			)
			VALUES
			(
				source.[SalesRegionId],
				source.[SalesSubRegion],
				source.[ActiveStatus]
			);

			DROP TABLE #SalesSubRegionTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END