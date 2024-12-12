using CRM_WindowsForms.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Text;
using System.Windows.Forms;

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

            if (addNewAccountManagerFirstNameTextbox.Text.Length > 50)
            {
                validationErrors.AppendLine($"First Name cannot be longer than 50 characters. Submitted length is {addNewAccountManagerFirstNameTextbox.Text.Length} characters.");
            }

            if (addNewAccountManagerLastNameTextbox.Text.Length > 50)
            {
                validationErrors.AppendLine($"Last Name cannot be longer than 50 characters. Submitted length is {addNewAccountManagerLastNameTextbox.Text.Length} characters.");
            }

            if (addNewAccountManagerEmailAddressTextbox.Text.Length > 50)
            {
                validationErrors.AppendLine($"Email Address cannot be longer than 50 characters. Submitted length is {addNewAccountManagerEmailAddressTextbox.Text.Length} characters.");
            }
            else if (!addNewAccountManagerEmailAddressTextbox.Text.Contains("@"))
            {
                validationErrors.AppendLine("Email Address must contain an '@' symbol.");
            }

            if (addNewAccountManagerTelephoneNumberTextbox.Text.Length > 13)
            {
                validationErrors.AppendLine($"Telephone Number cannot be longer than 13 characters. Submitted length is {addNewAccountManagerTelephoneNumberTextbox.Text.Length} characters.");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(addNewAccountManagerTelephoneNumberTextbox.Text, @"^\+\d{12}$"))
            {
                validationErrors.AppendLine("Telephone Number must start with a '+' prefix followed by exactly 12 digits.");
            }

            if (ContainsSqlInjectionRisk(addNewAccountManagerFirstNameTextbox.Text) ||
                ContainsSqlInjectionRisk(addNewAccountManagerLastNameTextbox.Text) ||
                ContainsSqlInjectionRisk(addNewAccountManagerEmailAddressTextbox.Text) ||
                ContainsSqlInjectionRisk(addNewAccountManagerTelephoneNumberTextbox.Text))
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
            string[] sqlInjectionRiskCharacters = { "--", ";--", ";", "/*", "*/", "@@", "@" };
            foreach (var riskChar in sqlInjectionRiskCharacters)
            {
                if (input.Contains(riskChar))
                {
                    return true;
                }
            }
            return false;
        }

        private async void addNewAccountManagerSubmitButton_Click(object sender, EventArgs e)
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
                bool activeStatus = addNewAccountManagerActiveStatusCheckbox.Checked;
                string emailAddress = addNewAccountManagerEmailAddressTextbox.Text;
                string firstName = addNewAccountManagerFirstNameTextbox.Text;
                string lastName = addNewAccountManagerLastNameTextbox.Text;
                string telephoneNumber = addNewAccountManagerTelephoneNumberTextbox.Text;

                var parameters = new[]
                {
                        new SqlParameter("@activeStatus", activeStatus),
                        new SqlParameter("@emailAddress", emailAddress),
                        new SqlParameter("@firstName", firstName),
                        new SqlParameter("@lastName", lastName),
                        new SqlParameter("@telephoneNumber", telephoneNumber)
                    };

                ExecuteStoredProcedure executeor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                await executeor.ExecuteNonQueryAsync("[dbo].[CreateAccountManager]", parameters);

                MessageBox.Show("New account manager added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add new account manager: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}