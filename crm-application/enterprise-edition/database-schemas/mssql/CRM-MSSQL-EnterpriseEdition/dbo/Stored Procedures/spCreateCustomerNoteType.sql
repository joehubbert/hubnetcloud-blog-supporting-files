CREATE PROCEDURE [dbo].[spCreateCustomerNoteType]
	@activeStatus BIT,
	@customerNoteType NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #CustomerNoteTypeTemp
			(
				[CustomerNoteType] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #CustomerNoteTypeTemp
			(
				[CustomerNoteType],
				[ActiveStatus]
			)
			VALUES
			(
				@customerNoteType,
				@activeStatus
			)

			IF EXISTS
			(
			SELECT *
			FROM [dbo].[CustomerNoteType] CNT
			INNER JOIN #CustomerNoteTypeTemp CNTT ON CNT.[CustomerNoteType] = CNTT.[CustomerNoteType]
			WHERE CNT.[CustomerNoteType] = CNTT.[CustomerNoteType]
			)
			THROW 50000, 'Customer Note Type already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[CustomerNoteType] AS target
			USING #CustomerNoteTypeTemp AS source
			ON target.[CustomerNoteType] = source.[CustomerNoteType]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[CustomerNoteType],
				[ActiveStatus]
			)
			VALUES
			(
				source.[CustomerNoteType],
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