namespace CRM_WindowsForms_EnterpriseEdition.Presentation.Functions
{
    internal class ErrorMessageService
    {
        private string globalCSVMessageTitle;
        private string globalDatabaseConnectionMessageTitle;
        private string globalInformationMessageTitle;
        private string globalLoggingServiceMessageTitle;
        private string globalModuleMessageTitle;
        private string globalValidationMessageTitle;
        private string globalWarningMessageTitle;
        private bool loggingEnabled;

        public ErrorMessageService(string errorType, string? dataSubject = null, string? exceptionMessage = null)
        {
            InitializeClass(errorType, dataSubject, exceptionMessage);
        }

        private async void InitializeClass(string errorType, string? dataSubject = null, string? exceptionMessage = null)
        {
            globalCSVMessageTitle = $"Export CSV - {errorType}";
            globalDatabaseConnectionMessageTitle = $"Database Connection - {errorType}";
            globalInformationMessageTitle = $"Information - {errorType}";
            globalLoggingServiceMessageTitle = $"Logging Service - {errorType}";
            globalModuleMessageTitle = $"Module - {errorType}";
            globalValidationMessageTitle = $"Validation - {errorType}";
            globalWarningMessageTitle = $"Warning - {errorType}";

            loggingEnabled = await ApplicationConfigurationService.GetLoggingEnabledAsync();

            switch (errorType)
            {
                case "Error.CSVExport.ExportFailure":
                    CSVExportExportFailureError(dataSubject ?? "unknown", exceptionMessage ?? "No exception message provided.");
                    break;
                case "Error.CurrencyConversion.BaseCurrencyTargetCurrencyDifference":
                    CurrencyConversionBaseCurrencyTargetCurrencyDifferenceError();
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
                case "Error.Data.Validation.InvalidValue":
                    DataValidationInvalidValueError(dataSubject ?? "unknown");
                    break;
                case "Error.Data.Validation.Selection":
                    DataValidationSelectionError(dataSubject ?? "unknown");
                    break;
                case "Error.Database.Connection.Failed":
                    DatabaseConnectionFailedError(dataSubject ?? "unknown", exceptionMessage ?? "No exception message provided.");
                    break;
                case "Error.Database.Connection.SettingsNotLoaded":
                    DatabaseConnectionSettingsNotLoadedError();
                    break;
                case "Error.Measurement.Type.NotImplemented":
                    MeasurementTypeNotImplementedError(dataSubject ?? "unknown");
                    break;
                case "Error.Module.Function.NotImplemented":
                    ModuleFunctionNotImplementedError(dataSubject ?? "unknown");
                    break;
                case "Error.Module.NotImplemented":
                    ModuleNotImplementedError(dataSubject ?? "unknown");
                    break;
                case "Error.UnitConversion.Generic":
                    UnitConversionError();
                    break;
                case "Information.ApplicationConfiguration.Settings.Saved":
                    ApplicationConfigurationgSettingsSavedInformation();
                    break;
                case "Information.CompanyConfiguration.ActiveCompanyConfiguration.Saved":
                    CompanyConfigurationActiveCompanyConfigurationSavedInformation(dataSubject ?? "unknown");
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
                    NoDataFoundInformation(dataSubject ?? "unknown");
                    break;
                case "Information.UpdateCancelled":
                    UpdateCancelled();
                    break;
                case "Warning.ApplicationConfiguration.Settings.Missing":
                    ApplicationConfigurationgSettingsMissingWarning(dataSubject ?? "unknown", errorType);
                    break;
                case "Warning.CompanyConfiguration.NoData":
                    CompanyConfigurationNoDataFoundWarning(errorType);
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
                case "Warning.DataValidation.EffectiveDateValidation":
                    DataValidationEffectiveDateValidationWarning();
                    break;
                case "Warning.DataValidation.Selection":
                    DataValidationSelectionWarning(dataSubject ?? "unknown");
                    break;
                case "Warning.NoDataFound.CompanyConfiguration.Specific":
                    NoDataFoundWarning(dataSubject ?? "unknown");
                    break;
                default:
                    throw new ArgumentException("Invalid error type specified.");
            }
        }

