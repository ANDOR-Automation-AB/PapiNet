using System.Runtime.Serialization;

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

public enum DocumentType
{
    ATR,
    BillOfLading,
    CertificateForPackaging,
    CIM,
    CMR,
    DeliveryNote,
    EUR1,
    Invoice,
    PowerOfAttorney,
    TORG12,
    T2,
    T2L,
    UnitPaper,
    WayBill,
}

public enum PurchaseOrderReferenceType
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

public enum MixProductIndicator
{
    Yes,
    No,
}

public enum TransportLoadingType
{
    ByLoadingCode,
    Lying,
    Standing,
    StandingUpsideDown,
    Other,
}

public enum TransportDeckOption
{
    FullDeck,
    HalfDeck,
    OneThirdDeck,
    UnderDeck,
}

public enum LoadingTolerance
{
    FillUpFromOtherOrder,
    Full,
    FullWithinTolerance,
    WithinTolerance,
}

public enum DirectLoading
{
    Yes,
    No,
}

public enum GoodsLoadingPrinciple
{
    FirstInFirstOut,
    LastInFirstOut,
    Random,
}

public enum LabelOrientation
{
    BackEndSide,
    FrontEndSide,
    LeftAndRightSide,
    LeftSide,
    RightSide,
}

public enum SafetyAndEnvironmentalType
{
    Agricultural,
    Biodegradable,
    Certified,
    Chemical,
    CSA,
    Energy,
    FlamabilityReactivity,
    FSC,
    FSCMixed,
    FSCPure,
    FSCRecycled,
    HazardousMaterial,
    MaterialSafetyData,
    MTCC,
    PEFC,
    Recycled,
    SFI,
    TransportationSafetyAlert,
}

public enum BookClassificationType
{
    Assembly,
    Audio,
    Binding,
    Box,
    Cover,
    Endsheet,
    FinishedGoods,
    Insert,
    Jacket,
    Label,
    Material,
    Media,
    MediaHolder,
    Packaging,
    Prep,
    SlipCase,
    Text,
    Video,
    Wrap,
}

public enum BookSubClassificationType
{
    //2PieceCarton,
    Acetate,
    AdvertisingBrochure,
    Album,
    Assembly,
    Audio,
    BackCoverPanelwShrinkwrap,
    BackMatter,
    BarCode,
    BellyBand,
    Binder,
    Binding,
    //Bind-inSleeve,
    BlisterPak,
    BlownIn,
    Book,
    Bookblock,
    Bookmark,
    Bound,
    Box,
    BoxWrap,
    BubbleBag,
    Card,
    Carton,
    CaseCover,
    Cassette,
    CassetteHolder,
    CD,
    //CD-ROM,
    Cloth,
    CompanyOwnedStock,
    Cover,
    CoverBack,
    CoverFront,
    Disk,
    Diskette,
    DisketteSleeve,
    Divider,
    Documentation,
    DoubleWallCarton,
    DVD,
    EconoWrap,
    EndSheet,
    Envelope,
    FinishedGood,
    FlatSheet,
    FoldedAndGatheredSig,
    FrontMatter,
    Gatefold,
    HalfJacket,
    Handbook,
    HollowWrap,
    Insert,
    Jacket,
    Jcard,
    JewelCase,
    Jiffy,
    Jwrap,
    Label,
    LaserDisc,
    //Liner-Corrugation,
    Loose,
    MakeReady,
    Map,
    Material,
    Media,
    MediaHolder,
    OWrap,
    Packaging,
    Paper,
    PaperCover,
    PeelStickCD,
    Pocket,
    PolyBag,
    Prep,
    Preprinted,
    PreprintedCaseside,
    ReplyCard,
    Run,
    SheetSignature,
    SheetWise,
    Shrinkwrapping,
    Signature,
    SingleWallCarton,
    Skagg,
    Sleeve,
    Slide,
    SlimPack,
    SlipCase,
    SlipCaseWrap,
    SoftwareStyle,
    Spine,
    Sticker,
    SubAssembly,
    SuperJWrap,
    TCarton,
    Tab,
    Text,
    Transparency,
    Transvision,
    Video,
    VinylPack,
    WebSignature,
    WorkAndBack,
    WorkAndTurn,
    Wrap,
    ZipLockBag,
}

public enum ProofType
{
    Blues,
    ColorKey,
    Cromalin,
    CustomCromalin,
    DigitalProofs,
    Dylux,
    FilmProofs,
    FoldedGathered,
    InkDrawDown,
    Iris,
    MatchPrint,
    PressProofs,
    ReferenceCDCassette,
    Samples,
    //T-Print,
    Other,
}

public enum PrepType
{
    //4PageImposedFilm,
    //8PageImposedFilm,
    ApplicationFiles,
    Bookmap,
    CameraCopy,
    CopyBook,
    DuplicateStrip,
    ElectronicFiles,
    ElectronicGraphic,
    Film,
    FilmPageNegatives,
    FilmPagePositives,
    llustrationFilm,
    NegativeImposedPlateMakingFilm,
    Originals,
    OriginalArt,
    Other,
    Overtakes,
    PageProof,
    PDF,
    PositiveImposedPlateMakingFilm,
    RachwalFilm,
    ReflectiveArtBoard,
    ReproProof,
    RestripSuppliedFlats,
    TearSheet,
    Transparencies,
}

public enum SuppliedComponentType
{
    Component,
    RawMaterial,
}

public enum ProductIdentifierType
{
    BrandName,
    CatalogueNumber,
    CustomsTariffNumber,
    EAN8,
    EAN13,
    ExportHarmonisedSystemCode,
    FinishedGoodIdentifier,
    GradeCode,
    GradeName,
    ImportHarmonisedSystemCode,
    ManufacturingGradeCode,
    ManufacturingGradeName,
    Ondule,
    PartNumber,
    RFQPartNumber,
    SKU,
    UPC,
    Other,
}

public enum CoatingTop
{
    Acrylic,
    Flexolyn,
    FoilCoated,
    GreaseBarrier,
    Metallic,
    MetalizedPolyester,
    MoistureBarrier,
    MoldInhibitor,
    None,
    OilBarrier,
    OxygenBarrier,
    Plastic,
    PolyCoating,
    Polyethylene,
    Pyroxylin,
    Silicone,
}

public enum CoatingBottom
{
    Acrylic,
    Flexolyn,
    FoilCoated,
    GreaseBarrier,
    Metallic,
    MetalizedPolyester,
    MoistureBarrier,
    MoldInhibitor,
    None,
    OilBarrier,
    OxygenBarrier,
    Plastic,
    PolyCoating,
    Polyethylene,
    Pyroxylin,
    Silicone,
}

public enum FinishType
{
    Bond,
    Clear,
    CustomTint,
    Dull,
    English,
    Gloss,
    Hazy,
    Laid,
    Linen,
    Machine,
    Matte,
    Metalized,
    Satin,
    SCA,
    SCB,
    SCC,
    Silk,
    Silver,
    Smooth,
    SoftGloss,
    TransparentBlue,
    Vellum,
    Velvet,
}

