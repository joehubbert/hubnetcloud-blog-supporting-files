CREATE TABLE #SupplierNoteTypeTemp
(
	[SupplierNoteType] NVARCHAR(50) NOT NULL
)

INSERT INTO #SupplierNoteTypeTemp ([SupplierNoteType]) VALUES ('General')
INSERT INTO #SupplierNoteTypeTemp ([SupplierNoteType]) VALUES ('Product')
INSERT INTO #SupplierNoteTypeTemp ([SupplierNoteType]) VALUES ('Service')
INSERT INTO #SupplierNoteTypeTemp ([SupplierNoteType]) VALUES ('Logistics')
INSERT INTO #SupplierNoteTypeTemp ([SupplierNoteType]) VALUES ('Finance')
INSERT INTO #SupplierNoteTypeTemp ([SupplierNoteType]) VALUES ('Product Offering')

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