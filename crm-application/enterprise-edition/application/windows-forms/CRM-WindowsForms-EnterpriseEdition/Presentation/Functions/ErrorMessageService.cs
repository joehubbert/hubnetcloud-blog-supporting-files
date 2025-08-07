namespace CRM_WindowsForms_EnterpriseEdition.Presentation.Functions
{
    public class ErrorMessageService
    {
        private AppConfiguration _appConfiguration;
        private string globalCSVMessageTitle;
        private string globalDatabaseConnectionMessageTitle;
        private string globalInformationMessageTitle;
        private string globalLoggingServiceMessageTitle;
        private string globalModuleMessageTitle;
        private string globalValidationMessageTitle;

        public ErrorMessageService(AppConfiguration appConfiguration, string errorType, string? dataSubject = null, string? exceptionMessage = null)
        {
            _appConfiguration = appConfiguration;
            InitializeClass(errorType, dataSubject, exceptionMessage);
        }

        private void InitializeClass(string errorType, string? dataSubject = null, string? exceptionMessage = null)
        {
            globalCSVMessageTitle = $"Export CSV - {errorType}";
            globalDatabaseConnectionMessageTitle = $"Database Connection - {errorType}";
            globalInformationMessageTitle = $"Information - {errorType}";
            globalLoggingServiceMessageTitle = $"Logging Service - {errorType}";
            globalModuleMessageTitle = $"Module - {errorType}";
            globalValidationMessageTitle = $"Validation - {errorType}";

            switch (errorType)
            {
                case "Error.CSVExport.ExportFailure":
                    CSVExportExportFailureError(dataSubject ?? "unknown", exceptionMessage ?? "No exception message provided.");
                    break;
                case "Error.CurrencyConversion.BaseCurrencyTargetCurrencyDifference":
                    CurrencyConversionBaseCurrencyTargetCurrencyDifferenceError();
                    break;
                case "Error.CurrencyConversion.EffectiveDateValidation":
                    CurrencyConversionEffectiveDateValidationError();
                    break;
                case "Error.CurrencyConversion.MissingValues":
                    CurrencyConversionMissingValuesError();
                    break;
                case "Error.Customer.CustomerType.MultinationalValidation":
                    CustomerCustomerTypeMultinationalValidationError();
                    break;
                case "Error.Customer.GlobalParent.GlobalParentRelationshipValidation":
                    CustomerGlobalParentGlobalParentRelationshipValidationError();
                    break;
                case "Error.Customer.GlobalParentType.CustomerTypeValidation":
                    CustomerGlobalParentTypeCustomerTypeValidationError();
                    break;
                case "Error.Customer.TopParent.TopParentRelationshipValidation":
                    CustomerTopParentTopParentRelationshipValidationError();
                    break;
                case "Error.Data.IdColumnNotFound":
                    DataIdColumnNotFoundError(dataSubject ?? "unknown", errorType);
                    break;
                case "Error.Data.Retrieval":
                    DataRetrievalError(dataSubject ?? "unknown", errorType, exceptionMessage ?? "No exception message provided.");
                    break;
                case "Error.DataValidation.InvalidValue":
                    DataValidationInvalidValueError(dataSubject ?? "unknown");
                    break;
                case "Error.DataValidation.Selection":
                    DataValidationSelectionError(dataSubject ?? "unknown");
                    break;
                case "Error.Database.Connection.Failed":
                    DatabaseConnectionFailedError(exceptionMessage ?? "No exception message provided.");
                    break;
                case "Error.Database.Connection.SettingsNotLoaded":
                    DatabaseConnectionSettingsNotLoadedError();
                    break;
                case "Error.Module.Function.NotImplemented":
                    ModuleFunctionNotImplementedError(dataSubject ?? "unknown");
                    break;
                case "Error.Module.NotImplemented":
                    ModuleNotImplementedError(dataSubject ?? "unknown");
                    break;
                case "Information.ApplicationConfiguration.Settings.Saved":
                    ApplicationConfigurationgSettingsSavedInformation();
                    break;
                case "Information.CSVExport.ExportSuccessful":
                    CSVExportExportSuccessfulInformation(dataSubject ?? "unknown");
                    break;
                case "Information.Database.Connection.Test.Successful":
                    DatabaseConnectionTestSuccesfulInformation();
                    break;
                case "Information.LoggingService.Clear.Cancellation":
                    LoggingServiceClearLogCancellationConfirmationInformation();
                    break;
                case "Information.NoDataFound":
                    NoDataFoundError(dataSubject ?? "unknown");
                    break;
                case "Information.UpdateCancelled":
                    UpdateCancelled();
                    break;
                case "Warning.CSVExport.NoData":
                    CSVExportNoDataWarning(dataSubject ?? "unknown");
                    break;
                case "Warning.LoggingService.Clear":
                    LoggingServiceClearLogConfirmationWarning();
                    break;
                case "Warning.Data.Validation.DataType":
                    DataValidationDataTypeWarning(dataSubject ?? "unknown");
                    break;
                case "Warning.DataValidation.Dynamic":
                    DataValidationDynamicWarning(dataSubject ?? "unknown");
                    break;
                case "Warning.DataValidation.Selection":
                    DataValidationSelectionWarning(dataSubject ?? "unknown");
                    break;
                default:
                    throw new ArgumentException("Invalid error type specified.");
            }
        }

        private void ApplicationConfigurationgSettingsSavedInformation()
        {
            string messageText = "Application Configuration settings saved.";
            string messageTitle = globalInformationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CSVExportExportFailureError(string dataSubject, string exceptionMessage)
        {
            string messageText = $"Export failed for {dataSubject}: {exceptionMessage}.";
            string messageTitle = globalCSVMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CSVExportExportSuccessfulInformation(string dataSubject)
        {
            string messageText = $"Export successful for {dataSubject}.";
            string messageTitle = globalCSVMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CSVExportNoDataWarning(string dataSubject)
        {
            string messageText = $"No data available to export for {dataSubject}.";
            string messageTitle = globalCSVMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CurrencyConversionBaseCurrencyTargetCurrencyDifferenceError()
        {
            string messageText = "Base Currency and Target Currency must be different.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CurrencyConversionEffectiveDateValidationError()
        {
            string messageText = "Expiry Date must be after Effective Date.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CurrencyConversionMissingValuesError()
        {
            string messageText = "Please enter all required currency conversion values.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CustomerCustomerTypeMultinationalValidationError()
        {
            string messageText = "'Business - Multinational' can only be selected as the Customer Type if the parent customer is Global Parent.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CustomerGlobalParentGlobalParentRelationshipValidationError()
        {
            string messageText = "Cannot select 'Global Parent' as customer parent type when existing Parent Company Type is 'Global Parent'.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CustomerGlobalParentTypeCustomerTypeValidationError()
        {
            string messageText = "The 'Global Parent' option can only be selected for a customer if 'Business - Multinational' is selected in the Customer Type.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CustomerTopParentTopParentRelationshipValidationError()
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

        private void DataValidationDataTypeWarning(string dataSubject)
        {
            string messageText = $"Invalid {dataSubject}.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DataValidationDynamicWarning(string dataSubject)
        {
            string messageText = $"{dataSubject}.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DataValidationInvalidValueError(string dataSubject)
        {
            string messageText = $"Invalid {dataSubject}.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DataValidationSelectionError(string dataSubject)
        {
            string messageText = $"Please select a valid {dataSubject}.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DataValidationSelectionWarning(string dataSubject)
        {
            string messageText = $"Please ensure a valid {dataSubject} is selected.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DatabaseConnectionFailedError(string exceptionMessage)
        {
            string messageText = $"Database connection failed. {exceptionMessage}";
            string messageTitle = globalDatabaseConnectionMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DatabaseConnectionSettingsNotLoadedError()
        {
            string messageText = "Database connection settings are not loaded.";
            string messageTitle = globalDatabaseConnectionMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DatabaseConnectionTestSuccesfulInformation()
        {
            string messageText = "Database connection test was successful.";
            string messageTitle = globalDatabaseConnectionMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void LoggingServiceClearLogCancellationConfirmationInformation()
        {
            string messageText = "Action Cancelled. No logs were deleted.";
            string messageTitle = globalInformationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void LoggingServiceClearLogConfirmationWarning()
        {
            string messageText = "Logs were successfully deleted.";
            string messageTitle = globalLoggingServiceMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void ModuleFunctionNotImplementedError(string dataSubject)
        {
            string messageText = $"{dataSubject} not onboarded.";
            string messageTitle = globalModuleMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void ModuleNotImplementedError(string dataSubject)
        {
            string messageText = $"Unrecognised module group - {dataSubject} passed.";
            string messageTitle = globalModuleMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void NoDataFoundError(string dataSubject)
        {
            string messageText = $"No data found for {dataSubject}.";
            string messageTitle = globalInformationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (_appConfiguration.userProfileLoggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void UpdateCancelled()
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