        private void ApplicationConfigurationgSettingsMissingWarning(string dataSubject, string errorType)
        {
            string messageText = $"Settings for {dataSubject} missing in Application Configuration.";
            string messageTitle = $"{errorType} - Missing Settings in Application Configuration";
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void ApplicationConfigurationgSettingsSavedInformation()
        {
            string messageText = "Application Configuration settings saved.";
            string messageTitle = globalInformationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CompanyConfigurationActiveCompanyConfigurationSavedInformation(string dataSubject)
        {
            string messageText = $"Active Company Configuration saved. Active Company Configuration is: {dataSubject}";
            string messageTitle = globalInformationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CompanyConfigurationNoDataFoundWarning(string errorType)
        {
            string messageText = "No Company Configurations Found - Please create at least one in order to continue.";
            string messageTitle = $"No Company Configurations Found {errorType}";
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CSVExportExportFailureError(string dataSubject, string exceptionMessage)
        {
            string messageText = $"Export failed for {dataSubject}: {exceptionMessage}.";
            string messageTitle = globalCSVMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CSVExportExportSuccessfulInformation(string dataSubject)
        {
            string messageText = $"Export successful for {dataSubject}.";
            string messageTitle = globalCSVMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CSVExportNoDataWarning(string dataSubject)
        {
            string messageText = $"No data available to export for {dataSubject}.";
            string messageTitle = globalCSVMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CurrencyConversionBaseCurrencyTargetCurrencyDifferenceError()
        {
            string messageText = "Base Currency and Target Currency must be different.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CurrencyConversionMissingValuesError()
        {
            string messageText = "Please enter all required currency conversion values.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CustomerCustomerTypeMultinationalValidationError()
        {
            string messageText = "'Business - Multinational' can only be selected as the Customer Type if the parent customer is Global Parent.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CustomerGlobalParentGlobalParentRelationshipValidationError()
        {
            string messageText = "Cannot select 'Global Parent' as customer parent type when existing Parent Company Type is 'Global Parent'.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CustomerGlobalParentTypeCustomerTypeValidationError()
        {
            string messageText = "The 'Global Parent' option can only be selected for a customer if 'Business - Multinational' is selected in the Customer Type.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void CustomerTopParentTopParentRelationshipValidationError()
        {
            string messageText = "Cannot select 'Top Parent Parent' as new customer parent type when existing Parent Company Type is 'Top Parent'.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DataIdColumnNotFoundError(string dataSubject, string errorType)
        {
            string messageText = $"The ID column for {dataSubject} was not found in the data source.";
            string messageTitle = $"Data Id Not Found - {errorType}";
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DataRetrievalError(string dataSubject, string errorType, string exceptionMessage)
        {
            string messageText = $"Failed to load {dataSubject} data: {exceptionMessage}";
            string messageTitle = $"Data Retrieval - {errorType}";
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DataValidationDataTypeWarning(string dataSubject)
        {
            string messageText = $"Invalid {dataSubject}.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DataValidationDynamicWarning(string dataSubject)
        {
            string messageText = $"{dataSubject}.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DataValidationEffectiveDateValidationWarning()
        {
            string messageText = "Expiry Date must be after Effective Date.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DataValidationInvalidValueError(string dataSubject)
        {
            string messageText = $"Invalid {dataSubject}.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DataValidationSelectionError(string dataSubject)
        {
            string messageText = $"Please select a valid {dataSubject}.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DataValidationSelectionWarning(string dataSubject)
        {
            string messageText = $"Please ensure a valid {dataSubject} is selected.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DatabaseConnectionFailedError(string dataSubject, string exceptionMessage)
        {
            string messageText = $"Database connection failed - ({dataSubject}) {exceptionMessage}";
            string messageTitle = globalDatabaseConnectionMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DatabaseConnectionSettingsNotLoadedError()
        {
            string messageText = "Database connection settings are not loaded.";
            string messageTitle = globalDatabaseConnectionMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void DatabaseConnectionTestSuccesfulInformation()
        {
            string messageText = "Database connection test was successful.";
            string messageTitle = globalDatabaseConnectionMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void LoggingServiceClearLogCancellationConfirmationInformation()
        {
            string messageText = "Action Cancelled. No logs were deleted.";
            string messageTitle = globalInformationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void LoggingServiceClearLogConfirmationWarning()
        {
            string messageText = "Logs were successfully deleted.";
            string messageTitle = globalLoggingServiceMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void MeasurementTypeNotImplementedError(string dataSubject)
        {
            string messageText = $"Unrecognised measurement type - {dataSubject} passed.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void ModuleFunctionNotImplementedError(string dataSubject)
        {
            string messageText = $"{dataSubject} not onboarded.";
            string messageTitle = globalModuleMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void ModuleNotImplementedError(string dataSubject)
        {
            string messageText = $"Unrecognised module group - {dataSubject} passed.";
            string messageTitle = globalModuleMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void NoDataFoundInformation(string dataSubject)
        {
            string messageText = $"No data found for {dataSubject}.";
            string messageTitle = globalInformationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void NoDataFoundWarning(string dataSubject)
        {
            string messageText = $"No data found for {dataSubject} for the current company configuration.";
            string messageTitle = globalWarningMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void UnitConversionError()
        {
            string messageText = "Invalid unit type combination or unsupported conversion.";
            string messageTitle = globalValidationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }

        private void UpdateCancelled()
        {
            string messageText = "Updates were cancelled, no changes have been made to the database.";
            string messageTitle = globalInformationMessageTitle;
            MessageBox.Show(messageText, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (loggingEnabled)
            {
                new ApplicationLoggingService("AppendToLogFile", messageTitle, messageText);
            }
        }
    }
}