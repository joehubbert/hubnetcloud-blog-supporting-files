CREATE PROCEDURE [dbo].[spUpdateManufacturer]
    @activeStatus BIT,
	@addressLine1 NVARCHAR(50),
    @addressLine2 NVARCHAR(50) = NULL,
    @addressLine3 NVARCHAR(50),
    @addressLine4 NVARCHAR(50),
    @addressLine5 UNIQUEIDENTIFIER,
    @emailAddress NVARCHAR(50),
    @manufacturerId UNIQUEIDENTIFIER,
    @manufacturerName NVARCHAR(50),
    @telephoneNumber NVARCHAR(50),
    @vatNumber NVARCHAR(50) = NULL,
    @vatRegistered BIT
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

            UPDATE [dbo].[Manufacturer]
            SET
                [ActiveStatus] = @activeStatus,
                [AddressLine1] = @addressLine1,
                [AddressLine2] = @addressLine2,
                [AddressLine3] = @addressLine3,
                [AddressLine4] = @addressLine4,
                [AddressLine5] = @addressLine5,
                [EmailAddress] = @emailAddress,
                [ManufacturerName] = @manufacturerName,
                [TelephoneNumber] = @telephoneNumber,
                [VATNumber] = @vatNumber,
                [VATRegistered] = @vatRegistered
            WHERE [ManufacturerId] = @manufacturerId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END