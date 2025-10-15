using System.Data;

namespace CRM.Model
{
    internal class StoredProcedureParameter
    {
        public ParameterDirection ParameterDirection { get; set; } = ParameterDirection.Input;
        public string ParameterName { get; set; } = string.Empty;
        public object? ParameterValue { get; set; }
        public int MaxLength { get; set; } = 0;
    }
}