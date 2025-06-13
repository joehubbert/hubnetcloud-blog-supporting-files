using CRM_WindowsForms.Interface;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class MetadataAdvancedDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _dataSubjectId;
        private readonly string _functionTitle;
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
        private readonly string titleLabelSuffix = " Detail";

        public MetadataAdvancedDetail(Guid dataSubjectId, string functionTitle)
        {
            InitializeComponent();
            _dataSubjectId = dataSubjectId;
            _functionTitle = functionTitle;
            metadataAdvancedDetailToggleEditModeButton.Click += metadataAdvancedDetailToggleEditModeButton_Click;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void InitializeCustomComponents()
        {
            metadataAdvancedDetailDataParentSubjectComboBox.DropDown += new EventHandler(MetadataAdvancedDetailDataParentSubjectComboBox_DropDown);
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
                    break;
            }

            dataSubjectName = functionTitle;

            metadataAdvancedDetailTitleLabel.Text = $"{dataSubjectFriendlyName}{titleLabelSuffix}";
            metadataAdvancedDetailDataSubjectIdTextboxLabel.Text = dataSubjectIdFriendlyName;
            metadataAdvancedDetailDataParentSubjectComboBoxLabel.Text = dataParentSubjectFriendlyName;
            metadataAdvancedDetailDataSubjectTextboxLabel.Text = dataSubjectFriendlyName;
            metadataAdvancedDetailActiveStatusCheckbox.Text = $"Active {dataSubjectFriendlyName}";
            metadataAdvancedDetailUpdateDataSubjectButton.Text = $"Update {dataSubjectFriendlyName}";
            this.Text = $"{applicationTitlePrefix}{dataSubjectFriendlyName}{titleLabelSuffix}";
        }

        private async Task MetadataAdvancedDetailLoadDataParentSubjectAsync(Guid dataParentSubjectId)
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

                metadataAdvancedDetailDataParentSubjectComboBox.DataSource = dataList;
                metadataAdvancedDetailDataParentSubjectComboBox.DisplayMember = "Name";
                metadataAdvancedDetailDataParentSubjectComboBox.ValueMember = "Id";
                metadataAdvancedDetailDataParentSubjectComboBox.SelectedValue = dataParentSubjectId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load {dataParentSubjectFriendlyName} data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MetadataAdvancedDetailDataParentSubjectComboBox_DropDown(object sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void ViewMetadataAdvancedDetailMetadataInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var parameters = new List<Parameter>();

            switch (_functionTitle)
            {
                case "ProductSubCategory":
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@productSubCategoryId",
                        ParameterValue = _dataSubjectId
                    });
                    break;
                case "SalesSubRegion":
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@salesSubRegionId",
                        ParameterValue = _dataSubjectId
                    });
                    break;
            }

            try
            {
                DataTable? metadataAdvancedDetailDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(
                    dataSubjectGetStoredProcedureName,
                    parameters.ToArray(),
                    dataSubjectName,
                    _databaseConnectionSettings.DatabaseConnectionString);

                if (metadataAdvancedDetailDataTable != null)
                {
                    DataRow metadataAdvancedDetailDataRow = metadataAdvancedDetailDataTable.Rows[0];
                    metadataAdvancedDetailDataSubjectIdTextbox.Text = metadataAdvancedDetailDataRow[dataSubjectIdFriendlyName].ToString();
                    await MetadataAdvancedDetailLoadDataParentSubjectAsync((Guid)metadataAdvancedDetailDataRow[dataParentSubjectIdFriendlyName]);
                    metadataAdvancedDetailDataSubjectTextbox.Text = metadataAdvancedDetailDataRow[dataSubjectFriendlyName].ToString();
                    metadataAdvancedDetailCreatedByTextbox.Text = metadataAdvancedDetailDataRow["Created By"].ToString();
                    metadataAdvancedDetailCreatedTimestampTextbox.Text = metadataAdvancedDetailDataRow["Created Timestamp"].ToString();
                    metadataAdvancedDetailLastUpdatedByTextbox.Text = metadataAdvancedDetailDataRow["Modified By"].ToString();
                    metadataAdvancedDetailLastUpdatedTimestampTextbox.Text = metadataAdvancedDetailDataRow["Modified Timestamp"].ToString();
                    metadataAdvancedDetailActiveStatusCheckbox.Checked = (bool)metadataAdvancedDetailDataRow["Active Status"];

                    dataParentSubjectOriginalValue = (Guid)metadataAdvancedDetailDataRow[dataParentSubjectIdFriendlyName];
                    dataSubjectOriginalValue = metadataAdvancedDetailDataRow[dataSubjectFriendlyName].ToString();
                    dataSubjectActiveStatusOriginalValue = (bool)metadataAdvancedDetailDataRow["Active Status"];
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

        private async void metadataAdvancedDetailUpdateDataSubjectButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = metadataAdvancedDetailActiveStatusCheckbox.Checked;
            Guid dataParentSubjectIdValue = (Guid)metadataAdvancedDetailDataParentSubjectComboBox.SelectedValue;
            string dataSubjectValue = metadataAdvancedDetailDataSubjectTextbox.Text.TrimEnd();

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
                        }
                    };

                    switch (_functionTitle)
                    {
                        case "ProductSubCategory":
                            parameters = parameters.Append(new Parameter
                            {
                                ParameterName = "@productCategoryId",
                                ParameterValue = dataParentSubjectIdValue
                            }).ToArray();
                            parameters = parameters.Append(new Parameter
                            {
                                ParameterName = "@productSubCategory",
                                ParameterValue = dataSubjectValue
                            }).ToArray();
                            parameters = parameters.Append(new Parameter
                            {
                                ParameterName = "@productSubCategoryId",
                                ParameterValue = _dataSubjectId
                            }).ToArray();
                            break;
                        case "SalesSubRegion":
                            parameters = parameters.Append(new Parameter
                            {
                                ParameterName = "@salesRegionId",
                                ParameterValue = dataParentSubjectIdValue
                            }).ToArray();
                            parameters = parameters.Append(new Parameter
                            {
                                ParameterName = "@salesSubRegion",
                                ParameterValue = dataSubjectValue
                            }).ToArray();
                            parameters = parameters.Append(new Parameter
                            {
                                ParameterName = "@salesSubRegionId",
                                ParameterValue = _dataSubjectId
                            }).ToArray();
                            break;
                    }

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
            ViewMetadataAdvancedDetailMetadataInformation_Load(this, EventArgs.Empty);
        }

        private void metadataAdvancedDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            metadataAdvancedDetailDataParentSubjectComboBox.Enabled = !metadataAdvancedDetailDataParentSubjectComboBox.Enabled;
            metadataAdvancedDetailDataSubjectTextbox.ReadOnly = !metadataAdvancedDetailDataSubjectTextbox.ReadOnly;
            metadataAdvancedDetailActiveStatusCheckbox.Enabled = !metadataAdvancedDetailActiveStatusCheckbox.Enabled;
            metadataAdvancedDetailUpdateDataSubjectButton.Enabled = !metadataAdvancedDetailUpdateDataSubjectButton.Enabled;
        }
    }
}