using CRM.Model;
using CRM.Services;

namespace CRM.Helpers
{
    internal class TextBoxNumericCharacterDataValidationHelper
    {
        private TranslationService _translationService;
        private LanguageRegionCode activeLanguageRegionCode;
        private string errorText = "Only numeric characters allowed";

        private async Task UpdateActiveLanguageRegionCodeAndErrorText()
        {
            _translationService = new TranslationService();

            activeLanguageRegionCode = await ApplicationConfigurationService.GetLanguageRegionCodeAsync();
            if (activeLanguageRegionCode != LanguageRegionCode.enGB)
            {
                errorText = _translationService.Translate(errorText, activeLanguageRegionCode);
            }
        }

        public async Task NumericKeyPressHandlerAsync(object? sender, KeyPressEventArgs e)
        {
            _translationService = new TranslationService();

            activeLanguageRegionCode = await ApplicationConfigurationService.GetLanguageRegionCodeAsync();
            if (activeLanguageRegionCode != LanguageRegionCode.enGB)
            {
                errorText = _translationService.Translate(errorText, activeLanguageRegionCode);
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                new ErrorMessageService("Warning.Data.Validation.Dynamic", errorText);
            }
        }

        public void NumericKeyPressHandler(object? sender, KeyPressEventArgs e)
        {
            UpdateActiveLanguageRegionCodeAndErrorText();

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                new ErrorMessageService("Warning.Data.Validation.Dynamic", errorText);
            }
        }
    }
}