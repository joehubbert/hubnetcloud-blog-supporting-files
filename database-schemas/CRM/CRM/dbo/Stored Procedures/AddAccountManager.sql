CREATE PROCEDURE [dbo].[AddAccountManager]  
   @firstName NVARCHAR(50),
   @lastName NVARCHAR(50),
   @emailAddress NVARCHAR(50),
   @telephoneNumber NVARCHAR(13)
AS

CREATE TABLE #AccountManager
(
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
    [EmailAddress] NVARCHAR(50) NOT NULL,
    [TelephoneNumber] NVARCHAR(50) NOT NULL
)

INSERT INTO #AccountManager
(
    [FirstName],
    [LastName],
    [EmailAddress],
    [TelephoneNumber]
)  
VALUES
(
    @firstName,
    @lastName,
    @emailAddress,
    @telephoneNumber
)

IF EXISTS
(
SELECT *
FROM [dbo].AccountManager
WHERE [FirstName] = @firstName
AND [LastName] = @lastName
AND [EmailAddress] = @emailAddress
AND [TelephoneNumber] = @telephoneNumber
)

THROW 50000, 'Account Manager already exists, please update the existing record.', 1;
ELSE

MERGE INTO [dbo].[AccountManager] AS target
USING #AccountManager AS source
ON target.[FirstName] = source.[FirstName]
AND target.[LastName] = source.[LastName]
AND target.[EmailAddress] = source.[EmailAddress]
AND target.[TelephoneNumber] = source.[TelephoneNumber]
WHEN NOT MATCHED THEN
    INSERT
    (
        [FirstName],
        [LastName],
        [EmailAddress],
        [TelephoneNumber]
    )
    VALUES
    (
        source.[FirstName],
        source.[LastName],
        source.[EmailAddress],
        source.[TelephoneNumber]
    );