CREATE TABLE #HTMLTemplateTypeTemp
(
	[HTMLTemplateType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #HTMLTemplateTypeTemp ([HTMLTemplateType], [ActiveStatus]) VALUES ('Invoice', 1)
INSERT INTO #HTMLTemplateTypeTemp ([HTMLTemplateType], [ActiveStatus]) VALUES ('Email Notification', 1)
INSERT INTO #HTMLTemplateTypeTemp ([HTMLTemplateType], [ActiveStatus]) VALUES ('Email Newsletter', 1)

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