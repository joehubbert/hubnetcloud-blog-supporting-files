using CRM.Interface;
using CRM.Services;

namespace CRM.Helpers
{
    public class TestDatabaseConnectionSettingsHelper
    {
        public async Task<bool> TestDatabaseConnectionSettings(string dataSubject, DatabaseConnectionSettings databaseConnectionSettings)
        {
            bool connectionAvailable = false;
            try
            {
                connectionAvailable = await DBInterface.TestConnectionAsync(databaseConnectionSettings.DatabaseConnectionString);
            }
            catch (Exception ex)
            {
                new ErrorMessageService("Error.Database.Connection.Failed", dataSubject, ex.Message);
                return false;
            }

            if (!connectionAvailable)
            {
                new ErrorMessageService("Error.Database.Connection.Failed", dataSubject, "Could not connect to the database.");
                return false;
            }

            return true;
        }
    }
}