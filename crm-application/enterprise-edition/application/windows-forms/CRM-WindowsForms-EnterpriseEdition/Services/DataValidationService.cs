using CRM.Helpers;
using System.Drawing.Imaging;
using System.Text;
using System.Text.RegularExpressions;

namespace CRM.Services
{
    internal class DataValidationService
    {
		internal class ValidationResult
        {
            public bool IsValid { get; set; }
            public string ErrorMessage { get; set; } = string.Empty;
        }

		internal class DataProperty
        {
            public bool AllowNullValue { get; set; } = false;
            public string Name { get; set; } = string.Empty;
            public object Value { get; set; } = string.Empty;
            public int MaxLength { get; set; } = 0;
            public int MaxPixelHeight { get; set; } = 0;
            public int MaxPixelWidth { get; set; } = 0;
            public Type ValueType { get; set; } = typeof(string);
        }

        public static ValidationResult ValidateInput(IEnumerable<DataProperty> dataToValidate)
        {
            StringBuilder validationErrors = new StringBuilder();

            foreach (var property in dataToValidate)
            {
                string value = property.Value?.ToString()?.TrimEnd() ?? string.Empty;

                if (property.ValueType == typeof(string))
                {
                    if (value.Length > property.MaxLength)
                    {
                        validationErrors.AppendLine($"{property.Name} cannot be longer than {property.MaxLength} characters. Submitted length is {value.Length} characters.");
                    }

                    if (property.AllowNullValue == false && string.IsNullOrWhiteSpace(value))
                    {
                        validationErrors.AppendLine($"{property.Name} cannot be empty.");
                    }

                    if (property.Name.Equals("BankAccountSortCode"))
                    {
                        if (!string.IsNullOrWhiteSpace(value))
                        {
                            if (!Regex.IsMatch(value, "^[0-9]{2}-[0-9]{2}-[0-9]{2}$"))
                            {
                                validationErrors.AppendLine("BankAccountSortCode must follow UK Bank Account Sort Code Format of 00-00-00.");
                            }
                            if (value.Length > 8)
                            {
                                validationErrors.AppendLine("BankAccountSortCode cannot be longer than 8 characters.");
                            }
                        }
                    }

                    if (property.Name.Equals("BCP47LanguageTagCode"))
                    {
                        if (value.Length == 2)
                        {
                            // Valid: exactly 2 characters (e.g., "en")
                        }
                        else if (value.Length == 5)
                        {
                            // Must match pattern: 2 letters, '-', 2 letters (e.g., "en-US")
                            if (!Regex.IsMatch(value, @"^[a-zA-Z]{2}-[a-zA-Z]{2}$"))
                            {
                                validationErrors.AppendLine("BCP47LanguageTagCode must be in the format 'xx' or 'xx-xx' (where x is a letter).");
                            }
                        }
                        else
                        {
                            validationErrors.AppendLine("BCP47LanguageTagCode must be either 2 letters or in the format 'xx-xx' (total 5 characters).");
                        }
                    }

                    if (property.Name.Equals("EmailTopLevelDomain"))
                    {
                        if (!value.StartsWith("@"))
                        {
                            validationErrors.AppendLine("EmailTopLevelDomain must begin with a @ character.");
                        }

                        if (value.Length > 50)
                        {
                            validationErrors.AppendLine("EmailTopLevelDomain cannot be longer than 50 characters.");
                        }
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
                        else if (!Regex.IsMatch(value, @"^\+\d{6,}$"))
                        {
                            validationErrors.AppendLine("Telephone Number must start with a '+' prefix followed by at least 6 digits.");
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
                else if (property.Name.ToLower().Contains("image"))
                {
                    if (property.Value is byte[] imageBytes)
                    {
                        if (!IsValidImageBytes(imageBytes, property.MaxPixelHeight, property.MaxPixelWidth, out string error))
                        {
                            validationErrors.AppendLine($"{property.Name}: {error}");
                        }
                    }
                    else if (property.Value is string imagePath && !string.IsNullOrWhiteSpace(imagePath))
                    {
                        if (!IsValidImageFile(imagePath, property.MaxPixelHeight, property.MaxPixelWidth, out string error))
                        {
                            validationErrors.AppendLine($"{property.Name}: {error}");
                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(value) && SQLInjectionRiskHelper.ContainsSqlInjectionRisk(value))
                {
                    validationErrors.AppendLine($"{property.Name} contains potentially dangerous characters that could lead to SQL injection.");
                }
            }

            if (validationErrors.Length > 0)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Warning.DataValidation.Dynamic", validationErrors.ToString());
                return new ValidationResult
                {
                    IsValid = false,
                    ErrorMessage = validationErrors.ToString()
                };
            }

            return new ValidationResult { IsValid = true };
        }

        public static bool IsValidImageFile(string filePath, int maxPixelHeight, int maxPixelWidth, out string errorMessage)
        {
            errorMessage = string.Empty;
            string extension = Path.GetExtension(filePath).ToLower();

            if (extension != ".png" && extension != ".jpg" && extension != ".jpeg")
            {
                errorMessage = "Only PNG and JPG images are allowed.";
                return false;
            }

            try
            {
                using (var img = Image.FromFile(filePath))
                {
                    if (img.Width > maxPixelWidth || img.Height > maxPixelHeight)
                    {
                        errorMessage = $"Image dimensions must not exceed {maxPixelWidth}x{maxPixelHeight} pixels.";
                        return false;
                    }
                }
            }
            catch
            {
                errorMessage = "The selected file is not a valid image.";
                return false;
            }

            return true;
        }

        public static bool IsValidImageBytes(byte[] imageBytes, int maxPixelHeight, int maxPixelWidth, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                using (var ms = new MemoryStream(imageBytes))
                using (var img = Image.FromStream(ms))
                {
                    var format = img.RawFormat;
                    if (format.Guid != ImageFormat.Png.Guid &&
                        format.Guid != ImageFormat.Jpeg.Guid)
                    {
                        errorMessage = "Only PNG and JPG images are allowed.";
                        return false;
                    }
                    if (img.Width > maxPixelWidth || img.Height > maxPixelHeight)
                    {
                        errorMessage = $"Image dimensions must not exceed {maxPixelWidth}x{maxPixelHeight} pixels.";
                        return false;
                    }
                }
            }
            catch
            {
                errorMessage = "The selected file is not a valid image.";
                return false;
            }
            return true;
        }
    }
}