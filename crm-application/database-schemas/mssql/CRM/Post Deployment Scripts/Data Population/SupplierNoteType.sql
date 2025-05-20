CREATE TABLE #SupplierNoteTypeTemp
(
	[SupplierNoteType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #SupplierNoteTypeTemp ([SupplierNoteType], [ActiveStatus]) VALUES ('General', 1)
INSERT INTO #SupplierNoteTypeTemp ([SupplierNoteType], [ActiveStatus]) VALUES ('Product', 1)
INSERT INTO #SupplierNoteTypeTemp ([SupplierNoteType], [ActiveStatus]) VALUES ('Service', 1)
INSERT INTO #SupplierNoteTypeTemp ([SupplierNoteType], [ActiveStatus]) VALUES ('Logistics', 1)
INSERT INTO #SupplierNoteTypeTemp ([SupplierNoteType], [ActiveStatus]) VALUES ('Finance', 1)
INSERT INTO #SupplierNoteTypeTemp ([SupplierNoteType], [ActiveStatus]) VALUES ('Product Offering', 1)

MERGE INTO [dbo].[SupplierNoteType] AS target
USING #SupplierNoteTypeTemp AS source
ON target.[SupplierNoteType] = source.[SupplierNoteType]
WHEN NOT MATCHED THEN
INSERT
(
	[SupplierNoteType],
	[ActiveStatus]
)
VALUES
(
	source.[SupplierNoteType],
	source.[ActiveStatus]
);

DROP TABLE #SupplierNoteTypeTemp;