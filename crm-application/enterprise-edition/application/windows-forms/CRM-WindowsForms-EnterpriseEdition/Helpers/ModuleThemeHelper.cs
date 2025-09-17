using CRM.Services;

namespace CRM.Helpers
{
    internal static class ModuleThemeHelper
    {
        public static void ApplyTheme(Form targetForm, string moduleGroup)
        {
            switch (moduleGroup)
            {
                case "CompanyManagement":
                    targetForm.BackColor = Color.LemonChiffon;
                    break;
                case "CustomerManagement":
                    targetForm.BackColor = Color.LightGreen;
                    break;
                case "MarketingManagement":
                    targetForm.BackColor = Color.NavajoWhite;
                    break;
                case "OrderManagement":
                    targetForm.BackColor = Color.LightSalmon;
                    break;
                case "ProductManagement":
                    targetForm.BackColor = Color.SkyBlue;
                    break;
                case "SupplierManagement":
                    targetForm.BackColor = Color.MediumAquamarine;
                    break;
                default:
                    new ErrorMessageService("Error.Module.NotImplemented", moduleGroup);
                    break;
            }
        }
    }
}