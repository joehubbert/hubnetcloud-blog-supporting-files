CREATE PROCEDURE [dbo].[spCreateSupplierNoteType]
	@supplierNoteType NVARCHAR(50)
AS

CREATE TABLE #SupplierNoteTypeTemp
(
	[SupplierNoteType] NVARCHAR(50) NOT NULL
)

INSERT INTO #SupplierNoteTypeTemp
(
	[SupplierNoteType]
)
VALUES
(
	@supplierNoteType
)

IF EXISTS
(
SELECT *
FROM [dbo].[SupplierNoteType] CT
INNER JOIN #SupplierNoteTypeTemp CTT ON CT.[SupplierNoteType] = CTT.[SupplierNoteType]
WHERE CT.[SupplierNoteType] = CTT.[SupplierNoteType]
)
THROW 50000, 'Supplier Note Type already exists, please update the existing record.', 1;
ELSE
MERGE INTO [dbo].[SupplierNoteType] AS target
USING #SupplierNoteTypeTemp AS source
ON target.[SupplierNoteType] = source.[SupplierNoteType]
WHEN NOT MATCHED THEN
INSERT
(
	[SupplierNoteType]
)
VALUES
(
	source.[SupplierNoteType]
);

DROP TABLE #SupplierNoteTypeTemp;