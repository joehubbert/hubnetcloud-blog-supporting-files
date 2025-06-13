IF EXISTS (
    SELECT 1 FROM sys.extended_properties 
    WHERE name = N'SoftwareEdition' AND class = 0
)
    EXEC sp_updateextendedproperty 
        @name = N'SoftwareEdition', 
        @value = N'Enterprise Edition';
ELSE
    EXEC sp_addextendedproperty 
        @name = N'SoftwareEdition', 
        @value = N'Enterprise Edition';