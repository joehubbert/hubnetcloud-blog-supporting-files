using CRM.Model;

namespace CRM.Services
{
    internal class TranslationService
    {
        private TranslationDictionaryModel _translationDictionaryModel = new();

        private Dictionary<LanguageRegionCode, Dictionary<string, string>> LanguageDictionaries => new()
        {
            [LanguageRegionCode.czCZ] = _translationDictionaryModel.csCZ,
            [LanguageRegionCode.daDK] = _translationDictionaryModel.daDK,
            [LanguageRegionCode.deDE] = _translationDictionaryModel.deDE,
            [LanguageRegionCode.esES] = _translationDictionaryModel.esES,
            [LanguageRegionCode.fi] = _translationDictionaryModel.fi,
            [LanguageRegionCode.frFR] = _translationDictionaryModel.frFR,
            [LanguageRegionCode.itIT] = _translationDictionaryModel.itIT,
            [LanguageRegionCode.jaJP] = _translationDictionaryModel.jaJP,
            [LanguageRegionCode.ko] = _translationDictionaryModel.ko,
            [LanguageRegionCode.nbNO] = _translationDictionaryModel.nbNO,
            [LanguageRegionCode.nlNL] = _translationDictionaryModel.nlNL,
            [LanguageRegionCode.plPL] = _translationDictionaryModel.plPL,
            [LanguageRegionCode.ptPT] = _translationDictionaryModel.ptPT,
            [LanguageRegionCode.svSE] = _translationDictionaryModel.svSE,
            [LanguageRegionCode.zh] = _translationDictionaryModel.zh
        };

        private Dictionary<string, string>? GetDictionary(LanguageRegionCode languageCode)
        {
            return LanguageDictionaries.TryGetValue(languageCode, out var dictionary) ? dictionary : null;
        }

        public string Translate(object input, LanguageRegionCode targetLanguageCode)
        {
            string originalText = input switch
            {
                Control control => control.Text,
                string str => str,
                _ => throw new ArgumentException("Input must be a Control or a string.")
            };

            bool hasTrailingAsterisk = originalText.EndsWith("*");
            string lookupText = hasTrailingAsterisk ? originalText.TrimEnd('*').TrimEnd() : originalText;

            var dict = GetDictionary(targetLanguageCode);
            string translated;

            if (dict != null && dict.TryGetValue(lookupText, out var value))
            {
                translated = value;
            }
            else
            {
                // Fallback to input text if not found in dictionary
                translated = originalText;
            }

            if (hasTrailingAsterisk && !translated.EndsWith("*"))
                translated = $"{translated}*";

            if (input is Control controlInput)
            {
                controlInput.Text = translated;
                return translated;
            }
            else
            {
                return translated;
            }
        }

        public string TranslateString(string inputString, LanguageRegionCode targetLanguageCode)
        {
            bool hasTrailingAsterisk = inputString.EndsWith("*");
            string lookupText = hasTrailingAsterisk ? inputString.TrimEnd('*').TrimEnd() : inputString;

            var dict = GetDictionary(targetLanguageCode);
            string translated;

            if (dict != null && dict.TryGetValue(lookupText, out var value))
            {
                translated = value;
            }
            else
            {
                // Fallback to input text if not found in dictionary
                translated = inputString;
            }

            if (hasTrailingAsterisk && !translated.EndsWith("*"))
                translated = $"{translated}*";

            return translated;
        }
    }
}