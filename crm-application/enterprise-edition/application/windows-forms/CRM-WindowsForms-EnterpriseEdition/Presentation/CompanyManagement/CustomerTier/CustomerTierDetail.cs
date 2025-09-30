using CRM.Helpers;
using CRM.Interface;
using CRM.Model;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.CompanyManagement.CustomerTier
{
    public partial class CustomerTierDetail : Form
    {
        private readonly Guid _customerTierId;
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private bool customerTierDetailActiveStatusOriginalValue;
        private Guid customerTierDetailCompanyConfigurationIdOriginalValue;
        private string customerTierDetailCustomerTierCodeOriginalValue;
        private string customerTierDetailCustomerTierDescriptionOriginalValue;
        private readonly string dataSubject = "Customer Tier";

        public CustomerTierDetail(Guid customerTierId)
        {
            InitializeComponent();
            InitializeEventHandlers();
            _customerTierId = customerTierId;
            LoadDatabaseConnectionSettingsAsync();
        }

		protected override async void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			await LoadDatabaseConnectionSettingsAsync();
			CustomerTierDetailCustomerTierInformation_Load(this, EventArgs.Empty);
		}

		private void InitializeEventHandlers()
        {
            
        }

		private async void CustomerTierDetailCustomerTierInformation_Load(object sender, EventArgs e)
		{
			if (_databaseConnectionSettings == null)
			{
				ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
				return;
			}

			string storedProcedureName = "spGetCustomerTier";

			var parameters = new[]
			{
				new StoredProcedureParameter
				{
					ParameterName = "customerTierId",
					ParameterValue = _customerTierId
				}
			};

			try
			{
				DataTable? customerTierDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(dataSubject, _databaseConnectionSettings, storedProcedureName, parameters);

				if (customerTierDataTable != null)
				{
					DataRow customerTierDataRow = customerTierDataTable.Rows[0];
					customerTierDetailCustomerTierIdTextBox.Text = customerTierDataRow["Customer Tier Id"].ToString();
					customerTierDetailCustomerTierCodeTextBox.Text = customerTierDataRow["Customer Tier Code"].ToString();
					customerTierDetailCustomerTierDescriptionTextBox.Text = customerTierDataRow["Customer Tier Description"].ToString();
					customerTierDetailCreatedByTextBox.Text = customerTierDataRow["Created By"].ToString();
					customerTierDetailCreatedTimestampTextBox.Text = customerTierDataRow["Created Timestamp UTC"].ToString();
					customerTierDetailLastUpdatedByTextBox.Text = customerTierDataRow["Modified By"].ToString();
					customerTierDetailLastUpdatedTimestampTextBox.Text = customerTierDataRow["Modified Timestamp UTC"].ToString();
					customerTierDetailActiveStatusCheckBox.Checked = (bool)customerTierDataRow["Active Status"];
					Guid companyConfigurationId = (Guid)customerTierDataRow["Company Configuration Id"];
					await LoadCompanyConfigurationAsync(companyConfigurationId);

					customerTierDetailCompanyConfigurationIdOriginalValue = (Guid)customerTierDataRow["Company Configuration Id"];
					customerTierDetailCustomerTierCodeOriginalValue = customerTierDataRow["Customer Tier Code"].ToString();
					customerTierDetailCustomerTierDescriptionOriginalValue = customerTierDataRow["Customer Tier Description"].ToString();
					customerTierDetailActiveStatusOriginalValue = (bool)customerTierDataRow["Active Status"];

					this.Text += $" ({customerTierDetailCustomerTierDescriptionOriginalValue})";
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

		private async Task LoadCompanyConfigurationAsync(Guid companyConfigurationId)
		{
			_dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerTierDetailCompanyConfigurationComboBox,
                FunctionTitle.CompanyConfiguration,
                null,
                true,
                "Company Configuration Id",
                companyConfigurationId,
                false,
                null,
                null,
                null,
                true);
            await _dataAccessComboBoxHelper.LoadDataAsync();
		}

		private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

		private void customerTierDetailToggleEditModeButton_Click(object? sender, EventArgs e)
		{
			customerTierDetailCompanyConfigurationComboBox.Enabled = !customerTierDetailCompanyConfigurationComboBox.Enabled;
			customerTierDetailCustomerTierCodeTextBox.ReadOnly = !customerTierDetailCustomerTierCodeTextBox.ReadOnly;
			customerTierDetailCustomerTierDescriptionTextBox.ReadOnly = !customerTierDetailCustomerTierDescriptionTextBox.ReadOnly;
			customerTierDetailActiveStatusCheckBox.Enabled = !customerTierDetailActiveStatusCheckBox.Enabled;
			customerTierDetailUpdateCustomerTierButton.Enabled = !customerTierDetailUpdateCustomerTierButton.Enabled;
		}

		private async void customerTierDetailUpdateCustomerTierButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = customerTierDetailActiveStatusCheckBox.Checked;
            Guid companyConfigurationId = (Guid)customerTierDetailCompanyConfigurationComboBox.SelectedValue;
            string customerTierCode = TextBoxCleanerHelper.GetTrimmedText(customerTierDetailCustomerTierCodeTextBox);
            string customerTierDescription = TextBoxCleanerHelper.GetTrimmedText(customerTierDetailCustomerTierDescriptionTextBox);

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
                    Name = "Company Configuration Id",
                    Value = companyConfigurationId,
                    ValueType = typeof(Guid)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Tier Code",
                    Value = customerTierCode,
                    MaxLength = 1,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Tier Description",
                    Value = customerTierDescription,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
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
                        OriginalValue = customerTierDetailActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Company Configuration Id",
                        OriginalValue = customerTierDetailCompanyConfigurationIdOriginalValue,
                        NewValue = companyConfigurationId
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Tier Code",
                        OriginalValue = customerTierDetailCustomerTierCodeOriginalValue,
                        NewValue = customerTierCode
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Tier Description",
                        OriginalValue = customerTierDetailCustomerTierDescriptionOriginalValue,
                        NewValue = customerTierDescription
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
                            ParameterName = "companyConfigurationId",
                            ParameterValue = companyConfigurationId
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "customerTier",
                            ParameterValue = customerTierDescription
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "customerTierCode",
                            ParameterValue = customerTierCode
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "customerTierId",
                            ParameterValue = _customerTierId
                        }
                    };
                    string storedProcedureName = "spUpdateCustomerTier";
                    DataOperationType operationType = DataOperationType.Update;

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(dataSubject, _databaseConnectionSettings, operationType, storedProcedureName,  parameters);
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