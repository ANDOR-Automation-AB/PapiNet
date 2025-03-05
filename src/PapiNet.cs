using System.Linq;
using System.Xml.Linq;

namespace PapiNet;

public enum DeliveryMessageType
{
    DeliveryMessage,
    InitialShipmentAdvice,
    LoadingOrder,
    PackingSpecification,
    ShipmentAdvice,
}

public enum DeliveryMessageStatusType
{
    Cancelled,
    Original,
    Replaced,
}

public enum DeliveryMessageContextType
{
    Return,
}

// TODO: Add language from ISO 639-2
// https://www.loc.gov/standards/iso639-2/php/code_list.php
public enum Language
{

}

public enum LogisticsRole 
{
    Consignee,
    Consignor,
    LogisticsProvider,
}

public enum PartyIdentifierType
{
    ABINumber,
    ABNNumber,
    AFPA,
    AssignedByAgency,
    AssignedByBuyer,
    AssignedByReceiver,
    AssignedBySeller,
    AssignedBySender,
    BankIdentificationCode,
    BankgiroAccountNumber,
    CABNumber,
    ChamberOfCommerceRegistrationNumber,
    Domicile,
    DunsNumber,
    Duns4Number,
    EANNumber,
    GlobalLocationNumber,
    IBAN,
    ISO6523Number,
    papiNetGlobalPartyIdentifier,
    PatenteNumber,
    PayeeAccountNumber,
    PayeeInternalAccountNumber,
    PayeeFinancialInstitution,
    PayerAccountNumber,
    PayerFinancialInstitution,
    PlusgiroAccountNumber,
    RegisterOfCompaniesSubscriptionNumber,
    StandardAddressNumber,
    StandardCarrierAlphaCode,
    StockCapital,
    SWIFT,
    TaxIdentifier,
    TradeRegNumber,
    // UN/ECE,
    VATIdentificationNumber,
    Other,
}

public enum Agency
{
    AFPA,
    ANSI,
    APPITA,
    ATA,
    BISAC,
    Bowker,
    BSI,
    Buyer,
    Carrier,
    CCTI,
    CEN,
    CEPI,
    Customs,
    DUNS,
    EAN,
    // ECTA-EPCA-CEFIC,
    EndUser,
    FINFO,
    Forwarder,
    FSC,
    GCA,
    // GCA-CCTI,
    GOST,
    IFRA,
    Intrastat,
    ISO,
    ISRI,
    Mill,
    NOBB,
    NMFTA,
    NPTA,
    Ondule,
    PEFC,
    PMS,
    PPPC,
    Publisher,
    RASI,
    RevenueCanada,
    RVR,
    SD,
    SDC,
    Seller,
    Supplier,
    TAPPI,
    UCC,
    // UN/ECE,
    WarehouseOperator,
    WCO,
    XBITS,
    Other,
}

public enum CommunicationRole
{
    From,
    To,
    CC,
}

public enum ContactType
{
    AccountManager,
    Carrier,
    CrossDock,
    CustomerService,
    Forwarder,
    HelpDesk,
    Merchant,
    Mill,
    Plant,
    Purchaser,
    RemitTo,
    SalesOffice,
    TransportPlanner,
    TransportVehicle,
    Warehouse,
    Other,
}

public enum DeliveryMessageReferenceType
{
    AccountNumber,
    AudioVideoSelectionNumber,
    Author,
    BarCodedSerialNumber,
    BillAndHoldInvoiceNumber,
    BillOfLadingMark,
    BillOfLadingNumber,
    BindingStyleType,
    BookLanguage,
    BookingNumber,
    BudgetCenter,
    BuyerBudgetCenter,
    BuyerClaimNumber,
    BuyerDivisionIdentifier,
    BuyerImprint,
    BuyerJobNumber,
    BuyerRetailPrice,
    CallOffConfirmationLineItemNumber,
    CallOffConfirmationNumber,
    CallOffLineItemNumber,
    CallOffNumber,
    CallOffReferenceNumber,
    CatalogueReferenceNumber,
    CIMNumber,
    CMRNumber,
    CoLoadingNumber,
    ComplaintNumber,
    ComplaintLineItemNumber,
    ComplaintResponseNumber,
    ComplaintResponseLineItemNumber,
    ConsigneeOrderNumber,
    ContainerReference,
    ContentLanguage,
    ContractLineNumber,
    ContractNumber,
    ConvertingReportNumber,
    Copyright,
    CreditAuthorizationNumber,
    CreditDebitNoteNumber,
    CreditNoteNumber,
    CustomerBookingNumber,
    CustomerJobNumber,
    CustomerJobTitle,
    CustomerOrderNumber,
    CustomerReferenceNumber,
    CustomerSpecificationNumber,
    DebitNoteNumber,
    DeliveryBookingNumber,
    DeliveryInstructionNumber,
    DeliveryInstructionSequenceNumber,
    DeliveryInstructionSequenceLineNumber,
    DeliveryLocation,
    DeliveryMessageNumber,
    DeliveryMessageLineItemNumber,
    DeliveryNumber,
    DepartmentIdentifier,
    DespatchInformationNumber,
    DespatchInstructionNumber,
    DivisionIdentifier,
    DropOffNumber,
    Edition,
    EditionState,
    EditionSubject,
    EducationSubject,
    EndCallOffDate,
    FlightNumber,
    FormID,
    FormLowFolio,
    FormPages,
    FormType,
    ForwarderReference,
    FromPurchaseOrderNumber,
    FromSalesOrderNumber,
    FSCNumber,
    GeneralAgreement,
    GoodsInBillOfLadingNumber,
    GoodsInDeliveryNumber,
    GoodsInTransportUnitIdentifier,
    GoodsInTransportVehicleIdentifier,
    GoodsReceiptNumber,
    GoodsReceiptLineItemNumber,
    Imprint,
    IndentOrderNumber,
    InitialShipmentAdviceNumber,
    IntraStatNumber,
    InventoryChangeNumber,
    InventoryDispositionInstructionsNumber,
    InventoryDispositionInstructionsLineNumber,
    InvoiceNumber,
    ISBN10,
    ISBN10Dash,
    ISBN13,
    ISBN13Dash,
    ISODocumentReference,
    IssueEvent,
    JobNumber,
    JobTitle,
    LoadPlanNumber,
    LoadReleaseNumber,
    LoadTenderNumber,
    LoadTenderResponseNumber,
    LoadingInstructionNumber,
    LoadingInstructionSequenceNumber,
    LoadingInstructionSequenceLineNumber,
    LoadingOrderNumber,
    LoadingOrderLineNumber,
    LotIdentifier,
    MagazineCode,
    ManufacturerMaterialSafetyDataSheetNumber,
    MarketType,
    MarketplaceReferenceNumber,
    MasterBillOfLading,
    MasterContractNumber,
    MasterISBN10,
    MasterISBN13,
    MasterPurchaseOrder,
    MaterialSafetyDataSheetNumber,
    MeasuringInstructionNumber,
    MeasuringNumber,
    MeasuringTicketNumber,
    MeasuringTicketSequenceNumber,
    MeasuringTicketSequenceLineItemNumber,
    MillOrderLineItemNumber,
    MillOrderNumber,
    MillSalesOfficeNumber,
    NonconformanceReportNumber,
    OrderConfirmationNumber,
    OrderConfirmationLineItemNumber,
    OrderNumber,
    OrderLineItemNumber,
    OrderPartyReferenceNumber,
    OriginalComplaintResponseNumber,
    OriginalDeliveryNumber,
    OriginalGoodsReceiptNumber,
    OriginalInvoiceNumber,
    OriginalProductQualityMessageNumber,
    OriginalPurchaseOrderNumber,
    OriginalSalesOrderNumber,
    OriginalScaleTicketNumber,
    OriginalUsageNumber,
    PackageMark,
    PackageNumber,
    PackageSpecificationNumber,
    PackageSpecificationLineNumber,
    PageCount,
    PageCountTotal,
    PaymentReferenceNumber,
    PEFCNumber,
    PickUpNumber,
    PlanningMessageNumber,
    PopulationNumber,
    PriceContractNumber,
    PriceQuoteNumber,
    PriceList,
    PrintingCode,
    PrintingNumber,
    PriorPurchaseOrderNumber,
    ProductOriginIdentifier,
    ProFormaInvoiceNumber,
    ProNumber,
    ProfitCenter,
    ProgramID,
    PromotionNumber,
    PubName,
    PubNumber,
    PublisherReferenceNumber,
    PupilsTeachers,
    PurchaseOrderCorrelationID,
    PurchaseOrderNumber,
    PurchaseOrderLineItemCorrelationID,
    PurchaseOrderLineItemNumber,
    QualityReportNumber,
    RandomSampleNumber,
    ReferenceNumber,
    ReleaseNumber,
    RetailPrice,
    RFQLineItemNumber,
    RFQNumber,
    RunNumber,
    SalesOfficeNumber,
    SalesOrderLineItemNumber,
    SalesOrderNumber,
    ScaleTicketNumber,
    SchoolGrade,
    SchoolGradeLevel,
    SellersInvoiceNumber,
    ServiceNumber,
    ShippingInstructionsLineItemNumber,
    ShippingInstructionsNumber,
    SimplifiedCustomsNumber,
    SpecificationNumber,
    SpecificationReferenceNumber,
    SpecificationVersion,
    StockOrderLineItemNumber,
    StockOrderNumber,
    SupplierCallOffNumber,
    SupplierClaimNumber,
    SupplierJobNumber,
    SupplierReferenceNumber,
    SupplierVoyageNumber,
    T2L,
    TimeTableNumber,
    Title,
    TitleAlias,
    ToPurchaseOrderNumber,
    TrackingNumber,
    TransactionID,
    TransportUnitIdentifier,
    TransportVehicleIdentifier,
    UniversalProductIdentifier,
    UsageNumber,
    UsageLineItemNumber,
    VendorReferenceNumber,
    VesselShipNotice,
    VoucherNumber,
    VoyageNumber,
    WarehouseDeliveryNumber,
    WaybillIdentifier,
    Other,
}

public enum AssignedBy
{
    Bank,
    BillTo,
    BorderCrossing,
    Broker,
    Buyer,
    BuyerAgent,
    Carrier,
    CarrierAssignmentResponsible,
    ComponentVendor,
    Consignee,
    Consignor,
    Consuming,
    Converter,
    CreditDepartment,
    CrossDock,
    CustomerFacility,
    CustomerStock,
    Customs,
    CustomsForwarder,
    DomesticForwarder,
    EndUser,
    ExportForwarder,
    ForestForwarder,
    Forwarder,
    FreightPayer,
    Insurer,
    Landowner,
    LoadingOperator,
    LoggingArea,
    MainCarrier,
    Measurer,
    Merchant,
    Mill,
    NotifyParty,
    OnBehalfOf,
    OrderParty,
    OriginalSupplier,
    Payee,
    Payer,
    PlaceFinalDestination,
    PlaceOfAccept,
    PlaceOfDespatch,
    PlaceOfDischarge,
    PlaceOfLoading,
    PlaceOfReloading,
    Port,
    PreCarrier,
    PrinterFacility,
    ProFormaInvoice,
    Producer,
    RemitTo,
    Requestor,
    RoadKeeper,
    RoadOwner,
    SalesAgent,
    SalesOffice,
    Seller, 
    ShipFromLocation,
    ShipOwner,
    ShipTo,
    SubCarrier,
    Supplier,
    Terminal,
    TerminalOperator,
    UnloadingOperator,
    Warehouse,
    WillAdvise,
    Other,
}

public enum GPSSystem
{
    ECEF,
    HAE,
    MSL,
}

public enum MapCoordinateType
{
    // ETRS-TM35FIN,
    Lambert93,
    Lambert1,
    Lambert2,
    Lambert3,
    Lambert4,
    Lambert2Etendu,
    LatLong,
    // RT90_2.5GonV
    SWEREF99TM,
    UTM,
}

public enum MapReferenceSystem
{
    ETRS89,
    // EUREF-FIN,
    NTF,
    RGF93,
    RT90,
    SWEREF99,
    WGS84,
}

public enum PartyType
{
    Bank,
    BillTo,
    BorderCrossing,
    Broker,
    Buyer,
    BuyerAgent,
    Carrier,
    CarrierAssignmentResponsible,
    ComponentVendor,
    Consignee,
    Consignor,
    Consuming,
    Converter,
    CreditDepartment,
    CrossDock,
    CustomerFacility,
    CustomerStock,
    Customs,
    CustomsForwarder,
    DomesticForwarder,
    EndUser,
    ExportForwarder,
    ForestForwarder,
    Forwarder,
    FreightPayer,
    Insurer,
    Landowner,
    LoadingOperator,
    LoggingArea,
    MainCarrier,
    Measurer,
    Merchant,
    Mill,
    NotifyParty,
    OnBehalfOf,
    OrderParty,
    OriginalSupplier,
    Payee,
    Payer,
    PlaceFinalDestination,
    PlaceOfAccept,
    PlaceOfDespatch,
    PlaceOfDischarge,
    PlaceOfLoading,
    PlaceOfReloading,
    Port,
    PreCarrier,
    PrinterFacility,
    ProFormaInvoice,
    Producer,
    RemitTo,
    Requestor,
    RoadKeeper,
    RoadOwner,
    SalesAgent,
    SalesOffice,
    Seller,
    ShipFromLocation,
    ShipOwner,
    ShipTo,
    SubCarrier,
    Supplier,
    Terminal,
    TerminalOperator,
    UnloadingOperator,
    Warehouse,
    WillAdvise,
    Other,
}

public enum Incoterms
{
    CFR,
    CIF,
    CIP,
    CPT,
    DAF,
    DDP,
    DDU,
    DEQ,
    DES,
    EXW,
    FAS,
    FCA,
    FOB,
    Other,
}

public enum IncotermsVersion
{
    _1980,
    _1990,
    _2000,
    _20xx
}

public enum LocationQualifier
{
    Destination,
    DistributionCentre,
    Dock,
    Factory,
    Mill,
    OnVesselFOBPoint,
    Origin,
    OriginAfterLoadingOnEquipment,
    OriginShippingPoint,
    Plant,
    Port,
    Reload,
    Terminal,
    Warehouse,
}

public enum Method
{
    CollectFreight,
    CollectFreightAndAllowed,
    CollectFreightCreditedBackToCustomer,
    CustomerPickupBackhaul,
    Pickup,
    PrepaidButChargedToCustomer,
    PrepaidBySeller,
}

public enum ProductionStatusType
{
    Free,
    NotFree,
}

public enum DeliveryStatusType
{
    Cancelled,
    Free,
    NotFree,
}

public enum DeliveryDateType
{
    ActualArrivalDate,
    ActualDepartureDate,
    AvailableToShipDate,
    CancelAfterDate,
    DateOfLastChange,
    DateOfTrading,
    DeliveryRequestedDate,
    DoNotDeliverAfterDate,
    DoNotShipAfterDate,
    EndCallOffDate,
    EstimatedTimeOfArrival,
    EstimatedTimeOfDeparture,
    LastChangeDate,
    LoadingDate,
    PickUpDate,
    PlannedShipDate,
    ReferencePeriod,
    ShipmentPriorToDate,
    ShipmentRequestedDate,
    StartCallOffDate,
}

public enum QuantityType
{
    ActualVolume,
    AirDryWeight,
    Area,
    BoneDry,
    Count,
    GrossWeight,
    Energy,
    Length,
    LogPileVolume,
    NetWeight,
    NetNetWeight,
    NominalWeight,
    Percent,
    RunningLength,
    ShortLengthVolume,
    SolidWoodVolume,
    TareWeight,
    Time,
    TippedLooseVolume,
    Volume,
}

public enum QuantityTypeContext
{
    AgreedToClaimValue,
    Allocated,
    AllowableSpoilage,
    Balance,
    CalledOff,
    Consumed,
    Credited,
    CutOff,
    Damaged,
    Delivered,
    Destroyed,
    Deviation,
    Freight,
    Handled,
    Intransit,
    Invoiced,
    Loaded,
    OnHand,
    Ordered,
    Packed,
    Planned,
    Produced,
    Released,
    Reorder,
    ReorderPoint,
    Reserved,
    Scrapped,
    Stored,
    Trimmed,
    Unloaded,
    UnspecifiedDamage,
    ValueClaimed,
    VendorSupplied,
    Wound,
    Wrapped,
}

public enum AdjustmentType_Tare
{
    Advances,
    Core,
    Ends,
    Excess,
    IncludesOverage,
    None,
    Pallet,
    Samples,
    SchoolAdoption,
    Straps,
    Total,
    Wrap,
    WrapCore,
}

public enum MeasuringAgency
{
    Buyer,
    RVR,
    SD,
    SDC,
    Supplier,
}

public enum UOM
{
    AirDryMetricTonne,
    AirDryPercent,
    AirDryShortTon,
    Bale,
    BoardFoot,
    BookUnit,
    Box,
    Bundle,
    // C-Size,
    Celsius,
    Centimeter,
    CentimeterPerSecond,
    Cord,
    CubicCentimeterPerGram,
    CubicCentimeterPerSecond,
    CubicFoot,
    CubicInchesPerSecond,
    CubicMeter,
    CubicMeterPerKilogram,
    Cubit,
    Day,
    Decimeter,
    Degree,
    DegreesSchopperRiegler,
    DotsPerInch,
    Envelope,
    Fahrenheit,
    Foot,
    Gallon,
    Gram,
    GramCentimeter,
    GramForce,
    GramPerCubicCentimeter,
    GramPerMeter,
    GramsPerSquareMeter,
    Hectare,
    Hour,
    HundredBoardFeet,
    HundredLinealFeet,
    HundredPound,
    HundredSquareFeet,
    ImpressionCount,
    Inch,
    JoulePerSquareMeter,
    Kilogram,
    KilogramForcePerSquareCentimeter,
    KilogramForcePerCentimeter,
    KilogramPerCubicMeter,
    KilogramPerSquareMeter,
    KilogramsPerDay,
    KilogramsPerWeek,
    Kilometer,
    KiloNewton,
    KiloNewtonPerMeter,
    KiloPascal,
    KnownBreaks,
    Layer,
    Leaves,
    LinearFoot,
    LinesPerInch,
    Litre,
    Load,
    Log,
    LogPile,
    LooseVolumeItem,
    MagazineUnit,
    Megabyte,
    MegaWattHour,
    Meter,
    MeterPerSecond,
    MetricTon,
    MetricTonsPerDay,
    MetricTonsPerHour,
    MetricTonsPerWeek,
    MicroMeterPerPascalSecond,
    Micron,
    MilliLitersPerMinute,
    Millimeter,
    MilliNewton,
    MilliNewtonMeter,
    MilliNewtonSquareMeterPerGram,
    Minute,
    NanoMeter,
    Newton,
    NewtonMeterPerGram,
    None,
    Package,
    Page,
    PagesPerForm,
    PagesPerImpression,
    PagesPerInch,
    PalletUnit,
    PartsPerMillion,
    Percentage,
    PerThousand,
    pH,
    Picas,
    Piece,
    PixelsPerInch,
    Pound,
    PoundForce,
    PoundPerCubicFoot,
    PoundPerSixInchDiameter,
    PoundPerSquareInch,
    PoundsPerDay,
    PoundsPerHour,
    PoundsPerWeek,
    PulpUnit,
    Ream,
    Reel,
    Set,
    Sheet,
    ShortTon,
    ShortTonsPerDay,
    ShortTonsPerHour,
    ShortTonsPerWeek,
    Signature,
    Skid,
    SquareFeet,
    SquareInch,
    SquareMeter,
    SquareMeterPerKilogram,
    TenKilometer,
    ThousandBoardFeet,
    ThousandLinealFeet,
    ThousandPieces,
    ThousandSquareCentimeters,
    ThousandSquareFeet,
    ThousandSquareInch,
    Ton,
    TonsPerHour,
    Unit,
    UnknownBreaks,
    Yard,
}

public enum PriceQuantityBasis
{
    ActualVolume,
    AirDryWeight,
    Area,
    BoneDry,
    Count,
    GrossWeight,
    Energy,
    Length,
    LogPileVolume,
    NetWeight,
    NetNetWeight,
    NominalWeight,
    Percent,
    RunningLength,
    ShortLengthVolume,
    SolidWoodVolume,
    TareWeight,
    Time,
    TippedLooseVolume,
    Volume,
}

public enum PriceTaxBasis
{
    Yes,
    No,
}

public enum InformationalPricePerUnitType
{
    AlternatePrice,
    CoverPrice,
    ProductPrice,
    ProductionPrice,
}

public enum ExchangeRateType
{
    Fixed,
    Float,
}

public enum CurrencyFromType
{
    // TODO:
    // A three-character ISO 4217 currency code in capital letters.
    // Refer to the ISO standard for enumerations.
}

public enum CurrencyType
{
    // TODO:
    // A three-character ISO 4217 currency code in capital letters.
    // Refer to the ISO standard for enumerations.
}

public enum AdjustmentType_Financial
{
    BillOfLadingCharge,
    CancellationCharge,
    CashDiscount,
    CertificateCharge,
    ChargesForward,
    ClaimAdjustment,
    Commission,
    CompetitiveAllowance,
    CongestionCharge,
    ConsigneeUnloadCharge,
    ContractAllowance,
    CurrencyAdjustmentCharge,
    DecimalRounding,
    DefectiveAllowance,
    DeliveryCharge,
    DeliveryNonConformanceAllowance,
    EarlyShipAllowance,
    EnergySurcharge,
    Environmental,
    ExpeditedShipmentCharge,
    ExportClearanceCharge,
    FlatRateCharge,
    FreightAllowance,
    FreightCharge,
    FuelAdjustmentCharge,
    HandlingCharge,
    Inspection,
    InterestCharge,
    LabourAllowance,
    LabourCharge,
    LotCharge,
    MetalDetection,
    ModelHomeDiscount,
    NewStoreCouponDiscount,
    OrderQuantity,
    PalletCharge,
    PickUpAllowance,
    PromotionalAllowance,
    PromotionalCharge,
    PriceCorrection,
    ProductionSetUpCharge,
    Provision,
    Rebate,
    ReelDiscount,
    ReturnedLoadAllowance,
    ReturnLoadCharge,
    RoadFeeCharge,
    ScrapAndDunnageCharge,
    ServiceCharge,
    SpecialConversionCharge,
    SpecialDeliveryCharge,
    SpecialHandlingCharge,
    SpecialPackagingCharge,
    StopOffAllowance,
    StopOffCharge,
    StorageAllowance,
    StorageCharge,
    Tax,
    TestingCharge,
    TradeDiscount,
    TrialDiscount,
    TransferCharge,
    UnloadingAllowance,
    UnloadingCharge,
    VolumeDiscount,
    WarRiskCharge,
    Other,
}

