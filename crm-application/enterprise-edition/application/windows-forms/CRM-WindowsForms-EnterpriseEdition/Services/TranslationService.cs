using CRM.Model;

namespace CRM.Services
{
    internal class TranslationService
    {
        private TranslationDictionaryModel _translationDictionaryModel = new();

        private Dictionary<RegionLanguageCode, Dictionary<string, string>> LanguageDictionaries => new()
        {
            [RegionLanguageCode.czCZ] = _translationDictionaryModel.csCZ,
            [RegionLanguageCode.daDK] = _translationDictionaryModel.daDK,
            [RegionLanguageCode.deDE] = _translationDictionaryModel.deDE,
            [RegionLanguageCode.esES] = _translationDictionaryModel.esES,
            [RegionLanguageCode.fi] = _translationDictionaryModel.fi,
            [RegionLanguageCode.frFR] = _translationDictionaryModel.frFR,
            [RegionLanguageCode.itIT] = _translationDictionaryModel.itIT,
            [RegionLanguageCode.jaJP] = _translationDictionaryModel.jaJP,
            [RegionLanguageCode.ko] = _translationDictionaryModel.ko,
            [RegionLanguageCode.nbNO] = _translationDictionaryModel.nbNO,
            [RegionLanguageCode.nlNL] = _translationDictionaryModel.nlNL,
            [RegionLanguageCode.plPL] = _translationDictionaryModel.plPL,
            [RegionLanguageCode.ptPT] = _translationDictionaryModel.ptPT,
            [RegionLanguageCode.svSE] = _translationDictionaryModel.svSE,
            [RegionLanguageCode.zh] = _translationDictionaryModel.zh
        };

        private Dictionary<string, string>? GetDictionary(RegionLanguageCode languageCode)
        {
            return LanguageDictionaries.TryGetValue(languageCode, out var dictionary) ? dictionary : null;
        }

        public string Translate(object input, RegionLanguageCode targetLanguageCode)
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

        public string TranslateString(string inputString, RegionLanguageCode targetLanguageCode)
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