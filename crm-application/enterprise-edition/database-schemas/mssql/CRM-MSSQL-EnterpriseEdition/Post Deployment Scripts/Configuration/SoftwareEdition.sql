IF EXISTS (
    SELECT 1 FROM sys.extended_properties 
    WHERE name = N'SoftwareEdition' AND class = 0
)
BEGIN
    EXEC sp_updateextendedproperty 
        @name = N'SoftwareEdition', 
        @value = N'Enterprise Edition';
END
ELSE
BEGIN
    EXEC sp_addextendedproperty 
        @name = N'SoftwareEdition', 
        @value = N'Enterprise Edition';
END