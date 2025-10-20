CREATE PROCEDURE [dbo].[spGetAllCustomer]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Global Parent Customer Id],
			[Top Parent Customer Id],
			[Customer Id],
			[Company Configuration Company Name],
			[Account Manager],
			[Customer Tier],
			[Customer Type],
			[Sales Region],
			[Sales Sub Region],
			[First Name],
			[Last Name],
			[Company Name],
			[Telephone Number],
			[Email Address],
			[Credit Enabled],
			[Credit Limit],
			[Payment Currency Code],
			[Payment Days],
			[VAT Registered],
			[VAT Number],
			[Global Parent Customer],
			[Top Parent Customer],
			[Active Status],
			[Customer Since],
			[Row Version]
			FROM [dbo].[vwCustomer]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END