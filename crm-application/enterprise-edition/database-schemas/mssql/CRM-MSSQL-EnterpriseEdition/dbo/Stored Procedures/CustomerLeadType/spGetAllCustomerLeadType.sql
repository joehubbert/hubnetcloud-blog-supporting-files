CREATE PROCEDURE [dbo].[spGetAllCustomerLeadType]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Customer Lead Type Id],
			[Customer Lead Type],
			[Customer Lead Type Description],
			[Active Status]
			FROM [dbo].[vwCustomerLeadType]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END