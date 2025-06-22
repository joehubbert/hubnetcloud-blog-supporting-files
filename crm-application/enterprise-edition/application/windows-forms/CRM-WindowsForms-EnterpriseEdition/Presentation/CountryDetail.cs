using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CountryDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _countryId;
        private bool? countryDetailActiveStatusOriginalValue;
        private string? countryDetailCountryEnglishNameOriginalValue;
        private string? countryDetailISO31661A2CountryCodeOriginalValue;
        private readonly string dataSubject = "Country";

        public CountryDetail(Guid countryId)
        {
            InitializeComponent();
            _countryId = countryId;
            countryDetailToggleEditModeButton.Click += countryDetailToggleEditModeButton_Click;
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void ViewCountryDetailCountryInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string storedProcedureName = "[dbo].[spGetCountry]";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@countryId",
                    ParameterValue = _countryId
                }
            };

            try
            {
                DataTable? countryDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (countryDataTable != null)
                {
                    DataRow countryDataRow = countryDataTable.Rows[0];
                    countryDetailCountryIdTextbox.Text = countryDataRow["Country Id"].ToString();
                    countryDetailISO31661A2CountryCodeTextbox.Text = countryDataRow["ISO 3166-1 Alpha 2 Country Code"].ToString();
                    countryDetailCountryEnglishNameTextbox.Text = countryDataRow["Country English Name"].ToString();
                    countryDetailCreatedByTextbox.Text = countryDataRow["Created By"].ToString();
                    countryDetailCreatedTimestampTextbox.Text = countryDataRow["Created Timestamp UTC"].ToString();
                    countryDetailLastUpdatedByTextbox.Text = countryDataRow["Modified By"].ToString();
                    countryDetailLastUpdatedTimestampTextbox.Text = countryDataRow["Modified Timestamp UTC"].ToString();
                    countryDetailActiveStatusCheckbox.Checked = (bool)countryDataRow["Active Status"];

                    countryDetailActiveStatusOriginalValue = (bool)countryDataRow["Active Status"];
                    countryDetailCountryEnglishNameOriginalValue = countryDataRow["Country English Name"].ToString();
                    countryDetailISO31661A2CountryCodeOriginalValue = countryDataRow["ISO 3166-1 Alpha 2 Country Code"].ToString();
                }
                else
                {
                    MessageBox.Show("No data found for the specified Country.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Country details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void countryDetailUpdateCountryButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = countryDetailActiveStatusCheckbox.Checked;   
            string countryEnglishName = countryDetailCountryEnglishNameTextbox.Text.TrimEnd();
            string iso31661A2CountryCode = countryDetailISO31661A2CountryCodeTextbox.Text.TrimEnd().ToUpper();

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
                    Name = "CountryEnglishName",
                    Value = countryEnglishName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ISO31661A2CountryCode",
                    Value = iso31661A2CountryCode,
                    MaxLength = 2,
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
                        OriginalValue = countryDetailActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Country English Name",
                        VariableType = "string",
                        OriginalValue = countryDetailCountryEnglishNameOriginalValue,
                        NewValue = countryEnglishName
                    },
                    new ChangeDetail
                    {
                        VariableName = "ISO 3166-1 Alpha 2 CountryCode",
                        VariableType = "string",
                        OriginalValue = countryDetailISO31661A2CountryCodeOriginalValue,
                        NewValue = iso31661A2CountryCode
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
                            ParameterName = "@countryEnglishName",
                            ParameterValue = countryEnglishName
                        },
                        new Parameter
                        {
                            ParameterName = "@countryId",
                            ParameterValue = _countryId
                        },
                        new Parameter
                        {
                            ParameterName = "@iso31661A2CountryCode",
                            ParameterValue = iso31661A2CountryCode
                        }
                    };
                    string storedProcedureName = "[dbo].[spUpdateCountry]";
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
            ViewCountryDetailCountryInformation_Load(this, EventArgs.Empty);
        }

        private void countryDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            countryDetailISO31661A2CountryCodeTextbox.ReadOnly = !countryDetailISO31661A2CountryCodeTextbox.ReadOnly;
            countryDetailCountryEnglishNameTextbox.ReadOnly = !countryDetailCountryEnglishNameTextbox.ReadOnly;
            countryDetailActiveStatusCheckbox.Enabled = !countryDetailActiveStatusCheckbox.Enabled;
            countryDetailUpdateCountryButton.Enabled = !countryDetailUpdateCountryButton.Enabled;
        }
    }
}