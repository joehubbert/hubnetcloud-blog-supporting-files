using System.Runtime.CompilerServices;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation.Functions
{
    public class ErrorMessageService
    {
        private AppConfiguration _appConfiguration;
        private string globalCSVMessageTitle;
        private string globalDatabaseConnectionMessageTitle;
        private string globalInformationMessageTitle;
        private string globalModuleMessageTitle;
        private string globalValidationMessageTitle;

        public ErrorMessageService(AppConfiguration appConfiguration, string errorType, string? dataSubject = null, string? exceptionMessage = null)
        {
            _appConfiguration = appConfiguration;
            InitializeClass(errorType, dataSubject, exceptionMessage);
        }

        private void InitializeClass(string errorType, string? dataSubject = null, string? exceptionMessage = null)
        {
            switch (errorType)
            {
                case "Error.CSVExport.ExportFailure":
                    CSVExportExportFailureError(dataSubject ?? "unknown", errorType, exceptionMessage ?? "No exception message provided.");
                    break;
                case "Error.CurrencyConversion.BaseCurrencyTargetCurrencyDifference":
                    CurrencyConversionBaseCurrencyTargetCurrencyDifferenceError(errorType);
                    break;
                case "Error.CurrencyConversion.EffectiveDateValidation":
                    CurrencyConversionEffectiveDateValidationError(errorType);
                    break;
                case "Error.CurrencyConversion.MissingValues":
                    CurrencyConversionMissingValuesError(errorType);
                    break;
                case "Error.Customer.CustomerType.MultinationalValidation":
                    CustomerCustomerTypeMultinationalValidationError(errorType);
                    break;
                case "Error.Customer.GlobalParent.GlobalParentRelationshipValidation":
                    CustomerGlobalParentGlobalParentRelationshipValidationError(errorType);
                    break;
                case "Error.Customer.GlobalParentType.CustomerTypeValidation":
                    CustomerGlobalParentTypeCustomerTypeValidationError(errorType);
                    break;
                case "Error.Customer.TopParent.TopParentRelationshipValidation":
                    CustomerTopParentTopParentRelationshipValidationError(errorType);
                    break;
                case "Error.Data.IdColumnNotFound":
                    DataIdColumnNotFoundError(dataSubject ?? "unknown", errorType);
                    break;
                case "Error.Data.Retrieval":
                    DataRetrievalError(dataSubject ?? "unknown", errorType, exceptionMessage ?? "No exception message provided.");
                    break;
                case "Error.DataValidation.InvalidValue":
                    DataValidationInvalidValueError(dataSubject ?? "unknown", errorType);
                    break;
                case "Error.DataValidation.Selection":
                    DataValidationSelectionError(dataSubject ?? "unknown", errorType);
                    break;
                case "Error.Database.ConnectionSettingsNotLoaded":
                    DatabaseConnectionSettingsNotLoadedError(errorType);
                    break;
                case "Error.Module.Function.NotImplemented":
                    ModuleFunctionNotImplementedError(dataSubject ?? "unknown", errorType);
                    break;
                case "Error.Module.NotImplemented":
                    ModuleNotImplementedError(dataSubject ?? "unknown", errorType);
                    break;
                case "Information.CSVExport.ExportSuccessful":
                    CSVExportExportSuccessfulInformation(dataSubject ?? "unknown", errorType);
                    break;
                case "Information.NoDataFound":
                    NoDataFoundError(dataSubject ?? "unknown", errorType);
                    break;
                case "Information.UpdateCancelled":
                    UpdateCancelled(errorType);
                    break;
                case "Warning.CSVExport.NoData":
                    CSVExportNoDataWarning(dataSubject ?? "unknown", errorType);
                    break;
                case "Warning.Data.Validation.DataType":
                    DataValidationDataTypeWarning(dataSubject ?? "unknown", errorType);
                    break;
                case "Warning.DataValidation.Dynamic":
                    DataValidationDynamicWarning(dataSubject ?? "unknown", errorType);
                    break;
                case "Warning.DataValidation.Selection":
                    DataValidationSelectionWarning(dataSubject ?? "unknown", errorType);
                    break;
                default:
                    throw new ArgumentException("Invalid error type specified.");
            }

            globalCSVMessageTitle = $"Export CSV - {errorType}";
            globalDatabaseConnectionMessageTitle = $"Database Connection - {errorType}";
            globalInformationMessageTitle = $"Information - {errorType}";
            globalModuleMessageTitle = $"Module - {errorType}";
            globalValidationMessageTitle = $"Validation - {errorType}";
        }

        private void CSVExportExportFailureError(string dataSubject, string errorType, string exceptionMessage)
        {
            string messageText = $"Export failed for {dataSubject}: {exceptionMessage}.";
            string messageTitle = globalCSVMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CSVExportExportSuccessfulInformation(string dataSubject, string errorType)
        {
            string messageText = $"Export successful for {dataSubject}.";
            string messageTitle = globalCSVMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CSVExportNoDataWarning(string dataSubject, string errorType)
        {
            string messageText = $"No data available to export for {dataSubject}.";
            string messageTitle = globalCSVMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CurrencyConversionBaseCurrencyTargetCurrencyDifferenceError(string errorType)
        {
            string messageText = "Base Currency and Target Currency must be different.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CurrencyConversionEffectiveDateValidationError(string errorType)
        {
            string messageText = "Expiry Date must be after Effective Date.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CurrencyConversionMissingValuesError(string errorType)
        {
            string messageText = "Please enter all required currency conversion values.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CustomerCustomerTypeMultinationalValidationError(string errorType)
        {
            string messageText = "'Business - Multinational' can only be selected as the Customer Type if the parent customer is Global Parent.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CustomerGlobalParentGlobalParentRelationshipValidationError(string errorType)
        {
            string messageText = "Cannot select 'Global Parent' as customer parent type when existing Parent Company Type is 'Global Parent'.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CustomerGlobalParentTypeCustomerTypeValidationError(string errorType)
        {
            string messageText = "The 'Global Parent' option can only be selected for a customer if 'Business - Multinational' is selected in the Customer Type.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CustomerTopParentTopParentRelationshipValidationError(string errorType)
        {
            string messageText = "Cannot select 'Top Parent Parent' as new customer parent type when existing Parent Company Type is 'Top Parent'.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DataIdColumnNotFoundError(string dataSubject, string errorType)
        {
            string messageText = $"The ID column for {dataSubject} was not found in the data source.";
            string messageTitle = $"Data Id Not Found - {errorType}";
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DataRetrievalError(string dataSubject, string errorType, string exceptionMessage)
        {
            string messageText = $"Failed to load {dataSubject} data: {exceptionMessage}";
            string messageTitle = $"Data Retrieval - {errorType}";
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DataValidationDataTypeWarning(string dataSubject, string errorType)
        {
            string messageText = $"Invalid {dataSubject}.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DataValidationDynamicWarning(string dataSubject, string errorType)
        {
            string messageText = $"{dataSubject}.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DataValidationInvalidValueError(string dataSubject, string errorType)
        {
            string messageText = $"Invalid {dataSubject}.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DataValidationSelectionError(string dataSubject, string errorType)
        {
            string messageText = $"Please select a valid {dataSubject}.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DataValidationSelectionWarning(string dataSubject, string errorType)
        {
            string messageText = $"Please ensure a valid {dataSubject} is selected.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DatabaseConnectionSettingsNotLoadedError(string errorType)
        {
            string messageText = "Database connection settings are not loaded.";
            string messageTitle = globalDatabaseConnectionMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void ModuleFunctionNotImplementedError(string dataSubject, string errorType)
        {
            string messageText = $"{dataSubject} not onboarded.";
            string messageTitle = globalModuleMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void ModuleNotImplementedError(string dataSubject, string errorType)
        {
            string messageText = $"Unrecognised module group - {dataSubject} passed.";
            string messageTitle = globalModuleMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void NoDataFoundError(string dataSubject, string errorType)
        {
            string messageText = $"No data found for the specified {dataSubject}.";
            string messageTitle = globalInformationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void UpdateCancelled(string errorType)
        {
            string messageText = "Updates were cancelled, no changes have been made to the database.";
            string messageTitle = globalInformationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }
    }
}