namespace CRM.Helpers
{
    public class NumericParserHelper
    {
        public decimal? ParseDecimal(TextBox textBoxA, TextBox textBoxB)
        {
            var partA = TextBoxCleanerHelper.GetTrimmedText(textBoxA);
            var partB = TextBoxCleanerHelper.GetTrimmedText(textBoxB);

            if (string.IsNullOrWhiteSpace(partA) || string.IsNullOrWhiteSpace(partB))
                return null;

            if (decimal.TryParse($"{partA}.{partB}", out decimal result))
                return result;

            return null;
        }

        public int? ParseInt(TextBox textBox)
        {
            var text = TextBoxCleanerHelper.GetTrimmedText(textBox);
            if (string.IsNullOrWhiteSpace(text))
                return null;

            if (int.TryParse(text, out int result))
                return result;

            return null;
        }
    }
}