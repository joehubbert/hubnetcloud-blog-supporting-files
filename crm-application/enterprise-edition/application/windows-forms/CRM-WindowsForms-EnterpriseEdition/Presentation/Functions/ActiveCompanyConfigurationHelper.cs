namespace CRM_WindowsForms_EnterpriseEdition.Presentation.Functions
{
    internal class ActiveCompanyConfigurationHelper
    {
        private ToolStripSplitButton _placeholderControl;
        private Guid _companyConfigurationId;
        private string _companyName;
        private readonly TranslationService _translationService;
        private string activeRegionLanguageCode;
        public Guid CompanyConfigurationId => _companyConfigurationId;

        public ActiveCompanyConfigurationHelper(ToolStripSplitButton placeholderControl)
        {
            _placeholderControl = placeholderControl;
        }

        private async void GetActiveRegionLanguageCode()
        {
            activeRegionLanguageCode = await ApplicationConfigurationService.GetRegionLanguageCodeAsync();
        }

        public async Task LoadAsync()
        {
            GetActiveRegionLanguageCode();

            var companyConfiguration = await ApplicationConfigurationService.GetCompanyConfigurationAsync();
            if (companyConfiguration == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Warning.CompanyConfiguration.NoData");
                return;
            }
            else
            {
                _companyConfigurationId = companyConfiguration.companyConfigurationId;
                _companyName = companyConfiguration.companyName;

                string prefix;

                if (activeRegionLanguageCode != "en-GB")
                {
                    prefix = _translationService.Translate("Company Configuration", activeRegionLanguageCode);
                }
                else
                {
                    prefix = "Company Configuration";
                }

                string displayText = $"{prefix}: {_companyName} ({_companyConfigurationId})";
                _placeholderControl.Text = displayText;
            }
        }

        public async Task ShowChangeDialogAndReloadAsync(Form parentForm)
        {
            var previousCompanyConfigurationId = _companyConfigurationId;
            using (var activeCompanyConfiguration = new ActiveCompanyConfiguration())
            {
                activeCompanyConfiguration.ShowDialog(parentForm);
            }

            var currentCompanyConfiguration = await ApplicationConfigurationService.GetCompanyConfigurationAsync();
            if (currentCompanyConfiguration != null && currentCompanyConfiguration.companyConfigurationId != previousCompanyConfigurationId)
            {
                _companyConfigurationId = currentCompanyConfiguration.companyConfigurationId;
                _companyName = currentCompanyConfiguration.companyName;
                await LoadAsync();
            }
        }
    }
}