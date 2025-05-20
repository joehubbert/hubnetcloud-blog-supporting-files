using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class SalesSubRegionDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _salesSubRegionId;
        private Guid? salesSubRegionDetailSalesRegionIdOriginalValue;
        private string salesSubRegionDetailSalesSubRegionOriginalValue;
        private bool salesSubRegionDetailActiveStatusOriginalValue;

        public SalesSubRegionDetail(Guid salesSubRegionId)
        {
            InitializeComponent();
            InitializeCustomComponents();
            _salesSubRegionId = salesSubRegionId;
            salesSubRegionDetailToggleEditModeButton.Click += salesSubRegionDetailToggleEditModeButton_Click;
            LoadDatabaseConnectionSettingsAsync();
        }

        private void InitializeCustomComponents()
        {
            salesSubRegionDetailSalesRegionComboBox.DropDown += new EventHandler(SalesSubRegionDetailSalesRegionComboBox_DropDown);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task SalesSubRegionDetailLoadSalesRegionAsync(Guid salesRegionId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                string storedProcedureName = "[dbo].[spGetAllSalesRegion]";
                string dataSubject = "Sales Region";
                DataTable? salesRegionData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var salesRegionList = salesRegionData.AsEnumerable()
                    .Select(row => new
                    {
                        SalesRegionId = row.Field<Guid>("Sales Region Id"),
                        SalesRegion = row.Field<string>("Sales Region")
                    })
                    .OrderBy(item => item.SalesRegion)
                    .ToList();
                salesSubRegionDetailSalesRegionComboBox.DataSource = salesRegionList;
                salesSubRegionDetailSalesRegionComboBox.DisplayMember = "SalesRegion";
                salesSubRegionDetailSalesRegionComboBox.ValueMember = "SalesRegionId";
                salesSubRegionDetailSalesRegionComboBox.SelectedValue = salesRegionId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Sales Region data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SalesSubRegionDetailSalesRegionComboBox_DropDown(object sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void ViewSalesSubRegionDetailSalesSubRegionInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string storedProcedureName = "[dbo].[spGetSalesSubRegion]";
            string dataSubject = "Sales Sub Region";

            var parameters = new[]
            {
                    new Parameter
                    {
                        ParameterName = "@salesSubRegionId",
                        ParameterValue = _salesSubRegionId
                    }
            };

            try
            {
                DataTable? salesSubRegionDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (salesSubRegionDataTable != null)
                {
                    DataRow salesSubRegionDataRow = salesSubRegionDataTable.Rows[0];
                    salesSubRegionDetailSalesSubRegionIdTextbox.Text = salesSubRegionDataRow["Sales Sub Region Id"].ToString();
                    salesSubRegionDetailSalesSubRegionTextbox.Text = salesSubRegionDataRow["Sales Sub Region"].ToString();
                    await SalesSubRegionDetailLoadSalesRegionAsync((Guid)salesSubRegionDataRow["Sales Region Id"]);
                    salesSubRegionDetailCreatedByTextbox.Text = salesSubRegionDataRow["Created By"].ToString();
                    salesSubRegionDetailCreatedTimestampTextbox.Text = salesSubRegionDataRow["Created Timestamp"].ToString();
                    salesSubRegionDetailLastUpdatedByTextbox.Text = salesSubRegionDataRow["Modified By"].ToString();
                    salesSubRegionDetailLastUpdatedTimestampTextbox.Text = salesSubRegionDataRow["Modified Timestamp"].ToString();
                    salesSubRegionDetailActiveStatusCheckbox.Checked = (bool)salesSubRegionDataRow["Active Status"];

                    salesSubRegionDetailSalesRegionIdOriginalValue = (Guid)salesSubRegionDataRow["Sales Region Id"];
                    salesSubRegionDetailSalesSubRegionOriginalValue = salesSubRegionDataRow["Sales Sub Region"].ToString();
                    salesSubRegionDetailActiveStatusOriginalValue = (bool)salesSubRegionDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Sales Sub Region.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Sales Sub Region details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void salesSubRegionDetailUpdateSalesSubRegionButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = salesSubRegionDetailActiveStatusCheckbox.Checked;
            Guid salesRegionId = (Guid)salesSubRegionDetailSalesRegionComboBox.SelectedValue;
            string salesSubRegion = salesSubRegionDetailSalesSubRegionTextbox.Text.TrimEnd();

            string dataSubject = "Sales Sub Region";

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
                    Name = "SalesRegionId",
                    Value = salesRegionId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SalesSubRegion",
                    Value = salesSubRegion,
                    MaxLength = 50
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
                        OriginalValue = salesSubRegionDetailActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Sales Region Id",
                        VariableType = "Guid",
                        OriginalValue = salesSubRegionDetailSalesRegionIdOriginalValue,
                        NewValue = salesRegionId
                    },
                    new ChangeDetail
                    {
                        VariableName = "Sales Sub Region",
                        VariableType = "string",
                        OriginalValue = salesSubRegionDetailSalesSubRegionOriginalValue,
                        NewValue = salesSubRegion
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
                            ParameterName = "@salesSubRegion",
                            ParameterValue = salesSubRegion
                        },
                        new Parameter
                        {
                            ParameterName = "@salesSubRegionId",
                            ParameterValue = _salesSubRegionId
                        },
                        new Parameter
                        {
                            ParameterName = "@salesRegionId",
                            ParameterValue = salesRegionId
                        }
                    };
                    string storedProcedureName = "[dbo].[spUpdateSalesSubRegion]";
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
            ViewSalesSubRegionDetailSalesSubRegionInformation_Load(this, EventArgs.Empty);
        }

        private void salesSubRegionDetailToggleEditModeButton_Click(object sender, EventArgs e)
        {
            salesSubRegionDetailSalesSubRegionTextbox.Enabled = !salesSubRegionDetailSalesSubRegionTextbox.Enabled;
            salesSubRegionDetailSalesRegionComboBox.Enabled = !salesSubRegionDetailSalesRegionComboBox.Enabled;
            salesSubRegionDetailActiveStatusCheckbox.Enabled = !salesSubRegionDetailActiveStatusCheckbox.Enabled;
            salesSubRegionDetailUpdateSalesSubRegionButton.Enabled = !salesSubRegionDetailUpdateSalesSubRegionButton.Enabled;
        }
    }
}