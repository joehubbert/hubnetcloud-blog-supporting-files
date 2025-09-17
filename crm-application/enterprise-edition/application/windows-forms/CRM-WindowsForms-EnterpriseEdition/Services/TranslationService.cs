using CRM.Model;

namespace CRM.Services
{
    internal class TranslationService
    {
        private TranslationDictionaryModel _translationDictionaryModel = new();

        private Dictionary<string, Dictionary<string, string>> LanguageDictionaries => new()
        {
            ["cs-CZ"] = _translationDictionaryModel.csCZ,
            ["da-DK"] = _translationDictionaryModel.daDK,
            ["de-DE"] = _translationDictionaryModel.deDE,
            ["es-ES"] = _translationDictionaryModel.esES,
            ["fi"] = _translationDictionaryModel.fi,
            ["fr-FR"] = _translationDictionaryModel.frFR,
            ["it-IT"] = _translationDictionaryModel.itIT,
            ["ja-JP"] = _translationDictionaryModel.jaJP,
            ["ko"] = _translationDictionaryModel.ko,
            ["nb-NO"] = _translationDictionaryModel.nbNO,
            ["nl-NL"] = _translationDictionaryModel.nlNL,
            ["pl-PL"] = _translationDictionaryModel.plPL,
            ["pt-PT"] = _translationDictionaryModel.ptPT,
            ["sv-SE"] = _translationDictionaryModel.svSE,
            ["zh"] = _translationDictionaryModel.zh
        };

        private Dictionary<string, string>? GetDictionary(string languageCode)
        {
            return LanguageDictionaries.TryGetValue(languageCode, out var dictionary) ? dictionary : null;
        }

        public string Translate(object input, string targetLanguageCode)
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

        public string TranslateString(string inputString, string targetLanguageCode)
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