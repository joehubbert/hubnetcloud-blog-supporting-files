using CRM_WindowsForms_EnterpriseEdition.Model;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class ActiveCompanyConfiguration : Form
    {
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;

        public ActiveCompanyConfiguration()
        {
            InitializeComponent();
            InitializeEventHandlers();
            LoadCompanyConfigurationAsync();
        }

        private void InitializeEventHandlers()
        {
            activeCompanyConfigurationCompanyConfigurationComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
        }

        private async Task LoadCompanyConfigurationAsync()
        {
            var applicationConfigurationCompanyConfiguration = await ApplicationConfigurationService.GetCompanyConfigurationAsync();
            if (applicationConfigurationCompanyConfiguration.companyConfigurationId != null)
            {
                _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(activeCompanyConfigurationCompanyConfigurationComboBox, "spGetAllCompanyConfiguration", applicationConfigurationCompanyConfiguration.companyConfigurationId);
            }
            else
            {
                _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(activeCompanyConfigurationCompanyConfigurationComboBox, "spGetAllCompanyConfiguration");
            }
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async void activeCompanyConfigurationCompanyConfigurationButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (activeCompanyConfigurationCompanyConfigurationComboBox.SelectedValue is Guid companyConfigurationId)
                {
                    var selectedItem = activeCompanyConfigurationCompanyConfigurationComboBox.SelectedItem;
                    string companyName = string.Empty;

                    var columnsProperty = selectedItem?.GetType().GetProperty("Columns");
                    var columns = columnsProperty?.GetValue(selectedItem) as Dictionary<string, object>;
                    if (columns != null && columns.TryGetValue("Company Name", out var value))
                    {
                        companyName = value?.ToString() ?? string.Empty;
                    }

                    var companyConfiguration = new ApplicationConfigurationModel.ApplicationConfigurationServiceCompanyConfiguration
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
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Validation.InvalidValue", "Company Configuration");
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", "Company Configuration", ex.Message);
            }
        }
    }
}