namespace CRM.Model
{
    public class MeasurementConversionModel
    {
        public string MeasurementType = string.Empty;
        public Action<decimal>? SetValue;
        public decimal Value;
    }
}