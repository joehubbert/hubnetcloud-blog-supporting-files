namespace CRM.Model
{
    public class MeasurementConversionModel
    {
        public string MeasurementType = string.Empty;
        public string? PropertyName { get; set; }
        public Action<decimal>? SetValue;
        public decimal Value;
    }
}