CREATE PROCEDURE [dbo].[spUpdateCustomerLeadNoteType]
	@activeStatus BIT,
	@companyConfgurationId UNIQUEIDENTIFIER = NULL,
	@customerLeadNoteType NVARCHAR(50),
	@customerLeadNoteTypeCode NVARCHAR(20),
	@customerLeadNoteTypeId UNIQUEIDENTIFIER,
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[CustomerLeadNoteType]
			SET
				[ActiveStatus] = @activeStatus,
				[CompanyConfigurationId] = @companyConfgurationId,
				[CustomerLeadNoteType] = @customerLeadNoteType,
				[CustomerLeadNoteTypeCode] = @customerLeadNoteTypeCode,
				[MasterDataTypeId] = @masterDataTypeId
			WHERE [CustomerLeadNoteTypeId] = @customerLeadNoteTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END