using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CountryTranslationDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _countryTranslationId;
        private bool? countryTranslationDetailActiveStatusOriginalValue;
        private string? countryTranslationDetailBCP47LanguageTagCodeOriginalValue;
        private Guid? countryTranslationDetailCountryIdOriginalValue;
        private string? countryTranslationDetailLocalisedCountryNameOriginalValue;

        public CountryTranslationDetail(Guid countryTranslationId)
        {
            InitializeComponent();
            InitializeCustomComponents();
            _countryTranslationId = countryTranslationId;
            countryTranslationDetailToggleEditModeButton.Click += new EventHandler(countryTranslationDetailToggleEditModeButton_Click);
            LoadDatabaseConnectionSettingsAsync();
        }

        private void InitializeCustomComponents()
        {
            countryTranslationDetailCountryComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task CountryTranslationDetailLoadCountryAsync(Guid countryId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Country";

            try
            {
                string storedProcedureName = "[dbo].[spGetAllCountry]";               
                DataTable? countryData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var countryList = countryData.AsEnumerable()
                    .Select(row => new
                    {
                        CountryId = row.Field<Guid>("Country Id"),
                        DisplayText = $"{row.Field<string>("ISO 3166-1 Alpha 2 Country Code")} - {row.Field<string>("Country English Name")}"
                    })
                    .OrderBy(item => item.DisplayText)
                    .ToList();
                countryTranslationDetailCountryComboBox.DataSource = countryList;
                countryTranslationDetailCountryComboBox.DisplayMember = "DisplayText";
                countryTranslationDetailCountryComboBox.ValueMember = "CountryId";
                countryTranslationDetailCountryComboBox.SelectedValue = countryId;
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

        private async void CountryTranslationDetailCountryTranslationInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.ConnectionSettingsNotLoaded");
                return;
            }

            string storedProcedureName = "[dbo].[spGetCountryTranslation]";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@countryTranslationId",
                    ParameterValue = _countryTranslationId
                }
            };

            string dataSubject = "Country Translation";

            try
            {
                DataTable? countryDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (countryDataTable != null)
                {
                    DataRow countryDataRow = countryDataTable.Rows[0];
                    countryTranslationDetailCountryTranslationIdTextbox.Text = countryDataRow["Country Translation Id"].ToString();
                    Guid countryId = (Guid)countryDataRow["Country Id"];
                    await CountryTranslationDetailLoadCountryAsync(countryId);
                    countryTranslationDetailBCP47LanguageTagCodeTextbox.Text = countryDataRow["BCP 47 Language Tag Code"].ToString();
                    countryTranslationDetailLocalisedCountryNameTextbox.Text = countryDataRow["Localised Country Name"].ToString();
                    countryTranslationDetailCreatedByTextbox.Text = countryDataRow["Created By"].ToString();
                    countryTranslationDetailCreatedTimestampTextbox.Text = countryDataRow["Created Timestamp UTC"].ToString();
                    countryTranslationDetailLastUpdatedByTextbox.Text = countryDataRow["Modified By"].ToString();
                    countryTranslationDetailLastUpdatedTimestampTextbox.Text = countryDataRow["Modified Timestamp UTC"].ToString();
                    countryTranslationDetailActiveStatusCheckbox.Checked = (bool)countryDataRow["Active Status"];

                    countryTranslationDetailActiveStatusOriginalValue = (bool)countryDataRow["Active Status"];
                    countryTranslationDetailBCP47LanguageTagCodeOriginalValue = countryDataRow["BCP 47 Language Tag Code"].ToString();
                    countryTranslationDetailCountryIdOriginalValue = (Guid)countryDataRow["Country Id"];
                    countryTranslationDetailLocalisedCountryNameOriginalValue = countryDataRow["Localised Country Name"].ToString();

                    this.Text += $" ({countryTranslationDetailLocalisedCountryNameOriginalValue})";
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

        private async void countryTranslationDetailUpdateCountryTranslationButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = countryTranslationDetailActiveStatusCheckbox.Checked;
            string bcp47LanguageTagCode = countryTranslationDetailBCP47LanguageTagCodeTextbox.Text.TrimEnd().ToLower();
            Guid countryId = Guid.Parse(countryTranslationDetailCountryComboBox.SelectedValue.ToString());
            string localisedCountryName = countryTranslationDetailLocalisedCountryNameTextbox.Text.TrimEnd();

            string dataSubject = "Country Translation";

            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.ConnectionSettingsNotLoaded");
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
                var changesList = new List<ChangeDetail>
                {
                    new ChangeDetail
                    {
                        VariableName = "Active Status",
                        VariableType = "bool",
                        OriginalValue = countryTranslationDetailActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "BCP47 Language Tag Code",
                        VariableType = "string",
                        OriginalValue = countryTranslationDetailBCP47LanguageTagCodeOriginalValue,
                        NewValue = bcp47LanguageTagCode
                    },
                    new ChangeDetail
                    {
                        VariableName = "Country Id",
                        VariableType = "Guid",
                        OriginalValue = countryTranslationDetailCountryIdOriginalValue,
                        NewValue = countryId
                    },
                    new ChangeDetail
                    {
                        VariableName = "Localised Country Name",
                        VariableType = "string",
                        OriginalValue = countryTranslationDetailLocalisedCountryNameOriginalValue,
                        NewValue = localisedCountryName
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
                            ParameterName = "@bcp47LanguageTagCode",
                            ParameterValue = bcp47LanguageTagCode
                        },
                        new Parameter
                        {
                            ParameterName = "@countryId",
                            ParameterValue = countryId
                        },
                        new Parameter
                        {
                            ParameterName = "@countryTranslationId",
                            ParameterValue = _countryTranslationId
                        },
                        new Parameter
                        {
                            ParameterName = "@localisedCountryName",
                            ParameterValue = localisedCountryName
                        }
                    };
                    string storedProcedureName = "[dbo].[spUpdateCountryTranslation]";
                    string operationType = "update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                    this.Close();
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.UpdateCancelled");
                    this.Close();
                }
            }
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            CountryTranslationDetailCountryTranslationInformation_Load(this, EventArgs.Empty);
        }

        private void countryTranslationDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            countryTranslationDetailCountryComboBox.Enabled = !countryTranslationDetailCountryComboBox.Enabled;
            countryTranslationDetailBCP47LanguageTagCodeTextbox.ReadOnly = !countryTranslationDetailBCP47LanguageTagCodeTextbox.ReadOnly;
            countryTranslationDetailLocalisedCountryNameTextbox.ReadOnly = !countryTranslationDetailLocalisedCountryNameTextbox.ReadOnly;
            countryTranslationDetailActiveStatusCheckbox.Enabled = !countryTranslationDetailActiveStatusCheckbox.Enabled;
            countryTranslationDetailUpdateCountryTranslationButton.Enabled = !countryTranslationDetailUpdateCountryTranslationButton.Enabled;
        }
    }
}