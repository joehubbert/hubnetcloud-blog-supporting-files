CREATE PROCEDURE [dbo].[spCreateOrder]
	@currencyId UNIQUEIDENTIFIER,
	@customerId UNIQUEIDENTIFIER,
	@orderId UNIQUEIDENTIFIER OUTPUT,
	@orderStatusId UNIQUEIDENTIFIER,
	@paymentMethodId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare a table variable to capture the output of the INSERT statement
	DECLARE @OutputTable TABLE (OrderId UNIQUEIDENTIFIER);

	INSERT INTO [dbo].[Order]
	(
		[CurrencyId],
		[CustomerId],
		[OrderStatusId],
		[PaymentMethodId]
	)
	OUTPUT INSERTED.[OrderId] INTO @OutputTable
	VALUES
	(
		@currencyId,
		@customerId,
		@orderStatusId,
		@paymentMethodId
	);

	-- Set the output parameter from the table variable
	SET @orderId = (SELECT OrderId FROM @OutputTable);
END