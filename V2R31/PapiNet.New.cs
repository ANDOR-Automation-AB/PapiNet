namespace PapiNet.New;

public class DeliveryMessageWood
{
    public DeliveryMessageType DeliveryMessageType { get; set; } = DeliveryMessageType.DeliveryMessage;
    public DeliveryMessageStatusType DeliveryMessageStatusType { get; set; } = DeliveryMessageStatusType.Original;
    public DeliveryMessageContextType DeliveryMessageContextType { get; set; } = DeliveryMessageContextType.Unset;
    public YesNo Reissued { get; set; } = YesNo.Unset;
    public Language Language { get; set; } = Language.Unset;
    public DeliveryMessageWoodHeader DeliveryMessageWoodHeader { get; set; } = new();
    public List<DeliveryMessageShipment> DeliveryMessageShipment { get; } = [];
    public DeliveryMessageWoodSummary? DeliveryMessageWoodSummary { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class DeliveryMessageWoodSummary
{
    public TotalNumberOfShipments TotalNumberOfShipments { get; set; } = new();
    public TotalQuantity TotalQuantity { get; set; } = new();
    public List<TotalInformationalQuantity> TotalInformationalQuantity { get; } = [];
    public ProductSummary? ProductSummary { get; set; } = null;
    public LengthSpecification? LengthSpecification { get; set; } = null;
    public QuantityDeviation? QuantityDeviation { get; set; } = null;
    public CustomsTotals? CustomsTotals { get; set; } = null;
    public List<CustomsStampInformation> CustomsStampInformation { get; } = [];
    public List<TermsAndDisclaimers> TermsAndDisclaimers { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class TermsAndDisclaimers
{
    public Language Language { get; set; } = Language.Unset;
    public string Value { get; set; } = string.Empty;
}

public class CustomsStampInformation
{
    public List<CustomsStampHeaderText> CustomsStampHeaderText { get; } = [];
    public CustomsParty? CustomsParty { get; set; } = null;
    public CustomsStampDate? CustomsStampDate { get; set; } = null;
    public CustomsReferenceNumber? CustomsReferenceNumber { get; set; } = null;
    public SupplierCustomsReference? SupplierCustomsReference { get; set; } = null;
    public MillParty? MillParty { get; set; } = null;
    public CustomsStampTrailerText? CustomsStampTrailerText { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class CustomsStampTrailerText
{
    public string Value { get; set; } = string.Empty;
}

public class MillParty : Party
{

}

public class SupplierCustomsReference
{
    public ReferenceType SupplierCustomsReferenceType { get; set; } = ReferenceType.Other;
    public AssignedBy AssignedBy { get; set; } = AssignedBy.Other;
    public string Value { get; set; } = string.Empty;
}

public class CustomsReferenceNumber
{
    public CustomsReferenceNumberType CustomsReferenceNumberType { get; set; } = CustomsReferenceNumberType.Unset;
    public string Value { get; set; } = string.Empty;
}

public class CustomsStampDate : DateTimeBase
{

}

public class CustomsParty : Party
{

}

public class CustomsStampHeaderText
{
    public string Value { get; set; } = string.Empty;
}

public class CustomsTotals
{
    public CustomsTariffCode CustomsTariffCode { get; set; } = new();
    public TotalQuantity TotalQuantity { get; set; } = new();
    public List<InformationalQuantity> InformationalQuantity { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class CustomsTariffCode
{
    public string Value { get; set; } = string.Empty;
}

public class TotalNumberOfShipments
{
    public string Value { get; set; } = string.Empty;
}

public class DeliveryMessageDate
{
    public Date Date { get; set; } = new();

    public static implicit operator DateTime(DeliveryMessageDate deliveryMessageDate) => deliveryMessageDate.Date;

    public static implicit operator DeliveryMessageDate(DateTime date) => new DeliveryMessageDate { Date = date };
}

public class Date
{
    public string Year { get; set; } = string.Empty;
    public string Month { get; set; } = string.Empty;
    public string Day { get; set; } = string.Empty;

    public static implicit operator DateTime(Date date) => new DateTime(
        int.Parse(date.Year),
        int.Parse(date.Month),
        int.Parse(date.Day));

    public static implicit operator Date(DateTime dateTime) => new Date
    {
        Day = $"{dateTime.Day:00}",
        Month = $"{dateTime.Month:00}",
        Year = $"{dateTime.Year}"
    };
}

public class Time
{
    public string Value { get; set; } = string.Empty;
}

public class DeliveryMessageShipment
{
    public ShipmentID? ShipmentID { get; set; } = null;
    public List<DeliveryMessageProductGroup> DeliveryMessageProductGroup { get; } = [];
    public ShipmentSummary? ShipmentSummary { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class ShipmentID
{
    public ShipmentIDType ShipmentIDType { get; set; } = ShipmentIDType.Unset;
    public string Value { get; set; } = string.Empty;
}

public class ShipmentSummary
{
    public TotalQuantity? TotalQuantity { get; set; } = null;
    public List<TotalInformationalQuantity> TotalInformationalQuantity { get; } = [];
    public ProductSummary? ProductSummary { get; set; } = null;
    public List<LengthSpecification> LengthSpecification { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class DeliveryMessageProductGroup
{
    public ProductGroupID? ProductGroupID { get; set; } = null;
    public List<DeliveryShipmentLineItem> DeliveryShipmentLineItem { get; } = [];
    public ProductGroupSummary? ProductGroupSummary { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class ProductGroupID
{
    public ProductGroupIDType ProductGroupIDType { get; set; } = ProductGroupIDType.Unset;
    public string Value { get; set; } = string.Empty;
}

public class ProductGroupSummary
{
    public TotalQuantity? TotalQuantity { get; set; } = null;
    public List<TotalInformationalQuantity> TotalInformationalQuantity { get; } = [];
    public ProductSummary? ProductSummary { get; set; } = null;
    public List<LengthSpecification> LengthSpecification { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class DeliveryShipmentLineItem
{
    public DeliveryShipmentLineItemNumber DeliveryShipmentLineItemNumber { get; set; } = new();
    public PurchaseOrderInformation PurchaseOrderInformation { get; set; } = new();
    public PurchaseOrderLineItemNumber? PurchaseOrderLineItemNumber { get; set; } = null;
    public List<DeliveryMessageReference> DeliveryMessageReference { get; } = [];
    public List<DocumentReferenceInformation> DocumentReferenceInformation { get; } = [];
    public CountryOfOrigin? CountryOfOrigin { get; set; } = null;
    public CountryOfDestination? CountryOfDestination { get; set; } = null;
    public CountryOfConsumption? CountryOfConsumption { get; set; } = null;
    public TotalNumberOfUnits? TotalNumberOfUnits { get; set; } = null;
    public List<DeliveryDateWindow> DeliveryDateWindow { get; } = [];
    public MillProductionInformation? MillProductionInformation { get; set; } = null;
    public QuantityOrderedInformation? QuantityOrderedInformation { get; set; } = null;
    public List<TransportLoadingCharacteristics> TransportLoadingCharacteristics { get; } = [];
    public TransportUnloadingCharacteristics? TransportUnloadingCharacteristics { get; set; } = null;
    public List<TransportOtherInstructions> TransportOtherInstructions { get; } = [];
    public List<SafetyAndEnvironmentalInformation> SafetyAndEnvironmentalInformation { get; } = [];
    public BillToParty? BillToParty { get; set; } = null;
    public Product? Product { get; set; } = null;
    public PackageInformation? PackageInformation { get; set; } = null;
    public List<TransportPackageInformation> TransportPackageInformation { get; set; } = [];
    public ProductSummary? ProductSummary { get; set; } = null;
    public List<LengthSpecification> LengthSpecification { get; } = [];
    public QuantityDeviation? QuantityDeviation { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class PurchaseOrderLineItemNumber
{
    public string Value { get; set; } = string.Empty;
}

public class DeliveryShipmentLineItemNumber
{
    public string Value { get; set; } = string.Empty;
}

public class QuantityDeviation : MeasurementBase
{

}

public class TransportPackageInformation
{
    public PackageType PackageType { get; set; } = PackageType.Unset;
    public YesNo MixedProductPalletIndicator { get; set; } = YesNo.Unset;
    public PackageLevel? PackageLevel { get; set; } = null;
    public Identifier? Identifier { get; set; } = null;
    public List<RawMaterialSet> RawMaterialSet { get; } = [];
    public List<PartyIdentifier> PartyIdentifier { get; } = [];
    public MachineID? MachineID { get; set; } = null;
    public ItemCount? ItemCount { get; set; } = null;
    public Quantity? Quantity { get; set; } = null;
    public List<InformationalQuantity> InformationalQuantity { get; } = [];
    public InventoryClass? InventoryClass { get; set; } = null;
    public TransportVehicleCharacteristics? TransportVehicleCharacteristics { get; set; } = null;
    public TransportUnitCharacteristics? TransportUnitCharacteristics { get; set; } = null;
    public PackageCharacteristics? PackageCharacteristics { get; set; } = null;
    public BaleItem? BaleItem { get; set; } = null;
    public BoxItem? BoxItem { get; set; } = null;
    public ReelItem? ReelItem { get; set; } = null;
    public ReamItem? ReamItem { get; set; } = null;
    public SheetItem? SheetItem { get; set; } = null;
    public UnitItem? UnitItem { get; set; } = null;
    public WoodItem? WoodItem { get; set; } = null;
    public List<OtherDate> OtherDate { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class PackageInformation
{
    public PackageType PackageType { get; set; } = PackageType.Unset;
    public YesNo MixedProductPalletIndicator { get; set; } = YesNo.Unset;
    public PackageLevel? PackageLevel { get; set; } = null;
    public Identifier? Identifier { get; set; } = null;
    public List<SupplierMarks> SupplierMarks { get; } = [];
    public List<RawMaterialSet> RawMaterialSet { get; } = [];
    public List<PartyIdentifier> PartyIdentifier { get; } = [];
    public MachineID? MachineID { get; set; } = null;
    public ItemCount? ItemCount { get; set; } = null;
    public Quantity? Quantity { get; set; } = null;
    public List<InformationalQuantity> InformationalQuantity { get; } = [];
    public InventoryClass? InventoryClass { get; set; } = null;
    public PackageCharacteristics? PackageCharacteristics { get; set; } = null;
    public BaleItem? BaleItem { get; set; } = null;
    public BoxItem? BoxItem { get; set; } = null;
    public ReelItem? ReelItem { get; set; } = null;
    public ReamItem? ReamItem { get; set; } = null;
    public SheetItem? SheetItem { get; set; } = null;
    public UnitItem? UnitItem { get; set; } = null;
    public WoodItem? WoodItem { get; set; } = null;
    public List<OtherDate> OtherDate { get; } = [];
    public e_Attachment? e_Attachment { get; set; } = null;
    public List<AdditionalText> AdditionalText { get; } = [];
    public PackageReference? PackageReference { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class PackageLevel
{
    public string Value { get; set; } = string.Empty;
}

public class PackageReference
{
    public ReferenceType PackageReferenceType { get; set; } = ReferenceType.Other;
    public AssignedBy AssignedBy { get; set; } = AssignedBy.Other;
    public string Value { get; set; } = string.Empty;
}

public class AdditionalText
{
    public string Value { get; set; } = string.Empty;
}

public class OtherDate
{
    public DateType DateType = DateType.Other;
    public Date Date { get; set; } = new();
    public Time? Time { get; set; } = null;
    public Week? Week { get; set; } = null;
    public DateTimeRange? DateTimeRange { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class Week
{
    public string Value { get; set; } = string.Empty;
}

public class WoodItem
{
    public Product? Product { get; set; } = null;
    public PackagingInformation? PackagingInformation { get; set; } = null;
    public ProductSummary? ProductSummary { get; set; } = null;
    public List<LengthSpecification> LengthSpecification { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class LengthSpecification
{
    public LengthCategory? LengthCategory { get; set; } = null;
    public TotalNumberOfUnits? TotalNumberOfUnits { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class LengthCategory : ValueBase
{

}

public class ProductSummary
{
    public TotalQuantity? TotalQuantity { get; set; } = null;
    public List<TotalInformationalQuantity> TotalInformationalQuantity { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class TotalInformationalQuantity : MeasurementBase
{

}

public class TotalQuantity : MeasurementBase
{

}

public class PackagingInformation
{
    public QuantityInUnit? QuantityInUnit { get; set; } = null;
    public UnitDimension? UnitDimension { get; set; } = null;
    public Weight? Weight { get; set; } = null;
    public PackageIDInformation? PackageIDInformation { get; set; } = null;
    public List<LabelCharacteristics> LabelCharacteristics { get; } = [];
    public List<StencilCharacteristics> StencilCharacteristics { get; } = [];
    public List<BandCharacteristics> BandCharacteristics { get; } = [];
    public List<PalletCharacteristics> PalletCharacteristics { get; } = [];
    public List<Wrap> Wrap { get; } = [];
    public List<string> AdditionalText { get; } = [];
    public PackageType PackageType { get; set; } = PackageType.Unset;
    public string Value { get; set; } = string.Empty;
}

public class UnitItem
{

}

public class SheetItem
{

}

public class ReamItem
{

}

public class ReelItem
{

}

public class BoxItem
{
}

public class BaleItem
{

}

public class PackageCharacteristics
{
    public Height? Height { get; set; } = null;
    public Width? Width { get; set; } = null;
    public Length? Length { get; set; } = null;
    public LengthCutDescription? LengthCutDescription { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class InventoryClass
{
    public InventoryStatusType InventoryStatusType { get; set; } = InventoryStatusType.Unset;
    public OwnedBy InventoryOwnedBy { get; set; } = OwnedBy.Unset;
    public InventoryClassCode InventoryClassCode { get; set; } = new();
    public List<InventoryClassDescription> InventoryClassDescription { get; } = [];
    public List<string> AdditionalText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class InventoryClassDescription
{
    public string Value { get; set; } = string.Empty;
}

public class InventoryClassCode
{
    public Agency Agency { get; set; } = Agency.Other;
    public string InventoryClassLevel { get; set; } = "1";
    public string Value { get; set; } = string.Empty;
}

public class ItemCount : MeasurementBase
{
    public ItemCount() : base() { }
}

public class MachineID
{
    public string Value { get; set; } = string.Empty;
}

public class RawMaterialSet
{
    public IdentifierCodeType IdentifierCodeType { get; set; }
    public IdentifierType IdentifierType { get; set; }
    public IdentifierFormatType IdentifierFormatType { get; set; } = IdentifierFormatType.Unset;
    public string Value { get; set; } = string.Empty;
}

public class SupplierMarks
{
    public string Value { get; set; } = string.Empty;
}

public class Identifier
{
    public IdentifierCodeType IdentifierCodeType { get; set; } = IdentifierCodeType.Supplier;
    public IdentifierType IdentifierType { get; set; } = IdentifierType.Primary;
    public IdentifierFormatType IdentifierFormatType { get; set; } = IdentifierFormatType.Unset;
    public string Value { get; set; } = string.Empty;
}

public class Product
{
    public ProductIdentifier ProductIdentifier { get; set; } = new();
    public List<ProductDescription> ProductDescription { get; } = [];
    public List<Classification> Classification { get; } = [];
    public BookManufacturing? BookManufacturing { get; set; } = null;
    public LabelStock? LabelStock { get; set; } = null;
    public Paper? Paper { get; set; } = null;
    public Pulp? Pulp { get; set; } = null;
    public RecoveredPaper? RecoveredPaper { get; set; } = null;
    public VirginFibre? VirginFibre { get; set; } = null;
    public WoodProducts? WoodProducts { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class VirginFibre
{

}

public class RecoveredPaper
{

}

public class Pulp
{

}

public class LabelStock
{

}

public class WoodProducts
{
    public WoodTimbersDimensionalLumberBoards? WoodTimbersDimensionalLumberBoards { get; set; } = null;
    public RoofingSidingDeckingFencing? RoofingSidingDeckingFencing { get; set; } = null;
    public CompositeAndVeneerWoodPanels? CompositeAndVeneerWoodPanels { get; set; } = null;
    public ConstructionPackagesAndPreFabPanels? ConstructionPackagesAndPreFabPanels { get; set; } = null;
    public Millwork? Millwork { get; set; } = null;
    public Gypsum? Gypsum { get; set; } = null;
    public List<ProofInformationalQuantity> ProofInformationalQuantity { get; } = [];
    public List<SuppliedComponentInformation> SuppliedComponentInformation { get; } = [];
    public List<SafetyAndEnvironmentalInformation> SafetyAndEnvironmentalInformation { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class Gypsum
{

}

public class Millwork
{

}

public class ConstructionPackagesAndPreFabPanels
{

}

public class CompositeAndVeneerWoodPanels
{
    public SoftwoodPlywood? SoftwoodPlywood { get; set; } = null;
    public WoodPanelProducts? WoodPanelProducts { get; set; } = null;
    public Packaging? Packaging { get; set; } = null;
}

public class WoodPanelProducts
{

}

public class SoftwoodPlywood
{
    public PlywoodOSBGrade PlywoodOSBGrade { get; set; } = new();
    public Thickness Thickness { get; set; } = new();
    public Width Width { get; set; } = new();
    public Length Length { get; set; } = new();
    public PlywoodOSBSpecies PlywoodOSBSpecies { get; set; } = PlywoodOSBSpecies.Unset;
    public string? PlyNumber { get; set; } = null;
    public Surface? Surface { get; set; } = null;
    public Overlay? Overlay { get; set; } = null;
    public GlueExposure GlueExposure { get; set; } = GlueExposure.Unset;
    public Edge? Edge { get; set; } = null;
    public PressureTreatment? PressureTreatment { get; set; } = null;
    public FireTreatment? FireTreatment { get; set; } = null;
    public List<Supplemental> Supplemental { get; } = [];
    public string? Brand { get; set; } = null;
    public GradeAgency GradeAgency { get; set; } = GradeAgency.Unset;
    public GradeStamp? GradeStamp { get; set; } = null;
    public ClassIdentifier? ClassIdentifier { get; set; } = null;
    public List<LabelCharacteristics> LabelCharacteristics { get; } = [];
    public List<StencilCharacteristics> StencilCharacteristics { get; } = [];
    public List<SafetyAndEnvironmentalInformation> SafetyAndEnvironmentalInformation { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class Supplemental
{
    public SupplementalSpecification SupplementalSpecification { get; set; } = SupplementalSpecification.Unset;
    public List<string> AdditionalText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class Edge
{
    public EdgeTypePlywood EdgeType { get; set; } = EdgeTypePlywood.Unset;
    public EdgeLocation EdgeLocation { get; set; } = EdgeLocation.Unset;
    public string? EdgeMachiningProfile { get; set; } = null;
    public List<string> AdditionalText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class Overlay
{
    public OverlaySide OverlaySide { get; set; } = OverlaySide.Unset;
    public List<string> AdditionalText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class Surface
{
    public SurfaceType SurfaceType { get; set; } = SurfaceType.Unset;
    public List<string> AdditionalText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class PlywoodOSBGrade
{
    public Face Face { get; set; } = Face.Unset;
    public SpanRating SpanRating { get; set; } = SpanRating.Unset;
    public StrengthGroup StrengthGroup { get; set; } = StrengthGroup.Unset;
    public string Value { get; set; } = string.Empty;
}

public class RoofingSidingDeckingFencing
{
    public NaturalWoodSiding? NaturalWoodSiding { get; set; } = null;
    public NaturalWoodSidingOther? NaturalWoodSidingOther { get; set; } = null;
    public DeckAndPorchFlooringMaterialsNaturalWood? DeckAndPorchFlooringMaterialsNaturalWood { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class DeckAndPorchFlooringMaterialsNaturalWood
{
    public DeckAndPorchFlooringMaterialsNaturalWoodCharacteristics DeckAndPorchFlooringMaterialsNaturalWoodCharacteristics { get; set; } = new();
    public Packaging? Packaging { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class DeckAndPorchFlooringMaterialsNaturalWoodCharacteristics : SoftwoodLumberCharacteristicsBase
{

}

public class NaturalWoodSidingOther
{
    public NaturalWoodSidingOtherCharacteristics NaturalWoodSidingOtherCharacteristics { get; set; } = new();
    public Packaging? Packaging { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class NaturalWoodSidingOtherCharacteristics : SoftwoodLumberCharacteristicsBase
{

}

public class NaturalWoodSiding
{
    public NaturalWoodSidingCharacteristics NaturalWoodSidingCharacteristics { get; set; } = new();
    public Packaging? Packaging { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public abstract class SoftwoodLumberCharacteristicsBase
{
    public LumberSpecies LumberSpecies { get; set; } = new();
    public LumberGrade LumberGrade { get; set; } = new();
    public Length? Length { get; set; } = null;
    public Width? Width { get; set; } = null;
    public Thickness? Thickness { get; set; } = null;
    public Seasoning? Seasoning { get; set; } = null;
    public MoistureContent? MoistureContent { get; set; } = null;
    public HeatTreatment? HeatTreatment { get; set; } = null;
    public List<ManufacturingProcess> ManufacturingProcess { get; } = [];
    public PatternProfile? PatternProfile { get; set; } = null;
    public Trim? Trim { get; set; } = null;
    public Joining? Joining { get; set; } = null;
    public PressureTreatment? PressureTreatment { get; set; } = null;
    public FireTreatment? FireTreatment { get; set; } = null;
    public OtherTreatment? OtherTreatment { get; set; } = null;
    public GradeStamp? GradeStamp { get; set; } = null;
    public ExLog? ExLog { get; set; } = null;
    public ClassIdentifier? ClassIdentifier { get; set; } = null;
    public Weight? Weight { get; set; } = null;
    public LabelCharacteristics? LabelCharacteristics { get; set; } = null;
    public StencilCharacteristics? StencilCharacteristics { get; set; } = null;
    public Wrap? Wrap { get; set; } = null;
    public List<SafetyAndEnvironmentalInformation> SafetyAndEnvironmentalInformation { get; } = [];
    public List<string> AdditionalText { get; } = [];
    public LengthCutDescription? LengthCutDescription { get; set; } = null;
    public string? ShippingMark { get; set; } = null;
    public string Value { get; set; } = string.Empty;
    
}

public class NaturalWoodSidingCharacteristics : SoftwoodLumberCharacteristicsBase
{

}

public class WoodTimbersDimensionalLumberBoards
{
    public SoftwoodLumber? SoftwoodLumber { get; set; } = null;
    public HardwoodLumber? HardwoodLumber { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class HardwoodLumber
{
    public HardwoodLumberCharacteristics HardwoodLumberCharacteristics { get; set; } = new();
    public Packaging? Packaging { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class HardwoodLumberCharacteristics
{
    public List<AnyType> AnyType { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class AnyType
{
    public string LocalName { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}

public class SoftwoodLumber
{
    public SoftwoodLumberCharacteristics SoftwoodLumberCharacteristics { get; set; } = new();
    public Packaging? Packaging { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class Packaging
{
    public ProductPackaging ProductPackaging { get; set; } = new();
    public string Value { get; set; } = string.Empty;
}

public class ProductPackaging
{
    public QuantityInUnit? QuantityInUnit { get; set; } = null;
    public UnitDimension? UnitDimension { get; set; } = null;
    public Weight? Weight { get; set; } = null;
    public PackageIDInformation? PackageIDInformation { get; set; } = null;
    public List<LabelCharacteristics> LabelCharacteristics { get; } = [];
    public List<StencilCharacteristics> StencilCharacteristics { get; } = [];
    public List<BandCharacteristics> BandCharacteristics { get; } = [];
    public List<PalletCharacteristics> PalletCharacteristics { get; } = [];
    public List<Wrap> Wrap { get; } = [];
    public List<string> AdditionalText { get; } = [];
    public PackageType PackageType { get; set; } = PackageType.Unset;
    public string Value { get; set; } = string.Empty;
}

public class PalletCharacteristics
{
    public YesNo MixedProductPalletIndicator { get; set; } = YesNo.Unset;
    public PalletType PalletType { get; set; } = PalletType.Unset;
    public PalletLedgeType PalletLedgeType { get; set; } = PalletLedgeType.Unset;
    public PalletCoverType PalletCoverType { get; set; } = PalletCoverType.Unset;
    public PalletAdditionsType PalletAdditionsType { get; set; } = PalletAdditionsType.Unset;
    public PalletTopType PalletTopType { get; set; } = PalletTopType.Unset;
    public YesNo IsPartialPalletsAllowed { get; set; } = YesNo.Unset;
    public ProductIdentification? ProductIdentification { get; set; } = null;
    public PalletLength? PalletLength { get; set; } = null;
    public PalletWidth? PalletWidth { get; set; } = null;
    public string? ItemsPerPallet { get; set; } = null;
    public string? StacksPerPallet { get; set; } = null;
    public string? TiersPerPallet { get; set; } = null;
    public MaximumHeight? MaximumHeight { get; set; } = null;
    public string? StackingMethod { get; set; } = null;
    public LabelCharacteristics? LabelCharacteristics { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class MaximumHeight : Height
{

}

public class PalletWidth : Width
{

}

public class PalletLength : Length
{

}

public class ProductIdentification
{
    public ProductIdentifier ProductIdentifier { get; set; } = new();
    public List<string> ProductDescription { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class BandCharacteristics
{
    public BandType BandType { get; set; } = BandType.Unset;
    public YesNo BandsRequired { get; set; } = YesNo.Unset;
    public string? NumberOfBands { get; set; } = null;
    public string? BandColour { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class PackageIDInformation
{
    public PackageAgency PackageAgency { get; set; } = PackageAgency.Unset;
    public string? PackageCode { get; set; } = null;
    public string? PackageName { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class UnitDimension
{
    public Length? Length { get; set; } = null;
    public Width? Width { get; set; } = null;
    public Height? Height { get; set; } = null;
    public string? PiecesPerRow { get; set; } = null;
    public string? RowsPerUnit { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class QuantityInUnit : MeasurementBase
{

}

public class SoftwoodLumberCharacteristics
{
    public LumberSpecies LumberSpecies { get; set; } = new();
    public LumberGrade LumberGrade { get; set; } = new();
    public Length? Length { get; set; } = null;
    public Width? Width { get; set; } = null;
    public Thickness? Thickness { get; set; } = null;
    public Seasoning? Seasoning { get; set; } = null;
    public MoistureContent? MoistureContent { get; set; } = null;
    public HeatTreatment? HeatTreatment { get; set; } = null;
    public ManufacturingProcess? ManufacturingProcess { get; set; } = null;
    public PatternProfile? PatternProfile { get; set; } = null;
    public Trim? Trim { get; set; } = null;
    public Joining? Joining { get; set; } = null;
    public PressureTreatment? PressureTreatment { get; set; } = null;
    public FireTreatment? FireTreatment { get; set; } = null;
    public OtherTreatment? OtherTreatment { get; set; } = null;
    public GradeStamp? GradeStamp { get; set; } = null;
    public ExLog? ExLog { get; set; } = null;
    public List<ClassIdentifier> ClassIdentifier { get; } = [];
    public Weight? Weight { get; set; } = null;
    public LabelCharacteristics? LabelCharacteristics { get; set; } = null;
    public StencilCharacteristics? StencilCharacteristics { get; set; } = null;
    public Wrap? Wrap { get; set; } = null;
    public List<SafetyAndEnvironmentalInformation> SafetyAndEnvironmentalInformation { get; } = [];
    public List<string> AdditionalText { get; } = [];
    public LengthCutDescription? LengthCutDescription { get; set; } = null;
    public string? ShippingMark { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class LengthCutDescription
{
    public LengthCutType LengthCutType { get; set; } = LengthCutType.Unset;
    public string Value { get; set; } = string.Empty;
}

public class Wrap
{
    public WrapType WrapType { get; set; } = WrapType.Unset;
    public WrapProperties WrapProperties { get; set; } = WrapProperties.Unset;
    public WrapLocation WrapLocation { get; set; } = WrapLocation.Unset;
    public string? NumberOfWraps { get; set; } = null;
    public string? Brand { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class StencilCharacteristics
{
    public StencilType StencilType { get; set; } = StencilType.Unset;
    public StencilInkType StencilInkType { get; set; } = StencilInkType.Unset;
    public StencilLocation StencilLocation { get; set; } = StencilLocation.Unset;
    public StencilFormat StencilFormat { get; set; } = StencilFormat.Unset;
    public StencilContent StencilContent { get; set; } = StencilContent.Unset;
    public AssignedBy AssignedBy { get; set; } = AssignedBy.Unset;
    public List<string> StencilText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class LabelCharacteristics
{
    public List<string> CustomerMarks { get; } = [];
    public string? LabelStyle { get; set; } = null;
    public string? LabelBrandName { get; set; } = null;
    public string? LabelPosition { get; set; } = null;
    public string? NumberOfLabels { get; set; } = null;
    public Length? Length { get; set; } = null;
    public Width? Width { get; set; } = null;
    public string? ColourCode { get; set; } = null;
    public string? ColourDescription { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class Weight : MeasurementBase
{

}

public class ClassIdentifier
{
    public IdentifierCodeType IdentifierCodeType { get; set; } = IdentifierCodeType.Supplier;
    public IdentifierType IdentifierType { get; set; } = IdentifierType.Primary;
    public IdentifierFormatType IdentifierFormatType { get; set; } = IdentifierFormatType.Unset;
    public string Value { get; set; } = string.Empty;
}

public class ExLog
{
    public Value Value { get; set; } = new();
}

public class GradeStamp
{
    public GradeStamped GradeStamped { get; set; } = GradeStamped.Unset;
    public string? GradeStampMillNumber { get; set; } = null;
    public GradeStampLocation GradeStampLocation { get; set; } = GradeStampLocation.Unset;
    public string Value { get; set; } = string.Empty;
}

public class OtherTreatment
{
    public List<string> AdditionalText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class FireTreatment
{
    public FireTreatmentType FireTreatmentType { get; set; } = FireTreatmentType.Unset;
    public List<string> AdditionalText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class PressureTreatment
{
    public PressureTreatmentCompound PressureTreatmentCompound { get; set; } = new();
    public PressureTreatmentConcentration PressureTreatmentConcentration { get; set; } = new();
    public PressureTreatmentComStdorUseCategory PressureTreatmentComStdorUseCategory { get; set; } = PressureTreatmentComStdorUseCategory.Unset;
    public string Value { get; set; } = string.Empty;
}

public class PressureTreatmentConcentration
{
    public UOM UOM { get; set; } = UOM.Unset;
    public string Value { get; set; } = string.Empty;
}

public class PressureTreatmentCompound
{
    public string? CompoundType { get; set; } = null;
    public string? CompoundAgency { get; set; } = null;
    public Value? Value { get; set; } = null;
    public List<string> AdditionalText { get; } = [];
}

public class Joining
{
    public JoiningType JoiningType { get; set; } = JoiningType.Unset;
    public List<string> AdditionalText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class Trim
{
    public TrimType TrimType { get; set; } = TrimType.Unset;
    public List<string> AdditionalText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class PatternProfile
{
    public PatternProfileType PatternProfileType { get; set; } = PatternProfileType.Unset;
    public PatternProfileAgency PatternProfileAgency { get; set; } = PatternProfileAgency.Unset;
    public string? PatternProfileCode { get; set; } = null;
    public List<string> AdditionalText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class ManufacturingProcess
{
    public ManufacturingProcessType ManufacturingProcessType { get; set; } = ManufacturingProcessType.Unset;
    public ManufacturingProcessAgency ManufacturingProcessAgency { get; set; } = ManufacturingProcessAgency.Unset;
    public Value? Value { get; set; } = null;
    public List<string> AdditionalText { get; } = [];
}

public class HeatTreatment
{
    public HeatTreatmentType HeatTreatmentType { get; set; } = HeatTreatmentType.Unset;
    public List<string> AdditionalText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class MoistureContent
{
    public MoistureContentPercentage MoistureContentPercentage { get; set; } = MoistureContentPercentage.Unset;
    public List<string> AdditionalText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class Seasoning
{
    public SeasoningType SeasoningType { get; set; } = SeasoningType.Unset;
    public List<string> AdditionalText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class Thickness : MeasurementBase
{

}

public class LumberGrade
{
    public GradeType GradeType { get; set; } = GradeType.Unset;
    public GradingRule GradingRule { get; set; } = GradingRule.Unset;
    public LumberAgency GradeAgency { get; set; } = LumberAgency.Unset;
    public ModulusElasticity ModulusElasticity { get; set; } = ModulusElasticity.Unset;
    public Face Face { get; set; } = Face.Unset;
    public string? GradeName { get; set; } = null;
    public string? GradeCode { get; set; } = null;
    public List<string> AdditionalText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class LumberSpecies
{
    public SpeciesType SpeciesType { get; set; } = SpeciesType.Unset;
    public SpeciesOrigin SpeciesOrigin { get; set; } = SpeciesOrigin.Unset;
    public SpeciesAgency SpeciesAgency { get; set; } = SpeciesAgency.Unset;
    public string? SpeciesCode { get; set; } = null;
    public List<string> AdditionalText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class BookManufacturing
{
    public List<BookClassification> BookClassification { get; } = [];
    public List<ProofInformationalQuantity> ProofInformationalQuantity { get; } = [];
    public List<PrepInformation> PrepInformation { get; } = [];
    public List<SuppliedComponentInformation> SuppliedComponentInformation { get; } = [];
}

public class SuppliedComponentInformation
{
    public SupplierParty SupplierParty { get; set; } = new();
    public ProductIdentifier ProductIdentifier { get; set; } = new();
    public List<ProductDescription> ProductDescription { get; } = [];
    public List<Classification> Classification { get; } = [];
    public List<BookClassification> BookClassification { get; } = [];
    public Paper? Paper { get; set; } = null;
    public SuppliedComponentReference? SuppliedComponentReference { get; set; } = null;
    public Quantity? Quantity { get; set; } = null;
    public ComponentShipDate? ComponentShipDate { get; set; } = null;
    public ComponentDueDate? ComponentDueDate { get; set; } = null;
    public ComponentNeededDate? ComponentNeededDate { get; set; } = null;
    public OrderStatusInformation? OrderStatusInformation { get; set; } = null;
    public List<string> AdditionalText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class OrderStatusInformation
{
    public string OrderPrimaryStatus = string.Empty;
    public string? OrderSecondaryStatus { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class ComponentNeededDate : DateTimeBase
{
    public ComponentNeededDate() : base() { }
}

public class ComponentDueDate : DateTimeBase
{

}

public class ComponentShipDate : DateTimeBase
{

}

public class SuppliedComponentReference
{
    public ReferenceType SuppliedComponentReferenceType { get; set; } = ReferenceType.Unset;
    public AssignedBy AssignedBy { get; set; } = AssignedBy.Unset;
    public string Value { get; set; } = string.Empty;
}

public class Paper
{
    public PaperCharacteristics? PaperCharacteristics { get; set; } = null;
}

public class PaperCharacteristics
{
    public CoatingTop? CoatingTop { get; set; } = null;
    public CoatingBottom? CoatingBottom { get; set; } = null;
    public FinishType? FinishType { get; set; } = null;
    public PrintType? PrintType { get; set; } = null;
    public List<Abrasion> Abrasion { get; } = [];
    public List<AbsorptionInk> AbsorptionInk { get; } = [];
    public List<AbsorptionWater> AbsorptionWater { get; } = [];
    public List<Appearance> Appearance { get; } = [];
    public List<Ash> Ash { get; } = [];
    public List<BasisWeight> BasisWeight { get; } = [];
    public List<BendingResistance> BendingResistance { get; } = [];
    public List<BendingStiffness> BendingStiffness { get; } = [];
    public List<Brightness> Brightness { get; } = [];
    public List<Bulk> Bulk { get; } = [];
    public List<Burst> Burst { get; } = [];

}

public class Burst : DetailMeasurementBase
{

}

public class Bulk : DetailMeasurementBase
{

}

public class Brightness : DetailMeasurementBase
{

}

public class BendingStiffness : DetailMeasurementBase
{

}

public class BendingResistance : DetailMeasurementBase
{

}

public class BasisWeight : DetailMeasurementBase
{

}

public class Ash : DetailMeasurementBase
{

}

public class Appearance : DetailMeasurementBase
{

}

public class AbsorptionWater : DetailMeasurementBase
{

}

public class AbsorptionInk : DetailMeasurementBase
{

}

public class Abrasion : DetailMeasurementBase
{

}

public abstract class DetailMeasurementBase
{
    public TestMethod TestMethod { get; set; } = TestMethod.Unset;
    public TestAgency TestAgency { get; set; } = TestAgency.Unset;
    public SampleType SampleType { get; set; } = SampleType.Unset;
    public ResultSource ResultSource { get; set; } = ResultSource.Unset;
    public DetailValue DetailValue { get; set; } = new();
    public DetailRangeMin? DetailRangeMin { get; set; } = null;
    public DetailRangeMax? DetailRangeMax { get; set; } = null;
    public StandardDeviation? StandardDeviation { get; set; } = null;
    public SampleSize? SampleSize { get; set; } = null;
    public TwoSigmaLower? TwoSigmaLower { get; set; } = null;
    public TwoSigmaUpper? TwoSigmaUpper { get; set; } = null;
    public IncrementalValue? IncrementalValue { get; set; } = null;
    public string Value { get; set; } = string.Empty;
    
}

public class IncrementalValue : ValueBase
{

}

public class TwoSigmaUpper : ValueBase
{

}

public class TwoSigmaLower : ValueBase
{

}

public class SampleSize
{
    public string Value { get; set; } = string.Empty;
}

public class StandardDeviation : ValueBase
{

}

public class DetailRangeMax : ValueBase
{

}

public class DetailRangeMin : ValueBase
{

}

public class DetailValue : ValueBase
{

}

public class ProductDescription
{
    public Language Language { get; set; } = Language.Unset;
    public string Value { get; set; } = string.Empty;
}

public class ProductIdentifier
{
    public Agency Agency { get; set; } = Agency.Other;
    public ProductIdentifierType ProductIdentifierType { get; set; } = ProductIdentifierType.Other;
    public string Value { get; set; } = string.Empty;
}

public class PrepInformation
{
    public PrepType PrepType { get; set; } = PrepType.Unset;
    public SupplierParty SupplierParty { get; set; } = new();
    public PrepShipDate? PrepShipDate { get; set; } = null;
    public PrepDueDate? PrepDueDate { get; set; } = null;
    public PrepNeededDate? PrepNeededDate { get; set; } = null;
    public List<string> AdditionalText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class PrepNeededDate : DateTimeBase
{

}

public class PrepDueDate : DateTimeBase
{

}

public class PrepShipDate : DateTimeBase
{

}

public abstract class DateTimeBase
{
    public Date Date { get; set; } = new();
    public Time? Time { get; set; } = null;
    public string Value { get; set; } = string.Empty;
    
}

public class ProofInformationalQuantity
{
    public ProofType ProofType { get; set; } = ProofType.Unset;
    public Quantity Quantity { get; set; } = new();
    public List<InformationalQuantity> InformationalQuantity { get; } = [];
    public OtherParty? OtherParty { get; set; } = null;
    public ProofApprovalDate? ProofApprovalDate { get; set; } = null;
    public ProofDueDate? ProofDueDate { get; set; } = null;
    public List<string> AdditionalText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class ProofDueDate : DateTimeBase
{

}

public class ProofApprovalDate : DateTimeBase
{

}

public class BookClassification
{
    public BookClassificationType BookClassificationType { get; set; } = BookClassificationType.Assembly;
    public List<string> ClassificationDescription { get; } = [];
    public List<BookSubClassification> BookSubClassification { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class BookSubClassification
{
    public BookSubClassificationType BookSubClassificationType;
    public List<string> ClassificationDescription { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class Classification
{
    public string ClassificationCode = string.Empty;
    public string? ClassificationDescription = string.Empty;
    public string Value { get; set; } = string.Empty;
}

public class SafetyAndEnvironmentalInformation
{
    public SafetyAndEnvironmentalType SafetyAndEnvironmentalType { get; set; } = SafetyAndEnvironmentalType.MaterialSafetyData;
    public Agency Agency { get; set; } = Agency.Other;
    public string? LicenceNumber { get; set; } = null;
    public string? ChainOfCustody { get; set; } = null;
    public SafetyAndEnvironmentalCertification? SafetyAndEnvironmentalCertification { get; set; } = null;
    public List<string> AdditionalText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class SafetyAndEnvironmentalCertification : MeasurementBase
{

}

public class TransportLoadingCharacteristics
{
    public MixProductIndicator? MixProductIndicator { get; set; } = null;
    public TransportLoadingType? TransportLoadingType { get; set; } = null;
    public TransportDeckOption? TransportDeckOption { get; set; } = null;
    public LoadingTolerance? LoadingTolerance { get; set; } = null;
    public DirectLoading? DirectLoading { get; set; } = null;
    public GoodsLoadingPrinciple? GoodsLoadingPrinciple { get; set; } = null;
    public LabelOrientation? LabelOrientation { get; set; } = null;
    public string? TransportLoadingCode { get; set; } = null;
    public TransportLoadingCodeDescription? TransportLoadingCodeDescription { get; set; } = null;
    public List<string> TransportLoadingText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class TransportLoadingCodeDescription
{
    public List<string> AdditionalText { get; } = [];
    public e_Attachment? e_Attachment { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class QuantityOrderedInformation
{
    public Quantity Quantity { get; set; } = new();
    public List<InformationalQuantity> InformationalQuantity { get; } = [];
    public List<string> AdditionalText { get; } = [];
    public List<Length> Length { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class MillProductionInformation
{
    public MillCharacteristics? MillCharacteristics { get; set; } = null;
    public string? MillOrderNumber { get; set; } = null;
    public Quantity? Quantity { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class MillCharacteristics
{
    public MillParty? MillParty { get; set; } = null;
    public string? MachineID { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public abstract class MeasurementBase
{
    public ActualNominal ActualNominal { get; set; } = ActualNominal.Unset;
    public WithGrain WithGrain { get; set; } = WithGrain.Unset;
    public Value Value { get; set; } = new();
    public RangeMin? RangeMin { get; set; } = null;
    public RangeMax? RangeMax { get; set; } = null;
    public List<string> AdditionalText { get; } = [];
    
}

public class TotalNumberOfUnits : MeasurementBase
{

}

public class PurchaseOrderInformation
{
    public string? PurchaseOrderNumber { get; set; } = null;
    public string? PurchaseOrderReleaseNumber { get; set; } = null;
    public PurchaseOrderIssuedDate? PurchaseOrderIssuedDate { get; set; } = null;
    public List<PurchaseOrderReference> PurchaseOrderReference { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class PurchaseOrderReference : AssignedByReferenceValueBase
{
    public ReferenceType PurchaseOrderReferenceType { get; set; } = ReferenceType.Other;
}

public class PurchaseOrderIssuedDate : DateTimeBase
{

}

public class DeliveryMessageWoodHeader
{
    public string DeliveryMessageNumber { get; set; } = string.Empty;
    public string? TransactionHistoryNumber { get; set; } = null;
    public DeliveryMessageDate DeliveryMessageDate { get; set; } = new();
    public List<DeliveryMessageReference> DeliveryMessageReference { get; } = [];
    public List<DocumentReferenceInformation> DocumentReferenceInformation { get; } = [];
    public BuyerParty BuyerParty { get; set; } = new();
    public BillToParty? BillToParty { get; set; } = new();
    public SupplierParty SupplierParty { get; set; } = new();
    public List<OtherParty> OtherParty { get; } = [];
    public SenderParty? SenderParty { get; set; } = new();
    public List<ReceiverParty> ReceiverParty { get; } = [];
    public List<ShipToInformation> ShipToInformation { get; } = [];
    public CountryOfOrigin? CountryOfOrigin { get; set; } = null;
    public CountryOfDestination? CountryOfDestination { get; set; } = null;
    public CountryOfConsumption? CountryOfConsumption { get; set; } = null;
    public Insurance? Insurance { get; set; } = null;
    public List<string> AdditionalText { get; } = [];
    public List<DocumentInformation> DocumentInformation { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class ReceiverParty : Party
{

}

public class SenderParty : Party
{

}

public class SupplierParty : Party
{

}

public class BillToParty : Party
{

}

public class BuyerParty : Party
{

}

public class DocumentInformation
{
    public DocumentType DocumentType = DocumentType.DeliveryNote;
    public List<string> NumberOfDocuments { get; } = [];
    public List<string> AdditionalText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class Insurance
{
    public string? Insurer { get; set; } = null;
    public string? InsuranceContractNo { get; set; } = null;
    public InsuredValue? InsuredValue { get; set; } = null;
    public string? InsuranceInfo { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class InsuredValue
{
    public string CurrencyValue = string.Empty;
    public string Value { get; set; } = string.Empty;
}

public class CountryOfConsumption
{
    public string Country = string.Empty;
    public ISOCountryCode ISOCountryCode { get; set; } = ISOCountryCode.Unset;
    public string Value { get; set; } = string.Empty;
}

public class CountryOfDestination
{
    public string Country = string.Empty;
    public ISOCountryCode ISOCountryCode { get; set; } = ISOCountryCode.Unset;
    public string Value { get; set; } = string.Empty;
}

public class CountryOfOrigin
{
    public string Country = string.Empty;
    public ISOCountryCode ISOCountryCode { get; set; } = ISOCountryCode.Unset;
    public string Value { get; set; } = string.Empty;
}

public class ShipToInformation
{
    public ShipToCharacteristics ShipToCharacteristics { get; set; } = new();
    public List<DeliverySchedule> DeliverySchedule { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class DeliverySchedule
{
    public string DeliveryLineNumber = string.Empty;
    public ProductionStatus? ProductionStatus { get; set; } = null;
    public DeliveryStatus? DeliveryStatus { get; set; } = null;
    public List<DeliveryDateWindow> DeliveryDateWindow { get; } = [];
    public Quantity Quantity { get; set; } = new();
    public List<InformationalQuantity> InformationalQuantity { get; } = [];
    public PriceDetails? PriceDetails { get; set; } = null;
    public List<MonetaryAdjustment> MonetaryAdjustment { get; } = [];
    public List<DeliveryLeg> DeliveryLeg { get; } = [];
    public List<DeliveryScheduleReference> DeliveryScheduleReference { get; } = [];
    public List<string> AdditionalText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class DeliveryScheduleReference : AssignedByReferenceValueBase
{
    public ReferenceType DeliveryScheduleReferenceType { get; set; } = ReferenceType.Other;
}

public class DeliveryLeg
{
    public DeliveryModeType DeliveryModeType { get; set; } = DeliveryModeType.Unset;
    public DeliveryLegType DeliveryLegType { get; set; } = DeliveryLegType.Unset;
    public EventType EventType { get; set; } = EventType.Unset;
    public LegStageType LegStageType { get; set; } = LegStageType.Unset;
    public string DeliveryLegSequenceNumber = string.Empty;
    public DeliveryOrigin DeliveryOrigin { get; set; } = new();
    public CarrierParty? CarrierParty { get; set; } = new();
    public List<OtherParty> OtherParty { get; } = [];
    public TransportModeCharacteristics? TransportModeCharacteristics { get; set; } = null;
    public TransportVehicleCharacteristics? TransportVehicleCharacteristics { get; set; } = null;
    public TransportUnitCharacteristics? TransportUnitCharacteristics { get; set; } = null;
    public TransportUnloadingCharacteristics? TransportUnloadingCharacteristics { get; set; } = null;
    public TransportOtherInstructions? TransportOtherInstructions { get; set; } = null;
    public List<Route> Route { get; } = [];
    public DeliveryTransitTime? DeliveryTransitTime { get; set; } = null;
    public DeliveryDestination? DeliveryDestination { get; set; } = null;
    public List<DeliveryDateWindow> DeliveryDateWindow { get; } = [];
    public List<DeliveryLegReference> DeliveryLegReference { get; } = [];
    public List<TermsOfChartering> TermsOfChartering { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class CarrierParty : Party
{

}

public class TermsOfChartering
{
    public TermsOfCharteringType TermsOfCharteringType { get; set; } = TermsOfCharteringType.Unset;
    public string Value { get; set; } = string.Empty;
}

public class DeliveryLegReference
{
    public ReferenceType DeliveryLegReferenceType { get; set; } = ReferenceType.Other;
    public AssignedBy AssignedBy { get; set; } = AssignedBy.Unset;
    public string Value { get; set; } = string.Empty;
}

public class DeliveryDestination
{
    public Date? Date { get; set; } = null;
    public Time? Time { get; set; } = null;
    public LocationParty LocationParty { get; set; } = new();
    public SupplyPoint? SupplyPoint { get; set; } = null;
    public LocationCode? LocationCode { get; set; } = null;
    public GPSCoordinates? GPSCoordinates { get; set; } = null;
    public MapCoordinates? MapCoordinates { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class DeliveryTransitTime
{
    public string Days { get; set; } = string.Empty;
    public string? Hours { get; set; } = null;
    public string? Minutes { get; set; } = null;
}

public class Route
{
    public RouteType RouteType { get; set; } = RouteType.DeliveryOriginToDeliveryDestination;
    public string RouteName { get; set; } = string.Empty;
    public List<string> RouteComment { get; } = [];
    public List<SupplyPoint> SupplyPoint { get; } = [];
    public List<MapPoint> MapPoint { get; } = [];
    public string? RouteLength { get; set; } = null;
    public string? RouteDefinition { get; set; } = null;
    public eAttachment? eAttachment { get; set; } = null;
    public List<RouteLeg> RouteLeg { get; } = [];
    public string RootValue { get; set; } = string.Empty;
}

public class RouteLeg
{
    public string RouteLegNumber = string.Empty;
    public string? RouteLegName { get; set; } = null;
    public List<OtherParty> OtherParty { get; } = [];
    public MapPoint? MapPoint { get; set; } = null;
    public RouteLegLength? RouteLegLength { get; set; } = null;
    public RoadCharacteristics? RoadCharacteristics { get; set; } = null;
    public eAttachment? eAttachment { get; set; } = null;
    public List<string> AdditionalText { get; } = [];
}

public class OtherParty : Party
{

}

public class RoadCharacteristics
{
    public RoadOwnerType RoadOwnerType { get; set; } = RoadOwnerType.Unset;
    public RoadKeeperType RoadKeeperType { get; set; } = RoadKeeperType.Unset;
    public RoadAccessibilityType RoadAccessibilityType { get; set; } = RoadAccessibilityType.Unset;
    public RoadTurningPossibilityType RoadTurningPossibilityType { get; set; } = RoadTurningPossibilityType.Unset;
    public RoadTurningPointType RoadTurningPointType { get; set; } = RoadTurningPointType.Unset;
    public RoadPassingPossibility RoadPassingPossibility { get; set; } = RoadPassingPossibility.Unset;
    public string? RoadName { get; set; } = null;
    public string? RoadNumber { get; set; } = null;
    public List<RoadClassification> RoadClassification { get; } = [];
    public List<RoadAvailability> RoadAvailability { get; } = [];
    public List<RoadBearingCapacity> RoadBearingCapacity { get; } = [];
    public List<RoadObstruction> RoadObstruction { get; } = [];
}

public class RoadObstruction
{
    public RoadObstructionType RoadObstructionType = RoadObstructionType.Passage;
    public string? MapPointName { get; set; } = null;
    public List<string> MapPointComment { get; } = [];
    public List<MapCoordinates> MapCoordinates { get; } = [];
    public string? RoadSlopePercent { get; set; } = null;
    public List<RoadBearingCapacity> RoadBearingCapacity { get; } = [];
    public Length? Length { get; set; } = null;
    public Width? Width { get; set; } = null;
    public Height? Height { get; set; } = null;
    public eAttachment? eAttachment { get; set; } = null;
    public List<string> AdditionalText { get; } = [];
}

public class Height : MeasurementBase
{

}

public class Width : MeasurementBase
{

}

public class Length : MeasurementBase
{

}

public class RoadBearingCapacity
{
    public RoadBearingCapacityType RoadBearingCapacityType { get; set; } = RoadBearingCapacityType.Unset;
    public Value Value { get; set; } = new();
    public RangeMin? RangeMin { get; set; } = null;
    public RangeMax? RangeMax { get; set; } = null;
}

public class RoadClassification
{
    public string? RoadClassificationCode { get; set; } = null;
    public List<string> RoadClassificationDescription { get; } = [];
    public string RootValue { get; set; } = string.Empty;
}

public class RouteLegLength : MeasurementBase
{

}

public class eAttachment
{
    public string? AttachmentFileName { get; set; } = null;
    public string? NumberOfAttachments { get; set; } = null;
    public List<URL> URL { get; } = [];
    public string RootValue { get; set; } = string.Empty;
}

public class MapPoint
{
    public MapPointType MapPointType { get; set; } = MapPointType.Unset;
    public string MapPointName { get; set; } = string.Empty;
    public List<string> MapPointComment { get; } = [];
    public List<MapCoordinates> MapCoordinates { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class TransportOtherInstructions
{
    public TransportInstructionType TransportInstructionType { get; set; } = TransportInstructionType.Unset;
    public TransportInstructionCode? TransportInstructionCode { get; set; } = null;
    public List<string> TransportInstructionText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class TransportInstructionCode : AgencyValueBase
{
    public new Agency Agency { get; set; } = Agency.Other;
}

public class TransportUnloadingCharacteristics
{
    public TransportUnloadingType TransportUnloadingType { get; set; } = TransportUnloadingType.Unset;
    public DirectUnloading DirectUnloading { get; set; } = DirectUnloading.Unset;
    public TransportUnloadingCode? TransportUnloadingCode { get; set; } = null;
    public TransportUnloadingCodeDescription? TransportUnloadingCodeDescription { get; set; } = null;
    public List<string> TransportUnloadingText { get; } = [];
    public string Value { get; set; } = string.Empty;
}

public class TransportUnloadingCodeDescription
{
    public List<string> AdditionalText { get; } = [];
    public e_Attachment? e_Attachment { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class e_Attachment
{
    public string? AttachmentFileName { get; set; } = null;
    public string? NumberOfAttachments { get; set; } = null;
    public URL? URL { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class URL
{
    public string? URLContext { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class TransportUnloadingCode : AgencyValueBase
{
    public new Agency Agency { get; set; } = Agency.Other;
}

public class TransportUnitCharacteristics
{
    public TransportUnitType TransportUnitType { get; set; } = TransportUnitType.Other;
    public TransportUnitVariable TransportUnitVariable { get; set; } = TransportUnitVariable.Unset;
    public string? TransportUnitLevel { get; set; } = null;
    public TransportUnitCode? TransportUnitCode { get; set; } = null;
    public TransportUnitMeasurements? TransportUnitMeasurements { get; set; } = null;
    public List<TransportUnitEquipment> TransportUnitEquipment { get; } = [];
    public string? TransportUnitCount { get; set; } = null;
    public List<TransportUnitIdentifier> TransportUnitIdentifier { get; } = [];
    public string? TransportUnitText { get; set; } = null;
    public TransportUnitDetail? TransportUnitDetail { get; set; } = null;
}

public class TransportUnitDetail
{
    public TransportUnitDetailType TransportUnitDetailType { get; set; } = TransportUnitDetailType.Unset;
    public LoadOpeningSide LoadOpeningSide { get; set; } = LoadOpeningSide.Unset;
    public TransportUnitDetailCode? TransportUnitDetailCode { get; set; } = null;
    public List<string> AdditionalText { get; } = [];
}

public class TransportUnitDetailCode : AgencyValueBase
{
    public new Agency Agency { get; set; } = Agency.Other;
}

public class TransportUnitIdentifier
{
    public TransportUnitIdentifierType TransportUnitIdentifierType { get; set; } = TransportUnitIdentifierType.Other;
    public string? StateOrProvince { get; set; } = null;
    public ISOCountryCode ISOCountryCode { get; set; } = ISOCountryCode.Unset;
    public string Value { get; set; } = string.Empty;
}

public class TransportUnitEquipment
{
    public TransportUnitEquipmentCode? TransportUnitEquipmentCode { get; set; } = null;
    public List<TransportUnitEquipmentDescription> TransportUnitEquipmentDescription { get; } = [];
}

public class TransportUnitEquipmentDescription
{
    public Language Language { get; set; } = Language.Unset;
    public string Value { get; set; } = string.Empty;
}

public class TransportUnitEquipmentCode : AgencyValueBase
{
    public new Agency Agency { get; set; } = Agency.Other;
}

public class TransportUnitMeasurements
{
    public AppliesTo AppliesTo { get; set; } = AppliesTo.Unset;
    public TransportUnitLength? TransportUnitLength { get; set; } = null;
    public TransportUnitWidth? TransportUnitWidth { get; set; } = null;
    public TransportUnitHeight? TransportUnitHeight { get; set; } = null;
    public TransportUnitWeight? TransportUnitWeight { get; set; } = null;
}

public class TransportUnitWeight : MeasurementBase
{

}

public class TransportUnitHeight : MeasurementBase
{

}

public class TransportUnitWidth : MeasurementBase
{

}

public class TransportUnitLength : MeasurementBase
{

}

public class TransportUnitCode : AgencyValueBase
{

}

public class TransportVehicleCharacteristics
{
    public TransportVehicleType TransportVehicleType { get; set; } = TransportVehicleType.Unset;
    public TransportVehicleCode? TransportVehicleCode { get; set; } = null;
    public TransportVehicleMeasurements? TransportVehicleMeasurements { get; set; } = null;
    public List<TransportVehicleEquipment> TransportVehicleEquipment { get; } = [];
    public string? TransportVehicleCount { get; set; } = null;
    public TransportVehicleIdentifier? TransportVehicleIdentifier { get; set; } = null;
    public string? TransportVehicleText { get; set; } = null;
}

public class TransportVehicleIdentifier
{
    public TransportVehicleIdentifierType TransportVehicleIdentifierType { get; set; } = TransportVehicleIdentifierType.Unset;
    public string? StateOrProvince { get; set; } = null;
    public ISOCountryCode ISOCountryCode { get; set; } = ISOCountryCode.Unset;
    public string Value { get; set; } = string.Empty;
}

public class TransportVehicleEquipment
{
    public TransportVehicleEquipmentCode? TransportVehicleEquipmentCode { get; set; } = null;
    public List<TransportVehicleEquipmentDescription> TransportVehicleEquipmentDescription { get; } = [];
}

public class TransportVehicleEquipmentDescription
{
    public Language Language { get; set; } = Language.Unset;
    public string Value { get; set; } = string.Empty;
}

public class TransportVehicleEquipmentCode : AgencyValueBase
{
    public new Agency Agency { get; set; } = Agency.Other;
}

public class TransportVehicleMeasurements
{
    public TransportVehicleLength? TransportVehicleLength { get; set; } = null;
    public TransportVehicleWidth? TransportVehicleWidth { get; set; } = null;
    public TransportVehicleHeight? TransportVehicleHeight { get; set; } = null;
    public TransportVehicleWeight? TransportVehicleWeight { get; set; } = null;
}

public class TransportVehicleWeight : MeasurementBase
{

}

public class TransportVehicleHeight : MeasurementBase
{

}

public class TransportVehicleWidth : MeasurementBase
{

}

public class TransportVehicleLength : MeasurementBase
{

}

public class TransportVehicleCode : AgencyValueBase
{
    public new Agency Agency { get; set; } = Agency.Other;
}

public class TransportModeCharacteristics
{
    public TransportModeType TransportModeType { get; set; } = TransportModeType.Unset;
    public TransportModeCode? TransportModeCode { get; set; } = null;
    public string? TransportModeText { get; set; } = null;
}

public class TransportModeCode : AgencyValueBase
{
    public new Agency Agency { get; set; } = Agency.Other;
}

public class DeliveryOrigin
{
    public Date? Date { get; set; } = null;
    public Time? Time { get; set; } = null;
    public LocationParty LocationParty { get; set; } = new();
    public SupplyPoint? SupplyPoint { get; set; } = null;
    public LocationCode? LocationCode { get; set; } = null;
    public GPSCoordinates? GPSCoordinates { get; set; } = null;
    public MapCoordinates? MapCoordinates { get; set; } = null;
}

public class LocationParty : Party
{

}

public class SupplyPoint
{
    public LocationType LocationType = LocationType.Destination;
    public SupplyPointCode SupplyPointCode { get; set; } = new();
    public List<string> SupplyPointDescription { get; } = [];
    public List<MapCoordinates> MapCoordinates { get; } = [];
}

public class SupplyPointCode : AgencyValueBase
{
    public new Agency Agency { get; set; } = Agency.Other;
}

public class PriceDetails
{
    public PriceQuantityBasis PriceQuantityBasis { get; set; } = PriceQuantityBasis.ActualVolume;
    public PriceTaxBasis PriceTaxBasis { get; set; } = PriceTaxBasis.Unset;
    public PricePerUnit PricePerUnit { get; set; } = new();
    public List<InformationalPricePerUnit> InformationalPricePerUnit { get; } = [];
    public List<string> AdditionalText { get; } = [];
    public ExchangeRate ExchangeRate { get; set; } = new();
    public MonetaryAdjustment? MonetaryAdjustment { get; set; } = null;
    public GeneralLedgerAccount? GeneralLedgerAccount { get; set; } = null;
}

public class MonetaryAdjustment
{
    public AdjustmentType_Financial AdjustmentType { get; set; } = AdjustmentType_Financial.Other;
    public string MonetaryAdjustmentLine { get; set; } = string.Empty;
    public MonetaryAdjustmentStartAmount? MonetaryAdjustmentStartAmount { get; set; } = null;
    public MonetaryAdjustmentStartQuantity? MonetaryAdjustmentStartQuantity { get; set; } = null;
    public PriceAdjustment? PriceAdjustment { get; set; } = null;
    public FlatAmountAdjustment? FlatAmountAdjustment { get; set; } = null;
    public TaxAdjustment? TaxAdjustment { get; set; } = null;
    public InformationalAmount? InformationalAmount { get; set; } = null;
    public string? MonetaryAdjustmentReferenceLine { get; set; } = null;
    public List<string> AdditionalText { get; } = [];
    public GeneralLedgerAccount? GeneralLedgerAccount { get; set; } = null;
    public MonetaryAdjustmentAmount? MonetaryAdjustmentAmount { get; set; } = null;
    public string? AdjustmentTypeReason { get; set; } = null;
}

public class MonetaryAdjustmentAmount
{
    public CurrencyValue CurrencyValue { get; set; } = new();
}

public class GeneralLedgerAccount : AgencyValueBase
{

}

public class TaxAdjustment
{
    public TaxCategoryType TaxCategoryType { get; set; } = TaxCategoryType.Unset;
    public TaxType TaxType { get; set; } = TaxType.VAT;
    public string? TaxPercent { get; set; } = null;
    public TaxAmount? TaxAmount { get; set; } = null;
    public string TaxLocation { get; set; } = string.Empty;
    public List<InformationalAmount> InformationalAmount { get; } = [];
}

public class InformationalAmount
{
    public AmountType AmountType { get; set; } = AmountType.Unset;
    public CurrencyValue CurrencyValue { get; set; } = new();
    public ExchangeRate? ExchangeRate { get; set; } = null;
    public List<string> AdditionalText { get; } = [];
}

public class TaxAmount
{
    public CurrencyValue CurrencyValue { get; set; } = new();
}

public class FlatAmountAdjustment
{
    public AdjustmentPercentage? AdjustmentPercentage { get; set; } = null;
    public AdjustmentFixedAmount? AdjustmentFixedAmount { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class AdjustmentFixedAmount
{
    public CurrencyValue CurrencyValue { get; set; } = new();
    public string Value { get; set; } = string.Empty;
}

public class PriceAdjustment
{
    public AdjustmentPercentage? AdjustmentPercentage { get; set; } = null;
    public AdjustmentValue? AdjustmentValue { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class AdjustmentValue : MeasurementBase
{
    public CurrencyValue CurrencyValue { get; set; } = new();
}

public class AdjustmentPercentage : MeasurementBase
{

}

public class MonetaryAdjustmentStartQuantity : MeasurementBase
{

}

public class MonetaryAdjustmentStartAmount
{
    public CurrencyValue CurrencyValue { get; set; } = new();
    public string Value { get; set; } = string.Empty;
}

public class ExchangeRate
{
    public ExchangeRateType ExchangeRateType = ExchangeRateType.Fixed;
    public CurrencyFromType CurrencyFromType { get; set; } = CurrencyFromType.Unset;
    public CurrencyValue? CurrencyValue { get; set; } = null;
    public MinCurrencyValue MinCurrencyValue { get; set; } = new();
    public MaxCurrencyValue MaxCurrencyValue { get; set; } = new();
    public Date? Date { get; set; } = null;
}

public class MaxCurrencyValue : CurrencyValueBase
{

}

public class MinCurrencyValue : CurrencyValueBase
{

}

public abstract class CurrencyValueBase
{
    public CurrencyType CurrencyType { get; set; } = CurrencyType.Unset;
    public string Value { get; set; } = string.Empty;    
}

public class InformationalPricePerUnit : MeasurementBase
{
    public InformationalPricePerUnitType InformationalPricePerUnitType = InformationalPricePerUnitType.ProductPrice;
    public CurrencyValue CurrencyValue { get; set; } = new();
}

public class PricePerUnit : MeasurementBase
{
    public CurrencyValue CurrencyValue { get; set; } = new();
}

public class CurrencyValue
{
    public string CurrencyType { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}

public class InformationalQuantity : Quantity
{

}

public class Quantity
{
    public QuantityType QuantityType = QuantityType.ActualVolume;
    public QuantityTypeContext QuantityTypeContext { get; set; } = QuantityTypeContext.Unset;
    public AdjustmentType_Tare AdjustmentType { get; set; } = AdjustmentType_Tare.Unset;
    public MeasuringAgency MeasuringAgency { get; set; } = MeasuringAgency.Unset;
    public string? MeasuringMethod { get; set; } = null;
    public Value Value { get; set; } = new();
    public RangeMin? RangeMin { get; set; } = null;
    public RangeMax? RangeMax { get; set; } = null;
}

public class RangeMin : ValueBase
{

}

public class RangeMax : ValueBase
{

}

public class Value : ValueBase
{

}

public abstract class ValueBase
{
    public UOM UOM { get; set; } = UOM.Unit;
    public string Value { get; set; } = string.Empty;    
}

public class DeliveryDateWindow
{
    public DeliveryDateType DeliveryDateType { get; set; } = DeliveryDateType.ActualArrivalDate;
    public DateTimeRange? DateTimeRange { get; set; } = null;
    public string? Month { get; set; } = null;
    public string? Week { get; set; } = null;
    public Date Date { get; set; } = new();
    public Time? Time { get; set; } = null;
}

public class DateTimeRange
{
    public DateTimeFrom DateTimeFrom { get; set; } = new();
    public DateTimeTo DateTimeTo { get; set; } = new();
}

public class DateTimeTo
{
    public Date Date { get; set; } = new();
    public Time? Time { get; set; } = null;
}

public class DateTimeFrom
{
    public Date Date { get; set; } = new();
    public Time? Time { get; set; } = null;
}

public class DeliveryStatus
{
    public DeliveryStatusType DeliveryStatusType { get; set; } = DeliveryStatusType.Unset;
    public DeliveryLastDateOfChange? DeliveryLastDateOfChange { get; set; } = null;
}

public class DeliveryLastDateOfChange
{
    public Date Date { get; set; } = new();
    public Time? Time { get; set; } = null;
}

public class ProductionStatus
{
    public ProductionStatusType ProductionStatusType = ProductionStatusType.Free;
    public ProductionLastDateOfChange? ProductionLastDateOfChange { get; set; } = null;
}

public class ProductionLastDateOfChange
{
    public Date Date { get; set; } = new();
    public Time? Time { get; set; } = null;
}

public class ShipToCharacteristics
{
    public ShipToParty ShipToParty { get; set; } = new();
    public LocationCode? LocationCode { get; set; } = null;
    public TermsOfDelivery? TermsOfDelivery { get; set; } = null;
    public DeliveryRouteCode? DeliveryRouteCode { get; set; } = null;
}

public class ShipToParty : Party
{

}

public class LocationCode : AgencyValueBase
{
    public new Agency Agency { get; set; } = Agency.Other;
}

public class DeliveryRouteCode : AgencyValueBase
{
    public new Agency Agency { get; set; } = Agency.Other;
}

public class TermsOfDelivery
{
    public IncotermsLocation? IncotermsLocation { get; set; } = null;
    public ShipmentMethodOfPayment? ShipmentMethodOfPayment { get; set; } = null;
    public string? FreightPayableAt { get; set; } = null;
    public string? AdditionalText { get; set; } = null;
}

public class ShipmentMethodOfPayment
{
    public LocationQualifier LocationQualifier { get; set; } = LocationQualifier.Unset;
    public Method? Method { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public class IncotermsLocation
{
    public Incoterms Incoterms = Incoterms.Other;
    public string? IncotermsVersion { get; set; } = null;
    public string Value { get; set; } = string.Empty;
}

public abstract class Party
{
    public PartyType PartyType { get; set; } = PartyType.Unset;
    public LogisticsRole LogisticsRole { get; set; } = LogisticsRole.Unset;
    public List<PartyIdentifier> PartyIdentifier { get; } = [];
    public NameAddress NameAddress { get; set; } = new();
    public string? URL { get; set; } = null;
    public CommonContact? CommonContact { get; set; } = null;
    public string Value { get; set; } = string.Empty;
    
}

public class CommonContact
{
    public ContactType ContactType { get; set; } = ContactType.Other;
    public string ContactName { get; set; } = string.Empty;
    public string? ContactIdentifier { get; set; } = null;
    public string? Telephone { get; set; } = null;
    public string? MobilePhone { get; set; } = null;
    public string? Email { get; set; } = null;
    public string? Fax { get; set; } = null;
    public GPSCoordinates? GPSCoordinates { get; set; } = null;
    public MapCoordinates? MapCoordinates { get; set; } = null;
}

public class MapCoordinates
{
    public MapReferenceSystem MapReferenceSystem { get; set; } = MapReferenceSystem.NTF;
    public MapCoordinateType MapCoordinateType { get; set; } = MapCoordinateType.UTM;
    public string Coordinates { get; set; } = string.Empty;
    public string? Altitude { get; set; } = null;
}

public class NameAddress
{
    public CommunicationRole CommunicationRole { get; set; } = CommunicationRole.Unset;
    public string Name1 { get; set; } = string.Empty;
    public string? Name2 { get; set; } = null;
    public string? Name3 { get; set; } = null;
    public string? OrganisationUnit { get; set; } = null;
    public string? Address1 { get; set; } = null;
    public string? Address2 { get; set; } = null;
    public string? Address3 { get; set; } = null;
    public string? Address4 { get; set; } = null;
    public string? City { get; set; } = null;
    public string? County { get; set; } = null;
    public string? StateOrProvince { get; set; } = null;
    public string? PostalCode { get; set; } = null;
    public Country? Country { get; set; } = null;
    public GPSCoordinates? GPSCoordinates { get; set; } = null;
    public MapCoordinates? MapCoordinates { get; set; } = null;
}

public class Country
{
    public ISOCountryCode ISOCountryCode { get; set; } = ISOCountryCode.Unset;
    public string Value { get; set; } = string.Empty;
}

public class GPSCoordinates
{
    public GPSSystem GPSSystem { get; set; } = GPSSystem.Unset;
    public string Latitude { get; set; } = string.Empty;
    public string Longitude { get; set; } = string.Empty;
    public string? Height { get; set; } = null;
}

public class PartyIdentifier
{
    public PartyIdentifierType PartyIdentifierType { get; set; } = PartyIdentifierType.Other;
    public Agency Agency { get; set; } = Agency.Unset;
    public string Value { get; set; } = string.Empty;
}

public class DocumentReferenceInformation
{
    public string DocumentReferenceID { get; set; } = string.Empty;
    public string? DocumentReferenceIDLineItemNumber { get; set; } = null;
    public Date? Date { get; set; } = null;
    public Time? Time { get; set; } = null;
    public string? NumberOfDocumentsRequired { get; set; } = null;
}

public class DeliveryMessageReference
{
    public ReferenceType DeliveryMessageReferenceType { get; set; } = ReferenceType.Other;
    public AssignedBy AssignedBy { get; set; } = AssignedBy.Unset;
    public string Value { get; set; } = string.Empty;
}

public abstract class AgencyValueBase
{
    public Agency Agency { get; set; } = Agency.Unset;
    public string Value { get; set; } = string.Empty;
}

public abstract class AssignedByReferenceValueBase
{
    public AssignedBy AssignedBy { get; set; } = AssignedBy.Unset;
    public string Value { get; set; } = string.Empty;
}