public enum PrintType
{
    ColdsetOffset,
    ContinuousForms,
    Digital,
    Flexography,
    FoilPrint,
    Forms,
    Gravure,
    HeatsetOffset,
    InkJet,
    InstantOffset,
    Laser,
    Letterpress,
    LightPrint,
    MiniWeb,
    RotoFlexography,
    RotoGravure,
    RotoLetterpress,
    RotoSilkScreen,
    SheetfedOffset,
    SilkScreen,
    WebOffset,
}

public enum TestMethod
{

}

public enum TestAgency
{
    ASTM,
    BS,
    CIE,
    DuPont,
    EN,
    GE,
    ImageXpert,
    ISO,
    //NS-EN,
    PAPTAC,
    //SCAN-test,
    //SFS-EN,
    //SS-EN,
    TAPPI,
}

public enum SampleType
{
    Average,
    Bottom,
    CDAverage,
    CDBottom,
    CDTop,
    MDAverage,
    MDBottom,
    MDTop,
    Target,
    Top,
}

public enum ResultSource
{
    AutoLab,
    Calculated,
    ManualLab,
    OnMachine,
    Predicted,
}

public enum SpeciesType
{
    Afrormosia,
    Afzelia,
    Agba,
    AlaskanCedar,
    Alder,
    AlpineFir,
    AmabilisFir,
    Amapa,
    Andoung,
    Anegre,
    Antiaris,
    Ash,
    Aspen,
    AspenPolar,
    AustrianSpruce,
    Avodire,
    Ayan,
    Ayous,
    Ako,
    BalsamFir,
    BalsamPolar,
    Bamboo,
    Basswood,
    Beech,
    Birch,
    BirdseyeMaple,
    BlackCherry,
    BlackCottonwood,
    BlackGuarea,
    BlackSpruce,
    Bubinga,
    CaliforniaRedFir,
    CaribeanPine,
    CarolinaPine,
    Cedar,
    Ceiba,
    CembraPine,
    Cherry,
    Chestnut,
    CoastSpecies,
    Cypress,
    Danta,
    DouglasFir,
    Douka,
    EasternCottonwood,
    EasternHemlock,
    EasternSoftwoods,
    EasternSpruce,
    EasternWhiteCedar,
    EasternWhitePine,
    Elliotti,
    EngelmanSpruce,
    Eucalyptus,
    EuropeanLarch,
    Exotic,
    FigureSycamore,
    Fir,
    Frake,
    Framire,
    Gaboon,
    GrandFir,
    GreyElm,
    HardMaple,
    Hemlock,
    Hornbeam,
    IdahoWhitePine,
    Ilomba,
    Imbira,
    IncCedar,
    InlRedCedar,
    Ipe,
    Iroko,
    JackPine,
    Kaya,
    Koto,
    Larch,
    LarricioPine,
    Lauan,
    Limba,
    Locust,
    LodgepolePine,
    Mahogany,
    Macoré,
    Mansonia,
    Maple,
    MaritimePine,
    Meranti,
    Merbeau,
    MexicanPine,
    MixedSoftwood,
    MixedSYP,
    MixedTropicalHardwood,
    MntnHemlock,
    Niangon,
    NobelFir,
    NorwaySpruce,
    NorthernAspen,
    NorthernPine,
    NorthernSpecies,
    Oak,
    Okume,
    OliverAsh,
    Olon,
    Omu,
    OregonPine,
    Ozigo,
    PacificCoastHemlock,
    PacificSilverFir,
    Padauk,
    PaoAmarello,
    Pear,
    Pearwood,
    Pine,
    Plane,
    PlywoodComposite,
    PonderosaPine,
    PrtOrfCed,
    Poucouli,
    Purpleheart,
    Radiata,
    RadiataPine,
    RedCedar,
    RedElm,
    RedOak,
    RedPine,
    RedSpruce,
    RedWhitewood,
    Redwood,
    RioRosewood,
    Rosewood,
    SandPine,
    SantosRosewood,
    Sapelle,
    Satinwood,
    ScotsPine,
    SilkyOak,
    SitkaSpruce,
    SouthernPine,
    SouthernPondPine,
    SouthernSprucePine,
    SPF,
    Spruce,
    SugarPine,
    SwissPear,
    SwissStonePine,
    Sycamore,
    SYP,
    Taeda,
    Tamarack,
    Tauari,
    Teak,
    Tiama,
    Tineo,
    TropicalOliver,
    Utile,
    VirginiaPine,
    Walnut,
    Wenge,
    Wey,
    WesternCedars,
    WesternHemlock,
    WesternRedCedar,
    WesternWhitePine,
    WesternWhiteSpruce,
    WesternWoods,
    WhitebarkPine,
    WhiteFir,
    WhiteOak,
    WhiteSpruce,
    WhiteWood,
    YellowCedar,
    YellowCypress,
    YellowPoplar,
    Zebrano,
    Other,
}

public enum SpeciesOrigin
{
    Africa,
    America,
    Austria,
    Bavaria,
    Brasil,
    Canada,
    Estonia,
    European,
    Finland,
    French,
    Germany,
    Indian,
    Latvia,
    Lithuania,
    Norway,
    Russia,
    Sweden,
    North,
    South,
    Eastern,
    Western,
    Coast,
    Inland,
    Other,
}

public enum SpeciesAgency
{
    ISO,
    //prEN TC(1113-1),
    Supplier,
}

