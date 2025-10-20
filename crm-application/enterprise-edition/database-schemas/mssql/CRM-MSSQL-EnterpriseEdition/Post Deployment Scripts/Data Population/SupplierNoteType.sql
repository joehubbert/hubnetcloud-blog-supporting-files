CREATE TABLE #SupplierNoteTypeTemp
(
	[SupplierNoteType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #SupplierNoteTypeTemp 
(
	[SupplierNoteType],
	[ActiveStatus]
)
VALUES
(
	'General',
	1
),
(
	'Quality',
	1
),
(
	'Compliance',
	1
),
(
	'Product',
	1
),
(
	'Service',
	1
),
(
	'Logistics',
	1
),
(
	'Finance',
	1
),
(
	'Product Offering',
	1
)

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

DROP TABLE #SupplierNoteTypeTemp