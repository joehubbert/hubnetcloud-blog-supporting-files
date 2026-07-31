CREATE PROCEDURE [dbo].[spCreateCustomerNoteType]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@customerNoteType NVARCHAR(50),
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #CustomerNoteTypeTemp
			(
				[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
				[CustomerNoteType] NVARCHAR(50) NOT NULL,
				[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #CustomerNoteTypeTemp
			(
				[MasterDataTypeId],
				[CustomerNoteType],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				@masterDataTypeId,
				@customerNoteType,
				@companyConfigurationId,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[CustomerNoteType] CNT
				INNER JOIN #CustomerNoteTypeTemp CNTT ON CNT.[CustomerNoteType] = CNTT.[CustomerNoteType]
				AND (CNT.[CompanyConfigurationId] = CNTT.[CompanyConfigurationId] OR (CNT.[CompanyConfigurationId] IS NULL AND CNTT.[CompanyConfigurationId] IS NULL))
				WHERE CNT.[CustomerNoteType] = CNTT.[CustomerNoteType]
			)
			THROW 50000, 'Customer Note Type already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[CustomerNoteType] AS target
			USING #CustomerNoteTypeTemp AS source
			ON target.[CustomerNoteType] = source.[CustomerNoteType]
			AND (target.[CompanyConfigurationId] = source.[CompanyConfigurationId] OR (target.[CompanyConfigurationId] IS NULL AND source.[CompanyConfigurationId] IS NULL))
			WHEN NOT MATCHED THEN
			INSERT
			(
				[MasterDataTypeId],
				[CustomerNoteType],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				source.[MasterDataTypeId],
				source.[CustomerNoteType],
				source.[CompanyConfigurationId],
				source.[ActiveStatus]
			);

			DROP TABLE #CustomerNoteTypeTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END