// TODO :  Write enum member value
public enum GradeType
{
    [EnumMember(Value = "#1")]
    Num1,
    [EnumMember(Value = "#1 and #2")]
    Num1AndNum2,
    //#1 and #2 Clear 
    //#1 (SRB) 
    //#1 Box 
    //#1 Commons 
    //#1 Cuts 
    //#1 Cuttings 
    //#1 Dense 
    //#1 Dense Stadium Grade 
    //#1 Dense Structural 
    //#1 Door Cuttings 
    //#1 Fencing (Select) 
    //#1 Furniture 
    //#1 Lath 
    //#1 Mining 
    //#1 Non Dense 
    //#1 Pencil Stock 
    //#1 Prime 
    //#1 Sash Cuttings 
    //#1 Shop
    //#1 Stadium Grade 
    //#1 Structural 
    //#1 and Btr 
    //#2 
    //#2 (SRB) 
    //#2 Box 
    //#2 Common 
    //#2 Cuts 
    //#2 Cuttings 
    //#2 Dense 
    //#2 Door Cuttings 
    //#2 Fencing (Quality) 
    //#2 Foundation 
    //#2 Furniture 
    //#2 Lath 
    //#2 Mining 
    //#2 Non Dense 
    //#2 Pencil Stock 
    //#2 Prime 
    //#2 Sash Cuttings 
    //#2 Shop 
    //#2 Structural 
    //#2 and Btr 
    //#2 and Btr Common 
    //#2 and Btr Fencing(Rustic) 
    //#3 
    //#3 (SRB) 
    //#3 Clear 
    //#3 Common 
    //#3 Cuttings 
    //#3 Fencing 
    //#3 Fencing (Rustic) 
    //#3 Lath
    //#3 Pencil Stock 
    //#3 Shop 
    //#3 Shop or Sash 
    //#3 and Btr 
    //#3 and Btr Common 
    //#4 
    //#4 Common 
    //#5 Common 
    //1.5E LAM 
    //1.6E LAM 
    //1.7E LAM 
    //1.8E LAM 
    //1.9E LAM 
    //1200f 
    //1350f 
    //1400f 
    //1450f 
    //1500f 
    //1600f 
    //1650f 
    //1800f 
    //1950f 
    //2.0E LAM 
    //2.1E LAM 
    //2.2E LAM 
    //2.3E LAM 
    //2.4E LAM 
    //2.5E LAM 
    //2.6E LAM 
    //2000f 
    //2100f 
    //2200f Scaffold Plank 
    //2250f 
    //2400f 
    //2400f Scaffold Plank 
    //2550f 
    //26002-83 
    //2700f 
    //2850f 
    //3000f 
    //302-20 
    //302-22 
    //302-24 
    //3150f 
    //3300f 
    //8486
    //900f
    A,
    //A and Btr
    //Appearance Knotty
    //Architect Clear
    //Architect Knotty
    B,
    //B and B
    //B Grade
    //B Laminating
    //B and Btr
    //B and Btr - 1 and 2 Clear
    //B.F.Laminating
    //Barge Framing
    //Barge Planking and Decking
    Battens,
    C,
    //C Laminating
    //C Select
    //C Ship Decking
    //C and Btr
    //C and Btr Dimension
    //C and Btr Select
    //C and Btr-VG Stepping
    //California Fencing
    Choice,
    //Choice and Btr
    Clear,
    //Clear All Heart
    //Clear Door
    //Clear Door Rip
    //Clear Finger Joint
    //Clear Gutter
    //Clear Heart
    //Clear VG Heart
    Colonial,
    //Commercial Decking
    //Commercial Dex
    //Commercial Patio
    //Construction
    //Construction (SRB) 
    //Construction Common
    //Construction Heart
    Crossarms,
    //Custom Clear
    //Custom knotty
    //Cut Door Stock
    D,
    //D Dimension
    //D Laminating
    //D Select
    //D and Btr
    //D and Btr Select
    //Deck Common
    //Deck Heart
    //Dense Commercial Decking
    //Dense Industrial Scaffold plank 65 
    //Dense Industrial Scaffold Plank 72 
    //Dense Premium
    //Dense Select Decking
    //Dense Select Structural
    //Dense Standard Decking
    Dunnage,
    //D0VD Stepping
    E,
    Economy,
    //Economy Fencing
    //Economy Stud
    //Factory Flitches
    //Factory Select
    //FG or MG Ladder Rails
    //Fingerjoint Shop Common
    Finish,
    Foundation,
    Gutter,
    //Heart B
    //Heart Clear
    Industrial,
    //Industrial 26 
    //Industrial 45 
    //Industrial 55 
    Knotty,
    //Knotty Finger Joint
    //L1 Dense Laminating
    //L1 Laminating
    //L1-c Laminating
    //L2 Laminating
    //L2-d Dense Laminating
    //L3 Laminating
    //Ladder and Pole Stock
    //Ladder Rail Stock
    //M-10 
    //M-11 
    //M-12 
    //M-13 
    //M-14 
    //M-15 
    //M-16 
    //M-17 
    //M-18 
    //M-19 
    //M-20 
    //M-21 
    //M-22 
    //M-23 
    //M-24 
    //M-25 
    //M-26 
    //M-27 
    //M-28 
    //M-29 
    //M-30 
    //M-31 
    //M-5 
    //M-6 
    //M-7 
    //M-8
    //M-9 
    //Margin Plank
    //Mast Spar and Boat Two and One-Fourth Inch and Thicker
    //Mast Spar and Boat One to Two Inch
    Merchantable,
    //Merchantable Heart
    MillGrade,
    //Moulding Stock (A) 
    //Moulding Stock (B) 
    //Moulding and Btr
    Mouldings,
    //NeLMA # 1A Furniture 
    //NeLMA # 2A Furniture 
    None,
    //NSLB #1 
    //NSLB #2 
    Par99,
    //Patio 1 
    //Patio 2 
    //Pipe Stave Stock
    //Plank Wall
    Premium,
    //Premium and Btr
    Prime,
    Quality,
    //Quality Fencing
    //Quality Knotty
    //RadiusEdgeDecking 1 
    //RadiusEdgeDecking 2 
    Rustic,
    //Rustic Fencing
    //Rustic Knotty
    Sash,
    //Sash Cuttings
    //Sawn Railroad Ties
    //Scaffold #1 
    //Scaffold #2 
    Select,
    //Select and Quality Knotty
    //Select Decking
    //Select Dex
    //Select Fencing
    //Select Heart
    //Select Knotty
    //Select Merchantable
    //Select Patio
    //Select Shop
    //Select Structural
    //Select Structural (SRB) 
    //Select Structural Non Dense
    Selected,
    //Selected #2 Common 
    //Selected #3 Common 
    //Selected Decking
    //Selected Gutter
    //Ship Decking
    //Ship Plank
    //Shop Flitches
    Short,
    //Short Select
    //SPS 1 Certified Fingerjointed
    //SPS 3 Certified Fingerjointed
    //Stadium Plank Seats
    //Stadium Plank Walk boards
    //Stadium Planks
    //Stained Selects
    Standard,
    //Standard (SRB) 
    //Standard Mouldings
    //Standard and Btr
    Sterling,
    Stud,
    //Stud (SRB) 
    Superior,
    Supreme,
    //Tank Stock Inch and Thicker
    //Tank Stock Under Four Inch
    Utility,
    //Utility (#2 Mining) 
    //Utility (SRB) 
    //Utility and Btr
    //VG Ladder Rails
}

public enum ActualNominal
{
    Actual,
    Covering,
    Modal,
    Nominal,
}

public enum WithGrain
{
    Yes,
    No,
}

public enum GradingRule
{
    [EnumMember(Value = "European 1611-1")]
    European_1611_1,
    GSSS,
    Nordic,
    [EnumMember(Value = "SS EN 230120")]
    SS_EN_230120,
    Supplier,
    Other,
}

public enum LumberAgency
{
    BS,
    [EnumMember(Value = "BS-EN")]
    BS_EN,
    CEN,
    DIN,
    EN338,
    EN1912,
    [EnumMember(Value = "EN1611-1")]
    EN1611_1,
    EDISAW,
    Generic,
    GOST,
    ISO,
    JAS,
    NELMA,
    NLGA,
    NS,
    NSLB,
    RIS,
    RT,
    SIS,
    SPIB,
    WCLIB,
    WRCLA,
    WWPA,
    Supplier,
}

