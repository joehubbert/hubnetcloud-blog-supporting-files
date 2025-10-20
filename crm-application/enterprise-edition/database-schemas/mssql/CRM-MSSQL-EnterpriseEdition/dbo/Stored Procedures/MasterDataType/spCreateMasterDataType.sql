CREATE PROCEDURE [dbo].[spCreateMasterDataType]
	@activeStatus BIT,
	@masterDataType NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #MasterDataTypeTemp
			(
				[MasterDataType] NVARCHAR(50) NOT NULL,				
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #MasterDataTypeTemp
			(
				[MasterDataType],
				[ActiveStatus]
			)
			VALUES
			(
				@masterDataType,
				@activeStatus
			)

			IF EXISTS
			(
			SELECT *
			FROM [dbo].[MasterDataType] CT
			INNER JOIN #MasterDataTypeTemp CTT ON CT.[MasterDataType] = CTT.[MasterDataType]
			WHERE CT.[MasterDataType] = CTT.[MasterDataType]
			)
			THROW 50000, 'Master Data Type already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[MasterDataType] AS target
			USING #MasterDataTypeTemp AS source
			ON target.[MasterDataType] = source.[MasterDataType]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[MasterDataType],
				[SystemDefined],
				[UserDefined],
				[ActiveStatus]
			)
			VALUES
			(
				source.[MasterDataType],
				0,
				1,
				source.[ActiveStatus]
			);

			DROP TABLE #MasterDataTypeTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END