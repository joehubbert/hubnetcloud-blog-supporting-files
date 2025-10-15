using CRM.Helpers;
using CRM.Model;
using CRM.Presentation.General;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.Product
{
    public partial class CreateProduct : Form
    {
        private string _companyConfigurationBankAccountCurrencyCode;
        private Guid _companyConfigurationId;
        private ActiveCompanyConfigurationHelper? _companyConfigHelper;
        private DataOperationsService _dataOperationsService = new DataOperationsService();
        private GeneralSharedComponents _generalSharedComponents = new GeneralSharedComponents();
        private NumericParserHelper _numericParserHelper = new NumericParserHelper();
        private ProductSharedComponents _productSharedComponents = new ProductSharedComponents();
        private ProductModel _productModel = new ProductModel();
        private bool _suppressDateValidation = false;
        private bool _suppressWholesalePricePerCartonTextChanged = false;
        private bool _suppressWholesalePricePerPalletTextChanged = false;
        private List<TextBoxCharactersRemainingHelper> _textBoxCharactersRemainingHelpers = new();
        private TextBoxNumericCharacterDataValidationHelper _textBoxNumericChracterDataValidationHelper = new TextBoxNumericCharacterDataValidationHelper();
        private TranslationService _translationService = new TranslationService();
        private UIModelHelper _uiModelHelper = new UIModelHelper();
        private bool _wholesaleDeliveryTypeLoading = false;
        private LanguageRegionCode activeLanguageRegionCode;
        private UnitType activeUnitType;

        public CreateProduct()
        {
            InitializeComponent();
            InitializeEventHandlers();
            this.Load += CreateProduct_Load;
        }

        private async void CreateProduct_Load(object? sender, EventArgs e)
        {
            await LoadActiveCompanyConfigurationAsync();
            await LoadUserPreferencesAsync();
            await LoadComboBoxData();
            _productSharedComponents.ConfigureListViews(
                availableListView: createProductTabControlProductSalesSubRegionAvailabilityTabPageAvailableSalesSubRegionListView,
                chosenListView: createProductTabControlProductSalesSubRegionAvailabilityTabPageChosenSalesSubRegionListView,
                functionTitle: FunctionTitle.SalesSubRegion
                );
            _productSharedComponents.ConfigureListViews(
                availableListView: createProductTabControlProductSupplierRelationshipTabPageAvailableSupplierListView,
                chosenListView: createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView,
                functionTitle: FunctionTitle.Supplier
                );
            createProductTabControlProductSalesSubRegionAvailabilityTabPageSalesRegionComboBox_SelectedIndexChanged(sender, e);
        }

        private void InitializeEventHandlers()
        {
            createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductCategoryComboBox.SelectedIndexChanged += createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductCategoryComboBox_SelectedIndexChanged;
            createProductTabControlProductImageTabPageImageListView.SelectedIndexChanged += createProductTabControlProductImageTabPageImageListView_SelectedIndexChanged;
            createProductTabControlProductImageTabPageImageListViewDownButton.Click += createProductTabControlProductImageTabPageMoveImageDownButton_Click;
            createProductTabControlProductImageTabPageImageListViewUpButton.Click += createProductTabControlProductImageTabPageMoveImageUpButton_Click;
            createProductTabControlProductImageTabPageProductImageAltTextTextBox.TextChanged += createProductTabControlProductImageTabPageProductImageAltTextTextBox_TextChanged;
            createProductTabControlProductImageTabPageProductImageCaptionTextBox.TextChanged += createProductTabControlProductImageTabPageProductImageCaptionTextBox_TextChanged;
            createProductTabControlProductImageTabPageProductImageIsThumbnailCheckBox.CheckedChanged += createProductTabControlProductImageTabPageProductImageIsThumbnailCheckBox_CheckedChanged;
            createProductTabControlProductSalesSubRegionAvailabilityTabPageActiveProductSalesSubRegionAvailabilityCheckBox.CheckedChanged += createProductTabControlProductSalesSubRegionAvailabilityTabPageActiveProductSalesSubRegionAvailabilityCheckBox_CheckedChanged;
            createProductTabControlProductSalesSubRegionAvailabilityTabPageChosenSalesSubRegionListView.SelectedIndexChanged += createProductTabControlProductSalesSubRegionAvailabilityTabPageChosenSalesSubRegionListView_SelectedIndexChanged;
            createProductTabControlProductSalesSubRegionAvailabilityTabPageEffectiveDatePicker.ValueChanged += createProductTabControlProductSalesSubRegionAvailabilityTabPageEffectiveDatePicker_ValueChanged;
            createProductTabControlProductSalesSubRegionAvailabilityTabPageExpiryDateChoicePanelNoRadioButton.CheckedChanged += SalesSubRegionExpiryDatePanelRadioButton_CheckedChanged;
            createProductTabControlProductSalesSubRegionAvailabilityTabPageExpiryDateChoicePanelYesRadioButton.CheckedChanged += SalesSubRegionExpiryDatePanelRadioButton_CheckedChanged;
            createProductTabControlProductSalesSubRegionAvailabilityTabPageExpiryDatePicker.ValueChanged += createProductTabControlProductSalesSubRegionAvailabilityTabPageExpiryDatePicker_ValueChanged;
            createProductTabControlProductSalesSubRegionAvailabilityTabPageMoveSalesSubRegionToAvailableListViewButton.Click += createProductTabControlProductSalesSubRegionAvailabilityTabPageMoveSalesSubRegionToAvailableListViewButton_Click;
            createProductTabControlProductSalesSubRegionAvailabilityTabPageMoveSalesSubRegionToChosenListViewButton.Click += createProductTabControlProductSalesSubRegionAvailabilityTabPageMoveSalesSubRegionToChosenListViewButton_Click;
            createProductTabControlProductSalesSubRegionAvailabilityTabPageSalesRegionComboBox.SelectedIndexChanged += createProductTabControlProductSalesSubRegionAvailabilityTabPageSalesRegionComboBox_SelectedIndexChanged;
            createProductTabControlProductSupplierRelationshipTabPageActiveProductSupplierRelationshipCheckBox.CheckedChanged += createProductTabControlProductSupplierRelationshipTabPageActiveProductSupplierRelationshipCheckBox_CheckedChanged;
            createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView.SelectedIndexChanged += createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView_SelectedIndexChanged;
            createProductTabControlProductSupplierRelationshipTabPageDeliveryLeadTimeDaysTextBox.TextChanged += createProductTabControlProductSupplierRelationshipTabPageDeliveryLeadTimeDaysTextBox_TextChanged;
            createProductTabControlProductSupplierRelationshipTabPageMoveSupplierToAvailableListViewButton.Click += createProductTabControlProductSupplierRelationshipTabPageMoveSupplierToAvailableListViewButton_Click;
            createProductTabControlProductSupplierRelationshipTabPageMoveSupplierToChosenListViewButton.Click += createProductTabControlProductSupplierRelationshipTabPageMoveSupplierToChosenListViewButton_Click;
            createProductTabControlProductSupplierRelationshipTabPageSupplierProductCodeTextBox.TextChanged += createProductTabControlProductSupplierRelationshipTabPageSupplierProductCodeTextBox_TextChanged;
            createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxA.TextChanged += createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBox_TextChanged;
            createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxB.TextChanged += createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBox_TextChanged;
            createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxA.TextChanged += createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBox_TextChanged;
            createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxB.TextChanged += createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBox_TextChanged;

            var barcodeTextBoxes = new[]
            {
                createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitBarcodeTextBox,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonBarcodeTextBox,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletBarcodeTextBox
            };

            var calculateWholesalePricePerUnitControls = new[]
            {
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxUnitQuantityPerCartonTextBox,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleDeliveryTypeComboBox,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxCartonQuantityPerPalletLevelTextBox,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxUnitQuantityPerPalletLevelTextBox,
                (Control)createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxA,
                (Control)createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxB,
                (Control)createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxA,
                (Control)createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxB
            };

            var characterRemainingControls = new[]
            {
                new { Label = createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductNameTextBoxCharacterRemainingLabel, TextBox = createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductNameTextBox},
                new { Label = createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductDescriptionTextBoxCharacterRemainingLabel, TextBox = createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductDescriptionTextBox},
                new { Label = createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageManufacturerPartNumberTextBoxCharacterRemainingLabel, TextBox = createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageManufacturerPartNumberTextBox},
                new { Label = createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitBarcodeTextBoxCharacterRemainingLabel, TextBox = createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitBarcodeTextBox},
                new { Label = createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonBarcodeTextBoxCharacterRemainingLabel, TextBox = createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonBarcodeTextBox},
                new { Label = createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletBarcodeTextBoxCharacterRemainingLabel, TextBox = createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletBarcodeTextBox},
                new { Label = createProductTabControlProductImageTabPageProductImageAltTextTextBoxCharacterRemainingLabel, TextBox = createProductTabControlProductImageTabPageProductImageAltTextTextBox},
                new { Label = createProductTabControlProductImageTabPageProductImageCaptionTextBoxCharacterRemainingLabel, TextBox = createProductTabControlProductImageTabPageProductImageCaptionTextBox},
                new { Label = createProductTabControlProductSupplierRelationshipTabPageSupplierProductCodeTextBoxCharacterRemainingLabel, TextBox = createProductTabControlProductSupplierRelationshipTabPageSupplierProductCodeTextBox}
            };

            var comboBoxControls = new[]
            {
                createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductCategoryComboBox,
                createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageManufacturerComboBox,
                createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductCountryOfOriginComboBox,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleDeliveryTypeComboBox,
                createProductTabControlProductSalesSubRegionAvailabilityTabPageSalesRegionComboBox
            };

            var numericValidationHelperTextBoxes = new[]
            {
                createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitDepthTextBoxA,
                createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitDepthTextBoxB,
                createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitHeightTextBoxA,
                createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitHeightTextBoxB,
                createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitMinimumStockQuantityTextBox,
                createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitPriceTextBoxA,
                createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitPriceTextBoxB,
                createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitWeightTextBoxA,
                createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitWeightTextBoxB,
                createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitWidthTextBoxA,
                createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitWidthTextBoxB,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonDepthTextBoxA,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonDepthTextBoxB,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonHeightTextBoxA,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonHeightTextBoxB,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonPackagingWeightTextBoxA,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonPackagingWeightTextBoxB,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonWidthTextBoxA,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonWidthTextBoxB,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxUnitQuantityPerCartonTextBox,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxCartonStackingHeightPalletTextBox,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletDepthTextBoxA,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletDepthTextBoxB,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletHeightTextBoxA,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletHeightTextBoxB,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletWeightTextBoxA,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletWeightTextBoxB,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletWidthTextBoxA,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletWidthTextBoxB,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxUnitStackingHeightPalletTextBox,
                createProductTabControlProductSupplierRelationshipTabPageDeliveryLeadTimeDaysTextBox,
                createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxA,
                createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxB,
                createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxA,
                createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxB
            };

            var productDetailsGeneralInformationControls = new[]
            {
                (Control)createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageActiveStatusCheckBox,
                (Control)createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductCategoryComboBox,
                (Control)createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductCountryOfOriginComboBox,
                (Control)createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductDescriptionTextBox,
                (Control)createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductFamilyPanelYesRadioButton,
                (Control)createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductFamilyPanelNoRadioButton,
                (Control)createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductFamilyPanelProductFamilyComboBox,
                (Control)createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageManufacturerComboBox,
                (Control)createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageManufacturerPartNumberTextBox,
                (Control)createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductNameTextBox,
                (Control)createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductSubCategoryComboBox
            };

            var productDetailsUnitInformationControls = new[]
            {
                (Control)createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitBarcodeTextBox,
                (Control)createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitDepthTextBoxA,
                (Control)createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitDepthTextBoxB,
                (Control)createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitHeightTextBoxA,
                (Control)createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitHeightTextBoxB,
                (Control)createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitMinimumStockQuantityTextBox,
                (Control)createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitPriceTextBoxA,
                (Control)createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitPriceTextBoxB,
                (Control)createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitWeightTextBoxA,
                (Control)createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitWeightTextBoxB,
                (Control)createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitWidthTextBoxA,
                (Control)createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitWidthTextBoxB
            };

            var productDetailsWholesaleInformationControls = new[]
            {
                (Control)createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitDepthTextBoxA,
                (Control)createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitDepthTextBoxB,
                (Control)createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitHeightTextBoxA,
                (Control)createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitHeightTextBoxB,
                (Control)createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitWeightTextBoxA,
                (Control)createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitWeightTextBoxB,
                (Control)createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitWidthTextBoxA,
                (Control)createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitWidthTextBoxB,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonBarcodeTextBox,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonDepthTextBoxA,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonDepthTextBoxB,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonHeightTextBoxA,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonHeightTextBoxB,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonPackagingWeightTextBoxA,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonPackagingWeightTextBoxB,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonWidthTextBoxA,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonWidthTextBoxB,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxUnitQuantityPerCartonTextBox,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleDeliveryTypeComboBox,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleEnabledPanelNoRadioButton,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleEnabledPanelYesRadioButton,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleReorderFlagPanelNoRadioButton,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleReorderFlagPanelYesRadioButton,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxCartonStackingHeightPalletTextBox,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletBarcodeTextBox,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletDepthTextBoxA,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletDepthTextBoxB,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletHeightTextBoxA,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletHeightTextBoxB,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletWeightTextBoxA,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletWeightTextBoxB,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletWidthTextBoxA,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletWidthTextBoxB,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxUnitStackingHeightPalletTextBox
            };

            var wholesaleInformationTabRenderControls = new[]
            {
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleDeliveryTypeComboBox,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleEnabledPanelNoRadioButton,
                (Control)createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleEnabledPanelYesRadioButton
            };

            foreach (var textBox in barcodeTextBoxes)
            {
                textBox.TextChanged += (sender, e) => _productSharedComponents.ValidateBarcodeInput(
                        unitBarcode: createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitBarcodeTextBox,
                        cartonBarcode: createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonBarcodeTextBox,
                        palletBarcode: createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletBarcodeTextBox
                    );
            }

            foreach (var item in calculateWholesalePricePerUnitControls)
            {
                if (item is TextBox textBox)
                {
                    textBox.TextChanged += CalculateWholesalePricePerUnit;
                }
                else if (item is ComboBox comboBox)
                {
                    comboBox.SelectedIndexChanged += CalculateWholesalePricePerUnit;
                }
            }

            foreach (var dataSubject in characterRemainingControls)
            {
                if (dataSubject.Label != null && dataSubject.TextBox != null)
                {
                    _textBoxCharactersRemainingHelpers.Add(new TextBoxCharactersRemainingHelper(dataSubject.Label, dataSubject.TextBox));
                }
            }

            foreach (var comboBox in comboBoxControls)
            {
                if (comboBox != null)
                {
                    comboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
                }
            }

            foreach (var textBox in numericValidationHelperTextBoxes)
            {
                if (textBox != null)
                {
                    textBox.KeyPress += _textBoxNumericChracterDataValidationHelper.NumericKeyPressHandler;
                }
            }

            foreach (var control in productDetailsGeneralInformationControls)
            {
                if (control is ComboBox comboBox)
                {
                    comboBox.SelectedIndexChanged += PopulateProductDetailsGeneralInformationModel;
                }
                else if (control is RadioButton radioButton)
                {
                    radioButton.CheckedChanged += PopulateProductDetailsGeneralInformationModel;
                }
                else if (control is CheckBox checkBox)
                {
                    checkBox.CheckedChanged += PopulateProductDetailsGeneralInformationModel;
                }
                else if (control is TextBox textBox)
                {
                    textBox.TextChanged += PopulateProductDetailsGeneralInformationModel;
                }
            }

            foreach (var control in productDetailsUnitInformationControls)
            {
                if (control is TextBox textBox)
                {
                    textBox.TextChanged += PopulateProductDetailsUnitInformationModel;
                }
            }

            foreach (var control in productDetailsWholesaleInformationControls)
            {
                if (control is ComboBox comboBox)
                {
                    comboBox.SelectedIndexChanged += PopulateProductDetailsWholesaleInformationModel;
                }
                else if (control is RadioButton radioButton)
                {
                    radioButton.CheckedChanged += PopulateProductDetailsWholesaleInformationModel;
                }
                else if (control is TextBox textBox)
                {
                    textBox.TextChanged += PopulateProductDetailsWholesaleInformationModel;
                }
            }

            foreach (var control in wholesaleInformationTabRenderControls)
            {
                if (control is ComboBox comboBox)
                {
                    comboBox.SelectedIndexChanged += RenderWholesaleInformationTabPageControls;
                }
                else if (control is RadioButton radioButton)
                {
                    radioButton.CheckedChanged += RenderWholesaleInformationTabPageControls;
                }
            }
        }

        private void CalculateWholesalePricePerUnit(object? sender, EventArgs e)
        {
            try
            {
                // Exit early if loading data
                if (_wholesaleDeliveryTypeLoading)
                    return;

                // Check if a supplier is selected
                if (createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView.SelectedItems.Count == 0)
                    return;

                var item = createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView.SelectedItems[0];
                if (item.Tag == null)
                    return;

                var supplier = (ProductSupplierRelationshipChosenList)item.Tag;

                // Get delivery type safely
                string deliveryType = _productSharedComponents.GetSelectedWholesaleDeliveryType(comboBox: createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleDeliveryTypeComboBox);
                if (string.IsNullOrEmpty(deliveryType))
                    return;

                // IMPORTANT: If the sender is a pallet price textbox and delivery type uses pallet pricing,
                // exit immediately - let the dedicated TextChanged handler manage this
                if (sender == createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxA ||
                    sender == createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxB)
                {
                    if (deliveryType == "Pallet - Carton" || deliveryType == "Pallet - Unit")
                    {
                        return; // Exit - don't interfere with manual pallet price entry
                    }
                }

                // Use the reusable method for calculations triggered by other controls
                ProductSharedComponents.CalculateAndUpdateWholesalePriceControls(
                    chosenSupplierList: supplier,
                    deliveryType: deliveryType,
                    productModel: _productModel,
                    // Unit price update delegate
                    (unitPartA, unitPartB) =>
                    {
                        createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerUnitTextBoxA.Text = unitPartA;
                        createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerUnitTextBoxB.Text = unitPartB;
                    },
                    // Carton price update delegate (for "Pallet - Carton" delivery type)
                    (cartonPartA, cartonPartB) =>
                    {
                        createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxA.Text = cartonPartA;
                        createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxB.Text = cartonPartB;
                    }
                );
            }
            catch (Exception ex)
            {
                new ErrorMessageService("Error.Calculation.Dynamic", "Wholesale Price Per Unit", ex.Message);
            }
        }

        private async Task LoadActiveCompanyConfigurationAsync()
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(createProductStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.LoadAsync();
            _companyConfigurationId = _companyConfigHelper.CompanyConfigurationId;

            // Create the lookup helper
            var lookupHelper = new DataAccessLookupHelper(FunctionTitle.CompanyConfiguration, _companyConfigurationId);

            // Fetch data on background thread
            DataTable? dataTable = await lookupHelper.GetFilteredDataTableAsync();

            // Extract the company configuration bank account currency code
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                if (dataTable.Columns.Contains("Bank Account Currency Code"))
                {
                    _companyConfigurationBankAccountCurrencyCode = row["Bank Account Currency Code"].ToString();
                }
            }
        }

        private async Task LoadComboBoxData()
        {
            await LoadProductCategoryDataAsync();
            await LoadProductCategoryAndProductSubCategoryDataAsync();
            await _generalSharedComponents.LoadManufacturerDataAsync(comboBox: createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageManufacturerComboBox);
            await _generalSharedComponents.LoadCountryDataAsync(comboBox: createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductCountryOfOriginComboBox);
            await LoadWholesaleDeliveryTypeAsync();
            await LoadSalesRegionAsync();
            await LoadSalesRegionAndSubRegionsAsync();
            await _productSharedComponents.LoadSupplierAsync(
                availableSupplierListView: createProductTabControlProductSupplierRelationshipTabPageAvailableSupplierListView,
                chosenSupplierListView: createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView,
                companyConfigurationId: _companyConfigurationId,
                productModel: _productModel
                );
        }

        private async Task LoadProductCategoryDataAsync()
        {
            await _generalSharedComponents.LoadProductCategoryDataAsync(
                comboBox: createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductCategoryComboBox,
                companyConfigurationId: _companyConfigurationId
                );
        }

        private async Task LoadProductFamilyDataAsync()
        {
            await _generalSharedComponents.LoadProductFamilyDataAsync(
                comboBox: createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductFamilyPanelProductFamilyComboBox,
                companyConfigurationId: _companyConfigurationId
                );
        }

        private async Task LoadProductSubCategoryAsync(Guid productCategoryId)
        {
            await _generalSharedComponents.LoadProductSubCategoryDataAsync(
                    comboBox: createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductSubCategoryComboBox,
                    productCategoryId: productCategoryId
                    );
        }

        private async Task LoadProductCategoryAndProductSubCategoryDataAsync()
        {
            await LoadProductCategoryDataAsync();
            if (createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductCategoryComboBox.SelectedValue is Guid selectedProductCategoryId)
            {
                await LoadProductSubCategoryAsync(selectedProductCategoryId);
            }
        }

        private async Task LoadSalesRegionAsync()
        {
            await _generalSharedComponents.LoadSalesRegionDataAsync(
                comboBox: createProductTabControlProductSalesSubRegionAvailabilityTabPageSalesRegionComboBox,
                companyConfigurationId: _companyConfigurationId
                );
        }

        private async Task LoadSalesRegionAndSubRegionsAsync()
        {
            await Task.Run(async () =>
            {
                // Load sales regions
                await Task.Run(() => LoadSalesRegionAsync());
                // Wait for UI thread to update combo box
                this.Invoke(new Action(async () =>
                {
                    // Get first region ID
                    Guid firstRegionId = _productSharedComponents.GetFirstSalesRegionId(comboBox: createProductTabControlProductSalesSubRegionAvailabilityTabPageSalesRegionComboBox);
                    if (firstRegionId != Guid.Empty)
                    {
                        await _productSharedComponents.LoadSalesSubRegionsAsync(
                            listView: createProductTabControlProductSalesSubRegionAvailabilityTabPageAvailableSalesSubRegionListView,
                            productModel: _productModel,
                            salesRegionId: firstRegionId
                            );
                    }
                }));
            });
        }

        private async Task LoadUserPreferencesAsync()
        {
            activeLanguageRegionCode = await ApplicationConfigurationService.GetLanguageRegionCodeAsync();
            activeUnitType = await ApplicationConfigurationService.GetUnitTypeAsync();

            Label[] separatorLabelList =
            {
                createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitPriceTextBoxSeparatorLabel,
                createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitDepthTextBoxSeparatorLabel,
                createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitHeightTextBoxSeparatorLabel,
                createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitWeightTextBoxSeparatorLabel,
                createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitWidthTextBoxSeparatorLabel,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonDepthTextBoxSeparatorLabel,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonHeightTextBoxSeparatorLabel,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonWeightTextBoxSeparatorLabel,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonWidthTextBoxSeparatorLabel,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletDepthTextBoxSeparatorLabel,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletHeightTextBoxSeparatorLabel,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletWeightTextBoxSeparatorLabel,
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletWidthTextBoxSeparatorLabel
            };

            foreach (var label in separatorLabelList)
            {
                if (label != null)
                    await DelimeterLabelHelper.SetLabelToDelimeterAsync(label);
            }

            var measurementLabelList = new[]
            {
                new { Label = createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitAreaTextBoxLabel, MeasurementType = MeasurementType.Area, Mandatory = false },
                new { Label = createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitDepthTextBoxLabel, MeasurementType = MeasurementType.Distance, Mandatory = true },
                new { Label = createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitHeightTextBoxLabel, MeasurementType = MeasurementType.Distance, Mandatory = true },
                new { Label = createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitVolumeTextBoxLabel, MeasurementType = MeasurementType.Volume, Mandatory = false },
                new { Label = createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitWeightTextBoxLabel, MeasurementType = MeasurementType.Weight, Mandatory = true },
                new { Label = createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitWidthTextBoxLabel, MeasurementType = MeasurementType.Distance, Mandatory = true },
                new { Label = createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonDepthTextBoxLabel, MeasurementType = MeasurementType.Distance, Mandatory = true },
                new { Label = createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonHeightTextBoxLabel, MeasurementType = MeasurementType.Distance, Mandatory = true },
                new { Label = createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonVolumeTextBoxLabel, MeasurementType = MeasurementType.Volume, Mandatory = false },
                new { Label = createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonPackagingWeightTextBoxLabel, MeasurementType = MeasurementType.Weight, Mandatory = true },
                new { Label = createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonTotalWeightTextBoxLabel, MeasurementType = MeasurementType.Weight, Mandatory = false },
                new { Label = createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonWidthTextBoxLabel, MeasurementType = MeasurementType.Distance, Mandatory = true },
                new { Label = createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletDepthTextBoxLabel, MeasurementType = MeasurementType.Distance, Mandatory = true },
                new { Label = createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletHeightTextBoxLabel, MeasurementType = MeasurementType.Distance, Mandatory = true },
                new { Label = createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletAreaTextBoxLabel, MeasurementType = MeasurementType.Area, Mandatory = false },
                new { Label = createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletVolumeTextBoxLabel, MeasurementType = MeasurementType.Volume, Mandatory = false },
                new { Label = createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletWeightTextBoxLabel, MeasurementType = MeasurementType.Weight, Mandatory = true },
                new { Label = createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletWidthTextBoxLabel, MeasurementType = MeasurementType.Distance, Mandatory = true }
            };

            foreach (var label in measurementLabelList)
            {
                await MeasurementLabelHelper.SetUnitLabelAsync(label.Label, label.MeasurementType, label.Mandatory, activeUnitType);
            }

            string unitPricePrefix = activeLanguageRegionCode != LanguageRegionCode.enGB
                ? _translationService.TranslateString("Unit Price", activeLanguageRegionCode)
                : "Unit Price";
            string unitPriceSuffix = $"({_companyConfigurationBankAccountCurrencyCode})*";

            createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitPriceTextBoxLabel.Text = $"{unitPricePrefix} {unitPriceSuffix}";

            if (activeLanguageRegionCode != LanguageRegionCode.enGB)
            {

            }
            else
            {

            }
        }

        private async Task LoadWholesaleDeliveryTypeAsync()
        {
            try
            {
                _wholesaleDeliveryTypeLoading = true;

                // Create the lookup helper
                var lookupHelper = new DataAccessLookupHelper(FunctionTitle.WholesaleDeliveryType);

                // Fetch data on background thread
                DataTable? dataTable = await lookupHelper.GetFilteredDataTableAsync();

                // Update UI safely on the UI thread
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        var comboBox = createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleDeliveryTypeComboBox;
                        comboBox.DataSource = dataTable;

                        if (dataTable != null)
                        {
                            comboBox.DisplayMember = lookupHelper.DisplayMemberColumnName;
                            comboBox.ValueMember = lookupHelper.ValueMemberColumnName;
                        }
                    }));
                }
                else
                {
                    var comboBox = createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleDeliveryTypeComboBox;
                    comboBox.DataSource = dataTable;

                    if (dataTable != null)
                    {
                        comboBox.DisplayMember = lookupHelper.DisplayMemberColumnName;
                        comboBox.ValueMember = lookupHelper.ValueMemberColumnName;
                    }
                }
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => MessageBox.Show($"Error loading wholesale delivery types: {ex.Message}")));
                }
                else
                {
                    MessageBox.Show($"Error loading wholesale delivery types: {ex.Message}");
                }
            }
            finally
            {
                _wholesaleDeliveryTypeLoading = false;
            }
        }

        private async void PopulateProductDetailsGeneralInformationModel(object? sender, EventArgs e)
        {
            _productModel.ProductDetailsGeneralInformation.ActiveProductStatus = createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageActiveStatusCheckBox.Checked;

            // Safe casting for ComboBox SelectedValue
            if (createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductCategoryComboBox.SelectedValue is Guid productCategoryId)
            {
                _productModel.ProductDetailsGeneralInformation.ProductCategoryId = productCategoryId;
            }

            if (createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductCountryOfOriginComboBox.SelectedValue is Guid countryOfOriginId)
            {
                _productModel.ProductDetailsGeneralInformation.ProductCountryOfOriginId = countryOfOriginId;
            }

            _productModel.ProductDetailsGeneralInformation.ProductDescription = TextBoxCleanerHelper.GetTrimmedText(createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductDescriptionTextBox);

            // Handle Product Family loading properly
            if (createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductFamilyPanelYesRadioButton.Checked)
            {
                _productModel.ProductDetailsGeneralInformation.ProductFamilyEnabled = true;
                createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductFamilyPanelProductFamilyComboBox.Enabled = true;

                // Check if the combobox is empty before loading data
                if (createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductFamilyPanelProductFamilyComboBox.DataSource == null)
                {
                    try
                    {
                        await LoadProductFamilyDataAsync(); // Properly await the async call
                    }
                    catch (Exception ex)
                    {
                        new ErrorMessageService("Error.Data.Loading", "Product Family", ex.Message);
                        // Reset to disabled state if loading fails
                        _productModel.ProductDetailsGeneralInformation.ProductFamilyEnabled = false;
                        createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductFamilyPanelProductFamilyComboBox.Enabled = false;
                        createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductFamilyPanelNoRadioButton.Checked = true;
                        createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductFamilyPanelYesRadioButton.Checked = false;
                    }
                }
            }
            else if (createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductFamilyPanelNoRadioButton.Checked)
            {
                _productModel.ProductDetailsGeneralInformation.ProductFamilyEnabled = false;
                createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductFamilyPanelProductFamilyComboBox.Enabled = false;
                createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductFamilyPanelProductFamilyComboBox.DataSource = null;
            }

            if (createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductFamilyPanelProductFamilyComboBox.SelectedValue is Guid productFamilyId)
            {
                _productModel.ProductDetailsGeneralInformation.ProductFamilyId = productFamilyId;
            }
            else
            {
                _productModel.ProductDetailsGeneralInformation.ProductFamilyId = null;
            }

            if (createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageManufacturerComboBox.SelectedValue is Guid manufacturerId)
            {
                _productModel.ProductDetailsGeneralInformation.ProductManufacturerId = manufacturerId;
            }

            _productModel.ProductDetailsGeneralInformation.ProductManufacturerPartNumber = TextBoxCleanerHelper.GetTrimmedText(createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageManufacturerPartNumberTextBox);
            _productModel.ProductDetailsGeneralInformation.ProductName = TextBoxCleanerHelper.GetTrimmedText(createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductNameTextBox);

            if (createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductSubCategoryComboBox.SelectedValue is Guid productSubCategoryId)
            {
                _productModel.ProductDetailsGeneralInformation.ProductSubCategoryId = productSubCategoryId;
            }
        }

        private void PopulateProductDetailsUnitInformationModel(object? sender, EventArgs e)
        {
            _productModel.ProductDetailsUnitInformation.UnitBarcode = TextBoxCleanerHelper.GetTrimmedText(createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitBarcodeTextBox);

            if (!string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitDepthTextBoxA.Text) &&
                !string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitDepthTextBoxB.Text))
            {
                _productModel.ProductDetailsUnitInformation.UnitDepth = (decimal?)_numericParserHelper.ParseDecimal(createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitDepthTextBoxA, createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitDepthTextBoxB);
            }
            else
            {
                _productModel.ProductDetailsUnitInformation.UnitDepth = null;
            }

            if (!string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitHeightTextBoxA.Text) &&
                !string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitHeightTextBoxB.Text))
            {
                _productModel.ProductDetailsUnitInformation.UnitHeight = (decimal?)_numericParserHelper.ParseDecimal(createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitHeightTextBoxA, createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitHeightTextBoxB);
            }
            else
            {
                _productModel.ProductDetailsUnitInformation.UnitHeight = null;
            }

            _productModel.ProductDetailsUnitInformation.UnitMinimumStockQuantity = (int?)_numericParserHelper.ParseInt(createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitMinimumStockQuantityTextBox);

            if (!string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitPriceTextBoxA.Text) &&
                !string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitPriceTextBoxB.Text))
            {
                _productModel.ProductDetailsUnitInformation.UnitPrice = (decimal)_numericParserHelper.ParseDecimal(createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitPriceTextBoxA, createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitPriceTextBoxB);
            }
            else
            {
                _productModel.ProductDetailsUnitInformation.UnitPrice = 0; // or whatever default value is appropriate
            }

            if (!string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitWeightTextBoxA.Text) &&
                !string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitWeightTextBoxB.Text))
            {
                _productModel.ProductDetailsUnitInformation.UnitWeight = (decimal?)_numericParserHelper.ParseDecimal(createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitWeightTextBoxA, createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitWeightTextBoxB);
            }
            else
            {
                _productModel.ProductDetailsUnitInformation.UnitWeight = null;
            }

            if (!string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitWidthTextBoxA.Text) &&
                !string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitWidthTextBoxB.Text))
            {
                _productModel.ProductDetailsUnitInformation.UnitWidth = (decimal?)_numericParserHelper.ParseDecimal(createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitWidthTextBoxA, createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitWidthTextBoxB);
            }
            else
            {
                _productModel.ProductDetailsUnitInformation.UnitWidth = null;
            }

            // Calculate area of a unit
            if (_productModel.ProductDetailsUnitInformation.UnitDepth.HasValue &&
                _productModel.ProductDetailsUnitInformation.UnitWidth.HasValue
                )
            {
                _productModel.ProductDetailsUnitInformation.UnitArea = CalculateDimensionsHelper.GetArea(
                    _productModel.ProductDetailsUnitInformation.UnitDepth.Value,
                    _productModel.ProductDetailsUnitInformation.UnitWidth.Value);

                createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitAreaTextBox.Text = _productModel.ProductDetailsUnitInformation.UnitArea.ToString() ?? string.Empty;
            }

            // Calculate volume of a unit
            if (_productModel.ProductDetailsUnitInformation.UnitDepth.HasValue &&
                _productModel.ProductDetailsUnitInformation.UnitHeight.HasValue &&
                _productModel.ProductDetailsUnitInformation.UnitWidth.HasValue
                )
            {
                _productModel.ProductDetailsUnitInformation.UnitVolume = CalculateDimensionsHelper.GetVolume(
                    _productModel.ProductDetailsUnitInformation.UnitDepth.Value,
                    _productModel.ProductDetailsUnitInformation.UnitHeight.Value,
                    _productModel.ProductDetailsUnitInformation.UnitWidth.Value);

                createProductTabControlProductDetailTabPageTabControlUnitInformationTabPageUnitVolumeTextBox.Text = _productModel.ProductDetailsUnitInformation.UnitVolume.ToString() ?? string.Empty;
            }
        }

        private void PopulateProductDetailsWholesaleInformationModel(object? sender, EventArgs e)
        {
            // Exit early if loading data
            if (_wholesaleDeliveryTypeLoading)
                return;

            // General Information - Safe casting
            if (createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleDeliveryTypeComboBox.SelectedValue is Guid deliveryTypeId)
            {
                _productModel.ProductDetailsWholesaleInformation.GeneralInformationWholesaleDeliveryTypeId = deliveryTypeId;
            }
            else
            {
                _productModel.ProductDetailsWholesaleInformation.GeneralInformationWholesaleDeliveryTypeId = null;
            }

            if (createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleEnabledPanelYesRadioButton.Checked)
            {
                _productModel.ProductDetailsWholesaleInformation.GeneralInformationWholesaleEnabled = true;
            }
            else if (createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleEnabledPanelNoRadioButton.Checked)
            {
                _productModel.ProductDetailsWholesaleInformation.GeneralInformationWholesaleEnabled = false;
            }

            if (createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleReorderFlagPanelYesRadioButton.Checked)
            {
                _productModel.ProductDetailsWholesaleInformation.GeneralInformationWholesaleReorder = true;
            }
            else if (createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleReorderFlagPanelNoRadioButton.Checked)
            {
                _productModel.ProductDetailsWholesaleInformation.GeneralInformationWholesaleReorder = false;
            }

            // Get delivery type safely
            string deliveryType = _productSharedComponents.GetSelectedWholesaleDeliveryType(comboBox: createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleDeliveryTypeComboBox);

            if (deliveryType == "Carton" || deliveryType == "Pallet - Carton")
            {
                _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonBarcode = TextBoxCleanerHelper.GetTrimmedText(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonBarcodeTextBox);

                if (!string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonDepthTextBoxA.Text) &&
                    !string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonDepthTextBoxB.Text))
                {
                    _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonDepth = (decimal?)_numericParserHelper.ParseDecimal(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonDepthTextBoxA, createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonDepthTextBoxB);
                }
                else
                {
                    _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonDepth = null;
                }

                if (!string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonHeightTextBoxA.Text) &&
                    !string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonHeightTextBoxB.Text))
                {
                    _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonHeight = (decimal?)_numericParserHelper.ParseDecimal(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonHeightTextBoxA, createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonHeightTextBoxB);
                }
                else
                {
                    _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonHeight = null;
                }

                if (!string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonPackagingWeightTextBoxA.Text) &&
                    !string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonPackagingWeightTextBoxB.Text))
                {
                    _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonPackagingWeight = (decimal?)_numericParserHelper.ParseDecimal(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonPackagingWeightTextBoxA, createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonPackagingWeightTextBoxB);
                }
                else
                {
                    _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonPackagingWeight = null;
                }

                if (!string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonWidthTextBoxA.Text) &&
                    !string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonWidthTextBoxB.Text))
                {
                    _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonWidth = (decimal?)_numericParserHelper.ParseDecimal(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonWidthTextBoxA, createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonWidthTextBoxB);
                }
                else
                {
                    _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonWidth = null;
                }

                _productModel.ProductDetailsWholesaleInformation.CartonInformationUnitQuantityPerCarton = (int?)_numericParserHelper.ParseInt(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxUnitQuantityPerCartonTextBox);

                // Calculate carton area
                if (_productModel.ProductDetailsWholesaleInformation.CartonInformationCartonDepth.HasValue &&
                    _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonWidth.HasValue
                    )
                {
                    _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonArea = CalculateDimensionsHelper.GetArea(
                        _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonDepth.Value,
                        _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonWidth.Value);
                    createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonAreaTextBox.Text = _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonArea.ToString() ?? string.Empty;
                }

                // Calculate carton volume
                if (_productModel.ProductDetailsWholesaleInformation.CartonInformationCartonDepth.HasValue &&
                    _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonHeight.HasValue &&
                    _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonWidth.HasValue
                    )
                {
                    _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonVolume = CalculateDimensionsHelper.GetVolume(
                        _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonDepth.Value,
                        _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonHeight.Value,
                        _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonWidth.Value);
                    createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonVolumeTextBox.Text = _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonVolume.ToString() ?? string.Empty;
                }

                // Calculate carton total weight
                if (_productModel.ProductDetailsUnitInformation.UnitWeight.HasValue &&
                    _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonPackagingWeight.HasValue &&
                    _productModel.ProductDetailsWholesaleInformation.CartonInformationUnitQuantityPerCarton.HasValue
                    )
                {
                    _productModel.ProductDetailsWholesaleInformation.CartonInformationTotalCartonWeight = (_productModel.ProductDetailsUnitInformation.UnitWeight.Value * _productModel.ProductDetailsWholesaleInformation.CartonInformationUnitQuantityPerCarton.Value) + _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonPackagingWeight.Value;
                    createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBoxCartonTotalWeightTextBox.Text = _productModel.ProductDetailsWholesaleInformation.CartonInformationTotalCartonWeight?.ToString();
                }
            }

            if (deliveryType == "Pallet - Carton" || deliveryType == "Pallet - Unit")
            {
                _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletBarcode = TextBoxCleanerHelper.GetTrimmedText(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletBarcodeTextBox);

                if (!string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletDepthTextBoxA.Text) &&
                    !string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletDepthTextBoxB.Text))
                {
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletDepth = (decimal?)_numericParserHelper.ParseDecimal(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletDepthTextBoxA, createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletDepthTextBoxB);
                }
                else
                {
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletDepth = null;
                }

                if (!string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletHeightTextBoxA.Text) &&
                    !string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletHeightTextBoxB.Text))
                {
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletHeight = (decimal?)_numericParserHelper.ParseDecimal(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletHeightTextBoxA, createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletHeightTextBoxB);
                }
                else
                {
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletHeight = null;
                }
                if (!string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletWeightTextBoxA.Text) &&
                    !string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletWeightTextBoxB.Text))
                {
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWeight = (decimal?)_numericParserHelper.ParseDecimal(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletWeightTextBoxA, createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletWeightTextBoxB);
                }
                else
                {
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWeight = null;
                }

                if (!string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletWidthTextBoxA.Text) &&
                    !string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletWidthTextBoxB.Text))
                {
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWidth = (decimal?)_numericParserHelper.ParseDecimal(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletWidthTextBoxA, createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletWidthTextBoxB);
                }
                else
                {
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWidth = null;
                }

                // Calculate pallet area
                if (_productModel.ProductDetailsWholesaleInformation.PalletInformationPalletDepth.HasValue &&
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWidth.HasValue
                    )
                {
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletArea = CalculateDimensionsHelper.GetArea(
                        _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletDepth.Value,
                        _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWidth.Value);

                    createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletAreaTextBox.Text = _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletArea.ToString() ?? string.Empty;
                }

                // Calculate pallet volume
                if (_productModel.ProductDetailsWholesaleInformation.PalletInformationPalletDepth.HasValue &&
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletHeight.HasValue &&
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWidth.HasValue
                    )
                {
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletVolume = CalculateDimensionsHelper.GetVolume(
                        _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletDepth.Value,
                        _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletHeight.Value,
                        _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWidth.Value);

                    createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxPalletVolumeTextBox.Text = _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletVolume.ToString() ?? string.Empty;
                }
            }

            if (deliveryType == "Pallet - Carton")
            {
                _productModel.ProductDetailsWholesaleInformation.PalletInformationCartonStackingHeightPallet = (byte?)_numericParserHelper.ParseByte(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxCartonStackingHeightPalletTextBox);

                // Calculate how many cartons can fit per level on a pallet
                if (_productModel.ProductDetailsWholesaleInformation.CartonInformationCartonArea.HasValue &&
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletArea.HasValue
                    )
                {
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationCartonQuantityPerPalletLevel = (byte?)Math.Floor(_productModel.ProductDetailsWholesaleInformation.PalletInformationPalletArea.Value / _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonArea.Value);
                    createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxCartonQuantityPerPalletLevelTextBox.Text = _productModel.ProductDetailsWholesaleInformation.PalletInformationCartonQuantityPerPalletLevel?.ToString() ?? string.Empty;
                }

                // Calculate how many cartons in total can fit on a pallet
                if (_productModel.ProductDetailsWholesaleInformation.PalletInformationCartonQuantityPerPalletLevel.HasValue &&
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationCartonStackingHeightPallet.HasValue
                    )
                {
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationCartonQuantityPerPallet = (int?)_productModel.ProductDetailsWholesaleInformation.PalletInformationCartonQuantityPerPalletLevel.Value * _productModel.ProductDetailsWholesaleInformation.PalletInformationCartonStackingHeightPallet.Value;
                    createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxTotalCartonQuantityPerPalletTextBox.Text = _productModel.ProductDetailsWholesaleInformation.PalletInformationCartonQuantityPerPallet?.ToString() ?? string.Empty;
                }

                // Calculate total pallet height
                if (_productModel.ProductDetailsWholesaleInformation.PalletInformationCartonStackingHeightPallet.HasValue &&
                    _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonHeight.HasValue &&
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletHeight.HasValue
                    )
                {
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletHeight = (decimal?)(_productModel.ProductDetailsWholesaleInformation.CartonInformationCartonHeight.Value * _productModel.ProductDetailsWholesaleInformation.PalletInformationCartonStackingHeightPallet.Value) + _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletHeight.Value;
                    createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxTotalPalletHeightTextBox.Text = _productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletHeight?.ToString() ?? string.Empty;
                }

                // Calculate total pallet volume
                if (_productModel.ProductDetailsWholesaleInformation.PalletInformationPalletArea.HasValue &&
                    _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonHeight.HasValue &&
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationCartonStackingHeightPallet.HasValue &&
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletHeight.HasValue
                    )
                {
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletVolume = (decimal?)_productModel.ProductDetailsWholesaleInformation.PalletInformationPalletArea.Value * ((_productModel.ProductDetailsWholesaleInformation.CartonInformationCartonHeight.Value * _productModel.ProductDetailsWholesaleInformation.PalletInformationCartonStackingHeightPallet.Value) + _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletHeight.Value);
                    createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxTotalPalletVolumeTextBox.Text = _productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletVolume?.ToString() ?? string.Empty;
                }

                // Calculate total pallet weight
                if (_productModel.ProductDetailsWholesaleInformation.CartonInformationTotalCartonWeight.HasValue &&
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationCartonQuantityPerPallet.HasValue &&
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWeight.HasValue
                    )
                {
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletWeight = (decimal?)(_productModel.ProductDetailsWholesaleInformation.CartonInformationTotalCartonWeight.Value * _productModel.ProductDetailsWholesaleInformation.PalletInformationCartonQuantityPerPallet.Value) + _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWeight.Value;
                    createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxTotalPalletWeightTextBox.Text = _productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletWeight?.ToString() ?? string.Empty;
                }
            }

            if (deliveryType == "Pallet - Unit")
            {
                _productModel.ProductDetailsWholesaleInformation.PalletInformationUnitStackingHeightPallet = (byte?)_numericParserHelper.ParseByte(createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxUnitStackingHeightPalletTextBox);

                // Calculate how many units can fit per level on a pallet
                if (_productModel.ProductDetailsUnitInformation.UnitArea.HasValue &&
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletArea.HasValue
                    )
                {
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationUnitQuantityPerPalletLevel = (int?)Math.Floor(_productModel.ProductDetailsWholesaleInformation.PalletInformationPalletArea.Value / _productModel.ProductDetailsUnitInformation.UnitArea.Value);
                    createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxUnitQuantityPerPalletLevelTextBox.Text = _productModel.ProductDetailsWholesaleInformation.PalletInformationUnitQuantityPerPalletLevel?.ToString() ?? string.Empty;
                }

                // Calculate how many units in total can fit on a pallet
                if (_productModel.ProductDetailsWholesaleInformation.PalletInformationUnitQuantityPerPalletLevel.HasValue &&
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationUnitStackingHeightPallet.HasValue
                    )
                {
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationUnitQuantityPerPallet = (int?)_productModel.ProductDetailsWholesaleInformation.PalletInformationUnitQuantityPerPalletLevel.Value * _productModel.ProductDetailsWholesaleInformation.PalletInformationUnitStackingHeightPallet.Value;
                    createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxTotalUnitQuantityPerPalletTextBox.Text = _productModel.ProductDetailsWholesaleInformation.PalletInformationUnitQuantityPerPallet?.ToString() ?? string.Empty;
                }

                // Calculate total pallet height
                if (_productModel.ProductDetailsUnitInformation.UnitHeight.HasValue &&
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationUnitStackingHeightPallet.HasValue &&

                    _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletHeight.HasValue
                    )
                {
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletHeight = (decimal?)(_productModel.ProductDetailsUnitInformation.UnitHeight.Value * _productModel.ProductDetailsWholesaleInformation.PalletInformationUnitStackingHeightPallet.Value) + _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletHeight.Value;
                    createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxTotalPalletHeightTextBox.Text = _productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletHeight?.ToString() ?? string.Empty;
                }

                // Calculate total pallet volume
                if (_productModel.ProductDetailsWholesaleInformation.PalletInformationPalletArea.HasValue &&
                    _productModel.ProductDetailsUnitInformation.UnitHeight.HasValue &&
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationUnitStackingHeightPallet.HasValue &&
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletHeight.HasValue
                )
                {
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletVolume = (decimal?)_productModel.ProductDetailsWholesaleInformation.PalletInformationPalletArea.Value * ((_productModel.ProductDetailsUnitInformation.UnitHeight.Value * _productModel.ProductDetailsWholesaleInformation.PalletInformationUnitStackingHeightPallet.Value) + _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletHeight.Value);
                    createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxTotalPalletVolumeTextBox.Text = _productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletVolume?.ToString() ?? string.Empty;
                }

                // Calculate total pallet weight
                if (_productModel.ProductDetailsUnitInformation.UnitWeight.HasValue &&
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationUnitQuantityPerPallet.HasValue &&
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWeight.HasValue
                    )
                {
                    _productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletWeight = (decimal?)(_productModel.ProductDetailsUnitInformation.UnitWeight.Value * _productModel.ProductDetailsWholesaleInformation.PalletInformationUnitQuantityPerPallet.Value) + _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWeight.Value;
                    createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxTotalPalletWeightTextBox.Text = _productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletWeight?.ToString() ?? string.Empty;
                }
            }
        }

        private async void RenderWholesaleInformationTabPageControls(object? sender, EventArgs e)
        {
            try
            {
                // Exit early if loading data
                if (_wholesaleDeliveryTypeLoading)
                    return;

                // Reset controls to default state
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBox.Enabled = false;
                createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBox.Enabled = false;

                if (createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleEnabledPanelNoRadioButton.Checked)
                {
                    createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleDeliveryTypeComboBox.Enabled = false;
                    createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleDeliveryTypeComboBox.DataSource = null;

                    // Also update supplier price textboxes when wholesale is disabled
                    _productSharedComponents.UpdateSupplierPriceTextBoxStates(
                        chosenSupplierListView: createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView,
                        wholesaleDeliveryTypeComboBox: createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleDeliveryTypeComboBox,
                        wholesalePricePerCartonTextBoxA: createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxA,
                        wholesalePricePerCartonTextBoxB: createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxB,
                        wholesalePricePerPalletTextBoxA: createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxA,
                        wholesalePricePerPalletTextBoxB: createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxB
                        );
                    return;
                }

                if (createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleEnabledPanelYesRadioButton.Checked)
                {
                    createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleDeliveryTypeComboBox.Enabled = true;

                    // Only load data if the combo box is empty
                    if (createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleDeliveryTypeComboBox.DataSource == null)
                    {
                        await LoadWholesaleDeliveryTypeAsync();
                    }
                }

                // Get delivery type safely
                string deliveryType = _productSharedComponents.GetSelectedWholesaleDeliveryType(comboBox: createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleDeliveryTypeComboBox);
                if (string.IsNullOrEmpty(deliveryType))
                {
                    // Update supplier price textboxes even when delivery type is not selected
                    _productSharedComponents.UpdateSupplierPriceTextBoxStates(
                        chosenSupplierListView: createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView,
                        wholesaleDeliveryTypeComboBox: createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleDeliveryTypeComboBox,
                        wholesalePricePerCartonTextBoxA: createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxA,
                        wholesalePricePerCartonTextBoxB: createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxB,
                        wholesalePricePerPalletTextBoxA: createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxA,
                        wholesalePricePerPalletTextBoxB: createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxB
                        );
                    return;
                }

                // Handle the different delivery types
                if (deliveryType == "Carton")
                {
                    createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBox.Enabled = true;
                }

                if (deliveryType.StartsWith("Pallet"))
                {
                    createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBox.Enabled = true;

                    if (deliveryType == "Pallet - Carton")
                    {
                        createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageCartonGroupBox.Enabled = true;
                        createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxCartonStackingHeightPalletTextBox.Enabled = true;
                        createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxUnitStackingHeightPalletTextBox.Enabled = false;
                    }
                    else if (deliveryType == "Pallet - Unit")
                    {
                        createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxCartonStackingHeightPalletTextBox.Enabled = false;
                        createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPagePalletGroupBoxUnitStackingHeightPalletTextBox.Enabled = true;
                    }
                }

                // Update supplier price textboxes based on the new delivery type
                _productSharedComponents.UpdateSupplierPriceTextBoxStates(
                    chosenSupplierListView: createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView,
                    wholesaleDeliveryTypeComboBox: createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleDeliveryTypeComboBox,
                    wholesalePricePerCartonTextBoxA: createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxA,
                    wholesalePricePerCartonTextBoxB: createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxB,
                    wholesalePricePerPalletTextBoxA: createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxA,
                    wholesalePricePerPalletTextBoxB: createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxB
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in rendering wholesale controls: {ex.Message}");
            }
        }

        private void SalesSubRegionExpiryDatePanelRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (createProductTabControlProductSalesSubRegionAvailabilityTabPageExpiryDateChoicePanelYesRadioButton.Checked)
            {
                createProductTabControlProductSalesSubRegionAvailabilityTabPageExpiryDatePicker.Enabled = true;
            }
            else
            {
                createProductTabControlProductSalesSubRegionAvailabilityTabPageExpiryDatePicker.Enabled = false;
                createProductTabControlProductSalesSubRegionAvailabilityTabPageExpiryDatePicker.Value = DateTime.Now;
            }

            if (createProductTabControlProductSalesSubRegionAvailabilityTabPageChosenSalesSubRegionListView.SelectedItems.Count > 0)
            {
                var item = createProductTabControlProductSalesSubRegionAvailabilityTabPageChosenSalesSubRegionListView.SelectedItems[0];
                var salesSubRegion = (ProductSalesSubRegionChosenList)item.Tag;
                if (createProductTabControlProductSalesSubRegionAvailabilityTabPageExpiryDateChoicePanelYesRadioButton.Checked)
                {
                    salesSubRegion.ExpiryDateEnabled = true;
                }
                else
                {
                    salesSubRegion.ExpiryDateEnabled = false;
                }
            }
        }

        private async void changeActiveCompanyConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(createProductStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.ShowChangeDialogAndReloadAsync(this);
            _companyConfigurationId = _companyConfigHelper.CompanyConfigurationId;
        }

        private async void createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductCategoryComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductCategoryComboBox.SelectedValue is Guid selectedProductCategoryId)
            {
                await LoadProductSubCategoryAsync(selectedProductCategoryId);
            }
            else
            {
                // Clear the subcategory combobox if no valid category is selected
                createProductTabControlProductDetailTabPageTabControlGeneralInformationTabPageProductSubCategoryComboBox.DataSource = null;
            }
        }

        private void createProductTabControlProductImageTabPageChooseProductImageButton_Click(object sender, EventArgs e)
        {
            _productSharedComponents.AddProductImage(
                imageList: createProductTabControlProductImageTabPageImageList,
                listView: createProductTabControlProductImageTabPageImageListView,
                maxPixelHeight: _productModel.ProductImageDimension.maxHeight,
                maxPixelWidth: _productModel.ProductImageDimension.maxWidth,
                pictureBox: createProductTabControlProductImageTabPageProductImagePictureBox,
                productModel: _productModel
                );
        }

        private void createProductTabControlProductImageTabPageImageListView_SelectedIndexChanged(object? sender, EventArgs e)
        {
            bool hasSelection = createProductTabControlProductImageTabPageImageListView.SelectedItems.Count > 0;

            // Show/hide controls
            createProductTabControlProductImageTabPageProductImagePictureBox.Visible = hasSelection;
            createProductTabControlProductImageTabPageProductImageAltTextTextBox.Visible = hasSelection;
            createProductTabControlProductImageTabPageProductImageAltTextTextBoxLabel.Visible = hasSelection;
            createProductTabControlProductImageTabPageProductImageCaptionTextBox.Visible = hasSelection;
            createProductTabControlProductImageTabPageProductImageCaptionTextBoxLabel.Visible = hasSelection;
            createProductTabControlProductImageTabPageImageListViewDownButton.Visible = hasSelection;
            createProductTabControlProductImageTabPageImageListViewUpButton.Visible = hasSelection;
            createProductTabControlProductImageTabPageRemoveProductImageButton.Enabled = hasSelection;
            createProductTabControlProductImageTabPageProductImageIsThumbnailCheckBox.Visible = hasSelection;

            if (createProductTabControlProductImageTabPageImageListView.SelectedIndices.Count > 0)
            {
                int index = createProductTabControlProductImageTabPageImageListView.SelectedIndices[0];
                var img = _productModel.ProductImageList[index];
                createProductTabControlProductImageTabPageProductImagePictureBox.Image = Image.FromStream(new MemoryStream(img.ImageBytes));
                createProductTabControlProductImageTabPageProductImageAltTextTextBox.Text = img.AltText;
                createProductTabControlProductImageTabPageProductImageCaptionTextBox.Text = img.Caption;
                createProductTabControlProductImageTabPageProductImageIsThumbnailCheckBox.Checked = img.IsThumbnail;
            }
            else
            {
                createProductTabControlProductImageTabPageProductImagePictureBox.Image = null;
                createProductTabControlProductImageTabPageProductImageAltTextTextBox.Text = string.Empty;
                createProductTabControlProductImageTabPageProductImageCaptionTextBox.Text = string.Empty;
                createProductTabControlProductImageTabPageProductImageIsThumbnailCheckBox.Checked = false;
            }
        }

        private void createProductTabControlProductImageTabPageMoveImageUpButton_Click(object? sender, EventArgs e)
        {
            var selectedIndices = createProductTabControlProductImageTabPageImageListView.SelectedIndices;
            if (selectedIndices.Count > 0)
            {
                int index = selectedIndices[0];
                if (index > 0)
                {
                    _productSharedComponents.MoveProductImage(
                        imageList: createProductTabControlProductImageTabPageImageList,
                        imageListView: createProductTabControlProductImageTabPageImageListView,
                        index: index,
                        newIndex: index - 1,
                        productModel: _productModel
                        );
                    createProductTabControlProductImageTabPageImageListView.Items[index - 1].Selected = true;
                }
            }
        }

        private void createProductTabControlProductImageTabPageMoveImageDownButton_Click(object? sender, EventArgs e)
        {
            var selectedIndices = createProductTabControlProductImageTabPageImageListView.SelectedIndices;
            if (selectedIndices.Count > 0)
            {
                int index = selectedIndices[0];
                if (index < _productModel.ProductImageList.Count - 1)
                {
                    _productSharedComponents.MoveProductImage(
                        imageList: createProductTabControlProductImageTabPageImageList,
                        imageListView: createProductTabControlProductImageTabPageImageListView,
                        index: index,
                        newIndex: index + 1,
                        productModel: _productModel
                        );
                    createProductTabControlProductImageTabPageImageListView.Items[index + 1].Selected = true;
                }
            }
        }

        private void createProductTabControlProductImageTabPageProductImageAltTextTextBox_TextChanged(object? sender, EventArgs e)
        {
            if (createProductTabControlProductImageTabPageImageListView.SelectedIndices.Count > 0)
            {
                int index = createProductTabControlProductImageTabPageImageListView.SelectedIndices[0];
                _productModel.ProductImageList[index].AltText = createProductTabControlProductImageTabPageProductImageAltTextTextBox.Text;
            }
        }

        private void createProductTabControlProductImageTabPageProductImageCaptionTextBox_TextChanged(object? sender, EventArgs e)
        {
            if (createProductTabControlProductImageTabPageImageListView.SelectedIndices.Count > 0)
            {
                int index = createProductTabControlProductImageTabPageImageListView.SelectedIndices[0];
                _productModel.ProductImageList[index].Caption = createProductTabControlProductImageTabPageProductImageCaptionTextBox.Text;
            }
        }

        private void createProductTabControlProductImageTabPageProductImageIsThumbnailCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (createProductTabControlProductImageTabPageImageListView.SelectedIndices.Count > 0)
            {
                int selectedIndex = createProductTabControlProductImageTabPageImageListView.SelectedIndices[0];
                bool isChecked = createProductTabControlProductImageTabPageProductImageIsThumbnailCheckBox.Checked;

                // If checked, set all others to false
                if (isChecked)
                {
                    for (int i = 0; i < _productModel.ProductImageList.Count; i++)
                    {
                        _productModel.ProductImageList[i].IsThumbnail = (i == selectedIndex);
                    }
                }
                else
                {
                    _productModel.ProductImageList[selectedIndex].IsThumbnail = false;
                }

                // Optionally, update the checkbox state to reflect the change
                createProductTabControlProductImageTabPageProductImageIsThumbnailCheckBox.Checked = _productModel.ProductImageList[selectedIndex].IsThumbnail;
            }
        }

        private void createProductTabControlProductImageTabPageRemoveProductImageButton_Click(object? sender, EventArgs e)
        {
            if (createProductTabControlProductImageTabPageImageListView.SelectedIndices.Count > 0)
            {
                _productSharedComponents.RemoveProductImage(
                    imageList: createProductTabControlProductImageTabPageImageList,
                    index: createProductTabControlProductImageTabPageImageListView.SelectedIndices[0],
                    listView: createProductTabControlProductImageTabPageImageListView,
                    productModel: _productModel
                    );
            }
            if (createProductTabControlProductImageTabPageImageListView.SelectedIndices.Count == 0)
            {
                createProductTabControlProductImageTabPageProductImagePictureBox.Image = null;
            }
        }

        private void createProductTabControlProductSalesSubRegionAvailabilityTabPageActiveProductSalesSubRegionAvailabilityCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (createProductTabControlProductSalesSubRegionAvailabilityTabPageChosenSalesSubRegionListView.SelectedItems.Count > 0)
            {
                var item = createProductTabControlProductSalesSubRegionAvailabilityTabPageChosenSalesSubRegionListView.SelectedItems[0];
                var salesSubRegion = (ProductSalesSubRegionChosenList)item.Tag;
                salesSubRegion.ActiveStatus = createProductTabControlProductSalesSubRegionAvailabilityTabPageActiveProductSalesSubRegionAvailabilityCheckBox.Checked;
            }
        }

        private void createProductTabControlProductSalesSubRegionAvailabilityTabPageChosenSalesSubRegionListView_SelectedIndexChanged(object? sender, EventArgs e)
        {
            bool hasSelection = createProductTabControlProductSalesSubRegionAvailabilityTabPageChosenSalesSubRegionListView.SelectedItems.Count > 0;

            // Show/hide controls
            createProductTabControlProductSalesSubRegionAvailabilityTabPageEffectiveDatePicker.Visible = hasSelection;
            createProductTabControlProductSalesSubRegionAvailabilityTabPageEffectiveDatePickerLabel.Visible = hasSelection;
            createProductTabControlProductSalesSubRegionAvailabilityTabPageExpiryDateChoicePanel.Visible = hasSelection;
            createProductTabControlProductSalesSubRegionAvailabilityTabPageExpiryDateChoicePanelLabel.Visible = hasSelection;
            createProductTabControlProductSalesSubRegionAvailabilityTabPageExpiryDatePicker.Visible = hasSelection;
            createProductTabControlProductSalesSubRegionAvailabilityTabPageExpiryDatePickerLabel.Visible = hasSelection;
            createProductTabControlProductSalesSubRegionAvailabilityTabPageActiveProductSalesSubRegionAvailabilityCheckBox.Visible = hasSelection;

            if (hasSelection)
            {
                var item = createProductTabControlProductSalesSubRegionAvailabilityTabPageChosenSalesSubRegionListView.SelectedItems[0];
                var salesSubRegion = (ProductSalesSubRegionChosenList)item.Tag;

                // Temporarily suppress validation while we set the date values
                _suppressDateValidation = true;
                try
                {
                    createProductTabControlProductSalesSubRegionAvailabilityTabPageEffectiveDatePicker.Value = salesSubRegion.EffectiveDate;
                    createProductTabControlProductSalesSubRegionAvailabilityTabPageActiveProductSalesSubRegionAvailabilityCheckBox.Checked = salesSubRegion.ActiveStatus;
                    createProductTabControlProductSalesSubRegionAvailabilityTabPageExpiryDatePicker.Value = salesSubRegion.ExpiryDate ?? DateTime.Now;
                    createProductTabControlProductSalesSubRegionAvailabilityTabPageExpiryDatePicker.Enabled = salesSubRegion.ExpiryDate.HasValue;
                }
                finally
                {
                    // Always restore validation when done
                    _suppressDateValidation = false;
                }

                if (salesSubRegion.ExpiryDateEnabled)
                {
                    createProductTabControlProductSalesSubRegionAvailabilityTabPageExpiryDateChoicePanelYesRadioButton.Checked = true;
                }
                else
                {
                    createProductTabControlProductSalesSubRegionAvailabilityTabPageExpiryDateChoicePanelNoRadioButton.Checked = true;
                }
            }
        }

        private void createProductTabControlProductSalesSubRegionAvailabilityTabPageEffectiveDatePicker_ValueChanged(object? sender, EventArgs e)
        {
            if (_suppressDateValidation) return;

            if (createProductTabControlProductSalesSubRegionAvailabilityTabPageExpiryDatePicker.Enabled)
            {
                DateComparisonHelper.ValidateEffectiveAndExpiryDates(
                    createProductTabControlProductSalesSubRegionAvailabilityTabPageEffectiveDatePicker,
                    createProductTabControlProductSalesSubRegionAvailabilityTabPageExpiryDatePicker
                );
            }

            if (createProductTabControlProductSalesSubRegionAvailabilityTabPageChosenSalesSubRegionListView.SelectedItems.Count > 0)
            {
                var item = createProductTabControlProductSalesSubRegionAvailabilityTabPageChosenSalesSubRegionListView.SelectedItems[0];
                var salesSubRegion = (ProductSalesSubRegionChosenList)item.Tag;
                salesSubRegion.EffectiveDate = createProductTabControlProductSalesSubRegionAvailabilityTabPageEffectiveDatePicker.Value;
            }
        }

        private void createProductTabControlProductSalesSubRegionAvailabilityTabPageExpiryDatePicker_ValueChanged(object? sender, EventArgs e)
        {
            if (_suppressDateValidation) return;

            if (createProductTabControlProductSalesSubRegionAvailabilityTabPageExpiryDatePicker.Enabled)
            {
                DateComparisonHelper.ValidateEffectiveAndExpiryDates(
                    createProductTabControlProductSalesSubRegionAvailabilityTabPageEffectiveDatePicker,
                    createProductTabControlProductSalesSubRegionAvailabilityTabPageExpiryDatePicker
                );
            }

            if (createProductTabControlProductSalesSubRegionAvailabilityTabPageChosenSalesSubRegionListView.SelectedItems.Count > 0)
            {
                var item = createProductTabControlProductSalesSubRegionAvailabilityTabPageChosenSalesSubRegionListView.SelectedItems[0];
                var salesSubRegion = (ProductSalesSubRegionChosenList)item.Tag;
                salesSubRegion.ExpiryDate = createProductTabControlProductSalesSubRegionAvailabilityTabPageExpiryDatePicker.Value;
            }
        }

        private async void createProductTabControlProductSalesSubRegionAvailabilityTabPageSalesRegionComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (createProductTabControlProductSalesSubRegionAvailabilityTabPageSalesRegionComboBox.SelectedValue is Guid selectedSalesRegionId)
            {
                await _productSharedComponents.LoadSalesSubRegionsAsync(
                    listView: createProductTabControlProductSalesSubRegionAvailabilityTabPageAvailableSalesSubRegionListView,
                    productModel: _productModel,
                    salesRegionId: selectedSalesRegionId
                    );
            }
        }

        private void createProductTabControlProductSupplierRelationshipTabPageActiveProductSupplierRelationshipCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView.SelectedItems.Count > 0)
            {
                var item = createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView.SelectedItems[0];
                var supplier = (ProductSupplierRelationshipChosenList)item.Tag;
                supplier.ActiveStatus = createProductTabControlProductSupplierRelationshipTabPageActiveProductSupplierRelationshipCheckBox.Checked;
            }
        }

        private void createProductTabControlProductSupplierRelationshipTabPageDeliveryLeadTimeDaysTextBox_TextChanged(object? sender, EventArgs e)
        {
            if (createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView.SelectedItems.Count > 0)
            {
                var item = createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView.SelectedItems[0];
                var supplier = (ProductSupplierRelationshipChosenList)item.Tag;
                if (byte.TryParse(TextBoxCleanerHelper.GetTrimmedText(createProductTabControlProductSupplierRelationshipTabPageDeliveryLeadTimeDaysTextBox), out byte leadTimeDays))
                {
                    supplier.DeliveryLeadTimeDays = leadTimeDays;
                }
                else
                {
                    supplier.DeliveryLeadTimeDays = 0;
                }
            }
        }

        private async void createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView_SelectedIndexChanged(object? sender, EventArgs e)
        {
            bool hasSelection = createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView.SelectedItems.Count > 0;

            // Show/hide controls
            createProductTabControlProductSupplierRelationshipTabPageActiveProductSupplierRelationshipCheckBox.Visible = hasSelection;
            createProductTabControlProductSupplierRelationshipTabPageDeliveryLeadTimeDaysTextBox.Visible = hasSelection;
            createProductTabControlProductSupplierRelationshipTabPageDeliveryLeadTimeDaysTextBoxLabel.Visible = hasSelection;
            createProductTabControlProductSupplierRelationshipTabPageSupplierProductCodeTextBox.Visible = hasSelection;
            createProductTabControlProductSupplierRelationshipTabPageSupplierProductCodeTextBoxLabel.Visible = hasSelection;
            createProductTabControlProductSupplierRelationshipTabPageSupplierPaymentCurrencyLabel.Visible = hasSelection;
            createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxA.Visible = hasSelection;
            createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxB.Visible = hasSelection;
            createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxLabel.Visible = hasSelection;
            createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxSeparatorLabel.Visible = hasSelection;
            createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxA.Visible = hasSelection;
            createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxB.Visible = hasSelection;
            createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxLabel.Visible = hasSelection;
            createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxSeparatorLabel.Visible = hasSelection;
            createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerUnitTextBoxA.Visible = hasSelection;
            createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerUnitTextBoxB.Visible = hasSelection;
            createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerUnitTextBoxLabel.Visible = hasSelection;
            createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerUnitTextBoxSeparatorLabel.Visible = hasSelection;

            Label[] separatorLabelList =
            {
                createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxSeparatorLabel,
                createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxSeparatorLabel,
                createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerUnitTextBoxSeparatorLabel
            };

            if (hasSelection)
            {
                foreach (var label in separatorLabelList)
                {
                    await DelimeterLabelHelper.SetLabelToDelimeterAsync(label);
                }
            }

            // Update the enable/disable state of price textboxes based on delivery type
            _productSharedComponents.UpdateSupplierPriceTextBoxStates(
                chosenSupplierListView: createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView,
                wholesaleDeliveryTypeComboBox: createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleDeliveryTypeComboBox,
                wholesalePricePerCartonTextBoxA: createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxA,
                wholesalePricePerCartonTextBoxB: createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxB,
                wholesalePricePerPalletTextBoxA: createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxA,
                wholesalePricePerPalletTextBoxB: createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxB
                );

            // Update currency label and populate data if selected
            if (hasSelection)
            {
                var item = createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView.SelectedItems[0];
                var supplier = (ProductSupplierRelationshipChosenList)item.Tag;

                string wholesalePricePerCartonPartA;
                string wholesalePricePerCartonPartB;
                string wholesalePricePerPalletPartA;
                string wholesalePricePerPalletPartB;
                string wholesalePricePerUnitPartA;
                string wholesalePricePerUnitPartB;

                if (supplier.WholesalePricePerCarton.HasValue)
                {
                    SplitDecimalHelper.SplitDecimalUsingDelimiter((decimal)supplier.WholesalePricePerCarton, out wholesalePricePerCartonPartA, out wholesalePricePerCartonPartB);
                }
                else
                {
                    wholesalePricePerCartonPartA = string.Empty;
                    wholesalePricePerCartonPartB = string.Empty;
                }

                if (supplier.WholesalePricePerPallet.HasValue)
                {
                    SplitDecimalHelper.SplitDecimalUsingDelimiter((decimal)supplier.WholesalePricePerPallet, out wholesalePricePerPalletPartA, out wholesalePricePerPalletPartB);
                }
                else
                {
                    wholesalePricePerPalletPartA = string.Empty;
                    wholesalePricePerPalletPartB = string.Empty;
                }

                if (supplier.WholesalePricePerUnit.HasValue)
                {
                    SplitDecimalHelper.SplitDecimalUsingDelimiter((decimal)supplier.WholesalePricePerUnit, out wholesalePricePerUnitPartA, out wholesalePricePerUnitPartB);
                }
                else
                {
                    wholesalePricePerUnitPartA = string.Empty;
                    wholesalePricePerUnitPartB = string.Empty;
                }

                createProductTabControlProductSupplierRelationshipTabPageActiveProductSupplierRelationshipCheckBox.Checked = supplier.ActiveStatus;
                createProductTabControlProductSupplierRelationshipTabPageDeliveryLeadTimeDaysTextBox.Text = supplier.DeliveryLeadTimeDays.ToString();
                createProductTabControlProductSupplierRelationshipTabPageSupplierProductCodeTextBox.Text = supplier.SupplierProductCode;
                createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxA.Text = wholesalePricePerCartonPartA;
                createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxB.Text = wholesalePricePerCartonPartB;
                createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxA.Text = wholesalePricePerPalletPartA;
                createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxB.Text = wholesalePricePerPalletPartB;
                createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerUnitTextBoxA.Text = wholesalePricePerUnitPartA;
                createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerUnitTextBoxB.Text = wholesalePricePerUnitPartB;

                string prefix = "Supplier Payment Currency";
                if (activeLanguageRegionCode != LanguageRegionCode.enGB)
                {
                    prefix = _translationService.Translate(prefix, activeLanguageRegionCode);
                }

                createProductTabControlProductSupplierRelationshipTabPageSupplierPaymentCurrencyLabel.Text = $"{prefix} - {supplier.PaymentCurrencyCode}";
            }
            else
            {
                createProductTabControlProductSupplierRelationshipTabPageSupplierPaymentCurrencyLabel.Text = string.Empty;
            }
        }

        private void createProductTabControlProductSalesSubRegionAvailabilityTabPageMoveSalesSubRegionToAvailableListViewButton_Click(object? sender, EventArgs e)
        {
            if (createProductTabControlProductSalesSubRegionAvailabilityTabPageChosenSalesSubRegionListView.SelectedItems.Count > 0)
            {
                var item = createProductTabControlProductSalesSubRegionAvailabilityTabPageChosenSalesSubRegionListView.SelectedItems[0];
                var salesSubRegion = (ProductSalesSubRegionChosenList)item.Tag;

                _productModel.ProductSalesSubRegionChosenList.Remove(salesSubRegion);
                _productModel.ProductSalesSubRegionAvailableList.Add(new ProductSalesSubRegionAvailableList
                {
                    SalesRegion = salesSubRegion.SalesRegion,
                    SalesRegionId = salesSubRegion.SalesRegionId,
                    SalesSubRegion = salesSubRegion.SalesSubRegion,
                    SalesSubRegionId = salesSubRegion.SalesSubRegionId
                });

                _productSharedComponents.UpdateAvailableSalesSubRegionListView(
                    listView: createProductTabControlProductSalesSubRegionAvailabilityTabPageAvailableSalesSubRegionListView,
                    productModel: _productModel
                    );
                _productSharedComponents.UpdateChosenSalesSubRegionListView(
                    listView: createProductTabControlProductSalesSubRegionAvailabilityTabPageChosenSalesSubRegionListView,
                    productModel: _productModel
                    );
            }
        }

        private void createProductTabControlProductSalesSubRegionAvailabilityTabPageMoveSalesSubRegionToChosenListViewButton_Click(object? sender, EventArgs e)
        {
            if (createProductTabControlProductSalesSubRegionAvailabilityTabPageAvailableSalesSubRegionListView.SelectedItems.Count > 0)
            {
                var item = createProductTabControlProductSalesSubRegionAvailabilityTabPageAvailableSalesSubRegionListView.SelectedItems[0];
                var salesSubRegion = (ProductSalesSubRegionAvailableList)item.Tag;

                _productModel.ProductSalesSubRegionAvailableList.Remove(salesSubRegion);
                _productModel.ProductSalesSubRegionChosenList.Add(new ProductSalesSubRegionChosenList
                {
                    ActiveStatus = true,
                    EffectiveDate = DateTime.Now,
                    ExpiryDate = null,
                    ExpiryDateEnabled = false,
                    SalesRegion = salesSubRegion.SalesRegion,
                    SalesRegionId = salesSubRegion.SalesRegionId,
                    SalesSubRegion = salesSubRegion.SalesSubRegion,
                    SalesSubRegionId = salesSubRegion.SalesSubRegionId
                });

                _productSharedComponents.UpdateAvailableSalesSubRegionListView(
                    listView: createProductTabControlProductSalesSubRegionAvailabilityTabPageAvailableSalesSubRegionListView,
                    productModel: _productModel
                    );
                _productSharedComponents.UpdateChosenSalesSubRegionListView(
                    listView: createProductTabControlProductSalesSubRegionAvailabilityTabPageChosenSalesSubRegionListView,
                    productModel: _productModel
                    );
            }
        }

        private void createProductTabControlProductSupplierRelationshipTabPageMoveSupplierToAvailableListViewButton_Click(object? sender, EventArgs e)
        {
            if (createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView.SelectedItems.Count > 0)
            {
                var item = createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView.SelectedItems[0];
                var supplier = (ProductSupplierRelationshipChosenList)item.Tag;

                // Remove from chosen, add to available
                _productModel.ProductSupplierRelationshipChosenList.Remove(supplier);
                _productModel.ProductSupplierRelationshipAvailableList.Add(new ProductSupplierRelationshipAvailableList
                {
                    PaymentCurrencyCode = supplier.PaymentCurrencyCode,
                    PaymentCurrencyId = supplier.PaymentCurrencyId,
                    SupplierId = supplier.SupplierId,
                    SupplierName = supplier.SupplierName
                });

                _productSharedComponents.UpdateAvailableSupplierListView(
                    listView: createProductTabControlProductSupplierRelationshipTabPageAvailableSupplierListView,
                    productModel: _productModel
                    );
                _productSharedComponents.UpdateChosenSupplierListView(
                    listView: createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView,
                    productModel: _productModel
                    );
            }
        }

        private void createProductTabControlProductSupplierRelationshipTabPageMoveSupplierToChosenListViewButton_Click(object? sender, EventArgs e)
        {
            if (createProductTabControlProductSupplierRelationshipTabPageAvailableSupplierListView.SelectedItems.Count > 0)
            {
                var item = createProductTabControlProductSupplierRelationshipTabPageAvailableSupplierListView.SelectedItems[0];
                var supplier = (ProductSupplierRelationshipAvailableList)item.Tag;

                // Remove from available, add to chosen
                _productModel.ProductSupplierRelationshipAvailableList.Remove(supplier);
                _productModel.ProductSupplierRelationshipChosenList.Add(new ProductSupplierRelationshipChosenList
                {
                    ActiveStatus = true,
                    DeliveryLeadTimeDays = 0,
                    PaymentCurrencyCode = supplier.PaymentCurrencyCode,
                    PaymentCurrencyId = supplier.PaymentCurrencyId,
                    SupplierId = supplier.SupplierId,
                    SupplierName = supplier.SupplierName,
                    SupplierProductCode = string.Empty,
                    WholesalePricePerCarton = null,
                    WholesalePricePerPallet = null,
                    WholesalePricePerUnit = 0
                });

                _productSharedComponents.UpdateAvailableSupplierListView(
                    listView: createProductTabControlProductSupplierRelationshipTabPageAvailableSupplierListView,
                    productModel: _productModel
                    );
                _productSharedComponents.UpdateChosenSupplierListView(
                    listView: createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView,
                    productModel: _productModel
                    );
            }
        }

        private void createProductTabControlProductSupplierRelationshipTabPageSupplierProductCodeTextBox_TextChanged(object? sender, EventArgs e)
        {
            if (createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView.SelectedItems.Count > 0)
            {
                var item = createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView.SelectedItems[0];
                var supplier = (ProductSupplierRelationshipChosenList)item.Tag;
                supplier.SupplierProductCode = TextBoxCleanerHelper.GetTrimmedText(createProductTabControlProductSupplierRelationshipTabPageSupplierProductCodeTextBox);
            }
        }

        private void createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBox_TextChanged(object? sender, EventArgs e)
        {
            if (_suppressWholesalePricePerCartonTextChanged)
                return;

            if (createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView.SelectedItems.Count > 0)
            {
                var item = createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView.SelectedItems[0];
                var supplier = (ProductSupplierRelationshipChosenList)item.Tag;

                if (!string.IsNullOrWhiteSpace(createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxA.Text) &&
                    !string.IsNullOrWhiteSpace(createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxB.Text))
                {
                    supplier.WholesalePricePerCarton = _numericParserHelper.ParseDecimal(
                        createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxA,
                        createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxB);
                }
                else
                {
                    supplier.WholesalePricePerCarton = null;
                }

                string wholesalePricePerCartonPartA;
                string wholesalePricePerCartonPartB;

                if (supplier.WholesalePricePerCarton.HasValue)
                {
                    SplitDecimalHelper.SplitDecimalUsingDelimiter((decimal)supplier.WholesalePricePerCarton, out wholesalePricePerCartonPartA, out wholesalePricePerCartonPartB);
                }
                else
                {
                    wholesalePricePerCartonPartA = string.Empty;
                    wholesalePricePerCartonPartB = string.Empty;
                }

                // Prevent recursive calls
                _suppressWholesalePricePerCartonTextChanged = true;
                try
                {
                    createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxA.Text = wholesalePricePerCartonPartA;
                    createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxB.Text = wholesalePricePerCartonPartB;
                }
                finally
                {
                    _suppressWholesalePricePerCartonTextChanged = false;
                }
            }
        }

        private void createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBox_TextChanged(object? sender, EventArgs e)
        {
            if (_suppressWholesalePricePerPalletTextChanged)
                return;

            if (createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView.SelectedItems.Count > 0)
            {
                var item = createProductTabControlProductSupplierRelationshipTabPageChosenSupplierListView.SelectedItems[0];
                var supplier = (ProductSupplierRelationshipChosenList)item.Tag;

                // Parse and update supplier model
                if (!string.IsNullOrWhiteSpace(createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxA.Text) &&
                    !string.IsNullOrWhiteSpace(createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxB.Text))
                {
                    supplier.WholesalePricePerPallet = _numericParserHelper.ParseDecimal(
                        createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxA,
                        createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerPalletTextBoxB);
                }
                else
                {
                    supplier.WholesalePricePerPallet = null;
                }

                // Only normalize and calculate if we have a complete value
                if (supplier.WholesalePricePerPallet.HasValue)
                {
                    // Get delivery type
                    string deliveryType = _productSharedComponents.GetSelectedWholesaleDeliveryType(
                        comboBox: createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleDeliveryTypeComboBox);

                    // Only proceed with calculations if we have pallet-based delivery type
                    if (deliveryType == "Pallet - Carton" || deliveryType == "Pallet - Unit")
                    {
                        // Calculate derived prices
                        var result = ProductSharedComponents.CalculateWholesalePricePerUnit(
                            productModel: _productModel,
                            supplier: supplier,
                            deliveryType: deliveryType);

                        if (result.Success)
                        {
                            // Update unit price
                            SplitDecimalHelper.SplitDecimalUsingDelimiter(result.PricePerUnit, out string unitPartA, out string unitPartB);
                            createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerUnitTextBoxA.Text = unitPartA;
                            createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerUnitTextBoxB.Text = unitPartB;

                            // Update carton price if applicable (for "Pallet - Carton" delivery type)
                            if (deliveryType == "Pallet - Carton" && result.CartonPrice.HasValue)
                            {
                                SplitDecimalHelper.SplitDecimalUsingDelimiter(result.CartonPrice.Value, out string cartonPartA, out string cartonPartB);
                                createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxA.Text = cartonPartA;
                                createProductTabControlProductSupplierRelationshipTabPageWholesalePricePerCartonTextBoxB.Text = cartonPartB;
                            }
                        }
                    }
                }
            }
        }

        private async void createProductSubmitButton_Click(object sender, EventArgs e)
        {
            // Validate the wholesale data model if wholesale is enabled
            if (_productModel.ProductDetailsWholesaleInformation.GeneralInformationWholesaleEnabled)
            {
                bool wholesaleDataModelValidationSuccess = await _productSharedComponents.ValidateWholesaleDataModel(
                    productModel: _productModel,
                    wholesaleDeliveryTypeComboBox: createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleDeliveryTypeComboBox
                );

                if (!wholesaleDataModelValidationSuccess)
                {
                    return;
                }
            }

            // Convert measurements to metric if the active unit type is imperial
            if (activeUnitType == UnitType.Imperial)
            {
                // Prepare measurements to convert
                var measurementsToConvert = _productSharedComponents.PrepareProductMeasurementConversionData(
                    productModel: _productModel
                );

                // Convert measurements
                bool measurementConversionSuccess = await _dataOperationsService.DataOperationsServiceOrchestrator(
                    operationType: DataOperationType.MeasurementConversion,
                    dataToBeProcessed: measurementsToConvert,
                    measurementInputUnitType: UnitType.Imperial,
                    measurementOutputUnitType: UnitType.Metric
                );

                if (measurementConversionSuccess)
                {
                    // Get the conversion results
                    var conversionResults = _dataOperationsService.UnitConversionResults;

                    // Process the conversion results and update the model
                    if (conversionResults != null)
                    {
                        _productSharedComponents.ProcessUnitConversionResults(
                            conversionResults: conversionResults,
                            productModel: _productModel);
                    }
                }
                else
                {
                    return;
                }
            }

            // Create product details in database
            string deliveryType = _productSharedComponents.GetSelectedWholesaleDeliveryType(comboBox: createProductTabControlProductDetailTabPageTabControlWholesaleInformationTabPageGeneralInformationGroupBoxWholesaleDeliveryTypeComboBox);
            var productDetailData = new List<object>();
            Guid productDetailProductId = Guid.Empty;
            var productDetailProperties = _uiModelHelper.GetDataSubjectProperties(FunctionTitle.Product);
            if (productDetailProperties == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.Function.NotImplemented", FunctionTitle.Product.ToString());
                return;
            }

            string productDetailDataSubject = productDetailProperties.DataSubject.DataSubjectFriendlyName;
            string productDetailCreateStoredProcedureName = string.Empty;

            if (!string.IsNullOrEmpty(productDetailProperties.DataSubject.DataSubjectCreateStoredProcedureName))
            {
                productDetailCreateStoredProcedureName = productDetailProperties.DataSubject.DataSubjectCreateStoredProcedureName;
            }

            // Active Status
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = false,
                ["PropertyName"] = "Product General Information: Active Status",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "activeStatus",
                ["PropertyType"] = typeof(bool),
                ["PropertyValue"] = _productModel.ProductDetailsGeneralInformation.ActiveProductStatus
            });

            // Carton Area
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Carton Area",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesaleCartonArea",
                ["PropertyType"] = typeof(decimal),
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonArea
            });

            // Carton Barcode
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Carton Barcode",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesaleCartonBarcode",
                ["PropertyType"] = typeof(string),
                ["MaxLength"] = 50,
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonBarcode
            });

            // Carton Depth
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Carton Depth",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesaleCartonDepthCentimeter",
                ["PropertyType"] = typeof(decimal),
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonDepth
            });

            // Carton Height
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Carton Height",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesaleCartonHeightCentimeter",
                ["PropertyType"] = typeof(decimal),
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonHeight
            });

            // Carton Packaging Weight
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Carton Packaging Weight",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesaleCartonPackagingWeightKilogram",
                ["PropertyType"] = typeof(decimal),
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonPackagingWeight
            });

            // Carton Quantity per Pallet Level
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Carton Quantity Per Pallet Level",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesaleCartonQuantityPerPalletLevel",
                ["PropertyType"] = typeof(byte),
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.PalletInformationCartonQuantityPerPalletLevel
            });

            // Carton Stacking Height per Pallet
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Carton Stacking Height Per Pallet",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesaleCartonStackingHeightPerPallet",
                ["PropertyType"] = typeof(byte),
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.PalletInformationCartonStackingHeightPallet
            });

            // Carton Total Weight
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Carton Total Weight",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesaleCartonTotalWeightKilogram",
                ["PropertyType"] = typeof(decimal),
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.CartonInformationTotalCartonWeight
            });

            // Carton Volume
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Carton Volume",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesaleCartonVolumeCubicCentimeter",
                ["PropertyType"] = typeof(decimal),
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonVolume
            });

            // Carton Width
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Carton Width",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesaleCartonWidthCentimeter",
                ["PropertyType"] = typeof(decimal),
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.CartonInformationCartonWidth
            });

            // Pallet Area
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Pallet Area",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesalePalletArea",
                ["PropertyType"] = typeof(decimal),
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletArea
            });

            // Pallet Barcode
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Pallet Barcode",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesalePalletBarcode",
                ["PropertyType"] = typeof(string),
                ["MaxLength"] = 50,
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletBarcode
            });

            // Pallet Depth
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Pallet Depth",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesalePalletDepthCentimeter",
                ["PropertyType"] = typeof(decimal),
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletDepth
            });

            // Pallet Height
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Pallet Height",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesalePalletHeightCentimeter",
                ["PropertyType"] = typeof(decimal),
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletHeight
            });

            // Pallet Total Height
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Pallet Total Height",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesalePalletTotalHeightCentimeter",
                ["PropertyType"] = typeof(decimal),
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletHeight
            });

            // Pallet Total Volume
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Pallet Total Volume",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesalePalletTotalVolumeCubicCentimeter",
                ["PropertyType"] = typeof(decimal),
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletVolume
            });

            // Pallet Total Weight
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Pallet Total Weight",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesalePalletTotalWeightKilogram",
                ["PropertyType"] = typeof(decimal),
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.PalletInformationTotalPalletWeight
            });

            // Pallet Volume
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Pallet Volume",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesalePalletVolumeCubicCentimeter",
                ["PropertyType"] = typeof(decimal),
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletVolume
            });

            // Pallet Weight
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Pallet Weight",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesalePalletWeightKilogram",
                ["PropertyType"] = typeof(decimal),
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWeight
            });

            // Pallet Width
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Pallet Width",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesalePalletWidthCentimeter",
                ["PropertyType"] = typeof(decimal),
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.PalletInformationPalletWidth
            });

            // Product Country Of Origin Id
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = false,
                ["PropertyName"] = "Product General Information: Product Country Of Origin Id",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "productCountryOfOriginId",
                ["PropertyType"] = typeof(Guid),
                ["PropertyValue"] = _productModel.ProductDetailsGeneralInformation.ProductCountryOfOriginId
            });

            // Product Description
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product General Information: Product Description",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "productDescription",
                ["PropertyType"] = typeof(string),
                ["MaxLength"] = 255,
                ["PropertyValue"] = _productModel.ProductDetailsGeneralInformation.ProductDescription
            });

            // Product Family Id
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product General Information: Product Family Id",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "productFamilyId",
                ["PropertyType"] = typeof(Guid),
                ["PropertyValue"] = _productModel.ProductDetailsGeneralInformation.ProductFamilyId
            });

            // Product Id (Output Parameter)
            productDetailData.Add(new Dictionary<string, object>
            {
                ["PropertyName"] = "Product: Product Id",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Output,
                ["PropertyStoredProcedureParameterName"] = "productId",
                ["PropertyType"] = typeof(Guid),
                ["PropertyValue"] = DBNull.Value
            });

            // Product Manufacturer Id
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = false,
                ["PropertyName"] = "Product General Information: Product Manufacturer Id",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "manufacturerId",
                ["PropertyType"] = typeof(Guid),
                ["PropertyValue"] = _productModel.ProductDetailsGeneralInformation.ProductManufacturerId
            });

            // Product Manufacturer Part Number
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product General Information: Product Manufacturer Part Number",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "manufacturerPartNumber",
                ["PropertyType"] = typeof(string),
                ["MaxLength"] = 50,
                ["PropertyValue"] = _productModel.ProductDetailsGeneralInformation.ProductManufacturerPartNumber
            });

            // Product Name
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = false,
                ["PropertyName"] = "Product General Information: Product Name",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "productName",
                ["PropertyType"] = typeof(string),
                ["MaxLength"] = 50,
                ["PropertyValue"] = _productModel.ProductDetailsGeneralInformation.ProductName
            });

            // Product Sub Category Id
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = false,
                ["PropertyName"] = "Product General Information: Product Sub Category Id",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "productSubCategoryId",
                ["PropertyType"] = typeof(Guid),
                ["PropertyValue"] = _productModel.ProductDetailsGeneralInformation.ProductSubCategoryId
            });

            // Total Carton Quantity per Pallet
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Carton Quantity Per Pallet",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesaleTotalCartonQuantityPerPallet",
                ["PropertyType"] = typeof(int),
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.PalletInformationCartonQuantityPerPallet
            });

            // Total Unit Quantity per Pallet
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Unit Quantity Per Pallet",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesaleTotalUnitQuantityPerPallet",
                ["PropertyType"] = typeof(int),
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.PalletInformationUnitQuantityPerPallet
            });

            // Unit Area
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = false,
                ["PropertyName"] = "Product Unit Information: Unit Area",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "unitArea",
                ["PropertyType"] = typeof(decimal),
                ["PropertyValue"] = _productModel.ProductDetailsUnitInformation.UnitArea
            });

            // Unit Barcode
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Unit Information: Unit Barcode",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "unitBarcode",
                ["PropertyType"] = typeof(string),
                ["MaxLength"] = 50,
                ["PropertyValue"] = _productModel.ProductDetailsUnitInformation.UnitBarcode
            });

            // Unit Depth
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = false,
                ["PropertyName"] = "Product Unit Information: Unit Depth",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "unitDepthCentimeter",
                ["PropertyType"] = typeof(decimal),
                ["PropertyValue"] = _productModel.ProductDetailsUnitInformation.UnitDepth
            });

            // Unit Height
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = false,
                ["PropertyName"] = "Product Unit Information: Unit Height",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "unitHeightCentimeter",
                ["PropertyType"] = typeof(decimal),
                ["PropertyValue"] = _productModel.ProductDetailsUnitInformation.UnitHeight
            });

            // Unit Minimum Stock Quantity
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Unit Information: Unit Minimum Stock Quantity",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "unitMinimumStockQuantity",
                ["PropertyType"] = typeof(int),
                ["PropertyValue"] = _productModel.ProductDetailsUnitInformation.UnitMinimumStockQuantity
            });

            // Unit Price
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = false,
                ["PropertyName"] = "Product Unit Information: Unit Price",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "unitPrice",
                ["PropertyType"] = typeof(decimal),
                ["PropertyValue"] = _productModel.ProductDetailsUnitInformation.UnitPrice
            });

            // Unit Quantity Per Carton
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Unit Quantity Per Carton",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesaleUnitQuantityPerCarton",
                ["PropertyType"] = typeof(int),
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.CartonInformationUnitQuantityPerCarton
            });

            // Unit Quantity per Pallet Level
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Unit Quantity Per Pallet Level",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesaleUnitQuantityPerPalletLevel",
                ["PropertyType"] = typeof(int),
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.PalletInformationUnitQuantityPerPalletLevel
            });

            // Unit Stacking Height per Pallet
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Unit Stacking Height Per Pallet",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesaleUnitStackingHeightPerPallet",
                ["PropertyType"] = typeof(byte),
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.PalletInformationUnitStackingHeightPallet
            });

            // Unit Stock Quantity Held
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = false,
                ["PropertyName"] = "Product Unit Information: Unit Stock Quantity Held",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "unitStockQuantityHeld",
                ["PropertyType"] = typeof(int),
                ["PropertyValue"] = 0
            });

            // Unit Volume
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = false,
                ["PropertyName"] = "Product Unit Information: Unit Volume",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "unitVolumeCubicCentimeter",
                ["PropertyType"] = typeof(decimal),
                ["PropertyValue"] = _productModel.ProductDetailsUnitInformation.UnitVolume
            });

            // Unit Weight
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = false,
                ["PropertyName"] = "Product Unit Information: Unit Weight",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "unitWeightKilogram",
                ["PropertyType"] = typeof(decimal),
                ["PropertyValue"] = _productModel.ProductDetailsUnitInformation.UnitWeight
            });

            // Unit Width
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = false,
                ["PropertyName"] = "Product Unit Information: Unit Width",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "unitWidthCentimeter",
                ["PropertyType"] = typeof(decimal),
                ["PropertyValue"] = _productModel.ProductDetailsUnitInformation.UnitWidth
            });

            // Wholesale Carton Flag
            if (deliveryType == "Carton" || deliveryType == "Pallet - Carton")
            {
                productDetailData.Add(new Dictionary<string, object>
                {
                    ["AllowNullValue"] = false,
                    ["PropertyName"] = "Product Wholesale Information: Wholesale Carton Flag",
                    ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                    ["PropertyStoredProcedureParameterName"] = "wholesaleCartonFlag",
                    ["PropertyType"] = typeof(bool),
                    ["PropertyValue"] = true
                });
            }
            else
            {
                productDetailData.Add(new Dictionary<string, object>
                {
                    ["AllowNullValue"] = false,
                    ["PropertyName"] = "Product Wholesale Information: Wholesale Carton Flag",
                    ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                    ["PropertyStoredProcedureParameterName"] = "wholesaleCartonFlag",
                    ["PropertyType"] = typeof(bool),
                    ["PropertyValue"] = false
                });
            }

            // Wholesale Delivery Type Id
            productDetailData.Add(new Dictionary<string, object>
            {
                ["AllowNullValue"] = true,
                ["PropertyName"] = "Product Wholesale Information: Wholesale Delivery Type Id",
                ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                ["PropertyStoredProcedureParameterName"] = "wholesaleDeliveryTypeId",
                ["PropertyType"] = typeof(Guid),
                ["PropertyValue"] = _productModel.ProductDetailsWholesaleInformation.GeneralInformationWholesaleDeliveryTypeId
            });

            // Wholesale Enabled
            if (_productModel.ProductDetailsWholesaleInformation.GeneralInformationWholesaleEnabled == true)
            {
                productDetailData.Add(new Dictionary<string, object>
                {
                    ["AllowNullValue"] = false,
                    ["PropertyName"] = "Product Wholesale Information: Wholesale Enabled",
                    ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                    ["PropertyStoredProcedureParameterName"] = "wholesaleFlag",
                    ["PropertyType"] = typeof(bool),
                    ["PropertyValue"] = true
                });
            }
            else
            {
                productDetailData.Add(new Dictionary<string, object>
                {
                    ["AllowNullValue"] = false,
                    ["PropertyName"] = "Product Wholesale Information: Wholesale Enabled",
                    ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                    ["PropertyStoredProcedureParameterName"] = "wholesaleFlag",
                    ["PropertyType"] = typeof(bool),
                    ["PropertyValue"] = false
                });
            }

            // Wholesale Pallet Flag
            if (deliveryType == "Pallet - Carton" || deliveryType == "Pallet - Unit")
            {
                productDetailData.Add(new Dictionary<string, object>
                {
                    ["AllowNullValue"] = false,
                    ["PropertyName"] = "Product Wholesale Information: Wholesale Pallet Flag",
                    ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                    ["PropertyStoredProcedureParameterName"] = "wholesalePalletFlag",
                    ["PropertyType"] = typeof(bool),
                    ["PropertyValue"] = true
                });
            }
            else
            {
                productDetailData.Add(new Dictionary<string, object>
                {
                    ["AllowNullValue"] = false,
                    ["PropertyName"] = "Product Wholesale Information: Wholesale Pallet Flag",
                    ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                    ["PropertyStoredProcedureParameterName"] = "wholesalePalletFlag",
                    ["PropertyType"] = typeof(bool),
                    ["PropertyValue"] = false
                });
            }

            // Wholesale Reorder
            if (_productModel.ProductDetailsWholesaleInformation.GeneralInformationWholesaleReorder == true)
            {
                productDetailData.Add(new Dictionary<string, object>
                {
                    ["AllowNullValue"] = false,
                    ["PropertyName"] = "Product Wholesale Information: Wholesale Reorder",
                    ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                    ["PropertyStoredProcedureParameterName"] = "wholesaleReorderFlag",
                    ["PropertyType"] = typeof(bool),
                    ["PropertyValue"] = true
                });
            }
            else
            {
                productDetailData.Add(new Dictionary<string, object>
                {
                    ["AllowNullValue"] = false,
                    ["PropertyName"] = "Product Wholesale Information: Wholesale Reorder",
                    ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                    ["PropertyStoredProcedureParameterName"] = "wholesaleReorderFlag",
                    ["PropertyType"] = typeof(bool),
                    ["PropertyValue"] = false
                });
            }

            // Create Product
            bool createProductDetailsSuccess = await _dataOperationsService.DataOperationsServiceOrchestrator(
                dataSubjectName: productDetailDataSubject,
                dataToBeProcessed: productDetailData.ToArray(),
                operationType: DataOperationType.Create,
                outboundStoredProcedureParameterName: "productId",
                outputStoredProcedureParameterCapture: true,
                storedProcedureName: productDetailCreateStoredProcedureName
            );

            // Capture Product Id
            if (createProductDetailsSuccess)
            {
                productDetailProductId = _dataOperationsService.OutputStoredProcedureParameters["productId"] switch
                {
                    Guid guidValue => guidValue,
                    string stringValue when Guid.TryParse(stringValue, out var parsedGuid) => parsedGuid,
                    _ => Guid.Empty
                };
            }
            else
            {
                return;
            }

            // Process Product Images if there are any
            if (_productModel.ProductImageList.Count > 0 && productDetailProductId != Guid.Empty)
            {
                var productImageData = new List<object>();
                var productImageProperties = _uiModelHelper.GetDataSubjectProperties(FunctionTitle.ProductImage);
                if (productImageProperties == null)
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.Function.NotImplemented", FunctionTitle.ProductImage.ToString());
                    return;
                }

                string productImageDataSubject = productImageProperties.DataSubject.DataSubjectFriendlyName;
                string productImageCreateStoredProcedureName = string.Empty;

                if (!string.IsNullOrEmpty(productImageProperties.DataSubject.DataSubjectCreateStoredProcedureName))
                {
                    productImageCreateStoredProcedureName = productImageProperties.DataSubject.DataSubjectCreateStoredProcedureName;
                }

                // Prepare data in Product Image List and add each image to Database
                foreach (var image in _productModel.ProductImageList)
                {
                    image.AltText = image.AltText.TrimEnd();
                    image.Caption = image.Caption.TrimEnd();

                    // Product Id
                    productImageData.Add(new Dictionary<string, object>
                    {
                        ["AllowNullValue"] = false,
                        ["PropertyName"] = "Product Image: Product Id",
                        ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                        ["PropertyStoredProcedureParameterName"] = "productId",
                        ["PropertyType"] = typeof(Guid),
                        ["PropertyValue"] = productDetailProductId
                    });

                    // Product Image
                    productImageData.Add(new Dictionary<string, object>
                    {
                        ["AllowNullValue"] = false,
                        ["MaxPixelHeight"] = _productModel.ProductImageDimension.maxHeight,
                        ["MaxPixelWidth"] = _productModel.ProductImageDimension.maxWidth,
                        ["PropertyName"] = "Product Image: Image",
                        ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                        ["PropertyStoredProcedureParameterName"] = "productImage",
                        ["PropertyType"] = typeof(byte[]),
                        ["PropertyValue"] = image.ImageBytes
                    });

                    // Product Image Alt Text
                    productImageData.Add(new Dictionary<string, object>
                    {
                        ["AllowNullValue"] = true,
                        ["PropertyName"] = "Product Image: Alt Text",
                        ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                        ["PropertyStoredProcedureParameterName"] = "productImageAltText",
                        ["PropertyType"] = typeof(string),
                        ["MaxLength"] = 150,
                        ["PropertyValue"] = image.AltText
                    });

                    // Product Image Caption
                    productImageData.Add(new Dictionary<string, object>
                    {
                        ["AllowNullValue"] = true,
                        ["PropertyName"] = "Product Image: Caption",
                        ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                        ["PropertyStoredProcedureParameterName"] = "productImageCaption",
                        ["PropertyType"] = typeof(string),
                        ["MaxLength"] = 255,
                        ["PropertyValue"] = image.Caption
                    });

                    // Product Image Display Order
                    productImageData.Add(new Dictionary<string, object>
                    {
                        ["AllowNullValue"] = false,
                        ["PropertyName"] = "Product Image: Display Order",
                        ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                        ["PropertyStoredProcedureParameterName"] = "productImageDisplayOrder",
                        ["PropertyType"] = typeof(int),
                        ["PropertyValue"] = image.DisplayOrder
                    });

                    // Product Image Is Thumbnail
                    productImageData.Add(new Dictionary<string, object>
                    {
                        ["AllowNullValue"] = false,
                        ["PropertyName"] = "Product Image: Is Thumbnail",
                        ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                        ["PropertyStoredProcedureParameterName"] = "productImageIsThumbnail",
                        ["PropertyType"] = typeof(bool),
                        ["PropertyValue"] = image.IsThumbnail
                    });

                    // Create Product Image
                    bool createProductImageSuccess = await _dataOperationsService.DataOperationsServiceOrchestrator(
                        dataSubjectName: productImageDataSubject,
                        dataToBeProcessed: productImageData.ToArray(),
                        operationType: DataOperationType.Create,
                        storedProcedureName: productImageCreateStoredProcedureName
                    );

                    if (!createProductImageSuccess)
                    {
                        return;
                    }
                    else
                    {
                        productImageData.Clear();
                    }
                }
            }

            // Process Product Sales Sub Region Associations if there are any
            if (_productModel.ProductSalesSubRegionChosenList.Count > 0 && productDetailProductId != Guid.Empty)
            {
                var productSalesSubRegionData = new List<object>();
                var productSalesSubRegionProperties = _uiModelHelper.GetDataSubjectProperties(FunctionTitle.ProductSalesSubRegion);
                if (productSalesSubRegionProperties == null)
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.Function.NotImplemented", FunctionTitle.ProductSalesSubRegion.ToString());
                    return;
                }

                string productSalesSubRegionDataSubject = productSalesSubRegionProperties.DataSubject.DataSubjectFriendlyName;
                string productSalesSubRegionCreateStoredProcedureName = string.Empty;

                if (!string.IsNullOrEmpty(productSalesSubRegionProperties.DataSubject.DataSubjectCreateStoredProcedureName))
                {
                    productSalesSubRegionCreateStoredProcedureName = productSalesSubRegionProperties.DataSubject.DataSubjectCreateStoredProcedureName;
                }

                foreach (var salesSubRegion in _productModel.ProductSalesSubRegionChosenList)
                {
                    // Active Status
                    productSalesSubRegionData.Add(new Dictionary<string, object>
                    {
                        ["AllowNullValue"] = false,
                        ["PropertyName"] = "Product Sales Sub Region: Active Status",
                        ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                        ["PropertyStoredProcedureParameterName"] = "activeStatus",
                        ["PropertyType"] = typeof(bool),
                        ["PropertyValue"] = salesSubRegion.ActiveStatus
                    });

                    // Effective Date
                    productSalesSubRegionData.Add(new Dictionary<string, object>
                    {
                        ["AllowNullValue"] = false,
                        ["PropertyName"] = "Product Sales Sub Region: Effective Date",
                        ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                        ["PropertyStoredProcedureParameterName"] = "effectiveDate",
                        ["PropertyType"] = typeof(DateTime),
                        ["PropertyValue"] = salesSubRegion.EffectiveDate
                    });

                    // Expiry Date
                    productSalesSubRegionData.Add(new Dictionary<string, object>
                    {
                        ["AllowNullValue"] = true,
                        ["PropertyName"] = "Product Sales Sub Region: Expiry Date",
                        ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                        ["PropertyStoredProcedureParameterName"] = "expiryDate",
                        ["PropertyType"] = typeof(DateTime),
                        ["PropertyValue"] = salesSubRegion.ExpiryDate
                    });

                    // Product Id
                    productSalesSubRegionData.Add(new Dictionary<string, object>
                    {
                        ["AllowNullValue"] = false,
                        ["PropertyName"] = "Product Sales Sub Region: Product Id",
                        ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                        ["PropertyStoredProcedureParameterName"] = "productId",
                        ["PropertyType"] = typeof(Guid),
                        ["PropertyValue"] = productDetailProductId
                    });

                    // Sales Sub Region Id
                    productSalesSubRegionData.Add(new Dictionary<string, object>
                    {
                        ["AllowNullValue"] = false,
                        ["PropertyName"] = "Product Sales Sub Region: Sales Sub Region Id",
                        ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                        ["PropertyStoredProcedureParameterName"] = "salesSubRegionId",
                        ["PropertyType"] = typeof(Guid),
                        ["PropertyValue"] = salesSubRegion.SalesSubRegionId
                    });

                    // Create Product Sales Sub Region
                    bool createProductSalesSubRegionSuccess = await _dataOperationsService.DataOperationsServiceOrchestrator(
                        dataSubjectName: productSalesSubRegionDataSubject,
                        dataToBeProcessed: productSalesSubRegionData.ToArray(),
                        operationType: DataOperationType.Create,
                        storedProcedureName: productSalesSubRegionCreateStoredProcedureName
                    );

                    if (!createProductSalesSubRegionSuccess)
                    {
                        return;
                    }
                    else
                    {
                        productSalesSubRegionData.Clear();
                    }
                }
            }

            // Process Product Supplier Relationships if there are any
            if (_productModel.ProductSupplierRelationshipChosenList.Count > 0 && productDetailProductId != Guid.Empty)
            {
                var productSupplierRelationshipData = new List<object>();
                var productSupplierRelationshipProperties = _uiModelHelper.GetDataSubjectProperties(FunctionTitle.ProductSupplier);
                if (productSupplierRelationshipProperties == null)
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.Function.NotImplemented", FunctionTitle.ProductSupplier.ToString());
                    return;
                }
                string productSupplierRelationshipDataSubject = productSupplierRelationshipProperties.DataSubject.DataSubjectFriendlyName;
                string productSupplierRelationshipCreateStoredProcedureName = string.Empty;

                if (!string.IsNullOrEmpty(productSupplierRelationshipProperties.DataSubject.DataSubjectCreateStoredProcedureName))
                {
                    productSupplierRelationshipCreateStoredProcedureName = productSupplierRelationshipProperties.DataSubject.DataSubjectCreateStoredProcedureName;
                }

                foreach (var supplier in _productModel.ProductSupplierRelationshipChosenList)
                {
                    // Active Status
                    productSupplierRelationshipData.Add(new Dictionary<string, object>
                    {
                        ["AllowNullValue"] = false,
                        ["PropertyName"] = "Product Supplier Relationship: Active Status",
                        ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                        ["PropertyStoredProcedureParameterName"] = "activeStatus",
                        ["PropertyType"] = typeof(bool),
                        ["PropertyValue"] = supplier.ActiveStatus
                    });

                    // Delivery Lead Time (Days)
                    productSupplierRelationshipData.Add(new Dictionary<string, object>
                    {
                        ["AllowNullValue"] = false,
                        ["PropertyName"] = "Product Supplier Relationship: Delivery Lead Time (Days)",
                        ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                        ["PropertyStoredProcedureParameterName"] = "deliveryLeadTimeDays",
                        ["PropertyType"] = typeof(int),
                        ["PropertyValue"] = supplier.DeliveryLeadTimeDays
                    });

                    // Product Id
                    productSupplierRelationshipData.Add(new Dictionary<string, object>
                    {
                        ["AllowNullValue"] = false,
                        ["PropertyName"] = "Product Sales Sub Region: Product Id",
                        ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                        ["PropertyStoredProcedureParameterName"] = "productId",
                        ["PropertyType"] = typeof(Guid),
                        ["PropertyValue"] = productDetailProductId
                    });

                    // Supplier Id
                    productSupplierRelationshipData.Add(new Dictionary<string, object>
                    {
                        ["AllowNullValue"] = false,
                        ["PropertyName"] = "Product Supplier Relationship: Supplier Id",
                        ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                        ["PropertyStoredProcedureParameterName"] = "supplierId",
                        ["PropertyType"] = typeof(Guid),
                        ["PropertyValue"] = supplier.SupplierId
                    });

                    // Supplier Product Code
                    productSupplierRelationshipData.Add(new Dictionary<string, object>
                    {
                        ["AllowNullValue"] = true,
                        ["PropertyName"] = "Product Supplier Relationship: Supplier Product Code",
                        ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                        ["PropertyStoredProcedureParameterName"] = "supplierProductCode",
                        ["PropertyType"] = typeof(string),
                        ["MaxLength"] = 50,
                        ["PropertyValue"] = supplier.SupplierProductCode
                    });

                    // Wholesale Price per Carton
                    productSupplierRelationshipData.Add(new Dictionary<string, object>
                    {
                        ["AllowNullValue"] = true,
                        ["PropertyName"] = "Product Supplier Relationship: Wholesale Price Per Carton",
                        ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                        ["PropertyStoredProcedureParameterName"] = "wholesalePricePerCarton",
                        ["PropertyType"] = typeof(decimal),
                        ["PropertyValue"] = supplier.WholesalePricePerCarton
                    });

                    // Wholesale Price per Pallet
                    productSupplierRelationshipData.Add(new Dictionary<string, object>
                    {
                        ["AllowNullValue"] = true,
                        ["PropertyName"] = "Product Supplier Relationship: Wholesale Price Per Pallet",
                        ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                        ["PropertyStoredProcedureParameterName"] = "wholesalePricePerPallet",
                        ["PropertyType"] = typeof(decimal),
                        ["PropertyValue"] = supplier.WholesalePricePerPallet
                    });

                    // Wholesale Price per Unit
                    productSupplierRelationshipData.Add(new Dictionary<string, object>
                    {
                        ["AllowNullValue"] = false,
                        ["PropertyName"] = "Product Supplier Relationship: Wholesale Price Per Unit",
                        ["PropertyStoredProcedureParameterDirection"] = ParameterDirection.Input,
                        ["PropertyStoredProcedureParameterName"] = "wholesalePricePerUnit",
                        ["PropertyType"] = typeof(decimal),
                        ["PropertyValue"] = supplier.WholesalePricePerUnit
                    });
                }

                // Create Product Sales Sub Region
                bool createProductSupplierRelationshipSuccess = await _dataOperationsService.DataOperationsServiceOrchestrator(
                    dataSubjectName: productSupplierRelationshipDataSubject,
                    dataToBeProcessed: productSupplierRelationshipData.ToArray(),
                    operationType: DataOperationType.Create,
                    storedProcedureName: productSupplierRelationshipCreateStoredProcedureName
                );

                if (!createProductSupplierRelationshipSuccess)
                {
                    return;
                }
                else
                {
                    productSupplierRelationshipData.Clear();
                }
            }

            this.Close();
        }
    }
}