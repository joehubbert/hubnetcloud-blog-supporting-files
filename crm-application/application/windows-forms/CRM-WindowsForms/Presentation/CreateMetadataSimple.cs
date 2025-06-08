using CRM_WindowsForms.Interface;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class CreateMetadataSimple : Form
    {
        private readonly string _functionTitle;
        private readonly string applicationTitlePrefix = "CRM - Create ";
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private string dataSubjectFriendlyName;
        private string dataSubjectName;
        private string dataSubjectStoredProcedureName;
        private readonly string titleLabelPrefix = "Create ";

        public CreateMetadataSimple(string functionTitle)
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

        private void SetParameters(string functionTitle)
        {
            switch (functionTitle)
            {
                case "CustomerNoteType":
                    dataSubjectFriendlyName = "Customer Note Type";
                    dataSubjectName = functionTitle;
                    dataSubjectStoredProcedureName = "[dbo].[spCreateCustomerNoteType]";
                    break;
                case "CustomerType":
                    dataSubjectFriendlyName = "Customer Type";
                    dataSubjectName = functionTitle;
                    dataSubjectStoredProcedureName = "[dbo].[spCreateCustomerType]";
                    break;
                case "MarketingChannel":
                    dataSubjectFriendlyName = "Marketing Channel";
                    dataSubjectName = functionTitle;
                    dataSubjectStoredProcedureName = "[dbo].[spCreateMarketingChannel]";
                    break;
                case "OrderLineItemStatus":
                    dataSubjectFriendlyName = "Order Line Item Status";
                    dataSubjectName = functionTitle;
                    dataSubjectStoredProcedureName = "[dbo].[spCreateOrderLineItemStatus]";
                    break;
                case "OrderStatus":
                    dataSubjectFriendlyName = "Order Status";
                    dataSubjectName = functionTitle;
                    dataSubjectStoredProcedureName = "[dbo].[spCreateOrderStatus]";
                    break;
                case "PaymentMethod":
                    dataSubjectFriendlyName = "Payment Method";
                    dataSubjectName = functionTitle;
                    dataSubjectStoredProcedureName = "[dbo].[spCreatePaymentMethod]";
                    break;
                case "ProductCategory":
                    dataSubjectFriendlyName = "Product Category";
                    dataSubjectName = functionTitle;
                    dataSubjectStoredProcedureName = "[dbo].[spCreateProductCategory]";
                    break;
                case "ProductNoteType":
                    dataSubjectFriendlyName = "Product Note Type";
                    dataSubjectName = functionTitle;
                    dataSubjectStoredProcedureName = "[dbo].[spCreateProductNoteType]";
                    break;
                case "SalesRegion":
                    dataSubjectFriendlyName = "Sales Region";
                    dataSubjectName = functionTitle;
                    dataSubjectStoredProcedureName = "[dbo].[spCreateSalesRegion]";
                    break;
                case "SupplierNoteType":
                    dataSubjectFriendlyName = "Supplier Note Type";
                    dataSubjectName = functionTitle;
                    dataSubjectStoredProcedureName = "[dbo].[spCreateSupplierNoteType]";
                    break;
            }

            createMetadataSimpleTitleLabel.Text = $"{titleLabelPrefix}{dataSubjectFriendlyName}";
            createMetadataSimpleMetadataTypeTextboxLabel.Text = dataSubjectFriendlyName;
            createMetadataSimpleActiveStatusCheckbox.Text = $"Active {dataSubjectFriendlyName}";
            this.Text = $"{applicationTitlePrefix}{dataSubjectFriendlyName}";
        }

        private async void createMetadataSimpleSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createMetadataSimpleActiveStatusCheckbox.Checked;
            string dataSubjectValue = createMetadataSimpleMetadataTypeTextbox.Text.TrimEnd();

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

                switch(_functionTitle)
                {
                    case "CustomerNoteType":
                        parameters = parameters.Append(new Parameter
                        {
                            ParameterName = "@customerNoteType",
                            ParameterValue = dataSubjectValue
                        }).ToArray();
                        break;
                    case "CustomerType":
                        parameters = parameters.Append(new Parameter
                        {
                            ParameterName = "@customerType",
                            ParameterValue = dataSubjectValue
                        }).ToArray();
                        break;
                    case "MarketingChannel":
                        parameters = parameters.Append(new Parameter
                        {
                            ParameterName = "@marketingChannel",
                            ParameterValue = dataSubjectValue
                        }).ToArray();
                        break;
                    case "OrderLineItemStatus":
                        parameters = parameters.Append(new Parameter
                        {
                            ParameterName = "@orderLineItemStatus",
                            ParameterValue = dataSubjectValue
                        }).ToArray();
                        break;
                    case "OrderStatus":
                        parameters = parameters.Append(new Parameter
                        {
                            ParameterName = "@orderStatus",
                            ParameterValue = dataSubjectValue
                        }).ToArray();
                        break;
                    case "PaymentMethod":
                        parameters = parameters.Append(new Parameter
                        {
                            ParameterName = "@paymentMethod",
                            ParameterValue = dataSubjectValue
                        }).ToArray();
                        break;
                    case "ProductCategory":
                        parameters = parameters.Append(new Parameter
                        {
                            ParameterName = "@productCategory",
                            ParameterValue = dataSubjectValue
                        }).ToArray();
                        break;
                    case "ProductNoteType":
                        parameters = parameters.Append(new Parameter
                        {
                            ParameterName = "@productNoteType",
                            ParameterValue = dataSubjectValue
                        }).ToArray();
                        break;
                    case "SalesRegion":
                        parameters = parameters.Append(new Parameter
                        {
                            ParameterName = "@salesRegion",
                            ParameterValue = dataSubjectValue
                        }).ToArray();
                        break;
                    case "SupplierNoteType":
                        parameters = parameters.Append(new Parameter
                        {
                            ParameterName = "@supplierNoteType",
                            ParameterValue = dataSubjectValue
                        }).ToArray();
                        break;
                }
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(dataSubjectStoredProcedureName, parameters, dataSubjectName, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                this.Close();
            }
        }
    }
}