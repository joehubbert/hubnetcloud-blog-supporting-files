using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CreateCountryTranslation : Form
    {
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public CreateCountryTranslation()
        {
            InitializeComponent();
            InitializeEventHandlers();
            LoadDatabaseConnectionSettingsAsync();
            LoadCountryAsync();
        }

        private void InitializeEventHandlers()
        {
            createCountryTranslationCountryComboBox.DropDown += AdjustComboBoxWidth_DropDown;
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void LoadCountryAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCountryTranslationCountryComboBox, "spGetAllCountry");
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDownHelper.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void createCountryTranslationSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createCountryTranslationActiveStatusCheckbox.Checked;
            string bcp47LanguageTagCode = createCountryTranslationBCP47LanguageTagCodeTextBox.Text.TrimEnd().ToLower();
            Guid countryId = (Guid)createCountryTranslationCountryComboBox.SelectedValue;
            string localisedCountryName = createCountryTranslationLocalisedCountryNameTextBox.Text.TrimEnd();

            string dataSubject = "Country Translation";

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
                    Name = "BCP47 Language Tag Code",
                    Value = bcp47LanguageTagCode,
                    MaxLength = 5,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Country Id",
                    Value = countryId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Localised Country Name",
                    Value = localisedCountryName,
                    MaxLength = 100,
                    ValueType = typeof(string)
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
                    new Parameter
                    {
                        ParameterName = "activeStatus",
                        ParameterValue = activeStatus
                    },
                    new Parameter
                    {
                        ParameterName = "bcp47LanguageTagCode",
                        ParameterValue = bcp47LanguageTagCode
                    },
                    new Parameter
                    {
                        ParameterName = "countryId",
                        ParameterValue = countryId
                    },
                    new Parameter
                    {
                        ParameterName = "localisedCountryName",
                        ParameterValue = localisedCountryName
                    }
                };
                
                string storedProcedureName = "spCreateCountryTranslation";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, operationType);
                this.Close();
            }
        }
    }
}