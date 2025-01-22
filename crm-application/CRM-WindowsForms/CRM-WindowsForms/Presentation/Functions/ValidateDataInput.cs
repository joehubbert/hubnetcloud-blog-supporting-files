using System;
using System.Text;
using System.Text.RegularExpressions;

namespace CRM_WindowsForms.Presentation.Functions
{
    public static class ValidateDataInput
    {
        public class ValidationResult
        {
            public bool IsValid { get; set; }
            public string ErrorMessage { get; set; } = string.Empty;
        }

        public class DataProperty
        {
            public string Name { get; set; } = string.Empty;
            public object Value { get; set; } = string.Empty;
            public int MaxLength { get; set; } = 0;
            public Type ValueType { get; set; } = typeof(string);
        }

        public static ValidationResult ValidateInput(IEnumerable<DataProperty> dataToValidate)
        {
            StringBuilder validationErrors = new StringBuilder();

            foreach (var property in dataToValidate)
            {
                string value = property.Value.ToString().TrimEnd();

                if (property.ValueType == typeof(string))
                {
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
                }
                else if (property.ValueType == typeof(int))
                {
                    if (!int.TryParse(value, out _))
                    {
                        validationErrors.AppendLine($"{property.Name} must be a valid integer.");
                    }
                }
                else if (property.ValueType == typeof(decimal))
                {
                    if (!decimal.TryParse(value, out _))
                    {
                        validationErrors.AppendLine($"{property.Name} must be a valid decimal number.");
                    }
                }
                else if (property.ValueType == typeof(byte))
                {
                    if (!byte.TryParse(value, out _))
                    {
                        validationErrors.AppendLine($"{property.Name} must be a valid byte.");
                    }
                }
                else if (property.ValueType == typeof(Guid))
                {
                    if (!Guid.TryParse(value, out _))
                    {
                        validationErrors.AppendLine($"{property.Name} must be a valid Guid.");
                    }
                }
                else if (property.ValueType == typeof(bool))
                {
                    if (!bool.TryParse(value, out _))
                    {
                        validationErrors.AppendLine($"{property.Name} must be a valid boolean.");
                    }
                }
                else if (property.ValueType == typeof(DateTime))
                {
                    if (!DateTime.TryParse(value, out _))
                    {
                        validationErrors.AppendLine($"{property.Name} must be a valid datetime.");
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

