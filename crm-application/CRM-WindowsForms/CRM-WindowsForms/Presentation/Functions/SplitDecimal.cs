namespace CRM_WindowsForms.Presentation.Functions
{
    public static class SplitDecimal
    {
        public static void SplitDecimalUsingDelimiter(decimal decimalValue, out string partA, out string partB)
        {
            string[] parts = decimalValue.ToString().Split('.');
            partA = parts[0];
            partB = parts.Length > 1 ? parts[1] : "0";
        }
    }
}