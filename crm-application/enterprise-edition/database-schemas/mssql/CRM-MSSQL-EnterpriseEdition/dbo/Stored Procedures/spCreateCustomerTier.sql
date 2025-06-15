CREATE PROCEDURE [dbo].[spCreateCustomerTier]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER,
	@customerTierCode NCHAR(1),
	@customerTierDescription NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #CustomerTierTemp
			(
				[CompanyConfigurationId] UNIQUEIDENTIFIER NOT NULL,
				[CustomerTierCode] NCHAR(1) NOT NULL,
				[CustomerTierDescription] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #CustomerTierTemp
			(
				[CompanyConfigurationId],
				[CustomerTierCode],
				[CustomerTierDescription],
				[ActiveStatus]
			)
			VALUES
			(
				@companyConfigurationId,
				@customerTierCode,
				@customerTierDescription,
				@activeStatus
			)

			IF EXISTS
			(
			SELECT *
			FROM [dbo].[CustomerTier] CT
			INNER JOIN #CustomerTierTemp CTT ON CT.[CompanyConfigurationId] = CTT.[CompanyConfigurationId]
			AND CT.[CustomerTierCode] = CTT.[CustomerTierCode]
			AND CT.[CustomerTierDescription] = CTT.[CustomerTierDescription]
			WHERE CT.[CompanyConfigurationId] = CTT.[CompanyConfigurationId]
			AND CT.[CustomerTierCode] = CTT.[CustomerTierCode]
			AND CT.[CustomerTierDescription] = CTT.[CustomerTierDescription]
			)
			THROW 50000, 'Customer Tier already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[CustomerTier] AS target
			USING #CustomerTierTemp AS source
			ON target.[CompanyConfigurationId] = source.[CompanyConfigurationId]
			AND target.[CustomerTierCode] = source.[CustomerTierCode]
			AND target.[CustomerTierDescription] = source.[CustomerTierDescription]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[CompanyConfigurationId],
				[CustomerTierCode],
				[CustomerTierDescription],
				[ActiveStatus]
			)
			VALUES
			(
				sourc.[CompanyConfigurationId],
				source.[CustomerTierCode],
				source.[CustomerTierDescription],
				source.[ActiveStatus]
			);

			DROP TABLE #CustomerTierTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END