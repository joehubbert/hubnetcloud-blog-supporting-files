namespace CRM.Helpers
{
    internal class SQLInjectionRiskHelper
    {
        public static bool ContainsSqlInjectionRisk(string input)
        {
            string[] sqlInjectionRiskCharacters = { "--", ";--", ";", "/*", "*/", "@@" };
            foreach (var riskChar in sqlInjectionRiskCharacters)
            {
                if (input.Contains(riskChar))
                {
                    return true;
                }
            }
            return false;
        }
    }
}