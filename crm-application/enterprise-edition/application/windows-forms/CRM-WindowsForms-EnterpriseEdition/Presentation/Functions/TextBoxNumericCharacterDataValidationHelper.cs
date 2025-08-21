namespace CRM_WindowsForms_EnterpriseEdition.Presentation.Functions
{
    internal static class TextBoxNumericCharacterDataValidationHelper
    {
        public static void NumericKeyPressHandler(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                new ErrorMessageService("Warning.DataValidation.Dynamic", "Only numeric characters allowed");
            }
        }
    }
}