public enum ModulusElasticity
{
    [EnumMember(Value = "1.0E")]
    E1_0,
    [EnumMember(Value = "1.1E")]
    E1_1,
    [EnumMember(Value = "1.2E")]
    E1_2,
    [EnumMember(Value = "1.3E")]
    E1_3,
    [EnumMember(Value = "1.4E")]
    E1_4,
    [EnumMember(Value = "1.5E")]
    E1_5,
    [EnumMember(Value = "1.6E")]
    E1_6,
    [EnumMember(Value = "1.7E")]
    E1_7,
    [EnumMember(Value = "1.8E")]
    E1_8,
    [EnumMember(Value = "1.9E")]
    E1_9,
    [EnumMember(Value = "2.0E")]
    E2_0,
    [EnumMember(Value = "2.1E")]
    E2_1,
    [EnumMember(Value = "2.2E")]
    E2_2,
    [EnumMember(Value = "2.3E")]
    E2_3,
    [EnumMember(Value = "2.4E")]
    E2_4,
}

public enum Face
{
    Face1,
    Face2,
    Both,
}

public enum SeasoningType
{
    Dry,
    Green,
    KD,
    KDAT,
    PAD,
    ShippingDry,
    SurfacedDry,
    SurfacedGreen,
}

public enum MoistureContentPercentage
{
    [EnumMember(Value = "1")]
    _1,
    [EnumMember(Value = "2")]
    _2,
    [EnumMember(Value = "3")]
    _3,
    [EnumMember(Value = "4")]
    _4,
    [EnumMember(Value = "5")]
    _5,
    [EnumMember(Value = "6")]
    _6,
    [EnumMember(Value = "7")]
    _7,
    [EnumMember(Value = "8")]
    _8,
    [EnumMember(Value = "9")]
    _9,
    [EnumMember(Value = "10")]
    _10,
    [EnumMember(Value = "11")]
    _11,
    [EnumMember(Value = "12")]
    _12,
    [EnumMember(Value = "13")]
    _13,
    [EnumMember(Value = "14")]
    _14,
    [EnumMember(Value = "15")]
    _15,
    [EnumMember(Value = "16")]
    _16,
    [EnumMember(Value = "18")]
    _18,
    [EnumMember(Value = "19")]
    _19,
    [EnumMember(Value = "20")]
    _20,
    [EnumMember(Value = "21")]
    _21,
    [EnumMember(Value = "22")]
    _22,
    [EnumMember(Value = "23")]
    _23,
    Other,
}

public enum HeatTreatmentType
{
    HT,
    [EnumMember(Value = "HTC/NHTNC")]
    HTC_NHTNC,
    [EnumMember(Value = "KD56/30")]
    KD56_30,
}

public enum ManufacturingProcessType
{
    Chamfered,
    Combed,
    Compressed,
    Cut,
    DrySplitted,
    EndMatched,
    Finesawn,
    [EnumMember(Value = "FJ-Lam")]
    FJ_Lam,
    [EnumMember(Value = "FJ-Blank")]
    FJ_Blank,
    FurtherProcess,
    FingerJointed,
    GlueLamBeam,
    GreenSplitted,
    [EnumMember(Value = "H and M")]
    H_and_M,
    [EnumMember(Value = "H or M")]
    H_or_M,
    HeatTreated,
    Impregnated,
    ImpregnatedA,
    ImpregnatedWolmanitAB,
    [EnumMember(Value = "KD56/30")]
    KD56_30,
    Lacquered,
    Lamwood,
    MachineStrengthGraded,
    NorthFloor,
    Notched,
    OilTreated,
    [EnumMember(Value = "Opti-Blank")]
    Opti_Blank,
    Painted,
    Planed,
    [EnumMember(Value = "Pro-Lam")]
    Pro_Lam,
    Resawn,
    Rough,
    [EnumMember(Value = "Rougher Headed")]
    Rougher_Headed,
    RoughSawn,
    S1E,
    S1S,
    [EnumMember(Value = "S1S EdgeRgh")]
    S1S_EdgeRgh,
    S1S1E,
    S1S2E,
    S2E,
    S2S,
    [EnumMember(Value = "S2S EdgeRgh")]
    S2S_EdgeRgh,
    S2S1E,
    S4S,
    S4SEE,
    Sawn,
    SawTexture,
    Smooth,
    Split,
    StrengthGraded,
    Treated,
    Vstol,
    Other,
}

public enum ManufacturingProcessAgency
{
    ISO,
    [EnumMember(Value = "prEN TC(1113-1)")]
    prEN_TC_1113_1,
    Supplier,
}

