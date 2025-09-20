namespace CRM.Model
{


    public class MeasurementConversionModel
    {
        public MeasurementType MeasurementType { get; set; }
        public string? PropertyName { get; set; }
        public Action<decimal>? SetValue;
        public decimal Value;
    }
}