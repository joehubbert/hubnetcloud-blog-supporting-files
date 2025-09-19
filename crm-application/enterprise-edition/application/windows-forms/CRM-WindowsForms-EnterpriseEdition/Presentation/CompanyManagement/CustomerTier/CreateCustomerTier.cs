using CRM.Helpers;
using CRM.Interface;
using CRM.Services;

namespace CRM.Presentation.CompanyManagement.CustomerTier
{
    public partial class CreateCustomerTier : Form
    {
        private Guid _companyConfigurationId;
        private ActiveCompanyConfigurationHelper? _companyConfigHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Customer Tier";

        public CreateCustomerTier()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
            LoadActiveCompanyConfigurationAsync();
        }

        private async void LoadActiveCompanyConfigurationAsync()
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(createCustomerTierStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.LoadAsync();
            _companyConfigurationId = _companyConfigHelper.CompanyConfigurationId;
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void createCustomerTierSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createCustomerTierActiveStatusCheckBox.Checked;
            string customerTierCode = TextBoxCleanerHelper.GetTrimmedText(createCustomerTierCustomerTierCodeTextBox);
            string customerTierDescription = TextBoxCleanerHelper.GetTrimmedText(createCustomerTierCustomerTierDescriptionTextBox);

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
                    Value = _companyConfigurationId,
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
                        ParameterValue = _companyConfigurationId
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "customerTierCode",
                        ParameterValue = customerTierCode
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "customerTierDescription",
                        ParameterValue = customerTierDescription
                    }
                };
                string storedProcedureName = "spCreateCustomerTier";
                string operationType = "Create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, operationType);
                this.Close();
            }
        }

        private async void changeActiveCompanyConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(createCustomerTierStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.ShowChangeDialogAndReloadAsync(this);
            _companyConfigurationId = _companyConfigHelper.CompanyConfigurationId;
        }
    }
}