public enum TaxCategoryType
{
    Exempt,
    Standard,
    Zero,
    Other,
}

public enum TaxType
{
    Federal,
    GST,
    Harmonised,
    Local,
    StateOrProvincial,
    VAT,
}

public enum AmountType
{
    Adjustment,
    Net,
    Tax,
    TermsDiscountNet,
    Total,
}

public enum DeliveryModeType
{
    Deliver,
    PickUp,
}

public enum DeliveryLegType
{
    Fixed,
    Open,
}

public enum EventType
{
    Historical,
    Current,
    Future,
    Return,
}

public enum LegStageType
{
    PreCarriage,
    MainCarriage,
    OnCarriage,
}

public enum LocationType
{
    Destination,
    Origin,
}

public enum TransportModeType
{
    Air,
    InlandWaterway,
    Intermodal,
    Mail,
    Multimodal,
    Rail,
    Road,
    Sea,
    Other,
}

public enum TransportVehicleType
{
    Barge,
    ContainerVessel,
    ConventionalVessel,
    RollOnOffShip,
    SidePortVessel,
    Train,
    Truck,
    TruckTrailer,
    Other,
}

public enum TransportVehicleIdentifierType
{
    FlightNumber,
    GlobalReturnableAssetIdentifier,
    IMONumber,
    LicencePlateNumber,
    RadioCallSign,
    RFTag,
    SerialisedShippingContainerCode,
    StandardCarrierAlphaCode,
    TrainNumber,
    VesselName,
    VoyageNumber,
    Other,
}

public enum ISOCountryCode
{
    AF,
    AL,
    DZ,
    AS,
    AD,
    AO,
    AI,
    AQ,
    AG,
    AR,
    AM,
    AW,
    AU,
    AT,
    AZ,
    BS,
    BH,
    BD,
    BB,
    BY,
    BE,
    BZ,
    BJ,
    BM,
    BT,
    BO,
    BQ,
    BA,
    BW,
    BV,
    BR,
    IO,
    BN,
    BG,
    BF,
    BI,
    CV,
    KH,
    CM,
    CA,
    KY,
    CF,
    TD,
    CL,
    CN,
    CX,
    CC,
    CO,
    KM,
    CD,
    CG,
    CK,
    CR,
    HR,
    CU,
    CW,
    CY,
    CZ,
    CI,
    DK,
    DJ,
    DM,
    DO,
    EC,
    EG,
    SV,
    GQ,
    ER,
    EE,
    SZ,
    ET,
    FK,
    FO,
    FJ,
    FI,
    FR,
    GF,
    PF,
    TF,
    GA,
    GM,
    GE,
    DE,
    GH,
    GI,
    GR,
    GL,
    GD,
    GP,
    GU,
    GT,
    GG,
    GN,
    GW,
    GY,
    HT,
    HM,
    VA,
    HN,
    HK,
    HU,
    IS,
    IN,
    ID,
    IR,
    IQ,
    IE,
    IM,
    IL,
    IT,
    JM,
    JP,
    JE,
    JO,
    KZ,
    KE,
    KI,
    KP,
    KR,
    KW,
    KG,
    LA,
    LV,
    LB,
    LS,
    LR,
    LY,
    LI,
    LT,
    LU,
    MO,
    MG,
    MW,
    MY,
    MV,
    ML,
    MT,
    MH,
    MQ,
    MR,
    MU,
    YT,
    MX,
    FM,
    MD,
    MC,
    MN,
    ME,
    MS,
    MA,
    MZ,
    MM,
    NA,
    NR,
    NP,
    NL,
    NC,
    NZ,
    NI,
    NE,
    NG,
    NU,
    NF,
    MK,
    MP,
    NO,
    OM,
    PK,
    PW,
    PS,
    PA,
    PG,
    PY,
    PE,
    PH,
    PN,
    PL,
    PT,
    PR,
    QA,
    RO,
    RU,
    RW,
    RE,
    BL,
    SH,
    KN,
    LC,
    MF,
    PM,
    VC,
    WS,
    SM,
    ST,
    SA,
    SN,
    RS,
    SC,
    SL,
    SG,
    SX,
    SK,
    SI,
    SB,
    SO,
    ZA,
    GS,
    SS,
    ES,
    LK,
    SD,
    SR,
    SJ,
    SE,
    CH,
    SY,
    TW,
    TJ,
    TZ,
    TH,
    TL,
    TG,
    TK,
    TO,
    TT,
    TN,
    TM,
    TC,
    TV,
    TR,
    UG,
    UA,
    AE,
    GB,
    UM,
    US,
    UY,
    UZ,
    VU,
    VE,
    VN,
    VG,
    VI,
    WF,
    EH,
    YE,
    ZM,
    ZW,
    AX,
}

public enum TransportUnitType
{
    Barge,
    Cassette,
    Container,
    ConventionalVessel,
    DrawBarCombination,
    Flatbed,
    FlatCar,
    RailCar,
    RigidLorry,
    StackTrain,
    SwapBodies,
    Trailer,
    Wagon,
    Other,
}

public enum TransportUnitVariable
{
    CubicCapacity,
    DeckOption,
    Height,
    Length,
    RailcarDoorSize,
    WeightCarryingCapacity,
}

public enum AppliesTo
{
    Payload,
    Unit,
}

public enum TransportUnitIdentifierType
{
    ContainerID,
    CassetteID,
    GlobalReturnableAssetIdentifier,
    RailCarID,
    RFTag,
    SealNumber,
    SerialShippingContainerCode,
    TrailerID,
    WagonID,
    Other,
}

public enum TransportUnitDetailType
{
    DryFreightContainer,
    PlatformContainer,
    OpenSidesContainer,
    OpenTopContainer,
    OverheadContainer,
    SwapBodyContainer,
    BoxTrailer,
    CurtainsiderTrailer,
    DrawBarTrailer,
    GooseneckTrailer,
    HuckepackTrailer,
    FlatbedTrailer,
    SkeletalTrailer,
    SkeletalContainerTrailer,
    SkeletalDrawbarTrailer,
    SpecialTrailer,
    TerminalTrailer,
    TiltTrailer,
    BasketRailCar,
    ContainerRailCar,
    FlatRailCar,
    HighSidedRailCar,
    PocketRailCar,
    SpineRailCar,
}

public enum LoadOpeningSide
{
    BackEndSide,
    FrontEndSide,
    LeftAndRightSide,
    LeftSide,
    RightSide,
}

public enum TransportUnloadingType
{
    ByUnloadingCode,
    Lying,
    Standing,
    StandingUpsideDown,
    Other,
}

public enum DirectUnloading
{
    Yes,
    No,
}

public enum TransportInstructionType
{
    LegSpecific,
    ProductSpecific,
}

public enum RouteType
{
    DeliveryOriginToDeliveryDestination,
    MainIntersectionToDeliveryDestination,
    SupplyPointToDeliveryDestination,
    SupplyPointToMainIntersection,
}

public enum MapPointType
{
    Barrier,
    Bridge,
    CraneTemporaryStorage,
    Ferry,
    MainIntersection,
    Passage,
    PassingPossibility,
    RoadWorks,
    RouteLegEnd,
    RouteLegStart,
    RouteEnd,
    RouteStart,
    Slope,
    TurningPossibility,
    UnderPass,
    WeighBridge,
}

public enum RoadOwnerType
{
    Public,
    Private,
}

public enum RoadKeeperType
{
    Public,
    Private,
}

public enum RoadAccessibilityType
{
    Trailer,
    DrawBarCombination,
    DrawBarCombinationWithAdjustableBogie,
    RigidLorry,
}

public enum RoadTurningPossibilityType
{
    Trailer,
    DrawBarCombination,
    DrawBarCombinationWithAdjustableBogie,
    RigidLorry,
    NoTurningPossibility,
}

public enum RoadTurningPointType
{
    Circle,
    //T-crossing,
    //X-crossing,
}

public enum RoadPassingPossibility
{
    Yes,
    No,
}

public enum RoadAvailability
{
    AllYear,
    NotInHeavyRain,
    NotInSevereThawing,
    NotInWinter,
    InWinter,
}

public enum RoadBearingCapacityType
{
    BogieLoad,
    SingleAxleLoad,
    TripleAxleLoad,
    TotalVehicleLoad,
}

public enum RoadObstructionType
{
    Bridge,
    Ferry,
    Passage,
    RoadWorks,
    Slope,
    UnderPass,
}

public enum DeliveryLegReferenceType
{
    AccountNumber,
    AudioVideoSelectionNumber,
    Author,
    BarCodedSerialNumber,
    BillAndHoldInvoiceNumber,
    BillOfLadingMark,
    BillOfLadingNumber,
    BindingStyleType,
    BookLanguage,
    BookingNumber,
    BudgetCenter,
    BuyerBudgetCenter,
    BuyerClaimNumber,
    BuyerDivisionIdentifier,
    BuyerImprint,
    BuyerJobNumber,
    BuyerRetailPrice,
    CallOffConfirmationLineItemNumber,
    CallOffConfirmationNumber,
    CallOffLineItemNumber,
    CallOffNumber,
    CallOffReferenceNumber,
    CatalogueReferenceNumber,
    CIMNumber,
    CMRNumber,
    CoLoadingNumber,
    ComplaintNumber,
    ComplaintLineItemNumber,
    ComplaintResponseNumber,
    ComplaintResponseLineItemNumber,
    ConsigneeOrderNumber,
    ContainerReference,
    ContentLanguage,
    ContractLineNumber,
    ContractNumber,
    ConvertingReportNumber,
    Copyright,
    CreditAuthorizationNumber,
    CreditDebitNoteNumber,
    CreditNoteNumber,
    CustomerBookingNumber,
    CustomerJobNumber,
    CustomerJobTitle,
    CustomerOrderNumber,
    CustomerReferenceNumber,
    CustomerSpecificationNumber,
    DebitNoteNumber,
    DeliveryBookingNumber,
    DeliveryInstructionNumber,
    DeliveryInstructionSequenceNumber,
    DeliveryInstructionSequenceLineNumber,
    DeliveryLocation,
    DeliveryMessageNumber,
    DeliveryMessageLineItemNumber,
    DeliveryNumber,
    DepartmentIdentifier,
    DespatchInformationNumber,
    DespatchInstructionNumber,
    DivisionIdentifier,
    DropOffNumber,
    Edition,
    EditionState,
    EditionSubject,
    EducationSubject,
    EndCallOffDate,
    FlightNumber,
    FormID,
    FormLowFolio,
    FormPages,
    FormType,
    ForwarderReference,
    FromPurchaseOrderNumber,
    FromSalesOrderNumber,
    FSCNumber,
    GeneralAgreement,
    GoodsInBillOfLadingNumber,
    GoodsInDeliveryNumber,
    GoodsInTransportUnitIdentifier,
    GoodsInTransportVehicleIdentifier,
    GoodsReceiptNumber,
    GoodsReceiptLineItemNumber,
    Imprint,
    IndentOrderNumber,
    InitialShipmentAdviceNumber,
    IntraStatNumber,
    InventoryChangeNumber,
    InventoryDispositionInstructionsNumber,
    InventoryDispositionInstructionsLineNumber,
    InvoiceNumber,
    ISBN10,
    ISBN10Dash,
    ISBN13,
    ISBN13Dash,
    ISODocumentReference,
    IssueEvent,
    JobNumber,
    JobTitle,
    LoadPlanNumber,
    LoadReleaseNumber,
    LoadTenderNumber,
    LoadTenderResponseNumber,
    LoadingInstructionNumber,
    LoadingInstructionSequenceNumber,
    LoadingInstructionSequenceLineNumber,
    LoadingOrderNumber,
    LoadingOrderLineNumber,
    LotIdentifier,
    MagazineCode,
    ManufacturerMaterialSafetyDataSheetNumber,
    MarketType,
    MarketplaceReferenceNumber,
    MasterBillOfLading,
    MasterContractNumber,
    MasterISBN10,
    MasterISBN13,
    MasterPurchaseOrder,
    MaterialSafetyDataSheetNumber,
    MeasuringInstructionNumber,
    MeasuringNumber,
    MeasuringTicketNumber,
    MeasuringTicketSequenceNumber,
    MeasuringTicketSequenceLineItemNumber,
    MillOrderLineItemNumber,
    MillOrderNumber,
    MillSalesOfficeNumber,
    NonconformanceReportNumber,
    OrderConfirmationNumber,
    OrderConfirmationLineItemNumber,
    OrderNumber,
    OrderLineItemNumber,
    OrderPartyReferenceNumber,
    OriginalComplaintResponseNumber,
    OriginalDeliveryNumber,
    OriginalGoodsReceiptNumber,
    OriginalInvoiceNumber,
    OriginalProductQualityMessageNumber,
    OriginalPurchaseOrderNumber,
    OriginalSalesOrderNumber,
    OriginalScaleTicketNumber,
    OriginalUsageNumber,
    PackageMark,
    PackageNumber,
    PackageSpecificationNumber,
    PackageSpecificationLineNumber,
    PageCount,
    PageCountTotal,
    PaymentReferenceNumber,
    PEFCNumber,
    PickUpNumber,
    PlanningMessageNumber,
    PopulationNumber,
    PriceContractNumber,
    PriceQuoteNumber,
    PriceList,
    PrintingCode,
    PrintingNumber,
    PriorPurchaseOrderNumber,
    ProductOriginIdentifier,
    ProFormaInvoiceNumber,
    ProNumber,
    ProfitCenter,
    ProgramID,
    PromotionNumber,
    PubName,
    PubNumber,
    PublisherReferenceNumber,
    PupilsTeachers,
    PurchaseOrderCorrelationID,
    PurchaseOrderNumber,
    PurchaseOrderLineItemCorrelationID,
    PurchaseOrderLineItemNumber,
    QualityReportNumber,
    RandomSampleNumber,
    ReferenceNumber,
    ReleaseNumber,
    RetailPrice,
    RFQLineItemNumber,
    RFQNumber,
    RunNumber,
    SalesOfficeNumber,
    SalesOrderLineItemNumber,
    SalesOrderNumber,
    ScaleTicketNumber,
    SchoolGrade,
    SchoolGradeLevel,
    SellersInvoiceNumber,
    ServiceNumber,
    ShippingInstructionsLineItemNumber,
    ShippingInstructionsNumber,
    SimplifiedCustomsNumber,
    SpecificationNumber,
    SpecificationReferenceNumber,
    SpecificationVersion,
    StockOrderLineItemNumber,
    StockOrderNumber,
    SupplierCallOffNumber,
    SupplierClaimNumber,
    SupplierJobNumber,
    SupplierReferenceNumber,
    SupplierVoyageNumber,
    T2L,
    TimeTableNumber,
    Title,
    TitleAlias,
    ToPurchaseOrderNumber,
    TrackingNumber,
    TransactionID,
    TransportUnitIdentifier,
    TransportVehicleIdentifier,
    UniversalProductIdentifier,
    UsageNumber,
    UsageLineItemNumber,
    VendorReferenceNumber,
    VesselShipNotice,
    VoucherNumber,
    VoyageNumber,
    WarehouseDeliveryNumber,
    WaybillIdentifier,
    Other,
}

public enum TermsOfCharteringType
{
    Loading,
    Unloading,
}

public enum DeliveryScheduleReferenceType
{
    AccountNumber,
    AudioVideoSelectionNumber,
    Author,
    BarCodedSerialNumber,
    BillAndHoldInvoiceNumber,
    BillOfLadingMark,
    BillOfLadingNumber,
    BindingStyleType,
    BookLanguage,
    BookingNumber,
    BudgetCenter,
    BuyerBudgetCenter,
    BuyerClaimNumber,
    BuyerDivisionIdentifier,
    BuyerImprint,
    BuyerJobNumber,
    BuyerRetailPrice,
    CallOffConfirmationLineItemNumber,
    CallOffConfirmationNumber,
    CallOffLineItemNumber,
    CallOffNumber,
    CallOffReferenceNumber,
    CatalogueReferenceNumber,
    CIMNumber,
    CMRNumber,
    CoLoadingNumber,
    ComplaintNumber,
    ComplaintLineItemNumber,
    ComplaintResponseNumber,
    ComplaintResponseLineItemNumber,
    ConsigneeOrderNumber,
    ContainerReference,
    ContentLanguage,
    ContractLineNumber,
    ContractNumber,
    ConvertingReportNumber,
    Copyright,
    CreditAuthorizationNumber,
    CreditDebitNoteNumber,
    CreditNoteNumber,
    CustomerBookingNumber,
    CustomerJobNumber,
    CustomerJobTitle,
    CustomerOrderNumber,
    CustomerReferenceNumber,
    CustomerSpecificationNumber,
    DebitNoteNumber,
    DeliveryBookingNumber,
    DeliveryInstructionNumber,
    DeliveryInstructionSequenceNumber,
    DeliveryInstructionSequenceLineNumber,
    DeliveryLocation,
    DeliveryMessageNumber,
    DeliveryMessageLineItemNumber,
    DeliveryNumber,
    DepartmentIdentifier,
    DespatchInformationNumber,
    DespatchInstructionNumber,
    DivisionIdentifier,
    DropOffNumber,
    Edition,
    EditionState,
    EditionSubject,
    EducationSubject,
    EndCallOffDate,
    FlightNumber,
    FormID,
    FormLowFolio,
    FormPages,
    FormType,
    ForwarderReference,
    FromPurchaseOrderNumber,
    FromSalesOrderNumber,
    FSCNumber,
    GeneralAgreement,
    GoodsInBillOfLadingNumber,
    GoodsInDeliveryNumber,
    GoodsInTransportUnitIdentifier,
    GoodsInTransportVehicleIdentifier,
    GoodsReceiptNumber,
    GoodsReceiptLineItemNumber,
    Imprint,
    IndentOrderNumber,
    InitialShipmentAdviceNumber,
    IntraStatNumber,
    InventoryChangeNumber,
    InventoryDispositionInstructionsNumber,
    InventoryDispositionInstructionsLineNumber,
    InvoiceNumber,
    ISBN10,
    ISBN10Dash,
    ISBN13,
    ISBN13Dash,
    ISODocumentReference,
    IssueEvent,
    JobNumber,
    JobTitle,
    LoadPlanNumber,
    LoadReleaseNumber,
    LoadTenderNumber,
    LoadTenderResponseNumber,
    LoadingInstructionNumber,
    LoadingInstructionSequenceNumber,
    LoadingInstructionSequenceLineNumber,
    LoadingOrderNumber,
    LoadingOrderLineNumber,
    LotIdentifier,
    MagazineCode,
    ManufacturerMaterialSafetyDataSheetNumber,
    MarketType,
    MarketplaceReferenceNumber,
    MasterBillOfLading,
    MasterContractNumber,
    MasterISBN10,
    MasterISBN13,
    MasterPurchaseOrder,
    MaterialSafetyDataSheetNumber,
    MeasuringInstructionNumber,
    MeasuringNumber,
    MeasuringTicketNumber,
    MeasuringTicketSequenceNumber,
    MeasuringTicketSequenceLineItemNumber,
    MillOrderLineItemNumber,
    MillOrderNumber,
    MillSalesOfficeNumber,
    NonconformanceReportNumber,
    OrderConfirmationNumber,
    OrderConfirmationLineItemNumber,
    OrderNumber,
    OrderLineItemNumber,
    OrderPartyReferenceNumber,
    OriginalComplaintResponseNumber,
    OriginalDeliveryNumber,
    OriginalGoodsReceiptNumber,
    OriginalInvoiceNumber,
    OriginalProductQualityMessageNumber,
    OriginalPurchaseOrderNumber,
    OriginalSalesOrderNumber,
    OriginalScaleTicketNumber,
    OriginalUsageNumber,
    PackageMark,
    PackageNumber,
    PackageSpecificationNumber,
    PackageSpecificationLineNumber,
    PageCount,
    PageCountTotal,
    PaymentReferenceNumber,
    PEFCNumber,
    PickUpNumber,
    PlanningMessageNumber,
    PopulationNumber,
    PriceContractNumber,
    PriceQuoteNumber,
    PriceList,
    PrintingCode,
    PrintingNumber,
    PriorPurchaseOrderNumber,
    ProductOriginIdentifier,
    ProFormaInvoiceNumber,
    ProNumber,
    ProfitCenter,
    ProgramID,
    PromotionNumber,
    PubName,
    PubNumber,
    PublisherReferenceNumber,
    PupilsTeachers,
    PurchaseOrderCorrelationID,
    PurchaseOrderNumber,
    PurchaseOrderLineItemCorrelationID,
    PurchaseOrderLineItemNumber,
    QualityReportNumber,
    RandomSampleNumber,
    ReferenceNumber,
    ReleaseNumber,
    RetailPrice,
    RFQLineItemNumber,
    RFQNumber,
    RunNumber,
    SalesOfficeNumber,
    SalesOrderLineItemNumber,
    SalesOrderNumber,
    ScaleTicketNumber,
    SchoolGrade,
    SchoolGradeLevel,
    SellersInvoiceNumber,
    ServiceNumber,
    ShippingInstructionsLineItemNumber,
    ShippingInstructionsNumber,
    SimplifiedCustomsNumber,
    SpecificationNumber,
    SpecificationReferenceNumber,
    SpecificationVersion,
    StockOrderLineItemNumber,
    StockOrderNumber,
    SupplierCallOffNumber,
    SupplierClaimNumber,
    SupplierJobNumber,
    SupplierReferenceNumber,
    SupplierVoyageNumber,
    T2L,
    TimeTableNumber,
    Title,
    TitleAlias,
    ToPurchaseOrderNumber,
    TrackingNumber,
    TransactionID,
    TransportUnitIdentifier,
    TransportVehicleIdentifier,
    UniversalProductIdentifier,
    UsageNumber,
    UsageLineItemNumber,
    VendorReferenceNumber,
    VesselShipNotice,
    VoucherNumber,
    VoyageNumber,
    WarehouseDeliveryNumber,
    WaybillIdentifier,
    Other,
}

public class DeliveryMessageWood
{
    public DeliveryMessageType DeliveryMessageType = DeliveryMessageType.DeliveryMessage;
    public DeliveryMessageStatusType DeliveryMessageStatusType = DeliveryMessageStatusType.Original;
    public DeliveryMessageContextType? DeliveryMessageContextType = null;
    public bool? Reissued = null;
    public Language? Language = null;
    public DeliveryMessageWoodHeader DeliveryMessageWoodHeader = new();
    public DeliveryMessageShipment DeliveryMessageShipment = new();
    public DeliveryMessageWoodSummary? DeliveryMessageWoodSummary = null;

    public DeliveryMessageWood() { }

