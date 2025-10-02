using CRM.Helpers;
using CRM.Model;
using CRM.Services;
using System.Text;

namespace CRM.Presentation.General
{
    public class GeneralSharedComponents
    {
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private string? _dataSubjectFilterColumn1;
        private string? _dataSubjectFilterColumn2;
        private DataSubjectLookupResultModel? _dataSubjectProperties;
        private UIModel _uiModel = new UIModel();
        private UIModelHelper _uiModelHelper = new UIModelHelper();

        public DataSubjectLookupResultModel GetDataSubjectProperties(FunctionTitle functionTitle)
        {
            var dataSubjectProperties = _uiModelHelper.GetDataSubjectProperties(functionTitle);
            if (dataSubjectProperties == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.Function.NotImplemented", functionTitle.ToString());
            }

            return dataSubjectProperties;
        }

        public string GetModuleGroupValue(ModuleGroup moduleGroup, string propertyName)
        {
            // Delegate to UIModelHelper instead of using our own UIModel instance
            return _uiModelHelper.GetModuleGroupValue(moduleGroup, propertyName);
        }

        public async Task LoadProductCategoryDataAsync(ComboBox comboBox, Guid companyConfigurationId, Guid? productCategoryId = null)
        {
            if (productCategoryId == null)
            {
                _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(
                    comboBox: comboBox,
                    companyConfigurationId: companyConfigurationId,
                    functionTitle: FunctionTitle.ProductCategory
                    );
                await _dataAccessComboBoxHelper.LoadDataAsync();
            }
            else
            {
                var _dataSubjectProperties = GetDataSubjectProperties(FunctionTitle.ProductCategory);
                if (!string.IsNullOrWhiteSpace(_dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName))
                {
                    _dataSubjectFilterColumn1 = _dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName;
                }

                _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(
                    comboBox: comboBox,
                    companyConfigurationId: companyConfigurationId,
                    dataSubjectFilter1: true,
                    dataSubjectFilterColumn1: _dataSubjectFilterColumn1,
                    dataSubjectId1: productCategoryId,
                    functionTitle: FunctionTitle.ProductCategory,
                    treatFiltersAsPreselection: true
                    );
                await _dataAccessComboBoxHelper.LoadDataAsync();
            }
        }

        public async Task LoadCountryDataAsync(ComboBox comboBox, Guid? countryId = null)
        {
            if (countryId == null)
            {
                _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(
                    comboBox: comboBox,
                    functionTitle: FunctionTitle.Country
                    );
                await _dataAccessComboBoxHelper.LoadDataAsync();
            }
            else
            {
                var _dataSubjectProperties = GetDataSubjectProperties(FunctionTitle.Country);
                if (!string.IsNullOrWhiteSpace(_dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName))
                {
                    _dataSubjectFilterColumn1 = _dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName;
                }

                _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(
                    comboBox: comboBox,
                    dataSubjectFilter1: true,
                    dataSubjectFilterColumn1: _dataSubjectFilterColumn1,
                    dataSubjectId1: countryId,
                    functionTitle: FunctionTitle.Country,
                    treatFiltersAsPreselection: true
                    );
                await _dataAccessComboBoxHelper.LoadDataAsync();
            }
        }

        public async Task LoadProductFamilyDataAsync(ComboBox comboBox, Guid companyConfigurationId, Guid? productFamilyId = null)
        {
            if (productFamilyId == null)
            {
                _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(
                    comboBox: comboBox,
                    companyConfigurationId: companyConfigurationId,
                    functionTitle: FunctionTitle.ProductFamily
                    );
                await _dataAccessComboBoxHelper.LoadDataAsync();
            }
            else
            {
                var _dataSubjectProperties = GetDataSubjectProperties(FunctionTitle.ProductFamily);
                if (!string.IsNullOrWhiteSpace(_dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName))
                {
                    _dataSubjectFilterColumn1 = _dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName;
                }

                _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(
                    comboBox: comboBox,
                    companyConfigurationId: companyConfigurationId,
                    dataSubjectFilter1: true,
                    dataSubjectFilterColumn1: _dataSubjectFilterColumn1,
                    dataSubjectId1: productFamilyId,
                    functionTitle: FunctionTitle.ProductFamily,
                    treatFiltersAsPreselection: true
                    );
                await _dataAccessComboBoxHelper.LoadDataAsync();
            }
        }

