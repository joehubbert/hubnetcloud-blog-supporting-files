CREATE PROCEDURE [dbo].[spCreateCustomerContact]
	@activeStatus BIT,
	@customerId UNIQUEIDENTIFIER,
	@emailAddress NVARCHAR(50),
	@firstName NVARCHAR(30),
	@lastName NVARCHAR(30),
	@role NVARCHAR(50),
	@telephoneNumber NVARCHAR(13)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #CustomerContactTemp
			(
				[CustomerId] UNIQUEIDENTIFIER NOT NULL,
				[FirstName] NVARCHAR(30) NOT NULL,
				[LastName] NVARCHAR(30) NOT NULL,
				[EmailAddress] NVARCHAR(50) NOT NULL,
				[TelephoneNumber] NVARCHAR(13) NOT NULL,
				[Role] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #CustomerContactTemp
			(
				[CustomerId],
				[FirstName],
				[LastName],
				[EmailAddress],
				[TelephoneNumber],
				[Role],
				[ActiveStatus]
			)
			VALUES
			(
				@customerId,
				@firstName,
				@lastName,
				@emailAddress,
				@telephoneNumber,
				@role,
				@activeStatus
			)

			IF EXISTS
			(
			SELECT *
			FROM [dbo].[CustomerContact] CC
			INNER JOIN #CustomerContactTemp CCT ON CC.[CustomerId] = CCT.[CustomerId]
			AND CC.[FirstName] = CCT.[FirstName]
			AND CC.[LastName] = CCT.[LastName]
			AND CC.[EmailAddress] = CCT.[EmailAddress]
			AND CC.[TelephoneNumber] = CCT.[TelephoneNumber]
			WHERE CC.[CustomerId] = CCT.[CustomerId]
			AND CC.[FirstName] = CCT.[FirstName]
			AND CC.[LastName] = CCT.[LastName]
			AND CC.[EmailAddress] = CCT.[EmailAddress]
			AND CC.[TelephoneNumber] = CCT.[TelephoneNumber]
			)
			THROW 50000, 'Customer Contact already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[CustomerContact] AS target
			USING #CustomerContactTemp AS source
			ON target.[CustomerId] = source.[CustomerId]
			AND target.[FirstName] = source.[FirstName]
			AND target.[LastName] = source.[LastName]
			AND target.[EmailAddress] = source.[EmailAddress]
			AND target.[TelephoneNumber] = source.[TelephoneNumber]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[CustomerId],
				[FirstName],
				[LastName],
				[EmailAddress],
				[TelephoneNumber],
				[Role],
				[ActiveStatus]
			)
			VALUES
			(
				source.[CustomerId],
				source.[FirstName],
				source.[LastName],
				source.[EmailAddress],
				source.[TelephoneNumber],
				source.[Role],
				source.[ActiveStatus]
			);

			DROP TABLE #CustomerContactTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END