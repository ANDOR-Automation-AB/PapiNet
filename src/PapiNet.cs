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

public class DeliveryMessageWood
{
    public DeliveryMessageType DeliveryMessageType;
    public DeliveryMessageStatusType DeliveryMessageStatusType;
    public DeliveryMessageContextType? DeliveryMessageContextType;
    public bool? Reissued;
    public Language? Language;
    public DeliveryMessageWoodHeader DeliveryMessageWoodHeader = new();
    public DeliveryMessageShipment DeliveryMessageShipment = new();
    public DeliveryMessageWoodSummary? DeliveryMessageWoodSummary;

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
        return new XElement("DeliveryMessageDate", $"{Date}").ToString();
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
}

public class DeliveryMessageWoodHeader
{
    public string DeliveryMessageNumber = string.Empty;
    public string? TransactionHistoryNumber; // type nni9
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
}

public class ShipToInformation
{
    public ShipToCharacteristics ShipToCharacteristics = new();
    public DeliverySchedule? DeliverySchedule = null;
}

public class DeliverySchedule
{
    public string DeliveryLineNumber = string.Empty;
    public ProductionStatus? ProductionStatus = null;
    public DeliveryStatus? DeliveryStatus = null;
    public DeliveryDateWindow? DeliveryDateWindow = null;

}

public class DeliveryDateWindow
{

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