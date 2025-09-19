CREATE PROCEDURE [dbo].[spGetAssociatedCustomerToAccountManager]
	@accountManagerId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Customer Id],
			[First Name],
			[Last Name],
			[Company Name],
			[Customer Tier],
			[Customer Type],
			[Customer Since],
			[Total Orders],
			[Average Order Value],
			[Credit Limit Used Percentage]
			FROM [dbo].[vwAssociatedCustomerToAccountManager]
			WHERE [Account Manager Id] = @accountManagerId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END