public enum PatternProfileType
{
    [EnumMember(Value = "Beveled Siding")] Beveled_Siding,
    [EnumMember(Value = "Bungalow Siding")] Bungalow_Siding,
    [EnumMember(Value = "Channel Rustic Siding")] Channel_Rustic_Siding,
    [EnumMember(Value = "Colonial Siding")] Colonial_Siding,
    [EnumMember(Value = "Dolly Varden Siding")] Dolly_Varden_Siding,
    [EnumMember(Value = "Log Cabin Siding")] Log_Cabin_Siding,
    [EnumMember(Value = "Boston Pattern")] Boston_Pattern,
    [EnumMember(Value = "CaulkingSeam")] CaulkingSeam,
    [EnumMember(Value = "CB1S")] CB1S,
    [EnumMember(Value = "CB2S")] CB2S,
    [EnumMember(Value = "CG2E")] CG2E,
    [EnumMember(Value = "CM")] CM,
    [EnumMember(Value = "CM 1/4 T and G")] CM_1_4_T_and_G,
    [EnumMember(Value = "CM 3/8 T and G")] CM_3_8_T_and_G,
    [EnumMember(Value = "CM and EV 1S")] CM_and_EV_1S,
    [EnumMember(Value = "CM and EV 2S")] CM_and_EV_2S,
    [EnumMember(Value = "CV1S")] CV1S,
    [EnumMember(Value = "CV2S")] CV2S,
    [EnumMember(Value = "D and CM")] D_and_CM,
    [EnumMember(Value = "Dbl Plowed")] Dbl_Plowed,
    [EnumMember(Value = "E and CB1S")] E_and_CB1S,
    [EnumMember(Value = "E and CB2S")] E_and_CB2S,
    [EnumMember(Value = "E and CV2S")] E_and_CV2S,
    [EnumMember(Value = "EB1S")] EB1S,
    [EnumMember(Value = "EB2S")] EB2S,
    [EnumMember(Value = "EV1S")] EV1S,
    [EnumMember(Value = "EV2S")] EV2S,
    [EnumMember(Value = "Grooved for Splines")] Grooved_for_Splines,
    [EnumMember(Value = "Plowed")] Plowed,
    [EnumMember(Value = "S2S and CM 1/4 T and G")] S2S_and_CM_1_4_T_and_G,
    [EnumMember(Value = "S2S and CM 3/8 T and G")] S2S_and_CM_3_8_T_and_G,
    [EnumMember(Value = "ShipLap")] ShipLap,
    [EnumMember(Value = "ShipLap - 1/2 lap")] ShipLap___1_2_lap,
    [EnumMember(Value = "ShipLap - 3/8 lap")] ShipLap___3_8_lap,
    [EnumMember(Value = "ShipLap and EV1S")] ShipLap_and_EV1S,
    [EnumMember(Value = "T and G")] T_and_G,
    [EnumMember(Value = "V Rustic")] V_Rustic,
    [EnumMember(Value = "V-CV Rustic")] V_CV_Rustic,
    [EnumMember(Value = "Channel Decking")] Channel_Decking,
    [EnumMember(Value = "S2S CM and EV1S Decking")] S2S_CM_and_EV1S_Decking,
    [EnumMember(Value = "Comnation Ceiling")] Comnation_Ceiling,
    [EnumMember(Value = "DblBeaded Ceiling")] DblBeaded_Ceiling,
    [EnumMember(Value = "Double Beaded Ceiling")] Double_Beaded_Ceiling,
    [EnumMember(Value = "E and CB Ceiling")] E_and_CB_Ceiling,
    [EnumMember(Value = "E and CV Ceiling")] E_and_CV_Ceiling,
    [EnumMember(Value = "EB Ceiling")] EB_Ceiling,
    [EnumMember(Value = "EV Ceiling")] EV_Ceiling,
    [EnumMember(Value = "V Ceiling")] V_Ceiling,
    [EnumMember(Value = "Beaded Partition")] Beaded_Partition,
    [EnumMember(Value = "DblBeaded Partition")] DblBeaded_Partition,
    [EnumMember(Value = "E and CB Partition")] E_and_CB_Partition,
    [EnumMember(Value = "E and CV Partition")] E_and_CV_Partition,
    [EnumMember(Value = "V Partition")] V_Partition,
    [EnumMember(Value = "Flooring")] Flooring,
    [EnumMember(Value = "Flooring D and M")] Flooring_D_and_M,
    [EnumMember(Value = "Flooring S2S and CM")] Flooring_S2S_and_CM,
    [EnumMember(Value = "Special D and M Flooring")] Special_D_and_M_Flooring,
    [EnumMember(Value = "EasedEdge")] EasedEdge,
    [EnumMember(Value = "Rabbeted")] Rabbeted,
    [EnumMember(Value = "RadiusEdge")] RadiusEdge,
    [EnumMember(Value = "Beaded Shelving 2 Bead,")] Beaded_Shelving_2_Bead,
    [EnumMember(Value = "Beaded Shelving 3 Bead")] Beaded_Shelving_3_Bead,
    [EnumMember(Value = "Casket Stock S3S G1E")] Casket_Stock_S3S_G1E,
    [EnumMember(Value = "Casket Stock S3S T1E")] Casket_Stock_S3S_T1E,
    [EnumMember(Value = "Corn Cribbing")] Corn_Cribbing,
    [EnumMember(Value = "Grooved Roofing")] Grooved_Roofing,
    [EnumMember(Value = "Gutter-Boston")] Gutter_Boston,
    [EnumMember(Value = "Gutter-Ohio")] Gutter_Ohio,
    [EnumMember(Value = "Jamb")] Jamb,
    [EnumMember(Value = "Ogee Batten")] Ogee_Batten,
    [EnumMember(Value = "Patent Lath")] Patent_Lath,
    [EnumMember(Value = "Pulley Stile")] Pulley_Stile,
    [EnumMember(Value = "Still")] Still,
    [EnumMember(Value = "1")] _1,
    [EnumMember(Value = "2")] _2,
    [EnumMember(Value = "3")] _3,
    [EnumMember(Value = "4")] _4,
    [EnumMember(Value = "5")] _5,
    [EnumMember(Value = "6")] _6,
    [EnumMember(Value = "7")] _7,
    [EnumMember(Value = "8")] _8,
    [EnumMember(Value = "9")] _9,
    [EnumMember(Value = "10")] _10,
    [EnumMember(Value = "11")] _11,
    [EnumMember(Value = "12")] _12,
    [EnumMember(Value = "13")] _13,
    [EnumMember(Value = "14")] _14,
    [EnumMember(Value = "16")] _16,
    [EnumMember(Value = "18")] _18,
    [EnumMember(Value = "20")] _20,
    [EnumMember(Value = "50")] _50,
    [EnumMember(Value = "52")] _52,
    [EnumMember(Value = "54")] _54,
    [EnumMember(Value = "56")] _56,
    [EnumMember(Value = "58")] _58,
    [EnumMember(Value = "60")] _60,
    [EnumMember(Value = "62")] _62,
    [EnumMember(Value = "64")] _64,
    [EnumMember(Value = "66")] _66,
    [EnumMember(Value = "68")] _68,
    [EnumMember(Value = "71")] _71,
    [EnumMember(Value = "101")] _101,
    [EnumMember(Value = "102")] _102,
    [EnumMember(Value = "103")] _103,
    [EnumMember(Value = "104")] _104,
    [EnumMember(Value = "105")] _105,
    [EnumMember(Value = "106")] _106,
    [EnumMember(Value = "109")] _109,
    [EnumMember(Value = "110")] _110,
    [EnumMember(Value = "115")] _115,
    [EnumMember(Value = "116")] _116,
    [EnumMember(Value = "117")] _117,
    [EnumMember(Value = "118")] _118,
    [EnumMember(Value = "119")] _119,
    [EnumMember(Value = "121")] _121,
    [EnumMember(Value = "122")] _122,
    [EnumMember(Value = "123")] _123,
    [EnumMember(Value = "124")] _124,
    [EnumMember(Value = "125")] _125,
    [EnumMember(Value = "130")] _130,
    [EnumMember(Value = "131")] _131,
    [EnumMember(Value = "132")] _132,
    [EnumMember(Value = "133")] _133,
    [EnumMember(Value = "134")] _134,
    [EnumMember(Value = "136")] _136,
    [EnumMember(Value = "137")] _137,
    [EnumMember(Value = "138")] _138,
    [EnumMember(Value = "139")] _139,
    [EnumMember(Value = "140")] _140,
    [EnumMember(Value = "141")] _141,
    [EnumMember(Value = "142")] _142,
    [EnumMember(Value = "143")] _143,
    [EnumMember(Value = "144")] _144,
    [EnumMember(Value = "145")] _145,
    [EnumMember(Value = "153")] _153,
    [EnumMember(Value = "161")] _161,
    [EnumMember(Value = "165")] _165,
    [EnumMember(Value = "166")] _166,
    [EnumMember(Value = "168")] _168,
    [EnumMember(Value = "170")] _170,
    [EnumMember(Value = "171")] _171,
    [EnumMember(Value = "172")] _172,
    [EnumMember(Value = "173")] _173,
    [EnumMember(Value = "173 Spline")] _173_Spline,
    [EnumMember(Value = "174")] _174,
    [EnumMember(Value = "200")] _200,
    [EnumMember(Value = "202")] _202,
    [EnumMember(Value = "204")] _204,
    [EnumMember(Value = "206")] _206,
    [EnumMember(Value = "220A")] _220A,
    [EnumMember(Value = "222A")] _222A,
    [EnumMember(Value = "224A")] _224A,
    [EnumMember(Value = "300")] _300,
    [EnumMember(Value = "302")] _302,
    [EnumMember(Value = "304")] _304,
    [EnumMember(Value = "305-a")] _305_a,
    [EnumMember(Value = "305-b")] _305_b,
    [EnumMember(Value = "305-c")] _305_c,
    [EnumMember(Value = "305-d")] _305_d,
    [EnumMember(Value = "305-e")] _305_e,
    [EnumMember(Value = "405-a")] _405_a,
    [EnumMember(Value = "405-b")] _405_b,
    [EnumMember(Value = "405-c")] _405_c,
    [EnumMember(Value = "405-d")] _405_d,
    [EnumMember(Value = "405-e")] _405_e,
    [EnumMember(Value = "Other")] Other,

}

