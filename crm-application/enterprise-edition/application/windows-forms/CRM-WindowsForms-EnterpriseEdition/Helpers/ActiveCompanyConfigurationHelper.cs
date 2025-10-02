using CRM.Model;
using CRM.Presentation.CompanyManagement.CompanyConfiguration;
using CRM.Services;

namespace CRM.Helpers
{
    internal class ActiveCompanyConfigurationHelper
    {
        private ToolStripSplitButton _placeholderControl;
        private Guid _companyConfigurationId;
        private string _companyName;
        private TranslationService _translationService = new TranslationService();
        private UIModelHelper _uiModelHelper = new UIModelHelper();
        private LanguageRegionCode activeLanguageRegionCode;
        public Guid CompanyConfigurationId => _companyConfigurationId;

        public ActiveCompanyConfigurationHelper(ToolStripSplitButton placeholderControl)
        {
            _placeholderControl = placeholderControl;
        }

        private async void GetActiveLanguageRegionCode()
        {
            activeLanguageRegionCode = await ApplicationConfigurationService.GetLanguageRegionCodeAsync();
        }

        public async Task LoadAsync()
        {
            GetActiveLanguageRegionCode();

            var companyConfiguration = await ApplicationConfigurationService.GetCompanyConfigurationAsync();
            if (companyConfiguration == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Warning.CompanyConfiguration.NoData");
                return;
            }

            // Check if companyConfigurationId is empty GUID
            if (companyConfiguration.companyConfigurationId == Guid.Empty)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Warning.CompanyConfiguration.NoData");
                return;
            }

            // Check if companyName is empty or null
            if (string.IsNullOrWhiteSpace(companyConfiguration.companyName))
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Warning.CompanyConfiguration.NoData");
                return;
            }

            _companyConfigurationId = companyConfiguration.companyConfigurationId;
            _companyName = companyConfiguration.companyName;
            FunctionTitle functionTitle = FunctionTitle.CompanyConfiguration;

            var dataSubjectProperties = _uiModelHelper.GetDataSubjectProperties(functionTitle);
            if (dataSubjectProperties == null)
            {
                // Instead of showing error, let's just use a default display
                string displayText = $"Company: {_companyName} ({_companyConfigurationId})";
                _placeholderControl.Text = displayText;
                return;
            }

            if (dataSubjectProperties.DataParentSubject == null)
            {
                // Instead of showing error, let's just use a default display
                string displayText = $"Company: {_companyName} ({_companyConfigurationId})";
                _placeholderControl.Text = displayText;
                return;
            }

            string prefix = dataSubjectProperties.DataSubject.DataSubjectFriendlyName;

            if (activeLanguageRegionCode != LanguageRegionCode.enGB)
            {
                prefix = _translationService.Translate(prefix, activeLanguageRegionCode);
            }

            string finalDisplayText = $"{prefix}: {_companyName} ({_companyConfigurationId})";
            _placeholderControl.Text = finalDisplayText;
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