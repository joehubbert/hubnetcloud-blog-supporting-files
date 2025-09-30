using CRM.Helpers;
using CRM.Interface;
using CRM.Model;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.MasterDataManagement
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
				DataTable? countryDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(dataSubject, _databaseConnectionSettings, storedProcedureName, parameters);

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
                    Name = "Country English Name",
                    Value = countryEnglishName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ISO 3166-1 Alpha 2 Country Code",
                    Value = iso31661A2CountryCode,
                    MaxLength = 2,
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
                var changesList = new List<ChangeDetail>
                {
                    new ChangeDetail
                    {
                        VariableName = "Active Status",
                        OriginalValue = countryDetailActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Country English Name",
                        OriginalValue = countryDetailCountryEnglishNameOriginalValue,
                        NewValue = countryEnglishName
                    },
                    new ChangeDetail
                    {
                        VariableName = "ISO 3166-1 Alpha 2 Country Code",
                        OriginalValue = countryDetailISO31661A2CountryCodeOriginalValue,
                        NewValue = iso31661A2CountryCode
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