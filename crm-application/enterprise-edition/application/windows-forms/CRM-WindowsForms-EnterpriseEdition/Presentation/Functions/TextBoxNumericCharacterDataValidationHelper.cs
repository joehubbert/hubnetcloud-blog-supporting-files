namespace CRM_WindowsForms_EnterpriseEdition.Presentation.Functions
{
    internal class TextBoxNumericCharacterDataValidationHelper
    {
        private TranslationService _translationService;
        private string activeRegionLanguageCode;
        private string errorText = "Only numeric characters allowed";

        private async Task UpdateActiveRegionLanguageCodeAndErrorText()
        {
            _translationService = new TranslationService();

            activeRegionLanguageCode = await ApplicationConfigurationService.GetRegionLanguageCodeAsync();
            if (activeRegionLanguageCode != "en-GB")
            {
                errorText = _translationService.Translate(errorText, activeRegionLanguageCode);
            }
        }

        public async Task NumericKeyPressHandlerAsync(object? sender, KeyPressEventArgs e)
        {
            _translationService = new TranslationService();

            activeRegionLanguageCode = await ApplicationConfigurationService.GetRegionLanguageCodeAsync();
            if (activeRegionLanguageCode != "en-GB")
            {
                errorText = _translationService.Translate(errorText, activeRegionLanguageCode);
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                new ErrorMessageService("Warning.DataValidation.Dynamic", errorText);
            }
        }

        public void NumericKeyPressHandler(object? sender, KeyPressEventArgs e)
        {
            UpdateActiveRegionLanguageCodeAndErrorText();

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                new ErrorMessageService("Warning.DataValidation.Dynamic", errorText);
            }
        }
    }
}