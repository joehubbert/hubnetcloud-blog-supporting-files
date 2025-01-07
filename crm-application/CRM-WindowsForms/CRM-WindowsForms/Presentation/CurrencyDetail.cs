using CRM_WindowsForms.Model;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace CRM_WindowsForms.Presentation
{
    public partial class CurrencyDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _currencyId;
        private string ?currencyDetailCurrencyCodeOriginalValue;
        private string ?currencyDetailCurrencyNameOriginalValue;
        private bool ?currencyDetailActiveStatusOriginalValue;

        public CurrencyDetail(Guid currencyId)
        {
            InitializeComponent();
            _currencyId = currencyId;
            currencyDetailToggleEditModeButton.Click += currencyDetailToggleEditModeButton_Click;
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void ViewCurrencyDetailCurrencyInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@currencyId", _currencyId)
                };

                DataTable currencyDataTable = await executor.ExecuteAsync("[dbo].[spGetCurrency]", parameters);

                if (currencyDataTable != null)
                {
                    DataRow currencyDataRow = currencyDataTable.Rows[0];
                    currencyDetailCurrencyIdTextbox.Text = currencyDataRow["Currency ID"].ToString();
                    currencyDetailCurrencyCodeTextbox.Text = currencyDataRow["Currency Code"].ToString();
                    currencyDetailCurrencyNameTextbox.Text = currencyDataRow["Currency Name"].ToString();
                    currencyDetailCreatedByTextbox.Text = currencyDataRow["Created By"].ToString();
                    currencyDetailCreatedTimestampTextbox.Text = currencyDataRow["Created Timestamp"].ToString();
                    currencyDetailLastUpdatedByTextbox.Text = currencyDataRow["Modified By"].ToString();
                    currencyDetailLastUpdatedTimestampTextbox.Text = currencyDataRow["Modified Timestamp"].ToString();
                    currencyDetailActiveStatusCheckbox.Checked = (bool)currencyDataRow["Active Status"];

                    currencyDetailCurrencyCodeOriginalValue = currencyDataRow["Currency Code"].ToString();
                    currencyDetailCurrencyNameOriginalValue = currencyDataRow["Currency Name"].ToString();
                    currencyDetailActiveStatusOriginalValue = (bool)currencyDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Currency.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Currency details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            StringBuilder validationErrors = new StringBuilder();

            string currencyCode = currencyDetailCurrencyCodeTextbox.Text.TrimEnd();
            string currencyName = currencyDetailCurrencyNameTextbox.Text.TrimEnd();

            if (currencyCode.Length > 3)
            {
                validationErrors.AppendLine($"Currency Code cannot be longer than 3 characters. Submitted length is {currencyCode.Length} characters.");
            }

            if (currencyName.Length > 50)
            {
                validationErrors.AppendLine($"Currency Name cannot be longer than 50 characters. Submitted length is {currencyName.Length} characters.");
            }

            if (ContainsSqlInjectionRisk(currencyCode) ||
                ContainsSqlInjectionRisk(currencyName))
            {
                validationErrors.AppendLine("Input contains potentially dangerous characters that could lead to SQL injection.");
            }

            if (validationErrors.Length > 0)
            {
                MessageBox.Show(validationErrors.ToString(), "Validation Error: ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ContainsSqlInjectionRisk(string input)
        {
            string[] sqlInjectionRiskCharacters = { "--", ";--", ";", "/*", "*/", "@@" };
            foreach (var riskChar in sqlInjectionRiskCharacters)
            {
                if (input.Contains(riskChar))
                {
                    return true;
                }
            }
            return false;
        }


        private async void currencyDetailUpdateCurrencyButton_Click(object sender, EventArgs e)
        {
            string currencyCode = currencyDetailCurrencyCodeTextbox.Text.TrimEnd();
            string currencyName = currencyDetailCurrencyNameTextbox.Text.TrimEnd();

            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateInput())
            {
                return;
            }

            var result = MessageBox.Show("Are you sure that you want to update the following values?\n\n" +
                $"Currency Code Original Value: {currencyDetailCurrencyCodeOriginalValue}" + $"\nCurrency Code New Value: {currencyCode}\n" +
                $"Currency Name Original Value: {currencyDetailCurrencyNameOriginalValue}" + $"\nCurrency Name New Value: {currencyName}\n" +
                $"Active Status Original Value: {currencyDetailActiveStatusOriginalValue}" + $"\nActive Status New Value: {currencyDetailActiveStatusCheckbox.Checked}\n\n" +
                "This action cannot be undone.", "Update Currency Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Code to update the customer tier details
                try
                {
                    ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@activeStatus", currencyDetailActiveStatusCheckbox.Checked),
                        new SqlParameter("@currencyCode", currencyCode),
                        new SqlParameter("@currencyName", currencyName),
                        new SqlParameter("@currencyId", _currencyId) 
                    };

                    await executor.ExecuteAsync("[dbo].[spUpdateCurrency]", parameters);
                    MessageBox.Show("Currency details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update Currency details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Update details were cancelled, no changes have been made to the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            ViewCurrencyDetailCurrencyInformation_Load(this, EventArgs.Empty);
        }

        private void currencyDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            currencyDetailCurrencyCodeTextbox.Enabled = !currencyDetailCurrencyCodeTextbox.Enabled;
            currencyDetailCurrencyNameTextbox.Enabled = !currencyDetailCurrencyNameTextbox.Enabled;
            currencyDetailActiveStatusCheckbox.Enabled = !currencyDetailActiveStatusCheckbox.Enabled;
            currencyDetailUpdateCurrencyButton.Enabled = !currencyDetailUpdateCurrencyButton.Enabled;
        }
    }
}