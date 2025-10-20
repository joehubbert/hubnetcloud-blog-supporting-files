CREATE TABLE #HTMLTemplateTypeTemp
(
	[HTMLTemplateType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #HTMLTemplateTypeTemp
(
	[HTMLTemplateType],
	[ActiveStatus]
) 
VALUES 
(
	'Invoice', 
	1
),
(
	'Purchase Order', 
	1
),
(
	'Delivery Note', 
	1
),
(
	'Email Notification', 
	1
),
(
	'Email Newsletter', 
	1
)

MERGE INTO [dbo].[HTMLTemplateType] AS target
USING #HTMLTemplateTypeTemp AS source
ON target.[HTMLTemplateType] = source.[HTMLTemplateType]
WHEN NOT MATCHED THEN
INSERT
(
	[HTMLTemplateType],
	[ActiveStatus]
)
VALUES 
(
	source.[HTMLTemplateType],
	source.[ActiveStatus]
);

DROP TABLE #HTMLTemplateTypeTemp