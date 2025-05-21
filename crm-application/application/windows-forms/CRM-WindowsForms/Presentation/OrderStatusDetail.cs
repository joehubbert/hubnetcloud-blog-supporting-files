using CRM_WindowsForms.Interface;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class OrderStatusDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Order Status";
        private readonly Guid _orderStatusId;
        private bool? orderStatusDetailActiveStatusOriginalValue;
        private string? orderStatusDetailOrderStatusOriginalValue;

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

        private async void ViewSupplierTypeDetailSupplierTypeInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string storedProcedureName = "[dbo].[spGetOrderStatus]";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@orderStatusId",
                    ParameterValue = _orderStatusId
                }
            };

            try
            {
                DataTable? orderStatusDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (orderStatusDataTable != null)
                {
                    DataRow orderStatusDataRow = orderStatusDataTable.Rows[0];
                    orderStatusDetailOrderStatusIdTextbox.Text = orderStatusDataRow["Order Status Id"].ToString();
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

        private async void orderStatusDetailUpdateOrderStatusButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = orderStatusDetailActiveStatusCheckbox.Checked;
            string orderStatus = orderStatusDetailOrderStatusTextbox.Text.TrimEnd();

            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dataToValidate = new List<ValidateDataInput.DataProperty>
            {
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ActiveStatus",
                    Value = activeStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "OrderStatus",
                    Value = orderStatus,
                    MaxLength = 50,
                    ValueType = typeof(string)
                }
            };

            dataToValidate = dataToValidate.OrderBy(change => change.Name).ToList();

            var validationResult = ValidateDataInput.ValidateInput(dataToValidate);

            if (!validationResult.IsValid)
            {
                return;
            }
            else
            {
                var changesList = new List<ChangeDetail>
                {
                    new ChangeDetail
                    {
                        VariableName = "Active Status",
                        VariableType = "string",
                        OriginalValue = orderStatusDetailActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Order Status",
                        VariableType = "string",
                        OriginalValue = orderStatusDetailOrderStatusOriginalValue,
                        NewValue = orderStatus
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = UpdateConfirmation.ConfirmChanges(changesList, dataSubject);

                if (confirmed)
                {
                    var parameters = new[]
                    {
                        new Parameter
                        {
                            ParameterName = "@activeStatus",
                            ParameterValue = activeStatus
                        },
                        new Parameter
                        {
                            ParameterName = "@orderStatus",
                            ParameterValue = orderStatus
                        },
                        new Parameter
                        {
                            ParameterName = "@orderStatusId",
                            ParameterValue = _orderStatusId
                        }
                    };
                    string storedProcedureName = "[dbo].[spUpdateOrderStatus]";
                    string operationType = "update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Updates were cancelled, no changes have been made to the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            ViewSupplierTypeDetailSupplierTypeInformation_Load(this, EventArgs.Empty);
        }

        private void orderStatusDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            orderStatusDetailOrderStatusTextbox.ReadOnly = !orderStatusDetailOrderStatusTextbox.ReadOnly;
            orderStatusDetailActiveStatusCheckbox.Enabled = !orderStatusDetailActiveStatusCheckbox.Enabled;
            orderStatusDetailUpdateOrderStatusButton.Enabled = !orderStatusDetailUpdateOrderStatusButton.Enabled;
        }
    }
}