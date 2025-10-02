using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Model
{
    public class ProductModel
    {
        public ExistingRecordModel? ExistingRecordModel { get; set; } = new ExistingRecordModel();
        public ProductDetailsGeneralInformation ProductDetailsGeneralInformation { get; set; } = new ProductDetailsGeneralInformation();
        public ProductDetailsUnitInformation ProductDetailsUnitInformation { get; set; } = new ProductDetailsUnitInformation();
        public ProductDetailsWholesaleInformation ProductDetailsWholesaleInformation { get; set; } = new ProductDetailsWholesaleInformation();
        public List<ProductImageList> ProductImageList { get; set; } = new List<ProductImageList>();
        public ProductImageDimension ProductImageDimension { get; set; } = new ProductImageDimension();
        public List<ProductSalesSubRegionAvailableList> ProductSalesSubRegionAvailableList { get; set; } = new List<ProductSalesSubRegionAvailableList>();
        public List<ProductSalesSubRegionChosenList> ProductSalesSubRegionChosenList { get; set; } = new List<ProductSalesSubRegionChosenList>();
        public List<ProductSupplierRelationshipAvailableList> ProductSupplierRelationshipAvailableList { get; set; } = new List<ProductSupplierRelationshipAvailableList>();
        public List<ProductSupplierRelationshipChosenList> ProductSupplierRelationshipChosenList { get; set; } = new List<ProductSupplierRelationshipChosenList>();
    }

    public class ProductDetailsGeneralInformation
    {
        public bool ActiveProductStatus { get; set; } = true;
        public bool? ActiveProductStatusOriginalValue { get; set; }
        public Guid ProductCategoryId { get; set; }
        public Guid? ProductCategoryIdOriginalValue { get; set; }
        public Guid ProductCountryOfOriginId { get; set; }
        public Guid? ProductCountryOfOriginIdOriginalValue { get; set; }
        public string? ProductDescription { get; set; } = string.Empty;
        public string? ProductDescriptionOriginalValue { get; set; } = string.Empty;
        public bool ProductFamilyEnabled { get; set; } = false;
        public bool? ProductFamilyEnabledOriginalValue { get; set; }
        public Guid? ProductFamilyId { get; set; }
        public Guid? ProductFamilyIdOriginalValue { get; set; }
        public Guid ProductManufacturerId { get; set; }
        public Guid? ProductManufacturerIdOriginalValue { get; set; }
        public string? ProductManufacturerPartNumber { get; set; } = string.Empty;
        public string? ProductManufacturerPartNumberOriginalValue { get; set; } = string.Empty;
        public string ProductName { get; set; }
        public string? ProductNameOriginalValue { get; set; } = string.Empty;
        public Guid ProductSubCategoryId { get; set; }
        public Guid? ProductSubCategoryIdOriginalValue { get; set; }
    }

    public class ProductDetailsUnitInformation
    {
        public decimal? UnitArea { get; set; }
        public decimal? UnitAreaOriginalValue { get; set; }
        public string? UnitBarcode { get; set; } = string.Empty;
        public string? UnitBarcodeOriginalValue { get; set; } = string.Empty;
        public decimal? UnitDepth { get; set; }
        public decimal? UnitDepthOriginalValue { get; set; }
        public decimal? UnitHeight { get; set; }
        public decimal? UnitHeightOriginalValue { get; set; }
        public int? UnitMinimumStockQuantity { get; set; }
        public int? UnitMinimumStockQuantityOriginalValue { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? UnitPriceOriginalValue { get; set; }
        public decimal? UnitVolume { get; set; }
        public decimal? UnitVolumeOriginalValue { get; set; }
        public decimal? UnitWeight { get; set; }
        public decimal? UnitWeightOriginalValue { get; set; }
        public decimal? UnitWidth { get; set; }
        public decimal? UnitWidthOriginalValue { get; set; }
    }

    public class ProductDetailsWholesaleInformation
    {
        public decimal? CartonInformationCartonArea { get; set; }
        public decimal? CartonInformationCartonAreaOriginalValue { get; set; }
        public string? CartonInformationCartonBarcode { get; set; } = string.Empty;
        public string? CartonInformationCartonBarcodeOriginalValue { get; set; } = string.Empty;
        public decimal? CartonInformationCartonDepth { get; set; }
        public decimal? CartonInformationCartonDepthOriginalValue { get; set; }
        public decimal? CartonInformationCartonHeight { get; set; }
        public decimal? CartonInformationCartonHeightOriginalValue { get; set; }
        public decimal? CartonInformationCartonPackagingWeight { get; set; }
        public decimal? CartonInformationCartonPackagingWeightOriginalValue { get; set; }
        public decimal? CartonInformationCartonVolume { get; set; }
        public decimal? CartonInformationCartonVolumeOriginalValue { get; set; }
        public decimal? CartonInformationCartonWidth { get; set; }
        public decimal? CartonInformationCartonWidthOriginalValue { get; set; }
        public decimal? CartonInformationTotalCartonWeight { get; set; }
        public decimal? CartonInformationTotalCartonWeightOriginalValue { get; set; }
        public int? CartonInformationUnitQuantityPerCarton { get; set; }
        public int? CartonInformationUnitQuantityPerCartonOriginalValue { get; set; }
        public Guid? GeneralInformationWholesaleDeliveryTypeId { get; set; }
        public Guid? GeneralInformationWholesaleDeliveryTypeIdOriginalValue { get; set; }
        public bool GeneralInformationWholesaleEnabled { get; set; } = true;
        public bool? GeneralInformationWholesaleEnabledOriginalValue { get; set; }
        public bool? GeneralInformationWholesaleReorder { get; set; } = true;
        public bool? GeneralInformationWholesaleReorderOriginalValue { get; set; }
        public int? PalletInformationCartonQuantityPerPallet { get; set; }
        public int? PalletInformationCartonQuantityPerPalletOriginalValue { get; set; }
        public int? PalletInformationCartonQuantityPerPalletLevel { get; set; }
        public int? PalletInformationCartonQuantityPerPalletLevelOriginalValue { get; set; }
        public int? PalletInformationCartonStackingHeightPallet { get; set; }
        public int? PalletInformationCartonStackingHeightPalletOriginalValue { get; set; }
        public decimal? PalletInformationPalletArea { get; set; }
        public decimal? PalletInformationPalletAreaOriginalValue { get; set; }
        public string? PalletInformationPalletBarcode { get; set; } = string.Empty;
        public string? PalletInformationPalletBarcodeOriginalValue { get; set; } = string.Empty;
        public decimal? PalletInformationPalletDepth { get; set; }
        public decimal? PalletInformationPalletDepthOriginalValue { get; set; }
        public decimal? PalletInformationPalletHeight { get; set; }
        public decimal? PalletInformationPalletHeightOriginalValue { get; set; }
        public decimal? PalletInformationPalletVolume { get; set; }
        public decimal? PalletInformationPalletVolumeOriginalValue { get; set; }
        public decimal? PalletInformationPalletWeight { get; set; }
        public decimal? PalletInformationPalletWeightOriginalValue { get; set; }
        public decimal? PalletInformationPalletWidth { get; set; }
        public decimal? PalletInformationPalletWidthOriginalValue { get; set; }
        public decimal? PalletInformationTotalPalletHeight { get; set; }
        public decimal? PalletInformationTotalPalletHeightOriginalValue { get; set; }
        public decimal? PalletInformationTotalPalletVolume { get; set; }
        public decimal? PalletInformationTotalPalletVolumeOriginalValue { get; set; }
        public decimal? PalletInformationTotalPalletWeight { get; set; }
        public decimal? PalletInformationTotalPalletWeightOriginalValue { get; set; }
        public int? PalletInformationUnitQuantityPerPallet { get; set; }
        public int? PalletInformationUnitQuantityPerPalletOriginalValue { get; set; }
        public int? PalletInformationUnitQuantityPerPalletLevel { get; set; }
        public int? PalletInformationUnitQuantityPerPalletLevelOriginalValue { get; set; }
        public int? PalletInformationUnitStackingHeightPallet { get; set; }
        public int? PalletInformationUnitStackingHeightPalletOriginalValue { get; set; }
    }

    public class ProductImageDimension
    {
        public int maxHeight { get; set; } = 1000;
        public int maxWidth { get; set; } = 1000;
    }

    public class ProductImageList
    {
        public string? AltText { get; set; } = string.Empty;
        public string? AltTextOriginalValue { get; set; } = string.Empty;
        public string? Caption { get; set; } = string.Empty;
        public string? CaptionOriginalValue { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public int? DisplayOrderOriginalValue { get; set; }
        public byte[] ImageBytes { get; set; } = Array.Empty<byte>();
        public byte[]? ImageBytesOriginalValue { get; set; } = Array.Empty<byte>();
        public bool IsThumbnail { get; set; } = false;
        public bool? IsThumbnailOriginalValue { get; set; }
    }

    public class ProductSalesSubRegionAvailableList
    {
        [Column("Sales Region")]
        public string SalesRegion { get; set; } = string.Empty;
        [Column("Sales Region Id")]
        public Guid SalesRegionId { get; set; }
        [Column("Sales Sub Region")]
        public string SalesSubRegion { get; set; } = string.Empty;
        [Column("Sales Sub Region Id")]
        public Guid SalesSubRegionId { get; set; }
    }

    public class ProductSalesSubRegionChosenList
    {
        public bool ActiveStatus { get; set; }
        public bool? ActiveStatusOriginalValue { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime? EffectiveDateOriginalValue { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool ExpiryDateEnabled { get; set; } = false;
        public bool? ExpiryDateEnabledOriginalValue { get; set; }
        public string SalesRegion { get; set; }
        public Guid SalesRegionId { get; set; }
        public string SalesSubRegion { get; set; }
        public Guid SalesSubRegionId { get; set; }
    }

    public class ProductSupplierRelationshipAvailableList
    {
        [Column("Supplier Id")]
        public Guid SupplierId { get; set; }
        [Column("Supplier Name")]
        public string SupplierName { get; set; } = string.Empty;
        [Column("Payment Currency Id")]
        public Guid PaymentCurrencyId { get; set; }
        [Column("Payment Currency Code")]
        public string PaymentCurrencyCode { get; set; } = string.Empty;
    }

    public class ProductSupplierRelationshipChosenList
    {
        public bool ActiveStatus { get; set; }
        public bool? ActiveStatusOriginalValue { get; set; }
        public byte DeliveryLeadTimeDays { get; set; }
        public byte? DeliveryLeadTimeDaysOriginalValue { get; set; }
        public string PaymentCurrencyCode { get; set; } = string.Empty;
        public Guid PaymentCurrencyId { get; set; }
        public Guid SupplierId { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public string SupplierProductCode { get; set; } = string.Empty;
        public decimal? WholesalePricePerCarton { get; set; }
        public decimal? WholesalePricePerCartonOriginalValue { get; set; }
        public decimal? WholesalePricePerPallet { get; set; }
        public decimal? WholesalePricePerPalletOriginalValue { get; set; }
        public decimal? WholesalePricePerUnit { get; set; }
        public decimal? WholesalePricePerUnitOriginalValue { get; set; }
    }

    public class WholesalePriceCalculationResult
    {
        public bool Success { get; set; } = false;
        public decimal PricePerUnit { get; set; } = 0;
        public decimal? CartonPrice { get; set; } = null;
        public ProductSupplierRelationshipChosenList? Supplier { get; set; } = null;
    }
}