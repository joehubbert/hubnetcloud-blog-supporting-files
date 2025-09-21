using CRM.Model;
using CRM.Services;

namespace CRM.Helpers
{
    internal static class ModuleThemeHelper
    {
        public static void ApplyTheme(Form targetForm, ModuleGroup moduleGroup)
        {
            switch (moduleGroup)
            {
                case ModuleGroup.CompanyManagement:
                    targetForm.BackColor = Color.LemonChiffon;
                    break;
                case ModuleGroup.CustomerManagement:
                    targetForm.BackColor = Color.LightGreen;
                    break;
                case ModuleGroup.MarketingManagement:
                    targetForm.BackColor = Color.NavajoWhite;
                    break;
                case ModuleGroup.OrderManagement:
                    targetForm.BackColor = Color.LightSalmon;
                    break;
                case ModuleGroup.ProductManagement:
                    targetForm.BackColor = Color.SkyBlue;
                    break;
                case ModuleGroup.SupplierManagement:
                    targetForm.BackColor = Color.MediumAquamarine;
                    break;
                default:
                    new ErrorMessageService("Error.Module.NotImplemented", moduleGroup.ToString());
                    break;
            }
        }
    }
}