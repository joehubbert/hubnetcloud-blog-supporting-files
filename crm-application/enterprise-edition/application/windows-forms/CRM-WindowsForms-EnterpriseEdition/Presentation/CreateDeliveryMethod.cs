using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CreateDeliveryMethod : Form
    {
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public CreateDeliveryMethod()
        {
            InitializeComponent();
            InitializeEventHandlers();
            LoadDatabaseConnectionSettingsAsync();
            LoadTaxProfileAsync();
        }

        private void InitializeEventHandlers()
        {
            createDeliveryMethodTaxProfileComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void LoadTaxProfileAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createDeliveryMethodTaxProfileComboBox, "spGetAllTaxProfile");
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async void createDeliveryMethodSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createDeliveryMethodActiveStatusCheckbox.Checked;
            decimal deliveryCost = decimal.Parse(createDeliveryMethodDeliveryCostTextBoxA.Text.TrimEnd()) + (decimal.Parse(createDeliveryMethodDeliveryCostTextBoxB.Text.TrimEnd()) / 100);
            string deliveryMethod = createDeliveryMethodDeliveryMethodTextBox.Text.TrimEnd();
            int deliveryTime = int.Parse(createDeliveryMethodDeliveryTimeTextBox.Text.TrimEnd());
            Guid taxProfileId = Guid.Parse(createDeliveryMethodTaxProfileComboBox.SelectedValue.ToString());

            string dataSubject = "Delivery Method";

            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            var dataToValidate = new List<ValidateDataInputService.DataProperty>
            {
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Active Status",
                    Value = activeStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Delivery Cost",
                    Value = deliveryCost,
                    ValueType = typeof(decimal)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Delivery Method",
                    Value = deliveryMethod,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Delivery Time",
                    Value = deliveryTime,
                    ValueType = typeof(int)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Tax Profile Id",
                    Value = taxProfileId,
                    ValueType = typeof(Guid)
                }
            };

            dataToValidate = dataToValidate.OrderBy(change => change.Name).ToList();

            var validationResult = ValidateDataInputService.ValidateInput(dataToValidate);

            if (!validationResult.IsValid)
            {
                return;
            }
            else
            {
                var parameters = new[]
                {
                    new StoredProcedureParameter
                    {
                        ParameterName = "activeStatus",
                        ParameterValue = activeStatus
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "deliveryCost",
                        ParameterValue = deliveryCost
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "deliveryMethod",
                        ParameterValue = deliveryMethod
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "deliveryTime",
                        ParameterValue = deliveryTime
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "taxProfileId",
                        ParameterValue = taxProfileId
                    }
                };
                string storedProcedureName = "spCreateDeliveryMethod";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, operationType);
                this.Close();
            }
        }
    }
}