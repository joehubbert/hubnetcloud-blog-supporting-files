using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Text;

namespace CRM_WindowsForms.Presentation
{
    public partial class PaymentMethodDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _paymentMethodId;
        private bool? paymentMethodDetailActiveStatusOriginalValue;
        private string? paymentMethodDetailPaymentMethodOriginalValue;

        public PaymentMethodDetail(Guid paymentMethodId)
        {
            InitializeComponent();
            _paymentMethodId = paymentMethodId;
            paymentMethodDetailToggleEditModeButton.Click += paymentMethodDetailToggleEditModeButton_Click;
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void ViewPaymentMethodDetailPaymentMethodInformation_Load(object sender, EventArgs e)
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
                    new SqlParameter("@paymentMethodId", _paymentMethodId)
                };

                DataTable paymentMethodDataTable = await executor.ExecuteAsync("[dbo].[spGetPaymentMethod]", parameters);

                if (paymentMethodDataTable != null)
                {
                    DataRow paymentMethodDataRow = paymentMethodDataTable.Rows[0];
                    paymentMethodDetailPaymentMethodIdTextbox.Text = paymentMethodDataRow["Payment Method ID"].ToString();
                    paymentMethodDetailPaymentMethodTextbox.Text = paymentMethodDataRow["Payment Method"].ToString();
                    paymentMethodDetailCreatedByTextbox.Text = paymentMethodDataRow["Created By"].ToString();
                    paymentMethodDetailCreatedTimestampTextbox.Text = paymentMethodDataRow["Created Timestamp"].ToString();
                    paymentMethodDetailLastUpdatedByTextbox.Text = paymentMethodDataRow["Modified By"].ToString();
                    paymentMethodDetailLastUpdatedTimestampTextbox.Text = paymentMethodDataRow["Modified Timestamp"].ToString();
                    paymentMethodDetailActiveStatusCheckbox.Checked = (bool)paymentMethodDataRow["Active Status"];

                    paymentMethodDetailPaymentMethodOriginalValue = paymentMethodDataRow["Payment Method"].ToString();
                    paymentMethodDetailActiveStatusOriginalValue = (bool)paymentMethodDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Payment Method.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Payment Method details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            StringBuilder validationErrors = new StringBuilder();

            string paymentMethod = paymentMethodDetailPaymentMethodTextbox.Text.TrimEnd();

            if (paymentMethod.Length > 50)
            {
                validationErrors.AppendLine($"Payment Method cannot be longer than 50 characters. Submitted length is {paymentMethod.Length} characters.");
            }

            if (SQLInjectionRiskCheck.ContainsSqlInjectionRisk(paymentMethod))
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

        private async void paymentMethodDetailUpdatePaymentMethodButton_Click(object sender, EventArgs e)
        {
            string paymentMethod = paymentMethodDetailPaymentMethodTextbox.Text.TrimEnd();

            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateInput())
            {
                return;
            }

            var changes = new StringBuilder("Are you sure that you want to update the following values?\n\n");

            if (paymentMethodDetailPaymentMethodOriginalValue != paymentMethod)
            {
                changes.AppendLine($"Payment Method Original Value: {paymentMethodDetailPaymentMethodOriginalValue}" + $"\nPayment Method New Value: {paymentMethod}\n");
            }

            if (paymentMethodDetailActiveStatusOriginalValue != paymentMethodDetailActiveStatusCheckbox.Checked)
            {
                changes.AppendLine($"Active Status Original Value: {paymentMethodDetailActiveStatusOriginalValue}" + $"\nActive Status New Value: {paymentMethodDetailActiveStatusCheckbox.Checked}\n\n");
            }

            changes.AppendLine("This action cannot be undone.");

            var result = MessageBox.Show(changes.ToString(), "Update Payment Method Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Code to update the supplier type details
                try
                {
                    ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@activeStatus", paymentMethodDetailActiveStatusCheckbox.Checked),
                        new SqlParameter("@paymentMethod", paymentMethod),
                        new SqlParameter("@paymentMethodId", _paymentMethodId)
                    };

                    await executor.ExecuteAsync("[dbo].[spUpdatePaymentMethod]", parameters);
                    MessageBox.Show("Payment Method details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update Payment Method details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ViewPaymentMethodDetailPaymentMethodInformation_Load(this, EventArgs.Empty);
        }

        private void paymentMethodDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            paymentMethodDetailPaymentMethodTextbox.Enabled = !paymentMethodDetailPaymentMethodTextbox.Enabled;
            paymentMethodDetailActiveStatusCheckbox.Enabled = !paymentMethodDetailActiveStatusCheckbox.Enabled;
            paymentMethodDetailUpdatePaymentMethodButton.Enabled = !paymentMethodDetailUpdatePaymentMethodButton.Enabled;
        }
    }
}