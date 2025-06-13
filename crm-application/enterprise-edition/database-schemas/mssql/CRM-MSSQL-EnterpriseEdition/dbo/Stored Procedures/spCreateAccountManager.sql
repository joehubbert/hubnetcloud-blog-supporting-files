CREATE PROCEDURE [dbo].[spCreateAccountManager]
   @activeStatus BIT,
   @companyConfigurationId UNIQUEIDENTIFIER,
   @emailAddress NVARCHAR(50),
   @firstName NVARCHAR(50),
   @lastName NVARCHAR(50),
   @telephoneNumber NVARCHAR(13)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

            CREATE TABLE #AccountManagerTemp
            (
                [CompanyConfigurationId] UNIQUEIDENTIFIER NOT NULL,
                [FirstName] NVARCHAR(50) NOT NULL,
                [LastName] NVARCHAR(50) NOT NULL,
                [EmailAddress] NVARCHAR(50) NOT NULL,
                [TelephoneNumber] NVARCHAR(50) NOT NULL,
                [ActiveStatus] BIT NOT NULL
            )

            INSERT INTO #AccountManagerTemp
            (
                [CompanyConfigurationId],
                [FirstName],
                [LastName],
                [EmailAddress],
                [TelephoneNumber],
                [ActiveStatus]
            )  
            VALUES
            (
                @companyConfigurationId,
                @firstName,
                @lastName,
                @emailAddress,
                @telephoneNumber,
                @activeStatus
            )

            IF EXISTS
            (
            SELECT *
            FROM [dbo].[AccountManager] AM
            INNER JOIN #AccountManagerTemp AMT ON AM.[CompanyConfigurationId] = AMT.[CompanyConfigurationId]
            AND AM.[FirstName] = AMT.[FirstName]
            AND AM.[LastName] = AMT.[LastName]
            AND AM.[EmailAddress] = AMT.[EmailAddress]
            AND AM.[TelephoneNumber] = AMT.[TelephoneNumber]
            WHERE AM.[CompanyConfigurationId] = AMT.[CompanyConfigurationId]
            AND AM.[FirstName] = AMT.[FirstName]
            AND AM.[LastName] = AMT.[LastName]
            AND AM.[EmailAddress] = AMT.[EmailAddress]
            AND AM.[TelephoneNumber] = AMT.[TelephoneNumber]
            )
            THROW 50000, 'Account Manager already exists, please update the existing record.', 1;
            ELSE
            MERGE INTO [dbo].[AccountManager] AS target
            USING #AccountManagerTemp AS source
            ON target.[CompanyConfigurationId] = source.[CompanyConfigurationId]
            AND target.[FirstName] = source.[FirstName]
            AND target.[LastName] = source.[LastName]
            AND target.[EmailAddress] = source.[EmailAddress]
            AND target.[TelephoneNumber] = source.[TelephoneNumber]
            AND target.[ActiveStatus] = source.[ActiveStatus]
            WHEN NOT MATCHED THEN
                INSERT
                (
                    [CompanyConfigurationId],
                    [FirstName],
                    [LastName],
                    [EmailAddress],
                    [TelephoneNumber],
                    [ActiveStatus]
                )
                VALUES
                (
                    source.[CompanyConfigurationId],
                    source.[FirstName],
                    source.[LastName],
                    source.[EmailAddress],
                    source.[TelephoneNumber],
                    source.[ActiveStatus]
                );

            DROP TABLE #AccountManagerTemp
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END