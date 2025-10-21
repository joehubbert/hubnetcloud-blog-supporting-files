CREATE PROCEDURE [dbo].[spUpdateCustomerLeadStatus]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@customerLeadStatus NVARCHAR(50),
	@customerLeadStatusCode NVARCHAR(20),
	@customerLeadStatusId UNIQUEIDENTIFIER,
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[CustomerLeadStatus]
			SET 
				[ActiveStatus] = @activeStatus,
				[CompanyConfigurationId] = @companyConfigurationId,
				[CustomerLeadStatus] = @customerLeadStatus,
				[CustomerLeadStatusCode] = @customerLeadStatusCode,
				[MasterDataTypeId] = @masterDataTypeId
			WHERE [CustomerLeadStatusId] = @customerLeadStatusId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END