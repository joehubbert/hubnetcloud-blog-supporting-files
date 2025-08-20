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
            activeCompanyConfigurationCompanyConfigurationComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
        }

        private async Task LoadCompanyConfigurationAsync()
        {
            var applicationConfigurationCompanyConfiguration = await ApplicationConfigurationService.GetCompanyConfigurationAsync();
            if (applicationConfigurationCompanyConfiguration.companyConfigurationId != null)
            {
                _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(activeCompanyConfigurationCompanyConfigurationComboBox, "spGetAllCompanyConfiguration", null, true, "Company Configuration Id", applicationConfigurationCompanyConfiguration.companyConfigurationId);
            }
            else
            {
                _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(activeCompanyConfigurationCompanyConfigurationComboBox, "spGetAllCompanyConfiguration");
            }
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDownHelper.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void activeCompanyConfigurationCompanyConfigurationButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (activeCompanyConfigurationCompanyConfigurationComboBox.SelectedValue is Guid companyConfigurationId)
                {
                    var selectedItem = activeCompanyConfigurationCompanyConfigurationComboBox.SelectedItem;
                    string companyName = (string)selectedItem.GetType().GetProperty("CompanyName")?.GetValue(selectedItem)!;

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