    public DeliveryMessageWood(
        DeliveryMessageType deliveryMessageType, 
        DeliveryMessageStatusType deliveryMessageStatusType,
        DeliveryMessageContextType? deliveryMessageContextType, 
        bool? reissued,
        Language? language,
        DeliveryMessageWoodHeader deliveryMessageWoodHeader,
        DeliveryMessageShipment deliveryMessageShipment,
        DeliveryMessageWoodSummary? deliveryMessageWoodSummary)
    {
        DeliveryMessageType = deliveryMessageType;
        DeliveryMessageStatusType = deliveryMessageStatusType;
        DeliveryMessageContextType = deliveryMessageContextType;
        Reissued = reissued;
        Language = language;
        DeliveryMessageWoodHeader = deliveryMessageWoodHeader;
        DeliveryMessageShipment = deliveryMessageShipment;
        DeliveryMessageWoodSummary = deliveryMessageWoodSummary;
    }

    public DeliveryMessageWood(XElement root)
    {
        var deliveryMessageTypeAttribute = root.Attribute("DeliveryMessageType");
        var deliveryMessageStatusTypeAttribute = root.Attribute("DeliveryMessageStatusType");
        var deliveryMessageContextTypeAttribute = root.Attribute("DeliveryMessageContextType");
        var reissuedAttribute = root.Attribute("Reissued");
        var deliveryMessageWoodHeaderElement = root.Element("DeliveryMessageWoodHeader");
        var deliveryMessageShipmentElement = root.Element("DeliveryMessageShipment");
        var deliveryMessageWoodSummaryElement = root.Element("DeliveryMessageWoodSummary");

        DeliveryMessageType = Enum.Parse<DeliveryMessageType>(deliveryMessageTypeAttribute!.Value);
        DeliveryMessageStatusType = Enum.Parse<DeliveryMessageStatusType>(deliveryMessageStatusTypeAttribute!.Value);
        DeliveryMessageContextType = deliveryMessageContextTypeAttribute != null ? Enum.Parse<DeliveryMessageContextType>(deliveryMessageContextTypeAttribute.Value) : null;
        Reissued = reissuedAttribute != null ? bool.Parse(reissuedAttribute.Value) : null;
        DeliveryMessageWoodHeader = new DeliveryMessageWoodHeader(deliveryMessageWoodHeaderElement!);
        DeliveryMessageShipment = new DeliveryMessageShipment(deliveryMessageShipmentElement!);
        DeliveryMessageWoodSummary = deliveryMessageWoodSummaryElement != null ? new DeliveryMessageWoodSummary(deliveryMessageWoodSummaryElement) : null;
    }

    public override string ToString()
    {
        return new XElement("DeliveryMessageWood",
            new XAttribute("DeliveryMessageType", DeliveryMessageType),
            new XAttribute("DeliveryMessageStatusType", DeliveryMessageStatusType),
            DeliveryMessageContextType != null ? new XAttribute("DeliveryMessageContextType", DeliveryMessageContextType) : null,
            Reissued != null ? new XAttribute("Reissued", Reissued) : null,
            XElement.Parse($"{DeliveryMessageWoodHeader}"),
            XElement.Parse($"{DeliveryMessageShipment}"),
            DeliveryMessageWoodSummary != null ? XElement.Parse($"{DeliveryMessageWoodSummary}") : null
        ).ToString();
    }
}

public class DeliveryMessageWoodSummary
{
    public DeliveryMessageWoodSummary(XElement root)
    {
    }
}

public class DeliveryMessageDate
{
    public Date Date = new();

    public DeliveryMessageDate() { }

    public DeliveryMessageDate(Date date) { Date = date; }

    public DeliveryMessageDate(XElement root)
    {
        Date = root.Element("Date") is XElement date ? new Date(date) : Date;
    }

    public override string ToString()
    {
        return new XElement("DeliveryMessageDate", 
            XElement.Parse($"{Date}")            
        ).ToString();
    }
}

public class Date
{
    public string Year = string.Empty;
    public string Month = string.Empty;
    public string Day = string.Empty;

    public Date() { }

    public Date(string year, string month, string day)
    {
        Year = year;
        Month = month;
        Day = day;
    }

    public Date(XElement root)
    {
        Year = root.Element("Year")?.Value ?? Year;
        Month = root.Element("Month")?.Value ?? Month;
        Day = root.Element("Day")?.Value ?? Day;
    }

    public override string ToString()
    {
        return new XElement("Date",
            new XElement("Year", Year),
            new XElement("Month", Month),
            new XElement("Day", Day)
        ).ToString();
    }
}

public class Time
{
    public string Value = string.Empty;

    public Time() { }

    public Time(string value) { Value = value; }

    public Time(XElement root) { Value = root.Value; }

    public override string ToString()
    {
        return new XElement("Time",
            Value
        ).ToString();
    }
}

public class DeliveryMessageShipment
{
    public DeliveryMessageShipment() { }

    public DeliveryMessageShipment(XElement root)
    {
    }

    public override string ToString()
    {
        return new XElement("DeliveryMessageShipment"
            
        ).ToString();
    }
}

public class DeliveryMessageWoodHeader
{
    public string DeliveryMessageNumber = string.Empty;
    public string? TransactionHistoryNumber = null;
    public DeliveryMessageDate DeliveryMessageDate = new();
    public List<DeliveryMessageReference> DeliveryMessageReference = [];
    public List<DocumentReferenceInformation> DocumentReferenceInformation = [];
    public Party BuyerParty = new() { LocalName = "BuyerParty" };
    public Party? BillToParty = new() { LocalName = "BillToParty" };
    public Party SupplierParty = new() { LocalName = "SupplierParty" };
    public List<Party> OtherParty = [];
    public Party? SenderParty = new() { LocalName = "SenderParty" };
    public Party? ReceiverParty = new() { LocalName = "ReceiverParty" };
    public List<ShipToInformation> ShipToInformation = [];
    public CountryOfOrigin? CountryOfOrigin = null;
    public CountryOfDestination? CountryOfDestination = null;

    public DeliveryMessageWoodHeader() { }

    public DeliveryMessageWoodHeader(XElement root)
    {
        DeliveryMessageNumber = root.Element("DeliveryMessageNumber")?.Value ?? DeliveryMessageNumber;
        TransactionHistoryNumber = root.Element("TransactionHistoryNumber")?.Value;
        DeliveryMessageDate = root.Element("DeliveryMessageDate") is XElement deliveryMessageDate 
            ? new DeliveryMessageDate(deliveryMessageDate) 
            : DeliveryMessageDate;
        DeliveryMessageReference = root.Elements("DeliveryMessageReference")
            .Select(reference => new DeliveryMessageReference(reference))
            .ToList();
        DocumentReferenceInformation = root.Elements("DocumentReferenceInformation")
            .Select(information => new DocumentReferenceInformation(information))
            .ToList();
        BuyerParty = root.Element("BuyerParty") is XElement buyerParty
            ? new Party(buyerParty)
            : BuyerParty;
        BillToParty = root.Element("BillToParty") is XElement billToParty
            ? new Party(billToParty)
            : BillToParty;
        SupplierParty = root.Element("SupplierParty") is XElement supplierParty
            ? new Party(supplierParty)
            : SupplierParty;
        OtherParty = root.Elements("OtherParty")
            .Select(party => new Party(party))
            .ToList();
        SenderParty = root.Element("SenderParty") is XElement senderParty
            ? new Party(senderParty)
            : SenderParty;
        ReceiverParty = root.Element("ReceiverParty") is XElement receiverParty
            ? new Party(receiverParty)
            : ReceiverParty;
    }

    public override string ToString()
    {
        return new XElement("DeliveryMessageWoodHeader",
            new XElement("DeliveryMessageNumber", DeliveryMessageNumber),
            TransactionHistoryNumber != null ? new XElement("TransactionHistoryNumber", TransactionHistoryNumber) : null,
            XElement.Parse($"{DeliveryMessageDate}"),
            DeliveryMessageReference.Select(reference => XElement.Parse($"{reference}")),
            DocumentReferenceInformation.Select(information => XElement.Parse($"{information}")),
            XElement.Parse($"{BuyerParty}"),
            XElement.Parse($"{BillToParty}"),
            XElement.Parse($"{SupplierParty}"),
            OtherParty.Select(party => XElement.Parse($"{party}")),
            XElement.Parse($"{SenderParty}"),
            XElement.Parse($"{ReceiverParty}")
        ).ToString();
    }
}

public class CountryOfDestination
{
    public string Country = string.Empty;
    public ISOCountryCode? ISOCountryCode = null;
    public string Value = string.Empty;

    public CountryOfDestination() { }

    public CountryOfDestination(XElement root)
    {
        Country = root.Element("Country")?.Value ?? Country;
        ISOCountryCode = root.Attribute("ISOCountryCode") is XAttribute isoCountryCode
            ? Enum.Parse<ISOCountryCode>(isoCountryCode.Value)
            : ISOCountryCode;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("CountryOfDestination",
            ISOCountryCode != null ? new XAttribute("ISOCountryCode", ISOCountryCode) : null,
            new XElement("Country", Country),
            Value
        ).ToString();
    }
}

public class CountryOfOrigin
{
    public string Country = string.Empty;
    public ISOCountryCode? ISOCountryCode = null;
    public string Value = string.Empty;

    public CountryOfOrigin() { }

    public CountryOfOrigin(XElement root)
    {
        Country = root.Element("Country")?.Value ?? Country;
        ISOCountryCode = root.Attribute("ISOCountryCode") is XAttribute isoCountryCode
            ? Enum.Parse<ISOCountryCode>(isoCountryCode.Value)
            : ISOCountryCode;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("CountryOfOrigin",
            ISOCountryCode != null ? new XAttribute("ISOCountryCode", ISOCountryCode) : null,
            new XElement("Country", Country),
            Value
        ).ToString();
    }
}

public class ShipToInformation
{
    public ShipToCharacteristics ShipToCharacteristics = new();
    public List<DeliverySchedule> DeliverySchedule = [];
    public string Value = string.Empty;

    public ShipToInformation() { }

    public ShipToInformation(XElement root)
    {
        ShipToCharacteristics = root.Element("ShipToCharacteristics") is XElement shipToCharacteristics
            ? new ShipToCharacteristics(shipToCharacteristics)
            : ShipToCharacteristics;
        DeliverySchedule = root.Elements("DeliverySchedule")
            .Select(schedule => new DeliverySchedule(schedule))
            .ToList();
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("ShipToInformation",
            XElement.Parse($"{ShipToCharacteristics}"),
            DeliverySchedule.Select(schedule => XElement.Parse($"{schedule}")),
            Value
        ).ToString();
    }
}

public class DeliverySchedule
{
    public string DeliveryLineNumber = string.Empty;
    public ProductionStatus? ProductionStatus = null;
    public DeliveryStatus? DeliveryStatus = null;
    public List<DeliveryDateWindow> DeliveryDateWindow = [];
    public Quantity Quantity = new();
    public List<InformationalQuantity> InformationalQuantity = [];
    public PriceDetails? PriceDetails = null;
    public List<MonetaryAdjustment> MonetaryAdjustment = [];
    public List<DeliveryLeg> DeliveryLeg = [];
    public List<DeliveryScheduleReference> DeliveryScheduleReference = [];
    public List<string> AdditionalText = [];
    public string Value = string.Empty;

    public DeliverySchedule() { }

    public DeliverySchedule(XElement root)
    {
        DeliveryLineNumber = root.Element("DeliveryLineNumber")?.Value ?? DeliveryLineNumber;
        ProductionStatus = root.Element("ProductionStatus") is XElement productionStatus
            ? new ProductionStatus(productionStatus)
            : ProductionStatus;
        DeliveryStatus = root.Element("DeliveryStatus") is XElement deliveryStatus
            ? new DeliveryStatus(deliveryStatus)
            : DeliveryStatus;
        DeliveryDateWindow = root.Elements("DeliveryDateWindow")
            .Select(window => new DeliveryDateWindow(window))
            .ToList();
        Quantity = root.Element("Quantity") is XElement quantity
            ? new Quantity(quantity)
            : Quantity;
        InformationalQuantity = root.Elements("InformationalQuantity")
            .Select(quantity => new InformationalQuantity(quantity))
            .ToList();
        PriceDetails = root.Element("PriceDetails") is XElement priceDetails
            ? new PriceDetails(priceDetails)
            : PriceDetails;
        MonetaryAdjustment = root.Elements("MonetaryAdjustment")
            .Select(adjustment => new MonetaryAdjustment(adjustment))
            .ToList();
        DeliveryLeg = root.Elements("DeliveryLeg")
            .Select(leg => new DeliveryLeg(leg))
            .ToList();
        DeliveryScheduleReference = root.Elements("DeliveryScheduleReference")
            .Select(reference => new DeliveryScheduleReference(reference))
            .ToList();
        AdditionalText = root.Elements("AdditionalText")
            .Select(text => text.Value)
            .ToList();
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("DeliverySchedule",
            new XElement("DeliveryLineNumber", DeliveryLineNumber),
            ProductionStatus != null ? XElement.Parse($"{ProductionStatus}") : null,
            DeliveryStatus != null ? XElement.Parse($"{DeliveryStatus}") : null,
            DeliveryDateWindow.Select(window => XElement.Parse($"{window}")),
            Quantity != null ? XElement.Parse($"{Quantity}") : null,
            InformationalQuantity.Select(quantity => XElement.Parse($"{quantity}")),
            PriceDetails != null ? XElement.Parse($"{PriceDetails}") : null,
            MonetaryAdjustment.Select(adjustment => XElement.Parse($"{adjustment}")),
            DeliveryLeg.Select(leg => XElement.Parse($"{leg}")),
            DeliveryScheduleReference.Select(reference => XElement.Parse($"{reference}")),
            AdditionalText.Select(text => new XElement("AdditionalText", text)),
            Value
        ).ToString();
    }
}

public class DeliveryScheduleReference
{
    public DeliveryScheduleReferenceType DeliveryScheduleReferenceType = DeliveryScheduleReferenceType.Other;
    public AssignedBy? AssignedBy = null;
    public string Value = string.Empty;

    public DeliveryScheduleReference() { }

    public DeliveryScheduleReference(XElement root)
    {
        DeliveryScheduleReferenceType = root.Attribute("DeliveryScheduleReferenceType") is XAttribute deliveryScheduleReferenceType
            ? Enum.Parse<DeliveryScheduleReferenceType>(deliveryScheduleReferenceType.Value)
            : DeliveryScheduleReferenceType;
        AssignedBy = root.Attribute("AssignedBy") is XAttribute assignedBy
            ? Enum.Parse<AssignedBy>(assignedBy.Value)
            : AssignedBy;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("DeliveryScheduleReference",
            new XAttribute("DeliveryScheduleReferenceType", DeliveryScheduleReferenceType),
            AssignedBy != null ? new XAttribute("AssignedBy", AssignedBy) : null,
            Value
        ).ToString();
    }
}

public class DeliveryLeg
{
    public DeliveryModeType? DeliveryModeType = null;
    public DeliveryLegType? DeliveryLegType = null;
    public EventType? EventType = null;
    public LegStageType? LegStageType = null;
    public string DeliveryLegSequenceNumber = string.Empty;
    public DeliveryOrigin DeliveryOrigin = new();
    public Party? CarrierParty = new Party() { LocalName = "CarrierParty" };
    public List<Party> OtherParty = [];
    public TransportModeCharacteristics? TransportModeCharacteristics = null;
    public TransportVehicleCharacteristics? TransportVehicleCharacteristics = null;
    public TransportUnitCharacteristics? TransportUnitCharacteristics = null;
    public TransportUnloadingCharacteristics? TransportUnloadingCharacteristics = null;
    public TransportOtherInstructions? TransportOtherInstructions = null;
    public List<Route> Route = [];
    public DeliveryTransitTime? DeliveryTransitTime = null;
    public DeliveryDestination? DeliveryDestination = null;
    public List<DeliveryDateWindow> DeliveryDateWindow = [];
    public List<DeliveryLegReference> DeliveryLegReference = [];
    public List<TermsOfChartering> TermsOfChartering = [];
    public string Value = string.Empty;

    public DeliveryLeg() { }

    public DeliveryLeg(XElement root)
    {
        DeliveryModeType = root.Attribute("DeliveryModeType") is XAttribute deliveryModeType
            ? Enum.Parse<DeliveryModeType>(deliveryModeType.Value)
            : DeliveryModeType;
        DeliveryLegType = root.Attribute("DeliveryLegType") is XAttribute deliveryLegType
            ? Enum.Parse<DeliveryLegType>(deliveryLegType.Value)
            : DeliveryLegType;
        EventType = root.Attribute("EventType") is XAttribute eventType
            ? Enum.Parse<EventType>(eventType.Value)
            : EventType;
        LegStageType = root.Attribute("LegStageType") is XAttribute legStageType
            ? Enum.Parse<LegStageType>(legStageType.Value)
            : LegStageType;
        DeliveryLegSequenceNumber = root.Element("DeliveryLegSequenceNumber")?.Value ?? DeliveryLegSequenceNumber;
        DeliveryOrigin = root.Element("DeliveryOrigin") is XElement deliveryOrigin
            ? new DeliveryOrigin(deliveryOrigin)
            : DeliveryOrigin;
        CarrierParty = root.Element("CarrierParty") is XElement carrierParty
            ? new Party(carrierParty) { LocalName = "CarrierParty" }
            : CarrierParty;
        OtherParty = root.Elements("OtherParty")
            .Select(party => new Party(party) { LocalName = "OtherParty" })
            .ToList();
        TransportModeCharacteristics = root.Element("TransportModeCharacteristics") is XElement transportModeCharacteristics
            ? new TransportModeCharacteristics(transportModeCharacteristics)
            : TransportModeCharacteristics;
        TransportVehicleCharacteristics = root.Element("TransportVehicleCharacteristics") is XElement transportVehicleCharacteristics
            ? new TransportVehicleCharacteristics(transportVehicleCharacteristics)
            : TransportVehicleCharacteristics;
        TransportUnitCharacteristics = root.Element("TransportUnitCharacteristics") is XElement transportUnitCharacteristics
            ? new TransportUnitCharacteristics(transportUnitCharacteristics)
            : TransportUnitCharacteristics;
        TransportUnloadingCharacteristics = root.Element("TransportUnloadingCharacteristics") is XElement transportUnloadingCharacteristics
            ? new TransportUnloadingCharacteristics(transportUnloadingCharacteristics)
            : TransportUnloadingCharacteristics;
        TransportOtherInstructions = root.Element("TransportOtherInstructions") is XElement transportOtherInstructions
            ? new TransportOtherInstructions(transportOtherInstructions)
            : TransportOtherInstructions;
        Route = root.Elements("Route")
            .Select(route => new Route(route))
            .ToList();
        DeliveryTransitTime = root.Element("DeliveryTransitTime") is XElement deliveryTransitTime
            ? new DeliveryTransitTime(deliveryTransitTime)
            : DeliveryTransitTime;
        DeliveryDestination = root.Element("DeliveryDestination") is XElement deliveryDestination
            ? new DeliveryDestination(deliveryDestination)
            : DeliveryDestination;
        DeliveryDateWindow = root.Elements("DeliveryDateWindow")
            .Select(window => new DeliveryDateWindow(window))
            .ToList();
        DeliveryLegReference = root.Elements("DeliveryLegReference")
            .Select(reference => new DeliveryLegReference(reference))
            .ToList();
        TermsOfChartering = root.Elements("TermsOfChartering")
            .Select(chartering => new TermsOfChartering(chartering))
            .ToList();
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("DeliveryLeg",
            DeliveryModeType != null ? new XAttribute("DeliveryModeType", DeliveryModeType) : null,
            DeliveryLegType != null ? new XAttribute("DeliveryLegType", DeliveryLegType) : null,
            EventType != null ? new XAttribute("EventType", EventType) : null,
            LegStageType != null ? new XAttribute("LegStageType", LegStageType) : null,
            new XElement("DeliveryLegSequenceNumber", DeliveryLegSequenceNumber),
            XElement.Parse($"{DeliveryOrigin}"),
            CarrierParty != null ? XElement.Parse($"{CarrierParty}") : null,
            OtherParty.Select(party => XElement.Parse($"{party}")),
            TransportModeCharacteristics != null ? XElement.Parse($"{TransportModeCharacteristics}") : null,
            TransportVehicleCharacteristics != null ? XElement.Parse($"{TransportVehicleCharacteristics}") : null,
            TransportUnitCharacteristics != null ? XElement.Parse($"{TransportUnitCharacteristics}") : null,
            TransportUnloadingCharacteristics != null ? XElement.Parse($"{TransportUnloadingCharacteristics}") : null,
            TransportOtherInstructions != null ? XElement.Parse($"{TransportOtherInstructions}") : null,
            Route.Select(route => XElement.Parse($"{route}")),
            DeliveryTransitTime != null ? XElement.Parse($"{DeliveryTransitTime}") : null,
            DeliveryDestination != null ? XElement.Parse($"{DeliveryDestination}") : null,
            DeliveryDateWindow.Select(window => XElement.Parse($"{window}")),
            DeliveryLegReference.Select(reference => XElement.Parse($"{reference}")),
            TermsOfChartering.Select(chartering => XElement.Parse($"{chartering}")),
            Value
        ).ToString();
    }
}

public class TermsOfChartering
{
    public TermsOfCharteringType? TermsOfCharteringType = null;
    public string Value = string.Empty;

    public TermsOfChartering() { }

    public TermsOfChartering(XElement root)
    {
        TermsOfCharteringType = root.Attribute("TermsOfCharteringType") is XAttribute termsOfCharteringType
            ? Enum.Parse<TermsOfCharteringType>(termsOfCharteringType.Value)
            : TermsOfCharteringType;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TermsOfChartering",
            TermsOfCharteringType != null ? new XAttribute("TermsOfCharteringType", TermsOfCharteringType) : null,
            Value
        ).ToString();
    }
}

public class DeliveryLegReference
{
    public DeliveryLegReferenceType DeliveryLegReferenceType = DeliveryLegReferenceType.Other;
    public AssignedBy? AssignedBy = null;
    public string Value = string.Empty;

    public DeliveryLegReference() { }

    public DeliveryLegReference(XElement root)
    {
        DeliveryLegReferenceType = root.Attribute("DeliveryLegReferenceType") is XAttribute deliveryLegReferenceType
            ? Enum.Parse<DeliveryLegReferenceType>(deliveryLegReferenceType.Value)
            : DeliveryLegReferenceType;
        AssignedBy = root.Attribute("AssignedBy") is XAttribute assignedBy
            ? Enum.Parse<AssignedBy>(assignedBy.Value)
            : AssignedBy;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("DeliveryLegReference",
            new XAttribute("DeliveryLegReferenceType", DeliveryLegReferenceType),
            AssignedBy != null ? new XAttribute("AssignedBy", AssignedBy) : null,
            Value
        ).ToString();
    }
}

