CREATE PROCEDURE [dbo].[spDeleteOrderStatus]
	@orderStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

        DELETE E
        FROM [dbo].[OrderStatus] E
        INNER JOIN [dbo].[MasterDataType] MDT ON E.[MasterDataTypeId] = MDT.[MasterDataTypeId]
        WHERE E.[OrderStatusId] = @orderStatusId
        AND MDT.[IsCustom] = 1

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END
