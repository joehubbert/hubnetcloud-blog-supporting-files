CREATE PROCEDURE [dbo].[spGetDeliveryMethod]
	@deliveryMethodId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Delivery Method Id],
            [Master Data Type Id],
            [Master Data Type],
            [Master Data Type Code],
            [Is Custom],
            [Company Configuration Id],
            [Company Name],
            [Delivery Method],
            [Delivery Cost],
            [Delivery Time Days],
            [Tax Profile],
            [Tax Rate],
            [Delivery Method Active Status],
            [Created Timestamp UTC],
            [Created By],
            [Modified Timestamp UTC],
            [Modified By],
            [Row Version]
			FROM [dbo].[vwDeliveryMethod]
			WHERE [Delivery Method Id] = @deliveryMethodId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END
