--1. Create SQL Server login for the service princpal for the Azure Data Factory instance in the context of the master database

CREATE LOGIN [<Name of our data factory>] FROM EXTERNAL PROVIDER

--2. Create database user for the login that was just created in the context of the reportingDatabase
CREATE USER [<Name of our data factory>] FROM LOGIN [<Name of our data factory>]

--3. Add database user to database reader and writer roles 
ALTER ROLE [db_datareader] ADD MEMBER [<Name of our data factory>]
ALTER ROLE [db_datareader] ADD MEMBER [<Name of our data factory>]

--4. Create database role to execute stored procedures that we'll need to merge in the data on an ongoing basis to avoid data duplication
CREATE ROLE [db_spexector]
GRANT EXECUTE TO [db_spexector]
ALTER ROLE [db_spexector] ADD MEMBER [<Name of our data factory>]