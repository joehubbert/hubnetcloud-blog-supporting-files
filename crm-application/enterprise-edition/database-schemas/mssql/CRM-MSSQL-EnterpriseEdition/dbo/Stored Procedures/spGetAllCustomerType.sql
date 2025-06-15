CREATE PROCEDURE [dbo].[spGetAllCustomerType]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Customer Type Id],
			[Customer Type],
			[Customer Type Description],
			[Company Configuration Id],
			[Company Name],
			[Active Status],
			[Created Timestamp],
			[Created By],
			[Modified Timestamp],
			[Modified By]
			FROM [dbo].[vwCustomerType]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END