CREATE PROCEDURE [dbo].[spCreateCustomerLead]
	@customerId UNIQUEIDENTIFIER,
	@customerContactId UNIQUEIDENTIFIER = NULL,
	@customerLead NVARCHAR(4000),
	@customerLeadId UNIQUEIDENTIFIER OUTPUT,
	@customerLeadMarketingChannelId UNIQUEIDENTIFIER = NULL,
	@customerLeadTargetDate DATE = NULL,
	@customerLeadTitle NVARCHAR(50),
	@customerLeadTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

		CREATE TABLE #CustomerLeadTempOutput
		(
			[CustomerLeadId] UNIQUEIDENTIFIER NOT NULL
		);

		INSERT INTO [dbo].[CustomerLead]
		(
			[CustomerId],
			[CustomerContactId],
			[CustomerLeadTypeId],
			[CustomerLeadTitle],
			[CustomerLead],
			[CustomerLeadTargetDate],
			[CustomerLeadMarketingChannelId]
		)
		OUTPUT INSERTED.[CustomerLeadId] INTO #CustomerLeadTempOutput
		VALUES
		(
			@customerId,
			@customerContactId,
			@customerLeadTypeId,
			@customerLeadTitle,
			@customerLead,
			@customerLeadTargetDate,
			@customerLeadMarketingChannelId
		);

		SET @customerLeadId = (SELECT [CustomerLeadId] FROM #CustomerLeadTempOutput);
		DROP TABLE #CustomerLeadTempOutput;

		DECLARE @customerLeadStatusId UNIQUEIDENTIFIER;
		SELECT @customerLeadStatusId = [CustomerLeadStatusId] FROM [dbo].[CustomerLeadStatus] WHERE [CustomerLeadStatus] = 'New';

		EXEC [dbo].[spCreateCustomerLeadStatusHistory]
			@customerLeadId = @customerLeadId,
			@customerLeadStatusId = @customerLeadStatusId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END