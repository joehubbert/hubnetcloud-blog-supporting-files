using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class CreateSupplier : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Supplier";

        public CreateSupplier()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadDatabaseConnectionSettingsAsync();
            LoadInitialDataAsync();
        }

        private void InitializeCustomComponents()
        {
            createSupplierFinancePaymentCurrencyComboBox.DropDown += new EventHandler(CreateSupplierFinancePaymentCurrencyComboBox_DropDown);
            createSupplierFinanceVATRegisteredCheckbox.CheckedChanged += new EventHandler(CreateSupplierFinanceVATRegisteredCheckBox_CheckedChanged);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task LoadInitialDataAsync()
        {
            await LoadDatabaseConnectionSettingsAsync();

            var loadCurrencyTask = CreateSupplierFinanceLoadCurrencyDataAsync();

            await Task.WhenAll(loadCurrencyTask);
        }

        private void CreateSupplierFinanceVATRegisteredCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (createSupplierFinanceVATRegisteredCheckbox.Checked)
            {
                createSupplierFinanceVATNumberTextbox.Enabled = true;
            }
            else
            {
                createSupplierFinanceVATNumberTextbox.Enabled = false;
                createSupplierFinanceVATNumberTextbox.Text = string.Empty;
            }
        }

        private async Task CreateSupplierFinanceLoadCurrencyDataAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            try
            {
                string storedProcedureName = "[dbo].[spGetAllCurrency]";
                string dataSubject = "Currency";
                DataTable? currencyData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var currencyList = currencyData.AsEnumerable()
                    .Select(row => new
                    {
                        CurrencyId = row.Field<Guid>("Currency Id"),
                        CurrencyCode = row.Field<string>("Currency Code"),
                        CurrencyName = row.Field<string>("Currency Name"),
                        DisplayText = $"{row.Field<string>("Currency Code")} - {row.Field<string>("Currency Name")}"
                    })
                    .OrderBy(item => item.DisplayText)
                    .ToList();

                createSupplierFinancePaymentCurrencyComboBox.DataSource = currencyList;
                createSupplierFinancePaymentCurrencyComboBox.DisplayMember = "DisplayText";
                createSupplierFinancePaymentCurrencyComboBox.ValueMember = "CurrencyId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Currency data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateSupplierFinancePaymentCurrencyComboBox_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void createSupplierSubmitButton_Click(object sender, EventArgs e)
        {
            Guid supplierFinancePaymentCurrencyId = Guid.Parse(createSupplierFinancePaymentCurrencyComboBox.SelectedValue.ToString());
            byte supplierFinancePaymentDays = byte.Parse(createSupplierFinancePaymentDaysTextbox.Text.TrimEnd());
            string? supplierFinanceVATNumber = createSupplierFinanceVATNumberTextbox.Text.TrimEnd();

            bool supplierOverviewActiveStatus = createSupplierOverviewActiveStatusCheckbox.Checked;
            string supplierOverviewAddressLine1 = createSupplierOverviewAddressLine1Textbox.Text.TrimEnd();
            string? supplierOverviewAddressLine2 = createSupplierOverviewAddressLine2Textbox.Text.TrimEnd();
            string supplierOverviewAddressLine3 = createSupplierOverviewAddressLine3Textbox.Text.TrimEnd();
            string supplierOverviewAddressLine4 = createSupplierOverviewAddressLine4Textbox.Text.TrimEnd();
            string supplierOverviewAddressLine5 = createSupplierOverviewAddressLine5Textbox.Text.TrimEnd();
            string supplierOverviewSupplierName = createSupplierOverviewSupplierNameTextbox.Text.TrimEnd();
            string supplierOverviewEmailAddress = createSupplierOverviewEmailAddressTextbox.Text.TrimEnd();
            string supplierOverviewTelephoneNumber = createSupplierOverviewTelephoneNumberTextbox.Text.TrimEnd();

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
                    Name = "SupplierFinancePayemntCurrencyId",
                    Value = supplierFinancePaymentCurrencyId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierFinancePayemntDays",
                    Value = supplierFinancePaymentDays,
                    ValueType = typeof(byte)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierOverviewActiveStatus",
                    Value = supplierOverviewActiveStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierOverviewActiveStatus",
                    Value = supplierOverviewActiveStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierOverviewAddressLine1",
                    Value = supplierOverviewAddressLine1,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierOverviewAddressLine3",
                    Value = supplierOverviewAddressLine3,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierOverviewAddressLine4",
                    Value = supplierOverviewAddressLine4,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierOverviewAddressLine5",
                    Value = supplierOverviewAddressLine5,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierOverviewEmailAddress",
                    Value = supplierOverviewEmailAddress,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierOverviewSupplierName",
                    Value = supplierOverviewSupplierName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierOverviewTelephoneNumber",
                    Value = supplierOverviewTelephoneNumber,
                    MaxLength = 13,
                    ValueType = typeof(string)
                }
            };

            if (!string.IsNullOrEmpty(supplierOverviewAddressLine2))
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    AllowNullValue = true,
                    Name = "SupplierOverviewAddressLine2",
                    Value = supplierOverviewAddressLine2,
                    MaxLength = 50,
                    ValueType = typeof(string)
                });
            }

            if (!string.IsNullOrEmpty(supplierFinanceVATNumber))
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    AllowNullValue = true,
                    Name = "SupplierFinanceVATNumber",
                    Value = supplierFinanceVATNumber,
                    MaxLength = 50,
                    ValueType = typeof(string)
                });
            }

            dataToValidate = dataToValidate.OrderBy(change => change.Name).ToList();

            var validationResult = ValidateDataInput.ValidateInput(dataToValidate);

            if (!validationResult.IsValid)
            {
                return;
            }
            else
            {
                var parameters = new List<Parameter>
                {
                    new Parameter
                    {
                        ParameterName = "@activeStatus",
                        ParameterValue = supplierOverviewActiveStatus
                    },
                    new Parameter
                    {
                        ParameterName = "@addressLine1",
                        ParameterValue = supplierOverviewAddressLine1
                    },
                    new Parameter
                    {
                        ParameterName = "@addressLine3",
                        ParameterValue = supplierOverviewAddressLine3
                    },
                    new Parameter
                    {
                        ParameterName = "@addressLine4",
                        ParameterValue = supplierOverviewAddressLine4
                    },
                    new Parameter
                    {
                        ParameterName = "@addressLine5",
                        ParameterValue = supplierOverviewAddressLine5
                    },
                    new Parameter
                    {
                        ParameterName = "@emailAddress",
                        ParameterValue = supplierOverviewEmailAddress
                    },
                    new Parameter
                    {
                        ParameterName = "@paymentCurrencyId",
                        ParameterValue = supplierFinancePaymentCurrencyId
                    },
                    new Parameter
                    {
                        ParameterName = "@paymentDays",
                        ParameterValue = supplierFinancePaymentDays
                    },
                    new Parameter
                    {
                        ParameterName = "@supplierName",
                        ParameterValue = supplierOverviewSupplierName
                    },
                    new Parameter
                    {
                        ParameterName = "@telephoneNumber",
                        ParameterValue = supplierOverviewTelephoneNumber
                    },
                    new Parameter
                    {
                        ParameterName = "@vatNumber",
                        ParameterValue = supplierFinanceVATNumber
                    }
                };

                if (!string.IsNullOrEmpty(supplierOverviewAddressLine2))
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@addressLine2",
                        ParameterValue = supplierOverviewAddressLine2
                    });
                }

                string storedProcedureName = "[dbo].[spCreateSupplier]";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters.ToArray(), dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                this.Close();
            }
        }
    }
}