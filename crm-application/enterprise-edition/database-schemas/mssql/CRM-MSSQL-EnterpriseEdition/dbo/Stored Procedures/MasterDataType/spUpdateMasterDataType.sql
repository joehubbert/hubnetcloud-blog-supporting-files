CREATE PROCEDURE [dbo].[spUpdateMasterDataType]
	@activeStatus BIT,
	@isCustom BIT,
	@masterDataType NVARCHAR(50),
	@masterDataTypeCode NVARCHAR(20),
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[MasterDataType]
			SET 
				[ActiveStatus] = @activeStatus,
				[MasterDataType] = @masterDataType,
				[MasterDataTypeCode] = @masterDataTypeCode,
				[IsCustom] = @isCustom
			WHERE [MasterDataTypeId] = @masterDataTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END