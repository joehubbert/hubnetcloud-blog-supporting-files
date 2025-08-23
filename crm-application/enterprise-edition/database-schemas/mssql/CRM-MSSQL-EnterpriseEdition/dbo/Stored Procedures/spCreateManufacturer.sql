CREATE PROCEDURE [dbo].[spCreateManufacturer]
    @activeStatus BIT,
	@addressLine1 NVARCHAR(50),
    @addressLine2 NVARCHAR(50) = NULL,
    @addressLine3 NVARCHAR(50),
    @addressLine4 NVARCHAR(50),
    @addressLine5 UNIQUEIDENTIFIER,
    @emailAddress NVARCHAR(50),
    @supplierName NVARCHAR(50),
    @telephoneNumber NVARCHAR(50),
    @vatNumber NVARCHAR(50) = NULL,
    @vatRegistered BIT
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

            CREATE TABLE #ManufacturerTemp
            (
	            [ManufacturerName] NVARCHAR(50) NOT NULL,
                [AddressLine1] NVARCHAR(50) NOT NULL,
                [AddressLine2] NVARCHAR(50) NULL,
                [AddressLine3] NVARCHAR(50) NOT NULL,
                [AddressLine4] NVARCHAR(50) NOT NULL,
                [AddressLine5] UNIQUEIDENTIFIER NOT NULL,
                [TelephoneNumber] NVARCHAR(50) NOT NULL,
                [EmailAddress] NVARCHAR(50) NOT NULL,
                [VATRegistered] BIT NOT NULL,
                [VATNumber] NVARCHAR(50) NULL,
                [ActiveStatus] BIT NOT NULL
            )

            INSERT INTO #ManufacturerTemp
            (
                [ManufacturerName],
                [AddressLine1],
                [AddressLine2],
                [AddressLine3],
                [AddressLine4],
                [AddressLine5],
                [TelephoneNumber],
                [EmailAddress],
                [VATRegistered],
                [VATNumber],
                [ActiveStatus]
            )
            VALUES
            (
                @supplierName,
                @addressLine1,
                @addressLine2,
                @addressLine3,
                @addressLine4,
                @addressLine5,
                @telephoneNumber,
                @emailAddress,
                @vatRegistered,
                @vatNumber,
                @activeStatus
            )

            IF EXISTS
            (
            SELECT *
            FROM [dbo].[Manufacturer] S
            INNER JOIN #ManufacturerTemp ST ON M.[AddressLine1] = MT.[AddressLine1]
            AND M.[AddressLine2] = MT.[AddressLine2]
            AND M.[AddressLine3] = MT.[AddressLine3]
            AND M.[AddressLine4] = MT.[AddressLine4]
            AND M.[AddressLine5] = MT.[AddressLine5]
            AND M.[ManufacturerName] = MT.[ManufacturerName]
            AND M.[EmailAddress] = MT.[EmailAddress]
            AND M.[TelephoneNumber] = MT.[TelephoneNumber]
            AND M.[VATRegistered] = MT.[VATRegistered]
            AND M.[VATNumber] = MT.[VATNumber]
            WHERE M.[AddressLine1] = MT.[AddressLine1]
            AND M.[AddressLine2] = MT.[AddressLine2]
            AND M.[AddressLine3] = MT.[AddressLine3]
            AND M.[AddressLine4] = MT.[AddressLine4]
            AND M.[AddressLine5] = MT.[AddressLine5]
            AND M.[ManufacturerName] = MT.[ManufacturerName]
            AND M.[EmailAddress] = MT.[EmailAddress]
            AND M.[TelephoneNumber] = MT.[TelephoneNumber]
            AND M.[VATRegistered] = MT.[VATRegistered]
            AND M.[VATNumber] = MT.[VATNumber]
            )
            THROW 50000, 'Manufacturer already exists, please update the existing record.', 1;
            ELSE
            MERGE INTO [dbo].[Manufacturer] AS target
            USING #ManufacturerTemp AS source
            ON target.[AddressLine1] = source.[AddressLine1]
            AND target.[AddressLine2] = source.[AddressLine2]
            AND target.[AddressLine3] = source.[AddressLine3]
            AND target.[AddressLine4] = source.[AddressLine4]
            AND target.[AddressLine5] = source.[AddressLine5]
            AND target.[ManufacturerName] = source.[ManufacturerName]
            AND target.[VATRegistered] = source.[VATRegistered]
            AND target.[VATNumber] = source.[VATNumber]
            WHEN NOT MATCHED THEN
            INSERT
            (
                [ManufacturerName],
                [AddressLine1],
                [AddressLine2],
                [AddressLine3],
                [AddressLine4],
                [AddressLine5],
                [TelephoneNumber],
                [EmailAddress],
                [VATRegistered],
                [VATNumber],
                [ActiveStatus]
            )
            VALUES
            (
                source.[ManufacturerName],
                source.[AddressLine1],
                source.[AddressLine2],
                source.[AddressLine3],
                source.[AddressLine4],
                source.[AddressLine5],
                source.[TelephoneNumber],
                source.[EmailAddress],
                source.[VATRegistered],
                source.[VATNumber],
                source.[ActiveStatus]
            );

            DROP TABLE #ManufacturerTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END