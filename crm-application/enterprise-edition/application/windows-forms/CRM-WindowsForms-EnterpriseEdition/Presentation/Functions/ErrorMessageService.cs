namespace CRM_WindowsForms_EnterpriseEdition.Presentation.Functions
{
    public class ErrorMessageService
    {
        public ErrorMessageService(string errorType, string? dataSubject = null, string? exceptionMessage = null)
        {
            InitializeClass(errorType, dataSubject, exceptionMessage);
        }

        private void InitializeClass(string errorType, string? dataSubject, string? exceptionMessage)
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
        }

        private void CSVExportExportFailureError(string dataSubject, string errorType, string exceptionMessage)
        {
            MessageBox.Show($"Export failed for {dataSubject}: {exceptionMessage}.", $"Export CSV - {errorType}", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CSVExportExportSuccessfulInformation(string dataSubject, string errorType)
        {
            MessageBox.Show($"Export successful for {dataSubject}.", $"Export CSV - {errorType}", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CSVExportNoDataWarning(string dataSubject, string errorType)
        {
            MessageBox.Show($"No data available to export for {dataSubject}.", $"Export CSV - {errorType}", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void CurrencyConversionBaseCurrencyTargetCurrencyDifferenceError(string errorType)
        {
            MessageBox.Show("Base Currency and Target Currency must be different.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CurrencyConversionEffectiveDateValidationError(string errorType)
        {
            MessageBox.Show("Expiry Date must be after Effective Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CurrencyConversionMissingValuesError(string errorType)
        {
            MessageBox.Show("Please enter all required currency conversion values.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CustomerCustomerTypeMultinationalValidationError(string errorType)
        {
            MessageBox.Show("'Business - Multinational' can only be selected as the Customer Type if the parent customer is Global Parent.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CustomerGlobalParentGlobalParentRelationshipValidationError(string errorType)
        {
            MessageBox.Show("Cannot select 'Global Parent' as customer parent type when existing Parent Company Type is 'Global Parent'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CustomerGlobalParentTypeCustomerTypeValidationError(string errorType)
        {
            MessageBox.Show("The 'Global Parent' option can only be selected for a customer if 'Business - Multinational' is selected in the Customer Type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CustomerTopParentTopParentRelationshipValidationError(string errorType)
        {
            MessageBox.Show("Cannot select 'Top Parent Parent' as new customer parent type when existing Parent Company Type is 'Top Parent'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DataIdColumnNotFoundError(string dataSubject, string errorType)
        {
            MessageBox.Show($"The ID column for {dataSubject} was not found in the data source.", "Data Id Not Found Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DataRetrievalError(string dataSubject, string errorType, string exceptionMessage)
        {
            MessageBox.Show($"Failed to load {dataSubject} data: {exceptionMessage}", "Data Retrieval Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DataValidationDataTypeWarning(string dataSubject, string errorType)
        {
            MessageBox.Show($"Invalid {dataSubject}.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void DataValidationDynamicWarning(string dataSubject, string errorType)
        {
            MessageBox.Show($"{dataSubject}.", "Validation Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        private void DataValidationInvalidValueError(string dataSubject, string errorType)
        {
            MessageBox.Show($"Invalid {dataSubject}.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DataValidationSelectionError(string dataSubject, string errorType)
        {
            MessageBox.Show($"Please select a valid {dataSubject}.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DataValidationSelectionWarning(string dataSubject, string errorType)
        {
            MessageBox.Show($"Please ensure a valid {dataSubject} is selected.", "Validation Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        private void DatabaseConnectionSettingsNotLoadedError(string errorType)
        {
            MessageBox.Show("Database connection settings are not loaded.", "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ModuleFunctionNotImplementedError(string dataSubject, string errorType)
        {
            MessageBox.Show($"{dataSubject} not onboarded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ModuleNotImplementedError(string dataSubject, string errorType)
        {
            MessageBox.Show($"Unrecognised module group - {dataSubject} passed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NoDataFoundError(string dataSubject, string errorType)
        {
            MessageBox.Show($"No data found for the specified {dataSubject}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateCancelled(string errorType)
        {
            MessageBox.Show("Updates were cancelled, no changes have been made to the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}