        public async Task LoadManufacturerDataAsync(ComboBox comboBox, Guid? manufacturerId = null)
        {
            if (manufacturerId == null)
            {
                _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(
                    comboBox: comboBox,
                    functionTitle: FunctionTitle.Manufacturer);
                await _dataAccessComboBoxHelper.LoadDataAsync();
            }
            else
            {
                var _dataSubjectProperties = GetDataSubjectProperties(FunctionTitle.Manufacturer);
                if (!string.IsNullOrWhiteSpace(_dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName))
                {
                    _dataSubjectFilterColumn1 = _dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName;
                }

                _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(
                    comboBox: comboBox,
                    dataSubjectFilter1: true,
                    dataSubjectFilterColumn1: _dataSubjectFilterColumn1,
                    dataSubjectId1: manufacturerId,
                    functionTitle: FunctionTitle.Manufacturer,
                    treatFiltersAsPreselection: true);
                await _dataAccessComboBoxHelper.LoadDataAsync();
            }
        }

        public async Task LoadProductSubCategoryDataAsync(ComboBox comboBox, Guid productCategoryId, Guid? productSubCategoryId = null)
        {
            if (productSubCategoryId == null)
            {
                var _dataSubjectProperties = GetDataSubjectProperties(FunctionTitle.ProductSubCategory);
                if (!string.IsNullOrWhiteSpace(_dataSubjectProperties.DataParentSubject.DataSubjectIdFriendlyName))
                {
                    _dataSubjectFilterColumn1 = _dataSubjectProperties.DataParentSubject.DataSubjectIdFriendlyName;
                }

                _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(
                    comboBox: comboBox,
                    dataSubjectFilter1: true,
                    dataSubjectFilterColumn1: _dataSubjectFilterColumn1,
                    dataSubjectId1: productCategoryId,
                    functionTitle: FunctionTitle.ProductSubCategory
                    );
                await _dataAccessComboBoxHelper.LoadDataAsync();
            }
            else
            {
                var _dataSubjectProperties = GetDataSubjectProperties(FunctionTitle.ProductSubCategory);
                if (!string.IsNullOrWhiteSpace(_dataSubjectProperties.DataParentSubject.DataSubjectIdFriendlyName))
                {
                    _dataSubjectFilterColumn1 = _dataSubjectProperties.DataParentSubject.DataSubjectIdFriendlyName;
                }

                if (!string.IsNullOrWhiteSpace(_dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName))
                {
                    _dataSubjectFilterColumn2 = _dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName;
                }

                _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(
                    comboBox: comboBox,
                    dataSubjectFilter1: true,
                    dataSubjectFilter2: true,
                    dataSubjectFilterColumn1: _dataSubjectFilterColumn1,
                    dataSubjectFilterColumn2: _dataSubjectFilterColumn2,
                    dataSubjectId1: productCategoryId,
                    dataSubjectId2: productSubCategoryId,
                    functionTitle: FunctionTitle.ProductSubCategory,
                    treatFiltersAsPreselection: true
                    );
                await _dataAccessComboBoxHelper.LoadDataAsync();
            }
        }

        public async Task LoadSalesRegionDataAsync(ComboBox comboBox, Guid companyConfigurationId, Guid? salesRegionId = null)
        {
            if (salesRegionId == null)
            {
                _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(
                    comboBox: comboBox,
                    companyConfigurationId: companyConfigurationId,
                    functionTitle: FunctionTitle.SalesRegion
                    );
                await _dataAccessComboBoxHelper.LoadDataAsync();
            }
            else
            {
                var _dataSubjectProperties = GetDataSubjectProperties(FunctionTitle.SalesRegion);
                if (!string.IsNullOrWhiteSpace(_dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName))
                {
                    _dataSubjectFilterColumn1 = _dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName;
                }

                _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(
                    comboBox: comboBox,
                    companyConfigurationId: companyConfigurationId,
                    dataSubjectFilter1: true,
                    dataSubjectFilterColumn1: _dataSubjectFilterColumn1,
                    dataSubjectId1: salesRegionId,
                    functionTitle: FunctionTitle.SalesRegion,
                    treatFiltersAsPreselection: true
                    );
                await _dataAccessComboBoxHelper.LoadDataAsync();
            }
        }

