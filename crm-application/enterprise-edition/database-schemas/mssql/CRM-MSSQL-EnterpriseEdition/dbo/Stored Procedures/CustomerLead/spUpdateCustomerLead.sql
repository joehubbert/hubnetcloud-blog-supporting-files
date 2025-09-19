CREATE PROCEDURE [dbo].[spUpdateCustomerLead]
	@customerContactId UNIQUEIDENTIFIER = NULL,
	@customerLead NVARCHAR(4000),
	@customerLeadId UNIQUEIDENTIFIER,
	@customerLeadMarketingChannelId UNIQUEIDENTIFIER = NULL,
	@customerLeadTargetDate DATE = NULL,
	@customerLeadTitle NVARCHAR(50),
	@customerLeadTypeId UNIQUEIDENTIFIER

AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[CustomerLead]
			SET
				[CustomerContactId] = @customerContactId,
				[CustomerLeadTypeId] = @customerLeadTypeId,
				[CustomerLeadTitle] = @customerLeadTitle,
				[CustomerLead] = @customerLead,
				[CustomerLeadTargetDate] = @customerLeadTargetDate,
				[CustomerLeadMarketingChannelId] = @customerLeadMarketingChannelId
			WHERE [CustomerLeadId] = @customerLeadId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END