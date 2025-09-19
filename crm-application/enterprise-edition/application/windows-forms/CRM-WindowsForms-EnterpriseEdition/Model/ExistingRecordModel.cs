namespace CRM.Model
{
    public class ExistingRecordModel
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedTimestampUTC { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedTimestampUTC { get; set; }
    }
}