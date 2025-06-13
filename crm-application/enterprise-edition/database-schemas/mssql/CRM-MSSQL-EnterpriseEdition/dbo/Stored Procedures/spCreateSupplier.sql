CREATE PROCEDURE [dbo].[spCreateSupplier]
    @activeStatus BIT,
	@addressLine1 NVARCHAR(50),
    @addressLine2 NVARCHAR(50) = NULL,
    @addressLine3 NVARCHAR(50),
    @addressLine4 NVARCHAR(50),
    @addressLine5 NVARCHAR(50),
    @companyConfigurationId UNIQUEIDENTIFIER,
    @emailAddress NVARCHAR(50),
    @paymentCurrencyId UNIQUEIDENTIFIER,
    @paymentDays TINYINT,
    @supplierName NVARCHAR(50),
    @telephoneNumber NVARCHAR(50),
    @vatNumber NVARCHAR(50) = NULL
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

            CREATE TABLE #SupplierTemp
            (
	            [SupplierName] NVARCHAR(50) NOT NULL,
                [CompanyConfigurationId] UNIQUEIDENTIFIER NOT NULL,
                [AddressLine1] NVARCHAR(50) NOT NULL,
                [AddressLine2] NVARCHAR(50) NULL,
                [AddressLine3] NVARCHAR(50) NOT NULL,
                [AddressLine4] NVARCHAR(50) NOT NULL,
                [AddressLine5] NVARCHAR(50) NOT NULL,
                [TelephoneNumber] NVARCHAR(50) NOT NULL,
                [EmailAddress] NVARCHAR(50) NOT NULL,
                [PaymentDays] TINYINT NOT NULL,
                [PaymentCurrencyId] UNIQUEIDENTIFIER NOT NULL,
                [VATNumber] NVARCHAR(50) NULL,
                [ActiveStatus] BIT NOT NULL
            )

            INSERT INTO #SupplierTemp
            (
                [SupplierName],
                [CompanyConfigurationId],
                [AddressLine1],
                [AddressLine2],
                [AddressLine3],
                [AddressLine4],
                [AddressLine5],
                [TelephoneNumber],
                [EmailAddress],
                [PaymentDays],
                [PaymentCurrencyId],
                [VATNumber],
                [ActiveStatus]
            )
            VALUES
            (
                @supplierName,
                @companyConfigurationId,
                @addressLine1,
                @addressLine2,
                @addressLine3,
                @addressLine4,
                @addressLine5,
                @telephoneNumber,
                @emailAddress,
                @paymentDays,
                @paymentCurrencyId,
                @vatNumber,
                @activeStatus
            )

            IF EXISTS
            (
            SELECT *
            FROM [dbo].[Supplier] S
            INNER JOIN #SupplierTemp ST ON S.[AddressLine1] = ST.[AddressLine1]
            AND S.[AddressLine2] = ST.[AddressLine2]
            AND S.[AddressLine3] = ST.[AddressLine3]
            AND S.[AddressLine4] = ST.[AddressLine4]
            AND S.[AddressLine5] = ST.[AddressLine5]
            AND S.[CompanyConfigurationId] = ST.[CompanyConfigurationId]
            AND S.[SupplierName] = ST.[SupplierName]
            AND S.[VATNumber] = ST.[VATNumber]
            WHERE S.[AddressLine1] = ST.[AddressLine1]
            AND S.[AddressLine2] = ST.[AddressLine2]
            AND S.[AddressLine3] = ST.[AddressLine3]
            AND S.[AddressLine4] = ST.[AddressLine4]
            AND S.[AddressLine5] = ST.[AddressLine5]
            AND S.[CompanyConfigurationId] = ST.[CompanyConfigurationId]
            AND S.[SupplierName] = ST.[SupplierName]
            AND S.[VATNumber] = ST.[VATNumber]
            )
            THROW 50000, 'Supplier already exists, please update the existing record.', 1;
            ELSE
            MERGE INTO [dbo].[Supplier] AS target
            USING #SupplierTemp AS source
            ON target.[AddressLine1] = source.[AddressLine1]
            AND target.[AddressLine2] = source.[AddressLine2]
            AND target.[AddressLine3] = source.[AddressLine3]
            AND target.[AddressLine4] = source.[AddressLine4]
            AND target.[AddressLine5] = source.[AddressLine5]
            AND target.[CompanyConfigurationId] = source.[CompanyConfigurationId]
            AND target.[SupplierName] = source.[SupplierName]
            AND target.[VATNumber] = source.[VATNumber]
            WHEN NOT MATCHED THEN
            INSERT
            (
                [SupplierName],
                [CompanyConfigurationId],
                [AddressLine1],
                [AddressLine2],
                [AddressLine3],
                [AddressLine4],
                [AddressLine5],
                [TelephoneNumber],
                [EmailAddress],
                [PaymentDays],
                [PaymentCurrencyId],
                [VATNumber],
                [ActiveStatus]
            )
            VALUES
            (
                source.[SupplierName],
                source.[CompanyConfigurationId],
                source.[AddressLine1],
                source.[AddressLine2],
                source.[AddressLine3],
                source.[AddressLine4],
                source.[AddressLine5],
                source.[TelephoneNumber],
                source.[EmailAddress],
                source.[PaymentDays],
                source.[PaymentCurrencyId],
                source.[VATNumber],
                source.[ActiveStatus]
            );

            DROP TABLE #SupplierTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END