using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class ActiveCompanyConfiguration : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private string? activeCompanyConfiguration;

        public ActiveCompanyConfiguration()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadCompanyConfigurationAsync();
        }

        private void InitializeCustomComponents()
        {
            activeCompanyConfigurationCompanyConfigurationComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
        }

        private async Task LoadCompanyConfigurationAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Company Configuration";
            string storedProcedureName = "spGetAllCompanyConfiguration";

            try
            {
                DataTable? companyConfigurationData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject);

                var companyConfigurationList = companyConfigurationData.AsEnumerable()
                    .Select(row => new
                    {
                        CompanyConfigurationId = row.Field<Guid>("Company Configuration Id"),
                        CompanyName = row.Field<string>("Company Name"),
                        DisplayText = $"{row.Field<string>("Company Name")} ({row.Field<Guid>("Company Configuration Id")})"
                    })
                    .OrderBy(item => item.DisplayText)
                    .ToList();

                activeCompanyConfigurationCompanyConfigurationComboBox.DataSource = companyConfigurationList;
                activeCompanyConfigurationCompanyConfigurationComboBox.DisplayMember = "DisplayText";
                activeCompanyConfigurationCompanyConfigurationComboBox.ValueMember = "CompanyConfigurationId";

                // Disable button if no items
                activeCompanyConfigurationCompanyConfigurationButton.Enabled = companyConfigurationList.Count > 0;

                if (companyConfigurationList.Count == 0)
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Warning.CompanyConfiguration.NoData");
                }
                else
                {
                    var applicationConfigurationCompanyConfiguration = await ApplicationConfigurationService.GetCompanyConfigurationAsync();

                    // Only set SelectedValue if it exists in the list
                    var exists = companyConfigurationList.Any(x => x.CompanyConfigurationId == applicationConfigurationCompanyConfiguration.companyConfigurationId);
                    if (exists && applicationConfigurationCompanyConfiguration.companyConfigurationId != Guid.Empty)
                    {
                        activeCompanyConfigurationCompanyConfigurationComboBox.SelectedValue = applicationConfigurationCompanyConfiguration.companyConfigurationId;
                    }
                }
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

        private async void activeCompanyConfigurationCompanyConfigurationButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (activeCompanyConfigurationCompanyConfigurationComboBox.SelectedValue is Guid companyConfigurationId)
                {
                    var selectedItem = activeCompanyConfigurationCompanyConfigurationComboBox.SelectedItem;
                    string companyName = (string)selectedItem.GetType().GetProperty("CompanyName")?.GetValue(selectedItem)!;

                    var companyConfiguration = new ApplicationConfigurationServiceCompanyConfiguration
                    {
                        companyConfigurationId = companyConfigurationId,
                        companyName = companyName
                    };
                    await ApplicationConfigurationService.SetCompanyConfigurationAsync(companyConfiguration);
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.CompanyConfiguration.ActiveCompanyConfiguration.Saved", activeCompanyConfigurationCompanyConfigurationComboBox.Text);
                    this.Close();
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.DataValidation.InvalidValue", "Company Configuration");
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", "Company Configuration", ex.Message);
            }
        }
    }
}