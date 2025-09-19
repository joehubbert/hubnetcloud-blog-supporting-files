CREATE PROCEDURE [dbo].[spUpdateCustomerContact]
	@activeStatus BIT,
	@customerContactId UNIQUEIDENTIFIER,
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

			UPDATE [dbo].[CustomerContact]
			SET
				[ActiveStatus] = @activeStatus,
				[EmailAddress] = @emailAddress,
				[FirstName] = @firstName,
				[LastName] = @lastName,
				[Role] = @role,
				[TelephoneNumber] = @telephoneNumber
			WHERE [CustomerContactId] = @customerContactId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END