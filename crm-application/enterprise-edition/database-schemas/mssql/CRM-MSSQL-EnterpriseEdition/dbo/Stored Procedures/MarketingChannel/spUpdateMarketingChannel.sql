CREATE PROCEDURE [dbo].[spUpdateMarketingChannel]
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@marketingChannel NVARCHAR(50),
	@marketingChannelId UNIQUEIDENTIFIER,
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[MarketingChannel]
			SET
				[CompanyConfigurationId] = @companyConfigurationId,
				[MarketingChannel] = @marketingChannel,
				[MasterDataTypeId] = @masterDataTypeId
			WHERE [MarketingChannelId] = @marketingChannelId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END