public enum PatternProfileAgency
{
    [EnumMember(Value = "BS")] BS,
    [EnumMember(Value = "BS-EN")] BS_EN,
    [EnumMember(Value = "CEN")] CEN,
    [EnumMember(Value = "DIN")] DIN,
    [EnumMember(Value = "EN338")] EN338,
    [EnumMember(Value = "EN1912")] EN1912,
    [EnumMember(Value = "EN1611-1 ")] EN1611_1_,
    [EnumMember(Value = "EDISAW")] EDISAW,
    [EnumMember(Value = "Generic")] Generic,
    [EnumMember(Value = "GOST")] GOST,
    [EnumMember(Value = "ISO")] ISO,
    [EnumMember(Value = "JAS")] JAS,
    [EnumMember(Value = "NELMA")] NELMA,
    [EnumMember(Value = "NLGA")] NLGA,
    [EnumMember(Value = "NS")] NS,
    [EnumMember(Value = "NSLB")] NSLB,
    [EnumMember(Value = "RIS")] RIS,
    [EnumMember(Value = "RT")] RT,
    [EnumMember(Value = "SIS")] SIS,
    [EnumMember(Value = "SPIB")] SPIB,
    [EnumMember(Value = "WCLIB")] WCLIB,
    [EnumMember(Value = "WRCLA")] WRCLA,
    [EnumMember(Value = "WWPA")] WWPA,
    [EnumMember(Value = "Supplier")] Supplier,
}

public enum TrimType
{
    [EnumMember(Value = "DET")] DET,
    [EnumMember(Value = "PET")] PET,
    [EnumMember(Value = "SquareEndTrim")] SquareEndTrim,
    [EnumMember(Value = "Other")] Other,
}

public enum JoiningType
{
    [EnumMember(Value = "FingerJointed")] FingerJointed,
    [EnumMember(Value = "FingerJointed-VertUseOnly")] FingerJointed_VertUseOnly,
    [EnumMember(Value = "Glued-Up")] Glued_Up,
    [EnumMember(Value = "Other")] Other,
}

public enum PressureTreatmentComStdorUseCategory
{
    [EnumMember(Value = "C2")] C2,
    [EnumMember(Value = "C3")] C3,
    [EnumMember(Value = "C4")] C4,
    [EnumMember(Value = "C5")] C5,
    [EnumMember(Value = "C6")] C6,
    [EnumMember(Value = "C9")] C9,
    [EnumMember(Value = "C11")] C11,
    [EnumMember(Value = "C14")] C14,
    [EnumMember(Value = "C15")] C15,
    [EnumMember(Value = "C17")] C17,
    [EnumMember(Value = "C18")] C18,
    [EnumMember(Value = "C20")] C20,
    [EnumMember(Value = "C22")] C22,
    [EnumMember(Value = "C23")] C23,
    [EnumMember(Value = "C24")] C24,
    [EnumMember(Value = "C25")] C25,
    [EnumMember(Value = "C27")] C27,
    [EnumMember(Value = "C28")] C28,
    [EnumMember(Value = "C29")] C29,
    [EnumMember(Value = "C30")] C30,
    [EnumMember(Value = "C31")] C31,
    [EnumMember(Value = "C32")] C32,
    [EnumMember(Value = "C33")] C33,
    [EnumMember(Value = "C34")] C34,
    [EnumMember(Value = "C35")] C35,
    [EnumMember(Value = "N1")] N1,
    [EnumMember(Value = "N2")] N2,
    [EnumMember(Value = "UC2")] UC2,
    [EnumMember(Value = "UC3A")] UC3A,
    [EnumMember(Value = "UC3B")] UC3B,
    [EnumMember(Value = "UC4A")] UC4A,
    [EnumMember(Value = "UC4B")] UC4B,
    [EnumMember(Value = "UC4C")] UC4C,
    [EnumMember(Value = "UC5A")] UC5A,
    [EnumMember(Value = "UC5B")] UC5B,
    [EnumMember(Value = "UC5C")] UC5C,
    [EnumMember(Value = "UCFA")] UCFA,
    [EnumMember(Value = "UCFB")] UCFB,
}

public enum FireTreatmentType
{
    [EnumMember(Value = "FireTreated")] FireTreated,
    [EnumMember(Value = "Other")] Other,
}

public enum GradeStamped
{
    [EnumMember(Value = "Yes")] Yes,
    [EnumMember(Value = "No")] No,
}

public enum GradeStampLocation
{
    [EnumMember(Value = "Face")] Face,
    [EnumMember(Value = "Back")] Back,
    [EnumMember(Value = "Good Side")] Good_Side,
    [EnumMember(Value = "Bad Side")] Bad_Side,
    [EnumMember(Value = "Edge")] Edge,
    [EnumMember(Value = "End")] End,
}

public enum IdentifierCodeType
{
    [EnumMember(Value = "Carrier")] Carrier,
    [EnumMember(Value = "EAN8")] EAN8,
    [EnumMember(Value = "EAN8Plus2")] EAN8Plus2,
    [EnumMember(Value = "EAN8Plus5")] EAN8Plus5,
    [EnumMember(Value = "EAN13")] EAN13,
    [EnumMember(Value = "EAN13Plus2")] EAN13Plus2,
    [EnumMember(Value = "EAN13Plus8")] EAN13Plus8,
    [EnumMember(Value = "EAN128")] EAN128,
    [EnumMember(Value = "EPSMA")] EPSMA,
    [EnumMember(Value = "EUGROPA")] EUGROPA,
    [EnumMember(Value = "GlobalReturnableAssetNumber")] GlobalReturnableAssetNumber,
    [EnumMember(Value = "GlobalTradeItemNumber")] GlobalTradeItemNumber,
    [EnumMember(Value = "IFRA")] IFRA,
    [EnumMember(Value = "ISBN10")] ISBN10,
    [EnumMember(Value = "ISBN10Dash")] ISBN10Dash,
    [EnumMember(Value = "ISBN13")] ISBN13,
    [EnumMember(Value = "ISBN13Dash")] ISBN13Dash,
    [EnumMember(Value = "NARI")] NARI,
    [EnumMember(Value = "NPTA")] NPTA,
    [EnumMember(Value = "RFTagSerialNumber")] RFTagSerialNumber,
    [EnumMember(Value = "SerialisedShippingContainerCode")] SerialisedShippingContainerCode,
    [EnumMember(Value = "Supplier")] Supplier,
    [EnumMember(Value = "TAPPI13")] TAPPI13,
    [EnumMember(Value = "TAPPI9")] TAPPI9,
    [EnumMember(Value = "UCCEAN128SSCC")] UCCEAN128SSCC,
    [EnumMember(Value = "UCCEANMulti")] UCCEANMulti,
    [EnumMember(Value = "UIC14")] UIC14,
    [EnumMember(Value = "UIC16")] UIC16,
    [EnumMember(Value = "UPC")] UPC,
    [EnumMember(Value = "UPC_A")] UPC_A,
    [EnumMember(Value = "UPC_A_Plus2")] UPC_A_Plus2,
    [EnumMember(Value = "UPC_A_Plus5")] UPC_A_Plus5,
    [EnumMember(Value = "UPC_E")] UPC_E,
    [EnumMember(Value = "UPC_E_Plus2")] UPC_E_Plus2,
    [EnumMember(Value = "UPC_E_Plus5")] UPC_E_Plus5,
    [EnumMember(Value = "UPC_ShippingContainer")] UPC_ShippingContainer,
}

