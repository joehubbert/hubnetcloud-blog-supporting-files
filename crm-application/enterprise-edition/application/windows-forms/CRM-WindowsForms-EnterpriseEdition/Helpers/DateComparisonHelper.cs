using CRM_WindowsForms_EnterpriseEdition.Services;

namespace CRM_WindowsForms_EnterpriseEdition.Helpers
{
    internal class DateComparisonHelper
    {
        public static void ValidateEffectiveAndExpiryDates(DateTimePicker effectiveDatePicker, DateTimePicker expiryDatePicker)
        {
            DateTime effectiveDate = effectiveDatePicker.Value.Date;
            DateTime expiryDate = expiryDatePicker.Value.Date;
            if (expiryDate <= effectiveDate)
            {
                var errorMessageService = new ErrorMessageService("Warning.DataValidation.EffectiveDateValidation");
                return;
            }
        }
    }
}