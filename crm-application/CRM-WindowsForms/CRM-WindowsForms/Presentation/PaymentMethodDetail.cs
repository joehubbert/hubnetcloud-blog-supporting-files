using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace CRM_WindowsForms.Presentation
{
    public partial class PaymentMethodDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _paymentMethodId;
        private bool? paymentMethodDetailActiveStatusOriginalValue;
        private string? paymentMethodDetailSupplierTypeOriginalValue;

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

        private async void ViewSupplierTypeDetailSupplierTypeInformation_Load(object sender, EventArgs e)
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
                    paymentMethodDetailSupplierTypeIdTextbox.Text = paymentMethodDataRow["Payment Method ID"].ToString();
                    paymentMethodDetailSupplierTypeTextbox.Text = paymentMethodDataRow["Payment Method"].ToString();
                    paymentMethodDetailCreatedByTextbox.Text = paymentMethodDataRow["Created By"].ToString();
                    paymentMethodDetailCreatedTimestampTextbox.Text = paymentMethodDataRow["Created Timestamp"].ToString();
                    paymentMethodDetailLastUpdatedByTextbox.Text = paymentMethodDataRow["Modified By"].ToString();
                    paymentMethodDetailLastUpdatedTimestampTextbox.Text = paymentMethodDataRow["Modified Timestamp"].ToString();
                    paymentMethodDetailActiveStatusCheckbox.Checked = (bool)paymentMethodDataRow["Active Status"];

                    paymentMethodDetailSupplierTypeOriginalValue = paymentMethodDataRow["Payment Method"].ToString();
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

            string paymentMethod = paymentMethodDetailSupplierTypeTextbox.Text.TrimEnd();

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

        private async void paymentMethodDetailUpdateSupplierTypeButton_Click(object sender, EventArgs e)
        {
            string paymentMethod = paymentMethodDetailSupplierTypeTextbox.Text.TrimEnd();

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
                $"Payment Method Original Value: {paymentMethodDetailSupplierTypeOriginalValue}" + $"\nPayment Method New Value: {paymentMethod}\n" +
                $"Active Status Original Value: {paymentMethodDetailActiveStatusOriginalValue}" + $"\nActive Status New Value: {paymentMethodDetailActiveStatusCheckbox.Checked}\n\n" +
                "This action cannot be undone.", "Update Payment Method Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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

                    await executor.ExecuteAsync("[dbo].[spUpdateSupplierType]", parameters);
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
            ViewSupplierTypeDetailSupplierTypeInformation_Load(this, EventArgs.Empty);
        }

        private void paymentMethodDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            paymentMethodDetailSupplierTypeTextbox.Enabled = !paymentMethodDetailSupplierTypeTextbox.Enabled;
            paymentMethodDetailActiveStatusCheckbox.Enabled = !paymentMethodDetailActiveStatusCheckbox.Enabled;
            paymentMethodDetailUpdateSupplierTypeButton.Enabled = !paymentMethodDetailUpdateSupplierTypeButton.Enabled;
        }
    }
}