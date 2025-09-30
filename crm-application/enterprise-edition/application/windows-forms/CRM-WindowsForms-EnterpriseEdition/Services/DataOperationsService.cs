using CRM.Helpers;
using CRM.Interface;
using CRM.Model;
using System.Data;

namespace CRM.Services
{
    internal class DataOperationsService
    {
        private bool _changeValidationPassed;
        private Guid? _dataSubjectId;
        private object[]? _dataToBeProcessed;
        private bool _dataValidationPassed;
        private string? _dataSubjectName;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private UnitType? _measurementInputUnitType;
        private UnitType? _measurementOutputUnitType;
        private DataOperationType _operationType;
        private bool? _outputStoredProcedureParameterCapture;
        private Dictionary<string, object>? _outputStoredProcedureParameters;
        private string? _outboundStoredProcedureParameterName;
        private DataTable? _selectResults;
        private string? _storedProcedureName;
        private object[]? _unitConversionResults;
        public Dictionary<string, object>? OutputStoredProcedureParameters => _outputStoredProcedureParameters;
        public DataTable? SelectResults => _selectResults;
        public object[]? UnitConversionResults => _unitConversionResults;

        public async Task DataSubmissionServiceOrchestrator
            (
            DataOperationType operationType,
            object[]? dataToBeProcessed = null,
            Guid? dataSubjectId = null,
            string? dataSubjectName = null,
            UnitType? measurementInputUnitType = null,
            UnitType? measurementOutputUnitType = null,
            bool? outputStoredProcedureParameterCapture = null,
            string? outboundStoredProcedureParameterName = null,
            string? storedProcedureName = null
            ) 
        { 
            _dataSubjectId = dataSubjectId;
            _dataSubjectName = dataSubjectName;
            _dataToBeProcessed = dataToBeProcessed;
            _measurementInputUnitType = measurementInputUnitType;
            _measurementOutputUnitType = measurementOutputUnitType;
            _operationType = operationType;
            _outputStoredProcedureParameterCapture = outputStoredProcedureParameterCapture;
            _outboundStoredProcedureParameterName = outboundStoredProcedureParameterName;
            _storedProcedureName = storedProcedureName;

            if (_operationType == DataOperationType.Create || 
                _operationType == DataOperationType.MeasurementConversion || 
                _operationType == DataOperationType.Select || 
                _operationType == DataOperationType.Update
                )
            {
                if (_dataToBeProcessed == null || _dataToBeProcessed.Length == 0)
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Warning.Data.Validation.NoData");
                    return;
                }
            }

            if (_operationType == DataOperationType.Create || 
                _operationType == DataOperationType.Delete || 
                _operationType == DataOperationType.Select || 
                _operationType == DataOperationType.SelectNoParameter || 
                _operationType == DataOperationType.Update
                )
            {
                if (_dataSubjectName == null || string.IsNullOrWhiteSpace(_dataSubjectName))
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Warning.Data.Validation.Dynamic", "No Data Subject provided.");
                    return;
                }

                if (_storedProcedureName == null || string.IsNullOrWhiteSpace(_storedProcedureName))
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Warning.Data.Validation.Dynamic", "No Stored Procedure Name provided.");
                    return;
                }

