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
            LoadCompanyConfigurationAsync();
        }

        private async Task LoadCompanyConfigurationAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Company Configuration";
            string storedProcedureName = "[dbo].[spGetAllCompanyConfiguration]";

            try
            {
                DataTable? companyConfigurationData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var companyConfigurationList = companyConfigurationData.AsEnumerable()
                    .Select(row => new
                    {
                        CompanyConfigurationId = row.Field<Guid>("Company Configuration Id"),
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
                    var applicationConfigurationCompanyConfigurationId = await ApplicationConfigurationService.GetCompanyConfigurationIdAsync();

                    // Only set SelectedValue if it exists in the list
                    var exists = companyConfigurationList.Any(x => x.CompanyConfigurationId == applicationConfigurationCompanyConfigurationId);
                    if (exists && applicationConfigurationCompanyConfigurationId != Guid.Empty)
                    {
                        activeCompanyConfigurationCompanyConfigurationComboBox.SelectedValue = applicationConfigurationCompanyConfigurationId;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async void activeCompanyConfigurationCompanyConfigurationButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (activeCompanyConfigurationCompanyConfigurationComboBox.SelectedValue is Guid selectedId)
                {
                    ApplicationConfigurationService.CompanyConfigurationId = selectedId;
                    await ApplicationConfigurationService.SetCompanyConfigurationIdAsync(selectedId);
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