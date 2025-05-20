using CRM_WindowsForms.Interface;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class CreateDeliveryMethod : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public CreateDeliveryMethod()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadDatabaseConnectionSettingsAsync();
            CreateDeliveryMethodLoadTaxProfileAsync();
        }

        private void InitializeCustomComponents()
        {
            createDeliveryMethodTaxProfileComboBox.DropDown += new EventHandler(CreateDeliveryMethodTaxProfileComboBox_DropDown);
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void CreateDeliveryMethodLoadTaxProfileAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                string storedProcedureName = "[dbo].[spGetAllTaxProfile]";
                string dataSubject = "Tax Profile";
                DataTable? taxProfileData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var taxProfileList = taxProfileData.AsEnumerable()
                    .Select(row => new
                    {
                        TaxProfileId = row.Field<Guid>("Tax Profile Id"),
                        TaxProfile = row.Field<string>("Tax Profile"),
                        TaxRate = row.Field<decimal>("Tax Rate"),
                        DisplayText = $"{row.Field<string>("Tax Profile")} | {row.Field<decimal>("Tax Rate")}"
                    })
                    .OrderBy(item => item.TaxProfile)
                    .ToList();
                createDeliveryMethodTaxProfileComboBox.DataSource = taxProfileList;
                createDeliveryMethodTaxProfileComboBox.DisplayMember = "DisplayText";
                createDeliveryMethodTaxProfileComboBox.ValueMember = "TaxProfileId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Tax Profile data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateDeliveryMethodTaxProfileComboBox_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void createDeliveryMethodSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createDeliveryMethodActiveStatusCheckbox.Checked;
            decimal deliveryCost = decimal.Parse(createDeliveryMethodDeliveryCostTextboxA.Text.TrimEnd()) + (decimal.Parse(createDeliveryMethodDeliveryCostTextboxB.Text.TrimEnd()) / 100);
            string deliveryMethod = createDeliveryMethodDeliveryMethodTextbox.Text.TrimEnd();
            int deliveryTime = int.Parse(createDeliveryMethodDeliveryTimeTextbox.Text.TrimEnd());
            Guid taxProfileId = Guid.Parse(createDeliveryMethodTaxProfileComboBox.SelectedValue.ToString());

            string dataSubject = "Delivery Method";

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
                    Name = "DeliveryCost",
                    Value = deliveryCost,
                    ValueType = typeof(decimal)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "DeliveryMethod",
                    Value = deliveryMethod,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "DeliveryTime",
                    Value = deliveryTime,
                    ValueType = typeof(int)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "TaxProfileId",
                    Value = taxProfileId,
                    ValueType = typeof(Guid)
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
                        ParameterName = "@deliveryCost",
                        ParameterValue = deliveryCost
                    },
                    new Parameter
                    {
                        ParameterName = "@deliveryMethod",
                        ParameterValue = deliveryMethod
                    },
                    new Parameter
                    {
                        ParameterName = "@deliveryTime",
                        ParameterValue = deliveryTime
                    },
                    new Parameter
                    {
                        ParameterName = "@taxProfileId",
                        ParameterValue = taxProfileId
                    }
                };
                string storedProcedureName = "[dbo].[spCreateDeliveryMethod]";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                this.Close();
            }
        }
    }
}