                if (_databaseConnectionSettings == null)
                {
                    await LoadDatabaseConnectionSettingsAsync();
                    await TestDatabaseConnectionSettingsAsync(_dataSubjectName);
                }
            }

            if (_operationType == DataOperationType.Create || 
                _operationType == DataOperationType.Delete || 
                _operationType == DataOperationType.Update
                )
            {
                if (_outputStoredProcedureParameterCapture == true)
                {
                    if (_outboundStoredProcedureParameterName == null || string.IsNullOrWhiteSpace(_outboundStoredProcedureParameterName))
                    {
                        ErrorMessageService errorMessageService = new ErrorMessageService("Warning.Data.Validation.Dynamic", "No Outbound Stored Procedure Parameter Name provided.");
                        return;
                    }
                }
            }

            if (_operationType == DataOperationType.Delete || 
                _operationType == DataOperationType.Update
                )
            {
                if (_dataSubjectId == null)
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Warning.Data.Validation.Dynamic", $"No Data Subject Id for {dataSubjectName} provided.");
                    return;
                }
            }

            switch (_operationType)
            {
                case DataOperationType.Create:
                    DataValidation();
                    if (!_dataValidationPassed)
                    {
                        return;
                    }
                    else
                    {
                        _outputStoredProcedureParameters = await CreateDeleteUpdateOperation();
                    }
                    break;
                case DataOperationType.Delete:
                    var result = MessageBox.Show(
                    $"Deleting {_dataSubjectName} is an irreversible operation. Are you sure that you want to continue? Clicking Cancel will cancel the deletion.",
                    "Warning",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                    if (result == DialogResult.OK)
                    {
                        await CreateDeleteUpdateOperation();
                    }
                    else
                    {
                        return;
                    }
                    break;
                case DataOperationType.MeasurementConversion:
                    _unitConversionResults = UnitConversion();
                    break;
                case DataOperationType.Select:
                case DataOperationType.SelectNoParameter:
                    _selectResults = await SelectOperation();
                    break;
                case DataOperationType.Update:
                    DataValidation();
                    if (!_dataValidationPassed)
                    {
                        return;
                    }
                    else
                    {
                        ChangeValidation();
                        if (!_changeValidationPassed)
                        {
                            return;
                        }
                        else
                        {
                            _outputStoredProcedureParameters = await CreateDeleteUpdateOperation();
                        }
                    }
                    break;
                default: 
                    throw new InvalidOperationException("Invalid operation type specified");
            }
        }

        private bool ChangeValidation()
        {
            var changeDetailList = new List<ChangeDetail>();

            foreach (var item in _dataToBeProcessed)
            {
                if (item == null) continue;

                if (item is Dictionary<string, object> propertyDictionary)
                {
                    var dataProperty = new ChangeDetail
                    {
                        VariableName = (string)propertyDictionary.GetValueOrDefault("PropertyName", string.Empty),
                        OriginalValue = propertyDictionary.GetValueOrDefault("PropertyOriginalValue", ""),
                        NewValue = propertyDictionary.GetValueOrDefault("PropertyValue", "")
                    };

                    changeDetailList.Add(dataProperty);
                }
            }

            changeDetailList = changeDetailList.OrderBy(change => change.VariableName).ToList();

            bool changeValidationResult = ChangeValidationService.ConfirmChanges(changeDetailList, _dataSubjectName);

            if (!changeValidationResult)
            {
                _changeValidationPassed = false;
            }
            else
            {
                _changeValidationPassed = true;
            }

            return _changeValidationPassed;
        }

        private async Task<Dictionary<string, object>?> CreateDeleteUpdateOperation()
        {
            try
            {
                var storedProcedureParameterList = new List<StoredProcedureParameter> { };

                foreach (var item in _dataToBeProcessed)
                {
                    if (item == null) continue;

                    if (item is Dictionary<string, object> propertyDictionary)
                    {
                        var storedProcedureParameter = new StoredProcedureParameter
                        {
                            ParameterDirection = propertyDictionary.ContainsKey("PropertyStoredProcedureParameterDirection")
                            ? Enum.Parse<ParameterDirection>((string)propertyDictionary["PropertyStoredProcedureParameterDirection"])
                            : ParameterDirection.Input,
                            ParameterName = (string)propertyDictionary.GetValueOrDefault("PropertyStoredProcedureParameterName", string.Empty),
                            ParameterValue = propertyDictionary.GetValueOrDefault("PropertyValue", "")
                        };

                        storedProcedureParameterList.Add(storedProcedureParameter);
                    }
                }

                if (_outputStoredProcedureParameterCapture == true)
                {
                    var outputParameters = await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureWithOutputParametersAsync(
                        dataSubject: _dataSubjectName,
                        databaseConnectionSettings: _databaseConnectionSettings,
                        operationType: _operationType,
                        storedProcedureName: _storedProcedureName,
                        storedProcedureParameters: storedProcedureParameterList.ToArray(),
                        outboundStoredProcedureParameterName: _outboundStoredProcedureParameterName,
                        outputStoredProcedureParameterCapture: _outputStoredProcedureParameterCapture.Value
                        );
                    return outputParameters;
                }
                else
                {
                    // Use the standard method when output parameter capture is not requested
                    var success = await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(
                        dataSubject: _dataSubjectName,
                        databaseConnectionSettings: _databaseConnectionSettings,
                        operationType: _operationType,
                        storedProcedureName: _storedProcedureName,
                        storedProcedureParameters: storedProcedureParameterList.ToArray()
                        );
                    return success ? new Dictionary<string, object>() : null;
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Operation.Failed", _dataSubjectName, ex.Message);
                return null;
            }
        }

        private bool DataValidation()
        {
            var dataValidationList = new List<DataValidationService.DataProperty>();

            foreach (var item in _dataToBeProcessed)
            {
                if (item == null) continue;

                if (item is Dictionary<string, object> propertyDictionary)
                {
                    var dataProperty = new DataValidationService.DataProperty
                    {
                        AllowNullValue = (bool)propertyDictionary.GetValueOrDefault("AllowNullValue", false),
                        Name = (string)propertyDictionary.GetValueOrDefault("PropertyName", string.Empty),
                        Value = propertyDictionary.GetValueOrDefault("PropertyValue", ""),
                        ValueType = (Type)propertyDictionary.GetValueOrDefault("PropertyType", typeof(string)),
                        MaxLength = propertyDictionary.ContainsKey("MaxLength") ? (int)propertyDictionary["MaxLength"] : 0,
                        MaxPixelHeight = propertyDictionary.ContainsKey("MaxPixelHeight") ? (int)propertyDictionary["MaxPixelHeight"] : 0,
                        MaxPixelWidth = propertyDictionary.ContainsKey("MaxPixelWidth") ? (int)propertyDictionary["MaxPixelWidth"] : 0
                    };

                    dataValidationList.Add(dataProperty);
                }
            }

            dataValidationList = dataValidationList.OrderBy(change => change.Name).ToList();

            var validationResult = DataValidationService.ValidateInput(dataValidationList);

            if (!validationResult.IsValid)
            {
                _dataValidationPassed = false;
            }
            else
            {
                _dataValidationPassed = true;
            }

            return _dataValidationPassed;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task<DataTable?> SelectOperation()
        {
            var dataTable = new DataTable();

            try
            {
                switch (_operationType)
                {
                    case DataOperationType.Select:
                        var storedProcedureParameterList = new List<StoredProcedureParameter>();

                        foreach (var item in _dataToBeProcessed)
                        {
                            if (item == null) continue;

                            if (item is Dictionary<string, object> propertyDictionary)
                            {
                                var storedProcedureParameter = new StoredProcedureParameter
                                {
                                    ParameterName = (string)propertyDictionary.GetValueOrDefault("PropertyStoredProcedureParameterName", string.Empty),
                                    ParameterValue = propertyDictionary.GetValueOrDefault("PropertyValue", "")
                                };

                                storedProcedureParameterList.Add(storedProcedureParameter);
                            }
                        }

                        dataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(
                            dataSubject: _dataSubjectName,
                            databaseConnectionSettings: _databaseConnectionSettings,
                            storedProcedureName: _storedProcedureName,
                            storedProcedureParameters: storedProcedureParameterList.ToArray()
                            );
                        break;
                    case DataOperationType.SelectNoParameter:
                        dataTable = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(
                            dataSubject: _dataSubjectName,
                            databaseConnectionSettings: _databaseConnectionSettings,
                            storedProcedureName: _storedProcedureName
                            );
                        break;
                }

                if (dataTable.Rows.Count == 0)
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.NoDataFound", _dataSubjectName);
                }

                return dataTable;
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Operation.Failed", _dataSubjectName, ex.Message);
                return dataTable;
            }
        }

        private object[]? UnitConversion()
        {
            if (_dataToBeProcessed == null)
                throw new InvalidOperationException("No data provided for unit conversion");

            if (_measurementInputUnitType == null || _measurementOutputUnitType == null)
                throw new InvalidOperationException("Input and output unit types must be specified for unit conversion");

            var measurementsToBeConvertedList = new List<MeasurementConversionModel>();
            var convertedMeasurements = new List<object>();

            // Parse input data into measurement models
            foreach (var item in _dataToBeProcessed)
            {
                if (item == null) continue;

                if (item is Dictionary<string, object> propertyDictionary)
                {
                    // Extract MeasurementType with proper null handling
                    var measurementTypeValue = propertyDictionary.GetValueOrDefault("MeasurementType", null);
                    if (measurementTypeValue == null)
                        continue; // Skip if no measurement type is specified

                    MeasurementType measurementType;
                    if (measurementTypeValue is MeasurementType enumValue)
                    {
                        measurementType = enumValue;
                    }
                    else if (measurementTypeValue is string stringValue && Enum.TryParse<MeasurementType>(stringValue, out var parsedValue))
                    {
                        measurementType = parsedValue;
                    }
                    else
                    {
                        continue; // Skip if measurement type cannot be parsed
                    }

                    var measurement = new MeasurementConversionModel
                    {
                        MeasurementType = measurementType,
                        Value = Convert.ToDecimal(propertyDictionary.GetValueOrDefault("Value", 0m)),
                        PropertyName = propertyDictionary.GetValueOrDefault("PropertyName", string.Empty) as string
                    };

                    // Extract the SetValue action from the dictionary
                    if (propertyDictionary.TryGetValue("SetValue", out var setValueObj) && setValueObj is Action<decimal> setValueAction)
                    {
                        measurement.SetValue = setValueAction;
                    }

                    measurementsToBeConvertedList.Add(measurement);
                }
            }

            // Perform conversions
            foreach (var measurement in measurementsToBeConvertedList)
            {
                decimal convertedValue = UnitConversionService.ConvertMeasurement(
                    _measurementInputUnitType.Value,
                    measurement.Value,
                    measurement.MeasurementType,
                    _measurementOutputUnitType.Value
                );

                // Create converted measurement object
                var convertedMeasurement = new Dictionary<string, object>
                {
                    ["OriginalValue"] = measurement.Value,
                    ["ConvertedValue"] = convertedValue,
                    ["MeasurementType"] = measurement.MeasurementType,
                    ["PropertyName"] = measurement.PropertyName ?? string.Empty,
                    ["InputUnitType"] = _measurementInputUnitType.Value,
                    ["OutputUnitType"] = _measurementOutputUnitType.Value
                };

                convertedMeasurements.Add(convertedMeasurement);

                // Use the SetValue action if provided to write back to the model
                if (measurement.SetValue != null)
                {
                    measurement.SetValue(convertedValue);
                }
            }

            return convertedMeasurements.ToArray();
        }

        private async Task TestDatabaseConnectionSettingsAsync(string dataSubject)
        {
            var helper = new TestDatabaseConnectionSettingsHelper();
            bool isConnected = await helper.TestDatabaseConnectionSettings(dataSubject, _databaseConnectionSettings);

            if (!isConnected)
            {
                // Connection failed - handle accordingly
                return;
            }
            else
            {
                // Connection successful - proceed with database operations
            }
        }
    }
}