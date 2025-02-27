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

    public DeliveryMessageWood()
    {

    }

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

    public DeliveryMessageDate()
    {

    }

    public DeliveryMessageDate(Date date)
    {
        Date = date;
    }

    public DeliveryMessageDate(XElement root)
    {
        var dateElement = root.Element("Date");

        Date = new Date(dateElement!);
    }

    public override string ToString()
    {
        return new XElement("DeliveryMessageDate",
            $"{Date}"
        ).ToString();
    }
}

public class Date
{
    public string Year = string.Empty;
    public string Month = string.Empty;
    public string Day = string.Empty;

    public Date()
    {

    }

    public Date(string year, string month, string day)
    {
        Year = year;
        Month = month;
        Day = day;
    }

    public Date(XElement root)
    {
        var yearElement = root.Element("Year");
        var monthElement = root.Element("Month");
        var dayElement = root.Element("Day");

        Year = yearElement!.Value;
        Month = monthElement!.Value;
        Day = dayElement!.Value;
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

    public Time()
    {

    }

    public Time(string value)
    {
        Value = value;
    }

    public Time(XElement root)
    {
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("Time",
            Value
        ).ToString();
    }
}

public class DeliveryMessageShipment
{
    public DeliveryMessageShipment()
    {

    }

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
    public Party BuyerParty = new();

    public DeliveryMessageWoodHeader()
    {

    }

    public DeliveryMessageWoodHeader(XElement root)
    {
        var deliveryMessageNumberElement = root.Element("DeliveryMessageNumber");
        var transactionHistoryNumberElement = root.Element("TransactionHistoryNumber");
        var deliveryMessageDateElement = root.Element("DeliveryMessageDate");
        var buyerPartyElement = root.Element("BuyerParty");

        DeliveryMessageNumber = deliveryMessageNumberElement!.Value;
        TransactionHistoryNumber = transactionHistoryNumberElement != null ? transactionHistoryNumberElement.Value : null;
        DeliveryMessageDate = new DeliveryMessageDate(deliveryMessageDateElement!);
    }
}

public class Party
{
    public string Name = string.Empty;
    public LogisticsRole? LogisticsRole;
    public List<PartyIdentifier> PartyIdentifier = [];
    public NameAddress NameAddress = new();
    public string? URL;
    public CommonContact? CommonContact;
}

public class CommonContact
{
    public ContactType ContactType;
    public string ContactName = string.Empty;
    public string? ContactIdentifier;
    public string? Telephone;
    public string? MobilePhone;
    public string? Email;
    public string? Fax;
    //public GPSCoordinates? GPSCoordinates;
    //public MapCoordinates? MapCoordinates;

    public CommonContact()
    {

    }

    public CommonContact(
        ContactType contactType, 
        string contactName, 
        string? contactIdentifier, 
        string? telephone, 
        string? mobilePhone, 
        string? email, 
        string? fax)
    {
        ContactType = contactType;
        ContactName = contactName;
        ContactIdentifier = contactIdentifier;
        Telephone = telephone;
        MobilePhone = mobilePhone;
        Email = email;
        Fax = fax;
    }

    public CommonContact(XElement root)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        throw new NotImplementedException();
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
    //public GPSCoordinates? GPSCoordinates;
    //public MapCoordinates? MapCoordinates;

    public NameAddress()
    {

    }

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
        string? iSOCountryCode)
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
    }

    public NameAddress(XElement root)
    {
        var communicationRoleAttribute = root.Attribute("CommunicationRole");
        var name1Element = root.Element("Name1");
        var name2Element = root.Element("Name2");
        var name3Element = root.Element("Name3");
        var organisationUnitElement = root.Element("OrganisationUnit");
        var address1Element = root.Element("Address1");
        var address2Element = root.Element("Address2");
        var address3Element = root.Element("Address3");
        var address4Element = root.Element("Address4");
        var cityElement = root.Element("City");
        var countyElement = root.Element("County");
        var stateOrProvinceElement = root.Element("StateOrProvince");
        var postalCodeElement = root.Element("PostalCode");
        var countryElement = root.Element("Country");

        var isoCountryCodeAttribute = countryElement?.Attribute("ISOCountryCode");

        CommunicationRole? CommunicationRole = communicationRoleAttribute != null ? Enum.Parse<CommunicationRole>(communicationRoleAttribute.Value) : null;
        Name1 = name1Element!.Value;
        Name2 = name2Element?.Value;
        Name3 = name3Element?.Value;
        OrganisationUnit = organisationUnitElement?.Value;
        Address1 = address1Element?.Value;
        Address2 = address2Element?.Value;
        Address3 = address3Element?.Value;
        Address4 = address4Element?.Value;
        City = cityElement?.Value;
        County = countyElement?.Value;
        StateOrProvince = stateOrProvinceElement?.Value;
        PostalCode = postalCodeElement?.Value;
        Country = countryElement?.Value;
        ISOCountryCode = isoCountryCodeAttribute?.Value;
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
                ISOCountryCode != null ? new XAttribute("ISOCountryCode", ISOCountryCode) : null,
                Country
            ) : null
        ).ToString();
    }
}

public class PartyIdentifier
{
    public PartyIdentifierType PartyIdentifierType = PartyIdentifierType.Other;
    public Agency? Agency;
    public string Value = string.Empty;

    public PartyIdentifier()
    {

    }

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
        var partyIdentifierTypeAttribute = root.Attribute("PartyIdentifierType");
        var agencyAttribute = root.Attribute("Agency");

        PartyIdentifierType = partyIdentifierTypeAttribute != null ? Enum.Parse<PartyIdentifierType>(partyIdentifierTypeAttribute.Value) : PartyIdentifierType.Other;
        Agency = agencyAttribute != null ? Enum.Parse<Agency>(agencyAttribute.Value) : null;
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
    public string? NumberOfDocumentsRequired = string.Empty;

    public DocumentReferenceInformation()
    {

    }

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
        var documentReferenceID = root.Element("DocumentReferenceID");
        var documentReferenceIDLineItemNumber = root.Element("DocumentReferenceIDLineItemNumber");
        var date = root.Element("Date");
        var time = root.Element("Time");
        var numberOfDocumentsRequired = root.Element("NumberOfDocumentsRequired");


    }

    public override string ToString()
    {
        return base.ToString();
    }
}

public class DeliveryMessageReference
{
    public DeliveryMessageReferenceType DeliveryMessageReferenceType = DeliveryMessageReferenceType.Other;
    public AssignedBy? AssignedBy;
    public string Value = string.Empty;

    public DeliveryMessageReference()
    {

    }

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
        var deliveryMessageReferenceTypeAttribute = root.Attribute("DeliveryMessageReferenceType");
        var assignedByAttribute = root.Attribute("AssignedBy");

        DeliveryMessageReferenceType = deliveryMessageReferenceTypeAttribute != null ? Enum.Parse<DeliveryMessageReferenceType>(deliveryMessageReferenceTypeAttribute.Value) : DeliveryMessageReferenceType.Other;
        AssignedBy = assignedByAttribute != null ? Enum.Parse<AssignedBy>(assignedByAttribute.Value) : null;
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