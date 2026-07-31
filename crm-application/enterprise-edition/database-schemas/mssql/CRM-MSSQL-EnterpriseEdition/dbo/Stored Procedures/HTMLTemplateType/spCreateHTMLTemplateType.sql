CREATE PROCEDURE [dbo].[spCreateHTMLTemplateType]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@htmlTemplateType NVARCHAR(50),
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #HTMLTemplateTypeTemp
			(
				[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
				[HTMLTemplateType] NVARCHAR(50) NOT NULL,
				[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #HTMLTemplateTypeTemp
			(
				[MasterDataTypeId],
				[HTMLTemplateType],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				@masterDataTypeId,
				@htmlTemplateType,
				@companyConfigurationId,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[HTMLTemplateType] HTMLT
				INNER JOIN #HTMLTemplateTypeTemp HTMLTT ON HTMLT.[HTMLTemplateType] = HTMLTT.[HTMLTemplateType]
				WHERE HTMLT.[HTMLTemplateType] = HTMLTT.[HTMLTemplateType]
			)
			THROW 50000, 'HTML Template Type already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[HTMLTemplateType] AS target
			USING #HTMLTemplateTypeTemp AS source
			ON target.[HTMLTemplateType] = source.[HTMLTemplateType]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[MasterDataTypeId],
				[HTMLTemplateType],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				source.[MasterDataTypeId],
				source.[HTMLTemplateType],
				source.[CompanyConfigurationId],
				source.[ActiveStatus]
			);

			DROP TABLE #HTMLTemplateTypeTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END