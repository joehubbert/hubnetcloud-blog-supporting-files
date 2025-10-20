CREATE PROCEDURE [dbo].[spGetAllOrderLineItemForOrder]
	@orderId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Order Id],
			[Order Line Item Id],
			[Product Name],
			[Product Unit Price],
			[Order Line Item Unit Price],
			[Order Line Item Tax Amount],
			[Tax Profile Id],
			[Tax Profile],
			[Tax Rate],
			[Order Line Item Quantity],
			[Order Line Item Percentage Discount],
			[Promotion Id],
			[Promotion Code],
			[Promotion Type Id],
			[Promotion Type],
			[Total Line Item Price],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwOrderLineItem]
			WHERE [Order Id] = @orderId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END