public class DeliveryDestination
{
    public Date? Date = null;
    public Time? Time = null;
    public Party LocationParty = new() { LocalName = "LocationParty" };
    public SupplyPoint? SupplyPoint = null;
    public LocationCode? LocationCode = null;
    public GPSCoordinates? GPSCoordinates = null;
    public MapCoordinates? MapCoordinates = null;
    public string Value = string.Empty;

    public DeliveryDestination() { }

    public DeliveryDestination(XElement root)
    {
        Date = root.Element("Date") is XElement date
            ? new Date(date)
            : Date;
        Time = root.Element("Time") is XElement time
            ? new Time(time)
            : Time;
        LocationParty = root.Element("LocationParty") is XElement locationParty
            ? new Party(locationParty) { LocalName = "LocationParty" }
            : LocationParty;
        LocationCode = root.Element("LocationCode") is XElement locationCode
            ? new LocationCode(locationCode)
            : LocationCode;
        GPSCoordinates = root.Element("GPSCoordinates") is XElement gpsCoordinates
            ? new GPSCoordinates(gpsCoordinates)
            : GPSCoordinates;
        MapCoordinates = root.Element("MapCoordinates") is XElement mapCoordinates
            ? new MapCoordinates(mapCoordinates)
            : MapCoordinates;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("DeliveryDestination",
            Date != null ? XElement.Parse($"{Date}") : null,
            Time != null ? XElement.Parse($"{Time}") : null,
            LocationParty != null ? XElement.Parse($"{LocationParty}") : null,
            LocationCode != null ? XElement.Parse($"{LocationCode}") : null,
            GPSCoordinates != null ? XElement.Parse($"{GPSCoordinates}") : null,
            MapCoordinates != null ? XElement.Parse($"{MapCoordinates}") : null,
            Value
        ).ToString();
    }
}

public class DeliveryTransitTime
{
    public string Days = string.Empty;
    public string? Hours = null;
    public string? Minutes = null;

    public DeliveryTransitTime() { }

    public DeliveryTransitTime(XElement root)
    {
        Days = root.Element("Days")?.Value ?? Days;
        Hours = root.Element("Hours")?.Value ?? Hours;
        Minutes = root.Element("Minutes")?.Value ?? Minutes;
    }

    public override string ToString()
    {
        return new XElement("DeliveryTransitTime",
            new XElement("Days", Days),
            Hours != null ? new XElement("Hours", Hours) : null,
            Minutes != null ? new XElement("Minutes", Minutes) : null
        ).ToString();
    }
}

public class Route
{
    public RouteType RouteType = RouteType.DeliveryOriginToDeliveryDestination;
    public string RouteName = string.Empty;
    public List<string> RouteComment = [];
    public List<SupplyPoint> SupplyPoint = [];
    public List<MapPoint> MapPoint = [];
    public string? RouteLength = null;
    public string? RouteDefinition = null;
    public eAttachment? eAttachment = null;
    public List<RouteLeg> RouteLeg = [];
    public string RootValue = string.Empty;

    public Route() { }

    public Route(XElement root)
    {
        RouteType = root.Attribute("RouteType") is XAttribute routeType
            ? Enum.Parse<RouteType>(routeType.Value)
            : RouteType;
        RouteName = root.Element("RouteName")?.Value ?? RouteName;
        RouteComment = root.Elements("RouteComment")
            .Select(comment => comment.Value)
            .ToList();
        SupplyPoint = root.Elements("SupplyPoint")
            .Select(point => new SupplyPoint(point))
            .ToList();
        MapPoint = root.Elements("MapPoint")
            .Select(point => new MapPoint(point))
            .ToList();
        RootValue = root.Value;
    }

    public override string ToString()
    {
        return new XElement("Route",
            new XAttribute("RouteType", RouteType),
            new XElement("RouteName", RouteName),
            RouteComment.Select(comment => new XElement("RouteComment", comment)),
            SupplyPoint.Select(point => XElement.Parse($"{point}")),
            MapPoint.Select(point => XElement.Parse($"{point}")),
            RootValue
        ).ToString();
    }
}

public class RouteLeg
{
    public string RouteLegNumber = string.Empty;
    public string? RouteLegName = null;
    public List<Party> OtherParty = [];
    public MapPoint? MapPoint = null;
    public RouteLegLength? RouteLegLength = null;
    public RoadCharacteristics? RoadCharacteristics = null;
    public eAttachment? eAttachment = null;
    public List<string> AdditionalText = [];

    public RouteLeg() { }

    public RouteLeg(XElement root)
    {
        RouteLegNumber = root.Element("RouteLegNumber")?.Value ?? RouteLegNumber;
        RouteLegName = root.Element("RouteLegName")?.Value ?? RouteLegName;
        OtherParty = root.Elements("OtherParty")
            .Select(party => new Party(party) { LocalName = "OtherParty" })
            .ToList();
        MapPoint = root.Element("MapPoint") is XElement mapPoint
            ? new MapPoint(mapPoint)
            : MapPoint;
        RouteLegLength = root.Element("RouteLegLength") is XElement routeLegLength
            ? new RouteLegLength(routeLegLength)
            : RouteLegLength;
        RoadCharacteristics = root.Element("RoadCharacteristics") is XElement roadCharacteristics
            ? new RoadCharacteristics(roadCharacteristics)
            : RoadCharacteristics;
        eAttachment = root.Element("eAttachment") is XElement attachment
            ? new eAttachment(attachment)
            : eAttachment;
        AdditionalText = root.Elements("AdditionalText")
            .Select(text => text.Value)
            .ToList();
    }

    public override string ToString()
    {
        return new XElement("RouteLeg",
            RouteLegNumber != null ? new XElement("RouteLegNumber", RouteLegNumber) : null,
            RouteLegName != null ? new XElement("RouteLegName", RouteLegName) : null,
            OtherParty.Select(party => XElement.Parse($"{party}")),
            MapPoint != null ? XElement.Parse($"{MapPoint}") : null,
            RouteLegLength != null ? XElement.Parse($"{RouteLegLength}") : null,
            RoadCharacteristics != null ? XElement.Parse($"{RoadCharacteristics}") : null,
            eAttachment != null ? XElement.Parse($"{eAttachment}") : null,
            AdditionalText.Select(text => new XElement("AdditionalText", text))
        ).ToString();
    }
}

public class RoadCharacteristics
{
    public RoadOwnerType? RoadOwnerType = null;
    public RoadKeeperType? RoadKeeperType = null;
    public RoadAccessibilityType? RoadAccessibilityType = null;
    public RoadTurningPossibilityType? RoadTurningPossibilityType = null;
    public RoadTurningPointType? RoadTurningPointType = null;
    public RoadPassingPossibility? RoadPassingPossibility = null;
    public string? RoadName = null;
    public string? RoadNumber = null;
    public List<RoadClassification> RoadClassification = [];
    public List<RoadAvailability> RoadAvailability = [];
    public List<RoadBearingCapacity> RoadBearingCapacity = [];
    public List<RoadObstruction> RoadObstruction = [];

    public RoadCharacteristics() { }

    public RoadCharacteristics(XElement root)
    {
        RoadOwnerType = root.Attribute("RoadOwnerType") is XAttribute roadOwnerType
            ? Enum.Parse<RoadOwnerType>(roadOwnerType.Value)
            : RoadOwnerType;
        RoadKeeperType = root.Attribute("RoadKeeperType") is XAttribute roadKeeperType
            ? Enum.Parse<RoadKeeperType>(roadKeeperType.Value)
            : RoadKeeperType;
        RoadAccessibilityType = root.Attribute("RoadAccessibilityType") is XAttribute roadAccessibilityType
            ? Enum.Parse<RoadAccessibilityType>(roadAccessibilityType.Value)
            : RoadAccessibilityType;
        RoadTurningPossibilityType = root.Attribute("RoadTurningPossibilityType") is XAttribute roadTurningPossibilityType
            ? Enum.Parse<RoadTurningPossibilityType>(roadTurningPossibilityType.Value)
            : RoadTurningPossibilityType;
        RoadTurningPointType = root.Attribute("RoadTurningPointType") is XAttribute roadTurningPointType
            ? Enum.Parse<RoadTurningPointType>(roadTurningPointType.Value)
            : RoadTurningPointType;
        RoadPassingPossibility = root.Attribute("RoadPassingPossibility") is XAttribute roadPassingPossibility
            ? Enum.Parse<RoadPassingPossibility>(roadPassingPossibility.Value)
            : RoadPassingPossibility;
        RoadName = root.Element("RoadName")?.Value ?? RoadName;
        RoadNumber = root.Element("RoadNumber")?.Value ?? RoadNumber;
        RoadClassification = root.Elements("RoadClassification")
            .Select(classification => new RoadClassification(classification))
            .ToList();
        RoadAvailability = root.Elements("RoadAvailability")
            .Select(availability => Enum.Parse<RoadAvailability>(availability.Value))
            .ToList();
        RoadBearingCapacity = root.Elements("RoadBearingCapacity")
            .Select(capacity => new RoadBearingCapacity(capacity))
            .ToList();
        RoadObstruction = root.Elements("RoadObstruction")
            .Select(obstruction => new RoadObstruction(obstruction))
            .ToList();
    }

    public override string ToString()
    {
        return new XElement("RoadCharacteristics",
            RoadOwnerType != null ? new XAttribute("RoadOwnerType", RoadOwnerType) : null,
            RoadKeeperType != null ? new XAttribute("RoadKeeperType", RoadKeeperType) : null,
            RoadAccessibilityType != null ? new XAttribute("RoadAccessibilityType", RoadAccessibilityType) : null,
            RoadTurningPossibilityType != null ? new XAttribute("RoadTurningPossibilityType", RoadTurningPossibilityType) : null,
            RoadTurningPointType != null ? new XAttribute("RoadTurningPointType", RoadTurningPointType) : null,
            RoadPassingPossibility != null ? new XAttribute("RoadPassingPossibility", RoadPassingPossibility) : null,
            RoadName != null ? new XElement("RoadName", RoadName) : null,
            RoadNumber != null ? new XElement("RoadNumber", RoadNumber) : null,
            RoadClassification.Select(classification => XElement.Parse($"{classification}")),
            RoadAvailability.Select(availability => XElement.Parse($"{availability}")),
            RoadBearingCapacity.Select(capacity => XElement.Parse($"{capacity}")),
            RoadObstruction.Select(obstruction => XElement.Parse($"{obstruction}"))
        ).ToString();
    }
}

public class RoadObstruction
{
    public RoadObstructionType RoadObstructionType = RoadObstructionType.Passage;
    public string? MapPointName = null;
    public List<string> MapPointComment = [];
    public List<MapCoordinates> MapCoordinates = [];
    public string? RoadSlopePercent = null;
    public List<RoadBearingCapacity> RoadBearingCapacity = [];
    public Length_Object? Length = null;
    public Width_Object? Width = null;
    public Height_Object? Height = null;
    public eAttachment? eAttachment = null;
    public List<string> AdditionalText = [];

    public RoadObstruction() { }

    public RoadObstruction(XElement root)
    {
        RoadObstructionType = root.Attribute("RoadObstructionType") is XAttribute roadObstructionType
            ? Enum.Parse<RoadObstructionType>(roadObstructionType.Value)
            : RoadObstructionType;
        MapPointName = root.Element("MapPointName")?.Value ?? MapPointName;
        MapPointComment = root.Elements("MapPointComment")
            .Select(comment => comment.Value)
            .ToList();
        MapCoordinates = root.Elements("MapCoordinates")
            .Select(coordinates => new MapCoordinates(coordinates))
            .ToList();
        RoadSlopePercent = root.Element("RoadSlopePercent")?.Value ?? RoadSlopePercent;
        RoadBearingCapacity = root.Elements("RoadBearingCapacity")
            .Select(capacity => new RoadBearingCapacity(capacity))
            .ToList();
        Length = root.Element("Length") is XElement length
            ? new Length_Object(length)
            : Length;
        Width = root.Element("Width") is XElement width
            ? new Width_Object(width)
            : Width;
        Height = root.Element("Height") is XElement height
            ? new Height_Object(height)
            : Height;
        eAttachment = root.Element("eAttachment") is XElement attachment
            ? new eAttachment(attachment)
            : eAttachment;
        AdditionalText = root.Elements("AdditionalText")
            .Select(text => text.Value)
            .ToList();
    }

    public override string ToString()
    {
        return new XElement("RoadObstruction",
            new XAttribute("RoadObstructionType", RoadObstructionType),
            MapPointName != null ? new XElement("MapPointName", MapPointName) : null,
            MapPointComment.Select(comment => new XElement("MapPointComment", comment)),
            MapCoordinates.Select(coordinates => XElement.Parse($"{coordinates}")),
            RoadSlopePercent != null ? new XElement("RoadSlopePercent", RoadSlopePercent) : null,
            RoadBearingCapacity.Select(capacity => XElement.Parse($"{capacity}")),
            Length != null ? XElement.Parse($"{Length}") : null,
            Width != null ? XElement.Parse($"{Width}") : null,
            Height != null ? XElement.Parse($"{Height}") : null,
            eAttachment != null ? XElement.Parse($"{eAttachment}") : null,
            AdditionalText.Select(text => new XElement("AdditionalText", text))
        ).ToString();
    }
}

public class Height_Object
{
    public Value Value = new();
    public RangeMin? RangeMin = null;
    public RangeMax? RangeMax = null;

    public Height_Object() { }

    public Height_Object(XElement root)
    {
        Value = root.Element("Value") is XElement value
            ? new Value(value)
            : Value;
        RangeMin = root.Element("RangeMin") is XElement rangeMin
            ? new RangeMin(rangeMin)
            : RangeMin;
        RangeMax = root.Element("RangeMax") is XElement rangeMax
            ? new RangeMax(rangeMax)
            : RangeMax;
    }

