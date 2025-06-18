using CRM_WindowsForms.Interface;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class TaxProfileDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Tax Profile";
        private readonly Guid _taxProfileId;
        private bool? taxProfileDetailActiveStatusOriginalValue;
        private string? taxProfileDetailTaxProfileOriginalValue;
        private decimal? taxProfileDetailTaxRateOriginalValue;

        public TaxProfileDetail(Guid taxProfileId)
        {
            InitializeComponent();
            _taxProfileId = taxProfileId;
            taxProfileDetailToggleEditModeButton.Click += taxProfileDetailToggleEditModeButton_Click;
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void ViewTaxProfileDetailTaxProfileInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string storedProcedureName = "[dbo].[spGetTaxProfile]";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@taxProfileId",
                    ParameterValue = _taxProfileId
                }
            };

            try
            {
                DataTable? taxProfileDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (taxProfileDataTable != null)
                {
                    DataRow taxProfileDataRow = taxProfileDataTable.Rows[0];
                    string taxRatePartA;
                    string taxRatePartB;

                    SplitDecimal.SplitDecimalUsingDelimiter((decimal)taxProfileDataRow["Tax Rate"], out taxRatePartA, out taxRatePartB);

                    taxProfileDetailTaxProfileIdTextbox.Text = taxProfileDataRow["Tax Profile Id"].ToString();
                    taxProfileDetailTaxProfileTextbox.Text = taxProfileDataRow["Tax Profile"].ToString();
                    taxProfileDetailTaxRateTextboxA.Text = taxRatePartA;
                    taxProfileDetailTaxRateTextboxB.Text = taxRatePartB;
                    taxProfileDetailCreatedByTextbox.Text = taxProfileDataRow["Created By"].ToString();
                    taxProfileDetailCreatedTimestampTextbox.Text = taxProfileDataRow["Created Timestamp UTC"].ToString();
                    taxProfileDetailLastUpdatedByTextbox.Text = taxProfileDataRow["Modified By"].ToString();
                    taxProfileDetailLastUpdatedTimestampTextbox.Text = taxProfileDataRow["Modified Timestamp UTC"].ToString();
                    taxProfileDetailActiveStatusCheckbox.Checked = (bool)taxProfileDataRow["Active Status"];

                    taxProfileDetailTaxProfileOriginalValue = taxProfileDataRow["Tax Profile"].ToString();
                    taxProfileDetailTaxRateOriginalValue = (decimal)taxProfileDataRow["Tax Rate"];
                    taxProfileDetailActiveStatusOriginalValue = (bool)taxProfileDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Tax Profile.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Tax Profile details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void taxProfileDetailUpdateTaxProfileButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = taxProfileDetailActiveStatusCheckbox.Checked;
            string taxProfile = taxProfileDetailTaxProfileTextbox.Text.TrimEnd();
            decimal taxRate = decimal.Parse(taxProfileDetailTaxRateTextboxA.Text.TrimEnd()) + (decimal.Parse(taxProfileDetailTaxRateTextboxB.Text.TrimEnd()) / 100);

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
                    Name = "TaxProfile",
                    Value = taxProfile,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "TaxRate",
                    Value = taxRate,
                    ValueType = typeof(decimal)
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
                        VariableType = "string",
                        OriginalValue = taxProfileDetailActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Tax Profile",
                        VariableType = "string",
                        OriginalValue = taxProfileDetailTaxProfileOriginalValue,
                        NewValue = taxProfile
                    },
                    new ChangeDetail
                    {
                        VariableName = "Tax Rate",
                        VariableType = "string",
                        OriginalValue = taxProfileDetailTaxRateOriginalValue,
                        NewValue = taxRate
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
                            ParameterName = "@taxProfile",
                            ParameterValue = taxProfile
                        },
                        new Parameter
                        {
                            ParameterName = "@taxProfileId",
                            ParameterValue = _taxProfileId
                        },
                        new Parameter
                        {
                            ParameterName = "@taxRate",
                            ParameterValue = taxRate
                        }
                    };
                    string storedProcedureName = "[dbo].[spUpdateTaxProfile]";
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
            ViewTaxProfileDetailTaxProfileInformation_Load(this, EventArgs.Empty);
        }

        private void taxProfileDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            taxProfileDetailTaxProfileTextbox.ReadOnly = !taxProfileDetailTaxProfileTextbox.ReadOnly;
            taxProfileDetailTaxRateTextboxA.ReadOnly = !taxProfileDetailTaxRateTextboxA.ReadOnly;
            taxProfileDetailTaxRateTextboxB.ReadOnly = !taxProfileDetailTaxRateTextboxB.ReadOnly;
            taxProfileDetailActiveStatusCheckbox.Enabled = !taxProfileDetailActiveStatusCheckbox.Enabled;
            taxProfileDetailUpdateTaxProfileButton.Enabled = !taxProfileDetailUpdateTaxProfileButton.Enabled;
        }
    }
}