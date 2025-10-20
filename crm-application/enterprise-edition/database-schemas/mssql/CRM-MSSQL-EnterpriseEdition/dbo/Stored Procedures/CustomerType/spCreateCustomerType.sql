CREATE PROCEDURE [dbo].[spCreateCustomerType]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER,
	@customerType NVARCHAR(50),
	@customerTypeDescription NVARCHAR(255) = NULL
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #CustomerTypeTemp
			(
				[CompanyConfigurationId] UNIQUEIDENTIFIER NOT NULL,
				[CustomerType] NVARCHAR(50) NOT NULL,
				[CustomerTypeDescription] NVARCHAR(255) NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #CustomerTypeTemp
			(
				[CompanyConfigurationId],
				[CustomerType],
				[CustomerTypeDescription],
				[ActiveStatus]
			)
			VALUES
			(
				@companyConfigurationId,
				@customerType,
				@customerTypeDescription,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[CustomerType] CT
				INNER JOIN #CustomerTypeTemp CTT ON CT.[CompanyConfigurationId] = CTT.[CompanyConfigurationId]
				AND CT.[CustomerType] = CTT.[CustomerType]
				WHERE CT.[CompanyConfigurationId] = CTT.[CompanyConfigurationId]
				AND CT.[CustomerType] = CTT.[CustomerType]
			)
			THROW 50000, 'Customer Type already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[CustomerType] AS target
			USING #CustomerTypeTemp AS source
			ON target.[CompanyConfigurationId] = source.[CompanyConfigurationId]
			AND target.[CustomerType] = source.[CustomerType]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[CompanyConfigurationId],
				[CustomerType],
				[CustomerTypeDescription],
				[ActiveStatus]
			)
			VALUES
			(
				source.[CompanyConfigurationId],
				source.[CustomerType],
				source.[CustomerTypeDescription],
				source.[ActiveStatus]
			);

			DROP TABLE #CustomerTypeTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END