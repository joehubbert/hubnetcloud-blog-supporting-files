namespace CRM_WindowsForms_EnterpriseEdition.Helpers
{
    internal class TextBoxCleanerHelper
    {
        public static string GetTrimmedText(Control control)
        {
            if (control is TextBox textBox)
                return textBox.Text.TrimEnd();

            if (control is MaskedTextBox maskedTextBox)
                return maskedTextBox.Text.TrimEnd();

            return string.Empty;
        }
    }
}