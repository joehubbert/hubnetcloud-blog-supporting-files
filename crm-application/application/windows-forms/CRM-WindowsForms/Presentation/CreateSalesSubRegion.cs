using CRM_WindowsForms.Interface;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class CreateSalesSubRegion : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public CreateSalesSubRegion()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadDatabaseConnectionSettingsAsync();
            CreateSalesSubRegionLoadSalesRegionAsync();
        }

        private void InitializeCustomComponents()
        {
            createSalesSubRegionSalesRegionComboBox.DropDown += new EventHandler(CreateSalesSubRegionSalesRegionComboBox_DropDown);
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void CreateSalesSubRegionLoadSalesRegionAsync()
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
                createSalesSubRegionSalesRegionComboBox.DataSource = salesRegionList;
                createSalesSubRegionSalesRegionComboBox.DisplayMember = "SalesRegion";
                createSalesSubRegionSalesRegionComboBox.ValueMember = "SalesRegionId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Sales Region data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateSalesSubRegionSalesRegionComboBox_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void createSalesSubRegionSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createSalesSubRegionActiveStatusCheckbox.Checked;
            Guid salesRegionId = Guid.Parse(createSalesSubRegionSalesRegionComboBox.SelectedValue.ToString());
            string salesSubRegion = createSalesSubRegionSalesSubRegionTextbox.Text.TrimEnd();

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
                        ParameterName = "@salesRegionId",
                        ParameterValue = salesRegionId
                    },
                    new Parameter
                    {
                        ParameterName = "@salesSubRegion",
                        ParameterValue = salesSubRegion
                    }
                };
                string storedProcedureName = "[dbo].[spCreateSalesSubRegion]";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                this.Close();
            }
        }
    }
}