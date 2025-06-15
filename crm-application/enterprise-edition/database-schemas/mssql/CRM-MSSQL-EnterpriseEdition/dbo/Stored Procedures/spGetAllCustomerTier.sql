CREATE PROCEDURE [dbo].[spGetAllCustomerTier]
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
			[Created Timestamp],
			[Created By],
			[Modified Timestamp],
			[Modified By]
			FROM [dbo].[vwCustomerTier]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END