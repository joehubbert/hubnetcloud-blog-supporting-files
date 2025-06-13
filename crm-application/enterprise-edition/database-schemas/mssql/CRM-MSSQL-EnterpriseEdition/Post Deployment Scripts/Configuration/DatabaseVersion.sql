IF EXISTS (
    SELECT 1 FROM sys.extended_properties 
    WHERE name = N'DatabaseVersion' AND class = 0
)
    EXEC sp_updateextendedproperty 
        @name = N'DatabaseVersion', 
        @value = $(DatabaseVersion);
ELSE
    EXEC sp_addextendedproperty 
        @name = N'DatabaseVersion', 
        @value = $(DatabaseVersion);