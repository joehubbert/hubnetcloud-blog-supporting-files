CREATE PROCEDURE [dbo].[spUpdateMasterDataType]
	@activeStatus BIT,
	@masterDataType NVARCHAR(50),
	@masterDataTypeId UNIQUEIDENTIFIER,
	@systemDefined BIT,
	@userDefined BIT
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[MasterDataType]
			SET 
				[ActiveStatus] = @activeStatus,
				[MasterDataType] = @masterDataType,
				[SystemDefined] = @systemDefined,
				[UserDefined] = @userDefined
			WHERE [MasterDataTypeId] = @masterDataTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END