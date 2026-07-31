CREATE PROCEDURE [dbo].[spUpdateCustomerLeadType]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@customerLeadType NVARCHAR(50),
	@customerLeadTypeCode NVARCHAR(20),
	@customerLeadTypeDescription NVARCHAR(255) = NULL,
	@customerLeadTypeId UNIQUEIDENTIFIER,
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[CustomerLeadType]
			SET
				[ActiveStatus] = @activeStatus,
				[CompanyConfigurationId] = @companyConfigurationId,
				[CustomerLeadType] = @customerLeadType,
				[CustomerLeadTypeCode] = @customerLeadTypeCode,
				[CustomerLeadTypeDescription] = @customerLeadTypeDescription,
				[MasterDataTypeId] = @masterDataTypeId
			WHERE [CustomerLeadTypeId] = @customerLeadTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END