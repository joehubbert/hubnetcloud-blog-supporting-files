CREATE PROCEDURE [dbo].[spCreateTaxProfile]
	@activeStatus BIT,
	@taxProfile NVARCHAR(50),
	@taxRate DECIMAL(5, 2)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #TazProfileTemp
			(
				[TaxProfile] NVARCHAR(50) NOT NULL,
				[TaxRate] DECIMAL(5, 2) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #TazProfileTemp
			(
				[TaxProfile],
				[TaxRate],
				[ActiveStatus]
			)
			VALUES
			(
				@taxProfile,
				@taxRate,
				@activeStatus
			)

			IF EXISTS
			( 
				SELECT *
				FROM [dbo].[TaxProfile] TP
				INNER JOIN #TazProfileTemp TPP ON TP.[TaxProfile] = TPP.[TaxProfile]
				AND TP.[TaxRate] = TPP.[TaxRate]
				WHERE TP.[TaxProfile] = TPP.[TaxProfile]
				AND TP.[TaxRate] = TPP.[TaxRate]
			)
			THROW 50000, 'Tax Profile already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[TaxProfile] AS target
			USING #TazProfileTemp AS source
			ON target.[TaxProfile] = source.[TaxProfile]
			AND target.[TaxRate] = source.[TaxRate]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[TaxProfile],
				[TaxRate],
				[ActiveStatus]
			)
			VALUES
			(
				source.[TaxProfile],
				source.[TaxRate],
				source.[ActiveStatus]
			);

			DROP TABLE #TazProfileTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END