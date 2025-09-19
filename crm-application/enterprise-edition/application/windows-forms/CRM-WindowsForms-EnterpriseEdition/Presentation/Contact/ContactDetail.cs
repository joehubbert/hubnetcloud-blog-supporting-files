using CRM.Helpers;
using CRM.Interface;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.Contact
{
    public partial class ContactDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string _functionTitle;
        private readonly Guid _contactId;
        private readonly Guid _dataSubjectId;
        private readonly string _dataSubjectName;
        private readonly string applicationTitlePrefix = "CRM - ";
        private bool contactDetailActiveStatusOriginalValue;
        private string contactDetailContactGetStoredProcedureName;
        private string contactDetailContactIdFriendlyName;
        private string contactDetailContactStoredProcedureParameterPrefix;
        private string contactDetailContactUpdateStoredProcedureName;
        private string contactDetailEmailAddressOriginalValue;
        private string contactDetailFirstNameOriginalValue;
        private string contactDetailLastNameOriginalValue;
        private string contactDetailModuleContactTypeFriendlyName;
        private string contactDetailRoleOriginalValue;
        private string contactDetailTelephoneNumberOriginalValue;
        private readonly string titleLabelSuffix = " Detail";

        public ContactDetail(string functionTitle, Guid contactId, string dataSubjectName, Guid dataSubjectId)
        {
            InitializeComponent();
            InitializeEventHandlers();
            _functionTitle = functionTitle;
            _contactId = contactId;
            SetModuleTheme(_functionTitle);
        }

		protected override async void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			await LoadDatabaseConnectionSettingsAsync();
			ContactDetailContactInformation_Load(this, EventArgs.Empty);
		}

		private void InitializeEventHandlers()
        {
            
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
				new StoredProcedureParameter
				{
					ParameterName = $"{contactDetailContactStoredProcedureParameterPrefix}Id",
					ParameterValue = _contactId
				}
			};

			try
			{
				DataTable? contactDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(
					contactDetailContactGetStoredProcedureName,
					parameters.ToArray(),
					contactDetailModuleContactTypeFriendlyName
					);

				if (contactDataTable != null)
				{
					DataRow contactDataRow = contactDataTable.Rows[0];
					contactDetailActiveStatusCheckBox.Checked = (bool)contactDataRow["Active Status"];
					contactDetailContactIdTextBox.Text = contactDataRow[contactDetailContactIdFriendlyName].ToString();
					contactDetailEmailAddressTextBox.Text = contactDataRow["Email Address"].ToString();
					contactDetailFirstNameTextBox.Text = contactDataRow["First Name"].ToString();
					contactDetailLastNameTextBox.Text = contactDataRow["Last Name"].ToString();
					contactDetailRoleTextBox.Text = contactDataRow["Role"].ToString();
					contactDetailTelephoneNumberTextBox.Text = contactDataRow["Telephone Number"].ToString();
					contactDetailCreatedByTextBox.Text = contactDataRow["Created By"].ToString();
					contactDetailCreatedTimestampTextBox.Text = contactDataRow["Created Timestamp UTC"].ToString();
					contactDetailLastUpdatedByTextBox.Text = contactDataRow["Modified By"].ToString();
					contactDetailLastUpdatedTimestampTextBox.Text = contactDataRow["Modified Timestamp UTC"].ToString();
					switch (_functionTitle)
					{
						case "Customer":
							contactDetailStatusStripDataSubjectPlaceholder.Text = $"Customer: {_dataSubjectName} ({_dataSubjectId})";
							break;
						case "Supplier":
							contactDetailStatusStripDataSubjectPlaceholder.Text = $"Supplier: {_dataSubjectName} ({_dataSubjectId})";
							break;
						default:
							this.Text = _functionTitle;
							break;
					}

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
                    contactDetailContactGetStoredProcedureName = "spGetCustomerContact";
                    contactDetailContactIdFriendlyName = "Customer Contact Id";
                    contactDetailContactStoredProcedureParameterPrefix = "customerContact";
                    break;
                case "Supplier":
                    this.BackColor = Color.MediumAquamarine;
                    contactDetailModuleContactTypeFriendlyName = "Supplier Contact";
                    contactDetailContactGetStoredProcedureName = "spGetSupplierContact";
                    contactDetailContactIdFriendlyName = "Supplier Contact Id";
                    contactDetailContactStoredProcedureParameterPrefix = "supplierContact";
                    break;
            }

            this.Text = $"{applicationTitlePrefix}{contactDetailModuleContactTypeFriendlyName}{titleLabelSuffix}";
            contactDetailTitleLabel.Text = $"{contactDetailModuleContactTypeFriendlyName}{titleLabelSuffix}";
            contactDetailContactIdTextBoxLabel.Text = contactDetailContactIdFriendlyName;
            contactDetailUpdateContactButton.Text = $"Update {contactDetailModuleContactTypeFriendlyName}";
			contactDetailStatusStrip.BackColor = SystemColors.Control;
		}

		private void contactDetailToggleEditModeButton_Click(object? sender, EventArgs e)
		{
			contactDetailActiveStatusCheckBox.Enabled = !contactDetailActiveStatusCheckBox.Enabled;
			contactDetailEmailAddressTextBox.ReadOnly = !contactDetailEmailAddressTextBox.ReadOnly;
			contactDetailFirstNameTextBox.ReadOnly = !contactDetailFirstNameTextBox.ReadOnly;
			contactDetailLastNameTextBox.ReadOnly = !contactDetailLastNameTextBox.ReadOnly;
			contactDetailRoleTextBox.ReadOnly = !contactDetailRoleTextBox.ReadOnly;
			contactDetailTelephoneNumberTextBox.ReadOnly = !contactDetailTelephoneNumberTextBox.ReadOnly;
			contactDetailUpdateContactButton.Enabled = !contactDetailUpdateContactButton.Enabled;
		}

		private async void contactDetailUpdateContactButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = contactDetailActiveStatusCheckBox.Checked;
            string emailAddress = TextBoxCleanerHelper.GetTrimmedText(contactDetailEmailAddressTextBox);
            string firstName = TextBoxCleanerHelper.GetTrimmedText(contactDetailFirstNameTextBox);
            string lastName = TextBoxCleanerHelper.GetTrimmedText(contactDetailLastNameTextBox);
            string role = TextBoxCleanerHelper.GetTrimmedText(contactDetailRoleTextBox);
            string telephoneNumber = TextBoxCleanerHelper.GetTrimmedText(contactDetailTelephoneNumberTextBox);

            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            var dataToValidate = new List<DataValidationService.DataProperty>
            {
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Active Status",
                    Value = activeStatus,
                    ValueType = typeof(bool)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Email Address",
                    Value = emailAddress,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "First Name",
                    Value = firstName,
                    MaxLength = 30,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Last Name",
                    Value = lastName,
                    MaxLength = 30,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Role",
                    Value = role,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Telephone Number",
                    Value = telephoneNumber,
                    ValueType = typeof(string)
                }
            };

            dataToValidate = dataToValidate.OrderBy(change => change.Name).ToList();

            var validationResult = DataValidationService.ValidateInput(dataToValidate);

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
                        OriginalValue = contactDetailActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Email Address",
                        OriginalValue = contactDetailEmailAddressOriginalValue,
                        NewValue = emailAddress
                    },
                    new ChangeDetail
                    {
                        VariableName = "First Name",
                        OriginalValue = contactDetailFirstNameOriginalValue,
                        NewValue = firstName
                    },
                    new ChangeDetail
                    {
                        VariableName = "Last Name",
                        OriginalValue = contactDetailLastNameOriginalValue,
                        NewValue = lastName
                    },
                    new ChangeDetail
                    {
                        VariableName = "Role",
                        OriginalValue = contactDetailRoleOriginalValue,
                        NewValue = role
                    },
                    new ChangeDetail
                    {
                        VariableName = "Telephone Number",
                        OriginalValue = contactDetailTelephoneNumberOriginalValue,
                        NewValue = telephoneNumber
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = ChangeValidationService.ConfirmChanges(changesList, contactDetailModuleContactTypeFriendlyName);

                if (confirmed)
                {
                    var parameters = new[]
                    {
                        new StoredProcedureParameter
                        {
                            ParameterName = "activeStatus",
                            ParameterValue = activeStatus
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = $"@{contactDetailContactStoredProcedureParameterPrefix}Id",
                            ParameterValue = _contactId
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "emailAddress",
                            ParameterValue = emailAddress
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "firstName",
                            ParameterValue = firstName
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "lastName",
                            ParameterValue = lastName
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "role",
                            ParameterValue = role
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "telephoneNumber",
                            ParameterValue = telephoneNumber
                        }
                    };

                    string operationType = "Update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(
                        contactDetailContactUpdateStoredProcedureName,
                        parameters.ToArray(),
                        contactDetailModuleContactTypeFriendlyName,
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
    }
}