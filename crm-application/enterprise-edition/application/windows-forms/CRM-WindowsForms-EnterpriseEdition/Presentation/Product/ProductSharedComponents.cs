using CRM.Helpers;
using CRM.Model;
using CRM.Presentation.General;
using CRM.Services;
using System.Data;
using System.Text;

namespace CRM.Presentation.Product
{
    internal class ProductSharedComponents
    {
        private DataAccessListViewHelper? _dataAccessListViewHelper;
        private DataSubjectLookupResultModel? _dataSubjectProperties;
        private GeneralSharedComponents _generalSharedComponents = new GeneralSharedComponents();

        public void AddProductImage(ImageList imageList, ListView listView, int maxPixelHeight, int maxPixelWidth, PictureBox pictureBox, ProductModel productModel)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    if (DataValidationService.IsValidImageFile(filePath, maxPixelWidth, maxPixelHeight, out string errorMessage))
                    {
                        pictureBox.Image = Image.FromFile(filePath);

                        var imageBytes = File.ReadAllBytes(filePath);
                        int order = productModel.ProductImageList.Count;
                        productModel.ProductImageList.Add(new ProductImageList { ImageBytes = imageBytes, DisplayOrder = order });

                        UpdateProductImageListView(
                            imageList: imageList,
                            listView: listView,
                            productModel: productModel
                            );
                    }
                    else
                    {
                        ErrorMessageService errorMessageService = new ErrorMessageService("Warning.Data.Validation.DataType", "Image");
                        pictureBox.Image = null;
                    }
                }
            }
        }

        private string BuildMissingPropertiesMessage(List<string> missingProperties, string deliveryType)
        {
            var message = new StringBuilder();
            message.AppendLine($"The following required wholesale data properties are missing for delivery type '{deliveryType}':");
            message.AppendLine();

            // Group properties by category for better readability
            var cartonProperties = missingProperties.Where(p => p.StartsWith("Carton") || p.Contains("Per Carton")).ToList();
            var palletProperties = missingProperties.Where(p => p.StartsWith("Pallet") || p.Contains("Per Pallet")).ToList();
            var otherProperties = missingProperties.Except(cartonProperties).Except(palletProperties).ToList();

            if (cartonProperties.Count > 0)
            {
                message.AppendLine("Carton Information:");
                foreach (var property in cartonProperties)
                {
                    message.AppendLine($"  • {property}");
                }
                message.AppendLine();
            }

            if (palletProperties.Count > 0)
            {
                message.AppendLine("Pallet Information:");
                foreach (var property in palletProperties)
                {
                    message.AppendLine($"  • {property}");
                }
                message.AppendLine();
            }

            if (otherProperties.Count > 0)
            {
                message.AppendLine("Other Information:");
                foreach (var property in otherProperties)
                {
                    message.AppendLine($"  • {property}");
                }
                message.AppendLine();
            }

            message.AppendLine("Please complete all required fields before proceeding.");
            return message.ToString().TrimEnd();
        }

        public static void CalculateAndUpdateWholesalePriceControls(
            ProductSupplierRelationshipChosenList chosenSupplierList,
            string deliveryType,
            ProductModel productModel,
            Action<string, string> updateUnitPriceAction,
            Action<string, string>? updateCartonPriceAction = null
            )
        {
            var result = CalculateWholesalePricePerUnit(productModel, chosenSupplierList, deliveryType);
            UpdateWholesalePriceControls(result, updateUnitPriceAction, updateCartonPriceAction);
        }

        public void ConfigureListViews(ListView availableListView, ListView chosenListView, FunctionTitle functionTitle)
        {
            string dataSubjectPlural = string.Empty;
            var _dataSubjectProperties = _generalSharedComponents.GetDataSubjectProperties(functionTitle);
            if (!string.IsNullOrWhiteSpace(_dataSubjectProperties.DataSubject.DataSubjectPlural))
            {
                dataSubjectPlural = _dataSubjectProperties.DataSubject.DataSubjectPlural;
            }

            // If designer set View=Details but forgot columns, add one.
            DataAccessListViewHelper.PrepareListViewColumnsIfNeeded(
                headerText: $"Available {dataSubjectPlural}",
                listView: availableListView
                );
            DataAccessListViewHelper.PrepareListViewColumnsIfNeeded(
                headerText: $"Chosen {dataSubjectPlural}",
                listView: chosenListView
                );

            // Common quality-of-life flags
            foreach (var listView in new[] { chosenListView, availableListView })
            {
                listView.FullRowSelect = true;
                listView.HideSelection = false;
                listView.MultiSelect = true;
            }
        }

        public Guid GetFirstSalesRegionId(ComboBox comboBox)
        {
            string dataSubjectIdFriendlyName = string.Empty;
            var _dataSubjectProperties = _generalSharedComponents.GetDataSubjectProperties(FunctionTitle.SalesRegion);
            if (!string.IsNullOrWhiteSpace(_dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName))
            {
                dataSubjectIdFriendlyName = _dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName;
            }

            if (comboBox.Items.Count > 0)
            {
                var firstItem = comboBox.Items[0];
                if (firstItem is Guid guid)
                    return guid;
                if (firstItem is DataRowView drv && drv.Row[dataSubjectIdFriendlyName] is Guid regionId)
                    return regionId;
            }
            return Guid.Empty;
        }

        public string GetSelectedWholesaleDeliveryType(ComboBox comboBox)
        {
            if (comboBox?.DataSource == null || comboBox.SelectedItem == null)
                return string.Empty;

            try
            {
                string dataSubjectFriendlyName = string.Empty;
                var _dataSubjectProperties = _generalSharedComponents.GetDataSubjectProperties(FunctionTitle.WholesaleDeliveryType);
                if (!string.IsNullOrWhiteSpace(_dataSubjectProperties.DataSubject.DataSubjectFriendlyName))
                {
                    dataSubjectFriendlyName = _dataSubjectProperties.DataSubject.DataSubjectFriendlyName;
                }

                // Handle DataRowView (from DataTable binding)
                if (comboBox.SelectedItem is DataRowView drv)
                {
                    // Check for common column names that might contain the delivery type text
                    if (drv.Row.Table.Columns.Contains(dataSubjectFriendlyName))
                        return drv.Row[dataSubjectFriendlyName]?.ToString() ?? string.Empty;
                    if (drv.Row.Table.Columns.Contains("Display Text"))
                        return drv.Row["Display Text"]?.ToString() ?? string.Empty;
                    if (drv.Row.Table.Columns.Contains(comboBox.DisplayMember))
                        return drv.Row[comboBox.DisplayMember]?.ToString() ?? string.Empty;
                }

                // Fallback to ComboBox text
                return comboBox.Text ?? string.Empty;
            }
            catch (Exception)
            {
                // If anything fails, return empty string to prevent crashes
                return string.Empty;
            }
        }

        public async Task LoadSalesSubRegionsAsync(ListView listView, ProductModel productModel, Guid salesRegionId)
        {
            string dataSubjectIdFriendlyName = string.Empty;
            var _dataSubjectProperties = _generalSharedComponents.GetDataSubjectProperties(FunctionTitle.SalesRegion);
            if (!string.IsNullOrWhiteSpace(_dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName))
            {
                dataSubjectIdFriendlyName = _dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName;
            }

            var storedProcedureParameterObject = new List<object>();

            storedProcedureParameterObject.Add(new Dictionary<string, object>
            {
                ["PropertyStoredProcedureParameterName"] = "salesRegionId",
                ["PropertyValue"] = salesRegionId
            });

            productModel.ProductSalesSubRegionAvailableList.Clear();
            // Use DataAccessListViewHelper to get sales sub regions for the selected sales region
            _dataAccessListViewHelper = new DataAccessListViewHelper(
                functionTitle: FunctionTitle.SalesSubRegion,
                listView: listView,
                storedProcedureParameter: storedProcedureParameterObject.ToArray()
            );
            await _dataAccessListViewHelper.LoadDataAsync();

            // Get all sales sub regions from the ListView
            var allSubRegions = _dataAccessListViewHelper.GetItems<ProductSalesSubRegionAvailableList>();

            // Filter out sales sub regions already in either list
            var usedIds = new HashSet<Guid>(
                productModel.ProductSalesSubRegionAvailableList.Select(x => x.SalesSubRegionId)
                .Concat(productModel.ProductSalesSubRegionChosenList.Select(x => x.SalesSubRegionId))
            );

            var filteredSubRegions = allSubRegions
                .Where(x => !usedIds.Contains(x.SalesSubRegionId))
                .ToList();

            // Update available list and ListView
            productModel.ProductSalesSubRegionAvailableList = filteredSubRegions;
            UpdateAvailableSalesSubRegionListView(
                listView: listView,
                productModel: productModel
                );
        }

        public async Task LoadSupplierAsync(ListView availableSupplierListView, ListView chosenSupplierListView, Guid companyConfigurationId, ProductModel productModel)
        {
            // Load raw data into the ListView (DataAccessListViewHelper will populate it first)
            _dataAccessListViewHelper = new DataAccessListViewHelper(
                companyConfigurationId: companyConfigurationId,
                functionTitle: FunctionTitle.Supplier,
                listView: availableSupplierListView
                );

            await _dataAccessListViewHelper.LoadDataAsync();

            // Materialize into our strongly-typed list
            var loaded = _dataAccessListViewHelper.GetItems<ProductSupplierRelationshipAvailableList>();

            // Guard: if nothing loaded, keep existing list empty
            productModel.ProductSupplierRelationshipAvailableList = loaded?.ToList() ?? new List<ProductSupplierRelationshipAvailableList>();

            // Rebuild ListView so Tag is the full object (not a Guid) to avoid invalid cast later
            UpdateAvailableSupplierListView(
                listView: availableSupplierListView,
                productModel: productModel
                );
        }

        public void MoveProductImage(ImageList imageList, 
            ListView imageListView,
            int index, 
            int newIndex,
            ProductModel productModel)
        {
            if (index >= 0 && newIndex >= 0 && index < productModel.ProductImageList.Count && newIndex < productModel.ProductImageList.Count)
            {
                var img = productModel.ProductImageList[index];
                productModel.ProductImageList.RemoveAt(index);
                productModel.ProductImageList.Insert(newIndex, img);
                UpdateProductImageListView(
                    imageList: imageList,
                    listView: imageListView,
                    productModel: productModel
                    );
            }
        }

        public object[] PrepareProductMeasurementConversionData(ProductModel productModel)
        {
            var measurementData = new List<object>();

            // Unit Measurements
            // Area
            if (productModel.ProductDetailsUnitInformation.UnitArea.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Area,
                    ["Value"] = productModel.ProductDetailsUnitInformation.UnitArea.Value,
                    ["PropertyName"] = "UnitArea",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsUnitInformation.UnitArea = value)
                });
            }

            if (productModel.ProductDetailsUnitInformation.UnitAreaOriginalValue.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Area,
                    ["Value"] = productModel.ProductDetailsUnitInformation.UnitAreaOriginalValue.Value,
                    ["PropertyName"] = "UnitAreaOriginalValue",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsUnitInformation.UnitAreaOriginalValue = value)
                });
            }

            // Depth
            if (productModel.ProductDetailsUnitInformation.UnitDepth.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Distance,
                    ["Value"] = productModel.ProductDetailsUnitInformation.UnitDepth.Value,
                    ["PropertyName"] = "UnitDepth",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsUnitInformation.UnitDepth = value)
                });
            }

            if (productModel.ProductDetailsUnitInformation.UnitDepthOriginalValue.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Distance,
                    ["Value"] = productModel.ProductDetailsUnitInformation.UnitDepthOriginalValue.Value,
                    ["PropertyName"] = "UnitDepthOriginalValue",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsUnitInformation.UnitDepthOriginalValue = value)
                });
            }

            // Height
            if (productModel.ProductDetailsUnitInformation.UnitHeight.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Distance,
                    ["Value"] = productModel.ProductDetailsUnitInformation.UnitHeight.Value,
                    ["PropertyName"] = "UnitHeight",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsUnitInformation.UnitHeight = value)
                });
            }

            if (productModel.ProductDetailsUnitInformation.UnitHeightOriginalValue.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Distance,
                    ["Value"] = productModel.ProductDetailsUnitInformation.UnitHeightOriginalValue.Value,
                    ["PropertyName"] = "UnitHeightOriginalValue",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsUnitInformation.UnitHeightOriginalValue = value)
                });
            }

            // Weight
            if (productModel.ProductDetailsUnitInformation.UnitWeight.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Weight,
                    ["Value"] = productModel.ProductDetailsUnitInformation.UnitWeight.Value,
                    ["PropertyName"] = "UnitWeight",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsUnitInformation.UnitWeight = value)
                });
            }

            if (productModel.ProductDetailsUnitInformation.UnitWeightOriginalValue.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Weight,
                    ["Value"] = productModel.ProductDetailsUnitInformation.UnitWeightOriginalValue.Value,
                    ["PropertyName"] = "UnitWeightOriginalValue",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsUnitInformation.UnitWeightOriginalValue = value)
                });
            }

            // Width
            if (productModel.ProductDetailsUnitInformation.UnitWidth.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Distance,
                    ["Value"] = productModel.ProductDetailsUnitInformation.UnitWidth.Value,
                    ["PropertyName"] = "UnitWidth",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsUnitInformation.UnitWidth = value)
                });
            }

            if (productModel.ProductDetailsUnitInformation.UnitWidthOriginalValue.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Distance,
                    ["Value"] = productModel.ProductDetailsUnitInformation.UnitWidthOriginalValue.Value,
                    ["PropertyName"] = "UnitWidthOriginalValue",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsUnitInformation.UnitWidthOriginalValue = value)
                });
            }

            // Volume
            if (productModel.ProductDetailsUnitInformation.UnitVolume.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Volume,
                    ["Value"] = productModel.ProductDetailsUnitInformation.UnitVolume,
                    ["PropertyName"] = "UnitVolume",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsUnitInformation.UnitVolume = value)
                });
            }

            if (productModel.ProductDetailsUnitInformation.UnitVolumeOriginalValue.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Area,
                    ["Value"] = productModel.ProductDetailsUnitInformation.UnitVolumeOriginalValue,
                    ["PropertyName"] = "UnitVolumeOriginalValue",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsUnitInformation.UnitVolumeOriginalValue = value)
                });
            }

            // Carton Measurements
            // Area
            if (productModel.ProductDetailsWholesaleInformation.CartonInformationCartonArea.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Distance,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.CartonInformationCartonArea.Value,
                    ["PropertyName"] = "CartonArea",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.CartonInformationCartonArea = value)
                });
            }

            if (productModel.ProductDetailsWholesaleInformation.CartonInformationCartonAreaOriginalValue.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Distance,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.CartonInformationCartonAreaOriginalValue.Value,
                    ["PropertyName"] = "CartonAreaOriginalValue",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.CartonInformationCartonAreaOriginalValue = value)
                });
            }

            // Depth
            if (productModel.ProductDetailsWholesaleInformation.CartonInformationCartonDepth.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Distance,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.CartonInformationCartonDepth.Value,
                    ["PropertyName"] = "CartonDepth",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.CartonInformationCartonDepth = value)
                });
            }

            if (productModel.ProductDetailsWholesaleInformation.CartonInformationCartonDepthOriginalValue.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Distance,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.CartonInformationCartonDepthOriginalValue.Value,
                    ["PropertyName"] = "CartonDepthOriginalValue",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.CartonInformationCartonDepthOriginalValue = value)
                });
            }

            // Height
            if (productModel.ProductDetailsWholesaleInformation.CartonInformationCartonHeight.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Distance,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.CartonInformationCartonHeight.Value,
                    ["PropertyName"] = "CartonHeight",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.CartonInformationCartonHeight = value)
                });
            }

            if (productModel.ProductDetailsWholesaleInformation.CartonInformationCartonHeightOriginalValue.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Distance,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.CartonInformationCartonHeightOriginalValue.Value,
                    ["PropertyName"] = "CartonHeightOriginalValue",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.CartonInformationCartonHeightOriginalValue = value)
                });
            }

            // Packaging Weight
            if (productModel.ProductDetailsWholesaleInformation.CartonInformationCartonPackagingWeight.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Weight,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.CartonInformationCartonPackagingWeight.Value,
                    ["PropertyName"] = "CartonPackagingWeight",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.CartonInformationCartonPackagingWeight = value)
                });
            }

            if (productModel.ProductDetailsWholesaleInformation.CartonInformationCartonPackagingWeightOriginalValue.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Weight,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.CartonInformationCartonPackagingWeightOriginalValue.Value,
                    ["PropertyName"] = "CartonPackagingWeightOriginalValue",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.CartonInformationCartonPackagingWeightOriginalValue = value)
                });
            }

            // Total Carton Weight
            if (productModel.ProductDetailsWholesaleInformation.CartonInformationTotalCartonWeight.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Weight,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.CartonInformationTotalCartonWeight.Value,
                    ["PropertyName"] = "CartonTotalCartonWeight",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.CartonInformationTotalCartonWeight = value)
                });
            }

            if (productModel.ProductDetailsWholesaleInformation.CartonInformationTotalCartonWeightOriginalValue.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Weight,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.CartonInformationTotalCartonWeightOriginalValue.Value,
                    ["PropertyName"] = "CartonTotalCartonWeightOriginalValue",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.CartonInformationTotalCartonWeightOriginalValue = value)
                });
            }

            // Volume
            if (productModel.ProductDetailsWholesaleInformation.CartonInformationCartonVolume.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Volume,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.CartonInformationCartonVolume.Value,
                    ["PropertyName"] = "CartonVolume",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.CartonInformationCartonVolume = value)
                });
            }

            if (productModel.ProductDetailsWholesaleInformation.CartonInformationCartonVolumeOriginalValue.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Volume,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.CartonInformationCartonVolumeOriginalValue.Value,
                    ["PropertyName"] = "CartonVolumeOriginalValue",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.CartonInformationCartonVolumeOriginalValue = value)
                });
            }

            // Width
            if (productModel.ProductDetailsWholesaleInformation.CartonInformationCartonWidth.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Distance,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.CartonInformationCartonWidth.Value,
                    ["PropertyName"] = "CartonWidth",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.CartonInformationCartonWidth = value)
                });
            }

            if (productModel.ProductDetailsWholesaleInformation.CartonInformationCartonWidthOriginalValue.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Distance,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.CartonInformationCartonWidthOriginalValue.Value,
                    ["PropertyName"] = "CartonWidthOriginalValue",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.CartonInformationCartonWidthOriginalValue = value)
                });
            }

            // Pallet Measurements
            // Area
            if (productModel.ProductDetailsWholesaleInformation.PalletInformationPalletArea.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Area,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.PalletInformationPalletArea.Value,
                    ["PropertyName"] = "PalletArea",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.PalletInformationPalletArea = value)
                });
            }

            if (productModel.ProductDetailsWholesaleInformation.PalletInformationPalletAreaOriginalValue.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Area,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.PalletInformationPalletAreaOriginalValue.Value,
                    ["PropertyName"] = "PalletAreaOriginalValue",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.PalletInformationPalletAreaOriginalValue = value)
                });
            }

            // Depth
            if (productModel.ProductDetailsWholesaleInformation.PalletInformationPalletDepth.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Distance,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.PalletInformationPalletDepth.Value,
                    ["PropertyName"] = "PalletDepth",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.PalletInformationPalletDepth = value)
                });
            }

            if (productModel.ProductDetailsWholesaleInformation.PalletInformationPalletDepthOriginalValue.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Distance,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.PalletInformationPalletDepthOriginalValue.Value,
                    ["PropertyName"] = "PalletDepthOriginalValue",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.PalletInformationPalletDepthOriginalValue = value)
                });
            }

            // Height
            if (productModel.ProductDetailsWholesaleInformation.PalletInformationPalletHeight.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Distance,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.PalletInformationPalletHeight.Value,
                    ["PropertyName"] = "PalletHeight",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.PalletInformationPalletHeight = value)
                });
            }

            if (productModel.ProductDetailsWholesaleInformation.PalletInformationPalletHeightOriginalValue.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Distance,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.PalletInformationPalletHeightOriginalValue.Value,
                    ["PropertyName"] = "PalletHeightOriginalValue",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.PalletInformationPalletHeightOriginalValue = value)
                });
            }

            // Volume
            if (productModel.ProductDetailsWholesaleInformation.PalletInformationPalletVolume.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Volume,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.PalletInformationPalletVolume.Value,
                    ["PropertyName"] = "PalletVolume",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.PalletInformationPalletVolume = value)
                });
            }

            if (productModel.ProductDetailsWholesaleInformation.PalletInformationPalletVolumeOriginalValue.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Volume,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.PalletInformationPalletVolumeOriginalValue.Value,
                    ["PropertyName"] = "PalletVolumeOriginalValue",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.PalletInformationPalletVolumeOriginalValue = value)
                });
            }

            // Weight
            if (productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWeight.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Weight,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWeight.Value,
                    ["PropertyName"] = "PalletWeight",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWeight = value)
                });
            }

            if (productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWeightOriginalValue.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Weight,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWeightOriginalValue.Value,
                    ["PropertyName"] = "PalletWeightOriginalValue",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWeightOriginalValue = value)
                });
            }

            // Width
            if (productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWidth.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Distance,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWidth.Value,
                    ["PropertyName"] = "PalletWidth",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWidth = value)
                });
            }

            if (productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWidthOriginalValue.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Distance,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWidthOriginalValue.Value,
                    ["PropertyName"] = "PalletWidthOriginalValue",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWidthOriginalValue = value)
                });
            }

            // Total Pallet Height
            if (productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletHeight.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Distance,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletHeight.Value,
                    ["PropertyName"] = "TotalPalletHeight",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletHeight = value)
                });
            }

            if (productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletHeightOriginalValue.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Distance,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletHeightOriginalValue.Value,
                    ["PropertyName"] = "TotalPalletHeightOriginalValue",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletHeightOriginalValue = value)
                });
            }

            // Total Pallet Volume
            if (productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletVolume.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Volume,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletVolume.Value,
                    ["PropertyName"] = "TotalPalletVolume",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletVolume = value)
                });
            }

            if (productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletVolumeOriginalValue.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Volume,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletVolumeOriginalValue.Value,
                    ["PropertyName"] = "TotalPalletVolumeOriginalValue",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletVolumeOriginalValue = value)
                });
            }

            // Total Pallet Weight
            if (productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletWeight.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Weight,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletWeight.Value,
                    ["PropertyName"] = "TotalPalletWeight",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletWeight = value)
                });
            }

            if (productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletWeightOriginalValue.HasValue)
            {
                measurementData.Add(new Dictionary<string, object>
                {
                    ["MeasurementType"] = MeasurementType.Weight,
                    ["Value"] = productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletWeightOriginalValue.Value,
                    ["PropertyName"] = "TotalPalletWeightOriginalValue",
                    ["SetValue"] = new Action<decimal>(value => productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletWeightOriginalValue = value)
                });
            }

            return measurementData.ToArray();
        }

        public void ProcessUnitConversionResults(object[] conversionResults, ProductModel productModel)
        {
            try
            {
                foreach (var result in conversionResults)
                {
                    if (result is Dictionary<string, object> conversionData)
                    {
                        var propertyName = conversionData.GetValueOrDefault("PropertyName", string.Empty) as string;
                        var convertedValue = Convert.ToDecimal(conversionData.GetValueOrDefault("ConvertedValue", 0m));
                        var measurementType = (MeasurementType)conversionData.GetValueOrDefault("MeasurementType", MeasurementType.Distance);

                        // Log the conversion for debugging
                        System.Diagnostics.Debug.WriteLine($"Converted {propertyName}: {convertedValue} ({measurementType})");

                        // The SetValue actions in PrepareProductMeasurementConversionData should have already 
                        // updated the model, but you can add additional processing here if needed

                        // Example: Store original values for audit trail
                        StoreOriginalValueForAudit(
                            conversionData: conversionData, 
                            productModel: productModel,
                            propertyName: propertyName);
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrorMessageService("Error.Conversion.Processing", "Unit Conversion Results", ex.Message);
            }
        }

        public void StoreOriginalValueForAudit(Dictionary<string, object> conversionData, ProductModel productModel, string propertyName)
        {
            var originalValue = Convert.ToDecimal(conversionData.GetValueOrDefault("OriginalValue", 0m));
            var convertedValue = Convert.ToDecimal(conversionData.GetValueOrDefault("ConvertedValue", 0m));

            // Store original values in the model for audit purposes
            switch (propertyName)
            {
                case "UnitDepth":
                    productModel.ProductDetailsUnitInformation.UnitDepthOriginalValue = originalValue;
                    break;
                case "UnitHeight":
                    productModel.ProductDetailsUnitInformation.UnitHeightOriginalValue = originalValue;
                    break;
                case "UnitWidth":
                    productModel.ProductDetailsUnitInformation.UnitWidthOriginalValue = originalValue;
                    break;
                case "UnitWeight":
                    productModel.ProductDetailsUnitInformation.UnitWeightOriginalValue = originalValue;
                    break;
                case "UnitVolume":
                    productModel.ProductDetailsUnitInformation.UnitVolumeOriginalValue = originalValue;
                    break;
                case "UnitArea":
                    productModel.ProductDetailsUnitInformation.UnitAreaOriginalValue = originalValue;
                    break;
                // Add cases for carton measurements
                case "CartonDepth":
                    productModel.ProductDetailsWholesaleInformation.CartonInformationCartonDepthOriginalValue = originalValue;
                    break;
                case "CartonHeight":
                    productModel.ProductDetailsWholesaleInformation.CartonInformationCartonHeightOriginalValue = originalValue;
                    break;
                case "CartonWidth":
                    productModel.ProductDetailsWholesaleInformation.CartonInformationCartonWidthOriginalValue = originalValue;
                    break;
                case "CartonPackagingWeight":
                    productModel.ProductDetailsWholesaleInformation.CartonInformationCartonPackagingWeightOriginalValue = originalValue;
                    break;
                case "CartonVolume":
                    productModel.ProductDetailsWholesaleInformation.CartonInformationCartonVolumeOriginalValue = originalValue;
                    break;
                case "CartonArea":
                    productModel.ProductDetailsWholesaleInformation.CartonInformationCartonAreaOriginalValue = originalValue;
                    break;
                case "CartonTotalCartonWeight":
                    productModel.ProductDetailsWholesaleInformation.CartonInformationTotalCartonWeightOriginalValue = originalValue;
                    break;
                // Add cases for pallet measurements
                case "PalletDepth":
                    productModel.ProductDetailsWholesaleInformation.PalletInformationPalletDepthOriginalValue = originalValue;
                    break;
                case "PalletHeight":
                    productModel.ProductDetailsWholesaleInformation.PalletInformationPalletHeightOriginalValue = originalValue;
                    break;
                case "PalletWidth":
                    productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWidthOriginalValue = originalValue;
                    break;
                case "PalletWeight":
                    productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWeightOriginalValue = originalValue;
                    break;
                case "PalletVolume":
                    productModel.ProductDetailsWholesaleInformation.PalletInformationPalletVolumeOriginalValue = originalValue;
                    break;
                case "PalletArea":
                    productModel.ProductDetailsWholesaleInformation.PalletInformationPalletAreaOriginalValue = originalValue;
                    break;
                case "TotalPalletHeight":
                    productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletHeightOriginalValue = originalValue;
                    break;
                case "TotalPalletVolume":
                    productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletVolumeOriginalValue = originalValue;
                    break;
                case "TotalPalletWeight":
                    productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletWeightOriginalValue = originalValue;
                    break;
            }
        }

        public void RemoveProductImage(ImageList imageList, int index, ListView listView, ProductModel productModel)
        {
            if (index >= 0 && index < productModel.ProductImageList.Count)
            {
                productModel.ProductImageList.RemoveAt(index);
                UpdateProductImageListView(
                    imageList: imageList,
                    listView: listView,
                    productModel: productModel
                    );
            }
        }

        public void UpdateAvailableSalesSubRegionListView(ListView listView, ProductModel productModel)
        {
            listView.Items.Clear();

            foreach (var salesSubRegion in productModel.ProductSalesSubRegionAvailableList)
            {
                // Combine Sub Region + Region (this was previously only the sub region)
                string displayText = $"{salesSubRegion.SalesSubRegion} ({salesSubRegion.SalesRegion})";

                var item = new ListViewItem(displayText)
                {
                    Tag = salesSubRegion
                };
                listView.Items.Add(item);
            }
        }

        public void UpdateAvailableSupplierListView(ListView listView, ProductModel productModel)
        {
            listView.Items.Clear();
            foreach (var supplier in productModel.ProductSupplierRelationshipAvailableList)
            {
                var displayText = $"{supplier.SupplierName} ({supplier.SupplierId})";
                var item = new ListViewItem(displayText)
                {
                    Tag = supplier
                };
                listView.Items.Add(item);
            }
        }

        public void UpdateChosenSalesSubRegionListView(ListView listView, ProductModel productModel)
        {
            listView.Items.Clear();
            foreach (var salesSubRegion in productModel.ProductSalesSubRegionChosenList)
            {
                // Now show region in brackets (same format as available list)
                var item = new ListViewItem($"{salesSubRegion.SalesSubRegion} ({salesSubRegion.SalesRegion})")
                {
                    Tag = salesSubRegion
                };
                listView.Items.Add(item);
            }
        }

        public void UpdateChosenSupplierListView(ListView listView, ProductModel productModel)
        {
            listView.Items.Clear();
            foreach (var supplier in productModel.ProductSupplierRelationshipChosenList)
            {
                var displayText = $"{supplier.SupplierName} ({supplier.SupplierId})";
                var item = new ListViewItem(displayText)
                {
                    Tag = supplier
                };
                listView.Items.Add(item);
            }
        }

        public void UpdateProductImageListView(
            ImageList imageList,
            ListView listView,
            ProductModel productModel)
        {
            imageList.Images.Clear();
            listView.Items.Clear();
            for (int i = 0; i < productModel.ProductImageList.Count; i++)
            {
                using var ms = new MemoryStream(productModel.ProductImageList[i].ImageBytes);
                var img = Image.FromStream(ms);
                imageList.Images.Add(img);
                var item = new ListViewItem($"Image {i + 1} (Order: {productModel.ProductImageList[i].DisplayOrder})") { ImageIndex = i };
                listView.Items.Add(item);
            }
        }

        public void UpdateSupplierPriceTextBoxStates(
            ListView chosenSupplierListView,
            ComboBox wholesaleDeliveryTypeComboBox,
            TextBox wholesalePricePerCartonTextBoxA,
            TextBox wholesalePricePerCartonTextBoxB,
            TextBox wholesalePricePerPalletTextBoxA,
            TextBox wholesalePricePerPalletTextBoxB
            )
        {
            // Exit early if no supplier is selected
            if (chosenSupplierListView.SelectedItems.Count == 0)
            {
                // Hide all price textboxes when no supplier is selected
                wholesalePricePerCartonTextBoxA.Enabled = false;
                wholesalePricePerCartonTextBoxB.Enabled = false;
                wholesalePricePerPalletTextBoxA.Enabled = false;
                wholesalePricePerPalletTextBoxB.Enabled = false;
                wholesalePricePerCartonTextBoxA.ReadOnly = false;
                wholesalePricePerCartonTextBoxB.ReadOnly = false;
                return;
            }

            // Get the current delivery type
            string deliveryType = GetSelectedWholesaleDeliveryType(comboBox: wholesaleDeliveryTypeComboBox);

            // Reset all controls to default state
            wholesalePricePerCartonTextBoxA.Enabled = false;
            wholesalePricePerCartonTextBoxB.Enabled = false;
            wholesalePricePerPalletTextBoxA.Enabled = false;
            wholesalePricePerPalletTextBoxB.Enabled = false;
            wholesalePricePerCartonTextBoxA.ReadOnly = false;
            wholesalePricePerCartonTextBoxB.ReadOnly = false;

            // Enable appropriate textboxes based on delivery type
            switch (deliveryType)
            {
                case "Carton":
                    // Only carton pricing is enabled for direct carton delivery
                    wholesalePricePerCartonTextBoxA.Enabled = true;
                    wholesalePricePerCartonTextBoxB.Enabled = true;
                    break;

                case "Pallet - Unit":
                    // Only pallet pricing is enabled for direct pallet to unit delivery
                    wholesalePricePerPalletTextBoxA.Enabled = true;
                    wholesalePricePerPalletTextBoxB.Enabled = true;
                    break;

                case "Pallet - Carton":
                    // Both carton and pallet pricing, but carton is read-only (calculated)
                    wholesalePricePerCartonTextBoxA.Enabled = true;
                    wholesalePricePerCartonTextBoxB.Enabled = true;
                    wholesalePricePerCartonTextBoxA.ReadOnly = true;
                    wholesalePricePerCartonTextBoxB.ReadOnly = true;
                    wholesalePricePerPalletTextBoxA.Enabled = true;
                    wholesalePricePerPalletTextBoxB.Enabled = true;
                    break;

                default:
                    // Unknown delivery type or no delivery type selected - disable all
                    break;
            }
        }

        public static void UpdateWholesalePriceControls(
            WholesalePriceCalculationResult calculationResult,
            Action<string, string> updateUnitPriceAction,
            Action<string, string>? updateCartonPriceAction = null)
        {
            if (!calculationResult.Success)
                return;

            // Update unit price controls
            if (updateUnitPriceAction != null)
            {
                SplitDecimalHelper.SplitDecimalUsingDelimiter(calculationResult.PricePerUnit, out string unitPricePartA, out string unitPricePartB);
                updateUnitPriceAction(unitPricePartA, unitPricePartB);
            }

            // Update carton price controls if needed (for Pallet - Carton delivery type)
            if (calculationResult.CartonPrice.HasValue && updateCartonPriceAction != null)
            {
                SplitDecimalHelper.SplitDecimalUsingDelimiter(calculationResult.CartonPrice.Value, out string cartonPricePartA, out string cartonPricePartB);
                updateCartonPriceAction(cartonPricePartA, cartonPricePartB);
            }
        }

        public async Task<bool> ValidateWholesaleDataModel(ProductModel productModel, ComboBox wholesaleDeliveryTypeComboBox)
        {
            string deliveryType = GetSelectedWholesaleDeliveryType(comboBox: wholesaleDeliveryTypeComboBox);
            var missingProperties = new List<string>();

            if (deliveryType == "Carton" || deliveryType == "Pallet - Carton")
            {
                // Validate Carton Information
                if (!productModel.ProductDetailsWholesaleInformation.CartonInformationCartonArea.HasValue)
                    missingProperties.Add("Carton Area");

                if (string.IsNullOrEmpty(productModel.ProductDetailsWholesaleInformation.CartonInformationCartonBarcode))
                    missingProperties.Add("Carton Barcode");

                if (!productModel.ProductDetailsWholesaleInformation.CartonInformationCartonDepth.HasValue)
                    missingProperties.Add("Carton Depth");

                if (!productModel.ProductDetailsWholesaleInformation.CartonInformationCartonHeight.HasValue)
                    missingProperties.Add("Carton Height");

                if (!productModel.ProductDetailsWholesaleInformation.CartonInformationCartonPackagingWeight.HasValue)
                    missingProperties.Add("Carton Packaging Weight");

                if (!productModel.ProductDetailsWholesaleInformation.CartonInformationCartonVolume.HasValue)
                    missingProperties.Add("Carton Volume");

                if (!productModel.ProductDetailsWholesaleInformation.CartonInformationCartonWidth.HasValue)
                    missingProperties.Add("Carton Width");

                if (!productModel.ProductDetailsWholesaleInformation.CartonInformationTotalCartonWeight.HasValue)
                    missingProperties.Add("Total Carton Weight");

                if (!productModel.ProductDetailsWholesaleInformation.CartonInformationUnitQuantityPerCarton.HasValue)
                    missingProperties.Add("Unit Quantity Per Carton");
            }

            if (deliveryType == "Pallet - Carton" || deliveryType == "Pallet - Unit")
            {
                // Validate Pallet Information
                if (!productModel.ProductDetailsWholesaleInformation.PalletInformationPalletArea.HasValue)
                    missingProperties.Add("Pallet Area");

                if (string.IsNullOrEmpty(productModel.ProductDetailsWholesaleInformation.PalletInformationPalletBarcode))
                    missingProperties.Add("Pallet Barcode");

                if (!productModel.ProductDetailsWholesaleInformation.PalletInformationPalletDepth.HasValue)
                    missingProperties.Add("Pallet Depth");

                if (!productModel.ProductDetailsWholesaleInformation.PalletInformationPalletHeight.HasValue)
                    missingProperties.Add("Pallet Height");

                if (!productModel.ProductDetailsWholesaleInformation.PalletInformationPalletVolume.HasValue)
                    missingProperties.Add("Pallet Volume");

                if (!productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWeight.HasValue)
                    missingProperties.Add("Pallet Weight");

                if (!productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWidth.HasValue)
                    missingProperties.Add("Pallet Width");

                if (!productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletHeight.HasValue)
                    missingProperties.Add("Total Pallet Height");

                if (!productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletVolume.HasValue)
                    missingProperties.Add("Total Pallet Volume");

                if (!productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletWeight.HasValue)
                    missingProperties.Add("Total Pallet Weight");
            }

            if (deliveryType == "Pallet - Carton")
            {
                // Validate Pallet-Carton specific information
                if (!productModel.ProductDetailsWholesaleInformation.PalletInformationCartonQuantityPerPallet.HasValue)
                    missingProperties.Add("Carton Quantity Per Pallet");

                if (!productModel.ProductDetailsWholesaleInformation.PalletInformationCartonQuantityPerPalletLevel.HasValue)
                    missingProperties.Add("Carton Quantity Per Pallet Level");

                if (!productModel.ProductDetailsWholesaleInformation.PalletInformationCartonStackingHeightPallet.HasValue)
                    missingProperties.Add("Carton Stacking Height on Pallet");
            }

            if (deliveryType == "Pallet - Unit")
            {
                // Validate Pallet-Unit specific information
                if (!productModel.ProductDetailsWholesaleInformation.PalletInformationUnitQuantityPerPallet.HasValue)
                    missingProperties.Add("Unit Quantity Per Pallet");

                if (!productModel.ProductDetailsWholesaleInformation.PalletInformationUnitQuantityPerPalletLevel.HasValue)
                    missingProperties.Add("Unit Quantity Per Pallet Level");

                if (!productModel.ProductDetailsWholesaleInformation.PalletInformationUnitStackingHeightPallet.HasValue)
                    missingProperties.Add("Unit Stacking Height on Pallet");
            }

            // If there are missing properties, generate and display a dynamic warning message
            if (missingProperties.Count > 0)
            {
                string missingPropertiesText = BuildMissingPropertiesMessage(missingProperties, deliveryType);
                new ErrorMessageService("Warning.Data.Validation.Dynamic", missingPropertiesText);
                return false;
            }

            return true;
        }

        public static WholesalePriceCalculationResult CalculateWholesalePricePerUnit(
            ProductModel productModel,
            ProductSupplierRelationshipChosenList supplier,
            string deliveryType)
        {
            try
            {
                var result = new WholesalePriceCalculationResult();

                if (string.IsNullOrEmpty(deliveryType) || supplier == null || productModel?.ProductDetailsWholesaleInformation == null)
                {
                    return result;
                }

                decimal pricePerUnit = 0;
                decimal? cartonPrice = null;

                if (deliveryType == "Carton")
                {
                    if (supplier.WholesalePricePerCarton.HasValue)
                    {
                        var unitQuantityPerCarton = productModel.ProductDetailsWholesaleInformation.CartonInformationUnitQuantityPerCarton;
                        if (unitQuantityPerCarton.HasValue && unitQuantityPerCarton.Value > 0)
                        {
                            pricePerUnit = supplier.WholesalePricePerCarton.Value / unitQuantityPerCarton.Value;
                        }
                    }
                }
                else if (deliveryType == "Pallet - Carton")
                {
                    if (supplier.WholesalePricePerPallet.HasValue)
                    {
                        var cartonQuantityPerPallet = productModel.ProductDetailsWholesaleInformation.PalletInformationCartonQuantityPerPallet;
                        var unitQuantityPerCarton = productModel.ProductDetailsWholesaleInformation.CartonInformationUnitQuantityPerCarton;

                        if (cartonQuantityPerPallet.HasValue && unitQuantityPerCarton.HasValue &&
                            cartonQuantityPerPallet.Value > 0 && unitQuantityPerCarton.Value > 0)
                        {
                            // Calculate carton price from pallet price
                            cartonPrice = supplier.WholesalePricePerPallet.Value / cartonQuantityPerPallet.Value;
                            supplier.WholesalePricePerCarton = cartonPrice;

                            // Calculate unit price
                            pricePerUnit = cartonPrice.Value / unitQuantityPerCarton.Value;
                        }
                    }
                }
                else if (deliveryType == "Pallet - Unit")
                {
                    if (supplier.WholesalePricePerPallet.HasValue)
                    {
                        var unitQuantityPerPallet = productModel.ProductDetailsWholesaleInformation.PalletInformationUnitQuantityPerPallet;
                        if (unitQuantityPerPallet.HasValue && unitQuantityPerPallet > 0)
                        {
                            pricePerUnit = supplier.WholesalePricePerPallet.Value / unitQuantityPerPallet.Value;
                        }
                    }
                }

                // Update the supplier model
                supplier.WholesalePricePerUnit = pricePerUnit;

                // Prepare result
                result.Success = true;
                result.PricePerUnit = pricePerUnit;
                result.CartonPrice = cartonPrice;
                result.Supplier = supplier;

                return result;
            }
            catch (Exception ex)
            {
                new ErrorMessageService("Error.Calculation.Dynamic", "Wholesale Price Per Unit", ex.Message);
                return new WholesalePriceCalculationResult();
            }
        }
    }
}