        public async Task LoadSalesSubRegionDataAsync(ComboBox comboBox, Guid salesRegionId, Guid? salesSubRegionId = null)
        {
            var storedProcedureParameterObject = new List<object>();

            storedProcedureParameterObject.Add(new Dictionary<string, object>
            {
                ["PropertyStoredProcedureParameterName"] = "salesRegionId",
                ["PropertyValue"] = salesRegionId
            });

            if (salesSubRegionId == null)
            {
                var _dataSubjectProperties = GetDataSubjectProperties(FunctionTitle.SalesSubRegion);
                if (!string.IsNullOrWhiteSpace(_dataSubjectProperties.DataParentSubject.DataSubjectIdFriendlyName))
                {
                    _dataSubjectFilterColumn1 = _dataSubjectProperties.DataParentSubject.DataSubjectIdFriendlyName;
                }

                _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(
                    comboBox: comboBox,
                    dataSubjectFilter1: true,
                    dataSubjectFilterColumn1: _dataSubjectFilterColumn1,
                    dataSubjectId1: salesRegionId,
                    functionTitle: FunctionTitle.SalesSubRegion,
                    storedProcedureParameter: storedProcedureParameterObject.ToArray()
                    );
                await _dataAccessComboBoxHelper.LoadDataAsync();
            }
            else
            {
                var _dataSubjectProperties = GetDataSubjectProperties(FunctionTitle.SalesSubRegion);
                if (!string.IsNullOrWhiteSpace(_dataSubjectProperties.DataParentSubject.DataSubjectIdFriendlyName))
                {
                    _dataSubjectFilterColumn1 = _dataSubjectProperties.DataParentSubject.DataSubjectIdFriendlyName;
                }

                if (!string.IsNullOrWhiteSpace(_dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName))
                {
                    _dataSubjectFilterColumn2 = _dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName;
                }

                _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(
                    comboBox: comboBox,
                    dataSubjectFilter1: true,
                    dataSubjectFilter2: true,
                    dataSubjectFilterColumn1: _dataSubjectFilterColumn1,
                    dataSubjectFilterColumn2: _dataSubjectFilterColumn2,
                    dataSubjectId1: salesRegionId,
                    dataSubjectId2: salesSubRegionId,
                    functionTitle: FunctionTitle.SalesSubRegion,
                    storedProcedureParameter: storedProcedureParameterObject.ToArray(),
                    treatFiltersAsPreselection: true
                    );
                await _dataAccessComboBoxHelper.LoadDataAsync();
            }
        }

        public async Task LoadSupplierDataAsync(ComboBox comboBox, Guid companyConfigurationId, Guid? supplierId = null)
        {
            var storedProcedureParameterObject = new List<object>();

            storedProcedureParameterObject.Add(new Dictionary<string, object>
            {
                ["PropertyStoredProcedureParameterName"] = "companyConfigurationId",
                ["PropertyValue"] = companyConfigurationId
            });

            if (supplierId == null)
            {
                _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(
                    comboBox: comboBox,
                    companyConfigurationId: companyConfigurationId,
                    functionTitle: FunctionTitle.Supplier,
                    storedProcedureParameter: storedProcedureParameterObject.ToArray()
                    );
                await _dataAccessComboBoxHelper.LoadDataAsync();
            }
            else
            {
                var _dataSubjectProperties = GetDataSubjectProperties(FunctionTitle.Supplier);
                if (!string.IsNullOrWhiteSpace(_dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName))
                {
                    _dataSubjectFilterColumn1 = _dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName;
                }

                _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(
                    comboBox: comboBox,
                    companyConfigurationId: companyConfigurationId,
                    dataSubjectFilter1: true,
                    dataSubjectFilterColumn1: _dataSubjectFilterColumn1,
                    dataSubjectId1: supplierId,
                    functionTitle: FunctionTitle.Supplier,
                    storedProcedureParameter: storedProcedureParameterObject.ToArray(),
                    treatFiltersAsPreselection: true
                    );
                await _dataAccessComboBoxHelper.LoadDataAsync();
            }
        }
    }
}