    public override string ToString()
    {
        return new XElement("Height",
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class Width_Object
{
    public Value Value = new();
    public RangeMin? RangeMin = null;
    public RangeMax? RangeMax = null;

    public Width_Object() { }

    public Width_Object(XElement root)
    {
        Value = root.Element("Value") is XElement value
            ? new Value(value)
            : Value;
        RangeMin = root.Element("RangeMin") is XElement rangeMin
            ? new RangeMin(rangeMin)
            : RangeMin;
        RangeMax = root.Element("RangeMax") is XElement rangeMax
            ? new RangeMax(rangeMax)
            : RangeMax;
    }

    public override string ToString()
    {
        return new XElement("Width",
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class Length_Object
{
    public Value Value = new();
    public RangeMin? RangeMin = null;
    public RangeMax? RangeMax = null;

    public Length_Object() { }

    public Length_Object(XElement root)
    {
        Value = root.Element("Value") is XElement value
            ? new Value(value)
            : Value;
        RangeMin = root.Element("RangeMin") is XElement rangeMin
            ? new RangeMin(rangeMin)
            : RangeMin;
        RangeMax = root.Element("RangeMax") is XElement rangeMax
            ? new RangeMax(rangeMax)
            : RangeMax;
    }

    public override string ToString()
    {
        return new XElement("Length",
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class RoadBearingCapacity
{
    public RoadBearingCapacityType? RoadBearingCapacityType = null;
    public Value Value = new();
    public RangeMin? RangeMin = null;
    public RangeMax? RangeMax = null;

    public RoadBearingCapacity() { }

    public RoadBearingCapacity(XElement root)
    {
        RoadBearingCapacityType = root.Attribute("RoadBearingCapacityType") is XAttribute roadBearingCapacityType
            ? Enum.Parse<RoadBearingCapacityType>(roadBearingCapacityType.Value)
            : RoadBearingCapacityType;
        Value = root.Element("Value") is XElement value
            ? new Value(value)
            : Value;
        RangeMin = root.Element("RangeMin") is XElement rangeMin
            ? new RangeMin(rangeMin)
            : RangeMin;
        RangeMax = root.Element("RangeMax") is XElement rangeMax
            ? new RangeMax(rangeMax)
            : RangeMax;
    }

    public override string ToString()
    {
        return new XElement("RoadBearingCapacity",
            RoadBearingCapacityType != null ? new XAttribute("RoadBearingCapacityType", RoadBearingCapacityType) : null,
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class RoadClassification
{
    public string? RoadClassificationCode = null;
    public List<string> RoadClassificationDescription = [];
    public string RootValue = string.Empty;

    public RoadClassification() { }

    public RoadClassification(XElement root)
    {
        RoadClassificationCode = root.Element("RoadClassificationCode")?.Value ?? RoadClassificationCode;
        RoadClassificationDescription = root.Elements("RoadClassificationDescription")
            .Select(description => description.Value)
            .ToList();
        RootValue = root.Value;
    }

    public override string ToString()
    {
        return new XElement("RoadClassification",
            RoadClassificationCode != null ? new XElement("RoadClassificationCode", RoadClassificationCode) : null,
            RoadClassificationDescription.Select(description => new XElement("RoadClassificationDescription", description)),
            RootValue
        ).ToString();
    }
}

public class RouteLegLength
{
    public Value Value = new();
    public RangeMin? RangeMin = null;
    public RangeMax? RangeMax = null;

    public RouteLegLength() { }

    public RouteLegLength(XElement root)
    {
        Value = root.Element("Value") is XElement value
            ? new Value(value)
            : Value;
        RangeMin = root.Element("RangeMin") is XElement rangeMin
            ? new RangeMin(rangeMin)
            : RangeMin;
        RangeMax = root.Element("RangeMax") is XElement rangeMax
            ? new RangeMax(rangeMax)
            : RangeMax;
    }

    public override string ToString()
    {
        return new XElement("RouteLegLength",
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class eAttachment
{
    public string? AttachmentFileName = null;
    public string? NumberOfAttachments = null;
    public List<URL> URL = [];
    public string RootValue = string.Empty;

    public eAttachment() { }

    public eAttachment(XElement root)
    {
        AttachmentFileName = root.Element("AttachmentFileName")?.Value ?? AttachmentFileName;
        NumberOfAttachments = root.Element("NumberOfAttachments")?.Value ?? NumberOfAttachments;
        URL = root.Elements("URL")
            .Select(url => new URL(url))
            .ToList();
        RootValue = root.Value;
    }

    public override string ToString()
    {
        return new XElement("eAttachment",
            AttachmentFileName != null ? new XElement("AttachmentFileName", AttachmentFileName) : null,
            NumberOfAttachments != null ? new XElement("NumberOfAttachments", NumberOfAttachments) : null,
            URL.Select(url => XElement.Parse($"{url}")),
            RootValue
        ).ToString();
    }
}

public class MapPoint
{
    public MapPointType? MapPointType = null;
    public string MapPointName = string.Empty;
    public List<string> MapPointComment = [];
    public List<MapCoordinates> MapCoordinates = [];
    public string Value = string.Empty;

    public MapPoint() { }

    public MapPoint(XElement root)
    {
        MapPointType = root.Attribute("MapPointType") is XAttribute mapPointType
            ? Enum.Parse<MapPointType>(mapPointType.Value)
            : MapPointType;
        MapPointName = root.Element("MapPointName")?.Value ?? MapPointName;
        MapPointComment = root.Elements("MapPointComment")
            .Select(comment => comment.Value)
            .ToList();
        MapCoordinates = root.Elements("MapCoordinates")
            .Select(coordinates => new MapCoordinates(coordinates))
            .ToList();
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("MapPoint",
            MapPointType != null ? new XAttribute("MapPointType", MapPointType) : null,
            new XElement("MapPointName", MapPointName),
            MapPointComment.Select(comment => new XElement("MapPointComment", comment)),
            MapCoordinates.Select(coordinates => XElement.Parse($"{coordinates}")),
            Value
        ).ToString();
    }
}

public class TransportOtherInstructions
{
    public TransportInstructionType? TransportInstructionType = null;
    public TransportInstructionCode? TransportInstructionCode = null;
    public List<string> TransportInstructionText = [];
    public string Value = string.Empty;

    public TransportOtherInstructions() { }

    public TransportOtherInstructions(XElement root)
    {
        TransportInstructionType = root.Attribute("TransportInstructionType") is XAttribute transportInstructionType
            ? Enum.Parse<TransportInstructionType>(transportInstructionType.Value)
            : TransportInstructionType;
        TransportInstructionCode = root.Element("TransportInstructionCode") is XElement transportInstructionCode
            ? new TransportInstructionCode(transportInstructionCode)
            : TransportInstructionCode;
        TransportInstructionText = root.Elements("TransportInstructionText")
            .Select(text => text.Value)
            .ToList();
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportOtherInstructions",
            TransportInstructionType != null ? new XAttribute("TransportInstructionType", TransportInstructionType) : null,
            TransportInstructionCode != null ? XElement.Parse($"{TransportInstructionCode}") : null,
            TransportInstructionText.Select(text => new XElement("TransportInstructionText", text)),
            Value
        ).ToString();
    }
}

public class TransportInstructionCode
{
    public Agency Agency = Agency.Other;
    public string Value = string.Empty;

    public TransportInstructionCode() { }

    public TransportInstructionCode(XElement root)
    {
        Agency = root.Attribute("Agency") is XAttribute agency
            ? Enum.Parse<Agency>(agency.Value)
            : Agency;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportInstructionCode",
            new XAttribute("Agency", Agency),
            Value
        ).ToString();
    }
}

public class TransportUnloadingCharacteristics
{
    public TransportUnloadingType? TransportUnloadingType = null;
    public DirectUnloading? DirectUnloading = null;
    public TransportUnloadingCode? TransportUnloadingCode = null;
    public TransportUnloadingCodeDescription? TransportUnloadingCodeDescription = null;
    public List<string> TransportUnloadingText = [];
    public string Value = string.Empty;

    public TransportUnloadingCharacteristics() { }

    public TransportUnloadingCharacteristics(XElement root)
    {
        TransportUnloadingType = root.Attribute("TransportUnloadingType") is XAttribute transportUnloadingType
            ? Enum.Parse<TransportUnloadingType>(transportUnloadingType.Value)
            : TransportUnloadingType;
        DirectUnloading = root.Attribute("DirectUnloading") is XAttribute directUnloading
            ? Enum.Parse<DirectUnloading>(directUnloading.Value)
            : DirectUnloading;
        TransportUnloadingCode = root.Element("TransportUnloadingCode") is XElement transportUnloadingCode
            ? new TransportUnloadingCode(transportUnloadingCode)
            : TransportUnloadingCode;
        TransportUnloadingCodeDescription = root.Element("TransportUnloadingCodeDescription") is XElement transportUnloadingCodeDescription
            ? new TransportUnloadingCodeDescription(transportUnloadingCodeDescription)
            : TransportUnloadingCodeDescription;
        TransportUnloadingText = root.Elements("TransportUnloadingText")
            .Select(text => text.Value)
            .ToList();
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportUnloadingCharacteristics",
            TransportUnloadingType != null ? new XAttribute("TransportUnloadingType", TransportUnloadingType) : null,
            DirectUnloading != null ? new XAttribute("DirectUnloading", DirectUnloading) : null,
            TransportUnloadingCode != null ? XElement.Parse($"{TransportUnloadingCode}") : null,
            TransportUnloadingCodeDescription != null ? XElement.Parse($"{TransportUnloadingCodeDescription}") : null,
            TransportUnloadingText.Select(text => new XElement("TransportUnloadingText", text)),
            Value
        ).ToString();
    }
}

public class TransportUnloadingCodeDescription
{
    public List<string> AdditionalText = [];
    public e_Attachment? e_Attachment = null;
    public string Value = string.Empty;

    public TransportUnloadingCodeDescription() { }

    public TransportUnloadingCodeDescription(XElement root)
    {
        AdditionalText = root.Elements("AdditionalText")
            .Select(text => text.Value)
            .ToList();
        e_Attachment = root.Element("Attachment") is XElement attachment
            ? new e_Attachment(attachment)
            : e_Attachment;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportUnloadingCodeDescription",
            AdditionalText.Select(text => new XElement("AdditionalText", text)),
            e_Attachment != null ? XElement.Parse($"{e_Attachment}") : null,
            Value
        ).ToString();
    }
}

public class e_Attachment
{
    public string? AttachmentFileName = null;
    public string? NumberOfAttachments = null;
    public URL? URL = null;
    public string Value = string.Empty;

    public e_Attachment() { }

    public e_Attachment(XElement root)
    {
        AttachmentFileName = root.Element("AttachmentFileName")?.Value ?? AttachmentFileName;
        NumberOfAttachments = root.Element("NumberOfAttachments")?.Value ?? NumberOfAttachments;
        URL = root.Element("URL") is XElement url
            ? new URL(url)
            : URL;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("e-Attachment",
            AttachmentFileName != null ? new XElement("AttachmentFileName", AttachmentFileName) : null,
            NumberOfAttachments != null ? new XElement("NumberOfAttachments", NumberOfAttachments) : null,
            URL != null ? XElement.Parse($"{URL}") : null,
            Value
        ).ToString();
    }
}

public class URL
{
    public string? URLContext = null;
    public string Value = string.Empty;

    public URL() { }

    public URL(XElement root)
    {
        URLContext = root.Attribute("URLContext")?.Value ?? URLContext;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("URL",
            URLContext != null ? new XAttribute("URLContext", URLContext) : null,
            Value
        ).ToString();
    }
}

public class TransportUnloadingCode
{
    public Agency Agency = Agency.Other;
    public string Value = string.Empty;

    public TransportUnloadingCode() { }

    public TransportUnloadingCode(XElement root)
    {
        Agency = root.Attribute("Agency") is XAttribute agency
            ? Enum.Parse<Agency>(agency.Value)
            : Agency;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportUnloadingCode",
            new XAttribute("Agency", Agency),
            Value
        ).ToString();
    }
}

public class TransportUnitCharacteristics
{
    public TransportUnitType TransportUnitType = TransportUnitType.Other;
    public TransportUnitVariable? TransportUnitVariable = null;
    public string? TransportUnitLevel = null;
    public TransportUnitCode? TransportUnitCode = null;
    public TransportUnitMeasurements? TransportUnitMeasurements = null;
    public List<TransportUnitEquipment> TransportUnitEquipment = [];
    public string? TransportUnitCount = null;
    public List<TransportUnitIdentifier> TransportUnitIdentifier = [];
    public string? TransportUnitText = null;
    public TransportUnitDetail? TransportUnitDetail = null;

    public TransportUnitCharacteristics() { }

    public TransportUnitCharacteristics(XElement root)
    {
        TransportUnitType = root.Attribute("TransportUnitType") is XAttribute transportUnitType
            ? Enum.Parse<TransportUnitType>(transportUnitType.Value)
            : TransportUnitType;
        TransportUnitVariable = root.Attribute("TransportUnitVariable") is XAttribute transportUnitVariable
            ? Enum.Parse<TransportUnitVariable>(transportUnitVariable.Value)
            : TransportUnitVariable;
        TransportUnitLevel = root.Attribute("TransportUnitLevel")?.Value ?? TransportUnitLevel;
        TransportUnitCode = root.Element("TransportUnitCode") is XElement transportUnitCode
            ? new TransportUnitCode(transportUnitCode)
            : TransportUnitCode;
        TransportUnitMeasurements = root.Element("TransportUnitMeasurements") is XElement transportUnitMeasurements
            ? new TransportUnitMeasurements(transportUnitMeasurements)
            : TransportUnitMeasurements;
        TransportUnitEquipment = root.Elements("TransportUnitEquipment")
            .Select(equipment => new TransportUnitEquipment(equipment))
            .ToList();
        TransportUnitCount = root.Element("TransportUnitCount")?.Value ?? TransportUnitCount;
        TransportUnitIdentifier = root.Elements("TransportUnitIdentifier")
            .Select(identifier => new TransportUnitIdentifier(identifier))
            .ToList();
        TransportUnitText = root.Element("TransportUnitText")?.Value ?? TransportUnitText;
        TransportUnitDetail = root.Element("TransportUnitDetail") is XElement transportUnitDetail
            ? new TransportUnitDetail(transportUnitDetail)
            : TransportUnitDetail;
    }

    public override string ToString()
    {
        return new XElement("TransportUnitCharacteristics",
            new XAttribute("TransportUnitType", TransportUnitType),
            TransportUnitVariable != null ? new XAttribute("TransportUnitVariable", TransportUnitVariable) : null,
            TransportUnitLevel != null ? new XAttribute("TransportUnitLevel", TransportUnitLevel) : null,
            TransportUnitCode != null ? XElement.Parse($"{TransportUnitCode}") : null,
            TransportUnitMeasurements != null ? XElement.Parse($"{TransportUnitMeasurements}") : null,
            TransportUnitEquipment.Select(equipment =>  XElement.Parse($"{equipment}")),
            TransportUnitCount != null ? new XElement("TransportUnitCount", TransportUnitCount) : null,
            TransportUnitIdentifier.Select(identifier => XElement.Parse($"{identifier}")),
            TransportUnitText != null ? new XElement("TransportUnitText", TransportUnitText) : null,
            TransportUnitDetail != null ? XElement.Parse($"{TransportUnitDetail}") : null
        ).ToString();
    }
}

public class TransportUnitDetail
{
    public TransportUnitDetailType? TransportUnitDetailType = null;
    public LoadOpeningSide? LoadOpeningSide = null;
    public TransportUnitDetailCode? TransportUnitDetailCode = null;
    public List<string> AdditionalText = [];

    public TransportUnitDetail() { }

    public TransportUnitDetail(XElement root)
    {
        TransportUnitDetailType = root.Attribute("TransportUnitDetailType") is XAttribute transportUnitDetailType
            ? Enum.Parse<TransportUnitDetailType>(transportUnitDetailType.Value)
            : TransportUnitDetailType;
        LoadOpeningSide = root.Attribute("LoadOpeningSide") is XAttribute loadOpeningSide
            ? Enum.Parse<LoadOpeningSide>(loadOpeningSide.Value)
            : LoadOpeningSide;
        TransportUnitDetailCode = root.Element("TransportUnitDetailCode") is XElement transportUnitDetailCode
            ? new TransportUnitDetailCode(transportUnitDetailCode)
            : TransportUnitDetailCode;
        AdditionalText = root.Elements("AdditionalText")
            .Select(text => text.Value)
            .ToList();
    }

    public override string ToString()
    {
        return new XElement("TransportUnitDetail",
            TransportUnitDetailType != null ? new XAttribute("TransportUnitDetailType", TransportUnitDetailType) : null,
            LoadOpeningSide != null ? new XAttribute("LoadOpeningSide", LoadOpeningSide) : null,
            TransportUnitDetailCode != null ? XElement.Parse($"{TransportUnitDetailCode}") : null,
            AdditionalText.Select(text => new XElement("AdditionalText", text))
        ).ToString();
    }
}

public class TransportUnitDetailCode
{
    public Agency Agency = Agency.Other;
    public string Value = string.Empty;

    public TransportUnitDetailCode() { }

    public TransportUnitDetailCode(XElement root)
    {
        Agency = root.Attribute("Agency") is XAttribute agency
            ? Enum.Parse<Agency>(agency.Value)
            : Agency;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportUnitDetailCode",
            new XAttribute("Agency", Agency),
            Value
        ).ToString();
    }
}

public class TransportUnitIdentifier
{
    public TransportUnitIdentifierType TransportUnitIdentifierType = TransportUnitIdentifierType.Other;
    public string? StateOrProvince = null;
    public ISOCountryCode? ISOCountryCode = null;
    public string Value = string.Empty;

    public TransportUnitIdentifier() { }

    public TransportUnitIdentifier(XElement root)
    {
        TransportUnitIdentifierType = root.Attribute("TransportUnitIdentifierType") is XAttribute transportUnitIdentifierType
            ? Enum.Parse<TransportUnitIdentifierType>(transportUnitIdentifierType.Value)
            : TransportUnitIdentifierType;
        StateOrProvince = root.Attribute("StateOrProvince")?.Value ?? StateOrProvince;
        ISOCountryCode = root.Attribute("ISOCountryCode") is XAttribute isoCountryCode
            ? Enum.Parse<ISOCountryCode>(isoCountryCode.Value)
            : ISOCountryCode;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportUnitIdentifier",
            new XAttribute("TransportUnitIdentifierType", TransportUnitIdentifierType),
            StateOrProvince != null ? new XAttribute("StateOrProvince", StateOrProvince) : null,
            ISOCountryCode != null ? new XAttribute("ISOCountryCode", ISOCountryCode) : null,
            Value
        ).ToString();
    }
}

public class TransportUnitEquipment
{
    public TransportUnitEquipmentCode? TransportUnitEquipmentCode = null;
    public List<TransportUnitEquipmentDescription> TransportUnitEquipmentDescription = [];

    public TransportUnitEquipment() { }

    public TransportUnitEquipment(XElement root)
    {
        TransportUnitEquipmentCode = root.Element("TransportUnitEquipmentCode") is XElement transportUnitEquipmentCode
            ? new TransportUnitEquipmentCode(transportUnitEquipmentCode)
            : TransportUnitEquipmentCode;
        TransportUnitEquipmentDescription = root.Elements("TransportUnitEquipmentDescription")
            .Select(description => new TransportUnitEquipmentDescription(description))
            .ToList();
    }

    public override string ToString()
    {
        return new XElement("TransportUnitEquipment",
            TransportUnitEquipmentCode != null ? XElement.Parse($"{TransportUnitEquipmentCode}") : null,
            TransportUnitEquipmentDescription.Select(description => XElement.Parse($"{description}"))
        ).ToString();
    }
}

public class TransportUnitEquipmentDescription
{
    public Language? Language = null;
    public string Value = string.Empty;

    public TransportUnitEquipmentDescription() { }

    public TransportUnitEquipmentDescription(XElement root)
    {
        Language = root.Attribute("Language") is XAttribute language
            ? Enum.Parse<Language>(language.Value)
            : Language;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportUnitEquipmentDescription",
            Language != null ? new XAttribute("Language", Language) : null,
            Value
        ).ToString();
    }
}

public class TransportUnitEquipmentCode
{
    public Agency Agency = Agency.Other;
    public string Value = string.Empty;

    public TransportUnitEquipmentCode() { }

    public TransportUnitEquipmentCode(XElement root)
    {
        Agency = root.Attribute("Agency") is XAttribute agency
            ? Enum.Parse<Agency>(agency.Value)
            : Agency;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportUnitEquipmentCode",
            new XAttribute("Agency", Agency),
            Value
        ).ToString();
    }
}

public class TransportUnitMeasurements
{
    public AppliesTo? AppliesTo = null;
    public TransportUnitLength? TransportUnitLength = null;
    public TransportUnitWidth? TransportUnitWidth = null;
    public TransportUnitHeight? TransportUnitHeight = null;
    public TransportUnitWeight? TransportUnitWeight = null;

    public TransportUnitMeasurements() { }

    public TransportUnitMeasurements(XElement root)
    {
        AppliesTo = root.Attribute("AppliesTo") is XAttribute appliesTo
            ? Enum.Parse<AppliesTo>(appliesTo.Value)
            : AppliesTo;
        TransportUnitLength = root.Element("TransportUnitLength") is XElement transportUnitLength
            ? new TransportUnitLength(transportUnitLength)
            : TransportUnitLength;
        TransportUnitWidth = root.Element("TransportUnitWidth") is XElement transportUnitWidth
            ? new TransportUnitWidth(transportUnitWidth)
            : TransportUnitWidth;
        TransportUnitHeight = root.Element("TransportUnitHeight") is XElement transportUnitHeight
            ? new TransportUnitHeight(transportUnitHeight)
            : TransportUnitHeight;
        TransportUnitWeight = root.Element("TransportUnitWeight") is XElement transportUnitWeight
            ? new TransportUnitWeight(transportUnitWeight)
            : TransportUnitWeight;
    }

    public override string ToString()
    {
        return new XElement("TransportUnitMeasurements",
            AppliesTo != null ? new XAttribute("AppliesTo", AppliesTo) : null,
            TransportUnitLength != null ? XElement.Parse($"{TransportUnitLength}") : null,
            TransportUnitWidth != null ? XElement.Parse($"{TransportUnitWidth}") : null,
            TransportUnitHeight != null ? XElement.Parse($"{TransportUnitHeight}") : null,
            TransportUnitWeight != null ? XElement.Parse($"{TransportUnitWeight}") : null
        ).ToString();
    }
}

public class TransportUnitWeight
{
    public Value Value = new();
    public RangeMin? RangeMin = null;
    public RangeMax? RangeMax = null;

    public TransportUnitWeight() { }

    public TransportUnitWeight(XElement root)
    {
        Value = root.Element("Value") is XElement value
            ? new Value(value)
            : Value;
        RangeMin = root.Element("RangeMin") is XElement rangeMin
            ? new RangeMin(rangeMin)
            : RangeMin;
        RangeMax = root.Element("RangeMax") is XElement rangeMax
            ? new RangeMax(rangeMax)
            : RangeMax;
    }

    public override string ToString()
    {
        return new XElement("TransportUnitWeight",
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class TransportUnitHeight
{
    public Value Value = new();
    public RangeMin? RangeMin = null;
    public RangeMax? RangeMax = null;

    public TransportUnitHeight() { }

    public TransportUnitHeight(XElement root)
    {
        Value = root.Element("Value") is XElement value
            ? new Value(value)
            : Value;
        RangeMin = root.Element("RangeMin") is XElement rangeMin
            ? new RangeMin(rangeMin)
            : RangeMin;
        RangeMax = root.Element("RangeMax") is XElement rangeMax
            ? new RangeMax(rangeMax)
            : RangeMax;
    }

    public override string ToString()
    {
        return new XElement("TransportUnitHeight",
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class TransportUnitWidth
{
    public Value Value = new();
    public RangeMin? RangeMin = null;
    public RangeMax? RangeMax = null;

    public TransportUnitWidth() { }

    public TransportUnitWidth(XElement root)
    {
        Value = root.Element("Value") is XElement value
            ? new Value(value)
            : Value;
        RangeMin = root.Element("RangeMin") is XElement rangeMin
            ? new RangeMin(rangeMin)
            : RangeMin;
        RangeMax = root.Element("RangeMax") is XElement rangeMax
            ? new RangeMax(rangeMax)
            : RangeMax;
    }

    public override string ToString()
    {
        return new XElement("TransportUnitWidth",
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class TransportUnitLength
{
    public Value Value = new();
    public RangeMin? RangeMin = null;
    public RangeMax? RangeMax = null;

    public TransportUnitLength() { }

    public TransportUnitLength(XElement root)
    {
        Value = root.Element("Value") is XElement value
            ? new Value(value)
            : Value;
        RangeMin = root.Element("RangeMin") is XElement rangeMin
            ? new RangeMin(rangeMin)
            : RangeMin;
        RangeMax = root.Element("RangeMax") is XElement rangeMax
            ? new RangeMax(rangeMax)
            : RangeMax;
    }

    public override string ToString()
    {
        return new XElement("TransportUnitLength",
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class TransportUnitCode
{
    public Agency Agency = Agency.Other;
    public string Value = string.Empty;

    public TransportUnitCode() { }

    public TransportUnitCode(XElement root)
    {
        Agency = root.Attribute("Agency") is XAttribute agency
            ? Enum.Parse<Agency>(agency.Value)
            : Agency;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportUnitCode",
            new XAttribute("Agency", Agency),
            Value
        ).ToString();
    }
}

public class TransportVehicleCharacteristics
{
    public TransportVehicleType? TransportVehicleType = null;
    public TransportVehicleCode? TransportVehicleCode = null;
    public TransportVehicleMeasurements? TransportVehicleMeasurements = null;
    public List<TransportVehicleEquipment> TransportVehicleEquipment = [];
    public string? TransportVehicleCount = null;
    public TransportVehicleIdentifier? TransportVehicleIdentifier = null;
    public string? TransportVehicleText = null;

    public TransportVehicleCharacteristics() { }

    public TransportVehicleCharacteristics(XElement root)
    {
        TransportVehicleType = root.Attribute("TransportVehicleType") is XAttribute transportVehicleType
            ? Enum.Parse<TransportVehicleType>(transportVehicleType.Value)
            : TransportVehicleType;
        TransportVehicleCode = root.Element("TransportVehicleCode") is XElement transportVehicleCode
            ? new TransportVehicleCode(transportVehicleCode)
            : TransportVehicleCode;
        TransportVehicleMeasurements = root.Element("TransportVehicleMeasurements") is XElement transportVehicleMeasurements
            ? new TransportVehicleMeasurements(transportVehicleMeasurements)
            : TransportVehicleMeasurements;
        TransportVehicleEquipment = root.Elements("TransportVehicleEquipment")
            .Select(equipment => new TransportVehicleEquipment(equipment))
            .ToList();
        TransportVehicleCount = root.Element("TransportVehicleCount")?.Value ?? TransportVehicleCount;
        TransportVehicleIdentifier = root.Element("TransportVehicleIdentifier") is XElement transportVehicleIdentifier
            ? new TransportVehicleIdentifier(transportVehicleIdentifier)
            : TransportVehicleIdentifier;
        TransportVehicleText = root.Element("TransportVehicleText")?.Value ?? TransportVehicleText;
    }

    public override string ToString()
    {
        return new XElement("TransportVehicleCharacteristics",
            TransportVehicleType != null ? new XAttribute("TransportVehicleType", TransportVehicleType) : null,
            TransportVehicleCode != null ? XElement.Parse($"{TransportVehicleCode}") : null,
            TransportVehicleMeasurements != null ? XElement.Parse($"{TransportVehicleMeasurements}") : null,
            TransportVehicleEquipment.Select(equipment => XElement.Parse($"{equipment}")),
            TransportVehicleCount != null ? new XElement("TransportVehicleCount", TransportVehicleCount) : null,
            TransportVehicleIdentifier != null ? XElement.Parse($"{TransportVehicleIdentifier}") : null,
            TransportVehicleText != null ? new XElement("TransportVehicleText", TransportVehicleText) : null
        ).ToString();
    }
}

public class TransportVehicleIdentifier
{
    public TransportVehicleIdentifierType? TransportVehicleIdentifierType = null;
    public string? StateOrProvince = null;
    public ISOCountryCode? ISOCountryCode = null;
    public string Value = string.Empty;

    public TransportVehicleIdentifier() { }

    public TransportVehicleIdentifier(XElement root)
    {
        TransportVehicleIdentifierType = root.Attribute("TransportVehicleIdentifierType") is XAttribute transportVehicleIdentifierType
            ? Enum.Parse<TransportVehicleIdentifierType>(transportVehicleIdentifierType.Value)
            : TransportVehicleIdentifierType;
        StateOrProvince = root.Attribute("StateOrProvince") is XAttribute stateOrProvince
            ? stateOrProvince.Value
            : StateOrProvince;
        ISOCountryCode = root.Attribute("ISOCountryCode") is XAttribute isoCountryCode
            ? Enum.Parse<ISOCountryCode>(isoCountryCode.Value)
            : ISOCountryCode;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportVehicleIdentifier",
            TransportVehicleIdentifierType != null ? new XAttribute("TransportVehicleIdentifierType", TransportVehicleIdentifierType) : null,
            StateOrProvince != null ? new XAttribute("StateOrProvince", StateOrProvince) : null,
            ISOCountryCode != null ? new XAttribute("ISOCountryCode", ISOCountryCode) : null,
            Value
        ).ToString();
    }
}

public class TransportVehicleEquipment
{
    public TransportVehicleEquipmentCode? TransportVehicleEquipmentCode = null;
    public List<TransportVehicleEquipmentDescription> TransportVehicleEquipmentDescription = [];

    public TransportVehicleEquipment() { }

    public TransportVehicleEquipment(XElement root)
    {
        TransportVehicleEquipmentCode = root.Element("TransportVehicleEquipmentCode") is XElement transportVehicleEquipmentCode
            ? new TransportVehicleEquipmentCode(transportVehicleEquipmentCode)
            : TransportVehicleEquipmentCode;
        TransportVehicleEquipmentDescription = root.Elements("TransportVehicleEquipmentDescription")
            .Select(description => new TransportVehicleEquipmentDescription(description))
            .ToList();
    }

    public override string ToString()
    {
        return new XElement("TransportVehicleEquipment",
            TransportVehicleEquipmentCode != null ? XElement.Parse($"{TransportVehicleEquipmentCode}") : null,
            TransportVehicleEquipmentDescription.Select(description => XElement.Parse($"{description}"))
        ).ToString();
    }
}

public class TransportVehicleEquipmentDescription
{
    public Language? Language = null;
    public string Value = string.Empty;

    public TransportVehicleEquipmentDescription() { }

    public TransportVehicleEquipmentDescription(XElement root)
    {
        Language = root.Attribute("Language") is XAttribute language
            ? Enum.Parse<Language>(language.Value)
            : Language;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportVehicleEquipmentDescription",
            Language != null ? new XAttribute("Language", Language) : null,
            Value
        ).ToString();
    }
}

public class TransportVehicleEquipmentCode
{
    public Agency Agency = Agency.Other;
    public string Value = string.Empty;

    public TransportVehicleEquipmentCode() { }

    public TransportVehicleEquipmentCode(XElement root)
    {
        Agency = root.Attribute("Agency") is XAttribute agency
            ? Enum.Parse<Agency>(agency.Value)
            : Agency;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportVehicleEquipmentCode",
            new XAttribute("Agency", Agency),
            Value
        ).ToString();
    }
}

public class TransportVehicleMeasurements
{
    public TransportVehicleLength? TransportVehicleLength = null;
    public TransportVehicleWidth? TransportVehicleWidth = null;
    public TransportVehicleHeight? TransportVehicleHeight = null;
    public TransportVehicleWeight? TransportVehicleWeight = null;

    public TransportVehicleMeasurements() { }

    public TransportVehicleMeasurements(XElement root)
    {
        TransportVehicleLength = root.Element("TransportVehicleLength") is XElement transportVehicleLength
            ? new TransportVehicleLength(transportVehicleLength)
            : TransportVehicleLength;
        TransportVehicleWidth = root.Element("TransportVehicleWidth") is XElement transportVehicleWidth
            ? new TransportVehicleWidth(transportVehicleWidth)
            : TransportVehicleWidth;
        TransportVehicleHeight = root.Element("TransportVehicleHeight") is XElement transportVehicleHeight
            ? new TransportVehicleHeight(transportVehicleHeight)
            : TransportVehicleHeight;
        TransportVehicleWeight = root.Element("TransportVehicleWeight") is XElement transportVehicleWeight
            ? new TransportVehicleWeight(transportVehicleWeight)
            : TransportVehicleWeight;
    }

    public override string ToString()
    {
        return new XElement("TransportVehicleMeasurements",
            TransportVehicleLength != null ? XElement.Parse($"{TransportVehicleLength}") : null,
            TransportVehicleWidth != null ? XElement.Parse($"{TransportVehicleWidth}") : null,
            TransportVehicleHeight != null ? XElement.Parse($"{TransportVehicleHeight}") : null,
            TransportVehicleWeight != null ? XElement.Parse($"{TransportVehicleWeight}") : null
        ).ToString();
    }
}

public class TransportVehicleWeight
{
    public Value Value = new();
    public RangeMin? RangeMin = null;
    public RangeMax? RangeMax = null;

    public TransportVehicleWeight() { }

    public TransportVehicleWeight(XElement root)
    {
        Value = root.Element("Value") is XElement value
            ? new Value(value)
            : Value;
        RangeMin = root.Element("RangeMin") is XElement rangeMin
            ? new RangeMin(rangeMin)
            : RangeMin;
        RangeMax = root.Element("RangeMax") is XElement rangeMax
            ? new RangeMax(rangeMax)
            : RangeMax;
    }

    public override string ToString()
    {
        return new XElement("TransportVehicleWeight",
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class TransportVehicleHeight
{
    public Value Value = new();
    public RangeMin? RangeMin = null;
    public RangeMax? RangeMax = null;

    public TransportVehicleHeight() { }

    public TransportVehicleHeight(XElement root)
    {
        Value = root.Element("Value") is XElement value
            ? new Value(value)
            : Value;
        RangeMin = root.Element("RangeMin") is XElement rangeMin
            ? new RangeMin(rangeMin)
            : RangeMin;
        RangeMax = root.Element("RangeMax") is XElement rangeMax
            ? new RangeMax(rangeMax)
            : RangeMax;
    }

    public override string ToString()
    {
        return new XElement("TransportVehicleHeight",
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class TransportVehicleWidth
{
    public Value Value = new();
    public RangeMin? RangeMin = null;
    public RangeMax? RangeMax = null;

    public TransportVehicleWidth() { }

    public TransportVehicleWidth(XElement root)
    {
        Value = root.Element("Value") is XElement value
            ? new Value(value)
            : Value;
        RangeMin = root.Element("RangeMin") is XElement rangeMin
            ? new RangeMin(rangeMin)
            : RangeMin;
        RangeMax = root.Element("RangeMax") is XElement rangeMax
            ? new RangeMax(rangeMax)
            : RangeMax;
    }

    public override string ToString()
    {
        return new XElement("TransportVehicleWidth",
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class TransportVehicleLength
{
    public Value Value = new();
    public RangeMin? RangeMin = null;
    public RangeMax? RangeMax = null;

    public TransportVehicleLength() { }

    public TransportVehicleLength(XElement root)
    {
        Value = root.Element("Value") is XElement value
            ? new Value(value)
            : Value;
        RangeMin = root.Element("RangeMin") is XElement rangeMin
            ? new RangeMin(rangeMin)
            : RangeMin;
        RangeMax = root.Element("RangeMax") is XElement rangeMax
            ? new RangeMax(rangeMax)
            : RangeMax;
    }

    public override string ToString()
    {
        return new XElement("TransportVehicleLength",
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class TransportVehicleCode
{
    public Agency Agency = Agency.Other;
    public string Value = string.Empty;

    public TransportVehicleCode() { }

    public TransportVehicleCode(XElement root)
    {
        Agency = root.Attribute("Agency") is XAttribute agency
            ? Enum.Parse<Agency>(agency.Value)
            : Agency;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportVehicleCode",
            new XAttribute("Agency", Agency),
            Value
        ).ToString();
    }
}

public class TransportModeCharacteristics
{
    public TransportModeType? TransportModeType = null;
    public TransportModeCode? TransportModeCode = null;
    public string? TransportModeText = null;

    public TransportModeCharacteristics() { }

    public TransportModeCharacteristics(XElement root)
    {
        TransportModeType = root.Attribute("TransportModeType") is XAttribute transportModeType
            ? Enum.Parse<TransportModeType>(transportModeType.Value)
            : TransportModeType;
        TransportModeCode = root.Element("TransportModeCode") is XElement transportModeCode
            ? new TransportModeCode(transportModeCode)
            : TransportModeCode;
        TransportModeText = root.Element("TransportModeText")?.Value ?? TransportModeText;
    }

    public override string ToString()
    {
        return new XElement("TransportModeCharacteristics",
            TransportModeType != null ? new XAttribute("TransportModeType", TransportModeType) : null,
            TransportModeCode != null ? XElement.Parse($"{TransportModeCode}") : null,
            TransportModeText != null ? new XElement("TransportModeText", TransportModeText) : null
        ).ToString();
    }
}

public class TransportModeCode
{
    public Agency Agency = Agency.Other;
    public string Value = string.Empty;

    public TransportModeCode() { }

    public TransportModeCode(XElement root)
    {
        Agency = root.Attribute("Agency") is XAttribute agency
            ? Enum.Parse<Agency>(agency.Value)
            : Agency;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportModeCode",
            new XAttribute("Agency", Agency),
            Value
        ).ToString();
    }
}

public class DeliveryOrigin
{
    public Date? Date = null;
    public Time? Time = null;
    public Party LocationParty = new() { LocalName = "LocationParty" };
    public SupplyPoint? SupplyPoint = null;
    public LocationCode? LocationCode = null;
    public GPSCoordinates? GPSCoordinates = null;
    public MapCoordinates? MapCoordinates = null;

    public DeliveryOrigin() { }

    public DeliveryOrigin(XElement root)
    {
        Date = root.Element("Date") is XElement date
            ? new Date(date)
            : Date;
        Time = root.Element("Time") is XElement time
            ? new Time(time)
            : Time;
        LocationParty = root.Element("LocationParty") is XElement locationParty
            ? new Party(locationParty)
            : LocationParty;
        SupplyPoint = root.Element("SupplyPoint") is XElement supplyPoint
            ? new SupplyPoint(supplyPoint)
            : SupplyPoint;
        LocationCode = root.Element("LocationCode") is XElement locationCode
            ? new LocationCode(locationCode)
            : LocationCode;
        GPSCoordinates = root.Element("GPSCoordinates") is XElement gpsCoordinates
            ? new GPSCoordinates(gpsCoordinates)
            : GPSCoordinates;
        MapCoordinates = root.Element("MapCoordinates") is XElement mapCoordinates
            ? new MapCoordinates(mapCoordinates)
            : MapCoordinates;
    }

    public override string ToString()
    {
        return new XElement("DeliveryOrigin",
            Date != null ? XElement.Parse($"{Date}") : null,
            Time != null ? XElement.Parse($"{Time}") : null,
            LocationParty != null ? XElement.Parse($"{LocationParty}") : null,
            GPSCoordinates != null ? XElement.Parse($"{GPSCoordinates}") : null,
            MapCoordinates != null ? XElement.Parse($"{MapCoordinates}") : null
        ).ToString();
    }
}

public class SupplyPoint
{
    public LocationType LocationType = LocationType.Destination;
    public SupplyPointCode SupplyPointCode = new();
    public List<string> SupplyPointDescription = [];
    public List<MapCoordinates> MapCoordinates = [];

    public SupplyPoint() { }

    public SupplyPoint(XElement root)
    {
        LocationType = root.Attribute("LocationType") is XAttribute locationType
            ? Enum.Parse<LocationType>(locationType.Value)
            : LocationType;
        SupplyPointCode = root.Element("SupplyPointCode") is XElement supplyPointCode
            ? new SupplyPointCode(supplyPointCode)
            : SupplyPointCode;
        SupplyPointDescription = root.Elements("SupplyPointDescription")
            .Select(description => description.Value)
            .ToList();
        MapCoordinates = root.Elements("MapCoordinates")
            .Select(coordinates => new MapCoordinates(coordinates))
            .ToList();
    }

    public override string ToString()
    {
        return new XElement("SupplyPoint",
            new XAttribute("LocationType", LocationType),
            XElement.Parse($"{SupplyPointCode}"),
            SupplyPointDescription.Select(description => new XElement("SupplyPointDescription", description)),
            MapCoordinates.Select(coordinates => XElement.Parse($"{coordinates}"))
        ).ToString();
    }
}

public class SupplyPointCode
{
    public Agency Agency = Agency.Other;
    public string Value = string.Empty;

    public SupplyPointCode() { }

    public SupplyPointCode(XElement root)
    {
        Agency = root.Attribute("Agency") is XAttribute agency
            ? Enum.Parse<Agency>(agency.Value)
            : Agency;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("SupplyPointCode",
            new XAttribute("Agency", Agency),
            Value
        ).ToString();
    }
}

public class PriceDetails
{
    public PriceQuantityBasis PriceQuantityBasis = PriceQuantityBasis.ActualVolume;
    public PriceTaxBasis? PriceTaxBasis = null;
    public PricePerUnit PricePerUnit = new();
    public List<InformationalPricePerUnit> InformationalPricePerUnit = [];
    public List<string> AdditionalText = [];
    public ExchangeRate ExchangeRate = new();
    public MonetaryAdjustment? MonetaryAdjustment = null;
    public GeneralLedgerAccount? GeneralLedgerAccount = null;

    public PriceDetails() { }

    public PriceDetails(XElement root)
    {
        PriceQuantityBasis = root.Attribute("PriceQuantityBasis") is XAttribute priceQuantityBasis
            ? Enum.Parse<PriceQuantityBasis>(priceQuantityBasis.Value)
            : PriceQuantityBasis;
        PriceTaxBasis = root.Attribute("PriceTaxBasis") is XAttribute priceTaxBasis
            ? Enum.Parse<PriceTaxBasis>(priceTaxBasis.Value)
            : PriceTaxBasis;
        PricePerUnit = root.Element("PricePerUnit") is XElement pricePerUnit
            ? new PricePerUnit(pricePerUnit)
            : PricePerUnit;
        InformationalPricePerUnit = root.Elements("InformationalPricePerUnit")
            .Select(unit => new InformationalPricePerUnit(unit))
            .ToList();
        AdditionalText = root.Elements("AdditionalText")
            .Select(text => text.Value)
            .ToList();
        ExchangeRate = root.Element("ExchangeRate") is XElement exchangeRate
            ? new ExchangeRate(exchangeRate)
            : ExchangeRate;
        MonetaryAdjustment = root.Element("MonetaryAdjustment") is XElement monetaryAdjustment
            ? new MonetaryAdjustment(monetaryAdjustment)
            : MonetaryAdjustment;
        GeneralLedgerAccount = root.Element("GeneralLedgerAccount") is XElement generalLedgerAccount
            ? new GeneralLedgerAccount(generalLedgerAccount)
            : GeneralLedgerAccount;
    }

    public override string ToString()
    {
        return new XElement("PriceDetails",
            new XAttribute("PriceQuantityBasis", PriceQuantityBasis),
            PriceTaxBasis != null ? new XAttribute("PriceTaxBasis", PriceTaxBasis) : null,
            PricePerUnit != null ? XElement.Parse($"{PricePerUnit}") : null,
            InformationalPricePerUnit.Select(unit => XElement.Parse($"{unit}")),
            AdditionalText.Select(text => XElement.Parse($"{text}")),
            ExchangeRate != null ? XElement.Parse($"{ExchangeRate}") : null,
            MonetaryAdjustment != null ? XElement.Parse($"{MonetaryAdjustment}") : null,
            GeneralLedgerAccount != null ? XElement.Parse($"{GeneralLedgerAccount}") : null
        ).ToString();
    }
}

public class MonetaryAdjustment
{
    public AdjustmentType_Financial AdjustmentType = AdjustmentType_Financial.Other;
    public string MonetaryAdjustmentLine = string.Empty;
    public MonetaryAdjustmentStartAmount? MonetaryAdjustmentStartAmount = null;
    public MonetaryAdjustmentStartQuantity? MonetaryAdjustmentStartQuantity = null;
    public PriceAdjustment? PriceAdjustment = null;
    public FlatAmountAdjustment? FlatAmountAdjustment = null;
    public TaxAdjustment? TaxAdjustment = null;
    public InformationalAmount? InformationalAmount = null;
    public string? MonetaryAdjustmentReferenceLine = null;
    public List<string> AdditionalText = [];
    public GeneralLedgerAccount? GeneralLedgerAccount = null;
    public MonetaryAdjustmentAmount? MonetaryAdjustmentAmount = null;
    public string? AdjustmentTypeReason = null;

    public MonetaryAdjustment() { }

    public MonetaryAdjustment(XElement root)
    {
        AdjustmentType = root.Attribute("AdjustmentType") is XAttribute adjustmentType
            ? Enum.Parse<AdjustmentType_Financial>(adjustmentType.Value)
            : AdjustmentType;
        MonetaryAdjustmentLine = root.Element("MonetaryAdjustmentLine")?.Value ?? MonetaryAdjustmentLine;
        MonetaryAdjustmentStartAmount = root.Element("MonetaryAdjustmentStartAmount") is XElement monetaryAdjustmentStartAmount
            ? new MonetaryAdjustmentStartAmount(monetaryAdjustmentStartAmount)
            : MonetaryAdjustmentStartAmount;
        MonetaryAdjustmentStartQuantity = root.Element("MonetaryAdjustmentStartQuantity") is XElement monetaryAdjustmentStartQuantity
            ? new MonetaryAdjustmentStartQuantity(monetaryAdjustmentStartQuantity)
            : MonetaryAdjustmentStartQuantity;
        PriceAdjustment = root.Element("PriceAdjustment") is XElement priceAdjustment
            ? new PriceAdjustment(priceAdjustment)
            : PriceAdjustment;
        FlatAmountAdjustment = root.Element("FlatAmountAdjustment") is XElement flatAmountAdjustment
            ? new FlatAmountAdjustment(flatAmountAdjustment)
            : FlatAmountAdjustment;
        TaxAdjustment = root.Element("TaxAdjustment") is XElement taxAdjustment
            ? new TaxAdjustment(taxAdjustment)
            : TaxAdjustment;
        InformationalAmount = root.Element("InformationalAmount") is XElement informationalAmount
            ? new InformationalAmount(informationalAmount)
            : InformationalAmount;
        MonetaryAdjustmentReferenceLine = root.Element("MonetaryAdjustmentReferenceLine")?.Value ?? MonetaryAdjustmentReferenceLine;
        AdditionalText = root.Elements("AdditionalText").Select(text => text.Value).ToList();
        GeneralLedgerAccount = root.Element("GeneralLedgerAccount") is XElement generalLedgerAccount
            ? new GeneralLedgerAccount(generalLedgerAccount)
            : GeneralLedgerAccount;
        MonetaryAdjustmentAmount = root.Element("MonetaryAdjustmentAmount") is XElement monetaryAdjustmentAmount
            ? new MonetaryAdjustmentAmount(monetaryAdjustmentAmount)
            : MonetaryAdjustmentAmount;
        AdjustmentTypeReason = root.Element("AdjustmentTypeReason")?.Value ?? AdjustmentTypeReason;
    }

    public override string ToString()
    {
        return new XElement("MonetaryAdjustment",
            new XAttribute("AdjustmentType", AdjustmentType),
            new XElement("MonetaryAdjustmentLine", MonetaryAdjustmentLine),
            MonetaryAdjustmentStartAmount != null ? XElement.Parse($"{MonetaryAdjustmentStartAmount}") : null,
            MonetaryAdjustmentStartQuantity != null ? XElement.Parse($"{MonetaryAdjustmentStartQuantity}") : null,
            PriceAdjustment != null ? XElement.Parse($"{PriceAdjustment}") : null,
            FlatAmountAdjustment != null ? XElement.Parse($"{FlatAmountAdjustment}") : null,
            TaxAdjustment != null ? XElement.Parse($"{TaxAdjustment}") : null,
            InformationalAmount != null ? XElement.Parse($"{InformationalAmount}") : null,
            MonetaryAdjustmentReferenceLine != null 
                ? new XElement("MonetaryAdjustmentReferenceLine", MonetaryAdjustmentReferenceLine)
                : null,
            AdditionalText.Select(text => new XElement("AdditionalText", text)),
            GeneralLedgerAccount != null ? XElement.Parse($"{GeneralLedgerAccount}") : null,
            MonetaryAdjustmentAmount != null ? XElement.Parse($"{MonetaryAdjustmentAmount}") : null,
            AdjustmentTypeReason != null ? new XElement("AdjustmentTypeReason", AdjustmentTypeReason) : null
        ).ToString();
    }
}

public class MonetaryAdjustmentAmount
{
    public CurrencyValue CurrencyValue = new();

    public MonetaryAdjustmentAmount() { }

    public MonetaryAdjustmentAmount(XElement root)
    {
        CurrencyValue = root.Element("CurrencyValue") is XElement currencyValue
            ? new CurrencyValue(currencyValue)
            : CurrencyValue;
    }

    public override string ToString()
    {
        return new XElement("MonetaryAdjustmentAmount",
            XElement.Parse($"{CurrencyValue}")
        ).ToString();
    }
}

public class GeneralLedgerAccount
{
    public Agency? Agency = null;
    public string Value = string.Empty;

    public GeneralLedgerAccount() { }

    public GeneralLedgerAccount(XElement root)
    {
        Agency = root.Attribute("Agency") is XAttribute agency
            ? Enum.Parse<Agency>(agency.Value)
            : Agency;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("GeneralLedgerAccount",
            Agency != null ? new XAttribute("Agency", Agency) : null,
            Value
        ).ToString();
    }
}

public class TaxAdjustment
{
    public TaxCategoryType? TaxCategoryType = null;
    public TaxType TaxType = TaxType.VAT;
    public string? TaxPercent = null;
    public TaxAmount? TaxAmount = null;
    public string TaxLocation = string.Empty;
    public List<InformationalAmount> InformationalAmount = [];

    public TaxAdjustment() { }

    public TaxAdjustment(XElement root)
    {
        TaxCategoryType = root.Attribute("TaxCategoryType") is XAttribute taxCategoryType
            ? Enum.Parse<TaxCategoryType>(taxCategoryType.Value)
            : TaxCategoryType;
        TaxType = root.Attribute("TaxType") is XAttribute taxType
            ? Enum.Parse<TaxType>(taxType.Value)
            : TaxType;
        TaxPercent = root.Element("TaxPercent")?.Value ?? TaxPercent;
        TaxAmount = root.Element("TaxAmount") is XElement taxAmount
            ? new TaxAmount(taxAmount)
            : TaxAmount;
        TaxLocation = root.Element("TaxLocation")?.Value ?? TaxLocation;
        InformationalAmount = root.Elements("InformationalAmount")
            .Select(amount => new InformationalAmount(amount))
            .ToList();
    }

    public override string ToString()
    {
        return new XElement("TaxAdjustment",
            TaxCategoryType != null ? new XAttribute("TaxCategoryType", TaxCategoryType) : null,
            new XAttribute("TaxType", TaxType),
            TaxPercent != null ? XElement.Parse($"{TaxPercent}") : null,
            TaxAmount != null ? XElement.Parse($"{TaxAmount}") : null,
            new XElement("TaxLocation", TaxLocation),
            InformationalAmount.Select(amount => XElement.Parse($"{amount}"))
        ).ToString();
    }
}

public class InformationalAmount
{
    public AmountType? AmountType = null;
    public CurrencyValue CurrencyValue = new();
    public ExchangeRate? ExchangeRate = null;
    public List<string> AdditionalText = [];

    public InformationalAmount() { }

    public InformationalAmount(XElement root)
    {
        AmountType = root.Attribute("AmountType") is XAttribute amountType
            ? Enum.Parse<AmountType>(amountType.Value)
            : AmountType;
        CurrencyValue = root.Element("CurrencyValue") is XElement currencyValue
            ? new CurrencyValue(currencyValue)
            : CurrencyValue;
        ExchangeRate = root.Element("ExchangeRate") is XElement exchangeRate
            ? new ExchangeRate(exchangeRate)
            : ExchangeRate;
        AdditionalText = root.Elements("AdditionalText").Select(text => text.Value)
            .ToList();
    }

    public override string ToString()
    {
        return new XElement("InformationalAmount",
            AmountType != null ? new XAttribute("AmountType", AmountType) : null,
            XElement.Parse($"{CurrencyValue}"),
            ExchangeRate != null ? XElement.Parse($"{ExchangeRate}") : null,
            AdditionalText.Select(text => new XElement("AdditionalText", text))
        ).ToString();
    }
}

public class TaxAmount
{
    public CurrencyValue CurrencyValue = new();

    public TaxAmount() { }

    public TaxAmount(XElement root)
    {
        CurrencyValue = root.Element("CurrencyValue") is XElement currencyValue
            ? new CurrencyValue(currencyValue)
            : CurrencyValue;
    }

    public override string ToString()
    {
        return new XElement("TaxAmount",
            XElement.Parse($"{CurrencyValue}")
        ).ToString();
    }
}

public class FlatAmountAdjustment
{
    public AdjustmentPercentage? AdjustmentPercentage = null;
    public AdjustmentFixedAmount? AdjustmentFixedAmount = null;
    public string Value = string.Empty;

    public FlatAmountAdjustment() { }

    public FlatAmountAdjustment(XElement root)
    {
        AdjustmentPercentage = root.Element("AdjustmentPercentage") is XElement adjustmentPercentage
            ? new AdjustmentPercentage(adjustmentPercentage)
            : AdjustmentPercentage;
        AdjustmentFixedAmount = root.Element("AdjustmentFixedAmount") is XElement adjustmentFixedAmount
            ? new AdjustmentFixedAmount(adjustmentFixedAmount)
            : AdjustmentFixedAmount;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("FlatAmountAdjustment",
            AdjustmentPercentage != null ? XElement.Parse($"{AdjustmentPercentage}") : null,
            AdjustmentFixedAmount != null ? XElement.Parse($"{AdjustmentFixedAmount}") : null,
            Value
        ).ToString();
    }
}

public class AdjustmentFixedAmount
{
    public CurrencyValue CurrencyValue = new();
    public string Value = string.Empty;

    public AdjustmentFixedAmount() { }

    public AdjustmentFixedAmount(XElement root)
    {
        CurrencyValue = root.Element("CurrencyValue") is XElement currencyValue
            ? new CurrencyValue(currencyValue)
            : CurrencyValue;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("AdjustmentFixedAmount",
            XElement.Parse($"{CurrencyValue}"),
            Value
        ).ToString();
    }
}

public class PriceAdjustment
{
    public AdjustmentPercentage? AdjustmentPercentage = null;
    public AdjustmentValue? AdjustmentValue = null;
    public string Value = string.Empty;

    public PriceAdjustment() { }

    public PriceAdjustment(XElement root)
    {
        AdjustmentPercentage = root.Element("AdjustmentPercentage") is XElement adjustmentPercentage
            ? new AdjustmentPercentage(adjustmentPercentage)
            : AdjustmentPercentage;
        AdjustmentValue = root.Element("AdjustmentValue") is XElement adjustmentValue
            ? new AdjustmentValue(adjustmentValue)
            : AdjustmentValue;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("PriceAdjustment",
            AdjustmentPercentage != null ? XElement.Parse($"{AdjustmentPercentage}") : null,
            AdjustmentValue != null ? XElement.Parse($"{AdjustmentValue}") : null,
            Value
        ).ToString();
    }
}

public class AdjustmentValue
{
    public CurrencyValue CurrencyValue = new();
    public Value Value = new();
    public RangeMin? RangeMin = null;
    public RangeMax? RangeMax = null;

    public AdjustmentValue() { }

    public AdjustmentValue(XElement root)
    {
        CurrencyValue = root.Element("CurrencyValue") is XElement currencyValue
            ? new CurrencyValue(currencyValue)
            : CurrencyValue;
        Value = root.Element("Value") is XElement value
            ? new Value(value) 
            : Value;
        RangeMin = root.Element("RangeMin") is XElement rangeMin
            ? new RangeMin(rangeMin)
            : RangeMin;
        RangeMax = root.Element("RangeMax") is XElement rangeMax
            ? new RangeMax(rangeMax)
            : RangeMax;
    }

    public override string ToString()
    {
        return new XElement("AdjustmentValue",
            XElement.Parse($"{CurrencyValue}"),
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class AdjustmentPercentage
{
    public Value Value = new();
    public RangeMin? RangeMin = null;
    public RangeMax? RangeMax = null;

    public AdjustmentPercentage() { }

    public AdjustmentPercentage(XElement root)
    {
        Value = root.Element("Value") is XElement value
            ? new Value(value)
            : Value;
        RangeMin = root.Element("RangeMin") is XElement rangeMin
            ? new RangeMin(rangeMin)
            : RangeMin;
        RangeMax = root.Element("RangeMax") is XElement rangeMax
            ? new RangeMax(rangeMax)
            : RangeMax;
    }

    public override string ToString()
    {
        return new XElement("AdjustmentPercentage",
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class MonetaryAdjustmentStartQuantity
{
    public Value Value = new();
    public RangeMin? RangeMin = null;
    public RangeMax? RangeMax = null;

    public MonetaryAdjustmentStartQuantity() { }

    public MonetaryAdjustmentStartQuantity(XElement root)
    {
        Value = root.Element("Value") is XElement value
            ? new Value(root)
            : Value;
        RangeMin = root.Element("RangeMin") is XElement rangeMin
            ? new RangeMin(rangeMin)
            : RangeMin;
        RangeMax = root.Element("RangeMax") is XElement rangeMax
            ? new RangeMax(rangeMax)
            : RangeMax;
    }

    public override string ToString()
    {
        return new XElement("MonetaryAdjustmentStartQuantity",
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class MonetaryAdjustmentStartAmount
{
    public CurrencyValue CurrencyValue = new();
    public string Value = string.Empty;

    public MonetaryAdjustmentStartAmount() { }

    public MonetaryAdjustmentStartAmount(XElement root)
    {
        CurrencyValue = root.Element("CurrencyValue") is XElement currencyValue
            ? new CurrencyValue(currencyValue)
            : CurrencyValue;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("MonetaryAdjustmentStartAmount",
            XElement.Parse($"{CurrencyValue}"),
            Value
        ).ToString();
    }
}

public class ExchangeRate
{
    public ExchangeRateType ExchangeRateType = ExchangeRateType.Fixed;
    public CurrencyFromType? CurrencyFromType = null;
    public CurrencyValue? CurrencyValue = null;
    public MinCurrencyValue MinCurrencyValue = new();
    public MaxCurrencyValue MaxCurrencyValue = new();
    public Date? Date = null;

    public ExchangeRate() { }

    public ExchangeRate(XElement root)
    {
        ExchangeRateType = root.Attribute("ExchangeRateType") is XAttribute exchangeRateType
            ? Enum.Parse<ExchangeRateType>(exchangeRateType.Value)
            : ExchangeRateType;
        CurrencyFromType = root.Attribute("CurrencyFromType") is XAttribute currencyFromType
            ? Enum.Parse<CurrencyFromType>(currencyFromType.Value)
            : CurrencyFromType;
        CurrencyValue = root.Element("CurrencyValue") is XElement currencyValue
            ? new CurrencyValue(currencyValue)
            : CurrencyValue;
        MinCurrencyValue = root.Element("MinCurrencyValue") is XElement minCurrencyValue
            ? new MinCurrencyValue(minCurrencyValue) 
            : MinCurrencyValue;
        MaxCurrencyValue = root.Element("MaxCurrencyValue") is XElement maxCurrencyValue
            ? new MaxCurrencyValue(maxCurrencyValue) 
            : MaxCurrencyValue;
        Date = root.Element("Date") is XElement date
            ? new Date(date)
            : Date;
    }

    public override string ToString()
    {
        return new XElement("ExchangeRate",
            new XAttribute("ExchangeRateType", ExchangeRateType),
            CurrencyFromType != null ? new XAttribute("CurrencyFromType", CurrencyFromType) : null,
            MinCurrencyValue != null ? XElement.Parse($"{MinCurrencyValue}") : null,
            MaxCurrencyValue != null ? XElement.Parse($"{MaxCurrencyValue}") : null,
            Date != null ? XElement.Parse($"{Date}") : null
        ).ToString();
    }
}

public class MaxCurrencyValue : MinCurrencyValue
{
    public MaxCurrencyValue() : base() { }

    public MaxCurrencyValue(XElement root) : base(root) { }

    public override string ToString()
    {
        return new XElement("MaxCurrencyValue",
            CurrencyType != null ? new XAttribute("CurrencyType", CurrencyType) : null,
            Value
        ).ToString();
    }
}

public class MinCurrencyValue
{
    public CurrencyType? CurrencyType = null;
    public string Value = string.Empty;

    public MinCurrencyValue() { }

    public MinCurrencyValue(XElement root)
    {
        CurrencyType = root.Attribute("CurrencyType") is XAttribute currencyType
            ? Enum.Parse<CurrencyType>(currencyType.Value) 
            : CurrencyType;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("MinCurrencyValue",
            CurrencyType != null ? new XAttribute("CurrencyType", CurrencyType) : null,
            Value
        ).ToString();
    }
}

public class InformationalPricePerUnit
{
    public InformationalPricePerUnitType InformationalPricePerUnitType = InformationalPricePerUnitType.ProductPrice;
    public CurrencyValue CurrencyValue = new();
    public Value Value = new();
    public RangeMin? RangeMin = null;
    public RangeMax? RangeMax = null;

    public InformationalPricePerUnit() { }

    public InformationalPricePerUnit(XElement root)
    {
        InformationalPricePerUnitType = root.Attribute("InformationalPricePerUnitType") is XAttribute informationalPricePerUnitType
            ? Enum.Parse<InformationalPricePerUnitType>(informationalPricePerUnitType.Value)
            : InformationalPricePerUnitType;
        CurrencyValue = root.Element("CurrencyValue") is XElement currencyValue
            ? new CurrencyValue(root)
            : CurrencyValue;
        RangeMin = root.Element("RangeMin") is XElement rangeMin
            ? new RangeMin(root) 
            : RangeMin;
        RangeMax = root.Element("RangeMax") is XElement rangeMax
            ? new RangeMax(root)
            : RangeMax;
    }

    public override string ToString()
    {
        return new XElement("InformationalPricePerUnit",
            new XAttribute("InformationalPricePerUnitType", InformationalPricePerUnitType),
            XElement.Parse($"{CurrencyValue}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class PricePerUnit
{
    public CurrencyValue CurrencyValue = new();
    public Value Value = new();
    public RangeMin? RangeMin = null;
    public RangeMax? RangeMax = null;

    public PricePerUnit() { }

    public PricePerUnit(XElement root)
    {
        CurrencyValue = root.Element("CurrencyValue") is XElement currencyValue
            ? new CurrencyValue(currencyValue)
            : CurrencyValue;
        Value = root.Element("Value") is XElement value
            ? new Value(value)
            : Value;
        RangeMin = root.Element("RangeMin") is XElement rangeMin
            ? new RangeMin(rangeMin)
            : RangeMin;
        RangeMax = root.Element("RangeMax") is XElement rangeMax
            ? new RangeMax(rangeMax)
            : RangeMax;
    }

    public override string ToString()
    {
        return new XElement("PricePerUnit",
            XElement.Parse($"{CurrencyValue}"),
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class CurrencyValue
{
    public string CurrencyType = string.Empty;
    public string Value = string.Empty;

    public CurrencyValue() { }

    public CurrencyValue(XElement root)
    {
        CurrencyType = root.Attribute("CurrencyType")?.Value ?? CurrencyType;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("CurrencyValue",
            new XAttribute("CurrencyType", CurrencyType),
            Value
        ).ToString();
    }
}

public class InformationalQuantity : Quantity
{
    public InformationalQuantity() : base() { }

    public InformationalQuantity(XElement root) : base(root) { }

    public override string ToString()
    {
        return new XElement("InformationalQuantity",
            new XAttribute("QuantityType", QuantityType),
            QuantityTypeContext != null ? new XAttribute("QuantityTypeContext", QuantityTypeContext) : null,
            AdjustmentType != null ? new XAttribute("AdjustmentType", AdjustmentType) : null,
            MeasuringAgency != null ? new XAttribute("MeasuringAgency", MeasuringAgency) : null,
            MeasuringMethod != null ? new XAttribute("MeasuringMethod", MeasuringMethod) : null,
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class Quantity
{
    public QuantityType QuantityType = QuantityType.ActualVolume;
    public QuantityTypeContext? QuantityTypeContext = null;
    public AdjustmentType_Tare? AdjustmentType = null;
    public MeasuringAgency? MeasuringAgency = null;
    public string? MeasuringMethod = null;
    public Value Value = new();
    public RangeMin? RangeMin = null;
    public RangeMax? RangeMax = null;

    public Quantity() { }

    public Quantity(
        QuantityType quantityType, 
        QuantityTypeContext? quantityTypeContext, 
        AdjustmentType_Tare? adjustmentType, 
        MeasuringAgency? measuringAgency, 
        string? measuringMethod, 
        Value value,
        RangeMin? rangeMin, 
        RangeMax? rangeMax)
    {
        QuantityType = quantityType;
        QuantityTypeContext = quantityTypeContext;
        AdjustmentType = adjustmentType;
        MeasuringAgency = measuringAgency;
        MeasuringMethod = measuringMethod;
        Value = value;
        RangeMin = rangeMin;
        RangeMax = rangeMax;
    }

    public Quantity(XElement root)
    {
        QuantityType = root.Attribute("QuantityType") is XAttribute quantityType
            ? Enum.Parse<QuantityType>(quantityType.Value)
            : QuantityType;
        QuantityTypeContext = root.Attribute("QuantityTypeContext") is XAttribute quantityTypeContext
            ? Enum.Parse<QuantityTypeContext>(quantityTypeContext.Value)
            : QuantityTypeContext;
        AdjustmentType = root.Attribute("AdjustmentType") is XAttribute adjustmentType
            ? Enum.Parse<AdjustmentType_Tare>(adjustmentType.Value)
            : AdjustmentType;
        MeasuringAgency = root.Attribute("MeasuringAgency") is XAttribute measuringAgency
            ? Enum.Parse<MeasuringAgency>(measuringAgency.Value)
            : MeasuringAgency;
        MeasuringMethod = root.Attribute("MeasuringMethod") is XAttribute measuringMethod
            ? measuringMethod.Value
            : MeasuringMethod;
        Value = root.Element("Value") is XElement value
            ? new Value(value)
            : Value;
        RangeMin = root.Element("RangeMin") is XElement rangeMin
            ? new RangeMin(rangeMin)
            : RangeMin;
        RangeMax = root.Element("RangeMax") is XElement rangeMax
            ? new RangeMax(rangeMax)
            : RangeMax;
    }

    public override string ToString()
    {
        return new XElement("Quantity",
            new XAttribute("QuantityType", QuantityType),
            QuantityTypeContext != null ? new XAttribute("QuantityTypeContext", QuantityTypeContext) : null,
            AdjustmentType != null ? new XAttribute("AdjustmentType", AdjustmentType) : null,
            MeasuringAgency != null ? new XAttribute("MeasuringAgency", MeasuringAgency) : null,
            MeasuringMethod != null ? new XAttribute("MeasuringMethod", MeasuringMethod) : null,
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class RangeMin : Value 
{
    public RangeMin() : base() { }

    public RangeMin(XElement root) : base(root) { }

    public override string ToString()
    {
        return new XElement("RangeMin",
            new XAttribute("UOM", base.UOM),
            base.Text
        ).ToString();
    }
}

public class RangeMax : Value
{
    public RangeMax() : base() { }

    public RangeMax(XElement root) : base(root) { }

    public override string ToString()
    {
        return new XElement("RangeMax",
            new XAttribute("UOM", base.UOM),
            base.Text
        ).ToString();
    }
}

public class Value
{
    public UOM UOM = UOM.Unit;
    public string Text = string.Empty;

    public Value() { }

    public Value(UOM uOM, string text)
    {
        UOM = uOM;
        Text = text;
    }

    public Value(XElement root)
    {
        UOM = root.Attribute("UOM") is XAttribute uom
            ? Enum.Parse<UOM>(uom.Value)
            : UOM;
        Text = root.Value;
    }

    public override string ToString()
    {
        return new XElement("Value",
            new XAttribute("UOM", UOM),
            Text
        ).ToString();
    }
}

public class DeliveryDateWindow
{
    public DeliveryDateType DeliveryDateType = DeliveryDateType.ActualArrivalDate;
    public DateTimeRange? DateTimeRange = null;
    public string? Month = null;
    public string? Week = null;
    public Date Date = new();
    public Time? Time = null;

    public DeliveryDateWindow() { }

    public DeliveryDateWindow(DeliveryDateType deliveryDateType, DateTimeRange? dateTimeRange, string? month, string? week, Date date, Time? time)
    {
        DeliveryDateType = deliveryDateType;
        DateTimeRange = dateTimeRange;
        Month = month;
        Week = week;
        Date = date;
        Time = time;
    }

    public DeliveryDateWindow(XElement root)
    {
        DeliveryDateType = root.Attribute("DeliveryDateType") is XAttribute deliveryDateType
            ? Enum.Parse<DeliveryDateType>(deliveryDateType.Value)
            : DeliveryDateType;
        DateTimeRange = root.Element("DateTimeRange") is XElement dateTimeRange
            ? new DateTimeRange(dateTimeRange)
            : DateTimeRange;
        Month = root.Element("Month")?.Value;
        Week = root.Element("Week")?.Value;
        Date = root.Element("Date") is XElement date ? new Date(date) : Date;
        Time = root.Element("Time") is XElement time ? new Time(time) : Time;
    }

    public override string ToString()
    {
        return new XElement("DeliveryDateWindow",
            new XAttribute("DeliveryDateType", DeliveryDateType),
            DateTimeRange != null ? XElement.Parse($"{DateTimeRange}") : null,
            Month != null ? XElement.Parse($"{Month}") : null,
            Week != null ? XElement.Parse($"{Week}") : null,
            Date != null ? XElement.Parse($"{Date}") : null,
            Time != null ? XElement.Parse($"{Time}") : null
        ).ToString();
    }
}

public class DateTimeRange
{
    public DateTimeFrom DateTimeFrom = new();
    public DateTimeTo DateTimeTo = new();

    public DateTimeRange() { }

    public DateTimeRange(DateTimeFrom dateTimeFrom, DateTimeTo dateTimeTo)
    {
        DateTimeFrom = dateTimeFrom;
        DateTimeTo = dateTimeTo;
    }

    public DateTimeRange(XElement root)
    {
        DateTimeFrom = root.Element("DateTimeFrom") is XElement dateTimeFrom
            ? new DateTimeFrom(dateTimeFrom)
            : DateTimeFrom;
        DateTimeTo = root.Element("DateTimeTo") is XElement dateTimeTo
            ? new DateTimeTo(dateTimeTo)
            : DateTimeTo;
    }

    public override string ToString()
    {
        return new XElement("DateTimeRange",
            XElement.Parse($"{DateTimeFrom}"),
            XElement.Parse($"{DateTimeTo}")
        ).ToString();
    }
}

public class DateTimeTo
{
    public Date Date = new();
    public Time? Time = null;

    public DateTimeTo() { }

    public DateTimeTo(Date date, Time? time)
    {
        Date = date;
        Time = time;
    }

    public DateTimeTo(XElement root)
    {
        Date = root.Element("Date") is XElement date
            ? new Date(date)
            : Date;
        Time = root.Element("Time") is XElement time
            ? new Time(time)
            : Time;
    }

    public override string ToString()
    {
        return new XElement("DateTimeTo",
            XElement.Parse($"{Date}"),
            Time != null ? XElement.Parse($"{Time}") : null
        ).ToString();
    }
}

public class DateTimeFrom
{
    public Date Date = new();
    public Time? Time = null;

    public DateTimeFrom() { }

    public DateTimeFrom(Date date, Time? time)
    {
        Date = date;
        Time = time;
    }

    public DateTimeFrom(XElement root)
    {
        Date = root.Element("Date") is XElement date
            ? new Date(date)
            : Date;
        Time = root.Element("Time") is XElement time
            ? new Time(time)
            : Time;
    }

    public override string ToString()
    {
        return new XElement("DateTimeFrom",
            XElement.Parse($"{Date}"),
            Time != null ? XElement.Parse($"{Time}") : null
        ).ToString();
    }
}

public class DeliveryStatus
{
    public DeliveryStatusType? DeliveryStatusType = null;
    public DeliveryLastDateOfChange? DeliveryLastDateOfChange = null;

    public DeliveryStatus() { }

    public DeliveryStatus(DeliveryStatusType? deliveryStatusType, DeliveryLastDateOfChange? deliveryLastDateOfChange)
    {
        DeliveryStatusType = deliveryStatusType;
        DeliveryLastDateOfChange = deliveryLastDateOfChange;
    }

    public DeliveryStatus(XElement root)
    {
        DeliveryStatusType = root.Attribute("DeliveryStatusType") is XAttribute deliveryStatusType
            ? Enum.Parse<DeliveryStatusType>(deliveryStatusType.Value)
            : DeliveryStatusType;
        DeliveryLastDateOfChange = root.Element("DeliveryLastDateOfChange") is XElement deliveryLastDateOfChange
            ? new DeliveryLastDateOfChange(deliveryLastDateOfChange)
            : DeliveryLastDateOfChange;
    }

    public override string ToString()
    {
        return new XElement("DeliveryStatus",
            DeliveryStatusType != null ? new XAttribute("DeliveryStatusType", DeliveryStatusType) : null,
            DeliveryLastDateOfChange != null ? XElement.Parse($"{DeliveryLastDateOfChange}") : null
        ).ToString();
    }
}

public class DeliveryLastDateOfChange
{
    public Date Date = new();
    public Time? Time = null;

    public DeliveryLastDateOfChange() { }

    public DeliveryLastDateOfChange(Date date, Time? time)
    {
        Date = date;
        Time = time;
    }

    public DeliveryLastDateOfChange(XElement root)
    {
        Date = root.Element("Date") is XElement date
            ? new Date(date)
            : Date;
        Time = root.Element("Time") is XElement time
            ? new Time(time)
            : Time;
    }

    public override string ToString()
    {
        return new XElement("DeliveryLastDateOfChange",
            new XElement("Date", Date),
            Time != null ? new XElement("Time") : null
        ).ToString();
    }
}

public class ProductionStatus
{
    public ProductionStatusType ProductionStatusType = ProductionStatusType.Free;
    public ProductionLastDateOfChange? ProductionLastDateOfChange = null;

    public ProductionStatus() { }

    public ProductionStatus(ProductionStatusType productionStatusType, ProductionLastDateOfChange? productionLastDateOfChange)
    {
        ProductionStatusType = productionStatusType;
        ProductionLastDateOfChange = productionLastDateOfChange;
    }

    public ProductionStatus(XElement root)
    {
        ProductionStatusType = root.Attribute("ProductionStatusType") is XAttribute productionStatusType
            ? Enum.Parse<ProductionStatusType>(productionStatusType.Value)
            : ProductionStatusType;
        ProductionLastDateOfChange = root.Element("ProductionLastDateOfChange") is XElement productionLastDateOfChange
            ? new ProductionLastDateOfChange(productionLastDateOfChange)
            : ProductionLastDateOfChange;
    }

    public override string ToString()
    {
        return new XElement("ProductionLastDateOfChange",
            new XAttribute("ProductionStatusType", ProductionStatusType),
            ProductionLastDateOfChange != null ? XElement.Parse($"{ProductionLastDateOfChange}") : null
        ).ToString();
    }
}

public class ProductionLastDateOfChange
{
    public Date Date = new();
    public Time? Time = null;

    public ProductionLastDateOfChange() { }

    public ProductionLastDateOfChange(Date date, Time? time)
    {
        Date = date;
        Time = time;
    }

    public ProductionLastDateOfChange(XElement root)
    {
        Date = root.Element("Date") is XElement date
            ? new Date(date)
            : Date;
        Time = root.Element("Time") is XElement time
            ? new Time(time)
            : Time;
    }

    public override string ToString()
    {
        return new XElement("ProductionLastDateOfChange",
            new XElement("Date", Date),
            Time != null ? new XElement("Time") : null
        ).ToString();
    }
}

public class ShipToCharacteristics
{
    public Party ShipToParty = new() { LocalName = "ShipToParty" };
    public LocationCode? LocationCode = null;
    public TermsOfDelivery? TermsOfDelivery = null;
    public DeliveryRouteCode? DeliveryRouteCode = null;

    public ShipToCharacteristics() { }

    public ShipToCharacteristics(Party shipToParty, LocationCode? locationCode, TermsOfDelivery? termsOfDelivery, DeliveryRouteCode? deliveryRouteCode)
    {
        ShipToParty = shipToParty;
        LocationCode = locationCode;
        TermsOfDelivery = termsOfDelivery;
        DeliveryRouteCode = deliveryRouteCode;
    }

    public ShipToCharacteristics(XElement root)
    {
        ShipToParty = root.Element("ShipToParty") is XElement shipToParty
            ? new Party(shipToParty)
            : ShipToParty;
        LocationCode = root.Element("LocationCode") is XElement locationCode
            ? new LocationCode(locationCode)
            : LocationCode;
        TermsOfDelivery = root.Element("TermsOfDelivery") is XElement termsOfDelivery
            ? new TermsOfDelivery(termsOfDelivery)
            : TermsOfDelivery;
        DeliveryRouteCode = root.Element("DeliveryRouteCode") is XElement deliveryRouteCode
            ? new DeliveryRouteCode(deliveryRouteCode)
            : DeliveryRouteCode;
    }

    public override string ToString()
    {
        return new XElement("ShipToCharacteristics",
            new XElement("ShipToParty", ShipToParty),
            LocationCode != null ? XElement.Parse($"{LocationCode}") : null,
            TermsOfDelivery != null ? XElement.Parse($"{TermsOfDelivery}") : null,
            DeliveryRouteCode != null ? XElement.Parse($"{DeliveryRouteCode}") : null
        ).ToString();
    }
}

public class LocationCode
{
    public Agency Agency = Agency.Other;
    public string Value = string.Empty;

    public LocationCode() { }

    public LocationCode(Agency agency, string value)
    {
        Agency = agency;
        Value = value;
    }

    public LocationCode(XElement root)
    {
        Agency = root.Attribute("Agency") is XAttribute agency
            ? Enum.Parse<Agency>(agency.Value)
            : Agency;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("LocationCode",
            new XAttribute("Agency", Agency),
            Value
        ).ToString();
    }
}

public class DeliveryRouteCode
{
    public Agency Agency = Agency.Other;
    public string Value = string.Empty;

    public DeliveryRouteCode() { }

    public DeliveryRouteCode(Agency agency, string value)
    {
        Agency = agency;
        Value = value;
    }

    public DeliveryRouteCode(XElement root)
    {
        Agency = root.Attribute("Agency") is XAttribute agency
            ? Enum.Parse<Agency>(agency.Value)
            : Agency;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("DeliveryRouteCode",
            new XAttribute("Agency", Agency),
            Value
        ).ToString();
    }
}

public class TermsOfDelivery
{
    public IncotermsLocation? IncotermsLocation = null;
    public ShipmentMethodOfPayment? ShipmentMethodOfPayment = null;
    public string? FreightPayableAt = null;
    public string? AdditionalText = null;

    public TermsOfDelivery() { }

    public TermsOfDelivery(IncotermsLocation? incotermsLocation, ShipmentMethodOfPayment? shipmentMethodOfPayment, string? freightPayableAt, string? additionalText)
    {
        IncotermsLocation = incotermsLocation;
        ShipmentMethodOfPayment = shipmentMethodOfPayment;
        FreightPayableAt = freightPayableAt;
        AdditionalText = additionalText;
    }

    public TermsOfDelivery(XElement root)
    {
        IncotermsLocation = root.Element("IncotermsLocation") is XElement incotermsLocation
            ? new IncotermsLocation(incotermsLocation)
            : IncotermsLocation;
        ShipmentMethodOfPayment = root.Element("ShipmentMethodOfPayment") is XElement shipmentMethodOfPayment
            ? new ShipmentMethodOfPayment(shipmentMethodOfPayment)
            : ShipmentMethodOfPayment;
        FreightPayableAt = root.Element("FreightPayableAt")?.Value ?? FreightPayableAt;
        AdditionalText = root.Element("AdditionalText")?.Value ?? AdditionalText;
    }

    public override string ToString()
    {
        return new XElement("TermsOfDelivery",
            IncotermsLocation != null ? XElement.Parse($"{IncotermsLocation}") : null,
            ShipmentMethodOfPayment != null ? XElement.Parse($"{ShipmentMethodOfPayment}") : null,
            FreightPayableAt != null ? new XElement("FreightPayableAt", FreightPayableAt) : null,
            AdditionalText != null ? new XElement("AdditionalText", AdditionalText) : null
        ).ToString();
    }
}

public class ShipmentMethodOfPayment
{
    public LocationQualifier? LocationQualifier = null;
    public Method? Method = null;
    public string Value = string.Empty;

    public ShipmentMethodOfPayment() { }

    public ShipmentMethodOfPayment(LocationQualifier? locationQualifier, Method? method, string value)
    {
        LocationQualifier = locationQualifier;
        Method = method;
        Value = value;
    }

    public ShipmentMethodOfPayment(XElement root)
    {
        LocationQualifier = root.Attribute("LocationQualifier") is XAttribute locationQualifier
            ? Enum.Parse<LocationQualifier>(locationQualifier.Value)
            : LocationQualifier;
        Method = root.Attribute("Method") is XAttribute method
            ? Enum.Parse<Method>(method.Value)
            : Method;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("ShipmentMethodOfPayment",
            LocationQualifier != null ? new XAttribute("LocationQualifier", LocationQualifier) : null,
            Method != null ? new XAttribute("Method", Method) : null,
            Value
        ).ToString();
    }
}

public class IncotermsLocation
{
    public Incoterms Incoterms = Incoterms.Other;
    public string? IncotermsVersion = null;
    public string Value = string.Empty;

    public IncotermsLocation() { }

    public IncotermsLocation(Incoterms incoterms, string? incotermsVersion, string value)
    {
        Incoterms = incoterms;
        IncotermsVersion = incotermsVersion;
        Value = value;
    }

    public IncotermsLocation(XElement root)
    {
        Incoterms = root.Attribute("Incoterms") is XAttribute incoterms
            ? Enum.Parse<Incoterms>(incoterms.Value)
            : Incoterms;
        IncotermsVersion = root.Attribute("IncotermsVersion")?.Value ?? IncotermsVersion;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("IncotermsLocation",
            new XAttribute("Incoterms", Incoterms),
            IncotermsVersion != null ? new XAttribute("IncotermsVersion", IncotermsVersion) : null,
            Value
        ).ToString();
    }
}

public class Party
{
    public string LocalName = "OtherParty";
    public PartyType? PartyType = null;
    public LogisticsRole? LogisticsRole = null;
    public List<PartyIdentifier> PartyIdentifier = [];
    public NameAddress NameAddress = new();
    public string? URL = null;
    public CommonContact? CommonContact = null;

    public Party() { }

    public Party(string localName, LogisticsRole? logisticsRole, List<PartyIdentifier> partyIdentifier, NameAddress nameAddress, string? uRL, CommonContact? commonContact)
    {
        LocalName = localName;
        LogisticsRole = logisticsRole;
        PartyIdentifier = partyIdentifier;
        NameAddress = nameAddress;
        URL = uRL;
        CommonContact = commonContact;
    }

    public Party(XElement root)
    {
        LocalName = root.Name.LocalName;
        PartyType = root.Attribute("PartyType") is XAttribute partyType
            ? Enum.Parse<PartyType>(partyType.Value)
            : PartyType;
        LogisticsRole = root.Attribute("LogisticsRole") is XAttribute logisticsRole
            ? Enum.Parse<LogisticsRole>(logisticsRole.Value)
            : LogisticsRole;
        PartyIdentifier = root.Elements("PartyIdentifier")
            .Select(identifier => new PartyIdentifier(identifier))
            .ToList();
        NameAddress = root.Element("NameAddress") is XElement nameAddress
            ? new NameAddress(nameAddress)
            : NameAddress;
        URL = root.Element("URL")?.Value;
        CommonContact = root.Element("CommonContact") is XElement commonContact
            ? new CommonContact(commonContact)
            : CommonContact;
    }

    public override string ToString()
    {
        return new XElement(LocalName,
            PartyType != null ? new XAttribute("PartyType", PartyType) : null,
            LogisticsRole != null ? new XAttribute("LogisticsRole", LogisticsRole) : null,
            PartyIdentifier.Select(identifier => XElement.Parse($"{identifier}")),
            XElement.Parse($"{NameAddress}"),
            URL != null ? new XElement("URL", URL) : null,
            CommonContact != null ? XElement.Parse($"{CommonContact}") : null
        ).ToString();
    }
}

public class CommonContact
{
    public ContactType ContactType = ContactType.Other;
    public string ContactName = string.Empty;
    public string? ContactIdentifier;
    public string? Telephone;
    public string? MobilePhone;
    public string? Email;
    public string? Fax;
    public GPSCoordinates? GPSCoordinates;
    public MapCoordinates? MapCoordinates;

    public CommonContact() { }

    public CommonContact(
        ContactType contactType,
        string contactName, 
        string? contactIdentifier, 
        string? telephone, 
        string? mobilePhone, 
        string? email, 
        string? fax,
        GPSCoordinates gpsCoordinates,
        MapCoordinates mapCoordinates)
    {
        ContactType = contactType;
        ContactName = contactName;
        ContactIdentifier = contactIdentifier;
        Telephone = telephone;
        MobilePhone = mobilePhone;
        Email = email;
        Fax = fax;
        GPSCoordinates = gpsCoordinates;
        MapCoordinates = mapCoordinates;
    }

    public CommonContact(XElement root)
    {
        ContactType = root.Attribute("ContactType") is XAttribute contactType
            ? Enum.Parse<ContactType>(contactType.Value)
            : ContactType;
        ContactName = root.Element("ContactName")?.Value ?? ContactName;
        ContactIdentifier = root.Element("ContactIdentifier")?.Value;
        Telephone = root.Element("Telephone")?.Value;
        MobilePhone = root.Element("MobilePhone")?.Value;
        Email = root.Element("Email")?.Value;
        Fax = root.Element("Fax")?.Value;
        GPSCoordinates = root.Element("GPSCoordinates") is XElement gpsCoordinates
            ? new GPSCoordinates(gpsCoordinates)
            : null;
        MapCoordinates = root.Element("MapCoordinates") is XElement mapCoordinates
            ? new MapCoordinates(mapCoordinates)
            : null;
    }

    public override string ToString()
    {
        return new XElement("CommonContact",
            new XAttribute("ContactType", ContactType),
            new XElement("ContactName", ContactName),
            ContactIdentifier != null ? new XElement("ContactIdentifier", ContactIdentifier) : null,
            Telephone != null ? new XElement("Telephone", Telephone) : null,
            MobilePhone != null ? new XElement("MobilePhone", MobilePhone) : null,
            Email != null ? new XElement("Email", Email) : null,
            Fax != null ? new XElement("Fax", Fax) : null,
            GPSCoordinates != null ? XElement.Parse($"{GPSCoordinates}") : null,
            MapCoordinates != null ? XElement.Parse($"{MapCoordinates}") : null
        ).ToString();
    }
}

public class MapCoordinates
{
    public MapReferenceSystem MapReferenceSystem;
    public MapCoordinateType MapCoordinateType;
    public string Coordinates = string.Empty;
    public string? Altitude;

    public MapCoordinates() { }

    public MapCoordinates(MapReferenceSystem mapReferenceSystem, MapCoordinateType mapCoordinateType, string coordinates, string? altitude)
    {
        MapReferenceSystem = mapReferenceSystem;
        MapCoordinateType = mapCoordinateType;
        Coordinates = coordinates;
        Altitude = altitude;
    }

    public MapCoordinates(XElement root)
    {
        MapReferenceSystem = root.Attribute("MapReferenceSystem") is XAttribute mapReferenceSystem
            ? Enum.Parse<MapReferenceSystem>(mapReferenceSystem.Value)
            : MapReferenceSystem;
        MapCoordinateType = root.Attribute("MapCoordinateType") is XAttribute mapCoordinateType
            ? Enum.Parse<MapCoordinateType>(mapCoordinateType.Value)
            : MapCoordinateType;
        Coordinates = root.Element("Coordinates")?.Value ?? Coordinates;
        Altitude = root.Element("Altitude")?.Value ?? Altitude;
    }

    public override string ToString()
    {
        return new XElement("MapCoordinates",
            new XAttribute("MapReferenceSystem", MapReferenceSystem),
            new XAttribute("MapCoordinateType", MapCoordinateType),
            new XElement("Coordinates"),
            Altitude != null ? new XElement("Altitude", Altitude) : null
        ).ToString();
    }
}

public class NameAddress
{
    public CommunicationRole? CommunicationRole;
    public string Name1 = string.Empty;
    public string? Name2;
    public string? Name3;
    public string? OrganisationUnit;
    public string? Address1;
    public string? Address2;
    public string? Address3;
    public string? Address4;
    public string? City;
    public string? County;
    public string? StateOrProvince;
    public string? PostalCode;
    public string? Country;
    public string? ISOCountryCode;
    public GPSCoordinates? GPSCoordinates;
    public MapCoordinates? MapCoordinates;

    public NameAddress() { }

    public NameAddress(
        CommunicationRole? communicationRole,
        string name1,
        string? name2,
        string? name3,
        string? organisationUnit,
        string? address1,
        string? address2,
        string? address3,
        string? address4,
        string? city,
        string? county,
        string? stateOrProvince,
        string? postalCode,
        string? country,
        string? iSOCountryCode,
        GPSCoordinates? gpsCoordinates,
        MapCoordinates? mapCoordinates)
    {
        CommunicationRole = communicationRole;
        Name1 = name1;
        Name2 = name2;
        Name3 = name3;
        OrganisationUnit = organisationUnit;
        Address1 = address1;
        Address2 = address2;
        Address3 = address3;
        Address4 = address4;
        City = city;
        County = county;
        StateOrProvince = stateOrProvince;
        PostalCode = postalCode;
        Country = country;
        ISOCountryCode = iSOCountryCode;
        GPSCoordinates = gpsCoordinates;
        MapCoordinates = mapCoordinates;
    }

    public NameAddress(XElement root)
    {
        CommunicationRole = root.Attribute("CommunicationRole") is XAttribute communicationRole
            ? Enum.Parse<CommunicationRole>(communicationRole.Value)
            : null;
        Name1 = root.Element("Name1")?.Value ?? Name1;
        Name2 = root.Element("Name2")?.Value;
        Name3 = root.Element("Name3")?.Value;
        OrganisationUnit = root.Element("OrganisationUnit")?.Value;
        Address1 = root.Element("Address1")?.Value;
        Address2 = root.Element("Address2")?.Value;
        Address3 = root.Element("Address3")?.Value;
        Address4 = root.Element("Address4")?.Value;
        City = root.Element("City")?.Value;
        County = root.Element("County")?.Value;
        StateOrProvince = root.Element("StateOrProvince")?.Value;
        PostalCode = root.Element("PostalCode")?.Value;
        Country = root.Element("Country")?.Value;
        ISOCountryCode = root.Element("Country")?.Attribute("ISOCountryCode")?.Value;
        GPSCoordinates = root.Element("GPSCoordinates") is XElement gpsCoordinates
            ? new GPSCoordinates(gpsCoordinates)
            : null;
        MapCoordinates = root.Element("MapCoordinates") is XElement mapCoordinates
            ? new MapCoordinates(mapCoordinates)
            : null;
    }

    public override string ToString()
    {
        return new XElement("NameAddress",
            new XElement("Name1", Name1),
            Name2 != null ? new XElement("Name2", Name2) : null,
            Name3 != null ? new XElement("Name3", Name3) : null,
            OrganisationUnit != null ? new XElement("OrganisationUnit", OrganisationUnit) : null,
            Address1 != null ? new XElement("Address1", Address1) : null,
            Address2 != null ? new XElement("Address2", Address2) : null,
            Address3 != null ? new XElement("Address3", Address3) : null,
            Address4 != null ? new XElement("Address4", Address4) : null,
            City != null ? new XElement("City", City) : null,
            County != null ? new XElement("County", County) : null,
            StateOrProvince != null ? new XElement("StateOrProvince", StateOrProvince) : null,
            PostalCode != null ? new XElement("PostalCode", PostalCode) : null,
            Country != null ? new XElement("Country",
                    ISOCountryCode != null 
                        ? new XAttribute("ISOCountryCode", ISOCountryCode) 
                        : null, Country) : null,
            GPSCoordinates != null ? XElement.Parse($"{GPSCoordinates}") : null,
            MapCoordinates != null ? XElement.Parse($"{MapCoordinates}") : null
        ).ToString();
    }
}

public class GPSCoordinates
{
    public GPSSystem? GPSSystem;
    public string Latitude = string.Empty;
    public string Longitude = string.Empty;
    public string? Height;

    public GPSCoordinates() { }

    public GPSCoordinates(GPSSystem? gPSSystem, string latitude, string longitude, string? height)
    {
        GPSSystem = gPSSystem;
        Latitude = latitude;
        Longitude = longitude;
        Height = height;
    }

    public GPSCoordinates(XElement root)
    {
        GPSSystem = root.Attribute("GPSSystem") is XAttribute gpsSystem
            ? Enum.Parse<GPSSystem>(gpsSystem.Value)
            : null;
        Latitude = root.Element("Latitude")?.Value ?? Latitude;
        Longitude = root.Element("Longitude")?.Value ?? Longitude;
        Height = root.Element("Height")?.Value;
    }

    public override string ToString()
    {
        return new XElement("GPSCoordinates",
            GPSSystem != null ? new XAttribute("GPSSystem", GPSSystem) : null,
            new XElement("Latitude", Latitude),
            new XElement("Longitude", Longitude),
            Height != null ? new XElement("Height", Height) : null
        ).ToString();
    }
}

public class PartyIdentifier
{
    public PartyIdentifierType PartyIdentifierType = PartyIdentifierType.Other;
    public Agency? Agency;
    public string Value = string.Empty;

    public PartyIdentifier() { }

    public PartyIdentifier(
        PartyIdentifierType partyIdentifierType,
        Agency? agency,
        string value)
    {
        PartyIdentifierType = partyIdentifierType;
        Agency = agency;
        Value = value;
    }

    public PartyIdentifier(XElement root)
    {
        PartyIdentifierType = root.Attribute("PartyIdentifierType") is XAttribute partyIdentifierType
            ? Enum.Parse<PartyIdentifierType>(partyIdentifierType.Value)
            : PartyIdentifierType;
        Agency = root.Attribute("Agency") is XAttribute agency
            ? Enum.Parse<Agency>(agency.Value)
            : null;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("PartyIdentifier",
            new XAttribute("PartyIdentifierType", PartyIdentifierType),
            Agency != null ? new XAttribute("Agency", Agency) : null,
            Value
        ).ToString();
    }
}

public class DocumentReferenceInformation
{
    public string DocumentReferenceID = string.Empty;
    public string? DocumentReferenceIDLineItemNumber;
    public Date? Date;
    public Time? Time;
    public string? NumberOfDocumentsRequired;

    public DocumentReferenceInformation() { }

    public DocumentReferenceInformation(
        string documentReferenceID, 
        string? documentReferenceIDLineItemNumber,
        Date? date,
        Time? time, 
        string? numberOfDocumentsRequired)
    {
        DocumentReferenceID = documentReferenceID;
        DocumentReferenceIDLineItemNumber = documentReferenceIDLineItemNumber;
        Date = date;
        Time = time;
        NumberOfDocumentsRequired = numberOfDocumentsRequired;
    }

    public DocumentReferenceInformation(XElement root)
    {
        DocumentReferenceID = root.Element("DocumentReferenceID")?.Value ?? DocumentReferenceID;
        DocumentReferenceIDLineItemNumber = root.Element("DocumentReferenceIDLineItemNumber")?.Value;
        Date = root.Element("Date") is XElement date ? new Date(date) : null;
        Time = root.Element("Time") is XElement time ? new Time(time) : null;
        NumberOfDocumentsRequired = root.Element("NumberOfDocumentsRequired")?.Value;
    }

    public override string ToString()
    {
        return new XElement("DocumentReferenceInformation",
            new XElement("DocumentReferenceID", DocumentReferenceID),
            DocumentReferenceIDLineItemNumber != null 
                ? new XElement("DocumentReferenceIDLineItemNumber", DocumentReferenceIDLineItemNumber) 
                : null,
            Date != null ? XElement.Parse($"{Date}") : null,
            Time != null ? XElement.Parse($"{Time}") : null,
            NumberOfDocumentsRequired != null 
                ? new XElement("NumberOfDocumentsRequired", NumberOfDocumentsRequired) 
                : null
        ).ToString();
    }
}

public class DeliveryMessageReference
{
    public DeliveryMessageReferenceType DeliveryMessageReferenceType = DeliveryMessageReferenceType.Other;
    public AssignedBy? AssignedBy;
    public string Value = string.Empty;

    public DeliveryMessageReference() { }

    public DeliveryMessageReference(
        DeliveryMessageReferenceType deliveryMessageReferenceType, 
        AssignedBy? assignedBy, 
        string value)
    {
        DeliveryMessageReferenceType = deliveryMessageReferenceType;
        AssignedBy = assignedBy;
        Value = value;
    }

    public DeliveryMessageReference(XElement root)
    {
        DeliveryMessageReferenceType = root.Attribute("DeliveryMessageReferenceType") is XAttribute deliveryMessageReferenceType
            ? Enum.Parse<DeliveryMessageReferenceType>(deliveryMessageReferenceType.Value)
            : DeliveryMessageReferenceType;
        AssignedBy = root.Attribute("AssignedBy") is XAttribute assignedBy
            ? Enum.Parse<AssignedBy>(assignedBy.Value)
            : null;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("DeliveryMessageReference",
            new XAttribute("DeliveryMessageReferenceType", DeliveryMessageReferenceType),
            AssignedBy != null ? new XAttribute("AssignedBy", AssignedBy) : null,
            Value
        ).ToString();
    }
}