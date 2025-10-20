CREATE PROCEDURE [dbo].[spGetCustomerTier]
	@customerTierId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Customer Tier Id],
			[Customer Tier Code],
			[Customer Tier Description],
			[Company Configuration Id],
			[Company Name],
			[Active Status],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwCustomerTier]
			WHERE [Customer Tier Id] = @customerTierId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END