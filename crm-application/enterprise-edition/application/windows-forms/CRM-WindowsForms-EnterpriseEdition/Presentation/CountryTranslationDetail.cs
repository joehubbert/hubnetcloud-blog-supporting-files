using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CountryTranslationDetail : Form
    {
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _countryTranslationId;
        private bool? countryTranslationDetailActiveStatusOriginalValue;
        private string? countryTranslationDetailBCP47LanguageTagCodeOriginalValue;
        private Guid? countryTranslationDetailCountryIdOriginalValue;
        private string? countryTranslationDetailLocalisedCountryNameOriginalValue;

        public CountryTranslationDetail(Guid countryTranslationId)
        {
            InitializeComponent();
            InitializeEventHandlers();
            _countryTranslationId = countryTranslationId;
            LoadDatabaseConnectionSettingsAsync();
        }

        private void InitializeEventHandlers()
        {
            countryTranslationDetailCountryComboBox.DropDown += AdjustComboBoxWidth_DropDown;
            countryTranslationDetailToggleEditModeButton.Click += countryTranslationDetailToggleEditModeButton_Click;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task LoadCountryAsync(Guid countryId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(countryTranslationDetailCountryComboBox, "spGetAllCountry", null, true, "Country Id", countryId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDownHelper.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void CountryTranslationDetailCountryTranslationInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            string storedProcedureName = "spGetCountryTranslation";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "countryTranslationId",
                    ParameterValue = _countryTranslationId
                }
            };

            string dataSubject = "Country Translation";

            try
            {
                DataTable? countryDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject);

                if (countryDataTable != null)
                {
                    DataRow countryDataRow = countryDataTable.Rows[0];
                    countryTranslationDetailCountryTranslationIdTextBox.Text = countryDataRow["Country Translation Id"].ToString();
                    Guid countryId = (Guid)countryDataRow["Country Id"];
                    await LoadCountryAsync(countryId);
                    countryTranslationDetailBCP47LanguageTagCodeTextBox.Text = countryDataRow["BCP 47 Language Tag Code"].ToString();
                    countryTranslationDetailLocalisedCountryNameTextBox.Text = countryDataRow["Localised Country Name"].ToString();
                    countryTranslationDetailCreatedByTextBox.Text = countryDataRow["Created By"].ToString();
                    countryTranslationDetailCreatedTimestampTextBox.Text = countryDataRow["Created Timestamp UTC"].ToString();
                    countryTranslationDetailLastUpdatedByTextBox.Text = countryDataRow["Modified By"].ToString();
                    countryTranslationDetailLastUpdatedTimestampTextBox.Text = countryDataRow["Modified Timestamp UTC"].ToString();
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
            string bcp47LanguageTagCode = countryTranslationDetailBCP47LanguageTagCodeTextBox.Text.TrimEnd().ToLower();
            Guid countryId = Guid.Parse(countryTranslationDetailCountryComboBox.SelectedValue.ToString());
            string localisedCountryName = countryTranslationDetailLocalisedCountryNameTextBox.Text.TrimEnd();

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

                bool confirmed = UpdateConfirmationService.ConfirmChanges(changesList, dataSubject);

                if (confirmed)
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
                            ParameterName = "countryTranslationId",
                            ParameterValue = _countryTranslationId
                        },
                        new Parameter
                        {
                            ParameterName = "localisedCountryName",
                            ParameterValue = localisedCountryName
                        }
                    };
                    string storedProcedureName = "spUpdateCountryTranslation";
                    string operationType = "update";

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

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            CountryTranslationDetailCountryTranslationInformation_Load(this, EventArgs.Empty);
        }

        private void countryTranslationDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            countryTranslationDetailCountryComboBox.Enabled = !countryTranslationDetailCountryComboBox.Enabled;
            countryTranslationDetailBCP47LanguageTagCodeTextBox.ReadOnly = !countryTranslationDetailBCP47LanguageTagCodeTextBox.ReadOnly;
            countryTranslationDetailLocalisedCountryNameTextBox.ReadOnly = !countryTranslationDetailLocalisedCountryNameTextBox.ReadOnly;
            countryTranslationDetailActiveStatusCheckbox.Enabled = !countryTranslationDetailActiveStatusCheckbox.Enabled;
            countryTranslationDetailUpdateCountryTranslationButton.Enabled = !countryTranslationDetailUpdateCountryTranslationButton.Enabled;
        }
    }
}