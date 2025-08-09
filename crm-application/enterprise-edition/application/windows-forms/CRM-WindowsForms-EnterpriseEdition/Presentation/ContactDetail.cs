using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class ContactDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string _functionTitle;
        private readonly Guid _contactId;
        private readonly string applicationTitlePrefix = "CRM - ";
        private bool? contactDetailActiveStatusOriginalValue;
        private string contactDetailContactGetStoredProcedureName;
        private string contactDetailContactIdFriendlyName;
        private string contactDetailContactStoredProcedureParameterPrefix;
        private string contactDetailContactUpdateStoredProcedureName;
        private string? contactDetailEmailAddressOriginalValue;
        private string? contactDetailFirstNameOriginalValue;
        private string? contactDetailLastNameOriginalValue;
        private string contactDetailModuleContactTypeFriendlyName;
        private string? contactDetailRoleOriginalValue;
        private string? contactDetailTelephoneNumberOriginalValue;
        private readonly string titleLabelSuffix = " Detail";

        public ContactDetail(string functionTitle, Guid contactId)
        {
            InitializeComponent();
            _functionTitle = functionTitle;
            _contactId = contactId;
            SetModuleTheme(_functionTitle);
            contactDetailToggleEditModeButton.Click += new EventHandler(contactDetailToggleEditModeButton_Click);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void SetModuleTheme(string functionTitle)
        {
            switch (functionTitle)
            {
                case "Customer":
                    this.BackColor = Color.LightGreen;
                    contactDetailModuleContactTypeFriendlyName = "Customer Contact";
                    contactDetailContactGetStoredProcedureName = "[dbo].[spGetCustomerContact]";
                    contactDetailContactIdFriendlyName = "Customer Contact Id";
                    contactDetailContactStoredProcedureParameterPrefix = "customerContact";
                    break;
                case "Supplier":
                    this.BackColor = Color.MediumAquamarine;
                    contactDetailModuleContactTypeFriendlyName = "Supplier Contact";
                    contactDetailContactGetStoredProcedureName = "[dbo].[spGetSupplierContact]";
                    contactDetailContactIdFriendlyName = "Supplier Contact Id";
                    contactDetailContactStoredProcedureParameterPrefix = "supplierContact";
                    break;
            }

            this.Text = $"{applicationTitlePrefix}{contactDetailModuleContactTypeFriendlyName}{titleLabelSuffix}";
            contactDetailTitleLabel.Text = $"{contactDetailModuleContactTypeFriendlyName}{titleLabelSuffix}";
            contactDetailContactIdTextboxLabel.Text = contactDetailContactIdFriendlyName;
            contactDetailUpdateContactButton.Text = $"Update {contactDetailModuleContactTypeFriendlyName}";
        }

        private async void ContactDetailContactInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = $"@{contactDetailContactStoredProcedureParameterPrefix}Id",
                    ParameterValue = _contactId
                }
            };

            try
            {
                DataTable? contactDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(
                    contactDetailContactGetStoredProcedureName,
                    parameters.ToArray(),
                    contactDetailModuleContactTypeFriendlyName,
                    _databaseConnectionSettings.DatabaseConnectionString
                    );

                if (contactDataTable != null)
                {
                    DataRow contactDataRow = contactDataTable.Rows[0];
                    contactDetailActiveStatusCheckbox.Checked = (bool)contactDataRow["Active Status"];
                    contactDetailContactIdTextbox.Text = contactDataRow[contactDetailContactIdFriendlyName].ToString();
                    contactDetailEmailAddressTextbox.Text = contactDataRow["Email Address"].ToString();
                    contactDetailFirstNameTextbox.Text = contactDataRow["First Name"].ToString();
                    contactDetailLastNameTextbox.Text = contactDataRow["Last Name"].ToString();
                    contactDetailRoleTextbox.Text = contactDataRow["Role"].ToString();
                    contactDetailTelephoneNumberTextbox.Text = contactDataRow["Telephone Number"].ToString();
                    contactDetailCreatedByTextbox.Text = contactDataRow["Created By"].ToString();
                    contactDetailCreatedTimestampTextbox.Text = contactDataRow["Created Timestamp UTC"].ToString();
                    contactDetailLastUpdatedByTextbox.Text = contactDataRow["Modified By"].ToString();
                    contactDetailLastUpdatedTimestampTextbox.Text = contactDataRow["Modified Timestamp UTC"].ToString();

                    contactDetailActiveStatusOriginalValue = (bool)contactDataRow["Active Status"];
                    contactDetailEmailAddressOriginalValue = contactDataRow["Email Address"].ToString();
                    contactDetailFirstNameOriginalValue = contactDataRow["First Name"].ToString();
                    contactDetailLastNameOriginalValue = contactDataRow["Last Name"].ToString();
                    contactDetailRoleOriginalValue = contactDataRow["Role"].ToString();
                    contactDetailTelephoneNumberOriginalValue = contactDataRow["Telephone Number"].ToString();

                    this.Text += $" ({contactDetailLastNameOriginalValue}, {contactDetailFirstNameOriginalValue})";
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.NoDataFound", contactDetailModuleContactTypeFriendlyName);
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", contactDetailModuleContactTypeFriendlyName, ex.Message);
            }
        }

        private async void contactDetailUpdateContactButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = contactDetailActiveStatusCheckbox.Checked;
            string emailAddress = contactDetailEmailAddressTextbox.Text.TrimEnd();
            string firstName = contactDetailFirstNameTextbox.Text.TrimEnd();
            string lastName = contactDetailLastNameTextbox.Text.TrimEnd();
            string role = contactDetailRoleTextbox.Text.TrimEnd();
            string telephoneNumber = contactDetailTelephoneNumberTextbox.Text.TrimEnd();

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
                    Name = "EmailAddress",
                    Value = emailAddress,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "FirstName",
                    Value = firstName,
                    MaxLength = 30,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "LastName",
                    Value = lastName,
                    MaxLength = 30,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Role",
                    Value = role,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "TelephoneNumber",
                    Value = telephoneNumber,
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
                        OriginalValue = contactDetailActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Email Address",
                        VariableType = "string",
                        OriginalValue = contactDetailEmailAddressOriginalValue,
                        NewValue = emailAddress
                    },
                    new ChangeDetail
                    {
                        VariableName = "First Name",
                        VariableType = "string",
                        OriginalValue = contactDetailFirstNameOriginalValue,
                        NewValue = firstName
                    },
                    new ChangeDetail
                    {
                        VariableName = "Last Name",
                        VariableType = "string",
                        OriginalValue = contactDetailLastNameOriginalValue,
                        NewValue = lastName
                    },
                    new ChangeDetail
                    {
                        VariableName = "Role",
                        VariableType = "string",
                        OriginalValue = contactDetailRoleOriginalValue,
                        NewValue = role
                    },
                    new ChangeDetail
                    {
                        VariableName = "Telephone Number",
                        VariableType = "string",
                        OriginalValue = contactDetailTelephoneNumberOriginalValue,
                        NewValue = telephoneNumber
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = UpdateConfirmation.ConfirmChanges(changesList, contactDetailModuleContactTypeFriendlyName);

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
                            ParameterName = $"@{contactDetailContactStoredProcedureParameterPrefix}Id",
                            ParameterValue = _contactId
                        },
                        new Parameter
                        {
                            ParameterName = "@emailAddress",
                            ParameterValue = emailAddress
                        },
                        new Parameter
                        {
                            ParameterName = "@firstName",
                            ParameterValue = firstName
                        },
                        new Parameter
                        {
                            ParameterName = "@lastName",
                            ParameterValue = lastName
                        },
                        new Parameter
                        {
                            ParameterName = "@role",
                            ParameterValue = role
                        },
                        new Parameter
                        {
                            ParameterName = "@telephoneNumber",
                            ParameterValue = telephoneNumber
                        }
                    };

                    string operationType = "update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(
                        contactDetailContactUpdateStoredProcedureName,
                        parameters.ToArray(),
                        contactDetailModuleContactTypeFriendlyName,
                        _databaseConnectionSettings.DatabaseConnectionString,
                        operationType
                        );
                    this.Close();
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.UpdateCancelled");
                    this.Close();
                }
            }
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            ContactDetailContactInformation_Load(this, EventArgs.Empty);
        }

        private void contactDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            contactDetailActiveStatusCheckbox.Enabled = !contactDetailActiveStatusCheckbox.Enabled;
            contactDetailEmailAddressTextbox.ReadOnly = !contactDetailEmailAddressTextbox.ReadOnly;
            contactDetailFirstNameTextbox.ReadOnly = !contactDetailFirstNameTextbox.ReadOnly;
            contactDetailLastNameTextbox.ReadOnly = !contactDetailLastNameTextbox.ReadOnly;
            contactDetailRoleTextbox.ReadOnly = !contactDetailRoleTextbox.ReadOnly;
            contactDetailTelephoneNumberTextbox.ReadOnly = !contactDetailTelephoneNumberTextbox.ReadOnly;
            contactDetailUpdateContactButton.Enabled = !contactDetailUpdateContactButton.Enabled;
        }
    }
}