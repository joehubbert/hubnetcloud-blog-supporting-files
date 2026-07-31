CREATE PROCEDURE [dbo].[spCreateCustomerLeadNoteType]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@customerLeadNoteType NVARCHAR(50),
	@customerLeadNoteTypeCode NVARCHAR(20),
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #CustomerLeadNoteTypeTemp
			(
				[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
				[CustomerLeadNoteType] NVARCHAR(50) NOT NULL,
				[CustomerLeadNoteTypeCode] NVARCHAR(20) NOT NULL,
				[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #CustomerLeadNoteTypeTemp
			(
				[MasterDataTypeId],
				[CustomerLeadNoteType],
				[CustomerLeadNoteTypeCode],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				@masterDataTypeId,
				@customerLeadNoteType,
				@customerLeadNoteTypeCode,
				@companyConfigurationId,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[CustomerLeadNoteType] CLNT
				LEFT JOIN #CustomerLeadNoteTypeTemp CLNTT ON CLNT.[CustomerLeadNoteType] = CLNTT.[CustomerLeadNoteType]
				AND CLNT.[CustomerLeadNoteTypeCode] = CLNTT.[CustomerLeadNoteTypeCode]
				AND (CLNT.[CompanyConfigurationId] = CLNTT.[CompanyConfigurationId] OR (CLNT.[CompanyConfigurationId] IS NULL AND CLNTT.[CompanyConfigurationId] IS NULL))
				WHERE CLNT.[CustomerLeadNoteType] = CLNTT.[CustomerLeadNoteType]
				AND CLNT.[CustomerLeadNoteTypeCode] = CLNTT.[CustomerLeadNoteTypeCode]
				AND (CLNT.[CompanyConfigurationId] = CLNTT.[CompanyConfigurationId] OR (CLNT.[CompanyConfigurationId] IS NULL AND CLNTT.[CompanyConfigurationId] IS NULL))
			)
			THROW 50000, 'Customer Lead Note Type already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[CustomerLeadNoteType] AS target
			USING #CustomerLeadNoteTypeTemp AS source
			ON target.[CustomerLeadNoteType] = source.[CustomerLeadNoteType]
			AND target.[CustomerLeadNoteTypeCode] = source.[CustomerLeadNoteTypeCode]
			AND (target.[CompanyConfigurationId] = source.[CompanyConfigurationId] OR (target.[CompanyConfigurationId] IS NULL AND source.[CompanyConfigurationId] IS NULL))
			WHEN NOT MATCHED THEN
			INSERT
			(
				[MasterDataTypeId],
				[CustomerLeadNoteType],
				[CustomerLeadNoteTypeCode],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				source.[MasterDataTypeId],
				source.[CustomerLeadNoteType],
				source.[CustomerLeadNoteTypeCode],
				source.[CompanyConfigurationId],
				source.[ActiveStatus]
			);

			DROP TABLE #CustomerLeadNoteTypeTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END