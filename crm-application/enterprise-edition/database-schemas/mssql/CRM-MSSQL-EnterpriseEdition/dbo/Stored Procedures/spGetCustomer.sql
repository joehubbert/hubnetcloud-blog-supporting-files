CREATE PROCEDURE [dbo].[spGetCustomer]
	@customerId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Global Parent Customer Id],
			[Top Parent Customer Id],
			[Customer Id],
			[Company Configuration Id],
			[Company Configuration Company Name],
			[Account Manager],
			[Account Manager Id],
			[Customer Tier],
			[Customer Tier Id],
			[Customer Type],
			[Customer Type Id],
			[Sales Region],
			[Sales Region Id],
			[Sales Sub Region],
			[Sales Sub Region Id],
			[First Name],
			[Last Name],
			[Company Name],
			[Telephone Number],
			[Email Address],
			[Billing First Name],
			[Billing Last Name],
			[Billing Company Name],
			[Billing Address Line 1],
			[Billing Address Line 2],
			[Billing Address Line 3],
			[Billing Address Line 4],
			[Billing Address Line 5],
			[Billing Telephone Number],
			[Billing Email Address],
			[Shipping First Name],
			[Shipping Last Name],
			[Shipping Company Name],
			[Shipping Address Line 1],
			[Shipping Address Line 2],
			[Shipping Address Line 3],
			[Shipping Address Line 4],
			[Shipping Address Line 5],
			[Shipping Telephone Number],
			[Shipping Email Address],
			[Credit Enabled],
			[Credit Limit],
			[Credit Limit Used],
			[Credit Limit Used Percentage],
			[Remaining Credit Limit],
			[Payment Currency Id],
			[Payment Currency Code],
			[Payment Days],
			[VAT Registered],
			[VAT Number],
			[Global Parent Customer],
			[Top Parent Customer],
			[Active Status],
			[Customer Since],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By]
			FROM [dbo].[vwCustomer]
			WHERE [Customer Id] = @customerId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END