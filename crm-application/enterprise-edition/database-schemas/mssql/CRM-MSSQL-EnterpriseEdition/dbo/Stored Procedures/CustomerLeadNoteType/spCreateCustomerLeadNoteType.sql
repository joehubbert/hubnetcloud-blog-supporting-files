CREATE PROCEDURE [dbo].[spCreateCustomerLeadNoteType]
	@activeStatus BIT,
	@customerLeadNoteType NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #CustomerLeadNoteTypeTemp
			(
				[CustomerLeadNoteType] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #CustomerLeadNoteTypeTemp
			(
				[CustomerLeadNoteType],
				[ActiveStatus]
			)
			VALUES
			(
				@customerLeadNoteType,
				@activeStatus
			)

			IF EXISTS
			(
			SELECT *
			FROM [dbo].[CustomerLeadNoteType] CLNT
			INNER JOIN #CustomerLeadNoteTypeTemp CLNTT ON CLNT.[CustomerLeadNoteType] = CLNTT.[CustomerLeadNoteType]
			WHERE CNT.[CustomerLeadNoteType] = CLNTT.[CustomerLeadNoteType]
			)
			THROW 50000, 'Customer Lead Note Type already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[CustomerLeadNoteType] AS target
			USING #CustomerLeadNoteTypeTemp AS source
			ON target.[CustomerLeadNoteType] = source.[CustomerLeadNoteType]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[CustomerLeadNoteType],
				[ActiveStatus]
			)
			VALUES
			(
				source.[CustomerLeadNoteType],
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