CREATE PROCEDURE [dbo].[spUpdateAccountManager]
	@accountManagerId UNIQUEIDENTIFIER,
	@companyConfigurationId UNIQUEIDENTIFIER,
	@firstName NVARCHAR(50),
	@lastName NVARCHAR(50),
	@emailAddress NVARCHAR(50),
	@telephoneNumber NVARCHAR(50),
	@activeStatus BIT
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[AccountManager]
			SET 
				[CompanyConfigurationId] = @companyConfigurationId,
				[FirstName] = @firstName,
				[LastName] = @lastName,
				[EmailAddress] = @emailAddress,
				[TelephoneNumber] = @telephoneNumber,
				[ActiveStatus] = @activeStatus
			WHERE [AccountManagerId] = @accountManagerId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END