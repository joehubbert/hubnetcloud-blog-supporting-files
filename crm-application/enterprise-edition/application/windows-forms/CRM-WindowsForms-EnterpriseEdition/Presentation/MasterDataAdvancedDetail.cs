using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class MasterDataAdvancedDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _dataSubjectId;
        private readonly string _functionTitle;
        private readonly string _moduleGroup;
        private readonly string applicationTitlePrefix = "CRM - ";
        private string dataParentSubjectFriendlyName;
        private string dataParentSubjectIdFriendlyName;
        private string dataParentSubjectIdName;
        private Guid dataParentSubjectOriginalValue;
        private string dataParentSubjectName;
        private string dataParentSubjectGetStoredProcedureName;
        private bool? dataSubjectActiveStatusOriginalValue;
        private string dataSubjectFriendlyName;
        private string dataSubjectGetStoredProcedureName;
        private string dataSubjectIdFriendlyName;
        private string dataSubjectIdName;
        private string dataSubjectName;
        private string? dataSubjectOriginalValue;
        private string dataSubjectUpdateStoredProcedureName;
        private string dataSubjectUpdateStoredProcedureParameterPrefix;
        private string dataSubjectUpdateStoredProcedureParentDataSubjectParameterPrefix;
        private readonly string titleLabelSuffix = " Detail";

        public MasterDataAdvancedDetail(Guid dataSubjectId, string functionTitle, string moduleGroup)
        {
            InitializeComponent();
            InitializeCustomComponents();
            _dataSubjectId = dataSubjectId;
            _functionTitle = functionTitle;
            _moduleGroup = moduleGroup;
            SetModuleTheme(_moduleGroup);
            masterDataAdvancedDetailToggleEditModeButton.Click += new EventHandler(masterDataAdvancedDetailToggleEditModeButton_Click);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void InitializeCustomComponents()
        {
            masterDataAdvancedDetailDataParentSubjectComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
        }

        private void SetModuleTheme(string moduleGroup)
        {
            switch (moduleGroup)
            {
                case "CompanyManagement":
                    this.BackColor = Color.LemonChiffon;
                    break;
                case "CustomerManagement":
                    this.BackColor = Color.LightGreen;
                    break;
                case "MarketingManagement":
                    this.BackColor = Color.NavajoWhite;
                    break;
                case "OrderManagement":
                    this.BackColor = Color.LightSalmon;
                    break;
                case "ProductManagement":
                    this.BackColor = Color.SkyBlue;
                    break;
                case "SupplierManagement":
                    this.BackColor = Color.MediumAquamarine;
                    break;
                default:
                    MessageBox.Show($"Unrecognised module group - {moduleGroup} passed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void SetParameters(string functionTitle)
        {
            switch (functionTitle)
            {
                case "ProductSubCategory":
                    dataParentSubjectFriendlyName = "Product Category";
                    dataParentSubjectIdFriendlyName = "Product Category Id";
                    dataParentSubjectIdName = "ProductCategoryId";
                    dataParentSubjectName = "ProductCategory";
                    dataParentSubjectGetStoredProcedureName = "[dbo].[spGetAllProductCategory]";
                    dataSubjectFriendlyName = "Product Sub Category";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetProductSubCategory]";
                    dataSubjectIdFriendlyName = "Product Sub Category Id";
                    dataSubjectIdName = "ProductSubCategoryId";
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateProductSubCategory]";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "productSubCategory";
                    dataSubjectUpdateStoredProcedureParentDataSubjectParameterPrefix = "productCategory";
                    break;
                case "SalesSubRegion":
                    dataParentSubjectFriendlyName = "Sales Region";
                    dataParentSubjectIdFriendlyName = "Sales Region Id";
                    dataParentSubjectIdName = "SalesRegionId";
                    dataParentSubjectName = "SalesRegion";
                    dataParentSubjectGetStoredProcedureName = "[dbo].[spGetAllSalesRegion]";
                    dataSubjectFriendlyName = "Sales Sub Region";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetSalesSubRegion]";
                    dataSubjectIdFriendlyName = "Sales Sub Region Id";
                    dataSubjectIdName = "SalesSubRegionId";
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateSalesSubRegion]";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "salesSubRegion";
                    dataSubjectUpdateStoredProcedureParentDataSubjectParameterPrefix = "salesRegion";
                    break;
                default:
                    this.Text = functionTitle;
                    MessageBox.Show($"{functionTitle} not onboarded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            dataSubjectName = functionTitle;

            masterDataAdvancedDetailTitleLabel.Text = $"{dataSubjectFriendlyName}{titleLabelSuffix}";
            masterDataAdvancedDetailDataSubjectIdTextboxLabel.Text = dataSubjectIdFriendlyName;
            masterDataAdvancedDetailDataParentSubjectComboBoxLabel.Text = dataParentSubjectFriendlyName;
            masterDataAdvancedDetailDataSubjectTextboxLabel.Text = dataSubjectFriendlyName;
            masterDataAdvancedDetailActiveStatusCheckbox.Text = $"Active {dataSubjectFriendlyName}";
            masterDataAdvancedDetailUpdateDataSubjectButton.Text = $"Update {dataSubjectFriendlyName}";
            this.Text = $"{applicationTitlePrefix}{dataSubjectFriendlyName}{titleLabelSuffix}";
        }

        private async Task MasterDataAdvancedDetailLoadDataParentSubjectAsync(Guid dataParentSubjectId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                DataTable? dataParentSubjectData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(
                    dataParentSubjectGetStoredProcedureName,
                    dataParentSubjectName,
                    _databaseConnectionSettings.DatabaseConnectionString);

                // Use consistent property names for binding
                var dataList = dataParentSubjectData.AsEnumerable()
                    .Select(row => new
                    {
                        Id = row.Field<Guid>(dataParentSubjectIdFriendlyName),
                        Name = row.Field<string>(dataParentSubjectFriendlyName)
                    })
                    .OrderBy(item => item.Name)
                    .ToList();

                masterDataAdvancedDetailDataParentSubjectComboBox.DataSource = dataList;
                masterDataAdvancedDetailDataParentSubjectComboBox.DisplayMember = "Name";
                masterDataAdvancedDetailDataParentSubjectComboBox.ValueMember = "Id";
                masterDataAdvancedDetailDataParentSubjectComboBox.SelectedValue = dataParentSubjectId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load {dataParentSubjectFriendlyName} data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void MasterDataAdvancedDetailMasterDataInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = $"@{dataSubjectUpdateStoredProcedureParameterPrefix}Id",
                    ParameterValue = _dataSubjectId
                }
            };

            try
            {
                DataTable? masterDataAdvancedDetailDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(
                    dataSubjectGetStoredProcedureName,
                    parameters.ToArray(),
                    dataSubjectName,
                    _databaseConnectionSettings.DatabaseConnectionString);

                if (masterDataAdvancedDetailDataTable != null)
                {
                    DataRow masterDataAdvancedDetailDataRow = masterDataAdvancedDetailDataTable.Rows[0];
                    masterDataAdvancedDetailDataSubjectIdTextbox.Text = masterDataAdvancedDetailDataRow[dataSubjectIdFriendlyName].ToString();
                    await MasterDataAdvancedDetailLoadDataParentSubjectAsync((Guid)masterDataAdvancedDetailDataRow[dataParentSubjectIdFriendlyName]);
                    masterDataAdvancedDetailDataSubjectTextbox.Text = masterDataAdvancedDetailDataRow[dataSubjectFriendlyName].ToString();
                    masterDataAdvancedDetailCreatedByTextbox.Text = masterDataAdvancedDetailDataRow["Created By"].ToString();
                    masterDataAdvancedDetailCreatedTimestampTextbox.Text = masterDataAdvancedDetailDataRow["Created Timestamp UTC"].ToString();
                    masterDataAdvancedDetailLastUpdatedByTextbox.Text = masterDataAdvancedDetailDataRow["Modified By"].ToString();
                    masterDataAdvancedDetailLastUpdatedTimestampTextbox.Text = masterDataAdvancedDetailDataRow["Modified Timestamp UTC"].ToString();
                    masterDataAdvancedDetailActiveStatusCheckbox.Checked = (bool)masterDataAdvancedDetailDataRow["Active Status"];

                    dataParentSubjectOriginalValue = (Guid)masterDataAdvancedDetailDataRow[dataParentSubjectIdFriendlyName];
                    dataSubjectOriginalValue = masterDataAdvancedDetailDataRow[dataSubjectFriendlyName].ToString();
                    dataSubjectActiveStatusOriginalValue = (bool)masterDataAdvancedDetailDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show($"No data found for the specified {dataSubjectFriendlyName}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load {dataSubjectFriendlyName} details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void masterDataAdvancedDetailUpdateDataSubjectButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = masterDataAdvancedDetailActiveStatusCheckbox.Checked;
            Guid dataParentSubjectIdValue = (Guid)masterDataAdvancedDetailDataParentSubjectComboBox.SelectedValue;
            string dataSubjectValue = masterDataAdvancedDetailDataSubjectTextbox.Text.TrimEnd();

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
                    Name = dataParentSubjectName,
                    Value = dataParentSubjectIdValue,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = dataSubjectName,
                    Value = dataSubjectValue,
                    MaxLength = 50,
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
                        OriginalValue = dataSubjectActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = dataParentSubjectFriendlyName,
                        VariableType = "Guid",
                        OriginalValue = dataParentSubjectOriginalValue,
                        NewValue = dataParentSubjectIdValue
                    },
                    new ChangeDetail
                    {
                        VariableName = dataSubjectFriendlyName,
                        VariableType = "string",
                        OriginalValue = dataSubjectOriginalValue,
                        NewValue = dataSubjectValue
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = UpdateConfirmation.ConfirmChanges(changesList, dataSubjectName);

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
                            ParameterName = $"@{dataSubjectUpdateStoredProcedureParentDataSubjectParameterPrefix}Id",
                            ParameterValue = dataParentSubjectIdValue
                        },
                        new Parameter
                        {
                            ParameterName = $"@{dataSubjectUpdateStoredProcedureParameterPrefix}",
                            ParameterValue = dataSubjectValue
                        }
                    };

                    string operationType = "update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(dataSubjectUpdateStoredProcedureName, parameters, dataSubjectName, _databaseConnectionSettings.DatabaseConnectionString, operationType);
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
            SetParameters(_functionTitle);
            MasterDataAdvancedDetailMasterDataInformation_Load(this, EventArgs.Empty);
        }

        private void masterDataAdvancedDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            masterDataAdvancedDetailDataParentSubjectComboBox.Enabled = !masterDataAdvancedDetailDataParentSubjectComboBox.Enabled;
            masterDataAdvancedDetailDataSubjectTextbox.ReadOnly = !masterDataAdvancedDetailDataSubjectTextbox.ReadOnly;
            masterDataAdvancedDetailActiveStatusCheckbox.Enabled = !masterDataAdvancedDetailActiveStatusCheckbox.Enabled;
            masterDataAdvancedDetailUpdateDataSubjectButton.Enabled = !masterDataAdvancedDetailUpdateDataSubjectButton.Enabled;
        }
    }
}