CREATE PROCEDURE [dbo].[spUpdateSupplierContact]
	@activeStatus BIT,
	@supplierContactId UNIQUEIDENTIFIER,
	@emailAddress NVARCHAR(50),
	@firstName NVARCHAR(30),
	@lastName NVARCHAR(30),
	@role NVARCHAR(50),
	@telephoneNumber NVARCHAR(13)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[SupplierContact]
			SET
				[ActiveStatus] = @activeStatus,
				[EmailAddress] = @emailAddress,
				[FirstName] = @firstName,
				[LastName] = @lastName,
				[Role] = @role,
				[TelephoneNumber] = @telephoneNumber
			WHERE [SupplierContactId] = @supplierContactId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END