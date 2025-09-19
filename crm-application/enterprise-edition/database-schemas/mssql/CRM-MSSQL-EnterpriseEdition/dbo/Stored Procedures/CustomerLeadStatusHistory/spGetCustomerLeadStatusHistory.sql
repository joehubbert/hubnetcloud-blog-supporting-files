CREATE PROCEDURE [dbo].[spGetCustomerLeadStatusHistory]
	@customerLeadStatusHistoryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Customer Lead Status History Id],
			[Customer Lead Status Id],
			[Customer Lead Status],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By]
			FROM [dbo].[vwCustomerLeadStatusHistory]
			WHERE [Customer Lead Status History Id] = @customerLeadStatusHistoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END