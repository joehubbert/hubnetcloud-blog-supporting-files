CREATE PROCEDURE [dbo].[spGetAllGlobalParentCustomer]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Global Parent Customer Id],
			[Top Parent Customer Id],
			[Company Configuration Id],
			[Customer Id],
			[Account Manager],
			[Customer Tier],
			[Customer Type],
			[Sales Region],
			[First Name],
			[Last Name],
			[Company Name],
			[Credit Enabled],
			[Credit Limit],
			[Payment Days],
			[Global Parent Customer],
			[Top Parent Customer],
			[Active Status],
			[Customer Since],
			[Row Version]
			FROM [dbo].[vwCustomer]
			WHERE [Global Parent Customer] = 1

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END