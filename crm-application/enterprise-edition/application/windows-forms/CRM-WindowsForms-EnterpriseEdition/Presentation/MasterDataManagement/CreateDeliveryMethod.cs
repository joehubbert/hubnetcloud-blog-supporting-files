using CRM.Helpers;
using CRM.Interface;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.MasterDataManagement
{
    public partial class CreateDeliveryMethod : Form
    {
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private TextBoxNumericCharacterDataValidationHelper _textBoxNumericHelper;

        public CreateDeliveryMethod()
        {
            InitializeComponent();
            _textBoxNumericHelper = new TextBoxNumericCharacterDataValidationHelper();
            InitializeEventHandlers();
            LoadDatabaseConnectionSettingsAsync();
            LoadTaxProfileAsync();
        }

        private void InitializeEventHandlers()
        {
            createDeliveryMethodDeliveryCostTextBoxA.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            createDeliveryMethodDeliveryCostTextBoxB.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            createDeliveryMethodDeliveryTimeTextBox.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
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
            bool activeStatus = createDeliveryMethodActiveStatusCheckBox.Checked;
            decimal deliveryCost = decimal.Parse($"{TextBoxCleanerHelper.GetTrimmedText(createDeliveryMethodDeliveryCostTextBoxA)}.{TextBoxCleanerHelper.GetTrimmedText(createDeliveryMethodDeliveryCostTextBoxB)}");
            string deliveryMethod = TextBoxCleanerHelper.GetTrimmedText(createDeliveryMethodDeliveryMethodTextBox);
            int deliveryTime = int.Parse(TextBoxCleanerHelper.GetTrimmedText(createDeliveryMethodDeliveryTimeTextBox));
            Guid taxProfileId = (Guid)createDeliveryMethodTaxProfileComboBox.SelectedValue;

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