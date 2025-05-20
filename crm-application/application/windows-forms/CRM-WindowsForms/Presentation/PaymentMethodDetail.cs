using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class PaymentMethodDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Payment Method";
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

        private async void ViewSupplierTypeDetailSupplierTypeInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string storedProcedureName = "[dbo].[spGetPaymentMethod]";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@paymentMethodId",
                    ParameterValue = _paymentMethodId
                }
            };

            try
            {
                DataTable? paymentMethodDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (paymentMethodDataTable != null)
                {
                    DataRow paymentMethodDataRow = paymentMethodDataTable.Rows[0];
                    paymentMethodDetailPaymentMethodIdTextbox.Text = paymentMethodDataRow["Payment Method Id"].ToString();
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

        private async void paymentMethodDetailUpdatePaymentMethodButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = paymentMethodDetailActiveStatusCheckbox.Checked;
            string paymentMethod = paymentMethodDetailPaymentMethodTextbox.Text.TrimEnd();

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
                    Name = "PaymentMethod",
                    Value = paymentMethod,
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
                        OriginalValue = paymentMethodDetailActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Payment Method",
                        VariableType = "string",
                        OriginalValue = paymentMethodDetailPaymentMethodOriginalValue,
                        NewValue = paymentMethod
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
                            ParameterName = "@paymentMethod",
                            ParameterValue = paymentMethod
                        },
                        new Parameter
                        {
                            ParameterName = "@paymentMethodId",
                            ParameterValue = _paymentMethodId
                        }
                    };
                    string storedProcedureName = "[dbo].[spUpdatePaymentMethod]";
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

        private void paymentMethodDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            paymentMethodDetailPaymentMethodTextbox.Enabled = !paymentMethodDetailPaymentMethodTextbox.Enabled;
            paymentMethodDetailActiveStatusCheckbox.Enabled = !paymentMethodDetailActiveStatusCheckbox.Enabled;
            paymentMethodDetailUpdatePaymentMethodButton.Enabled = !paymentMethodDetailUpdatePaymentMethodButton.Enabled;
        }
    }
}