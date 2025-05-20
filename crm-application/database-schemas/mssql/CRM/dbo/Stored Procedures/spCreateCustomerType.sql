CREATE PROCEDURE [dbo].[spCreateCustomerType]
	@activeStatus BIT,
	@customerType NVARCHAR(50)
AS

CREATE TABLE #CustomerTypeTemp
(
	[CustomerType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #CustomerTypeTemp
(
	[CustomerType],
	[ActiveStatus]
)
VALUES
(
	@customerType,
	@activeStatus
)

IF EXISTS
(
SELECT *
FROM [dbo].[CustomerType] CT
INNER JOIN #CustomerTypeTemp CTT ON CT.[CustomerType] = CTT.[CustomerType]
WHERE CT.[CustomerType] = CTT.[CustomerType]
)
THROW 50000, 'Customer Type already exists, please update the existing record.', 1;
ELSE
MERGE INTO [dbo].[CustomerType] AS target
USING #CustomerTypeTemp AS source
ON target.[CustomerType] = source.[CustomerType]
WHEN NOT MATCHED THEN
INSERT
(
	[CustomerType],
	[ActiveStatus]
)
VALUES
(
	source.[CustomerType],
	source.[ActiveStatus]
);

DROP TABLE #CustomerTypeTemp;