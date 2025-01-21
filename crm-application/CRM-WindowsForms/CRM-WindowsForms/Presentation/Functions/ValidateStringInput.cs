using System.Text;
using System.Text.RegularExpressions;

namespace CRM_WindowsForms.Presentation.Functions
{
    public static class ValidateStringInput
    {
        public class ValidationResult
        {
            public bool IsValid { get; set; }
            public string ErrorMessage { get; set; } = string.Empty;
        }

        public class StringProperty
        {
            public string Name { get; set; } = string.Empty;
            public string Value { get; set; } = string.Empty;
            public int MaxLength { get; set; }
        }

        public static ValidationResult ValidateInput(IEnumerable<StringProperty> stringsToValidate)
        {
            StringBuilder validationErrors = new StringBuilder();

            foreach (var property in stringsToValidate)
            {
                string value = property.Value.TrimEnd();

                if (value.Length > property.MaxLength)
                {
                    validationErrors.AppendLine($"{property.Name} cannot be longer than {property.MaxLength} characters. Submitted length is {value.Length} characters.");
                }

                if (property.Name.Contains("EmailAddress"))
                {
                    if (!value.Contains("@"))
                    {
                        validationErrors.AppendLine("Email Address must contain an '@' symbol.");
                    }
                    if (value.Length > 50)
                    {
                        validationErrors.AppendLine("Email Address cannot be longer than 50 characters.");
                    }
                }

                if (property.Name.Contains("TelephoneNumber"))
                {
                    if (value.Length > 13)
                    {
                        validationErrors.AppendLine($"Telephone Number cannot be longer than 13 characters. Submitted length is {value.Length} characters.");
                    }
                    else if (!Regex.IsMatch(value, @"^\+\d{12}$"))
                    {
                        validationErrors.AppendLine("Telephone Number must start with a '+' prefix followed by exactly 12 digits.");
                    }
                }

                if (property.Name.Contains("Numeric"))
                {
                    if (!Regex.IsMatch(value, @"^\d+$"))
                    {
                        validationErrors.AppendLine($"{property.Name} must contain only numeric characters.");
                    }
                }

                if (property.Name.Contains("Decimal"))
                {
                    if (!decimal.TryParse(value, out _))
                    {
                        validationErrors.AppendLine($"{property.Name} must be a valid decimal number.");
                    }
                }

                if (SQLInjectionRiskCheck.ContainsSqlInjectionRisk(value))
                {
                    validationErrors.AppendLine($"{property.Name} contains potentially dangerous characters that could lead to SQL injection.");
                }
            }

            if (validationErrors.Length > 0)
            {
                MessageBox.Show(validationErrors.ToString(), "Validation Error: ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new ValidationResult
                {
                    IsValid = false,
                    ErrorMessage = validationErrors.ToString()
                };
            }

            return new ValidationResult { IsValid = true };
        }
    }
}