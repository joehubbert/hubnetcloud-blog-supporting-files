CREATE PROCEDURE [dbo].[spUpdateHTMLTemplateType]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@htmlTemplateType NVARCHAR(50),
	@htmlTemplateTypeId UNIQUEIDENTIFIER,
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[HTMLTemplateType]
			SET
				[ActiveStatus] = @activeStatus,
				[CompanyConfigurationId] = @companyConfigurationId,
				[HTMLTemplateType] = @htmlTemplateType,
				[MasterDataTypeId] = @masterDataTypeId
			WHERE [HTMLTemplateTypeId] = @htmlTemplateTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END