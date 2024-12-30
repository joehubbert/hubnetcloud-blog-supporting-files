CREATE PROCEDURE [dbo].[spCreateSalesRegionMember]
	@activeStatus BIT,
	@salesRegionId UNIQUEIDENTIFIER,
	@salwsRegionMember NVARCHAR(50)
AS

CREATE TABLE #SalesRegionMemberTemp
(
	[SalesRegionId] UNIQUEIDENTIFIER NOT NULL,
	[SalesRegionMember] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #SalesRegionMemberTemp
(
	[SalesRegionId],
	[SalesRegionMember],
	[ActiveStatus]
)
VALUES
(
	@salesRegionId,
	@salwsRegionMember,
	@activeStatus
)

IF EXISTS
(
SELECT *
FROM [dbo].[SalesRegionMember] SRM
INNER JOIN #SalesRegionMemberTemp SRMT ON SRM.[SalesRegionId] = SRMT.[SalesRegionId]
AND SRM.[SalesRegionMember] = SRMT.[SalesRegionMember]
WHERE SRM.[SalesRegionId] = SRMT.[SalesRegionId]
AND SRM.[SalesRegionMember] = SRMT.[SalesRegionMember]
)
THROW 50000, 'Sales Region Member already exists, please update the existing record.', 1;
ELSE
MERGE INTO [dbo].[SalesRegionMember] AS target
USING #SalesRegionMemberTemp AS source
ON target.[SalesRegionId] = source.[SalesRegionId]
AND target.[SalesRegionMember] = source.[SalesRegionMember]
WHEN NOT MATCHED THEN
INSERT
(
	[SalesRegionId],
	[SalesRegionMember],
	[ActiveStatus]
)
VALUES
(
	source.[SalesRegionId],
	source.[SalesRegionMember],
	source.[ActiveStatus]
);

DROP TABLE #SalesRegionMemberTemp;