public enum IdentifierType
{
    [EnumMember(Value = "Barcode")] Barcode,
    [EnumMember(Value = "CorrelationID")] CorrelationID,
    [EnumMember(Value = "Primary")] Primary,
    [EnumMember(Value = "RFTag")] RFTag,
    [EnumMember(Value = "Secondary")] Secondary,
}

public enum IdentifierFormatType
{
    [EnumMember(Value = "Codabar")] Codabar,
    [EnumMember(Value = "CodablockA")] CodablockA,
    [EnumMember(Value = "CodablockF")] CodablockF,
    [EnumMember(Value = "Code11")] Code11,
    [EnumMember(Value = "Code16K")] Code16K,
    [EnumMember(Value = "Code2/5Beared")] Code2_5Beared,
    [EnumMember(Value = "Code2/5Industrial")] Code2_5Industrial,
    [EnumMember(Value = "Code2/5Interleaved")] Code2_5Interleaved,
    [EnumMember(Value = "Code2/5InterleavedMod10")] Code2_5InterleavedMod10,
    [EnumMember(Value = "Code2/5MatrixEurope")] Code2_5MatrixEurope,
    [EnumMember(Value = "Code2/5MatrixJapan")] Code2_5MatrixJapan,
    [EnumMember(Value = "Code2/5Standard")] Code2_5Standard,
    [EnumMember(Value = "Code39")] Code39,
    [EnumMember(Value = "Code39F.ASCII")] Code39F_ASCII,
    [EnumMember(Value = "Code39Mod43")] Code39Mod43,
    [EnumMember(Value = "Code93")] Code93,
    [EnumMember(Value = "Code128Auto-Switching")] Code128Auto_Switching,
    [EnumMember(Value = "Code128A")] Code128A,
    [EnumMember(Value = "Code128B")] Code128B,
    [EnumMember(Value = "Code128C")] Code128C,
    [EnumMember(Value = "Code128C(F1Mod10)")] Code128C_F1Mod10,
    [EnumMember(Value = "Composite")] Composite,
    [EnumMember(Value = "Datamatrix")] Datamatrix,
    [EnumMember(Value = "EAN8")] EAN8,
    [EnumMember(Value = "EAN8Plus2")] EAN8Plus2,
    [EnumMember(Value = "EAN8Plus5")] EAN8Plus5,
    [EnumMember(Value = "EAN13")] EAN13,
    [EnumMember(Value = "EAN13Plus2")] EAN13Plus2,
    [EnumMember(Value = "EAN13Plus8")] EAN13Plus8,
    [EnumMember(Value = "EAN128")] EAN128,
    [EnumMember(Value = "HumanReadable")] HumanReadable,
    [EnumMember(Value = "IBM_BC412")] IBM_BC412,
    [EnumMember(Value = "ITF14")] ITF14,
    [EnumMember(Value = "Logmars")] Logmars,
    [EnumMember(Value = "MicroPDF14")] MicroPDF14,
    [EnumMember(Value = "PDF417")] PDF417,
    [EnumMember(Value = "Plessey")] Plessey,
    [EnumMember(Value = "Postnet")] Postnet,
    [EnumMember(Value = "QR_Code")] QR_Code,
    [EnumMember(Value = "RSS")] RSS,
    [EnumMember(Value = "TLC39")] TLC39,
    [EnumMember(Value = "UPC_A")] UPC_A,
    [EnumMember(Value = "UPC_A_Plus2")] UPC_A_Plus2,
    [EnumMember(Value = "UPC_A_Plus5")] UPC_A_Plus5,
    [EnumMember(Value = "UPC_E")] UPC_E,
    [EnumMember(Value = "UPC_E_Plus2")] UPC_E_Plus2,
    [EnumMember(Value = "UPC_E_Plus5")] UPC_E_Plus5,
    [EnumMember(Value = "UCCEAN128SSCC")] UCCEAN128SSCC,
    [EnumMember(Value = "UCCEAN128Multi")] UCCEAN128Multi,
    [EnumMember(Value = "UPC_ShippingContainer")] UPC_ShippingContainer,
    [EnumMember(Value = "Other")] Other,
}

public enum StencilType
{
    [EnumMember(Value = "CutOut")] CutOut,
    [EnumMember(Value = "InkJet")] InkJet,
    [EnumMember(Value = "Rubber")] Rubber,
}

public enum StencilInkType
{
    [EnumMember(Value = "EdibleNotWaterSoluble")] EdibleNotWaterSoluble,
    [EnumMember(Value = "EdibleWaterSoluble")] EdibleWaterSoluble,
    [EnumMember(Value = "InedibleNotWaterSoluble")] InedibleNotWaterSoluble,
    [EnumMember(Value = "InedibleWaterSoluble")] InedibleWaterSoluble,
    [EnumMember(Value = "Unknown")] Unknown,
}

public enum StencilLocation
{
    [EnumMember(Value = "End")] End,
    [EnumMember(Value = "Top")] Top,
    [EnumMember(Value = "Side")] Side,
    [EnumMember(Value = "UnwrappedReelBilge")] UnwrappedReelBilge,
    [EnumMember(Value = "UnwrappedReelEnd")] UnwrappedReelEnd,
    [EnumMember(Value = "WrappedReelBilge")] WrappedReelBilge,
}

public enum StencilFormat
{
    [EnumMember(Value = "Barcode")] Barcode,
    [EnumMember(Value = "Text")] Text,
}

