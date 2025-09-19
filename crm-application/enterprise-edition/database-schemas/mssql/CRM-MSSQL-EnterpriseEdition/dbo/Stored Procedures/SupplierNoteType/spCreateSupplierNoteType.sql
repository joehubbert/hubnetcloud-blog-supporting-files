CREATE PROCEDURE [dbo].[spCreateSupplierNoteType]
	@activeStatus BIT,
	@supplierNoteType NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #SupplierNoteTypeTemp
			(
				[SupplierNoteType] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #SupplierNoteTypeTemp
			(
				[SupplierNoteType],
				[ActiveStatus]
			)
			VALUES
			(
				@supplierNoteType,
				@activeStatus
			)

			IF EXISTS
			(
			SELECT *
			FROM [dbo].[SupplierNoteType] CT
			INNER JOIN #SupplierNoteTypeTemp CTT ON CT.[SupplierNoteType] = CTT.[SupplierNoteType]
			WHERE CT.[SupplierNoteType] = CTT.[SupplierNoteType]
			)
			THROW 50000, 'Supplier Note Type already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[SupplierNoteType] AS target
			USING #SupplierNoteTypeTemp AS source
			ON target.[SupplierNoteType] = source.[SupplierNoteType]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[SupplierNoteType],
				[ActiveStatus]
			)
			VALUES
			(
				source.[SupplierNoteType],
				source.[ActiveStatus]
			);

			DROP TABLE #SupplierNoteTypeTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END