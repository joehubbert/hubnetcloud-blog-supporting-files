CREATE PROCEDURE [dbo].[spCreateCustomerNote]
	@customerId UNIQUEIDENTIFIER,
	@customerNote NVARCHAR(4000),
	@customerNoteTitle NVARCHAR(50),
	@customerNoteTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			INSERT INTO [dbo].[CustomerNote]
			(
				[CustomerId],
				[CustomerNote],
				[CustomerNoteTitle],
				[CustomerNoteTypeId]
			)
			VALUES
			(
				@customerId,
				@customerNote,
				@customerNoteTitle,
				@customerNoteTypeId
			)

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END