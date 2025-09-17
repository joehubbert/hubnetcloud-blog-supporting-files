namespace CRM.Helpers
{
    internal class TextBoxCharactersRemainingHelper : IDisposable
    {
        private readonly Label _label;
        private readonly int _maximumLength;
        private readonly TextBox _textBox;
        private readonly Color _originalForeColor;
        private readonly Font _originalFont;
        private Font? _boldAlertFont;
        private bool _disposed;

        public TextBoxCharactersRemainingHelper(Label label, TextBox textBox)
        {
            _label = label ?? throw new ArgumentNullException(nameof(label));
            _textBox = textBox ?? throw new ArgumentNullException(nameof(textBox));
            _maximumLength = _textBox.MaxLength > 0 ? _textBox.MaxLength : int.MaxValue;

            _originalForeColor = _label.ForeColor;
            _originalFont = _label.Font;

            _label.Visible = false;

            _textBox.TextChanged += (_, _) => UpdateLabel();
            _textBox.Enter += (_, _) => ShowLabel();
            _textBox.Leave += (_, _) => HideLabel();
        }

        private void HideLabel() => _label.Visible = false;

        private void ShowLabel()
        {
            UpdateLabel();
            _label.Visible = true;
        }

        private void UpdateLabel()
        {
            int currentLength = _textBox.Text.Length;
            _label.Text = $"{currentLength}/{_maximumLength}";

            bool atLimit = currentLength == _maximumLength;

            if (atLimit)
            {
                // Create the bold font once, re-use it
                _boldAlertFont ??= new Font(_originalFont, _originalFont.Style | FontStyle.Bold);

                if (!ReferenceEquals(_label.Font, _boldAlertFont))
                    _label.Font = _boldAlertFont;

                if (_label.ForeColor != Color.Red)
                    _label.ForeColor = Color.Red;
            }
            else
            {
                // Restore original styling if it was changed
                if (!ReferenceEquals(_label.Font, _originalFont))
                    _label.Font = _originalFont;

                if (_label.ForeColor != _originalForeColor)
                    _label.ForeColor = _originalForeColor;
            }
        }

        public void Dispose()
        {
            if (_disposed) return;
            _boldAlertFont?.Dispose();
            _disposed = true;
        }
    }
}