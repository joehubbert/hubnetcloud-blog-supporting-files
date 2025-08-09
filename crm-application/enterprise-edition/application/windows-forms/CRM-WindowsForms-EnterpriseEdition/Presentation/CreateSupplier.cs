using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
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
            createSupplierTabControlFinanceTabPagePaymentCurrencyComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            createSupplierTabControlFinanceTabPageVATRegisteredCheckbox.CheckedChanged += new EventHandler(CreateSupplierFinanceVATRegisteredCheckBox_CheckedChanged);
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
            if (createSupplierTabControlFinanceTabPageVATRegisteredCheckbox.Checked)
            {
                createSupplierTabControlFinanceTabPageVATNumberTextbox.Enabled = true;
            }
            else
            {
                createSupplierTabControlFinanceTabPageVATNumberTextbox.Enabled = false;
                createSupplierTabControlFinanceTabPageVATNumberTextbox.Text = string.Empty;
            }
        }

        private async Task CreateSupplierFinanceLoadCurrencyDataAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Currency";

            try
            {
                string storedProcedureName = "[dbo].[spGetAllCurrency]";                
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

                createSupplierTabControlFinanceTabPagePaymentCurrencyComboBox.DataSource = currencyList;
                createSupplierTabControlFinanceTabPagePaymentCurrencyComboBox.DisplayMember = "DisplayText";
                createSupplierTabControlFinanceTabPagePaymentCurrencyComboBox.ValueMember = "CurrencyId";
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void createSupplierSubmitButton_Click(object sender, EventArgs e)
        {
            Guid supplierFinancePaymentCurrencyId = Guid.Parse(createSupplierTabControlFinanceTabPagePaymentCurrencyComboBox.SelectedValue.ToString());
            byte supplierFinancePaymentDays = byte.Parse(createSupplierTabControlFinanceTabPagePaymentDaysTextbox.Text.TrimEnd());
            string? supplierFinanceVATNumber = createSupplierTabControlFinanceTabPageVATNumberTextbox.Text.TrimEnd();

            bool supplierOverviewActiveStatus = createSupplierTabControlOverviewTabPageActiveStatusCheckbox.Checked;
            string supplierOverviewAddressLine1 = createSupplierTabControlOverviewTabPageAddressLine1Textbox.Text.TrimEnd();
            string? supplierOverviewAddressLine2 = createSupplierTabControlOverviewTabPageAddressLine2Textbox.Text.TrimEnd();
            string supplierOverviewAddressLine3 = createSupplierTabControlOverviewTabPageAddressLine3Textbox.Text.TrimEnd();
            string supplierOverviewAddressLine4 = createSupplierTabControlOverviewTabPageAddressLine4Textbox.Text.TrimEnd();
            string supplierOverviewAddressLine5 = createSupplierTabControlOverviewTabPageAddressLine5Textbox.Text.TrimEnd();
            string supplierOverviewSupplierName = createSupplierTabControlOverviewTabPageSupplierNameTextbox.Text.TrimEnd();
            string supplierOverviewEmailAddress = createSupplierTabControlOverviewTabPageEmailAddressTextbox.Text.TrimEnd();
            string supplierOverviewTelephoneNumber = createSupplierTabControlOverviewTabPageTelephoneNumberTextbox.Text.TrimEnd();

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