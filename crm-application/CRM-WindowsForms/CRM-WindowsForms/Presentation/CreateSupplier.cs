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
            bool supplierOverviewActiveStatus = createSupplierOverviewActiveStatusCheckbox.Checked;
            string supplierOverviewAddressLine1 = createSupplierOverviewAddressLine1Textbox.Text.TrimEnd();
            string? supplierOverviewAddressLine2 = createSupplierOverviewAddressLine2Textbox.Text.TrimEnd();
            string supplierOverviewAddressLine3 = createSupplierOverviewAddressLine3Textbox.Text.TrimEnd();
            string supplierOverviewAddressLine4 = createSupplierOverviewAddressLine4Textbox.Text.TrimEnd();
            string supplierOverviewAddressLine5 = createSupplierOverviewAddressLine5Textbox.Text.TrimEnd();
            string supplierOverviewSupplierName = createSupplierOverviewSupplierNameTextbox.Text.TrimEnd();
            string supplierOverviewEmailAddress = createSupplierOverviewEmailAddressTextbox.Text.TrimEnd();
            string supplierOverviewTelephoneNumber = createSupplierOverviewTelephoneNumberTextbox.Text.TrimEnd();

            Guid supplierFinancePaymentCurrencyId = Guid.Parse(createSupplierFinancePaymentCurrencyComboBox.SelectedValue.ToString());
            byte supplierFinancePaymentDays = byte.Parse(createSupplierFinancePaymentDaysTextbox.Text.TrimEnd());
            string? supplierFinanceVATNumber = createSupplierFinanceVATNumberTextbox.Text.TrimEnd();

            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var stringsToValidate = new List<ValidateStringInput.StringProperty>
            {
                new ValidateStringInput.StringProperty
                {
                    Name = "SupplierOverviewEmailAddress",
                    Value = supplierOverviewEmailAddress,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "SupplierOverviewSupplierName",
                    Value = supplierOverviewSupplierName,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "SupplierOverviewTelephoneNumber",
                    Value = supplierOverviewTelephoneNumber,
                    MaxLength = 13
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "SupplierOverviewAddressLine1",
                    Value = supplierOverviewAddressLine1,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "SupplierOverviewAddressLine3",
                    Value = supplierOverviewAddressLine3,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "SupplierOverviewAddressLine4",
                    Value = supplierOverviewAddressLine4,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "SupplierOverviewAddressLine5",
                    Value = supplierOverviewAddressLine5,
                    MaxLength = 50
                }
            };

            if (!string.IsNullOrEmpty(supplierOverviewAddressLine2))
            {
                stringsToValidate.Add(new ValidateStringInput.StringProperty
                {
                    Name = "SupplierOverviewAddressLine2",
                    Value = supplierOverviewAddressLine2,
                    MaxLength = 50
                });
            }

            if (!string.IsNullOrEmpty(supplierFinanceVATNumber))
            {
                stringsToValidate.Add(new ValidateStringInput.StringProperty
                {
                    Name = "CompanyFinanceVATNumber",
                    Value = supplierFinanceVATNumber,
                    MaxLength = 50
                });
            }

            var validationResult = ValidateStringInput.ValidateInput(stringsToValidate);

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
                        },
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