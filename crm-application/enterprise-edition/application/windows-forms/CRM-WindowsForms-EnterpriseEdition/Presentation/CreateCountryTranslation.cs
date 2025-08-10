using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CreateCountryTranslation : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public CreateCountryTranslation()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadDatabaseConnectionSettingsAsync();
            CreateCountryTranslationLoadCountryAsync();
        }

        private void InitializeCustomComponents()
        {
            createCountryTranslationCountryComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void CreateCountryTranslationLoadCountryAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Country";

            try
            {
                string storedProcedureName = "[dbo].[spGetAllCountry]";                
                DataTable? countryData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject);

                var countryList = countryData.AsEnumerable()
                    .Select(row => new
                    {
                        CountryId = row.Field<Guid>("Country Id"),
                        DisplayText = $"{row.Field<string>("ISO 3166-1 Alpha 2 Country Code")} - {row.Field<string>("Country English Name")}"
                    })
                    .OrderBy(item => item.DisplayText)
                    .ToList();
                createCountryTranslationCountryComboBox.DataSource = countryList;
                createCountryTranslationCountryComboBox.DisplayMember = "DisplayText";
                createCountryTranslationCountryComboBox.ValueMember = "CountryId";
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void createCountryTranslationSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createCountryTranslationActiveStatusCheckbox.Checked;
            string bcp47LanguageTagCode = createCountryTranslationBCP47LanguageTagCodeTextbox.Text.TrimEnd().ToLower();
            Guid countryId = (Guid)createCountryTranslationCountryComboBox.SelectedValue;
            string localisedCountryName = createCountryTranslationLocalisedCountryNameTextbox.Text.TrimEnd();

            string dataSubject = "Country Translation";

            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
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
                    Name = "BCP47LanguageTagCode",
                    Value = bcp47LanguageTagCode,
                    MaxLength = 5,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CountryId",
                    Value = countryId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "LocalisedCountryName",
                    Value = localisedCountryName,
                    MaxLength = 100,
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
                
                string storedProcedureName = "[dbo].[spCreateCountryTranslation]";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, operationType);
                this.Close();
            }
        }
    }
}