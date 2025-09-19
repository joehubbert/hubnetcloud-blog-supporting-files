CREATE PROCEDURE [dbo].[spGetAllWholesaleDeliveryType]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Wholesale Delivery Type Id],
			[Wholesale Delivery Type],
			[Active Status]
			FROM [dbo].[vwWholesaleDeliveryType]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END