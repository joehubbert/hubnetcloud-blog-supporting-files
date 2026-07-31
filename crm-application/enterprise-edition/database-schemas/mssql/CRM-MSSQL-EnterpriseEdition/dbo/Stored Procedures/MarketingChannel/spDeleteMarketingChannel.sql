CREATE PROCEDURE [dbo].[spDeleteMarketingChannel]
	@marketingChannelId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

		DELETE MC
		FROM [dbo].[MarketingChannel] MC
		INNER JOIN [dbo].[MasterDataType] MDT ON MC.[MasterDataTypeId] = MDT.[MasterDataTypeId]
		WHERE MC.[MarketingChannelId] = @marketingChannelId
		AND MDT.[IsCustom] = 1

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END