public enum StencilContent
{
    [EnumMember(Value = "Author")] Author,
    [EnumMember(Value = "BasisWeight")] BasisWeight,
    [EnumMember(Value = "BoxWeight")] BoxWeight,
    [EnumMember(Value = "BrandName")] BrandName,
    [EnumMember(Value = "Copyright")] Copyright,
    [EnumMember(Value = "Edition")] Edition,
    [EnumMember(Value = "ExportShipMark")] ExportShipMark,
    [EnumMember(Value = "GradeCode")] GradeCode,
    [EnumMember(Value = "GradeName")] GradeName,
    [EnumMember(Value = "Identifier")] Identifier,
    [EnumMember(Value = "ISBN10")] ISBN10,
    [EnumMember(Value = "ISBN10Dash")] ISBN10Dash,
    [EnumMember(Value = "ISBN13")] ISBN13,
    [EnumMember(Value = "ISBN13Dash")] ISBN13Dash,
    [EnumMember(Value = "LotIdentifier")] LotIdentifier,
    [EnumMember(Value = "PartNumber")] PartNumber,
    [EnumMember(Value = "PlainText")] PlainText,
    [EnumMember(Value = "PrintingNumber")] PrintingNumber,
    [EnumMember(Value = "ProductIdentifier")] ProductIdentifier,
    [EnumMember(Value = "ProfitCenter")] ProfitCenter,
    [EnumMember(Value = "PubName")] PubName,
    [EnumMember(Value = "PurchaseOrderNumber")] PurchaseOrderNumber,
    [EnumMember(Value = "PurchaseOrderReference")] PurchaseOrderReference,
    [EnumMember(Value = "ReferenceNumber")] ReferenceNumber,
    [EnumMember(Value = "RetailPrice")] RetailPrice,
    [EnumMember(Value = "TambourID")] TambourID,
    [EnumMember(Value = "Title")] Title,
    [EnumMember(Value = "TitleAlias")] TitleAlias,
    [EnumMember(Value = "UnitsPerCarton")] UnitsPerCarton,
    [EnumMember(Value = "UniversalProductIdentifier")] UniversalProductIdentifier,
    [EnumMember(Value = "VendorBrandName")] VendorBrandName,
    [EnumMember(Value = "VendorGradeCode")] VendorGradeCode,
    [EnumMember(Value = "VendorGradeName")] VendorGradeName,
}

public enum WrapType
{
    [EnumMember(Value = "Cardboard")] Cardboard,
    [EnumMember(Value = "Chipboard")] Chipboard,
    [EnumMember(Value = "Fibreboard")] Fibreboard,
    [EnumMember(Value = "KraftPaper")] KraftPaper,
    [EnumMember(Value = "Laminatedboard")] Laminatedboard,
    [EnumMember(Value = "Metal")] Metal,
    [EnumMember(Value = "None")] None,
    [EnumMember(Value = "Paper")] Paper,
    [EnumMember(Value = "Peelercores")] Peelercores,
    [EnumMember(Value = "Plastic")] Plastic,
    [EnumMember(Value = "PlasticBag")] PlasticBag,
    [EnumMember(Value = "Plywood")] Plywood,
    [EnumMember(Value = "Self")] Self,
    [EnumMember(Value = "ShrinkWrap")] ShrinkWrap,
    [EnumMember(Value = "StretchWrap")] StretchWrap,
    [EnumMember(Value = "Timber")] Timber,
}

public enum WrapProperties
{
    [EnumMember(Value = "Bleached")] Bleached,
    [EnumMember(Value = "Unbleached")] Unbleached,
    [EnumMember(Value = "MoistureBarrier")] MoistureBarrier,
    [EnumMember(Value = "Pulpable")] Pulpable,
}

public enum WrapLocation
{
    [EnumMember(Value = "None")] None,
    [EnumMember(Value = "Entire")] Entire,
    [EnumMember(Value = "Top")] Top,
    [EnumMember(Value = "Bottom")] Bottom,
    [EnumMember(Value = "FiveSides")] FiveSides,
    [EnumMember(Value = "TopAndEnds")] TopAndEnds,
    [EnumMember(Value = "Ends")] Ends,
    [EnumMember(Value = "LongSides")] LongSides,
}

public enum LengthCutType
{
    [EnumMember(Value = "ExactLength")] ExactLength,
    [EnumMember(Value = "FreeCut")] FreeCut,
    [EnumMember(Value = "SpecialLength")] SpecialLength,
    [EnumMember(Value = "Untrimmed")] Untrimmed,
    [EnumMember(Value = "1DecimeterCut")] _1DecimeterCut,
    [EnumMember(Value = "3DecimeterCut")] _3DecimeterCut,
}

public enum PackageAgency
{
    [EnumMember(Value = "BS")] BS,
    [EnumMember(Value = "BS-EN")] BS_EN,
    [EnumMember(Value = "CEN")] CEN,
    [EnumMember(Value = "DIN")] DIN,
    [EnumMember(Value = "EN338")] EN338,
    [EnumMember(Value = "EN1912")] EN1912,
    [EnumMember(Value = "EN1611-1 ")] EN1611_1_,
    [EnumMember(Value = "EDISAW")] EDISAW,
    [EnumMember(Value = "Generic")] Generic,
    [EnumMember(Value = "GOST")] GOST,
    [EnumMember(Value = "ISO")] ISO,
    [EnumMember(Value = "JAS")] JAS,
    [EnumMember(Value = "NELMA")] NELMA,
    [EnumMember(Value = "NLGA")] NLGA,
    [EnumMember(Value = "NS")] NS,
    [EnumMember(Value = "NSLB")] NSLB,
    [EnumMember(Value = "RIS")] RIS,
    [EnumMember(Value = "RT")] RT,
    [EnumMember(Value = "SIS")] SIS,
    [EnumMember(Value = "SPIB")] SPIB,
    [EnumMember(Value = "WCLIB")] WCLIB,
    [EnumMember(Value = "WRCLA")] WRCLA,
    [EnumMember(Value = "WWPA")] WWPA,
    [EnumMember(Value = "Supplier")] Supplier,
}

public enum BandType
{
    [EnumMember(Value = "Metal")] Metal,
    [EnumMember(Value = "Nylon")] Nylon,
    [EnumMember(Value = "Plastic")] Plastic,
    [EnumMember(Value = "Standard")] Standard,
}

public enum YesNo
{
    [EnumMember(Value = "Yes")] Yes,
    [EnumMember(Value = "No")] No,
}

public enum BandDirection
{
    [EnumMember(Value = "Long")] Long,
    [EnumMember(Value = "Short")] Short,
    [EnumMember(Value = "Both")] Both,
}

public enum PalletType
{
    [EnumMember(Value = "Euro")] Euro,
    [EnumMember(Value = "Export")] Export,
    [EnumMember(Value = "NonPalletised")] NonPalletised,
    [EnumMember(Value = "NonStop")] NonStop,
    [EnumMember(Value = "Twinned")] Twinned,
}

public enum PalletLedgeType
{
    [EnumMember(Value = "LongWay")] LongWay,
    [EnumMember(Value = "LongWayWithBelt")] LongWayWithBelt,
    [EnumMember(Value = "ShortWay")] ShortWay,
    [EnumMember(Value = "ShortWayWithBelt")] ShortWayWithBelt,
}
