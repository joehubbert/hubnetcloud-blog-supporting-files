using CRM_WindowsForms.Interface;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class NoteDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string _moduleGroup;
        private readonly Guid _noteId;
        private readonly string applicationTitlePrefix = "CRM - ";
        private string noteDetailModuleNoteTypeFriendlyName;
        private string noteDetailModuleNoteTypeName;
        private string noteDetailNoteGetStoredProcedureName;
        private string noteDetailNoteIdFriendlyName;
        private string noteDetailNoteIdName;
        private string? noteDetailNoteOriginalValue;
        private string? noteDetailNoteTitleFriendlyName;
        private string noteDetailNoteTitleName;
        private string? noteDetailNoteTitleOriginalValue;
        private string noteDetailNoteTypeFriendlyName;
        private string noteDetailNoteTypeGetStoredProcedureName;
        private string noteDetailNoteTypeIdFriendlyName;
        private string noteDetailNoteTypeIdName;
        private string noteDetailNoteTypeName;
        private Guid? noteDetailNoteTypeIdOriginalValue;       
        private string noteDetailNoteUpdateStoredProcedureName;
        private readonly string titleLabelSuffix = " Detail";

        public NoteDetail(string moduleGroup, Guid noteId)
        {
            InitializeComponent();
            _moduleGroup = moduleGroup;
            _noteId = noteId;
            SetModuleTheme(_moduleGroup);
            noteDetailToggleEditModeButton.Click += noteDetailToggleEditModeButton_Click;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void SetModuleTheme(string moduleGroup)
        {
            switch (moduleGroup)
            {
                case "CustomerManagement":
                    this.BackColor = Color.LightGreen;
                    noteDetailModuleNoteTypeFriendlyName = "Customer Note";
                    noteDetailModuleNoteTypeName = "CustomerNote";
                    noteDetailNoteGetStoredProcedureName = "[dbo].[spGetCustomerNote]";
                    noteDetailNoteIdFriendlyName = "Customer Note Id";
                    noteDetailNoteIdName = "CustomerNoteId";
                    noteDetailNoteTitleFriendlyName = "Customer Note Title";
                    noteDetailNoteTitleName = "CustomerNoteTitle";
                    noteDetailNoteTypeFriendlyName = "Customer Note Type";
                    noteDetailNoteTypeGetStoredProcedureName = "[dbo].[spGetAllCustomerNoteType]";
                    noteDetailNoteTypeIdFriendlyName = "Customer Note Type Id";
                    noteDetailNoteTypeIdName = "CustomerNoteTypeId";
                    noteDetailNoteTypeName = "CustomerNoteType";
                    break;
                case "ProductManagement":
                    this.BackColor = Color.SkyBlue;
                    noteDetailModuleNoteTypeFriendlyName = "Product Note";
                    noteDetailModuleNoteTypeName = "ProductNote";
                    noteDetailNoteGetStoredProcedureName = "[dbo].[spGetProductNote]";
                    noteDetailNoteIdFriendlyName = "Product Note Id";
                    noteDetailNoteIdName = "ProductNoteId";
                    noteDetailNoteTitleFriendlyName = "Product Note Title";
                    noteDetailNoteTitleName = "ProductNoteTitle";
                    noteDetailNoteTypeFriendlyName = "Product Note Type";
                    noteDetailNoteTypeGetStoredProcedureName = "[dbo].[spGetAllProductNoteType]";
                    noteDetailNoteTypeIdFriendlyName = "Product Note Type Id";
                    noteDetailNoteTypeIdName = "ProductNoteTypeId";
                    noteDetailNoteTypeName = "ProductNoteType";
                    break;
                case "SupplierManagement":
                    this.BackColor = Color.MediumAquamarine;
                    noteDetailModuleNoteTypeFriendlyName = "Supplier Note";
                    noteDetailModuleNoteTypeName = "SupplierNote";
                    noteDetailNoteGetStoredProcedureName = "[dbo].[spGetSupplierNote]";
                    noteDetailNoteIdFriendlyName = "Supplier Note Id";
                    noteDetailNoteIdName = "SupplierNoteId";
                    noteDetailNoteTitleFriendlyName = "Supplier Note Title";
                    noteDetailNoteTitleName = "SupplierNoteTitle";
                    noteDetailNoteTypeFriendlyName = "Supplier Note Type";
                    noteDetailNoteTypeGetStoredProcedureName = "[dbo].[spGetAllSupplierNoteType]";
                    noteDetailNoteTypeIdFriendlyName = "Supplier Note Type Id";
                    noteDetailNoteTypeIdName = "SupplierNoteTypeId";
                    noteDetailNoteTypeName = "SupplierNoteType";
                    break;
            }

            this.Text = $"{applicationTitlePrefix}{noteDetailModuleNoteTypeFriendlyName}{titleLabelSuffix}";
            noteDetailTitleLabel.Text = $"{noteDetailModuleNoteTypeFriendlyName}{titleLabelSuffix}";
            noteDetailNoteIdLabel.Text = noteDetailNoteIdFriendlyName;
            noteDetailNoteTitleLabel.Text = $"{noteDetailNoteTitleFriendlyName}*";
            noteDetailNoteTypeLabel.Text = $"{noteDetailNoteTypeFriendlyName}*";
            noteDetailUpdateNoteButton.Text = $"Update {noteDetailModuleNoteTypeFriendlyName}";
        }

        private async Task NoteDetailLoadNoteTypeAsync(Guid noteTypeId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                DataTable? noteTypeData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(noteDetailNoteTypeGetStoredProcedureName, noteDetailNoteTypeName, _databaseConnectionSettings.DatabaseConnectionString);

                var noteTypeList = noteTypeData.AsEnumerable()
                    .Select(row => new
                    {
                        NoteTypeId = row.Field<Guid>(noteDetailNoteTypeIdFriendlyName),
                        NoteType = row.Field<string>(noteDetailNoteTypeFriendlyName),
                    })
                    .OrderBy(item => item.NoteType)
                    .ToList();
                noteDetailNoteTypeComboBox.DataSource = noteTypeList;
                noteDetailNoteTypeComboBox.DisplayMember = "NoteType";
                noteDetailNoteTypeComboBox.ValueMember = "NoteTypeId";
                noteDetailNoteTypeComboBox.SelectedValue = noteTypeId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load {noteDetailNoteTypeFriendlyName} data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ViewNoteDetailNoteInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var parameters = new List<Parameter>();

            switch (_moduleGroup)
            {
                case "CustomerManagement":
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@customerNoteId",
                        ParameterValue = _noteId
                    });
                    break;
                case "ProductManagement":
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@productNoteId",
                        ParameterValue = _noteId
                    });
                    break;
                case "SupplierManagement":
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@supplierNoteId",
                        ParameterValue = _noteId
                    });
                    break;
            }

            try
            {
                DataTable? noteDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(
                    noteDetailNoteGetStoredProcedureName,
                    parameters.ToArray(),
                    noteDetailModuleNoteTypeFriendlyName,
                    _databaseConnectionSettings.DatabaseConnectionString
                    );

                if (noteDataTable != null)
                {
                    DataRow noteDataRow = noteDataTable.Rows[0];
                    noteDetailNoteIdTextbox.Text = noteDataRow[noteDetailNoteIdFriendlyName].ToString();
                    noteDetailNoteTitleTextbox.Text = noteDataRow[noteDetailNoteTitleFriendlyName].ToString();
                    await NoteDetailLoadNoteTypeAsync((Guid)noteDataRow[noteDetailNoteTypeIdFriendlyName]);
                    noteDetailNoteTextbox.Text = noteDataRow[noteDetailModuleNoteTypeFriendlyName].ToString();
                    noteDetailCreatedByTextbox.Text = noteDataRow["Created By"].ToString();
                    noteDetailCreatedTimestampTextbox.Text = noteDataRow["Created Timestamp"].ToString();
                    noteDetailLastUpdatedByTextbox.Text = noteDataRow["Modified By"].ToString();
                    noteDetailLastUpdatedTimestampTextbox.Text = noteDataRow["Modified Timestamp"].ToString();

                    noteDetailNoteOriginalValue = noteDataRow[noteDetailModuleNoteTypeFriendlyName].ToString();
                    noteDetailNoteTitleOriginalValue = noteDataRow[noteDetailNoteTitleFriendlyName].ToString();
                    noteDetailNoteTypeIdOriginalValue = (Guid)noteDataRow[noteDetailNoteTypeIdFriendlyName];
                }
                else
                {
                    MessageBox.Show($"No data found for the specified {noteDetailModuleNoteTypeFriendlyName}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load {noteDetailModuleNoteTypeFriendlyName} details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void noteDetailUpdateNoteButton_Click(object sender, EventArgs e)
        {
            string note = noteDetailNoteTextbox.Text.TrimEnd();
            string noteTitle = noteDetailNoteTitleTextbox.Text.TrimEnd();
            Guid noteTypeId = (Guid)noteDetailNoteTypeComboBox.SelectedValue;

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
                    Name = noteDetailModuleNoteTypeName,
                    Value = note,
                    MaxLength = 4000,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = noteDetailNoteTitleName,
                    Value = noteTitle,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = noteDetailNoteTypeIdName,
                    Value = noteTypeId,
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
                        VariableName = noteDetailModuleNoteTypeFriendlyName,
                        VariableType = "string",
                        OriginalValue = noteDetailNoteOriginalValue,
                        NewValue = note
                    },
                    new ChangeDetail
                    {
                        VariableName = noteDetailNoteTitleFriendlyName,
                        VariableType = "string",
                        OriginalValue = noteDetailNoteTitleOriginalValue,
                        NewValue = noteTitle
                    },
                    new ChangeDetail
                    {
                        VariableName = noteDetailNoteTypeIdFriendlyName,
                        VariableType = "Guid",
                        OriginalValue = noteDetailNoteTypeIdOriginalValue,
                        NewValue = noteTypeId
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = UpdateConfirmation.ConfirmChanges(changesList, noteDetailModuleNoteTypeFriendlyName);

                if (confirmed)
                {
                    var parameters = new List<Parameter>();

                    switch (_moduleGroup)
                    {
                        case "CustomerManagement":
                            parameters.Add(new Parameter
                            {
                                ParameterName = "@customerNoteId",
                                ParameterValue = _noteId
                            });
                            parameters.Add(new Parameter
                            {
                                ParameterName = "@customerNoteTitle",
                                ParameterValue = noteTitle
                            });
                            parameters.Add(new Parameter
                            {
                                ParameterName = "@customerNoteTypeId",
                                ParameterValue = noteTypeId
                            });
                            break;
                        case "ProductManagement":
                            parameters.Add(new Parameter
                            {
                                ParameterName = "@productNoteId",
                                ParameterValue = _noteId
                            });
                            parameters.Add(new Parameter
                            {
                                ParameterName = "@productNoteTitle",
                                ParameterValue = noteTitle
                            });
                            parameters.Add(new Parameter
                            {
                                ParameterName = "@productNoteTypeId",
                                ParameterValue = noteTypeId
                            });
                            break;
                        case "SupplierManagement":
                            parameters.Add(new Parameter
                            {
                                ParameterName = "@supplierNoteId",
                                ParameterValue = _noteId
                            });
                            parameters.Add(new Parameter
                            {
                                ParameterName = "@supplierNoteTitle",
                                ParameterValue = noteTitle
                            });
                            parameters.Add(new Parameter
                            {
                                ParameterName = "@supplierNoteTypeId",
                                ParameterValue = noteTypeId
                            });
                            break;
                    }

                    string operationType = "update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(
                        noteDetailNoteUpdateStoredProcedureName,
                        parameters.ToArray(),
                        noteDetailModuleNoteTypeFriendlyName,
                        _databaseConnectionSettings.DatabaseConnectionString,
                        operationType
                        );
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
            ViewNoteDetailNoteInformation_Load(this, EventArgs.Empty);
        }

        private void noteDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            noteDetailNoteTextbox.ReadOnly = !noteDetailNoteTextbox.ReadOnly;
            noteDetailNoteTitleTextbox.ReadOnly = !noteDetailNoteTitleTextbox.ReadOnly;
            noteDetailNoteTypeComboBox.Enabled = !noteDetailNoteTypeComboBox.Enabled;
            noteDetailUpdateNoteButton.Enabled = !noteDetailUpdateNoteButton.Enabled;
        }
    }
}