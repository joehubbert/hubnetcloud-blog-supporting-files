using CRM_WindowsForms_EnterpriseEdition.Services;

namespace CRM_WindowsForms_EnterpriseEdition.Helpers
{
    internal class DelimeterLabelHelper
    {
        public static async Task SetLabelToDelimeterAsync(Label label)
        {
            if (label == null)
                throw new ArgumentNullException(nameof(label));

            string delimeter = await ApplicationConfigurationService.GetDelimeterAsync();

            if (label.InvokeRequired)
            {
                label.Invoke(() => label.Text = delimeter);
            }
            else
            {
                label.Text = delimeter;
            }
        }
    }
}