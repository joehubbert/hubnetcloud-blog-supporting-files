using CRM_WindowsForms.Interface;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class CreateMetadataAdvanced : Form
    {
        private readonly string _functionTitle;
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
        private readonly string titleLabelPrefix = "Create ";

        public CreateMetadataAdvanced(string functionTitle)
        {
            InitializeComponent();
            _functionTitle = functionTitle;
            LoadDatabaseConnectionSettingsAsync();
            _functionTitle = functionTitle;
            SetParameters(_functionTitle);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void InitializeCustomComponents()
        {
            createMetadataAdvancedDataParentSubjectComboBox.DropDown += new EventHandler(CreateMetadataAdvancedDataParentSubjectComboBox_DropDown);
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
                    break;
                case "SalesSubRegion":
                    dataParentSubjectFriendlyName = "Sales Region";
                    dataParentSubjectIdFriendlyName = "Sales Region Id";
                    dataParentSubjectIdName = "SalesRegionId";
                    dataParentSubjectName = "SalesRegion";
                    dataParentSubjectGetStoredProcedureName = "[dbo].[spGetAllSalesRegion]";
                    dataSubjectFriendlyName = "Sales Sub Region";
                    dataSubjectCreateStoredProcedureName = "[dbo].[spCreateSalesSubRegion]";
                    break;
            }

            dataSubjectName = functionTitle;

            createMetadataAdvancedTitleLabel.Text = $"{titleLabelPrefix}{dataSubjectFriendlyName}";
            createMetadataAdvancedDataParentSubjectComboBoxLabel.Text = dataParentSubjectFriendlyName;
            createMetadataAdvancedMetadataTypeTextboxLabel.Text = dataSubjectFriendlyName;
            createMetadataAdvancedActiveStatusCheckbox.Text = $"Active {dataSubjectFriendlyName}";
            this.Text = $"{applicationTitlePrefix}{dataSubjectFriendlyName}";
            InitializeCustomComponents();
            CreateMetadataLoadDataParentSubjectAsync();
        }

        private async void CreateMetadataLoadDataParentSubjectAsync()
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

                createMetadataAdvancedDataParentSubjectComboBox.DataSource = dataList;
                createMetadataAdvancedDataParentSubjectComboBox.DisplayMember = "Name";
                createMetadataAdvancedDataParentSubjectComboBox.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load {dataParentSubjectFriendlyName} data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateMetadataAdvancedDataParentSubjectComboBox_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void createMetadataAdvancedSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createMetadataAdvancedActiveStatusCheckbox.Checked;
            Guid dataParentSubjectValue = Guid.Parse(createMetadataAdvancedDataParentSubjectComboBox.SelectedValue.ToString());
            string dataSubjectValue = createMetadataAdvancedMetadataTypeTextbox.Text.TrimEnd();

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
                    }
                };

                switch (_functionTitle)
                {
                    case "ProductSubCategory":
                        parameters = parameters.Append(new Parameter
                        {
                            ParameterName = "@productCategoryId",
                            ParameterValue = dataParentSubjectValue
                        }).ToArray();
                        parameters = parameters.Append(new Parameter
                        {
                            ParameterName = "@productSubCategory",
                            ParameterValue = dataSubjectValue
                        }).ToArray();
                        break;
                    case "SalesSubRegion":
                        parameters = parameters.Append(new Parameter
                        {
                            ParameterName = "@salesRegionId",
                            ParameterValue = dataParentSubjectValue
                        }).ToArray();
                        parameters = parameters.Append(new Parameter
                        {
                            ParameterName = "@salesSubRegion",
                            ParameterValue = dataSubjectValue
                        }).ToArray();
                        break;
                }
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(dataSubjectCreateStoredProcedureName, parameters, dataSubjectName, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                this.Close();
            }
        }
    }
}