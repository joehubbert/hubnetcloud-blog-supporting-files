CREATE PROCEDURE [dbo].[spCreateSupplierNoteType]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@supplierNoteType NVARCHAR(50),
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #SupplierNoteTypeTemp
			(
				[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
				[SupplierNoteType] NVARCHAR(50) NOT NULL,
				[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #SupplierNoteTypeTemp
			(
				[MasterDataTypeId],
				[SupplierNoteType],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				@masterDataTypeId,
				@supplierNoteType,
				@companyConfigurationId,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[SupplierNoteType] CT
				INNER JOIN #SupplierNoteTypeTemp CTT ON CT.[SupplierNoteType] = CTT.[SupplierNoteType]
				AND (CT.[CompanyConfigurationId] = CTT.[CompanyConfigurationId] OR (CT.[CompanyConfigurationId] IS NULL AND CTT.[CompanyConfigurationId] IS NULL))
				WHERE CT.[SupplierNoteType] = CTT.[SupplierNoteType]
			)
			THROW 50000, 'Supplier Note Type already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[SupplierNoteType] AS target
			USING #SupplierNoteTypeTemp AS source
			ON target.[SupplierNoteType] = source.[SupplierNoteType]
			AND (target.[CompanyConfigurationId] = source.[CompanyConfigurationId] OR (target.[CompanyConfigurationId] IS NULL AND source.[CompanyConfigurationId] IS NULL))
			WHEN NOT MATCHED THEN
			INSERT
			(
				[MasterDataTypeId],
				[SupplierNoteType],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				source.[MasterDataTypeId],
				source.[SupplierNoteType],
				source.[CompanyConfigurationId],
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