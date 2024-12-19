CREATE PROCEDURE [dbo].[spCreateCustomerNote]
	@customerId UNIQUEIDENTIFIER,
	@customerNote NVARCHAR(MAX),
	@customerNoteTitle NVARCHAR(50),
	@customerNoteTypeId UNIQUEIDENTIFIER
AS
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