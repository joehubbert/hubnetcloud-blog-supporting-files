CREATE PROCEDURE [dbo].[spCreateCompanyConfiguration]
    @addressLine1 NVARCHAR(50),
    @addressLine2 NVARCHAR(50) = NULL,
    @addressLine3 NVARCHAR(50),
    @addressLine4 NVARCHAR(50),
    @addressLine5 NVARCHAR(50),
	@companyName NVARCHAR(50),
    @emailAddress NVARCHAR(50),
    @telephoneNumber NVARCHAR(50),
    @vatNumber NVARCHAR(50) = NULL
AS

CREATE TABLE #CompanyConfigurationTemp
(
	[CompanyName] NVARCHAR(50) NOT NULL,
    [AddressLine1] NVARCHAR(50) NOT NULL,
    [AddressLine2] NVARCHAR(50) NULL,
    [AddressLine3] NVARCHAR(50) NOT NULL,
    [AddressLine4] NVARCHAR(50) NOT NULL,
    [AddressLine5] NVARCHAR(50) NOT NULL,
    [TelephoneNumber] NVARCHAR(50) NOT NULL,
    [EmailAddress] NVARCHAR(50) NOT NULL,
    [VATNumber] NVARCHAR(50) NULL
)

INSERT INTO #CompanyConfigurationTemp
(
    [CompanyName],
    [AddressLine1],
    [AddressLine2],
    [AddressLine3],
    [AddressLine4],
    [AddressLine5],
    [TelephoneNumber],
    [EmailAddress],
    [VATNumber]
)
VALUES
(
    @companyName,
    @addressLine1,
    @addressLine2,
    @addressLine3,
    @addressLine4,
    @addressLine5,
    @telephoneNumber,
    @emailAddress,
    @vatNumber
)

IF EXISTS
(
SELECT *
FROM [dbo].[CompanyConfiguration] C
INNER JOIN #CompanyConfigurationTemp CT ON C.[CompanyName] = CT.[CompanyName]
AND C.[VATNumber] = CT.[VATNumber]
WHERE C.[CompanyName] = CT.[CompanyName]
AND C.[VATNumber] = CT.[VATNumber]
)
THROW 50000, 'Company already exists, please update the existing record.', 1;
ELSE
MERGE INTO [dbo].[CompanyConfiguration] AS target
USING #CompanyConfigurationTemp AS source
ON target.[AddressLine1] = source.[AddressLine1]
AND target.[AddressLine2] = source.[AddressLine2]
AND target.[AddressLine3] = source.[AddressLine3]
AND target.[AddressLine4] = source.[AddressLine4]
AND target.[AddressLine5] = source.[AddressLine5]
AND target.[CompanyName] = source.[CompanyName]
AND target.[EmailAddress] = source.[EmailAddress]
AND target.[TelephoneNumber] = source.[TelephoneNumber]
AND target.[VATNumber] = source.[VATNumber]
WHEN NOT MATCHED THEN
INSERT
(
    [CompanyName],
    [AddressLine1],
    [AddressLine2],
    [AddressLine3],
    [AddressLine4],
    [AddressLine5],
    [TelephoneNumber],
    [EmailAddress],
    [VATNumber]
)
VALUES
(
    source.[CompanyName],
    source.[AddressLine1],
    source.[AddressLine2],
    source.[AddressLine3],
    source.[AddressLine4],
    source.[AddressLine5],
    source.[TelephoneNumber],
    source.[EmailAddress],
    source.[VATNumber]
);