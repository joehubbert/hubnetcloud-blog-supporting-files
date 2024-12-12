using CRM_WindowsForms.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace CRM_WindowsForms.Presentation
{
    public partial class AppConfiguration : Form
    {
        private DatabaseConnectionSettings _databaseConnectionSettings;

        public AppConfiguration()
        {
            InitializeComponent();
            LoadConfigurationAsync();
        }

        private async void LoadConfigurationAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            appConfigurationDatabaseServernameTextbox.Text = _databaseConnectionSettings.ServerName;
            appConfigurationDatabaseNameTextbox.Text = _databaseConnectionSettings.DatabaseName;
            appConfigurationDatabaseEncryptConnectionCheckbox.Checked = _databaseConnectionSettings.EncryptConnection;
        }

        private async void appConfigurationSaveSettingsButton_Click(object sender, EventArgs e)
        {
            _databaseConnectionSettings.ServerName = appConfigurationDatabaseServernameTextbox.Text;
            _databaseConnectionSettings.DatabaseName = appConfigurationDatabaseNameTextbox.Text;
            _databaseConnectionSettings.EncryptConnection = appConfigurationDatabaseEncryptConnectionCheckbox.Checked;
            await _databaseConnectionSettings.SaveAsync();
            MessageBox.Show("Database Settings saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void appConfigurationTestConnectionButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseConnectionSettings.DatabaseConnectionString))
                {
                    connection.Open();
                    MessageBox.Show("Connection successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}