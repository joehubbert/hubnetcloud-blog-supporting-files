CREATE PROCEDURE [dbo].[spDeletePaymentMethod]
	@paymentMethodId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

        DELETE E
        FROM [dbo].[PaymentMethod] E
        INNER JOIN [dbo].[MasterDataType] MDT ON E.[MasterDataTypeId] = MDT.[MasterDataTypeId]
        WHERE E.[PaymentMethodId] = @paymentMethodId
        AND MDT.[IsCustom] = 1

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END
