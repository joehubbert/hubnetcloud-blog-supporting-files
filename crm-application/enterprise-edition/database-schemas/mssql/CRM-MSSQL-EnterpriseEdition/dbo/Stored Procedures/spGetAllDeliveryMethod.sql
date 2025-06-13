CREATE PROCEDURE [dbo].[spGetAllDeliveryMethod]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Delivery Method Id],
			[Delivery Method],
			[Delivery Cost],
			[Delivery Time Days],
			[Tax Profile],
			[Tax Rate],
			[Delivery Method Active Status]
			FROM [dbo].[vwDeliveryMethod]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END