CREATE PROCEDURE [dbo].[spDeleteCustomerLeadStatus]
	@customerLeadStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

		DELETE CLS
		FROM [dbo].[CustomerLeadStatus] CLS
		INNER JOIN [dbo].[MasterDataType] MDT ON CLS.[MasterDataTypeId] = MDT.[MasterDataTypeId]
		WHERE CLS.[CustomerLeadStatusId] = @customerLeadStatusId
		AND MDT.[IsCustom] = 1

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END