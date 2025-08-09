using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CreateMasterDataAdvanced : Form
    {
        private readonly string _functionTitle;
        private readonly string _moduleGroup;
        private readonly string applicationTitlePrefix = "CRM - Create ";
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private string dataParentSubjectFriendlyName;
        private string dataParentSubjectIdFriendlyName;
        private string dataParentSubjectIdName;
        private string dataParentSubjectName;
        private string dataParentSubjectGetStoredProcedureName;
        private string dataSubjectFriendlyName;
        private string dataSubjectName;
        private string dataSubjectCreateStoredProcedureName;
        private string dataSubjectCreateStoredProcedureParameterPrefix;
        private string dataSubjectCreateStoredProcedureParentDataSubjectParameterPrefix;
        private readonly string titleLabelPrefix = "Create ";

        public CreateMasterDataAdvanced(string functionTitle, string moduleGroup)
        {
            InitializeComponent();
            _functionTitle = functionTitle;
            LoadDatabaseConnectionSettingsAsync();
            _moduleGroup = moduleGroup;
            SetModuleTheme(_moduleGroup);
            SetParameters(_functionTitle);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void InitializeCustomComponents()
        {
            createMasterDataAdvancedDataParentSubjectComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
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
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.NotImplemented", moduleGroup);
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
                    dataSubjectCreateStoredProcedureName = "[dbo].[spCreateProductSubCategory]";
                    dataSubjectCreateStoredProcedureParameterPrefix = "productSubCategory";
                    dataSubjectCreateStoredProcedureParentDataSubjectParameterPrefix = "productCategory";
                    break;
                case "SalesSubRegion":
                    dataParentSubjectFriendlyName = "Sales Region";
                    dataParentSubjectIdFriendlyName = "Sales Region Id";
                    dataParentSubjectIdName = "SalesRegionId";
                    dataParentSubjectName = "SalesRegion";
                    dataParentSubjectGetStoredProcedureName = "[dbo].[spGetAllSalesRegion]";
                    dataSubjectFriendlyName = "Sales Sub Region";
                    dataSubjectCreateStoredProcedureName = "[dbo].[spCreateSalesSubRegion]";
                    dataSubjectCreateStoredProcedureParameterPrefix = "salesSubRegion";
                    dataSubjectCreateStoredProcedureParentDataSubjectParameterPrefix = "salesRegion";
                    break;
                default:
                    this.Text = functionTitle;
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.Function.NotImplemented", functionTitle);
                    break;
            }

            dataSubjectName = functionTitle;

            createMasterDataAdvancedTitleLabel.Text = $"{titleLabelPrefix}{dataSubjectFriendlyName}";
            createMasterDataAdvancedDataParentSubjectComboBoxLabel.Text = dataParentSubjectFriendlyName;
            createMasterDataAdvancedMasterDataTypeTextboxLabel.Text = dataSubjectFriendlyName;
            createMasterDataAdvancedActiveStatusCheckbox.Text = $"Active {dataSubjectFriendlyName}";
            this.Text = $"{applicationTitlePrefix}{dataSubjectFriendlyName}";
            InitializeCustomComponents();
            CreateMasterDataLoadDataParentSubjectAsync();
        }

        private async void CreateMasterDataLoadDataParentSubjectAsync()
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

                createMasterDataAdvancedDataParentSubjectComboBox.DataSource = dataList;
                createMasterDataAdvancedDataParentSubjectComboBox.DisplayMember = "Name";
                createMasterDataAdvancedDataParentSubjectComboBox.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataParentSubjectFriendlyName, ex.Message);
            }
        }

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void createMasterDataAdvancedSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createMasterDataAdvancedActiveStatusCheckbox.Checked;
            Guid dataParentSubjectValue = Guid.Parse(createMasterDataAdvancedDataParentSubjectComboBox.SelectedValue.ToString());
            string dataSubjectValue = createMasterDataAdvancedMasterDataTypeTextbox.Text.TrimEnd();

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
                    Name = dataParentSubjectIdName,
                    Value = dataParentSubjectValue,
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
                var parameters = new[]
                {
                    new Parameter
                    {
                        ParameterName = "@activeStatus",
                        ParameterValue = activeStatus
                    },
                    new Parameter
                    {
                        ParameterName = $"@{dataSubjectCreateStoredProcedureParentDataSubjectParameterPrefix}Id",
                        ParameterValue = dataParentSubjectValue
                    },
                    new Parameter
                    {
                        ParameterName = $"@{dataSubjectCreateStoredProcedureParameterPrefix}",
                        ParameterValue = dataSubjectValue
                    }
                };

                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(dataSubjectCreateStoredProcedureName, parameters, dataSubjectName, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                this.Close();
            }
        }
    }
}