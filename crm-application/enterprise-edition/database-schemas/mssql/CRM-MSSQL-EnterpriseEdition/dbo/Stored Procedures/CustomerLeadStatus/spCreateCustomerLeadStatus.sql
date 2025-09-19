CREATE PROCEDURE [dbo].[spCreateCustomerLeadStatus]
	@activeStatus BIT,
	@customerLeadStatus NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #CustomerLeadStatusTemp
			(
				[CustomerLeadStatus] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #CustomerLeadStatusTemp
			(
				[CustomerLeadStatus],
				[ActiveStatus]
			)
			VALUES
			(
				@customerLeadStatus,
				@activeStatus
			)

			IF EXISTS
			(
			SELECT *
			FROM [dbo].[CustomerLeadStatus] CLS
			INNER JOIN #CustomerLeadStatusTemp CLST ON CLS.[CustomerLeadStatus] = CLST.[CustomerLeadStatus]
			WHERE CLS.[CustomerLeadStatus] = CLST.[CustomerLeadStatus]
			)
			THROW 50000, 'Customer Lead Status already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[CustomerLeadStatus] AS target
			USING #CustomerLeadStatusTemp AS source
			ON target.[CustomerLeadStatus] = source.[CustomerLeadStatus]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[CustomerLeadStatus],
				[ActiveStatus]
			)
			VALUES
			(
				source.[CustomerLeadStatus],
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