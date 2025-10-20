CREATE PROCEDURE [dbo].[spCreateHTMLTemplateType]
	@activeStatus BIT,
	@htmlTemplateType NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #HTMLTemplateTypeTemp
			(
				[HTMLTemplateType] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #HTMLTemplateTypeTemp
			(
				[HTMLTemplateType],
				[ActiveStatus]
			)
			VALUES
			(
				@htmlTemplateType,
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
				[HTMLTemplateType],
				[ActiveStatus]
			)
			VALUES
			(
				source.[HTMLTemplateType],
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