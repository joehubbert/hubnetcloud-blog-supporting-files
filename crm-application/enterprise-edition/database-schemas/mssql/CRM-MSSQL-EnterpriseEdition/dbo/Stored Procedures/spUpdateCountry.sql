CREATE PROCEDURE [dbo].[spUpdateCountry]
    @activeStatus BIT,
	@countryId UNIQUEIDENTIFIER,
	@countryEnglishName NVARCHAR(100),
	@iso31661A2CountryCode NCHAR(2)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[Country]
			SET
				[ActiveStatus] = @activeStatus,
				[CountryEnglishName] = @countryEnglishName,
				[ISO31661A2CountryCode] = @iso31661A2CountryCode
			WHERE [CountryId] = @countryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END