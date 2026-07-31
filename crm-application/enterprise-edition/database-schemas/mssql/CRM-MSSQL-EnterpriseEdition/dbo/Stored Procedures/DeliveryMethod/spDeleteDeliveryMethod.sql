CREATE PROCEDURE [dbo].[spDeleteDeliveryMethod]
	@deliveryMethodId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

        DELETE DM
        FROM [dbo].[DeliveryMethod] DM
        INNER JOIN [dbo].[MasterDataType] MDT ON DM.[MasterDataTypeId] = MDT.[MasterDataTypeId]
        WHERE DM.[DeliveryMethodId] = @deliveryMethodId
        AND MDT.[IsCustom] = 1

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END
