namespace CRM_WindowsForms_EnterpriseEdition.Presentation.Functions
{
    internal class TextBoxNumericCharacterDataValidationHelper
    {
        private readonly TranslationService _translationService;
        private string activeRegionLanguageCode;
        private string errorText;

        private async Task UpdateActiveRegionLanguageCodeAndErrorText()
        {
            activeRegionLanguageCode = await ApplicationConfigurationService.GetRegionLanguageCodeAsync();
            if (activeRegionLanguageCode != "en-GB")
            {
                errorText = _translationService.Translate("Only numeric characters allowed.", activeRegionLanguageCode);
            }
            else
            {
                errorText = "Only numeric characters allowed.";
            }
        }

        public async Task NumericKeyPressHandlerAsync(object? sender, KeyPressEventArgs e)
        {
            activeRegionLanguageCode = await ApplicationConfigurationService.GetRegionLanguageCodeAsync();
            if (activeRegionLanguageCode != "en-GB")
            {
                errorText = _translationService.Translate("Only numeric characters allowed.", activeRegionLanguageCode);
            }
            else
            {
                errorText = "Only numeric characters allowed.";
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