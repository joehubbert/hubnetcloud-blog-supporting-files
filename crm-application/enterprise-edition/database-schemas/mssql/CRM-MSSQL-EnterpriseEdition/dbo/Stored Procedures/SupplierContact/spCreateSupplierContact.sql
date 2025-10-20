CREATE PROCEDURE [dbo].[spCreateSupplierContact]
	@activeStatus BIT,
	@supplierId UNIQUEIDENTIFIER,
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

			CREATE TABLE #SupplierContactTemp
			(
				[SupplierId] UNIQUEIDENTIFIER NOT NULL,
				[FirstName] NVARCHAR(30) NOT NULL,
				[LastName] NVARCHAR(30) NOT NULL,
				[EmailAddress] NVARCHAR(50) NOT NULL,
				[TelephoneNumber] NVARCHAR(13) NOT NULL,
				[Role] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #SupplierContactTemp
			(
				[SupplierId],
				[FirstName],
				[LastName],
				[EmailAddress],
				[TelephoneNumber],
				[Role],
				[ActiveStatus]
			)
			VALUES
			(
				@supplierId,
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
				FROM [dbo].[SupplierContact] SC
				INNER JOIN #SupplierContactTemp SCT ON SC.[SupplierId] = SCT.[SupplierId]
				AND SC.[FirstName] = SCT.[FirstName]
				AND SC.[LastName] = SCT.[LastName]
				AND SC.[EmailAddress] = SCT.[EmailAddress]
				AND SC.[TelephoneNumber] = SCT.[TelephoneNumber]
				WHERE SC.[SupplierId] = SCT.[SupplierId]
				AND SC.[FirstName] = SCT.[FirstName]
				AND SC.[LastName] = SCT.[LastName]
				AND SC.[EmailAddress] = SCT.[EmailAddress]
				AND SC.[TelephoneNumber] = SCT.[TelephoneNumber]
			)
			THROW 50000, 'Supplier Contact already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[SupplierContact] AS target
			USING #SupplierContactTemp AS source
			ON target.[SupplierId] = source.[SupplierId]
			AND target.[FirstName] = source.[FirstName]
			AND target.[LastName] = source.[LastName]
			AND target.[EmailAddress] = source.[EmailAddress]
			AND target.[TelephoneNumber] = source.[TelephoneNumber]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[SupplierId],
				[FirstName],
				[LastName],
				[EmailAddress],
				[TelephoneNumber],
				[Role],
				[ActiveStatus]
			)
			VALUES
			(
				source.[SupplierId],
				source.[FirstName],
				source.[LastName],
				source.[EmailAddress],
				source.[TelephoneNumber],
				source.[Role],
				source.[ActiveStatus]
			);

			DROP TABLE #SupplierContactTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END