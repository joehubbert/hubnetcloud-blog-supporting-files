CREATE PROCEDURE [dbo].[spCreateCustomerLeadType]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@customerLeadType NVARCHAR(50),
	@customerLeadTypeCode NVARCHAR(20),
	@customerLeadTypeDescription NVARCHAR(255) = NULL,
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #CustomerLeadTypeTemp
			(
				[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
				[CustomerLeadType] NVARCHAR(50) NOT NULL,
				[CustomerLeadTypeCode] NVARCHAR(20) NOT NULL,
				[CustomerLeadTypeDescription] NVARCHAR(255) NULL,
				[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #CustomerLeadTypeTemp
			(
				[MasterDataTypeId],
				[CustomerLeadType],
				[CustomerLeadTypeCode],
				[CustomerLeadTypeDescription],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				@masterDataTypeId,
				@customerLeadType,
				@customerLeadTypeCode,
				@customerLeadTypeDescription,
				@companyConfigurationId,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[CustomerLeadType] CLT
				INNER JOIN #CustomerLeadTypeTemp CLTT ON CLT.[CustomerLeadType] = CLTT.[CustomerLeadType]
				AND (CLT.[CompanyConfigurationId] = CLTT.[CompanyConfigurationId] OR (CLT.[CompanyConfigurationId] IS NULL AND CLTT.[CompanyConfigurationId] IS NULL))
			)
			THROW 50000, 'Customer Lead Type already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[CustomerLeadType] AS target
			USING #CustomerLeadTypeTemp AS source
			ON target.[CustomerLeadType] = source.[CustomerLeadType]
			AND (target.[CompanyConfigurationId] = source.[CompanyConfigurationId] OR (target.[CompanyConfigurationId] IS NULL AND source.[CompanyConfigurationId] IS NULL))
			WHEN NOT MATCHED THEN
			INSERT
			(
				[MasterDataTypeId],
				[CustomerLeadType],
				[CustomerLeadTypeCode],
				[CustomerLeadTypeDescription],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				source.[MasterDataTypeId],
				source.[CustomerLeadType],
				source.[CustomerLeadTypeCode],
				source.[CustomerLeadTypeDescription],
				source.[CompanyConfigurationId],
				source.[ActiveStatus]
			);

			DROP TABLE #CustomerLeadTypeTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END