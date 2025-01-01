using CRM_WindowsForms.Model;
using Microsoft.Data.SqlClient;
using System.Text;

namespace CRM_WindowsForms.Presentation
{
    public partial class CreateAccountManager : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public CreateAccountManager()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private bool ValidateInput()
        {
            StringBuilder validationErrors = new StringBuilder();

            string firstName = createAccountManagerFirstNameTextbox.Text.Trim();
            string lastName = createAccountManagerLastNameTextbox.Text.Trim();
            string emailAddress = createAccountManagerEmailAddressTextbox.Text.Trim();
            string telephoneNumber = createAccountManagerTelephoneNumberTextbox.Text.Trim();

            if (firstName.Length > 50)
            {
                validationErrors.AppendLine($"First Name cannot be longer than 50 characters. Submitted length is {firstName.Length} characters.");
            }

            if (lastName.Length > 50)
            {
                validationErrors.AppendLine($"Last Name cannot be longer than 50 characters. Submitted length is {lastName.Length} characters.");
            }

            if (emailAddress.Length > 50)
            {
                validationErrors.AppendLine($"Email Address cannot be longer than 50 characters. Submitted length is {emailAddress.Length} characters.");
            }
            else if (!emailAddress.Contains("@"))
            {
                validationErrors.AppendLine("Email Address must contain an '@' symbol.");
            }

            if (telephoneNumber.Length > 13)
            {
                validationErrors.AppendLine($"Telephone Number cannot be longer than 13 characters. Submitted length is {telephoneNumber.Length} characters.");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(telephoneNumber, @"^\+\d{12}$"))
            {
                validationErrors.AppendLine("Telephone Number must start with a '+' prefix followed by exactly 12 digits.");
            }

            if (ContainsSqlInjectionRisk(firstName) ||
                ContainsSqlInjectionRisk(lastName) ||
                ContainsSqlInjectionRisk(emailAddress) ||
                ContainsSqlInjectionRisk(telephoneNumber))
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

        private async void createAccountManagerSubmitButton_Click(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateInput())
            {
                return;
            }

            try
            {
                bool activeStatus = createAccountManagerActiveStatusCheckbox.Checked;
                string emailAddress = createAccountManagerEmailAddressTextbox.Text.Trim();
                string firstName = createAccountManagerFirstNameTextbox.Text.Trim();
                string lastName = createAccountManagerLastNameTextbox.Text.Trim();
                string telephoneNumber = createAccountManagerTelephoneNumberTextbox.Text.Trim();

                var parameters = new[]
                {
                        new SqlParameter("@activeStatus", activeStatus),
                        new SqlParameter("@emailAddress", emailAddress),
                        new SqlParameter("@firstName", firstName),
                        new SqlParameter("@lastName", lastName),
                        new SqlParameter("@telephoneNumber", telephoneNumber)
                    };

                ExecuteStoredProcedure executeor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                await executeor.ExecuteNonQueryAsync("[dbo].[spCreateAccountManager]", parameters);

                MessageBox.Show("New account manager added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add new account manager: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}