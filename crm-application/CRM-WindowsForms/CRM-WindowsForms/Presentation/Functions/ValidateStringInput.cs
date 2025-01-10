using System.Text;

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

                if (property.Name == "EmailAddress" && !value.Contains("@"))
                {
                    validationErrors.AppendLine("Email Address must contain an '@' symbol.");
                }

                if (property.Name == "TelephoneNumber")
                {
                    if (value.Length > 13)
                    {
                        validationErrors.AppendLine($"Telephone Number cannot be longer than 13 characters. Submitted length is {value.Length} characters.");
                    }
                    else if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^\+\d{12}$"))
                    {
                        validationErrors.AppendLine("Telephone Number must start with a '+' prefix followed by exactly 12 digits.");
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