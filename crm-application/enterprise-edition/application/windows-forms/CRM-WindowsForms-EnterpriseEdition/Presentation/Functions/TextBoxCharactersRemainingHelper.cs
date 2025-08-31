namespace CRM_WindowsForms_EnterpriseEdition.Presentation.Functions
{
    internal class TextBoxCharactersRemainingHelper
    {
        private readonly Label _label;
        private readonly int _maximumLength;
        private readonly TextBox _textBox;
        private readonly TranslationService _translationService;
        private string activeRegionLanguageCode;
        private string characterUsage;

        public TextBoxCharactersRemainingHelper(Label label, TextBox textBox)
        {
            GetActiveRegionLanguageCode();

            _label = label ?? throw new ArgumentNullException(nameof(label));
            _textBox = textBox ?? throw new ArgumentNullException(nameof(textBox));
            _maximumLength = _textBox.MaxLength > 0 ? _textBox.MaxLength : int.MaxValue;

            // Hide label initially
            _label.Visible = false;

            // Subscribe to events
            _textBox.TextChanged += (sender, e) => UpdateLabel();
            _textBox.Enter += (sender, e) => ShowLabel();
            _textBox.Leave += (sender, e) => HideLabel();
        }

        private async void GetActiveRegionLanguageCode()
        {
            activeRegionLanguageCode = await ApplicationConfigurationService.GetRegionLanguageCodeAsync();
            if (activeRegionLanguageCode != "en-GB")
            {
                characterUsage = _translationService.Translate("characters used", activeRegionLanguageCode);
            }
            else
            {
                characterUsage = "characters used";
            }
        }

        private void HideLabel()
        {
            _label.Visible = false;
        }

        private void ShowLabel()
        {
            UpdateLabel();
            _label.Visible = true;
        }

        private void UpdateLabel()
        {
            int currentLength = _textBox.Text.Length;
            _label.Text = $"{currentLength}/{_maximumLength} {characterUsage}";
        }
    }
}