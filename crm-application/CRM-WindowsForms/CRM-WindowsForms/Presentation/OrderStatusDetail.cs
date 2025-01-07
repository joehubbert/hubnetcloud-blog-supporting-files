using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace CRM_WindowsForms.Presentation
{
    public partial class OrderStatusDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _orderStatusId;
        private bool ?orderStatusDetailActiveStatusOriginalValue;
        private string ?orderStatusDetailOrderStatusOriginalValue;

        public OrderStatusDetail(Guid orderStatusId)
        {
            InitializeComponent();
            _orderStatusId = orderStatusId;
            orderStatusDetailToggleEditModeButton.Click += orderStatusDetailToggleEditModeButton_Click;
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void ViewOrderStatusDetailOrderStatusInformation_Load(object sender, EventArgs e)
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
                    new SqlParameter("@orderStatusId", _orderStatusId)
                };

                DataTable orderStatusDataTable = await executor.ExecuteAsync("[dbo].[spGetOrderStatus]", parameters);

                if (orderStatusDataTable != null)
                {
                    DataRow orderStatusDataRow = orderStatusDataTable.Rows[0];
                    orderStatusDetailOrderStatusIdTextbox.Text = orderStatusDataRow["Order Status ID"].ToString();
                    orderStatusDetailOrderStatusTextbox.Text = orderStatusDataRow["Order Status"].ToString();
                    orderStatusDetailCreatedByTextbox.Text = orderStatusDataRow["Created By"].ToString();
                    orderStatusDetailCreatedTimestampTextbox.Text = orderStatusDataRow["Created Timestamp"].ToString();
                    orderStatusDetailLastUpdatedByTextbox.Text = orderStatusDataRow["Modified By"].ToString();
                    orderStatusDetailLastUpdatedTimestampTextbox.Text = orderStatusDataRow["Modified Timestamp"].ToString();
                    orderStatusDetailActiveStatusCheckbox.Checked = (bool)orderStatusDataRow["Active Status"];

                    orderStatusDetailOrderStatusOriginalValue = orderStatusDataRow["Order Status"].ToString();
                    orderStatusDetailActiveStatusOriginalValue = (bool)orderStatusDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Order Status.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Order Status details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            StringBuilder validationErrors = new StringBuilder();

            string orderStatus = orderStatusDetailOrderStatusTextbox.Text.TrimEnd();

            if (orderStatus.Length > 50)
            {
                validationErrors.AppendLine($"Order Status cannot be longer than 50 characters. Submitted length is {orderStatus.Length} characters.");
            }

            if (SQLInjectionRiskCheck.ContainsSqlInjectionRisk(orderStatus))
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

        private async void orderStatusDetailUpdateOrderStatusButton_Click(object sender, EventArgs e)
        {
            string orderStatus = orderStatusDetailOrderStatusTextbox.Text.TrimEnd();

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
                $"Order Status Original Value: {orderStatusDetailOrderStatusOriginalValue}" + $"\nOrder Status New Value: {orderStatus}\n" +
                $"Active Status Original Value: {orderStatusDetailActiveStatusOriginalValue}" + $"\nActive Status New Value: {orderStatusDetailActiveStatusCheckbox.Checked}\n\n" +
                "This action cannot be undone.", "Update Order Status Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Code to update the customer type details
                try
                {
                    ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@activeStatus", orderStatusDetailActiveStatusCheckbox.Checked),
                        new SqlParameter("@orderStatus", orderStatus),
                        new SqlParameter("@orderStatusId", _orderStatusId)
                    };

                    await executor.ExecuteAsync("[dbo].[spUpdateOrderStatus]", parameters);
                    MessageBox.Show("Order Status details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update Order Status details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ViewOrderStatusDetailOrderStatusInformation_Load(this, EventArgs.Empty);
        }

        private void orderStatusDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            orderStatusDetailOrderStatusTextbox.Enabled = !orderStatusDetailOrderStatusTextbox.Enabled;
            orderStatusDetailActiveStatusCheckbox.Enabled = !orderStatusDetailActiveStatusCheckbox.Enabled;
            orderStatusDetailUpdateOrderStatusButton.Enabled = !orderStatusDetailUpdateOrderStatusButton.Enabled;
        }
    }
}