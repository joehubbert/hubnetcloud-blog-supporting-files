using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class DeliveryMethodDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        
        private readonly Guid _deliveryMethodId;
        private bool ?deliveryMethodDetailActiveStatusOriginalValue;
        private decimal ?deliveryMethodDetailDeliveryCostOriginalValue;
        private string ?deliveryMethodDetailDeliveryMethodOriginalValue;
        private int ?deliveryMethodDetailDeliveryTimeOriginalValue;
        private Guid ?deliveryMethodDetailTaxProfileIdOriginalValue;

        public DeliveryMethodDetail(Guid deliveryMethodId)
        {
            InitializeComponent();
            InitializeCustomComponents();
            _deliveryMethodId = deliveryMethodId;
            deliveryMethodDetailToggleEditModeButton.Click += deliveryMethodDetailToggleEditModeButton_Click;
            LoadDatabaseConnectionSettingsAsync();
        }

        private void InitializeCustomComponents()
        {
            deliveryMethodDetailTaxProfileComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task DeliveryMethodDetailLoadTaxProfileAsync(Guid taxProfileId)
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
                        DisplayText = $"{row.Field<string>("Tax Profile")} - {row.Field<string>("Tax Rate")}"
                    })
                    .OrderBy(item => item.TaxProfile)
                    .ToList();
                deliveryMethodDetailTaxProfileComboBox.DataSource = taxProfileList;
                deliveryMethodDetailTaxProfileComboBox.DisplayMember = "DisplayText";
                deliveryMethodDetailTaxProfileComboBox.ValueMember = "TaxProfileId";
                deliveryMethodDetailTaxProfileComboBox.SelectedValue = taxProfileId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Tax Profile data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void DeliveryMethodDetailDeliveryMethodInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string storedProcedureName = "[dbo].[spGetDeliveryMethod]";
            string dataSubject = "Delivery Method";

            var parameters = new[]
            {
                    new Parameter
                    {
                        ParameterName = "@deliveryMethodId",
                        ParameterValue = _deliveryMethodId
                    }
            };

            try
            {
                DataTable? deliveryMethodDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (deliveryMethodDataTable != null)
                {
                    DataRow deliveryMethodDataRow = deliveryMethodDataTable.Rows[0];
                    string deliveryCostPartA;
                    string deliveryCostPartB;

                    SplitDecimal.SplitDecimalUsingDelimiter((decimal)deliveryMethodDataRow["Delivery Cost"], out deliveryCostPartA, out deliveryCostPartB);

                    deliveryMethodDetailDeliveryMethodIdTextbox.Text = deliveryMethodDataRow["Delivery Method Id"].ToString();
                    deliveryMethodDetailDeliveryMethodTextbox.Text = deliveryMethodDataRow["Delivery Method"].ToString();
                    deliveryMethodDetailDeliveryCostTextboxA.Text = deliveryCostPartA;
                    deliveryMethodDetailDeliveryCostTextboxB.Text = deliveryCostPartB;
                    deliveryMethodDetailDeliveryTimeTextbox.Text = deliveryMethodDataRow["Delivery Time"].ToString();
                    Guid taxProfileId = (Guid)deliveryMethodDataRow["Tax Profile Id"];
                    await DeliveryMethodDetailLoadTaxProfileAsync(taxProfileId);
                    deliveryMethodDetailCreatedByTextbox.Text = deliveryMethodDataRow["Created By"].ToString();
                    deliveryMethodDetailCreatedTimestampTextbox.Text = deliveryMethodDataRow["Created Timestamp UTC"].ToString();
                    deliveryMethodDetailLastUpdatedByTextbox.Text = deliveryMethodDataRow["Modified By"].ToString();
                    deliveryMethodDetailLastUpdatedTimestampTextbox.Text = deliveryMethodDataRow["Modified Timestamp UTC"].ToString();
                    deliveryMethodDetailActiveStatusCheckbox.Checked = (bool)deliveryMethodDataRow["Active Status"];

                    deliveryMethodDetailDeliveryMethodOriginalValue = deliveryMethodDataRow["Delivery Method"].ToString();
                    deliveryMethodDetailDeliveryCostOriginalValue = (decimal)deliveryMethodDataRow["Delivery Cost"];
                    deliveryMethodDetailDeliveryTimeOriginalValue = (int)deliveryMethodDataRow["Delivery Time"];
                    deliveryMethodDetailTaxProfileIdOriginalValue = (Guid)deliveryMethodDataRow["Tax Profile Id"];
                    deliveryMethodDetailActiveStatusOriginalValue = (bool)deliveryMethodDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Delivery Method.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Delivery Method details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void deliveryMethodDetailUpdateDeliveryMethodButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = deliveryMethodDetailActiveStatusCheckbox.Checked;
            decimal deliveryCost = decimal.Parse(deliveryMethodDetailDeliveryCostTextboxA.Text.TrimEnd()) + (decimal.Parse(deliveryMethodDetailDeliveryCostTextboxB.Text.TrimEnd()) / 100);
            string deliveryMethod = deliveryMethodDetailDeliveryMethodTextbox.Text.TrimEnd();
            int deliveryTime = int.Parse(deliveryMethodDetailDeliveryTimeTextbox.Text.TrimEnd());
            Guid taxProfileId = Guid.Parse(deliveryMethodDetailTaxProfileComboBox.SelectedValue.ToString());

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
                var changesList = new List<ChangeDetail>
                {
                    new ChangeDetail
                    {
                        VariableName = "Active Status",
                        VariableType = "bool",
                        OriginalValue = deliveryMethodDetailActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Delivery Method",
                        VariableType = "string",
                        OriginalValue = deliveryMethodDetailDeliveryMethodOriginalValue,
                        NewValue = deliveryMethod
                    },
                    new ChangeDetail
                    {
                        VariableName = "Delivery Cost",
                        VariableType = "decimal",
                        OriginalValue = deliveryMethodDetailDeliveryCostOriginalValue,
                        NewValue = deliveryCost
                    },
                    new ChangeDetail
                    {
                        VariableName = "Delivery Time",
                        VariableType = "int",
                        OriginalValue = deliveryMethodDetailDeliveryTimeOriginalValue,
                        NewValue = deliveryTime
                    },
                    new ChangeDetail
                    {
                        VariableName = "Tax Profile Id",
                        VariableType = "Guid",
                        OriginalValue = deliveryMethodDetailTaxProfileIdOriginalValue,
                        NewValue = taxProfileId
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
                            ParameterName = "@deliveryMethodId",
                            ParameterValue = _deliveryMethodId
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
                    string storedProcedureName = "[dbo].[spUpdateDeliveryMethod]";
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
            DeliveryMethodDetailDeliveryMethodInformation_Load(this, EventArgs.Empty);
        }

        private void deliveryMethodDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            deliveryMethodDetailDeliveryMethodTextbox.ReadOnly = !deliveryMethodDetailDeliveryMethodTextbox.ReadOnly;
            deliveryMethodDetailDeliveryCostTextboxA.ReadOnly = !deliveryMethodDetailDeliveryCostTextboxA.ReadOnly;
            deliveryMethodDetailDeliveryCostTextboxB.ReadOnly = !deliveryMethodDetailDeliveryCostTextboxB.ReadOnly;
            deliveryMethodDetailDeliveryTimeTextbox.ReadOnly = !deliveryMethodDetailDeliveryTimeTextbox.ReadOnly;
            deliveryMethodDetailTaxProfileComboBox.Enabled = !deliveryMethodDetailTaxProfileComboBox.Enabled;
            deliveryMethodDetailActiveStatusCheckbox.Enabled = !deliveryMethodDetailActiveStatusCheckbox.Enabled;
            deliveryMethodDetailUpdateDeliveryMethodButton.Enabled = !deliveryMethodDetailUpdateDeliveryMethodButton.Enabled;
        }
    }
}