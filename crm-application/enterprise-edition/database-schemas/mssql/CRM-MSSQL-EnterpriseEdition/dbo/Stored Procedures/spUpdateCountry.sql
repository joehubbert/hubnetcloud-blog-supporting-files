CREATE PROCEDURE [dbo].[spUpdateCountry]
    @activeStatus BIT,
	@countryId UNIQUEIDENTIFIER,
	@countryName NVARCHAR(100),
	@isoCountryCode NCHAR(2)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[Country]
			SET
				[ActiveStatus] = @activeStatus,
				[CountryName] = @countryName,
				[ISOCountryCode] = @isoCountryCode
			WHERE [CountryId] = @countryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END