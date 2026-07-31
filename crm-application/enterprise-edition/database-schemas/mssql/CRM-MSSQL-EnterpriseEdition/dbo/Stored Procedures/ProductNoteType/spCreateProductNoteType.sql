CREATE PROCEDURE [dbo].[spCreateProductNoteType]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@productNoteType NVARCHAR(50),
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #ProductNoteTypeTemp
			(
				[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
				[ProductNoteType] NVARCHAR(50) NOT NULL,
				[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #ProductNoteTypeTemp
			(
				[MasterDataTypeId],
				[ProductNoteType],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				@masterDataTypeId,
				@productNoteType,
				@companyConfigurationId,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[ProductNoteType] CT
				INNER JOIN #ProductNoteTypeTemp CTT ON CT.[ProductNoteType] = CTT.[ProductNoteType]
				WHERE CT.[ProductNoteType] = CTT.[ProductNoteType]
			)
			THROW 50000, 'Product Note Type already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[ProductNoteType] AS target
			USING #ProductNoteTypeTemp AS source
			ON target.[ProductNoteType] = source.[ProductNoteType]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[MasterDataTypeId],
				[ProductNoteType],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				source.[MasterDataTypeId],
				source.[ProductNoteType],
				source.[CompanyConfigurationId],
				source.[ActiveStatus]
			);

			DROP TABLE #ProductNoteTypeTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END