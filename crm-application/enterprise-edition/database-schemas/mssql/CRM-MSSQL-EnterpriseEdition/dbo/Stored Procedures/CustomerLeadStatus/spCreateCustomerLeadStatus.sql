CREATE PROCEDURE [dbo].[spCreateCustomerLeadStatus]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@customerLeadStatus NVARCHAR(50),
	@customerLeadStatusCode NVARCHAR(20),
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #CustomerLeadStatusTemp
			(	
				[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
				[CustomerLeadStatus] NVARCHAR(50) NOT NULL,
				[CustomerLeadStatusCode] NVARCHAR(20) NOT NULL,
				[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #CustomerLeadStatusTemp
			(
				[MasterDataTypeId],
				[CustomerLeadStatus],
				[CustomerLeadStatusCode],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				@masterDataTypeId,
				@customerLeadStatus,
				@customerLeadStatusCode,
				@companyConfigurationId,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[CustomerLeadStatus] CLS
				LEFT JOIN #CustomerLeadStatusTemp CLST ON CLS.[CustomerLeadStatus] = CLST.[CustomerLeadStatus]
				AND CLS.[CustomerLeadStatusCode] = CLST.[CustomerLeadStatusCode]
				AND (CLST.[CompanyConfigurationId] = CLSTT.[CompanyConfigurationId] OR (CLST.[CompanyConfigurationId] IS NULL AND CLSTT.[CompanyConfigurationId] IS NULL))
				WHERE CLS.[CustomerLeadStatus] = CLST.[CustomerLeadStatus]
				AND CLS.[CustomerLeadStatusCode] = CLST.[CustomerLeadStatusCode]
				AND (CLST.[CompanyConfigurationId] = CLSTT.[CompanyConfigurationId] OR (CLST.[CompanyConfigurationId] IS NULL AND CLSTT.[CompanyConfigurationId] IS NULL))
			)
			THROW 50000, 'Customer Lead Status already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[CustomerLeadStatus] AS target
			USING #CustomerLeadStatusTemp AS source
			ON target.[CustomerLeadStatus] = source.[CustomerLeadStatus]
			AND target.[CustomerLeadStatusCode] = source.[CustomerLeadStatusCode]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[MasterDataTypeId],
				[CustomerLeadStatus],
				[CustomerLeadStatusCode],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				source.[MasterDataTypeId],
				source.[CustomerLeadStatus],
				source.[CustomerLeadStatusCode],
				source.[CompanyConfigurationId],
				source.[ActiveStatus]
			);

			DROP TABLE #CustomerLeadStatusTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END