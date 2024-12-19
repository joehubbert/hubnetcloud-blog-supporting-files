CREATE PROCEDURE [dbo].[spCreateCustomerType]
	@customerType NVARCHAR(50)
AS

CREATE TABLE #CustomerTypeTemp
(
	[CustomerType] NVARCHAR(50) NOT NULL
)

INSERT INTO #CustomerTypeTemp
(
	[CustomerType]
)
VALUES
(
	@customerType
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
	[CustomerType]
)
VALUES
(
	source.[CustomerType]
);

DROP TABLE #CustomerTypeTemp;