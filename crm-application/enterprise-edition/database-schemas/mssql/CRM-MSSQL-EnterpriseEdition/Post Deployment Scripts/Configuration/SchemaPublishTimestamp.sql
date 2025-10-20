DECLARE @publishTimestamp DATETIME2 = SYSUTCDATETIME();

IF EXISTS (
    SELECT 1 FROM sys.extended_properties 
    WHERE name = N'SchemaPublishTimestampUTC' AND class = 0
)
BEGIN
    EXEC sp_updateextendedproperty 
        @name = N'SchemaPublishTimestampUTC', 
        @value = @publishTimestamp
END
ELSE
BEGIN
    EXEC sp_addextendedproperty 
        @name =  N'SchemaPublishTimestampUTC', 
        @value = @publishTimestamp
END