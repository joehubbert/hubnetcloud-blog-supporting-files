using CRM_WindowsForms_EnterpriseEdition.Helpers;
using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Services;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CountryDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _countryId;
        private bool countryDetailActiveStatusOriginalValue;
        private string countryDetailCountryEnglishNameOriginalValue;
        private string countryDetailISO31661A2CountryCodeOriginalValue;
        private readonly string dataSubject = "Country";

        public CountryDetail(Guid countryId)
        {
            InitializeComponent();
            InitializeEventHandlers();
            _countryId = countryId;
            LoadDatabaseConnectionSettingsAsync();
        }

		protected override async void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			await LoadDatabaseConnectionSettingsAsync();
			CountryDetailCountryInformation_Load(this, EventArgs.Empty);
		}

		private void InitializeEventHandlers()
        {
            
        }

		private async void CountryDetailCountryInformation_Load(object sender, EventArgs e)
		{
			if (_databaseConnectionSettings == null)
			{
				ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
				return;
			}

			string storedProcedureName = "spGetCountry";

			var parameters = new[]
			{
				new StoredProcedureParameter
				{
					ParameterName = "countryId",
					ParameterValue = _countryId
				}
			};

			try
			{
				DataTable? countryDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject);

				if (countryDataTable != null)
				{
					DataRow countryDataRow = countryDataTable.Rows[0];
					countryDetailCountryIdTextBox.Text = countryDataRow["Country Id"].ToString();
					countryDetailISO31661A2CountryCodeMaskedTextBox.Text = countryDataRow["ISO 3166-1 Alpha 2 Country Code"].ToString();
					countryDetailCountryEnglishNameTextBox.Text = countryDataRow["Country English Name"].ToString();
					countryDetailCreatedByTextBox.Text = countryDataRow["Created By"].ToString();
					countryDetailCreatedTimestampTextBox.Text = countryDataRow["Created Timestamp UTC"].ToString();
					countryDetailLastUpdatedByTextBox.Text = countryDataRow["Modified By"].ToString();
					countryDetailLastUpdatedTimestampTextBox.Text = countryDataRow["Modified Timestamp UTC"].ToString();
					countryDetailActiveStatusCheckBox.Checked = (bool)countryDataRow["Active Status"];

					countryDetailActiveStatusOriginalValue = (bool)countryDataRow["Active Status"];
					countryDetailCountryEnglishNameOriginalValue = countryDataRow["Country English Name"].ToString();
					countryDetailISO31661A2CountryCodeOriginalValue = countryDataRow["ISO 3166-1 Alpha 2 Country Code"].ToString();

					this.Text += $" ({countryDetailCountryEnglishNameOriginalValue} - {countryDetailISO31661A2CountryCodeOriginalValue})";
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

		private void countryDetailToggleEditModeButton_Click(object? sender, EventArgs e)
		{
			countryDetailISO31661A2CountryCodeMaskedTextBox.ReadOnly = !countryDetailISO31661A2CountryCodeMaskedTextBox.ReadOnly;
			countryDetailCountryEnglishNameTextBox.ReadOnly = !countryDetailCountryEnglishNameTextBox.ReadOnly;
			countryDetailActiveStatusCheckBox.Enabled = !countryDetailActiveStatusCheckBox.Enabled;
			countryDetailUpdateCountryButton.Enabled = !countryDetailUpdateCountryButton.Enabled;
		}

		private async void countryDetailUpdateCountryButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = countryDetailActiveStatusCheckBox.Checked;   
            string countryEnglishName = TextBoxCleanerHelper.GetTrimmedText(countryDetailCountryEnglishNameTextBox);
            string iso31661A2CountryCode = TextBoxCleanerHelper.GetTrimmedText(countryDetailISO31661A2CountryCodeMaskedTextBox).ToUpper();

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
                    Name = "Country English Name",
                    Value = countryEnglishName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ISO 3166-1 Alpha 2 Country Code",
                    Value = iso31661A2CountryCode,
                    MaxLength = 2,
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
                        VariableName = "ISO 3166-1 Alpha 2 Country Code",
                        VariableType = "string",
                        OriginalValue = countryDetailISO31661A2CountryCodeOriginalValue,
                        NewValue = iso31661A2CountryCode
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = UpdateConfirmationService.ConfirmChanges(changesList, dataSubject);

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
                            ParameterName = "countryEnglishName",
                            ParameterValue = countryEnglishName
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "countryId",
                            ParameterValue = _countryId
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "iso31661A2CountryCode",
                            ParameterValue = iso31661A2CountryCode
                        }
                    };
                    string storedProcedureName = "spUpdateCountry";
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
    }
}