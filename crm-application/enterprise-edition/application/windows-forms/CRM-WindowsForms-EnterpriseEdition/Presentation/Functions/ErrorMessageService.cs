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
                    DataIdColumnNotFoundError(dataSubject ?? "unknown");
                    break;
                case "Error.Data.Retrieval":
                    DataRetrievalError(dataSubject ?? "unknown", exceptionMessage ?? "No exception message provided.");
                    break;
                case "Error.DataValidation.InvalidValue":
                    DataValidationInvalidValueError(dataSubject ?? "unknown");
                    break;
                case "Error.DataValidation.Selection":
                    DataValidationSelectionError(dataSubject ?? "unknown");
                    break;
                case "Error.Database.ConnectionSettingsNotLoaded":
                    DatabaseConnectionSettingsNotLoadedError();
                    break;
                case "Error.Module.Function.NotImplemented":
                    ModuleFunctionNotImplementedError(dataSubject ?? "unknown");
                    break;
                case "Error.Module.NotImplemented":
                    ModuleNotImplementedError(dataSubject ?? "unknown");
                    break;
                case "Information.NoDataFound":
                    NoDataFoundError(dataSubject ?? "unknown");
                    break;
                case "Information.UpdateCancelled":
                    UpdateCancelled();
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

        private void CurrencyConversionBaseCurrencyTargetCurrencyDifferenceError()
        {
            MessageBox.Show("Base Currency and Target Currency must be different.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CurrencyConversionEffectiveDateValidationError()
        {
            MessageBox.Show("Expiry Date must be after Effective Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CurrencyConversionMissingValuesError()
        {
            MessageBox.Show("Please enter all required currency conversion values.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CustomerCustomerTypeMultinationalValidationError()
        {
            MessageBox.Show("'Business - Multinational' can only be selected as the Customer Type if the parent customer is Global Parent.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CustomerGlobalParentGlobalParentRelationshipValidationError()
        {
            MessageBox.Show("Cannot select 'Global Parent' as customer parent type when existing Parent Company Type is 'Global Parent'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CustomerGlobalParentTypeCustomerTypeValidationError()
        {
            MessageBox.Show("The 'Global Parent' option can only be selected for a customer if 'Business - Multinational' is selected in the Customer Type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CustomerTopParentTopParentRelationshipValidationError()
        {
            MessageBox.Show("Cannot select 'Top Parent Parent' as new customer parent type when existing Parent Company Type is 'Top Parent'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DataIdColumnNotFoundError(string dataSubject)
        {
            MessageBox.Show($"The ID column for {dataSubject} was not found in the data source.", "Data Id Not Found Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DataRetrievalError(string dataSubject, string exceptionMessage)
        {
            MessageBox.Show($"Failed to load {dataSubject} data: {exceptionMessage}", "Data Retrieval Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DataValidationDataTypeWarning(string dataSubject)
        {
            MessageBox.Show($"Invalid {dataSubject}.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void DataValidationDynamicWarning(string dataSubject)
        {
            MessageBox.Show($"{dataSubject}.", "Validation Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        private void DataValidationInvalidValueError(string dataSubject)
        {
            MessageBox.Show($"Invalid {dataSubject}.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DataValidationSelectionError(string dataSubject)
        {
            MessageBox.Show($"Please select a valid {dataSubject}.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DataValidationSelectionWarning(string dataSubject)
        {
            MessageBox.Show($"Please ensure a valid {dataSubject} is selected.", "Validation Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        private void DatabaseConnectionSettingsNotLoadedError()
        {
            MessageBox.Show("Database connection settings are not loaded.", "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ModuleFunctionNotImplementedError(string dataSubject)
        {
            MessageBox.Show($"{dataSubject} not onboarded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ModuleNotImplementedError(string dataSubject)
        {
            MessageBox.Show($"Unrecognised module group - {dataSubject} passed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NoDataFoundError(string dataSubject)
        {
            MessageBox.Show($"No data found for the specified {dataSubject}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateCancelled()
        {
            MessageBox.Show("Updates were cancelled, no changes have been made to the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}