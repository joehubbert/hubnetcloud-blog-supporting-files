CREATE PROCEDURE [dbo].[spCreateCustomerLeadType]
	@activeStatus BIT,
	@customerLeadType NVARCHAR(50),
	@customerLeadTypeDescription NVARCHAR(255) = NULL
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #CustomerLeadTypeTemp
			(
				[CustomerLeadType] NVARCHAR(50) NOT NULL,
				[CustomerLeadTypeDescription] NVARCHAR(255) NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #CustomerLeadTypeTemp
			(
				[CustomerLeadType],
				[CustomerLeadTypeDescription],
				[ActiveStatus]
			)
			VALUES
			(
				@customerLeadType,
				@customerLeadTypeDescription,
				@activeStatus
			)

			IF EXISTS
			(
			SELECT *
			FROM [dbo].[CustomerLeadType] CLT
			INNER JOIN #CustomerLeadTypeTemp CLTT ON CLT.[CustomerLeadType] = CLTT.[CustomerLeadType]
			WHERE CLT.[CustomerLeadType] = CLTT.[CustomerLeadType]
			)
			THROW 50000, 'Customer Lead Type already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[CustomerLeadType] AS target
			USING #CustomerLeadTypeTemp AS source
			ON target.[CustomerLeadType] = source.[CustomerLeadType]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[CustomerLeadType],
				[CustomerLeadTypeDescription],
				[ActiveStatus]
			)
			VALUES
			(
				source.[CustomerLeadType],
				source.[CustomerLeadTypeDescription],
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