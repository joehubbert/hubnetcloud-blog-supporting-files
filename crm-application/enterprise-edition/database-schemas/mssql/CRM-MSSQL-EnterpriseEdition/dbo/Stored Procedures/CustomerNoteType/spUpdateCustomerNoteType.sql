CREATE PROCEDURE [dbo].[spUpdateCustomerNoteType]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@customerNoteType NVARCHAR(50),
	@customerNoteTypeId UNIQUEIDENTIFIER,
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[CustomerNoteType]
			SET
				[ActiveStatus] = @activeStatus,
				[CompanyConfigurationId] = @companyConfigurationId,
				[CustomerNoteType] = @customerNoteType,
				[MasterDataTypeId] = @masterDataTypeId
			WHERE [CustomerNoteTypeId] = @customerNoteTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END