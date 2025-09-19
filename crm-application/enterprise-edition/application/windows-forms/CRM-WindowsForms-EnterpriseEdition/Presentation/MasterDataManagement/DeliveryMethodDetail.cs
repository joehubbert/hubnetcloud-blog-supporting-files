using CRM.Helpers;
using CRM.Interface;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.MasterDataManagement
{
    public partial class DeliveryMethodDetail : Form
    {
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _deliveryMethodId;
        private TextBoxNumericCharacterDataValidationHelper _textBoxNumericHelper;
        private bool deliveryMethodDetailActiveStatusOriginalValue;
        private decimal deliveryMethodDetailDeliveryCostOriginalValue;
        private string deliveryMethodDetailDeliveryMethodOriginalValue;
        private int deliveryMethodDetailDeliveryTimeOriginalValue;
        private Guid deliveryMethodDetailTaxProfileIdOriginalValue;

        public DeliveryMethodDetail(Guid deliveryMethodId)
        {
            InitializeComponent();
            _textBoxNumericHelper = new TextBoxNumericCharacterDataValidationHelper();
            InitializeEventHandlers();
            _deliveryMethodId = deliveryMethodId;
            LoadDatabaseConnectionSettingsAsync();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            DeliveryMethodDetailDeliveryMethodInformation_Load(this, EventArgs.Empty);
        }

        private void InitializeEventHandlers()
        {
            deliveryMethodDetailDeliveryCostTextBoxA.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            deliveryMethodDetailDeliveryCostTextBoxB.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            deliveryMethodDetailDeliveryTimeTextBox.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            deliveryMethodDetailTaxProfileComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
        }

        private async void DeliveryMethodDetailDeliveryMethodInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            string storedProcedureName = "spGetDeliveryMethod";
            string dataSubject = "Delivery Method";

            var parameters = new[]
            {
                    new StoredProcedureParameter
                    {
                        ParameterName = "deliveryMethodId",
                        ParameterValue = _deliveryMethodId
                    }
            };

            try
            {
                DataTable? deliveryMethodDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject);

                if (deliveryMethodDataTable != null)
                {
                    DataRow deliveryMethodDataRow = deliveryMethodDataTable.Rows[0];
                    string deliveryCostPartA;
                    string deliveryCostPartB;

                    SplitDecimalHelper.SplitDecimalUsingDelimiter((decimal)deliveryMethodDataRow["Delivery Cost"], out deliveryCostPartA, out deliveryCostPartB);

                    deliveryMethodDetailDeliveryMethodIdTextBox.Text = deliveryMethodDataRow["Delivery Method Id"].ToString();
                    deliveryMethodDetailDeliveryMethodTextBox.Text = deliveryMethodDataRow["Delivery Method"].ToString();
                    deliveryMethodDetailDeliveryCostTextBoxA.Text = deliveryCostPartA;
                    deliveryMethodDetailDeliveryCostTextBoxB.Text = deliveryCostPartB;
                    deliveryMethodDetailDeliveryTimeTextBox.Text = deliveryMethodDataRow["Delivery Time"].ToString();
                    Guid taxProfileId = (Guid)deliveryMethodDataRow["Tax Profile Id"];
                    await LoadTaxProfileAsync(taxProfileId);
                    deliveryMethodDetailCreatedByTextBox.Text = deliveryMethodDataRow["Created By"].ToString();
                    deliveryMethodDetailCreatedTimestampTextBox.Text = deliveryMethodDataRow["Created Timestamp UTC"].ToString();
                    deliveryMethodDetailLastUpdatedByTextBox.Text = deliveryMethodDataRow["Modified By"].ToString();
                    deliveryMethodDetailLastUpdatedTimestampTextBox.Text = deliveryMethodDataRow["Modified Timestamp UTC"].ToString();
                    deliveryMethodDetailActiveStatusCheckBox.Checked = (bool)deliveryMethodDataRow["Active Status"];

                    deliveryMethodDetailDeliveryMethodOriginalValue = deliveryMethodDataRow["Delivery Method"].ToString();
                    deliveryMethodDetailDeliveryCostOriginalValue = (decimal)deliveryMethodDataRow["Delivery Cost"];
                    deliveryMethodDetailDeliveryTimeOriginalValue = (int)deliveryMethodDataRow["Delivery Time"];
                    deliveryMethodDetailTaxProfileIdOriginalValue = (Guid)deliveryMethodDataRow["Tax Profile Id"];
                    deliveryMethodDetailActiveStatusOriginalValue = (bool)deliveryMethodDataRow["Active Status"];

                    this.Text += $" ({deliveryMethodDetailDeliveryMethodOriginalValue})";
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.NoDataFound", dataSubject);
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task LoadTaxProfileAsync(Guid taxProfileId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(deliveryMethodDetailTaxProfileComboBox,
                "spGetAllTaxProfile",
                null,
                true,
                "Tax Profile Id",taxProfileId,
                false,
                null,
                null,
                null,
                true);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private void deliveryMethodDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            deliveryMethodDetailDeliveryMethodTextBox.ReadOnly = !deliveryMethodDetailDeliveryMethodTextBox.ReadOnly;
            deliveryMethodDetailDeliveryCostTextBoxA.ReadOnly = !deliveryMethodDetailDeliveryCostTextBoxA.ReadOnly;
            deliveryMethodDetailDeliveryCostTextBoxB.ReadOnly = !deliveryMethodDetailDeliveryCostTextBoxB.ReadOnly;
            deliveryMethodDetailDeliveryTimeTextBox.ReadOnly = !deliveryMethodDetailDeliveryTimeTextBox.ReadOnly;
            deliveryMethodDetailTaxProfileComboBox.Enabled = !deliveryMethodDetailTaxProfileComboBox.Enabled;
            deliveryMethodDetailActiveStatusCheckBox.Enabled = !deliveryMethodDetailActiveStatusCheckBox.Enabled;
            deliveryMethodDetailUpdateDeliveryMethodButton.Enabled = !deliveryMethodDetailUpdateDeliveryMethodButton.Enabled;
        }

        private async void deliveryMethodDetailUpdateDeliveryMethodButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = deliveryMethodDetailActiveStatusCheckBox.Checked;
            decimal deliveryCost = decimal.Parse($"{TextBoxCleanerHelper.GetTrimmedText(deliveryMethodDetailDeliveryCostTextBoxA)}.{TextBoxCleanerHelper.GetTrimmedText(deliveryMethodDetailDeliveryCostTextBoxB)}");
            string deliveryMethod = TextBoxCleanerHelper.GetTrimmedText(deliveryMethodDetailDeliveryMethodTextBox);
            int deliveryTime = int.Parse(TextBoxCleanerHelper.GetTrimmedText(deliveryMethodDetailDeliveryTimeTextBox));
            Guid taxProfileId = (Guid)deliveryMethodDetailTaxProfileComboBox.SelectedValue;

            string dataSubject = "Delivery Method";

            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            var dataToValidate = new List<DataValidationService.DataProperty>
            {
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Active Status",
                    Value = activeStatus,
                    ValueType = typeof(bool)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Delivery Cost",
                    Value = deliveryCost,
                    ValueType = typeof(decimal)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Delivery Method",
                    Value = deliveryMethod,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Delivery Time",
                    Value = deliveryTime,
                    ValueType = typeof(int)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Tax Profile Id",
                    Value = taxProfileId,
                    ValueType = typeof(Guid)
                }
            };

            dataToValidate = dataToValidate.OrderBy(change => change.Name).ToList();

            var validationResult = DataValidationService.ValidateInput(dataToValidate);

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
                        OriginalValue = deliveryMethodDetailActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Delivery Method",
                        OriginalValue = deliveryMethodDetailDeliveryMethodOriginalValue,
                        NewValue = deliveryMethod
                    },
                    new ChangeDetail
                    {
                        VariableName = "Delivery Cost",
                        OriginalValue = deliveryMethodDetailDeliveryCostOriginalValue,
                        NewValue = deliveryCost
                    },
                    new ChangeDetail
                    {
                        VariableName = "Delivery Time",
                        OriginalValue = deliveryMethodDetailDeliveryTimeOriginalValue,
                        NewValue = deliveryTime
                    },
                    new ChangeDetail
                    {
                        VariableName = "Tax Profile Id",
                        OriginalValue = deliveryMethodDetailTaxProfileIdOriginalValue,
                        NewValue = taxProfileId
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = ChangeValidationService.ConfirmChanges(changesList, dataSubject);

                if (confirmed)
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
                            ParameterName = "deliveryMethodId",
                            ParameterValue = _deliveryMethodId
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
                    string storedProcedureName = "spUpdateDeliveryMethod";
                    string operationType = "Update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, operationType);
                    this.Close();
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.UpdateCancelled");
                    this.Close();
                }
            }
        }
    }
}