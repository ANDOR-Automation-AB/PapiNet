using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.XPath;

namespace PapiNet;

public class DeliveryMessageWood
{
    private readonly ILogger<DeliveryMessageWood>? _logger;
    public DeliveryMessageType DeliveryMessageType { get; set; } = DeliveryMessageType.DeliveryMessage;
    public DeliveryMessageStatusType DeliveryMessageStatusType { get; set; } = DeliveryMessageStatusType.Original;
    public DeliveryMessageContextType DeliveryMessageContextType { get; set; } = DeliveryMessageContextType.Unset;
    public YesNo Reissued { get; set; } = YesNo.Unset;
    public Language Language { get; set; } = Language.Unset;
    public DeliveryMessageWoodHeader DeliveryMessageWoodHeader { get; set; } = new();
    public List<DeliveryMessageShipment> DeliveryMessageShipment { get; } = [];
    public DeliveryMessageWoodSummary? DeliveryMessageWoodSummary { get; set; } = null;

    public string Value = string.Empty;  
    
    public DeliveryMessageWood(ILogger<DeliveryMessageWood>? logger = null) 
    {
        _logger = logger;
        _logger?.LogInformation("New delivery message has been added.");
    }

    public DeliveryMessageWood(XElement root, ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;
        DeliveryMessageType = root.Attribute("DeliveryMessageType")?.Value.ToEnum<DeliveryMessageType>(_logger) ?? DeliveryMessageType;
        DeliveryMessageStatusType = root.Attribute("DeliveryMessageStatusType")?.Value.ToEnum<DeliveryMessageStatusType>(_logger) ?? DeliveryMessageStatusType;
        DeliveryMessageContextType = root.Attribute("DeliveryMessageContextType")?.Value.ToEnum<DeliveryMessageContextType>(_logger) ?? DeliveryMessageContextType;
        Reissued = root.Attribute("Reissued")?.Value.ToEnum<YesNo>(_logger) ?? Reissued;
        //Language = root.Attribute("Language")?.Value.ToEnum<Language>(_logger) ?? Language;
        DeliveryMessageWoodHeader = root.Element("DeliveryMessageWoodHeader") is { } dmwh ? new(dmwh, _logger) : DeliveryMessageWoodHeader;
        DeliveryMessageShipment = [.. root.Elements("DeliveryMessageShipment").Select(e => new DeliveryMessageShipment(e, _logger))];
        DeliveryMessageWoodSummary = root.Element("DeliveryMessageWoodSummary") is { } dmws ? new(dmws, _logger) : DeliveryMessageWoodSummary;
        Value = root.Value;

        _logger?.LogInformation("New delivery message has been added.");
    }

    public override string ToString()
    {
        return new XElement("DeliveryMessageWood",
            new XAttribute("DeliveryMessageType", DeliveryMessageType),
            new XAttribute("DeliveryMessageStatusType", DeliveryMessageStatusType),
            DeliveryMessageContextType != DeliveryMessageContextType.Unset ? new XAttribute("DeliveryMessageContextType", DeliveryMessageContextType) : null,
            Reissued != YesNo.Unset ? new XAttribute("Reissued", Reissued) : null,
            XElement.Parse($"{DeliveryMessageWoodHeader}"),
            DeliveryMessageShipment.Select(obj => XElement.Parse($"{obj}")),
            DeliveryMessageWoodSummary != null ? XElement.Parse($"{DeliveryMessageWoodSummary}") : null
        ).ToString();
    }
}

public class DeliveryMessageWoodSummary
{
    private readonly ILogger<DeliveryMessageWood>? _logger;
    public TotalNumberOfShipments TotalNumberOfShipments { get; set; } = new();
    public TotalQuantity TotalQuantity { get; set; } = new();
    public List<TotalInformationalQuantity> TotalInformationalQuantity { get; } = [];
    public ProductSummary? ProductSummary { get; set; } = null;
    public LengthSpecification? LengthSpecification { get; set; } = null;
    public QuantityDeviation? QuantityDeviation { get; set; } = null;
    public CustomsTotals? CustomsTotals { get; set; } = null;
    public List<CustomsStampInformation> CustomsStampInformation { get; } = [];
    public List<TermsAndDisclaimers> TermsAndDisclaimers { get; } = [];
    public string Value = string.Empty;  
    

    public DeliveryMessageWoodSummary(ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;
        _logger?.LogInformation("New delivery message summary has been added.");
    }

    public DeliveryMessageWoodSummary(XElement root, ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;
        TotalNumberOfShipments = root.Element("TotalNumberOfShipments") is { } tnos ? new(tnos) : TotalNumberOfShipments;
        TotalQuantity = root.Element("TotalQuantity") is { } tq ? new(tq) : TotalQuantity;
        TotalInformationalQuantity = [.. root.Elements("TotalInformationalQuantity").Select(e => new TotalInformationalQuantity(e))];
        ProductSummary = root.Element("ProductSummary") is { } ps ? new(ps) : ProductSummary;
        LengthSpecification = root.Element("LengthSpecification") is { } ls ? new(ls) : LengthSpecification;
        QuantityDeviation = root.Element("QuantityDeviation") is { } qd ? new(qd) : QuantityDeviation;
        CustomsTotals = root.Element("CustomsTotals") is { } ct ? new(ct) : CustomsTotals;
        CustomsStampInformation = [.. root.Elements("CustomsStampInformation").Select(e => new CustomsStampInformation(e))];
        TermsAndDisclaimers = [.. root.Elements("TermsAndDisclaimers").Select(e => new TermsAndDisclaimers(e))];
        Value = root.Value;

        _logger?.LogInformation("New delivery message summary has been added.");
    }

    public override string ToString()
    {
        return new XElement("DeliveryMessageWoodSummary",
            XElement.Parse($"{TotalNumberOfShipments}"),
            XElement.Parse($"{TotalQuantity}"),
            TotalInformationalQuantity.Select(obj => XElement.Parse($"{obj}")),
            ProductSummary != null ? XElement.Parse($"{ProductSummary}") : null,
            LengthSpecification != null ? XElement.Parse($"{LengthSpecification}") : null,
            QuantityDeviation != null ? XElement.Parse($"{QuantityDeviation}") : null,
            CustomsTotals != null ? XElement.Parse($"{CustomsTotals}") : null,
            CustomsStampInformation.Select(obj => XElement.Parse($"{obj}")),
            TermsAndDisclaimers.Select(obj => XElement.Parse($"{obj}"))
        ).ToString();
    }
}

public class TermsAndDisclaimers
{
    private readonly ILogger<DeliveryMessageWood>? _logger;
    public Language Language { get; set; } = Language.Unset;
    public string Value = string.Empty;  
    

    public TermsAndDisclaimers(ILogger<DeliveryMessageWood>? logger = null) 
    {
        _logger = logger;
        _logger?.LogInformation("New terms and disclaimers has been added.");
    }

    public TermsAndDisclaimers(XElement root, ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;
        //Language = root.Attribute("Language")?.Value.ToEnum<Language>(_logger) ?? Language;
        Value = root.Value;

        _logger?.LogInformation("New terms and disclaimers has been added.");
    }

    public override string ToString()
    {
        return new XElement("TermsAndDisclaimers",
            //Language != null ? new XAttribute("Language", Language) : null,
            Value
        ).ToString();
    }
}

public class CustomsStampInformation
{
    private readonly ILogger<DeliveryMessageWood>? _logger;
    public List<CustomsStampHeaderText> CustomsStampHeaderText { get; } = [];
    public CustomsParty? CustomsParty { get; set; } = null;
    public CustomsStampDate? CustomsStampDate { get; set; } = null;
    public CustomsReferenceNumber? CustomsReferenceNumber { get; set; } = null;
    public SupplierCustomsReference? SupplierCustomsReference { get; set; } = null;
    public MillParty? MillParty { get; set; } = null;
    public CustomsStampTrailerText? CustomsStampTrailerText { get; set; } = null;
    public string Value = string.Empty;  
    

    public CustomsStampInformation(ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;

        _logger?.LogInformation("New customs stamp information has been added.");
    }

    public CustomsStampInformation(XElement root, ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;
        CustomsStampHeaderText = [.. root.Elements("CustomsStampHeaderText").Select(e => new CustomsStampHeaderText(e))];
        CustomsParty = root.Element("CustomsParty") is { } cp ? new(cp) : CustomsParty;
        CustomsStampDate = root.Element("CustomsStampDate") is { } csd ? new(csd) : CustomsStampDate;
        CustomsReferenceNumber = root.Element("CustomsReferenceNumber") is { } crn ? new(crn, _logger) : CustomsReferenceNumber;
        SupplierCustomsReference = root.Element("SupplierCustomsReference") is { } scr ? new(scr, _logger) : SupplierCustomsReference;
        MillParty = root.Element("MillParty") is { } mp ? new(mp) : MillParty;
        CustomsStampTrailerText = root.Element("CustomsStampTrailerText") is { } cstt ? new(cstt) : CustomsStampTrailerText;
        Value = root.Value;

        _logger?.LogInformation("New customs stamp information has been added.");
    }

    public override string ToString()
    {
        return new XElement("CustomsStampInformation",
            CustomsStampHeaderText.Select(obj => XElement.Parse($"{obj}")),
            CustomsParty != null ? XElement.Parse($"{CustomsParty}") : null,
            CustomsStampDate != null ? XElement.Parse($"{CustomsStampDate}") : null,
            CustomsReferenceNumber != null ? XElement.Parse($"{CustomsReferenceNumber}") : null,
            SupplierCustomsReference != null ? XElement.Parse($"{SupplierCustomsReference}") : null,
            MillParty != null ? XElement.Parse($"{MillParty}") : null,
            CustomsStampTrailerText != null ? XElement.Parse($"{CustomsStampTrailerText}") : null,
            Value
        ).ToString();
    }
}

public class CustomsStampTrailerText
{
    public string Value = string.Empty;  

    public CustomsStampTrailerText() { }

    public CustomsStampTrailerText(XElement root) { Value = root.Value; }

    public override string ToString() => new XElement("CustomsStampTrailerText", Value).ToString();
}

public class MillParty : Party
{
    public MillParty(ILogger<DeliveryMessageWood>? logger = null) : base(logger) { }

    public MillParty(XElement root, ILogger<DeliveryMessageWood>? logger = null) : base(root, logger) { }

    public override string LocalName => "MillParty";
}

public class SupplierCustomsReference
{
    private readonly ILogger<DeliveryMessageWood>? _logger;
    public ReferenceType SupplierCustomsReferenceType = ReferenceType.Other;
    public AssignedBy AssignedBy = AssignedBy.Other;
    public string Value = string.Empty;  
    

    public SupplierCustomsReference(ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;

        _logger?.LogInformation("New supplier customs reference has been added.");
    }

    public SupplierCustomsReference(XElement root, ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;
        SupplierCustomsReferenceType = root.Attribute("SupplierCustomsReferenceType")?.Value.ToEnum<ReferenceType>(_logger) ?? SupplierCustomsReferenceType;
        AssignedBy = root.Attribute("AssignedBy")?.Value.ToEnum<AssignedBy>(_logger) ?? AssignedBy;
        Value = root.Value;

        _logger?.LogInformation("New supplier customs reference has been added.");
    }

    public override string ToString()
    {
        return new XElement("SupplierCustomsReference",
            new XAttribute("SupplierCustomsReferenceType", SupplierCustomsReferenceType),
            new XAttribute("AssignedBy", AssignedBy),
            Value
        ).ToString();
    }
}

public class CustomsReferenceNumber
{
    private readonly ILogger<DeliveryMessageWood>? _logger;
    public CustomsReferenceNumberType CustomsReferenceNumberType;
    public string Value = string.Empty;  
    

    public CustomsReferenceNumber(ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;

        _logger?.LogInformation("New customs reference number has been added.");
    }

    public CustomsReferenceNumber(XElement root, ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;
        CustomsReferenceNumberType = root.Attribute("CustomsReferenceNumberType")?.Value.ToEnum<CustomsReferenceNumberType>(_logger) ?? CustomsReferenceNumberType;
        Value = root.Value;

        _logger?.LogInformation("New customs reference number has been added.");
    }

    public override string ToString()
    {
        return new XElement("CustomsReferenceNumber",
            new XAttribute("CustomsReferenceNumberType", CustomsReferenceNumberType),
            Value
        ).ToString();
    }
}

public class CustomsStampDate : DateTimeBase
{
    public CustomsStampDate() : base() { }

    public CustomsStampDate(XElement root) : base(root) { }

    public override string LocalName => "CustomsStampDate";
}

public class CustomsParty : Party
{
    public CustomsParty() : base() { }

    public CustomsParty(XElement root) : base(root) { }

    public override string LocalName => "CustomsParty";
}

public class CustomsStampHeaderText
{
    public string Value = string.Empty;

    public CustomsStampHeaderText() { }

    public CustomsStampHeaderText(XElement root) { Value = root.Value; }

    public override string ToString() => new XElement("CustomsStampHeaderText", Value).ToString();
}

public class CustomsTotals
{
    public CustomsTariffCode CustomsTariffCode { get; set; } = new();
    public TotalQuantity TotalQuantity { get; set; } = new();
    public List<InformationalQuantity> InformationalQuantity { get; } = [];
    public string Value = string.Empty; 
    

    public CustomsTotals() { }

    public CustomsTotals(XElement root)
    {
        CustomsTariffCode = root.Element("CustomsTariffCode") is { } ctc ? new(ctc) : CustomsTariffCode;
        TotalQuantity = root.Element("TotalQuantity") is { } tq ? new(tq) : TotalQuantity;
        InformationalQuantity = [.. root.Elements("InformationalQuantity").Select(e => new InformationalQuantity(e))];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("CustomsTotals",
            XElement.Parse($"{CustomsTariffCode}"),
            XElement.Parse($"{TotalQuantity}"),
            InformationalQuantity.Select(obj => XElement.Parse($"{obj}")),
            Value
        ).ToString();
    }
}

public class CustomsTariffCode
{
    public string Value = string.Empty; 

    public CustomsTariffCode() { }

    public CustomsTariffCode(XElement root) { Value = root.Value; }

    public override string ToString() => new XElement("CustomsTariffCode", Value).ToString();
}

public class TotalNumberOfShipments
{
    public string Value = string.Empty;

    public TotalNumberOfShipments() { }

    public TotalNumberOfShipments(XElement root) { Value = root.Value; }

    public override string ToString() => new XElement("TotalNumberOfShipments", Value).ToString();
}

public class DeliveryMessageDate
{
    public Date Date { get; set; } = new();

    public DeliveryMessageDate() { }

    public DeliveryMessageDate(Date date) { Date = date; }

    public DeliveryMessageDate(XElement root)
    {
        Date = root.Element("Date") is XElement date ? new Date(date) : Date;
    }

    public static DeliveryMessageDate Parse(DateTime dateTime)
    {
        DeliveryMessageDate dmd = new();
        dmd.Date.Year = $"{dateTime.Year}";
        dmd.Date.Month = $"{dateTime.Month}";
        dmd.Date.Day = $"{dateTime.Day}";
        return dmd;
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

    public DateTime ToDateTime()
    {
        int year = int.Parse(Year);
        int month = int.Parse(Month);
        int day = int.Parse(Day);
        return new DateTime(year, month, day);
    }
}

public class Time
{
    public string Value = string.Empty;

    public Time() { }

    public Time(string value) { Value = value; }

    public Time(XElement root) { Value = root.Value; }

    public override string ToString() => new XElement("Time", Value).ToString();
}

public class DeliveryMessageShipment
{
    private readonly ILogger<DeliveryMessageWood>? _logger;
    public ShipmentID? ShipmentID { get; set; } = null;
    public List<DeliveryMessageProductGroup> DeliveryMessageProductGroup { get; } = [];
    public ShipmentSummary? ShipmentSummary { get; set; } = null;
    public string Value = string.Empty;  
    

    public DeliveryMessageShipment(ILogger<DeliveryMessageWood>? logger = null) 
    { 
        _logger = logger;
    }

    public DeliveryMessageShipment(XElement root, ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;
        ShipmentID = root.Element("ShipmentID") is { } sid ? new(sid, _logger) : ShipmentID;
        DeliveryMessageProductGroup = [.. root.Elements("DeliveryMessageProductGroup").Select(e => new DeliveryMessageProductGroup(e, _logger))];
        ShipmentSummary = root.Element("ShipmentSummary") is { } ss ? new(ss) : ShipmentSummary;
        Value = root.Value;

        _logger?.LogInformation("New delivery message shipment has been added.");
    }

    public override string ToString()
    {
        return new XElement("DeliveryMessageShipment",
            ShipmentID != null ? XElement.Parse($"{ShipmentID}") : null,
            DeliveryMessageProductGroup.Select(obj => XElement.Parse($"{obj}")),
            ShipmentSummary != null ? XElement.Parse($"{ShipmentSummary}") : null
        ).ToString();
    }
}

public class ShipmentID
{
    private readonly ILogger<DeliveryMessageWood>? _logger;
    public ShipmentIDType ShipmentIDType { get; set; } = ShipmentIDType.Unset;
    public string Value = string.Empty;

    public ShipmentID(ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;

        _logger?.LogInformation("New shipment id has been added.");
    }

    public ShipmentID(XElement root, ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;
        ShipmentIDType = root.Attribute("ShipmentIDType")?.Value.ToEnum<ShipmentIDType>(_logger) ?? ShipmentIDType;
        Value = root.Value;

        _logger?.LogInformation("New shipment id has been added.");
    }

    public override string ToString()
    {
        return new XElement("ShipmentID",
            ShipmentIDType != ShipmentIDType.Unset ? new XAttribute("ShipmentIDType", ShipmentIDType) : null,
            Value
        ).ToString();
    }
}

public class ShipmentSummary
{
    public TotalQuantity? TotalQuantity { get; set; } = null;
    public List<TotalInformationalQuantity> TotalInformationalQuantity { get; } = [];
    public ProductSummary? ProductSummary { get; set; } = null;
    public List<LengthSpecification> LengthSpecification { get; } = [];
    public string Value = string.Empty;  

    public ShipmentSummary() { }

    public ShipmentSummary(XElement root)
    {
        TotalQuantity = root.Element("TotalQuantity") is { } tq ? new(tq) : TotalQuantity;
        TotalInformationalQuantity = [.. root.Elements("TotalInformationalQuantity").Select(e => new TotalInformationalQuantity(e))];
        ProductSummary = root.Element("ProductSummary") is { } ps ? new(ps) : ProductSummary;
        LengthSpecification = [.. root.Elements("LengthSpecification").Select(e => new LengthSpecification(e))];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("ShipmentSummary",
            TotalQuantity != null ? XElement.Parse($"{TotalQuantity}") : null,
            TotalInformationalQuantity.Select(obj => XElement.Parse($"{obj}")),
            ProductSummary != null ? XElement.Parse($"{ProductSummary}") : null,
            LengthSpecification.Select(obj => XElement.Parse($"{obj}"))
        ).ToString();
    }
}

public class DeliveryMessageProductGroup
{
    private readonly ILogger<DeliveryMessageWood>? _logger;
    public ProductGroupID? ProductGroupID { get; set; } = null;
    public List<DeliveryShipmentLineItem> DeliveryShipmentLineItem { get; } = [];
    public ProductGroupSummary? ProductGroupSummary { get; set; } = null;
    public string Value = string.Empty;  

    public DeliveryMessageProductGroup(ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;

        _logger?.LogInformation("New delivery message product group has been added.");
    }

    public DeliveryMessageProductGroup(XElement root, ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;
        ProductGroupID = root.Element("ProductGroupID") is { } pgid ? new(pgid, _logger) : ProductGroupID;
        DeliveryShipmentLineItem = [.. root.Elements("DeliveryShipmentLineItem").Select(e => new DeliveryShipmentLineItem(e, _logger))];
        ProductGroupSummary = root.Element("ProductGroupSummary") is { } pgs ? new(pgs) : ProductGroupSummary;
        Value = root.Value;

        _logger?.LogInformation("New delivery message product group has been added.");
    }

    public override string ToString()
    {
        return new XElement("DeliveryMessageProductGroup",
            ProductGroupID != null ? XElement.Parse($"{ProductGroupID}") : null,
            DeliveryShipmentLineItem.Select(obj => XElement.Parse($"{obj}")),
            ProductGroupSummary != null ? XElement.Parse($"{ProductGroupSummary}") : null
        ).ToString();
    }
}

public class ProductGroupID
{
    private readonly ILogger<DeliveryMessageWood>? _logger;
    public ProductGroupIDType ProductGroupIDType { get; set; } = ProductGroupIDType.Unset;
    public string Value = string.Empty;  

    public ProductGroupID(ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;

        _logger?.LogInformation("New product group id has been added.");
    }

    public ProductGroupID(XElement root, ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;
        ProductGroupIDType = root.Attribute("ProductGroupIDType")?.Value.ToEnum<ProductGroupIDType>(_logger) ?? ProductGroupIDType;
        Value = root.Value;

        _logger?.LogInformation("New product group id has been added.");
    }

    public override string ToString()
    {
        return new XElement("ProductGroupID",
            ProductGroupIDType !=  ProductGroupIDType.Unset ? new XAttribute("ProductGroupIDType", ProductGroupIDType) : null,
            Value
        ).ToString();
    }
}

public class ProductGroupSummary
{
    public TotalQuantity? TotalQuantity { get; set; } = null;
    public List<TotalInformationalQuantity> TotalInformationalQuantity { get; } = [];
    public ProductSummary? ProductSummary { get; set; } = null;
    public List<LengthSpecification> LengthSpecification { get; } = [];
    public string Value = string.Empty;  

    public ProductGroupSummary() { }

    public ProductGroupSummary(XElement root)
    {
        TotalQuantity = root.Element("TotalQuantity") is { } tq ? new(tq) : TotalQuantity;
        TotalInformationalQuantity = [.. root.Elements("TotalInformationalQuantity").Select(e => new TotalInformationalQuantity(e))];
        ProductSummary = root.Element("ProductSummary") is { } ps ? new(ps) : ProductSummary;
        LengthSpecification = [.. root.Elements("LengthSpecification").Select(e => new LengthSpecification(e))];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("ProductGroupSummary",
            TotalQuantity != null ? XElement.Parse($"{TotalQuantity}") : null,
            TotalInformationalQuantity.Select(obj => XElement.Parse($"{obj}")),
            ProductSummary != null ? XElement.Parse($"{ProductSummary}") : null,
            LengthSpecification.Select(obj => XElement.Parse($"{obj}"))
        ).ToString();
    }
}

public class DeliveryShipmentLineItem
{
    private readonly ILogger<DeliveryMessageWood>? _logger;
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
    
    public string Value = string.Empty;  

    public DeliveryShipmentLineItem(ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;

        _logger?.LogInformation("New delivery shipment line item has been added.");
    }

    public DeliveryShipmentLineItem(XElement root, ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;
        DeliveryShipmentLineItemNumber = root.Element("DeliveryShipmentLineItemNumber") is { } dslin ? new(dslin) : DeliveryShipmentLineItemNumber;
        PurchaseOrderInformation = root.Element("PurchaseOrderInformation") is { } poi ? new(poi) : PurchaseOrderInformation;
        PurchaseOrderLineItemNumber = root.Element("PurchaseOrderLineItemNumber") is { } polin ? new(polin) : PurchaseOrderLineItemNumber;
        DeliveryMessageReference = [.. root.Elements("DeliveryMessageReference").Select(e => new DeliveryMessageReference(e))];
        DocumentReferenceInformation = [.. root.Elements("DocumentReferenceInformation").Select(e => new DocumentReferenceInformation(e))];
        CountryOfOrigin = root.Element("CountryOfOrigin") is { } coo ? new(coo) : CountryOfOrigin;
        CountryOfDestination = root.Element("CountryOfDestination") is { } cod ? new(cod) : CountryOfDestination;
        CountryOfConsumption = root.Element("CountryOfConsumption") is { } coc ? new(coc) : CountryOfConsumption;
        TotalNumberOfUnits = root.Element("TotalNumberOfUnits") is { } tnou ? new(tnou) : TotalNumberOfUnits;
        DeliveryDateWindow = [.. root.Elements("DeliveryDateWindow").Select(e => new DeliveryDateWindow(e))];
        MillProductionInformation = root.Element("MillProductionInformation") is { } mpi ? new(mpi) : MillProductionInformation;
        QuantityOrderedInformation = root.Element("QuantityOrderedInformation") is { } qoi ? new(qoi) : QuantityOrderedInformation;
        TransportLoadingCharacteristics = [.. root.Elements("TransportLoadingCharacteristics").Select(e => new TransportLoadingCharacteristics(e))];
        TransportUnloadingCharacteristics = root.Element("TransportUnloadingCharacteristics") is { } tuc ? new(tuc) : TransportUnloadingCharacteristics;
        TransportOtherInstructions = [.. root.Elements("TransportOtherInstructions").Select(e => new TransportOtherInstructions(e))];
        SafetyAndEnvironmentalInformation = [.. root.Elements("SafetyAndEnvironmentalInformation").Select(e => new SafetyAndEnvironmentalInformation(e))];
        BillToParty = root.Element("BillToParty") is { } btp ? new(btp) : BillToParty;
        Product = root.Element("Product") is { } p ? new(p) : Product;
        PackageInformation = root.Element("PackageInformation") is { } pi ? new(pi, _logger) : PackageInformation;
        TransportPackageInformation = [.. root.Elements("TransportPackageInformation").Select(e => new TransportPackageInformation(e))];
        ProductSummary = root.Element("ProductSummary") is { } ps ? new(ps) : ProductSummary;
        LengthSpecification = [.. root.Elements("LengthSpecification").Select(e => new LengthSpecification(e))];
        QuantityDeviation = root.Element("QuantityDeviation") is { } qd ? new(qd) : QuantityDeviation;
        Value = root.Value;

        _logger?.LogInformation("New delivery shipment line item has been added.");
    }

    public override string ToString()
    {
        return new XElement("DeliveryShipmentLineItem",
            XElement.Parse($"{DeliveryShipmentLineItemNumber}"),
            XElement.Parse($"{PurchaseOrderInformation}"),
            PurchaseOrderLineItemNumber != null ? XElement.Parse($"{PurchaseOrderLineItemNumber}") : null,
            DeliveryMessageReference.Select(obj => XElement.Parse($"{obj}")),
            DocumentReferenceInformation.Select(obj => XElement.Parse($"{obj}")),
            CountryOfOrigin != null ? XElement.Parse($"{CountryOfOrigin}") : null,
            CountryOfDestination != null ? XElement.Parse($"{CountryOfDestination}") : null,
            CountryOfConsumption != null ? XElement.Parse($"{CountryOfConsumption}") : null,
            TotalNumberOfUnits != null ? XElement.Parse($"{TotalNumberOfUnits}") : null,
            DeliveryDateWindow.Select(obj => XElement.Parse($"{obj}")),
            MillProductionInformation != null ? XElement.Parse($"{TotalNumberOfUnits}") : null,
            QuantityOrderedInformation != null ? XElement.Parse($"{TotalNumberOfUnits}") : null,
            TransportLoadingCharacteristics.Select(obj => XElement.Parse($"{obj}")),
            TransportUnloadingCharacteristics != null ? XElement.Parse($"{TotalNumberOfUnits}") : null,
            TransportOtherInstructions.Select(obj => XElement.Parse($"{obj}")),
            SafetyAndEnvironmentalInformation.Select(obj => XElement.Parse($"{obj}")),
            BillToParty != null ? XElement.Parse($"{BillToParty}") : null,
            Product != null ? XElement.Parse($"{Product}") : null,
            PackageInformation != null ? XElement.Parse($"{PackageInformation}") : null,
            TransportPackageInformation.Select(obj => XElement.Parse($"{obj}")),
            ProductSummary != null ? XElement.Parse($"{ProductSummary}") : null,
            LengthSpecification.Select(obj => XElement.Parse($"{obj}")),
            QuantityDeviation != null ? XElement.Parse($"{QuantityDeviation}") : null
        ).ToString();
    }
}

public class PurchaseOrderLineItemNumber
{
    public string Value = string.Empty;  

    public PurchaseOrderLineItemNumber() { }

    public PurchaseOrderLineItemNumber(XElement root) { Value = root.Value; }

    public override string ToString() => new XElement("PurchaseOrderLineItemNumber", Value).ToString();
}

public class DeliveryShipmentLineItemNumber
{
    public string Value = string.Empty;  

    public DeliveryShipmentLineItemNumber() { }

    public DeliveryShipmentLineItemNumber(XElement root) { Value = root.Value; }

    public override string ToString() => new XElement("DeliveryShipmentLineItemNumber", Value).ToString();
}

public class QuantityDeviation : MeasurementBase
{
    public QuantityDeviation() : base() { }

    public QuantityDeviation(XElement root) : base(root) { }

    public override string LocalName => "QuantityDeviation";
}

public class TransportPackageInformation
{
    private readonly ILogger<DeliveryMessageWood>? _logger;
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
    public string Value = string.Empty;  

    public TransportPackageInformation(ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;

        _logger?.LogInformation("New transport package information has been added.");
    }

    public TransportPackageInformation(XElement root, ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;
        PackageType = root.Attribute("PackageType")?.Value.ToEnum<PackageType>(_logger) ?? PackageType;
        MixedProductPalletIndicator = root.Attribute("MixedProductPalletIndicator")?.Value.ToEnum<YesNo>(_logger) ?? MixedProductPalletIndicator;
        PackageLevel = root.Attribute("PackageLevel") is { } pl ? new(pl) : PackageLevel;
        Identifier = root.Element("Identifier") is { } i ? new(i) : Identifier;
        RawMaterialSet = [.. root.Elements("RawMaterialSet").Select(e => new RawMaterialSet(e))];
        PartyIdentifier = [.. root.Elements("PartyIdentifier").Select(e => new PartyIdentifier(e))];
        MachineID = root.Element("MachineID") is { } mid ? new(mid) : MachineID;
        ItemCount = root.Element("ItemCount") is { } ico ? new(ico) : ItemCount;
        Quantity = root.Element("Quantity") is { } q ? new(q) : Quantity;
        InformationalQuantity = [.. root.Elements("InformationalQuantity").Select(e => new InformationalQuantity(e))];
        InventoryClass = root.Element("InventoryClass") is { } icl ? new(icl) : InventoryClass;
        TransportVehicleCharacteristics = root.Element("TransportVehicleCharacteristics") is { } tvc ? new(tvc) : TransportVehicleCharacteristics;
        TransportUnitCharacteristics = root.Element("TransportUnitCharacteristics") is { } tuc ? new(tuc) : TransportUnitCharacteristics;
        PackageCharacteristics = root.Element("PackageCharacteristics") is { } pc ? new(pc) : PackageCharacteristics;
        BaleItem = root.Element("BaleItem") is { } bai ? new(bai) : BaleItem;
        BoxItem = root.Element("BoxItem") is { } boi ? new(boi) : BoxItem;
        ReelItem = root.Element("ReelItem") is { } reei ? new(reei) : ReelItem;
        ReamItem = root.Element("ReamItem") is { } reai ? new(reai) : ReamItem;
        SheetItem = root.Element("SheetItem") is { } si ? new(si) : SheetItem;
        UnitItem = root.Element("UnitItem") is { } ui ? new(ui) : UnitItem;
        WoodItem = root.Element("WoodItem") is { } wi ? new(wi, _logger) : WoodItem;
        OtherDate = [.. root.Elements("OtherDate").Select(e => new OtherDate(e, _logger))];
        Value = root.Value;

        _logger?.LogInformation("New transport package information has been added.");
    }

    public override string ToString()
    {
        return new XElement("TransportPackageInformation",
            PackageType != PackageType.Unset ? new XAttribute("PackageType", PackageType.GetMemberValue()) : null,
            MixedProductPalletIndicator != YesNo.Unset ? new XAttribute("MixedProductPalletIndicator", MixedProductPalletIndicator.GetMemberValue()) : null,
            PackageLevel != null ? new XAttribute("PackageLevel", $"{PackageLevel}") : null,
            Identifier != null ? XElement.Parse($"{Identifier}") : null,
            RawMaterialSet.Select(obj => XElement.Parse($"{obj}")),
            PartyIdentifier.Select(obj => XElement.Parse($"{obj}")),
            MachineID != null ? XElement.Parse($"{MachineID}") : null,
            ItemCount != null ? XElement.Parse($"{ItemCount}") : null,
            Quantity != null ? XElement.Parse($"{Quantity}") : null,
            InformationalQuantity.Select(obj => XElement.Parse($"{obj}")),
            InventoryClass != null ? XElement.Parse($"{InventoryClass}") : null,
            TransportVehicleCharacteristics != null ? XElement.Parse($"{TransportVehicleCharacteristics}") : null,
            TransportUnitCharacteristics != null ? XElement.Parse($"{TransportUnitCharacteristics}") : null,
            PackageCharacteristics != null ? XElement.Parse($"{PackageCharacteristics}") : null,
            BaleItem != null ? XElement.Parse($"{BaleItem}") : null,
            BoxItem != null ? XElement.Parse($"{BoxItem}") : null,
            ReelItem != null ? XElement.Parse($"{ReelItem}") : null,
            ReamItem != null ? XElement.Parse($"{ReamItem}") : null,
            SheetItem != null ? XElement.Parse($"{SheetItem}") : null,
            UnitItem != null ? XElement.Parse($"{UnitItem}") : null,
            WoodItem != null ? XElement.Parse($"{WoodItem}") : null,
            OtherDate.Select(obj => XElement.Parse($"{obj}"))
        ).ToString();
    }
}

public class PackageInformation
{
    private readonly ILogger<DeliveryMessageWood>? _logger;
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
    public string Value = string.Empty;  

    public PackageInformation(ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;

        _logger?.LogInformation("New package information has been added.");
    }

    public PackageInformation(XElement root, ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;
        PackageType = root.Attribute("PackageType")?.Value.ToEnum<PackageType>(_logger) ?? PackageType;
        MixedProductPalletIndicator = root.Attribute("MixedProductPalletIndicator")?.Value.ToEnum<YesNo>(_logger) ?? MixedProductPalletIndicator;
        PackageLevel = root.Attribute("PackageLevel") is { } pl ? new(pl) : PackageLevel;
        Identifier = root.Element("Identifier") is { } i ? new(i) : Identifier;
        SupplierMarks = [.. root.Elements("SupplierMarks").Select(e => new SupplierMarks(e))];
        RawMaterialSet = [.. root.Elements("RawMaterialSet").Select(e => new RawMaterialSet(e))];
        PartyIdentifier = [.. root.Elements("PartyIdentifier").Select(e => new PartyIdentifier(e))];
        MachineID = root.Element("MachineID") is { } mid ? new(mid) : MachineID;
        ItemCount = root.Element("ItemCount") is { } ico ? new(ico) : ItemCount;
        Quantity = root.Element("Quantity") is { } q ? new(q) : Quantity;
        InformationalQuantity = [.. root.Elements("InformationalQuantity").Select(e => new InformationalQuantity(e))];
        InventoryClass = root.Element("InventoryClass") is { } icl ? new(icl) : InventoryClass;
        PackageCharacteristics = root.Element("PackageCharacteristics") is { } pc ? new(pc) : PackageCharacteristics;
        BaleItem = root.Element("BaleItem") is { } bai ? new(bai) : BaleItem;
        BoxItem = root.Element("BoxItem") is { } boi ? new(boi) : BoxItem;
        ReelItem = root.Element("ReelItem") is { } reei ? new(reei) : ReelItem;
        ReamItem = root.Element("ReamItem") is { } reai ? new(reai) : ReamItem;
        SheetItem = root.Element("SheetItem") is { } si ? new(si) : SheetItem;
        UnitItem = root.Element("UnitItem") is { } ui ? new(ui) : UnitItem;
        WoodItem = root.Element("WoodItem") is { } wi ? new(wi, _logger) : WoodItem;
        OtherDate = [.. root.Elements("OtherDate").Select(e => new OtherDate(e, _logger))];
        e_Attachment = root.Element("e-Attachment") is { } ea ? new(ea) : e_Attachment;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => new AdditionalText(e))];
        PackageReference = root.Element("PackageReference") is { } pr ? new(pr, _logger) : PackageReference;
        Value = root.Value;

        _logger?.LogInformation("New package information has been added.");
    }

    public override string ToString()
    {
        return new XElement("PackageInformation",
            PackageType != PackageType.Unset ? new XAttribute("PackageType", PackageType.GetMemberValue()) : null,
            MixedProductPalletIndicator != YesNo.Unset ? new XAttribute("MixedProductPalletIndicator", MixedProductPalletIndicator.GetMemberValue()) : null,
            PackageLevel != null ? new XAttribute("PackageLevel", $"{PackageLevel}") : null,
            SupplierMarks.Select(obj => XElement.Parse($"{obj}")),
            RawMaterialSet.Select(obj => XElement.Parse($"{obj}")),
            PartyIdentifier.Select(obj => XElement.Parse($"{obj}")),
            MachineID != null ? XElement.Parse($"{MachineID}") : null,
            ItemCount != null ? XElement.Parse($"{ItemCount}") : null,
            Quantity != null ? XElement.Parse($"{Quantity}") : null,
            InformationalQuantity.Select(obj => XElement.Parse($"{obj}")),
            InventoryClass != null ? XElement.Parse($"{InventoryClass}") : null,
            PackageCharacteristics != null ? XElement.Parse($"{PackageCharacteristics}") : null,
            BaleItem != null ? XElement.Parse($"{BaleItem}") : null,
            BoxItem != null ? XElement.Parse($"{BoxItem}") : null,
            ReelItem != null ? XElement.Parse($"{ReelItem}") : null,
            ReamItem != null ? XElement.Parse($"{ReamItem}") : null,
            SheetItem != null ? XElement.Parse($"{SheetItem}") : null,
            UnitItem != null ? XElement.Parse($"{UnitItem}") : null,
            WoodItem != null ? XElement.Parse($"{WoodItem}") : null,
            OtherDate.Select(obj => XElement.Parse($"{obj}")),
            e_Attachment != null ? XElement.Parse($"{e_Attachment}") : null,
            AdditionalText.Select(obj => XElement.Parse($"{obj}")),
            PackageReference != null ? XElement.Parse($"{PackageReference}") : null,
            Value
        ).ToString();
    }
}

public class PackageLevel
{
    public string Value = string.Empty;  

    public PackageLevel() { }

    public PackageLevel(XAttribute root) { Value = root.Value; }

    public override string ToString() => Value;
}

public class PackageReference
{
    private readonly ILogger<DeliveryMessageWood>? _logger;
    public ReferenceType PackageReferenceType = ReferenceType.Other;
    public AssignedBy AssignedBy = AssignedBy.Other;
    public string Value = string.Empty;  

    public PackageReference(ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;

        _logger?.LogInformation("New package reference has been added.");
    }

    public PackageReference(XElement root, ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;
        PackageReferenceType = root.Attribute("PackageReferenceType")?.Value.ToEnum<ReferenceType>(_logger) ?? PackageReferenceType;
        AssignedBy = root.Attribute("AssignedBy")?.Value.ToEnum<AssignedBy>(_logger) ?? AssignedBy;
        Value = root.Value;

        _logger?.LogInformation("New package reference has been added.");
    }

    public override string ToString()
    {
        return new XElement("PackageReference",
            new XAttribute("PackageReferenceType", PackageReferenceType),
            new XAttribute("AssignedBy", AssignedBy),
            Value
        ).ToString();
    }
}

public class AdditionalText
{
    public string Value = string.Empty;  

    public AdditionalText() { }

    public AdditionalText(XElement root) { Value = root.Value; }

    public override string ToString() => new XElement("AdditionalText", Value).ToString();
}

public class OtherDate
{
    private readonly ILogger<DeliveryMessageWood>? _logger;
    public DateType DateType = DateType.Other;
    public Date Date { get; set; } = new();
    public Time? Time { get; set; } = null;
    public Week? Week { get; set; } = null;
    public DateTimeRange? DateTimeRange { get; set; } = null;
    public string Value = string.Empty;  

    public OtherDate() { }

    public OtherDate(XElement root, ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;
        DateType = root.Attribute("DateType")?.Value.ToEnum<DateType>(_logger) ?? DateType;
        Date = root.Element("Date") is { } d ? new(d) : Date;
        Time = root.Element("Time") is { } t ? new(t) : Time;
        Week = root.Element("Week") is { } w ? new(w) : Week;
        DateTimeRange = root.Element("DateTimeRange") is { } dtr ? new(dtr) : DateTimeRange;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("OtherDate",
            new XAttribute("DateType", DateType.GetMemberValue()),
            XElement.Parse($"{Date}"),
            Time != null ? XElement.Parse($"{Date}") : null,
            Week != null ? XElement.Parse($"{Week}") : null,
            DateTimeRange != null ? XElement.Parse($"{DateTimeRange}") : null,
            Value
        ).ToString();
    }
}

public class Week
{
    public string Value = string.Empty;  

    public Week() { }

    public Week(XElement root) { Value = root.Value; }

    public override string ToString() => new XElement("Week", Value).ToString();
}

public class WoodItem
{
    private readonly ILogger<DeliveryMessageWood>? _logger;
    public Product? Product { get; set; } = null;
    public PackagingInformation? PackagingInformation { get; set; } = null;
    public ProductSummary? ProductSummary { get; set; } = null;
    public List<LengthSpecification> LengthSpecification { get; } = [];
    public string Value = string.Empty;  

    public WoodItem(ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;

        _logger?.LogInformation("New wood item has been added.");
    }

    public WoodItem(XElement root, ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;
        Product = root.Element("Product") is { } p ? new(p) : Product;
        PackagingInformation = root.Element("PackagingInformation") is { } pi ? new(pi, _logger) : PackagingInformation;
        ProductSummary = root.Element("ProductSummary") is { } ps ? new(ps) : ProductSummary;
        LengthSpecification = [.. root.Elements("LengthSpecification").Select(e => new LengthSpecification(e))];
        Value = root.Value;

        _logger?.LogInformation("New wood item has been added.");
    }

    public override string ToString()
    {
        return new XElement("WoodItem",
            Product != null ? XElement.Parse($"{Product}") : null,
            PackagingInformation != null ? XElement.Parse($"{PackagingInformation}") : null,
            ProductSummary != null ? XElement.Parse($"{ProductSummary}") : null,
            LengthSpecification.Select(obj => XElement.Parse($"{obj}"))
        ).ToString();
    }
}

public class LengthSpecification
{
    public LengthCategory? LengthCategory { get; set; } = null;
    public TotalNumberOfUnits? TotalNumberOfUnits { get; set; } = null;
    public string Value = string.Empty;  

    public LengthSpecification() { }

    public LengthSpecification(XElement root)
    {
        LengthCategory = root.Element("LengthCategory") is { } lc ? new(lc) : LengthCategory;
        TotalNumberOfUnits = root.Element("TotalNumberOfUnits") is { } tnou ? new(tnou) : TotalNumberOfUnits;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("LengthSpecification",
            LengthCategory != null ? XElement.Parse($"{LengthCategory}") : null,
            TotalNumberOfUnits != null ? XElement.Parse($"{TotalNumberOfUnits}") : null
        ).ToString();
    }
}

public class LengthCategory : ValueBase
{
    public LengthCategory() : base() { }

    public LengthCategory(XElement root) : base(root) { }

    public override string LocalName => "LengthCategory";
}

public class ProductSummary
{
    public TotalQuantity? TotalQuantity { get; set; } = null;
    public List<TotalInformationalQuantity> TotalInformationalQuantity { get; } = [];
    public string Value = string.Empty;  

    public ProductSummary() { }

    public ProductSummary(XElement root)
    {
        TotalQuantity = root.Element("TotalQuantity") is { } tq ? new(tq) : TotalQuantity;
        TotalInformationalQuantity = [.. root.Elements("TotalInformationalQuantity").Select(e => new TotalInformationalQuantity(e))];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("ProductSummary",
            TotalQuantity != null ? XElement.Parse($"{TotalQuantity}") : null,
            TotalInformationalQuantity.Select(obj => XElement.Parse($"{obj}"))
        ).ToString();
    }
}

public class TotalInformationalQuantity : MeasurementBase
{
    public TotalInformationalQuantity() : base() { }

    public TotalInformationalQuantity(XElement root) : base(root) { }

    public override string LocalName => "TotalInformationalQuantity";
}

public class TotalQuantity : MeasurementBase
{
    public TotalQuantity() : base() { }

    public TotalQuantity(XElement root) : base(root) { }

    public override string LocalName => "TotalQuantity";
}

public class PackagingInformation
{
    private readonly ILogger<DeliveryMessageWood>? _logger;
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
    public string Value = string.Empty;  

    public PackagingInformation(ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;

        _logger?.LogInformation("New packaging information has been added.");
    }

    public PackagingInformation(XElement root, ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;
        QuantityInUnit = root.Element("QuantityInUnit") is { } qiu ? new(qiu) : QuantityInUnit;
        UnitDimension = root.Element("UnitDimension") is { } ud ? new(ud) : UnitDimension;
        Weight = root.Element("Weight") is { } w ? new(w) : Weight;
        PackageIDInformation = root.Element("PackageIDInformation") is { } pidi ? new(pidi) : PackageIDInformation;
        LabelCharacteristics = [.. root.Elements("LabelCharacteristics").Select(e => new LabelCharacteristics(e))];
        StencilCharacteristics = [.. root.Elements("StencilCharacteristics").Select(e => new StencilCharacteristics(e))];
        BandCharacteristics = [.. root.Elements("BandCharacteristics").Select(e => new BandCharacteristics(e))];
        PalletCharacteristics = [.. root.Elements("PalletCharacteristics").Select(e => new PalletCharacteristics(e))];
        Wrap = [.. root.Elements("Wrap").Select(e => new Wrap(e))];
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        PackageType = root.Element("PackageType")?.Value.ToEnum<PackageType>(_logger) ?? PackageType;
        Value = root.Value;

        _logger?.LogInformation("New packaging information has been added.");
    }

    public override string ToString()
    {
        return new XElement("PackagingInformation",
            QuantityInUnit != null ? new XElement("QuantityInUnit", QuantityInUnit) : null,
            UnitDimension != null ? new XElement("UnitDimension", UnitDimension) : null,
            Weight != null ? new XElement("Weight", Weight) : null,
            PackageIDInformation != null ? new XElement("PackageIDInformation", PackageIDInformation) : null,
            LabelCharacteristics.Select(obj => XElement.Parse($"{obj}")),
            StencilCharacteristics.Select(obj => XElement.Parse($"{obj}")),
            BandCharacteristics.Select(obj => XElement.Parse($"{obj}")),
            PalletCharacteristics.Select(obj => XElement.Parse($"{obj}")),
            Wrap.Select(obj => XElement.Parse($"{obj}")),
            AdditionalText.Select(obj => new XElement("AdditionalText", obj)),
            PackageType != PackageType.Unset ? new XElement("PackageType", PackageType) : null,
            Value
        ).ToString();
    }
}

public class UnitItem
{
    public UnitItem() { throw new NotImplementedException(); }

    public UnitItem(XElement root) { throw new NotImplementedException(); }
}

public class SheetItem
{
    public SheetItem() { throw new NotImplementedException(); }

    public SheetItem(XElement root) { throw new NotImplementedException(); }
}

public class ReamItem
{
    public ReamItem() { throw new NotImplementedException(); }

    public ReamItem(XElement root) { throw new NotImplementedException(); }
}

public class ReelItem
{
    public ReelItem() { throw new NotImplementedException(); }

    public ReelItem(XElement root) { throw new NotImplementedException(); }
}

public class BoxItem
{
    public BoxItem() { throw new NotImplementedException(); }

    public BoxItem(XElement root) { throw new NotImplementedException(); }
}

public class BaleItem
{
    public BaleItem() { throw new NotImplementedException(); }

    public BaleItem(XElement root) { throw new NotImplementedException(); }
}

public class PackageCharacteristics
{
    public Height? Height { get; set; } = null;
    public Width? Width { get; set; } = null;
    public Length? Length { get; set; } = null;
    public LengthCutDescription? LengthCutDescription { get; set; } = null;
    public string Value = string.Empty;  

    public PackageCharacteristics() { }

    public PackageCharacteristics(XElement root)
    {
        Height = root.Element("Height") is { } h ? new(h) : Height;
        Width = root.Element("Width") is { } w ? new(w) : Width;
        Length = root.Element("Length") is { } l ? new(l) : Length;
        LengthCutDescription = root.Element("LengthCutDescription") is { } lcd ? new(lcd) : LengthCutDescription;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("PackageCharacteristics",
            Height != null ? XElement.Parse($"{Height}") : null,
            Width != null ? XElement.Parse($"{Width}") : null,
            Length != null ? XElement.Parse($"{Length}") : null,
            LengthCutDescription != null ? XElement.Parse($"{LengthCutDescription}") : null,
            Value
        ).ToString();
    }
}

public class InventoryClass
{
    public InventoryStatusType InventoryStatusType { get; set; } = InventoryStatusType.Unset;
    public OwnedBy InventoryOwnedBy { get; set; } = OwnedBy.Unset;
    public InventoryClassCode InventoryClassCode { get; set; } = new();
    public List<InventoryClassDescription> InventoryClassDescription { get; } = [];
    public List<string> AdditionalText { get; } = [];
    public string Value = string.Empty;  

    public InventoryClass() { }

    public InventoryClass(XElement root)
    {
        InventoryStatusType = root.Attribute("InventoryStatusType")?.Value.ToEnum<InventoryStatusType>() ?? InventoryStatusType;
        InventoryOwnedBy = root.Attribute("InventoryOwnedBy")?.Value.ToEnum<OwnedBy>() ?? InventoryOwnedBy;
        InventoryClassCode = root.Element("InventoryClassCode") is { } icc ? new(icc) : InventoryClassCode;
        InventoryClassDescription = [.. root.Elements("InventoryClassDescription").Select(e => new InventoryClassDescription(e))];
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("InventoryClass",
            InventoryStatusType != InventoryStatusType.Unset ? new XAttribute("InventoryStatusType", InventoryStatusType.GetMemberValue()) : null,
            InventoryOwnedBy != OwnedBy.Unset ? new XAttribute("InventoryOwnedBy", InventoryOwnedBy.GetMemberValue()) : null,
            XElement.Parse($"{InventoryClassCode}"),
            InventoryClassDescription.Select(icd => XElement.Parse($"{icd}")),
            AdditionalText.Select(at => new XElement("AdditionalText", at)),
            Value
        ).ToString();
    }
}

public class InventoryClassDescription
{
    public string Value = string.Empty;  

    public InventoryClassDescription() { }

    public InventoryClassDescription(XElement root) { Value = root.Value; }

    public override string ToString() => new XElement("InventoryClassDescription", Value).ToString();
}

public class InventoryClassCode
{
    public Agency Agency = Agency.Other;
    public string InventoryClassLevel = "1";
    public string Value = string.Empty;  

    public InventoryClassCode() { }

    public InventoryClassCode(XElement root)
    {
        Agency = root.Attribute("Agency")?.Value.ToEnum<Agency>() ?? Agency;
        InventoryClassLevel = root.Attribute("InventoryClassLevel")?.Value ?? InventoryClassLevel;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("InventoryClassCode",
            new XAttribute("Agency", Agency.GetMemberValue()),
            new XAttribute("InventoryClassLevel", InventoryClassLevel),
            Value
        ).ToString();
    }
}

public class ItemCount : MeasurementBase
{
    public ItemCount() : base() { }

    public ItemCount(XElement root) : base(root) { }

    public override string LocalName => "ItemCount";
}

public class MachineID
{
    public string Value = string.Empty;  

    public MachineID() { }

    public MachineID(XElement root) { Value = root.Value; }

    public override string ToString() => new XElement("MachineID", Value).ToString();
}

public class RawMaterialSet
{
    public IdentifierCodeType IdentifierCodeType { get; set; }
    public IdentifierType IdentifierType { get; set; }
    public IdentifierFormatType IdentifierFormatType { get; set; } = IdentifierFormatType.Unset;
    public string Value = string.Empty;  

    public RawMaterialSet() { }

    public RawMaterialSet(XElement root)
    {
        IdentifierCodeType = root.Attribute("IdentifierCodeType") is { Value: var ict } ? ict.ToEnum<IdentifierCodeType>() : IdentifierCodeType;
        IdentifierType = root.Attribute("IdentifierType") is { Value: var it } ? it.ToEnum<IdentifierType>() : IdentifierType;
        IdentifierFormatType = root.Attribute("IdentifierFormatType") is { Value: var ift } ? ift.ToEnum<IdentifierFormatType>() : IdentifierFormatType;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("RawMaterialSet",
            new XAttribute("IdentifierCodeType", IdentifierCodeType),
            new XAttribute("IdentifierType", IdentifierType),
            IdentifierFormatType != IdentifierFormatType.Unset ? new XAttribute("IdentifierFormatType", IdentifierFormatType) : IdentifierFormatType,
            Value
        ).ToString();
    }
}

public class SupplierMarks
{
    public string Value = string.Empty;  

    public SupplierMarks() { }

    public SupplierMarks(XElement root)
    {
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("SupplierMarks",
            Value
        ).ToString();
    }
}

public class Identifier
{
    public IdentifierCodeType IdentifierCodeType { get; set; } = IdentifierCodeType.Supplier;
    public IdentifierType IdentifierType { get; set; } = IdentifierType.Primary;
    public IdentifierFormatType IdentifierFormatType { get; set; } = IdentifierFormatType.Unset;
    public string Value { get; set; } = string.Empty;  

    public Identifier() { }

    public Identifier(XElement root)
    {
        IdentifierCodeType = root.Attribute("IdentifierCodeType") is { Value: var ict } ? ict.ToEnum<IdentifierCodeType>() : IdentifierCodeType;
        IdentifierType = root.Attribute("IdentifierType") is { Value: var it } ? it.ToEnum<IdentifierType>() : IdentifierType;
        IdentifierFormatType = root.Attribute("IdentifierFormatType") is { Value: var ift } ? ift.ToEnum<IdentifierFormatType>() : IdentifierFormatType;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("Identifier",
            new XAttribute("IdentifierCodeType", IdentifierCodeType),
            new XAttribute("IdentifierType", IdentifierType),
            IdentifierFormatType != IdentifierFormatType.Unset ? new XAttribute("IdentifierFormatType", IdentifierFormatType) : null,
            Value
        ).ToString();
    }
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
    public string Value = string.Empty;  

    public Product() { }

    public Product(XElement root)
    {
        ProductIdentifier = root.Element("ProductIdentifier") is { } pi ? new(pi) : ProductIdentifier;
        ProductDescription = [.. root.Elements("ProductDescription").Select(e => new ProductDescription(e))];
        Classification = [.. root.Elements("Classification").Select(c => new Classification(c))];
        BookManufacturing = root.Element("BookManufacturing") is { } bm ? new(bm) : BookManufacturing;
        LabelStock = root.Element("LabelStock") is { } ls ? new(ls) : LabelStock;
        Paper = root.Element("Paper") is { } pa ? new(pa) : Paper;
        Pulp = root.Element("Pulp") is { } pu ? new(pu) : Pulp;
        RecoveredPaper = root.Element("RecoveredPaper") is { } rp ? new(rp) : RecoveredPaper;
        VirginFibre = root.Element("VirginFibre") is { } vf ? new(vf) : VirginFibre;
        WoodProducts = root.Element("WoodProducts") is { } wp ? new(wp) : WoodProducts;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("Product",
            XElement.Parse($"{ProductIdentifier}"),
            ProductDescription.Select(pd => XElement.Parse($"{pd}")),
            Classification.Select(c => XElement.Parse($"{c}")),
            BookManufacturing != null ? XElement.Parse($"{BookManufacturing}") : null,
            LabelStock != null ? XElement.Parse($"{LabelStock}") : null,
            Paper != null ? XElement.Parse($"{Paper}") : null,
            Pulp != null ? XElement.Parse($"{Pulp}") : null,
            RecoveredPaper != null ? XElement.Parse($"{RecoveredPaper}") : null,
            VirginFibre != null ? XElement.Parse($"{VirginFibre}") : null,
            WoodProducts != null ? XElement.Parse($"{WoodProducts}") : null
        ).ToString();
    }
}

public class VirginFibre
{
    public VirginFibre() { throw new NotImplementedException(); }

    public VirginFibre(XElement root) { throw new NotImplementedException(); }
}

public class RecoveredPaper
{
    public RecoveredPaper() { throw new NotImplementedException(); }

    public RecoveredPaper(XElement root) { throw new NotImplementedException(); }
}

public class Pulp
{
    public Pulp() { throw new NotImplementedException(); }

    public Pulp(XElement root) { throw new NotImplementedException(); }
}

public class LabelStock
{
    public LabelStock() { throw new NotImplementedException(); }

    public LabelStock(XElement root) { throw new NotImplementedException(); }
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
    public string Value = string.Empty;  

    public WoodProducts() { }

    public WoodProducts(XElement root)
    {
        WoodTimbersDimensionalLumberBoards = root.Element("WoodTimbersDimensionalLumberBoards") is { } wtdlb ? new(wtdlb) : WoodTimbersDimensionalLumberBoards;
        RoofingSidingDeckingFencing = root.Element("RoofingSidingDeckingFencing") is { } rsdf ? new(rsdf) : RoofingSidingDeckingFencing;
        CompositeAndVeneerWoodPanels = root.Element("CompositeAndVeneerWoodPanels") is { } cavwp ? new(cavwp) : CompositeAndVeneerWoodPanels;
        ConstructionPackagesAndPreFabPanels = root.Element("ConstructionPackagesAndPreFabPanels") is { } cpapfp ? new(cpapfp) : ConstructionPackagesAndPreFabPanels;
        Millwork = root.Element("Millwork") is { } m ? new(m) : Millwork;
        Gypsum = root.Element("Gypsum") is { } g ? new(g) : Gypsum;
        ProofInformationalQuantity = [.. root.Elements("ProofInformationalQuantity").Select(e => new ProofInformationalQuantity(e))];
        SuppliedComponentInformation = [.. root.Elements("SuppliedComponentInformation").Select(e => new SuppliedComponentInformation(e))];
        SafetyAndEnvironmentalInformation = [.. root.Elements("SafetyAndEnvironmentalInformation").Select(e => new SafetyAndEnvironmentalInformation(e))];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("WoodProducts",
            WoodTimbersDimensionalLumberBoards != null ? XElement.Parse($"{WoodTimbersDimensionalLumberBoards}") : null,
            RoofingSidingDeckingFencing != null ? XElement.Parse($"{RoofingSidingDeckingFencing}") : null,
            CompositeAndVeneerWoodPanels != null ? XElement.Parse($"{CompositeAndVeneerWoodPanels}") : null,
            ConstructionPackagesAndPreFabPanels != null ? XElement.Parse($"{ConstructionPackagesAndPreFabPanels}") : null,
            Millwork != null ? XElement.Parse($"{Millwork}") : null,
            Gypsum != null ? XElement.Parse($"{Gypsum}") : null,
            ProofInformationalQuantity.Select(piq => XElement.Parse($"{piq}")),
            SuppliedComponentInformation.Select(sci => XElement.Parse($"{sci}")),
            SafetyAndEnvironmentalInformation.Select(saei => XElement.Parse($"{saei}"))
        ).ToString();
    }
}

public class Gypsum
{
    public Gypsum() { throw new NotImplementedException(); }

    public Gypsum(XElement root) { throw new NotImplementedException(); }
}

public class Millwork
{
    public Millwork() { throw new NotImplementedException(); }

    public Millwork(XElement root) { throw new NotImplementedException(); }
}

public class ConstructionPackagesAndPreFabPanels
{
    public ConstructionPackagesAndPreFabPanels() { throw new NotImplementedException(); }

    public ConstructionPackagesAndPreFabPanels(XElement root) { throw new NotImplementedException(); }
}

public class CompositeAndVeneerWoodPanels
{
    public SoftwoodPlywood? SoftwoodPlywood { get; set; } = null;
    public WoodPanelProducts? WoodPanelProducts { get; set; } = null;
    public Packaging? Packaging { get; set; } = null;

    public CompositeAndVeneerWoodPanels() { throw new NotImplementedException(); }

    public CompositeAndVeneerWoodPanels(XElement root) { throw new NotImplementedException(); }
}

public class WoodPanelProducts
{
    public WoodPanelProducts() { throw new NotImplementedException(); }

    public WoodPanelProducts(XElement root) { throw new NotImplementedException(); }
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
    public string Value = string.Empty;  

    public SoftwoodPlywood() { }

    public SoftwoodPlywood(XElement root)
    {
        PlywoodOSBGrade = root.Element("PlywoodOSBGrade") is { } posbg ? new(posbg) : PlywoodOSBGrade;
        Thickness = root.Element("Thickness") is { } t ? new(t) : Thickness;
        Width = root.Element("Width") is { } w ? new(w) : Width;
        Length = root.Element("Length") is { } l ? new(l) : Length;
        PlywoodOSBSpecies = root.Element("PlywoodOSBSpecies") is { Value: var posbs } ? posbs.ToEnum<PlywoodOSBSpecies>() : PlywoodOSBSpecies;
        PlyNumber = root.Element("PlyNumber")?.Value ?? PlyNumber;
        Surface = root.Element("Surface") is { } s ? new(s) : Surface;
        Overlay = root.Element("Overlay") is { } o ? new(o) : Overlay;
        GlueExposure = root.Element("GlueExposure") is { Value: var ge } ? ge.ToEnum<GlueExposure>() : GlueExposure;
        Edge = root.Element("Edge") is { } e ? new(e) : Edge;
        PressureTreatment = root.Element("PressureTreatment") is { } pt ? new(pt) : PressureTreatment;
        FireTreatment = root.Element("FireTreatment") is { } ft ? new(ft) : FireTreatment;
        Supplemental = [.. root.Elements("Supplemental").Select(e => new Supplemental(e))];
        Brand = root.Element("Brand")?.Value ?? Brand;
        GradeAgency = root.Element("GradeAgency") is { Value: var ga } ? ga.ToEnum<GradeAgency>() : GradeAgency;
        GradeStamp = root.Element("GradeStamp") is { } gs ? new(gs) : GradeStamp;
        ClassIdentifier = root.Element("ClassIdentifier") is { } ci ? new(ci) : ClassIdentifier;
        LabelCharacteristics = [.. root.Elements("LabelCharacteristics").Select(e => new LabelCharacteristics(e))];
        StencilCharacteristics = [.. root.Elements("StencilCharacteristics").Select(e => new StencilCharacteristics(e))];
        SafetyAndEnvironmentalInformation = [.. root.Elements("SafetyAndEnvironmentalInformation").Select(e => new SafetyAndEnvironmentalInformation(e))];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("SoftwoodPlywood",
            XElement.Parse($"{PlywoodOSBGrade}"),
            XElement.Parse($"{Thickness}"),
            XElement.Parse($"{Width}"),
            XElement.Parse($"{Length}"),
            PlywoodOSBSpecies != PlywoodOSBSpecies.Unset ? new XElement("PlywoodOSBSpecies", PlywoodOSBSpecies.GetMemberValue()) : null,
            PlyNumber != null ? new XElement("PlyNumber", PlyNumber) : null,
            Surface != null ? XElement.Parse($"{Surface}") : null,
            Overlay != null ? XElement.Parse($"{Overlay}") : null,
            GlueExposure != GlueExposure.Unset ? XElement.Parse($"{GlueExposure}") : null,
            Edge != null ? XElement.Parse($"{Edge}") : null,
            PressureTreatment != null ? XElement.Parse($"{PressureTreatment}") : null,
            FireTreatment != null ? XElement.Parse($"{FireTreatment}") : null,
            Supplemental.Select(s => XElement.Parse($"{s}")),
            Brand != null ? new XElement("Brand", Brand) : null,
            GradeAgency != GradeAgency.Unset ? new XElement("GradeAgency", GradeAgency.GetMemberValue()) : null,
            GradeStamp != null ? XElement.Parse($"{GradeStamp}") : null,
            ClassIdentifier != null ? XElement.Parse($"{ClassIdentifier}") : null,
            LabelCharacteristics.Select(lc => XElement.Parse($"{lc}")),
            StencilCharacteristics.Select(sc => XElement.Parse($"{sc}")),
            SafetyAndEnvironmentalInformation.Select(saei => XElement.Parse($"{saei}")),
            Value
        ).ToString();
    }
}

public class Supplemental
{
    public SupplementalSpecification SupplementalSpecification { get; set; } = SupplementalSpecification.Unset;
    public List<string> AdditionalText { get; } = [];
    public string Value = string.Empty;  

    public Supplemental() { }

    public Supplemental(XElement root)
    {
        SupplementalSpecification = root.Attribute("SupplementalSpecification") is { Value: var ss } ? ss.ToEnum<SupplementalSpecification>() : SupplementalSpecification;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("Supplemental",
            SupplementalSpecification != SupplementalSpecification.Unset ? new XAttribute("SupplementalSpecification", SupplementalSpecification.GetMemberValue()) : null,
            AdditionalText.Select(at => new XElement("AdditionalText", at)),
            Value
        ).ToString();
    }
}

public class Edge
{
    public EdgeTypePlywood EdgeType { get; set; } = EdgeTypePlywood.Unset;
    public EdgeLocation EdgeLocation { get; set; } = EdgeLocation.Unset;
    public string? EdgeMachiningProfile { get; set; } = null;
    public List<string> AdditionalText { get; } = [];
    public string Value = string.Empty;  

    public Edge() { }

    public Edge(XElement root)
    {
        EdgeType = root.Attribute("EdgeType") is { Value: var et } ? et.ToEnum<EdgeTypePlywood>() : EdgeType;
        EdgeLocation = root.Attribute("EdgeLocation") is { Value: var el } ? el.ToEnum<EdgeLocation>() : EdgeLocation;
        EdgeMachiningProfile = root.Element("EdgeMachiningProfile")?.Value ?? EdgeMachiningProfile;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("Edge",
            EdgeType != EdgeTypePlywood.Unset ? new XAttribute("EdgeType", EdgeType.GetMemberValue()) : null,
            EdgeLocation != EdgeLocation.Unset ? new XAttribute("EdgeLocation", EdgeLocation.GetMemberValue()) : null,
            EdgeMachiningProfile != null ? new XElement("EdgeMachiningProfile", EdgeMachiningProfile) : null,
            AdditionalText.Select(at => new XElement("AdditionalText", at)),
            Value
        ).ToString();
    }
}

public class Overlay
{
    public OverlaySide OverlaySide { get; set; } = OverlaySide.Unset;
    public List<string> AdditionalText { get; } = [];
    public string Value = string.Empty;  

    public Overlay() { }

    public Overlay(XElement root)
    {
        OverlaySide = root.Attribute("OverlaySide") is { Value: var os } ? os.ToEnum<OverlaySide>() : OverlaySide;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("Overlay",
            OverlaySide != OverlaySide.Unset ? new XAttribute("OverlaySide", OverlaySide.GetMemberValue()) : null,
            AdditionalText.Select(at => new XAttribute("AdditionalText", at)),
            Value
        ).ToString();
    }
}

public class Surface
{
    public SurfaceType SurfaceType { get; set; } = SurfaceType.Unset;
    public List<string> AdditionalText { get; } = [];
    public string Value = string.Empty;  

    public Surface() { }

    public Surface(XElement root)
    {
        SurfaceType = root.Attribute("SurfaceType") is { Value: var st } ? st.ToEnum<SurfaceType>() : SurfaceType;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("Surface",
            SurfaceType != SurfaceType.Unset ? new XAttribute("SurfaceType", SurfaceType.GetMemberValue()) : null,
            AdditionalText.Select(at => new XElement("AdditionalText", at)),
            Value
        ).ToString();
    }
}

public class PlywoodOSBGrade
{
    public Face Face { get; set; } = Face.Unset;
    public SpanRating SpanRating { get; set; } = SpanRating.Unset;
    public StrengthGroup StrengthGroup { get; set; } = StrengthGroup.Unset;
    public string Value = string.Empty;  

    public PlywoodOSBGrade() { }

    public PlywoodOSBGrade(XElement root)
    {
        Face = root.Attribute("Face") is { Value: var f } ? f.ToEnum<Face>() : Face;
        SpanRating = root.Element("SpanRating") is { Value: var sr } ? sr.ToEnum<SpanRating>() : SpanRating;
        StrengthGroup = root.Element("StrengthGroup") is { Value: var sg } ? sg.ToEnum<StrengthGroup>() : StrengthGroup;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("PlywoodOSBGrade",
            Face != Face.Unset ? new XAttribute("Face", Face.GetMemberValue()) : null,
            SpanRating != SpanRating.Unset ? new XElement("SpanRating", SpanRating.GetMemberValue()) : null,
            StrengthGroup != StrengthGroup.Unset ? new XElement("StrengthGroup", StrengthGroup.GetMemberValue()) : null,
            Value
        ).ToString();
    }
}

public class RoofingSidingDeckingFencing
{
    public NaturalWoodSiding? NaturalWoodSiding { get; set; } = null;
    public NaturalWoodSidingOther? NaturalWoodSidingOther { get; set; } = null;
    public DeckAndPorchFlooringMaterialsNaturalWood? DeckAndPorchFlooringMaterialsNaturalWood { get; set; } = null;
    public string Value = string.Empty;  

    public RoofingSidingDeckingFencing() { }

    public RoofingSidingDeckingFencing(XElement root)
    {
        NaturalWoodSiding = root.Element("NaturalWoodSiding") is { } nws ? new(nws) : null;
        NaturalWoodSidingOther = root.Element("NaturalWoodSidingOther") is { } nwso ? new(nwso) : null;
        DeckAndPorchFlooringMaterialsNaturalWood = root.Element("DeckAndPorchFlooringMaterialsNaturalWood") is { } dapfmnw ? new(dapfmnw) : DeckAndPorchFlooringMaterialsNaturalWood;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("RoofingSidingDeckingFencing",
            NaturalWoodSiding != null ? XElement.Parse($"{NaturalWoodSiding}") : null,
            NaturalWoodSidingOther != null ? XElement.Parse($"{NaturalWoodSidingOther}") : null,
            DeckAndPorchFlooringMaterialsNaturalWood != null ? XElement.Parse($"{DeckAndPorchFlooringMaterialsNaturalWood}") : null,
            Value
        ).ToString();
    }
}

public class DeckAndPorchFlooringMaterialsNaturalWood
{
    public DeckAndPorchFlooringMaterialsNaturalWoodCharacteristics DeckAndPorchFlooringMaterialsNaturalWoodCharacteristics { get; set; } = new();
    public Packaging? Packaging { get; set; } = null;
    public string Value = string.Empty;  

    public string LocalName => "DeckAndPorchFlooringMaterials-NaturalWood";

    public DeckAndPorchFlooringMaterialsNaturalWood() { }

    public DeckAndPorchFlooringMaterialsNaturalWood(XElement root)
    {
        DeckAndPorchFlooringMaterialsNaturalWoodCharacteristics = root.Element("DeckAndPorchFlooringMaterials-NaturalWoodCharacteristics") is { } dapfmnwc ? new(dapfmnwc) : DeckAndPorchFlooringMaterialsNaturalWoodCharacteristics;
        Packaging = root.Element("Packaging") is { } p ? new(p) : Packaging;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement(LocalName,
            XElement.Parse($"{DeckAndPorchFlooringMaterialsNaturalWoodCharacteristics}"),
            Packaging != null ? XElement.Parse($"{Packaging}") : null,
            Value
        ).ToString();
    }
}

public class DeckAndPorchFlooringMaterialsNaturalWoodCharacteristics : SoftwoodLumberCharacteristicsBase
{
    public DeckAndPorchFlooringMaterialsNaturalWoodCharacteristics() : base() { }

    public DeckAndPorchFlooringMaterialsNaturalWoodCharacteristics(XElement root) : base(root) { }

    public override string LocalName => "DeckAndPorchFlooringMaterials-NaturalWoodCharacteristics";
}

public class NaturalWoodSidingOther
{
    public NaturalWoodSidingOtherCharacteristics NaturalWoodSidingOtherCharacteristics { get; set; } = new();
    public Packaging? Packaging { get; set; } = null;
    public string Value = string.Empty;  

    public string LocalName => "NaturalWoodSiding-Other";

    public NaturalWoodSidingOther() { }

    public NaturalWoodSidingOther(XElement root)
    {
        NaturalWoodSidingOtherCharacteristics = root.Element("NaturalWoodSiding-OtherCharacteristics") is { } nwsoc ? new(nwsoc) : NaturalWoodSidingOtherCharacteristics;
        Packaging = root.Element("Packaging") is { } p ? new(p) : Packaging;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement(LocalName,
            XElement.Parse($"{NaturalWoodSidingOtherCharacteristics}"),
            Packaging != null ? XElement.Parse($"{Packaging}") : null,
            Value
        ).ToString();
    }
}

public class NaturalWoodSidingOtherCharacteristics : SoftwoodLumberCharacteristicsBase
{
    public NaturalWoodSidingOtherCharacteristics() : base() { }

    public NaturalWoodSidingOtherCharacteristics(XElement root) : base(root) { }

    public override string LocalName => "NaturalWoodSiding-OtherCharacteristics";
}

public class NaturalWoodSiding
{
    public NaturalWoodSidingCharacteristics NaturalWoodSidingCharacteristics { get; set; } = new();
    public Packaging? Packaging { get; set; } = null;
    public string Value = string.Empty;  

    public NaturalWoodSiding() { }

    public NaturalWoodSiding(XElement root)
    {
        NaturalWoodSidingCharacteristics = root.Element("NaturalWoodSidingCharacteristics") is { } nwsc ? new(nwsc) : NaturalWoodSidingCharacteristics;
        Packaging = root.Element("Packaging") is { } p ? new(p) : Packaging;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("NaturalWoodSiding",
            XElement.Parse($"{NaturalWoodSidingCharacteristics}"),
            Packaging != null ? XElement.Parse($"{Packaging}") : null,
            Value
        ).ToString();
    }
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
    public string Value = string.Empty;  
    
    public abstract string LocalName { get; }

    public SoftwoodLumberCharacteristicsBase() { }

    public SoftwoodLumberCharacteristicsBase(XElement root)
    {
        LumberSpecies = root.Element("LumberSpecies") is { } ls ? new(ls) : LumberSpecies;
        LumberGrade = root.Element("LumberGrade") is { } lg ? new(lg) : LumberGrade;
        Length = root.Element("Length") is { } l ? new(l) : Length;
        Width = root.Element("Width") is { } wi ? new(wi) : Width;
        Thickness = root.Element("Thickness") is { } th ? new(th) : Thickness;
        Seasoning = root.Element("Seasoning") is { } s ? new(s) : Seasoning;
        MoistureContent = root.Element("MoistureContent") is { } mc ? new(mc) : MoistureContent;
        HeatTreatment = root.Element("HeatTreatment") is { } ht ? new(ht) : HeatTreatment;
        ManufacturingProcess = [.. root.Elements("ManufacturingProcess").Select(e => new ManufacturingProcess(e))];
        PatternProfile = root.Element("PatternProfile") is { } pp ? new(pp) : PatternProfile;
        Trim = root.Element("Trim") is { } tr ? new(tr) : Trim;
        Joining = root.Element("Joining") is { } j ? new(j) : Joining;
        PressureTreatment = root.Element("PressureTreatment") is { } pt ? new(pt) : PressureTreatment;
        FireTreatment = root.Element("FireTreatment") is { } ft ? new(ft) : FireTreatment;
        OtherTreatment = root.Element("OtherTreatment") is { } ot ? new(ot) : OtherTreatment;
        GradeStamp = root.Element("GradeStamp") is { } gs ? new(gs) : GradeStamp;
        ExLog = root.Element("ExLog") is { } el ? new(el) : ExLog;
        ClassIdentifier = root.Element("ClassIdentifier") is { } ci ? new(ci) : ClassIdentifier;
        Weight = root.Element("Weight") is { } we ? new(we) : Weight;
        LabelCharacteristics = root.Element("LabelCharacteristics") is { } lc ? new(lc) : LabelCharacteristics;
        StencilCharacteristics = root.Element("StencilCharacteristics") is { } sc ? new(sc) : StencilCharacteristics;
        Wrap = root.Element("Wrap") is { } wr ? new(wr) : Wrap;
        SafetyAndEnvironmentalInformation = [.. root.Elements("SafetyAndEnvironmentalInformation").Select(e => new SafetyAndEnvironmentalInformation(e))];
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        LengthCutDescription = root.Element("LengthCutDescription") is { } lcd ? new(lcd) : LengthCutDescription;
        ShippingMark = root.Element("ShippingMark")?.Value ?? ShippingMark;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement(LocalName,
            XElement.Parse($"{LumberSpecies}"),
            XElement.Parse($"{LumberGrade}"),
            Length != null ? XElement.Parse($"{Length}") : null,
            Width != null ? XElement.Parse($"{Width}") : null,
            Thickness != null ? XElement.Parse($"{Thickness}") : null,
            Seasoning != null ? XElement.Parse($"{Seasoning}") : null,
            MoistureContent != null ? XElement.Parse($"{MoistureContent}") : null,
            HeatTreatment != null ? XElement.Parse($"{HeatTreatment}") : null,
            ManufacturingProcess.Select(mp => XElement.Parse($"{mp}")),
            PatternProfile != null ? XElement.Parse($"{PatternProfile}") : null,
            Trim != null ? XElement.Parse($"{Trim}") : null,
            Joining != null ? XElement.Parse($"{Joining}") : null,
            PressureTreatment != null ? XElement.Parse($"{PressureTreatment}") : null,
            FireTreatment != null ? XElement.Parse($"{FireTreatment}") : null,
            OtherTreatment != null ? XElement.Parse($"{OtherTreatment}") : null,
            GradeStamp != null ? XElement.Parse($"{GradeStamp}") : null,
            ExLog != null ? XElement.Parse($"{ExLog}") : null,
            ClassIdentifier != null ? XElement.Parse($"{ClassIdentifier}") : null,
            Weight != null ? XElement.Parse($"{Weight}") : null,
            LabelCharacteristics != null ? XElement.Parse($"{LabelCharacteristics}") : null,
            StencilCharacteristics != null ? XElement.Parse($"{StencilCharacteristics}") : null,
            Wrap != null ? XElement.Parse($"{Wrap}") : null,
            SafetyAndEnvironmentalInformation.Select(saei => XElement.Parse($"{saei}")),
            AdditionalText.Select(at => new XElement("AdditionalText", at)),
            LengthCutDescription != null ? XElement.Parse($"{LengthCutDescription}") : null,
            ShippingMark != null ? new XElement("ShippingMark", ShippingMark) : null
        ).ToString();
    }
}

public class NaturalWoodSidingCharacteristics : SoftwoodLumberCharacteristicsBase
{
    public NaturalWoodSidingCharacteristics() : base() { }

    public NaturalWoodSidingCharacteristics(XElement root) : base(root) { }

    public override string LocalName => "NaturalWoodSidingCharacteristics";
}

public class WoodTimbersDimensionalLumberBoards
{
    public SoftwoodLumber? SoftwoodLumber { get; set; } = null;
    public HardwoodLumber? HardwoodLumber { get; set; } = null;
    public string Value = string.Empty;  

    public WoodTimbersDimensionalLumberBoards() { }

    public WoodTimbersDimensionalLumberBoards(XElement root)
    {
        SoftwoodLumber = root.Element("SoftwoodLumber") is { } sl ? new(sl) : SoftwoodLumber;
        HardwoodLumber = root.Element("HardwoodLumber") is { } hl ? new(hl) : HardwoodLumber;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("WoodTimbersDimensionalLumberBoards",
            SoftwoodLumber != null ? XElement.Parse($"{SoftwoodLumber}") : null,
            HardwoodLumber != null ? XElement.Parse($"{HardwoodLumber}") : null
        ).ToString();
    }
}

public class HardwoodLumber
{
    public HardwoodLumberCharacteristics HardwoodLumberCharacteristics { get; set; } = new();
    public Packaging? Packaging { get; set; } = null;
    public string Value = string.Empty;  

    public HardwoodLumber() { }

    public HardwoodLumber(XElement root)
    {
        HardwoodLumberCharacteristics = root.Element("HardwoodLumberCharacteristics") is { } hlc ? new(hlc) : HardwoodLumberCharacteristics;
        Packaging = root.Element("Packaging") is { } p ? new(p) : Packaging;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("HardwoodLumber",
            XElement.Parse($"{HardwoodLumberCharacteristics}"),
            Packaging != null ? XElement.Parse($"{Packaging}") : null,
            Value
        ).ToString();
    }
}

public class HardwoodLumberCharacteristics
{
    public List<AnyType> AnyType { get; } = [];
    public string Value = string.Empty;  

    public HardwoodLumberCharacteristics() { }

    public HardwoodLumberCharacteristics(XElement root)
    {
        AnyType = [.. root.Elements().Select(e => new AnyType(e))];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("HardwoodLumberCharacteristics",
            AnyType.Select(at => XElement.Parse($"{at}")),
            Value
        ).ToString();
    }
}

public class AnyType
{
    public string LocalName = string.Empty;
    public string Value = string.Empty;  

    public AnyType() { }

    public AnyType(XElement root)
    {
        LocalName = root.Name.LocalName;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement(LocalName,
            Value
        ).ToString();
    }
}

public class SoftwoodLumber
{
    public SoftwoodLumberCharacteristics SoftwoodLumberCharacteristics { get; set; } = new();
    public Packaging? Packaging { get; set; } = null;
    public string Value = string.Empty;  

    public SoftwoodLumber() { }

    public SoftwoodLumber(XElement root)
    {
        SoftwoodLumberCharacteristics = root.Element("SoftwoodLumberCharacteristics") is { } slc ? new(slc) : SoftwoodLumberCharacteristics;
        Packaging = root.Element("Packaging") is { } p ? new(p) : Packaging;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("SoftwoodLumber",
            XElement.Parse($"{SoftwoodLumberCharacteristics}"),
            Packaging != null ? XElement.Parse($"{Packaging}") : null
        ).ToString();
    }
}

public class Packaging
{
    public ProductPackaging ProductPackaging { get; set; } = new();
    public string Value = string.Empty;  

    public Packaging() { }

    public Packaging(XElement root)
    {
        ProductPackaging = root.Element("ProductPackaging") is { } pp ? new(pp) : ProductPackaging;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("Packaging",
            XElement.Parse($"{ProductPackaging}"),
            Value
        ).ToString();
    }
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
    public string Value = string.Empty;  

    public ProductPackaging() { }

    public ProductPackaging(XElement root)
    {
        QuantityInUnit = root.Element("QuantityInUnit") is { } qiu ? new(qiu) : QuantityInUnit;
        UnitDimension = root.Element("UnitDimension") is { } ud ? new(ud) : UnitDimension;
        Weight = root.Element("Weight") is { } w ? new(w) : Weight;
        PackageIDInformation = root.Element("PackageIDInformation") is { } pidi ? new(pidi) : PackageIDInformation;
        LabelCharacteristics = [.. root.Elements("LabelCharacteristics").Select(e => new LabelCharacteristics(e))];
        StencilCharacteristics = [.. root.Elements("StencilCharacteristics").Select(e => new StencilCharacteristics(e))];
        BandCharacteristics = [.. root.Elements("BandCharacteristics").Select(e => new BandCharacteristics(e))];
        PalletCharacteristics = [.. root.Elements("PalletCharacteristics").Select(e => new PalletCharacteristics(e))];
        Wrap = [.. root.Elements("Wrap").Select(e => new Wrap(e))];
        AdditionalText = [.. root.Elements("AdditionalText").Select(at => at.Value)];
        PackageType = root.Element("PackageType") is { Value: var pt } ? pt.ToEnum<PackageType>() : PackageType;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("ProductPackaging",
            QuantityInUnit != null ? XElement.Parse($"{QuantityInUnit}") : null,
            UnitDimension != null ? XElement.Parse($"{UnitDimension}") : null,
            Weight != null ? XElement.Parse($"{Weight}") : null,
            PackageIDInformation != null ? XElement.Parse($"{PackageIDInformation}") : null,
            LabelCharacteristics.Select(lc => XElement.Parse($"{lc}")),
            StencilCharacteristics.Select(sc => XElement.Parse($"{sc}")),
            BandCharacteristics.Select(bc => XElement.Parse($"{bc}")),
            PalletCharacteristics.Select(pc => XElement.Parse($"{pc}")),
            Wrap.Select(w => XElement.Parse($"{w}")),
            AdditionalText.Select(at => new XElement("AdditionalText", at)),
            PackageType != null ? new XElement("PackageType", PackageType.GetMemberValue()) : null,
            Value
        ).ToString();
    }
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
    public string Value = string.Empty;  

    public PalletCharacteristics() { }

    public PalletCharacteristics(XElement root)
    {
        MixedProductPalletIndicator = root.Attribute("MixedProductPalletIndicator") is { Value: var mppi } ? mppi.ToEnum<YesNo>() : MixedProductPalletIndicator;
        PalletType = root.Attribute("PalletType") is { Value: var pt } ? pt.ToEnum<PalletType>() : PalletType;
        PalletLedgeType = root.Attribute("PalletLedgeType") is { Value: var plt } ? plt.ToEnum<PalletLedgeType>() : PalletLedgeType;
        PalletCoverType = root.Attribute("PalletCoverType") is { Value: var pct } ? pct.ToEnum<PalletCoverType>() : PalletCoverType;
        PalletAdditionsType = root.Attribute("PalletAdditionsType") is { Value: var pat } ? pat.ToEnum<PalletAdditionsType>() : PalletAdditionsType;
        PalletTopType = root.Attribute("PalletTopType") is { Value: var ptt } ? ptt.ToEnum<PalletTopType>() : PalletTopType;
        IsPartialPalletsAllowed = root.Attribute("IsPartialPalletsAllowed") is { Value: var ippa } ? ippa.ToEnum<YesNo>() : IsPartialPalletsAllowed;
        ProductIdentification = root.Element("ProductIdentification") is { } pi ? new(pi) : ProductIdentification;
        PalletLength = root.Element("PalletLength") is { } pl ? new(pl) : PalletLength;
        PalletWidth = root.Element("PalletWidth") is { } pw ? new(pw) : PalletWidth;
        ItemsPerPallet = root.Element("ItemsPerPallet")?.Value ?? ItemsPerPallet;
        StacksPerPallet = root.Element("StacksPerPallet")?.Value ?? StacksPerPallet;
        TiersPerPallet = root.Element("TiersPerPallet")?.Value ?? TiersPerPallet;
        MaximumHeight = root.Element("MaximumHeight") is { } mh ? new(mh) : MaximumHeight;
        StackingMethod = root.Element("StackingMethod")?.Value ?? StackingMethod;
        LabelCharacteristics = root.Element("LabelCharacteristics") is { } lc ? new(lc) : LabelCharacteristics;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("PalletCharacteristics",
            MixedProductPalletIndicator != YesNo.Unset ? new XAttribute("MixedProductPalletIndicator", MixedProductPalletIndicator.GetMemberValue()) : null,
            PalletType != PalletType.Unset ? new XAttribute("PalletType", PalletType.GetMemberValue()) : null,
            PalletLedgeType != PalletLedgeType.Unset ? new XAttribute("PalletLedgeType", PalletLedgeType.GetMemberValue()) : null,
            PalletCoverType != PalletCoverType.Unset ? new XAttribute("PalletCoverType", PalletCoverType.GetMemberValue()) : null,
            PalletAdditionsType != PalletAdditionsType.Unset ? new XAttribute("PalletAdditionsType", PalletAdditionsType.GetMemberValue()) : null,
            PalletTopType != PalletTopType.Unset ? new XAttribute("PalletTopType", PalletTopType.GetMemberValue()) : null,
            IsPartialPalletsAllowed != YesNo.Unset ? new XAttribute("IsPartialPalletsAllowed", IsPartialPalletsAllowed.GetMemberValue()) : null,
            ProductIdentification != null ? XElement.Parse($"{ProductIdentification}") : null,
            PalletLength != null ? XElement.Parse($"{PalletLength}") : null,
            PalletWidth != null ? XElement.Parse($"{PalletWidth}") : null,
            ItemsPerPallet != null ? new XElement("ItemsPerPallet", ItemsPerPallet) : null,
            StacksPerPallet != null ? new XElement("StacksPerPallet", StacksPerPallet) : null,
            TiersPerPallet != null ? new XElement("TiersPerPallet", TiersPerPallet) : null,
            MaximumHeight != null ? XElement.Parse($"{MaximumHeight}") : null,
            StackingMethod != null ? new XElement("StackingMethod", StackingMethod) : null,
            LabelCharacteristics != null ? XElement.Parse($"{LabelCharacteristics}") : null,
            Value
        ).ToString();
    }
}

public class MaximumHeight : Height
{
    public MaximumHeight() : base() { }

    public MaximumHeight(XElement root) : base(root) { }

    public override string LocalName => "MaximumHeight";
}

public class PalletWidth : Width
{
    public PalletWidth() : base() { }

    public PalletWidth(XElement root) : base(root) { }

    public override string LocalName => "PalletWidth";
}

public class PalletLength : Length
{
    public PalletLength() : base() { }

    public PalletLength(XElement root) : base(root) { }

    public override string LocalName => "PalletLength";
}

public class ProductIdentification
{
    public ProductIdentifier ProductIdentifier { get; set; } = new();
    public List<string> ProductDescription { get; } = [];
    public string Value = string.Empty;   

    public ProductIdentification() { }

    public ProductIdentification(XElement root)
    {
        ProductIdentifier = root.Element("ProductIdentifier") is { } pi ? new(pi) : ProductIdentifier;
        ProductDescription = [.. root.Elements("ProductDescription").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("ProductIdentification",
            XElement.Parse($"{ProductIdentifier}"),
            ProductDescription.Select(pd => new XElement("ProductDescription", pd)),
            Value
        ).ToString();
    }
}

public class BandCharacteristics
{
    public BandType BandType { get; set; } = BandType.Unset;
    public YesNo BandsRequired { get; set; } = YesNo.Unset;
    public string? NumberOfBands { get; set; } = null;
    public string? BandColour { get; set; } = null;
    public string Value = string.Empty;  

    public BandCharacteristics() { }

    public BandCharacteristics(XElement root)
    {
        BandType = root.Attribute("BandType") is { Value: var bt } ? bt.ToEnum<BandType>() : BandType;
        BandsRequired = root.Attribute("BandsRequired") is { Value: var br } ? br.ToEnum<YesNo>() : BandsRequired;
        NumberOfBands = root.Element("NumberOfBands")?.Value ?? NumberOfBands;
        BandColour = root.Element("BandColour")?.Value ?? BandColour;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("BandCharacteristics",
            BandType != BandType.Unset ? new XAttribute("BandType", BandType.GetMemberValue()) : null,
            BandsRequired != YesNo.Unset ? new XAttribute("BandsRequired", BandsRequired.GetMemberValue()) : null,
            NumberOfBands != null ? new XElement("NumberOfBands", NumberOfBands) : null,
            BandColour != null ? new XElement("BandColour", BandColour) : null,
            Value
        ).ToString();
    }
}

public class PackageIDInformation
{
    public PackageAgency PackageAgency { get; set; } = PackageAgency.Unset;
    public string? PackageCode { get; set; } = null;
    public string? PackageName { get; set; } = null;
    public string Value = string.Empty;  

    public PackageIDInformation() { }

    public PackageIDInformation(XElement root)
    {
        PackageAgency = root.Attribute("PackageAgency") is { Value: var pa } ? pa.ToEnum<PackageAgency>() : PackageAgency;
        PackageCode = root.Element("PackageCode")?.Value ?? PackageCode;
        PackageName = root.Element("PackageName")?.Value ?? PackageName;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("PackageIDInformation",
            PackageAgency != PackageAgency.Unset ? new XAttribute("PackageAgency", PackageAgency.GetMemberValue()) : null,
            PackageCode != null ? new XElement("PackageCode", PackageCode) : null,
            PackageName != null ? new XElement("PackageName", PackageName) : null,
            Value
        ).ToString();
    }
}

public class UnitDimension
{
    public Length? Length { get; set; } = null;
    public Width? Width { get; set; } = null;
    public Height? Height { get; set; } = null;
    public string? PiecesPerRow { get; set; } = null;
    public string? RowsPerUnit { get; set; } = null;
    public string Value = string.Empty;  

    public UnitDimension() { }

    public UnitDimension(XElement root)
    {
        Length = root.Element("Length") is { } l ? new(l) : Length;
        Width = root.Element("Width") is { } w ? new(w) : Width;
        Height = root.Element("Height") is { } h ? new(h) : Height;
        PiecesPerRow = root.Element("PiecesPerRow")?.Value ?? PiecesPerRow;
        RowsPerUnit = root.Element("RowsPerUnit")?.Value ?? RowsPerUnit;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("UnitDimension",
            Length != null ? XElement.Parse($"{Length}") : null,
            Width != null ? XElement.Parse($"{Width}") : null,
            Height != null ? XElement.Parse($"{Height}") : null,
            PiecesPerRow != null ? new XElement("PiecesPerRow", PiecesPerRow) : null,
            RowsPerUnit != null ? new XElement("RowsPerUnit", RowsPerUnit) : null,
            Value
        ).ToString();
    }
}

public class QuantityInUnit : MeasurementBase
{
    public QuantityInUnit() : base() { }

    public QuantityInUnit(XElement root) : base(root) { }

    public override string LocalName => "QuantityInUnit";
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
    public string Value = string.Empty;  

    public SoftwoodLumberCharacteristics() { }

    public SoftwoodLumberCharacteristics(XElement root)
    {
        LumberSpecies = root.Element("LumberSpecies") is { } ls ? new(ls) : LumberSpecies;
        LumberGrade = root.Element("LumberGrade") is { } lg ? new(lg) : LumberGrade;
        Length = root.Element("Length") is { } l ? new(l) : Length;
        Width = root.Element("Width") is { } w ? new(w) : Width;
        Thickness = root.Element("Thickness") is { } t ? new(t) : Thickness;
        Seasoning = root.Element("Seasoning") is { } s ? new(s) : Seasoning;
        MoistureContent = root.Element("MoistureContent") is { } mc ? new(mc) : MoistureContent;
        HeatTreatment = root.Element("HeatTreatment") is { } ht ? new(ht) : HeatTreatment;
        ManufacturingProcess = root.Element("ManufacturingProcess") is { } mp ? new(mp) : ManufacturingProcess;
        PatternProfile = root.Element("PatternProfile") is { } pp ? new(pp) : PatternProfile;
        Trim = root.Element("Trim") is { } trim ? new(trim) : Trim;
        Joining = root.Element("Joining") is { } j ? new(j) : Joining;
        PressureTreatment = root.Element("PressureTreatment") is { } pt ? new(pt) : PressureTreatment;
        FireTreatment = root.Element("FireTreatment") is { } ft ? new(ft) : FireTreatment;
        OtherTreatment = root.Element("OtherTreatment") is { } ot ? new(ot) : OtherTreatment;
        GradeStamp = root.Element("GradeStamp") is { } gs ? new(gs) : GradeStamp;
        ExLog = root.Element("ExLog") is { } el ? new(el) : ExLog;
        ClassIdentifier = [.. root.Elements("ClassIdentifier").Select(e => new ClassIdentifier(e))];
        Weight = root.Element("Weight") is { } weight ? new(weight) : Weight;
        LabelCharacteristics = root.Element("LabelCharacteristics") is { } lchar ? new(lchar) : LabelCharacteristics;
        StencilCharacteristics = root.Element("StencilCharacteristics") is { } sc ? new(sc) : StencilCharacteristics;
        Wrap = root.Element("Wrap") is { } wrap ? new(wrap) : Wrap;
        SafetyAndEnvironmentalInformation = [.. root.Elements("SafetyAndEnvironmentalInformation").Select(e => new SafetyAndEnvironmentalInformation(e))];
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        LengthCutDescription = root.Element("LengthCutDescription") is { } lcd ? new(lcd) : LengthCutDescription;
        ShippingMark = root.Element("ShippingMark")?.Value ?? ShippingMark;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("SoftwoodLumberCharacteristics",
            LumberSpecies != null ? XElement.Parse($"{LumberSpecies}") : null,
            LumberGrade != null ? XElement.Parse($"{LumberGrade}") : null,
            Length != null ? XElement.Parse($"{Length}") : null,
            Width != null ? XElement.Parse($"{Width}") : null,
            Thickness != null ? XElement.Parse($"{Thickness}") : null,
            Seasoning != null ? XElement.Parse($"{Seasoning}") : null,
            MoistureContent != null ? XElement.Parse($"{MoistureContent}") : null,
            HeatTreatment != null ? XElement.Parse($"{HeatTreatment}") : null,
            ManufacturingProcess != null ? XElement.Parse($"{ManufacturingProcess}") : null,
            PatternProfile != null ? XElement.Parse($"{PatternProfile}") : null,
            Trim != null ? XElement.Parse($"{Trim}") : null,
            Joining != null ? XElement.Parse($"{Joining}") : null,
            PressureTreatment != null ? XElement.Parse($"{PressureTreatment}") : null,
            FireTreatment != null ? XElement.Parse($"{FireTreatment}") : null,
            OtherTreatment != null ? XElement.Parse($"{OtherTreatment}") : null,
            GradeStamp != null ? XElement.Parse($"{GradeStamp}") : null,
            ExLog != null ? XElement.Parse($"{ExLog}") : null,
            ClassIdentifier.Select(ci => XElement.Parse($"{ci}")),
            Weight != null ? XElement.Parse($"{Weight}") : null,
            LabelCharacteristics != null ? XElement.Parse($"{LabelCharacteristics}") : null,
            StencilCharacteristics != null ? XElement.Parse($"{StencilCharacteristics}") : null,
            Wrap != null ? XElement.Parse($"{Wrap}") : null,
            SafetyAndEnvironmentalInformation.Select(saei => XElement.Parse($"{saei}")),
            AdditionalText.Select(at => new XElement("AdditionalText", at)),
            LengthCutDescription != null ? XElement.Parse($"{LengthCutDescription}") : null,
            ShippingMark != null ? new XElement("ShippingMark", ShippingMark) : null
        ).ToString();
    }
}

public class LengthCutDescription
{
    public LengthCutType LengthCutType { get; set; } = LengthCutType.Unset;
    public string Value = string.Empty;  

    public LengthCutDescription() { }

    public LengthCutDescription(XElement root)
    {
        LengthCutType = root.Attribute("LengthCutType") is { Value: var lct } ? lct.ToEnum<LengthCutType>() : LengthCutType;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("LengthCutDescription",
            LengthCutType != LengthCutType.Unset ? new XAttribute("LengthCutType", LengthCutType.GetMemberValue()) : null,
            Value
        ).ToString();
    }
}

public class Wrap
{
    public WrapType WrapType { get; set; } = WrapType.Unset;
    public WrapProperties WrapProperties { get; set; } = WrapProperties.Unset;
    public WrapLocation WrapLocation { get; set; } = WrapLocation.Unset;
    public string? NumberOfWraps { get; set; } = null;
    public string? Brand { get; set; } = null;
    public string Value = string.Empty;  

    public Wrap() { }

    public Wrap(XElement root)
    {
        WrapType = root.Attribute("WrapType") is { Value: var wt } ? wt.ToEnum<WrapType>() : WrapType;
        WrapProperties = root.Attribute("WrapProperties") is { Value: var wp } ? wp.ToEnum<WrapProperties>() : WrapProperties;
        WrapLocation = root.Attribute("WrapLocation") is { Value: var wl } ? wl.ToEnum<WrapLocation>() : WrapLocation;
        NumberOfWraps = root.Element("NumberOfWraps")?.Value ?? NumberOfWraps;
        Brand = root.Element("Brand")?.Value ?? Brand;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("Wrap",
            WrapType != WrapType.Unset ? new XAttribute("WrapType", WrapType.GetMemberValue()) : null,
            WrapProperties != WrapProperties.Unset ? new XAttribute("WrapProperties", WrapProperties.GetMemberValue()) : null,
            WrapLocation != WrapLocation.Unset ? new XAttribute("WrapLocation", WrapLocation.GetMemberValue()) : null,
            NumberOfWraps != null ? new XElement("NumberOfWraps", NumberOfWraps) : null,
            Brand != null ? new XElement("Brand", Brand) : null,
            Value
        ).ToString();
    }
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
    public string Value = string.Empty;  

    public StencilCharacteristics() { }

    public StencilCharacteristics(XElement root)
    {
        StencilType = root.Attribute("StencilType") is { Value: var st } ? st.ToEnum<StencilType>() : StencilType;
        StencilInkType = root.Attribute("StencilInkType") is { Value: var sit } ? sit.ToEnum<StencilInkType>() : StencilInkType;
        StencilLocation = root.Attribute("StencilLocation") is { Value: var sl } ? sl.ToEnum<StencilLocation>() : StencilLocation;
        StencilFormat = root.Attribute("StencilFormat") is { Value: var sf } ? sf.ToEnum<StencilFormat>() : StencilFormat;
        StencilContent = root.Attribute("StencilContent") is { Value: var sc } ? sc.ToEnum<StencilContent>() : StencilContent;
        AssignedBy = root.Attribute("AssignedBy") is { Value: var ab } ? ab.ToEnum<AssignedBy>() : AssignedBy;
        StencilText = [.. root.Elements("StencilText").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("StencilCharacteristics",
            StencilType != StencilType.Unset ? new XAttribute("StencilType", StencilType.GetMemberValue()) : null,
            StencilInkType != StencilInkType.Unset ? new XAttribute("StencilInkType", StencilInkType.GetMemberValue()) : null,
            StencilLocation != StencilLocation.Unset ? new XAttribute("StencilLocation", StencilLocation.GetMemberValue()) : null,
            StencilFormat != StencilFormat.Unset ? new XAttribute("StencilFormat", StencilFormat.GetMemberValue()) : null,
            StencilContent != StencilContent.Unset ? new XAttribute("StencilContent", StencilContent.GetMemberValue()) : null,
            AssignedBy != AssignedBy.Unset ? new XAttribute("AssignedBy", AssignedBy.GetMemberValue()) : null,
            StencilText.Select(st => new XElement("StencilText", st)),
            Value
        ).ToString();
    }
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
    public string Value = string.Empty;  

    public LabelCharacteristics() { }

    public LabelCharacteristics(XElement root)
    {
        CustomerMarks = [.. root.Elements("CustomerMarks").Select(e => e.Value)];
        LabelStyle = root.Element("LabelStyle")?.Value ?? LabelStyle;
        LabelBrandName = root.Element("LabelBrandName")?.Value ?? LabelBrandName;
        LabelPosition = root.Element("LabelPosition")?.Value ?? LabelPosition;
        NumberOfLabels = root.Element("NumberOfLabels")?.Value ?? NumberOfLabels;
        Length = root.Element("Length") is { } l ? new(l) : Length;
        Width = root.Element("Width") is { } w ? new(w) : Width;
        ColourCode = root.Element("ColourCode")?.Value ?? ColourCode;
        ColourDescription = root.Element("ColourDescription")?.Value ?? ColourDescription;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("LabelCharacteristics",
            CustomerMarks.Select(cm => new XElement("CustomerMarks", cm)),
            LabelStyle != null ? new XElement("LabelStyle", LabelStyle) : null,
            LabelBrandName != null ? new XElement("LabelBrandName", LabelBrandName) : null,
            LabelPosition != null ? new XElement("LabelPosition", LabelPosition) : null,
            NumberOfLabels != null ? new XElement("NumberOfLabels", NumberOfLabels) : null,
            Length != null ? XElement.Parse($"{Length}") : null,
            Width != null ? XElement.Parse($"{Width}") : null,
            ColourCode != null ? new XElement("ColourCode", ColourCode) : null,
            ColourDescription != null ? new XElement("ColourDescription", ColourDescription) : null,
            Value
        ).ToString();
    }
}

public class Weight : MeasurementBase
{
    public Weight() : base() { }

    public Weight(XElement root) : base(root) { }

    public override string LocalName => "Weight";
}

public class ClassIdentifier
{
    public IdentifierCodeType IdentifierCodeType = IdentifierCodeType.Supplier;
    public IdentifierType IdentifierType = IdentifierType.Primary;
    public IdentifierFormatType IdentifierFormatType { get; set; } = IdentifierFormatType.Unset;
    public string Value = string.Empty;  

    public ClassIdentifier() { }

    public ClassIdentifier(XElement root)
    {
        IdentifierCodeType = root.Attribute("IdentifierCodeType") is { Value: var ict } ? ict.ToEnum<IdentifierCodeType>() : IdentifierCodeType;
        IdentifierType = root.Attribute("IdentifierType") is { Value: var it } ? it.ToEnum<IdentifierType>() : IdentifierType;
        IdentifierFormatType = root.Attribute("IdentifierFormatType") is { Value: var ift } ? ift.ToEnum<IdentifierFormatType>() : IdentifierFormatType;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("ClassIdentifier",
            new XAttribute("IdentifierCodeType", IdentifierCodeType.GetMemberValue()),
            new XAttribute("IdentifierType", IdentifierType.GetMemberValue()),
            IdentifierFormatType != IdentifierFormatType.Unset ? new XAttribute("IdentifierFormatType", IdentifierFormatType.GetMemberValue()) : null,
            Value
        ).ToString();
    }
}

public class ExLog
{
    public Value Value { get; set; } = new();

    public ExLog() { }

    public ExLog(XElement root)
    {
        Value = root.Element("Value") is { } v ? new(v) : Value;
    }

    public override string ToString()
    {
        return new XElement("ExLog",
            XElement.Parse($"{Value}")
        ).ToString();
    }
}

public class GradeStamp
{
    public GradeStamped GradeStamped { get; set; } = GradeStamped.Unset;
    public string? GradeStampMillNumber { get; set; } = null;
    public GradeStampLocation GradeStampLocation { get; set; } = GradeStampLocation.Unset;
    public string Value = string.Empty;  

    public GradeStamp() { }

    public GradeStamp(XElement root)
    {
        GradeStamped = root.Attribute("GradeStamped") is { Value: var gs } ? gs.ToEnum<GradeStamped>() : GradeStamped;
        GradeStampMillNumber = root.Element("GradeStampMillNumber")?.Value ?? GradeStampMillNumber;
        GradeStampLocation = root.Element("GradeStampLocation") is { Value: var gsl } ? gsl.ToEnum<GradeStampLocation>() : GradeStampLocation;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("GradeStamp",

            Value
        ).ToString();
    }
}

public class OtherTreatment
{
    public List<string> AdditionalText { get; } = [];
    public string Value = string.Empty;  

    public OtherTreatment() { }

    public OtherTreatment(XElement root)
    {
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("OtherTreatment",
            AdditionalText.Select(at => new XElement("AdditionalText", at)),
            Value
        ).ToString();
    }
}

public class FireTreatment
{
    public FireTreatmentType FireTreatmentType { get; set; } = FireTreatmentType.Unset;
    public List<string> AdditionalText { get; } = [];
    public string Value = string.Empty;  

    public FireTreatment() { }

    public FireTreatment(XElement root)
    {
        FireTreatmentType = root.Attribute("FireTreatmentType") is { Value: var ftt } ? ftt.ToEnum<FireTreatmentType>() : FireTreatmentType;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("FireTreatment",
            FireTreatmentType != FireTreatmentType.Unset ? new XAttribute("FireTreatmentType", FireTreatmentType.GetMemberValue()) : null,
            AdditionalText.Select(at => new XElement("AdditionalText", at)),
            Value
        ).ToString();
    }
}

public class PressureTreatment
{
    public PressureTreatmentCompound PressureTreatmentCompound { get; set; } = new();
    public PressureTreatmentConcentration PressureTreatmentConcentration { get; set; } = new();
    public PressureTreatmentComStdorUseCategory PressureTreatmentComStdorUseCategory;
    public string Value = string.Empty;  

    public PressureTreatment() { }

    public PressureTreatment(XElement root)
    {
        PressureTreatmentCompound = root.Element("PressureTreatmentCompound") is { } ptcom ? new(ptcom) : PressureTreatmentCompound;
        PressureTreatmentConcentration = root.Element("PressureTreatmentConcentration") is { } ptcon ? new(ptcon) : PressureTreatmentConcentration;
        PressureTreatmentComStdorUseCategory = root.Element("PressureTreatmentComStdorUseCategory")?.Value.ToEnum<PressureTreatmentComStdorUseCategory>() ?? PressureTreatmentComStdorUseCategory;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("PressureTreatment",
            XElement.Parse($"{PressureTreatmentCompound}"),
            XElement.Parse($"{PressureTreatmentConcentration}"),
            new XElement("PressureTreatmentComStdorUseCategory", PressureTreatmentComStdorUseCategory.GetMemberValue()),
            Value
        ).ToString();
    }
}

public class PressureTreatmentConcentration
{
    public UOM UOM { get; set; } = UOM.Unset;
    public string Value = string.Empty;  

    public PressureTreatmentConcentration() { }

    public PressureTreatmentConcentration(XElement root)
    {
        UOM = root.Attribute("UOM") is { Value: var uom } ? uom.ToEnum<UOM>() : UOM;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("PressureTreatmentConcentration",
            UOM != UOM.Unset ? new XAttribute("UOM", UOM.GetMemberValue()) : null,
            Value
        ).ToString();
    }
}

public class PressureTreatmentCompound
{
    public string? CompoundType { get; set; } = null;
    public string? CompoundAgency { get; set; } = null;   
    public Value? Value { get; set; } = null;
    public List<string> AdditionalText { get; } = [];
    

    public PressureTreatmentCompound() { }

    public PressureTreatmentCompound(XElement root)
    {
        CompoundType = root.Attribute("CompoundType")?.Value ?? CompoundType;
        CompoundAgency = root.Attribute("CompoundAgency")?.Value ?? CompoundAgency;
        Value = root.Element("Value") is { } v ? new(v) : null;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
    }

    public override string ToString()
    {
        return new XElement("PressureTreatmentCompound",
            CompoundType != null ? new XAttribute("CompoundType", CompoundType) : null,
            CompoundAgency != null ? new XAttribute("CompoundAgency", CompoundAgency) : null,
            Value != null ? XElement.Parse($"{Value}") : null,
            AdditionalText.Select(at => new XElement("AdditionalText", at))
        ).ToString();
    }
}

public class Joining
{
    public JoiningType JoiningType { get; set; } = JoiningType.Unset;
    public List<string> AdditionalText { get; } = [];
    public string Value = string.Empty;  

    public Joining() { }

    public Joining(XElement root)
    {
        JoiningType = root.Attribute("JoiningType") is { Value: var jt } ? jt.ToEnum<JoiningType>() : JoiningType;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("Joining",
            JoiningType != JoiningType.Unset ? new XAttribute("JoiningType", JoiningType.GetMemberValue()) : null,
            AdditionalText.Select(at => new XElement("AdditionalText", at)),
            Value
        ).ToString();
    }
}

public class Trim
{
    public TrimType TrimType { get; set; } = TrimType.Unset;
    public List<string> AdditionalText { get; } = [];
    public string Value = string.Empty;  

    public Trim() { }

    public Trim(XElement root)
    {
        TrimType = root.Attribute("TrimType") is { Value: var tt } ? tt.ToEnum<TrimType>() : TrimType;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("Trim",
            TrimType != TrimType.Unset ? new XAttribute("TrimType", TrimType.GetMemberValue()) : null,
            AdditionalText.Select(at => new XElement("AdditionalText", at)),
            Value
        ).ToString();
    }
}

public class PatternProfile
{
    public PatternProfileType PatternProfileType { get; set; } = PatternProfileType.Unset;
    public PatternProfileAgency PatternProfileAgency { get; set; } = PatternProfileAgency.Unset;
    public string? PatternProfileCode { get; set; } = null;
    public List<string> AdditionalText { get; } = [];
    public string Value = string.Empty;  

    public PatternProfile() { }

    public PatternProfile(XElement root)
    {
        PatternProfileType = root.Attribute("PatternProfileType") is { Value: var ppt } ? ppt.ToEnum<PatternProfileType>() : PatternProfileType;
        PatternProfileAgency = root.Attribute("PatternProfileAgency") is { Value: var ppa } ? ppa.ToEnum<PatternProfileAgency>() : PatternProfileAgency;
        PatternProfileCode = root.Element("PatternProfileCode")?.Value ?? PatternProfileCode;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("PatternProfile",
            PatternProfileType != PatternProfileType.Unset ? new XAttribute("PatternProfileType", PatternProfileType.GetMemberValue()) : null,
            PatternProfileAgency != PatternProfileAgency.Unset ? new XAttribute("PatternProfileAgency", PatternProfileAgency.GetMemberValue()) : null,
            PatternProfileCode != null ? new XElement("PatternProfileCode", PatternProfileCode) : null,
            AdditionalText.Select(at => new XElement("AdditionalText", at))
        ).ToString();
    }
}

public class ManufacturingProcess
{
    public ManufacturingProcessType ManufacturingProcessType { get; set; } = ManufacturingProcessType.Unset;
    public ManufacturingProcessAgency ManufacturingProcessAgency { get; set; } = ManufacturingProcessAgency.Unset;
    public Value? Value { get; set; } = null;
    public List<string> AdditionalText { get; } = [];

    public ManufacturingProcess() { }

    public ManufacturingProcess(XElement root)
    {
        ManufacturingProcessType = root.Attribute("ManufacturingProcessType") is { Value: var mpt } ? mpt.ToEnum<ManufacturingProcessType>() : ManufacturingProcessType;
        ManufacturingProcessAgency = root.Attribute("ManufacturingProcessAgency") is { Value: var mpa } ? mpa.ToEnum<ManufacturingProcessAgency>() : ManufacturingProcessAgency;
        Value = root.Element("Value") is { } v ? new(v) : null;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
    }

    public override string ToString()
    {
        return new XElement("ManufacturingProcess",
            ManufacturingProcessType != ManufacturingProcessType.Unset ? new XAttribute("ManufacturingProcessType", ManufacturingProcessType.GetMemberValue()) : null,
            ManufacturingProcessAgency != ManufacturingProcessAgency.Unset ? new XAttribute("ManufacturingProcessAgency", ManufacturingProcessAgency.GetMemberValue()) : null,
            Value != null ? XElement.Parse($"{Value}") : null,
            AdditionalText.Select(at => new XElement("AdditionalText", at))
        ).ToString();
    }
}

public class HeatTreatment
{
    public HeatTreatmentType HeatTreatmentType { get; set; } = HeatTreatmentType.Unset;
    public List<string> AdditionalText { get; } = [];
    public string Value = string.Empty;  

    public HeatTreatment() { }

    public HeatTreatment(XElement root)
    {
        HeatTreatmentType = root.Attribute("HeatTreatmentType") is { Value: var htt } ? htt.ToEnum<HeatTreatmentType>() : HeatTreatmentType;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("HeatTreatment",
            HeatTreatmentType != HeatTreatmentType.Unset ? new XAttribute("HeatTreatmentType", HeatTreatmentType.GetMemberValue()) : null,
            AdditionalText.Select(at => new XElement("AdditionalText", at)),
            Value
        ).ToString();
    }
}

public class MoistureContent
{
    public MoistureContentPercentage MoistureContentPercentage { get; set; } = MoistureContentPercentage.Unset;
    public List<string> AdditionalText { get; } = [];
    public string Value = string.Empty;  

    public MoistureContent() { }

    public MoistureContent(XElement root)
    {
        MoistureContentPercentage = root.Attribute("MoistureContentPercentage") is { Value: var mcp } ? mcp.ToEnum<MoistureContentPercentage>() : MoistureContentPercentage;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("MoistureContent",
            MoistureContentPercentage != MoistureContentPercentage.Unset ? new XAttribute("MoistureContentPercentage", MoistureContentPercentage.GetMemberValue()) : null,
            AdditionalText.Select(at => new XElement("AdditionalText", at)),
            Value
        ).ToString();
    }
}

public class Seasoning
{
    public SeasoningType SeasoningType { get; set; } = SeasoningType.Unset;
    public List<string> AdditionalText { get; } = [];
    public string Value = string.Empty;  

    public Seasoning() { }

    public Seasoning(XElement root)
    {
        SeasoningType = root.Attribute("SeasoningType") is { Value: var st } ? st.ToEnum<SeasoningType>() : SeasoningType;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("Seasoning",
            SeasoningType != SeasoningType.Unset ? new XAttribute("SeasoningType", SeasoningType) : null,
            AdditionalText.Select(at => new XElement("AdditionalText", at)),
            Value
        ).ToString();
    }
}

public class Thickness : MeasurementBase
{
    public Thickness() { }

    public Thickness(XElement root) : base(root) { }

    public override string LocalName => "Thickness";
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
    public string Value = string.Empty;  

    public LumberGrade() { }

    public LumberGrade(XElement root)
    {
        GradeType = root.Attribute("GradeType") is { Value: var gt } ? gt.ToEnum<GradeType>() : GradeType;
        GradingRule = root.Attribute("GradingRule") is { Value: var gr } ? gr.ToEnum<GradingRule>() : GradingRule;
        GradeAgency = root.Attribute("GradeAgency") is { Value: var ga } ? ga.ToEnum<LumberAgency>() : GradeAgency;
        ModulusElasticity = root.Attribute("ModulusElasticity") is { Value: var me } ? me.ToEnum<ModulusElasticity>() : ModulusElasticity;
        Face = root.Attribute("Face") is { Value: var f } ? f.ToEnum<Face>() : Face;
        GradeName = root.Element("GradeName")?.Value ?? GradeName;
        GradeCode = root.Element("GradeCode")?.Value ?? GradeCode;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("LumberGrade",
            GradeType != GradeType.Unset ? new XAttribute("GradeType", GradeType) : null,
            GradingRule != GradingRule.Unset ? new XAttribute("GradingRule", GradingRule) : null,
            GradeAgency != LumberAgency.Unset ? new XAttribute("GradeAgency", GradeAgency) : null,
            ModulusElasticity != ModulusElasticity.Unset ? new XAttribute("ModulusElasticity", ModulusElasticity) : null,
            Face != Face.Unset ? new XAttribute("Face", Face) : null,
            GradeName != null ? new XElement("GradeName", GradeName) : null,
            GradeCode != null ? new XElement("GradeCode", GradeCode) : null,
            AdditionalText.Select(at => new XElement("AdditionalText", at))
        ).ToString();
    }
}

public class LumberSpecies
{
    public SpeciesType SpeciesType { get; set; } = SpeciesType.Unset;
    public SpeciesOrigin SpeciesOrigin { get; set; } = SpeciesOrigin.Unset;
    public SpeciesAgency SpeciesAgency { get; set; } = SpeciesAgency.Unset;
    public string? SpeciesCode { get; set; } = null;
    public List<string> AdditionalText { get; } = [];
    public string Value = string.Empty;  

    public LumberSpecies() { }

    public LumberSpecies(XElement root)
    {
        SpeciesType = root.Attribute("SpeciesType") is { Value: var st } ? Enum.Parse<SpeciesType>(st) : SpeciesType;
        SpeciesOrigin = root.Attribute("SpeciesOrigin") is { Value: var so } ? Enum.Parse<SpeciesOrigin>(so) : SpeciesOrigin;
        SpeciesAgency = root.Attribute("SpeciesAgency") is { Value: var sa } ? Enum.Parse<SpeciesAgency>(sa) : SpeciesAgency;
        SpeciesCode = root.Element("SpeciesCode")?.Value ?? SpeciesCode;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("LumberSpecies",
            SpeciesType != SpeciesType.Unset ? new XAttribute("SpeciesType", SpeciesType) : null,
            SpeciesOrigin != SpeciesOrigin.Unset ? new XAttribute("SpeciesOrigin", SpeciesOrigin) : null,
            SpeciesAgency != SpeciesAgency.Unset ? new XAttribute("SpeciesAgency", SpeciesAgency) : null,
            SpeciesCode != null ? new XElement("SpeciesCode", SpeciesCode) : null,
            AdditionalText.Select(at => new XElement("AdditionalText", at))
        ).ToString();
    }
}

public class BookManufacturing
{
    public List<BookClassification> BookClassification { get; } = [];
    public List<ProofInformationalQuantity> ProofInformationalQuantity { get; } = [];
    public List<PrepInformation> PrepInformation { get; } = [];
    public List<SuppliedComponentInformation> SuppliedComponentInformation { get; } = [];

    public BookManufacturing() { throw new NotImplementedException(); }

    public BookManufacturing(XElement root) { throw new NotImplementedException(); }
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
    public string Value = string.Empty;  

    public SuppliedComponentInformation() { }

    public SuppliedComponentInformation(XElement root)
    {
        SupplierParty = root.Element("SupplierParty") is { } sp ? new(sp) : SupplierParty;
        ProductIdentifier = root.Element("ProductIdentifier") is { } pi ? new(pi) : ProductIdentifier;
        ProductDescription = [.. root.Elements("ProductDescription").Select(e => new ProductDescription(e))];
        Classification = [.. root.Elements("Classification").Select(e => new Classification(e))];
        BookClassification = [.. root.Elements("BookClassification").Select(e => new BookClassification(e))];
        Paper = root.Element("Paper") is { } p ? new(p) : Paper;
        SuppliedComponentReference = root.Element("SuppliedComponentReference") is { } scr ? new(scr) : SuppliedComponentReference;
        Quantity = root.Element("Quantity") is { } q ? new(q) : Quantity;
        ComponentShipDate = root.Element("ComponentShipDate") is { } csd ? new(csd) : ComponentShipDate;
        ComponentDueDate = root.Element("ComponentDueDate") is { } cdd ? new(cdd) : ComponentDueDate;
        ComponentNeededDate = root.Element("ComponentNeededDate") is { } cnd ? new(cnd) : ComponentNeededDate;
        OrderStatusInformation = root.Element("OrderStatusInformation") is { } osi ? new(osi) : OrderStatusInformation;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("SuppliedComponentInformation",
            XElement.Parse($"{SupplierParty}"),
            XElement.Parse($"{ProductIdentifier}"),
            ProductDescription.Select(pd => XElement.Parse($"{pd}")),
            Classification.Select(c => XElement.Parse($"{c}")),
            BookClassification.Select(bc => XElement.Parse($"{bc}")),
            Paper != null ? XElement.Parse($"{Paper}") : null,
            SuppliedComponentReference != null ? XElement.Parse($"{SuppliedComponentReference}") : null,
            Quantity != null ? XElement.Parse($"{Quantity}") : null,
            ComponentShipDate != null ? XElement.Parse($"{ComponentShipDate}") : null,
            ComponentDueDate != null ? XElement.Parse($"{ComponentDueDate}") : null,
            ComponentNeededDate != null ? XElement.Parse($"{ComponentNeededDate}") : null,
            OrderStatusInformation != null ? XElement.Parse($"{OrderStatusInformation}") : null,
            AdditionalText.Select(at => new XElement("AdditionalText", at)),
            Value
        ).ToString();
    }
}

public class OrderStatusInformation
{
    public string OrderPrimaryStatus = string.Empty;
    public string? OrderSecondaryStatus { get; set; } = null;
    public string Value = string.Empty;  

    public OrderStatusInformation() { }

    public OrderStatusInformation(XElement root)
    {
        OrderPrimaryStatus = root.Element("OrderPrimaryStatus")?.Value ?? OrderPrimaryStatus;
        OrderSecondaryStatus = root.Element("OrderSecondaryStatus")?.Value ?? OrderSecondaryStatus;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("OrderStatusInformation",
            new XElement("OrderPrimaryStatus", OrderPrimaryStatus),
            OrderSecondaryStatus != null ? new XElement("OrderSecondaryStatus", OrderSecondaryStatus) : null,
            Value
        ).ToString();
    }
}

public class ComponentNeededDate : DateTimeBase
{
    public ComponentNeededDate() : base() { }

    public ComponentNeededDate(XElement root) : base(root) { }

    public override string LocalName => "ComponentNeededDate";
}

public class ComponentDueDate : DateTimeBase
{
    public ComponentDueDate() : base() { }

    public ComponentDueDate(XElement root) : base(root) { }

    public override string LocalName => "ComponentDueDate";
}

public class ComponentShipDate : DateTimeBase
{
    public ComponentShipDate() : base() { }

    public ComponentShipDate(XElement root) : base(root) { }

    public override string LocalName => "ComponentShipDate";
}

public class SuppliedComponentReference
{
    public ReferenceType SuppliedComponentReferenceType { get; set; } = ReferenceType.Unset;
    public AssignedBy AssignedBy { get; set; } = AssignedBy.Unset;
    public string Value = string.Empty;  

    public SuppliedComponentReference() { }

    public SuppliedComponentReference(XElement root)
    {
        SuppliedComponentReferenceType = root.Attribute("SuppliedComponentReferenceType") is { Value: var scrt } ? scrt.ToEnum<ReferenceType>() : SuppliedComponentReferenceType;
        AssignedBy = root.Attribute("AssignedBy") is { Value: var ab } ? ab.ToEnum<AssignedBy>() : AssignedBy;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("SuppliedComponentReference",
            SuppliedComponentReferenceType != ReferenceType.Unset ? new XAttribute("SuppliedComponentReferenceType", SuppliedComponentReferenceType.GetMemberValue()) : null,
            AssignedBy != AssignedBy.Unset ? new XAttribute("AssignedBy", AssignedBy.GetMemberValue()) : null,
            Value
        ).ToString();
    }
}

public class Paper
{
    public PaperCharacteristics? PaperCharacteristics { get; set; } = null;

    public Paper() { throw new NotImplementedException(); }

    public Paper(XElement root) { throw new NotImplementedException(); }
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
    public Burst() : base() { }

    public Burst(XElement root) : base(root) { }

    public override string LocalName => "Burst";
}

public class Bulk : DetailMeasurementBase
{
    public Bulk() : base() { }

    public Bulk(XElement root) : base(root) { }

    public override string LocalName => "Bulk";
}

public class Brightness : DetailMeasurementBase
{
    public Brightness() : base() { }

    public Brightness(XElement root) : base(root) { }

    public override string LocalName => "Brightness";
}

public class BendingStiffness : DetailMeasurementBase
{
    public BendingStiffness() : base() { }

    public BendingStiffness(XElement root) : base(root) { }

    public override string LocalName => "BendingStiffness";
}

public class BendingResistance : DetailMeasurementBase
{
    public BendingResistance() : base() { }

    public BendingResistance(XElement root) : base(root) { }

    public override string LocalName => "BendingResistance";
}

public class BasisWeight : DetailMeasurementBase
{
    public BasisWeight() : base() { }

    public BasisWeight(XElement root) : base(root) { }

    public override string LocalName => "BasisWeight";
}

public class Ash : DetailMeasurementBase
{
    public Ash() : base() { }

    public Ash(XElement root) : base(root) { }

    public override string LocalName => "Ash";
}

public class Appearance : DetailMeasurementBase
{
    public Appearance() : base() { }

    public Appearance(XElement root) : base(root) { }

    public override string LocalName => "Appearance";
}

public class AbsorptionWater : DetailMeasurementBase
{
    public AbsorptionWater() : base() { }

    public AbsorptionWater(XElement root) : base(root) { }

    public override string LocalName => "AbsorptionWater";
}

public class AbsorptionInk : DetailMeasurementBase
{
    public AbsorptionInk() : base() { }

    public AbsorptionInk(XElement root) : base(root) { }

    public override string LocalName => "AbsorptionInk";
}

public class Abrasion : DetailMeasurementBase
{
    public Abrasion() : base() { }

    public Abrasion(XElement root) : base(root) { }

    public override string LocalName => "Abrasion";
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
    public string Value = string.Empty;  

    public abstract string LocalName { get; }

    public DetailMeasurementBase() { }

    public DetailMeasurementBase(XElement root)
    {
        TestMethod = root.Attribute("TestMethod") is { Value: var tm } ? Enum.Parse<TestMethod>(tm) : TestMethod;
        TestAgency = root.Attribute("TestAgency") is { Value: var ta } ? Enum.Parse<TestAgency>(ta) : TestAgency;
        SampleType = root.Attribute("SampleType") is { Value: var st } ? Enum.Parse<SampleType>(st) : SampleType;
        ResultSource = root.Attribute("ResultSource") is { Value: var rs } ? Enum.Parse<ResultSource>(rs) : ResultSource;
        DetailValue = root.Element("DetailValue") is { } dv ? new(dv) : DetailValue;
        DetailRangeMin = root.Element("DetailRangeMin") is { } drmin ? new(drmin) : DetailRangeMin;
        DetailRangeMax = root.Element("DetailRangeMax") is { } drmax ? new(drmax) : DetailRangeMax;
        StandardDeviation = root.Element("StandardDeviation") is { } sd ? new(sd) : StandardDeviation;
        SampleSize = root.Element("SampleSize") is { } ss ? new(ss) : SampleSize;
        TwoSigmaLower = root.Element("TwoSigmaLower") is { } tsl ? new(tsl) : TwoSigmaLower;
        TwoSigmaUpper = root.Element("TwoSigmaUpper") is { } tsu ? new(tsu) : TwoSigmaUpper;
        IncrementalValue = root.Element("IncrementalValue") is { } iv ? new(iv) : IncrementalValue;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement(LocalName,
            TestMethod != TestMethod.Unset ? new XAttribute("TestMethod", TestMethod) : null,
            TestAgency != TestAgency.Unset ? new XAttribute("TestAgency", TestAgency) : null,
            SampleType != SampleType.Unset ? new XAttribute("SampleType", SampleType) : null,
            ResultSource != ResultSource.Unset ? new XAttribute("ResultSource", ResultSource) : null,
            XElement.Parse($"{DetailValue}"),
            DetailRangeMin != null ? XElement.Parse($"{DetailRangeMin}") : null,
            DetailRangeMax != null ? XElement.Parse($"{DetailRangeMax}") : null,
            StandardDeviation != null ? XElement.Parse($"{StandardDeviation}") : null,
            SampleSize != null ? XElement.Parse($"{SampleSize}") : null,
            TwoSigmaLower != null ? XElement.Parse($"{TwoSigmaLower}") : null,
            TwoSigmaUpper != null ? XElement.Parse($"{TwoSigmaUpper}") : null,
            IncrementalValue != null ? XElement.Parse($"{IncrementalValue}") : null,
            Value
        ).ToString();
    }
}

public class IncrementalValue : ValueBase
{
    public IncrementalValue() : base() { }

    public IncrementalValue(XElement root) : base(root) { }

    public override string LocalName => throw new NotImplementedException();
}

public class TwoSigmaUpper : ValueBase
{
    public TwoSigmaUpper() : base() { }

    public TwoSigmaUpper(XElement root) : base(root) { }

    public override string LocalName => "TwoSigmaUpper";
}

public class TwoSigmaLower : ValueBase
{
    public TwoSigmaLower() : base() { }

    public TwoSigmaLower(XElement root) : base(root) { }

    public override string LocalName => "TwoSigmaLower";
}

public class SampleSize
{
    public string Value = string.Empty;  

    public SampleSize() { }

    public SampleSize(XElement root)
    {
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("SampleSize", Value).ToString();
    }
}

public class StandardDeviation : ValueBase
{
    public StandardDeviation() : base() { }

    public StandardDeviation(XElement root) : base(root) { }

    public override string LocalName => throw new NotImplementedException();
}

public class DetailRangeMax : ValueBase
{
    public DetailRangeMax() : base() { }

    public DetailRangeMax(XElement root) : base(root) { }

    public override string LocalName => "DetailRangeMax";
}

public class DetailRangeMin : ValueBase
{
    public DetailRangeMin() : base() { }

    public DetailRangeMin(XElement root) : base(root) { }

    public override string LocalName => "DetailRangeMin";
}

public class DetailValue : ValueBase
{
    public DetailValue() : base() { }

    public DetailValue(XElement root) : base(root) { }

    public override string LocalName => "DetailValue";
}

public class ProductDescription
{
    public Language Language { get; set; } = Language.Unset;
    public string Value = string.Empty;  

    public ProductDescription() { }

    public ProductDescription(XElement root)
    {
        Language = root.Element("Language") is { Value: var l } ? Enum.Parse<Language>(l) : Language;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("ProductDescription",
            Language != Language.Unset ? new XAttribute("Language", Language) : null,
            Value
        ).ToString();
    }
}

public class ProductIdentifier
{
    public Agency Agency = Agency.Other;
    public ProductIdentifierType ProductIdentifierType = ProductIdentifierType.Other;
    public string Value = string.Empty;  

    public ProductIdentifier() { }

    public ProductIdentifier(XElement root)
    {
        Agency = root.Attribute("Agency") is { Value: var a } ? Enum.Parse<Agency>(a) : Agency;
        ProductIdentifierType = root.Attribute("ProductIdentifierType") is { Value: var pit } ? Enum.Parse<ProductIdentifierType>(pit) : ProductIdentifierType;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("ProductIdentifier",
            new XAttribute("Agency", Agency),
            new XAttribute("ProductIdentifierType", ProductIdentifierType),
            Value
        ).ToString();
    }
}

public class PrepInformation
{
    public PrepType PrepType { get; set; } = PrepType.Unset;
    public SupplierParty SupplierParty { get; set; } = new();
    public PrepShipDate? PrepShipDate { get; set; } = null;
    public PrepDueDate? PrepDueDate { get; set; } = null;
    public PrepNeededDate? PrepNeededDate { get; set; } = null;
    public List<string> AdditionalText { get; } = [];
    public string Value = string.Empty;  

    public PrepInformation() { }

    public PrepInformation(XElement root)
    {
        PrepType = root.Element("PrepType") is { Value: var pt } ? Enum.Parse<PrepType>(pt) : PrepType;
        SupplierParty = root.Element("SupplierParty") is { } sp ? new(sp) : SupplierParty;
        PrepShipDate = root.Element("PrepShipDate") is { } psd ? new(psd) : PrepShipDate;
        PrepDueDate = root.Element("PrepDueDate") is { } pdd ? new(pdd) : PrepDueDate;
        PrepNeededDate = root.Element("PrepNeededDate") is { } pnd ? new(pnd) : PrepNeededDate;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
    }

    public override string ToString()
    {
        return new XElement("PrepInformation",
            PrepType != PrepType.Unset ? new XAttribute("PrepType", PrepType) : null,
            XElement.Parse($"{SupplierParty}"),
            PrepShipDate != null ? XElement.Parse($"{PrepShipDate}") : null,
            PrepDueDate != null ? XElement.Parse($"{PrepDueDate}") : null,
            PrepNeededDate != null ? XElement.Parse($"{PrepNeededDate}") : null,
            AdditionalText.Select(at => new XElement("AdditionalText", at)),
            Value
        ).ToString();
    }
}

public class PrepNeededDate : DateTimeBase
{
    public override string LocalName => "PrepNeededDate";
    public PrepNeededDate() { }
    public PrepNeededDate(XElement root) : base(root) { }
}

public class PrepDueDate : DateTimeBase
{
    public override string LocalName => "PrepDueDate";
    public PrepDueDate() { }
    public PrepDueDate(XElement root) : base(root) { }
}

public class PrepShipDate : DateTimeBase 
{ 
    public override string LocalName => "PrepShipDate";
    public PrepShipDate() { }
    public PrepShipDate(XElement root) : base(root) { }
}

public abstract class DateTimeBase
{
    public Date Date { get; set; } = new();
    public Time? Time { get; set; } = null;
    public string Value = string.Empty;  

    public abstract string LocalName { get; }

    public DateTimeBase() { }

    public DateTimeBase(XElement root)
    {
        Date = root.Element("Date") is { } d ? new(d) : Date;
        Time = root.Element("Time") is { } t ? new(t) : Time;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement(LocalName,
            XElement.Parse($"{Date}"),
            Time != null ? XElement.Parse($"{Time}") : null
        ).ToString();
    }
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
    public string Value = string.Empty;  

    public ProofInformationalQuantity() { }

    public ProofInformationalQuantity(XElement root)
    {
        ProofType = root.Attribute("ProofType") is { Value: var pt } ? Enum.Parse<ProofType>(pt) : ProofType;
        Quantity = root.Element("Quantity") is { } q ? new(q) : Quantity;
        InformationalQuantity = [.. root.Elements("InformationalQuantity").Select(iq => new InformationalQuantity(iq))];
        OtherParty = root.Element("OtherParty") is { } op ? new(op) : OtherParty;
        ProofApprovalDate = root.Element("ProofApprovalDate") is { } pad ? new(pad) : ProofApprovalDate;
        ProofDueDate = root.Element("ProofDueDate") is { } pdd ? new(pdd) : ProofDueDate;
        AdditionalText = [.. root.Elements("AdditionalText").Select(at => at.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("ProofInformationalQuantity",
            ProofType != ProofType.Unset ? new XAttribute("ProofType", ProofType) : null,
            XElement.Parse($"{Quantity}"),
            InformationalQuantity.Select(iq => XElement.Parse($"{iq}")),
            OtherParty != null ? XElement.Parse($"{OtherParty}") : null,
            ProofApprovalDate != null ? XElement.Parse($"{ProofApprovalDate}") : null,
            ProofDueDate != null ? XElement.Parse($"{ProofDueDate}") : null,
            AdditionalText.Select(at => new XElement("AdditionalText", at)),
            Value
        ).ToString();
    }
}

public class ProofDueDate : DateTimeBase
{
    public override string LocalName => "ProofDueDate";
    public ProofDueDate() { }
    public ProofDueDate(XElement root) : base(root) { }
}

public class ProofApprovalDate : DateTimeBase
{
    public override string LocalName => "ProofApprovalDate";
    public ProofApprovalDate() { }
    public ProofApprovalDate(XElement root) : base(root) { }
}

public class BookClassification
{
    public BookClassificationType BookClassificationType = BookClassificationType.Assembly;
    public List<string> ClassificationDescription { get; } = [];
    public List<BookSubClassification> BookSubClassification { get; } = [];
    public string Value = string.Empty;  

    public BookClassification() { }

    public BookClassification(XElement root)
    {
        BookClassificationType = root.Attribute("BookClassificationType") is { Value: var bct } ? Enum.Parse<BookClassificationType>(bct) : BookClassificationType;
        ClassificationDescription = [.. root.Elements("ClassificationDescription").Select(cd => cd.Value)];
        BookSubClassification = [.. root.Elements("BookSubClassification").Select(bsc => new BookSubClassification(bsc))];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("BookClassification",
            new XAttribute("BookClassificationType", BookClassificationType),
            ClassificationDescription.Select(cd => new XElement("ClassificationDescription", cd)),
            BookSubClassification.Select(bsc => XElement.Parse($"{bsc}")),
            Value
        ).ToString();
    }
}

public class BookSubClassification
{
    public BookSubClassificationType BookSubClassificationType;
    public List<string> ClassificationDescription { get; } = [];
    public string Value = string.Empty;  

    public BookSubClassification() { }

    public BookSubClassification(XElement root)
    {
        BookSubClassificationType = root.Attribute("BookSubClassificationType") is { Value: var bsct } ? Enum.Parse<BookSubClassificationType>(bsct) : BookSubClassificationType;
        ClassificationDescription = [.. root.Elements("ClassificationDescription").Select(cd => cd.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("BookSubClassification",
            new XAttribute("BookSubClassificationType", BookSubClassificationType),
            ClassificationDescription.Select(cd => new XElement("ClassificationDescription", cd)),
            Value
        ).ToString();
    }
}

public class Classification
{
    public string ClassificationCode = string.Empty;
    public string? ClassificationDescription = string.Empty;
    public string Value = string.Empty;  

    public Classification() { }

    public Classification(XElement root)
    {
        ClassificationCode = root.Element("ClassificationCode")?.Value ?? ClassificationCode;
        ClassificationDescription = root.Element("ClassificationDescription")?.Value ?? ClassificationDescription;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("Classification",
            new XElement("ClassificationCode", ClassificationCode),
            ClassificationDescription != null ? new XElement("ClassificationDescription", ClassificationDescription) : null,
            Value
        ).ToString();
    }
}

public class SafetyAndEnvironmentalInformation
{
    public SafetyAndEnvironmentalType SafetyAndEnvironmentalType { get; set; } = SafetyAndEnvironmentalType.MaterialSafetyData;
    public Agency Agency { get; set; } = Agency.Other;
    public string? LicenceNumber { get; set; } = null;
    public string? ChainOfCustody { get; set; } = null;
    public SafetyAndEnvironmentalCertification? SafetyAndEnvironmentalCertification { get; set; } = null;
    public List<string> AdditionalText { get; } = [];
    public string Value = string.Empty;  

    public SafetyAndEnvironmentalInformation() { }

    public SafetyAndEnvironmentalInformation(XElement root)
    {
        SafetyAndEnvironmentalType = root.Attribute("SafetyAndEnvironmentalType") is { Value: var saet } ? Enum.Parse<SafetyAndEnvironmentalType>(saet) : SafetyAndEnvironmentalType;
        Agency = root.Attribute("Agency") is { Value: var a } ? Enum.Parse<Agency>(a) : Agency;
        LicenceNumber = root.Element("LicenceNumber")?.Value ?? LicenceNumber;
        ChainOfCustody = root.Element("ChainOfCustody")?.Value ?? ChainOfCustody;
        SafetyAndEnvironmentalCertification = root.Element("SafetyAndEnvironmentalCertification") is { } saec ? new(saec) : SafetyAndEnvironmentalCertification;
        AdditionalText = [.. root.Elements("AdditionalText").Select(at => at.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("SafetyAndEnvironmentalInformation",
            new XAttribute("SafetyAndEnvironmentalType", SafetyAndEnvironmentalType),
            new XAttribute("Agency", Agency),
            LicenceNumber != null ? new XElement("LicenceNumber", LicenceNumber) : null,
            ChainOfCustody != null ? new XElement("ChainOfCustody", ChainOfCustody) : null,
            SafetyAndEnvironmentalCertification != null ? XElement.Parse($"{SafetyAndEnvironmentalCertification}") : null,
            AdditionalText.Select(at => new XElement("AdditionalText", at)),
            Value
        ).ToString();
    }
}

public class SafetyAndEnvironmentalCertification : MeasurementBase
{
    public SafetyAndEnvironmentalCertification() : base() { }

    public SafetyAndEnvironmentalCertification(XElement root) : base(root) { }

    public override string LocalName => "SafetyAndEnvironmentalCertification";
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
    public string Value = string.Empty;  

    public TransportLoadingCharacteristics() { }

    public TransportLoadingCharacteristics(XElement root)
    {
        MixProductIndicator = root.Attribute("MixProductIndicator") is { Value: var mpi } ? Enum.Parse<MixProductIndicator>(mpi) : MixProductIndicator;
        TransportLoadingType = root.Attribute("TransportLoadingType") is { Value: var tlp } ? Enum.Parse<TransportLoadingType>(tlp) : TransportLoadingType;
        TransportDeckOption = root.Attribute("TransportDeckOption") is { Value: var tdo } ? Enum.Parse<TransportDeckOption>(tdo) : TransportDeckOption;
        LoadingTolerance = root.Attribute("LoadingTolerance") is { Value: var lt } ? Enum.Parse<LoadingTolerance>(lt) : LoadingTolerance;
        DirectLoading = root.Attribute("DirectLoading") is { Value: var dl } ? Enum.Parse<DirectLoading>(dl) : DirectLoading;
        GoodsLoadingPrinciple = root.Attribute("GoodsLoadingPrinciple") is { Value: var glp } ? Enum.Parse<GoodsLoadingPrinciple>(glp) : GoodsLoadingPrinciple;
        LabelOrientation = root.Attribute("LabelOrientation") is { Value: var lo } ? Enum.Parse<LabelOrientation>(lo) : LabelOrientation;
        TransportLoadingCode = root.Element("TransportLoadingCode")?.Value ?? TransportLoadingCode;
        TransportLoadingCodeDescription = root.Element("TransportLoadingCodeDescription") is { } tlcd ? new(tlcd) : TransportLoadingCodeDescription;
        TransportLoadingText = [.. root.Elements("TransportLoadingText").Select(tlt => tlt.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportLoadingCharacteristics",
            MixProductIndicator != null ? new XAttribute("MixProductIndicator", MixProductIndicator) : null,
            TransportLoadingType != null ? new XAttribute("TransportLoadingType", TransportLoadingType) : null,
            TransportDeckOption != null ? new XAttribute("TransportDeckOption", TransportDeckOption) : null,
            LoadingTolerance != null ? new XAttribute("LoadingTolerance", LoadingTolerance) : null,
            DirectLoading != null ? new XAttribute("DirectLoading", DirectLoading) : null,
            GoodsLoadingPrinciple != null ? new XAttribute("GoodsLoadingPrinciple", GoodsLoadingPrinciple) : null,
            LabelOrientation != null ? new XAttribute("LabelOrientation", LabelOrientation) : null,
            TransportLoadingCode != null ? new XElement("TransportLoadingCode", TransportLoadingCode) : null,
            TransportLoadingCodeDescription != null ? XElement.Parse($"{TransportLoadingCodeDescription}") : null,
            TransportLoadingText.Select(tlt => new XElement("TransportLoadingText", tlt)),
            Value
        ).ToString();
    }
}

public class TransportLoadingCodeDescription
{
    public List<string> AdditionalText { get; } = [];
    public e_Attachment? e_Attachment { get; set; } = null;
    public string Value = string.Empty;  

    public TransportLoadingCodeDescription() { }

    public TransportLoadingCodeDescription(XElement root)
    {
        AdditionalText = [.. root.Elements("AdditionalText").Select(t => t.Value)];
        e_Attachment = root.Element("e-Attachment") is { } a ? new(a) : e_Attachment;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportLoadingCodeDescription",
            AdditionalText.Select(t => new XElement("AdditionalText", t)),
            e_Attachment != null ? XElement.Parse($"{e_Attachment}") : null,
            Value
        ).ToString();
    }
}

public class QuantityOrderedInformation
{
    public Quantity Quantity { get; set; } = new();
    public List<InformationalQuantity> InformationalQuantity { get; } = [];
    public List<string> AdditionalText { get; } = [];
    public List<Length> Length { get; } = [];
    public string Value = string.Empty;  

    public QuantityOrderedInformation() { }

    public QuantityOrderedInformation(XElement root)
    {
        Quantity = root.Element("Quantity") is { } q ? new(q) : Quantity;
        InformationalQuantity = [.. root.Elements("InformationalQuantity").Select(iq => new InformationalQuantity(iq))];
        AdditionalText = [.. root.Elements("AdditionalText").Select(t => t.Value)];
        Length = [.. root.Elements("Length").Select(l => new Length(l))];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("QuantityOrderedInformation",
            Quantity != null ? XElement.Parse($"{Quantity}") : null,
            InformationalQuantity.Select(iq => XElement.Parse($"{iq}")),
            AdditionalText.Select(t => new XElement("AdditionalText", t)),
            Length.Select(l => XElement.Parse($"{l}")),
            Value
        ).ToString();
    }
}

public class MillProductionInformation
{
    public MillCharacteristics? MillCharacteristics { get; set; } = null;
    public string? MillOrderNumber { get; set; } = null;
    public Quantity? Quantity { get; set; } = null;
    public string Value = string.Empty;  

    public MillProductionInformation() { }

    public MillProductionInformation(XElement root)
    {
        MillCharacteristics = root.Element("MillCharacteristics") is { } c ? new(c) : MillCharacteristics;
        MillOrderNumber = root.Element("MillOrderNumber")?.Value ?? MillOrderNumber;
        Quantity = root.Element("Quantity") is { } q ? new(q) : Quantity;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("MillProductionInformation",
            MillCharacteristics != null ? XElement.Parse($"{MillCharacteristics}") : null,
            MillOrderNumber != null ? new XElement("MillOrderNumber", MillOrderNumber) : null,
            Quantity != null ? XElement.Parse($"{Quantity}") : null,
            Value
        ).ToString();
    }
}

public class MillCharacteristics
{
    public MillParty? MillParty { get; set; } = null;
    public string? MachineID { get; set; } = null;
    public string Value = string.Empty;  

    public MillCharacteristics() { }

    public MillCharacteristics(XElement root)
    {
        MillParty = root.Element("MillParty") is { } party ? new(party) : MillParty;
        MachineID = root.Element("MachineID")?.Value ?? MachineID;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("MillCharacteristics",
            MillParty != null ? XElement.Parse($"{MillParty}") : null,
            MachineID != null ? new XElement("MachineID", MachineID) : null,
            Value
        ).ToString();
    }
}

public abstract class MeasurementBase
{
    public ActualNominal ActualNominal { get; set; } = ActualNominal.Unset;
    public WithGrain WithGrain { get; set; } = WithGrain.Unset;
    public Value Value { get; set; } = new();
    public RangeMin? RangeMin { get; set; } = null;
    public RangeMax? RangeMax { get; set; } = null;
    public List<string> AdditionalText { get; } = [];

    public abstract string LocalName { get; }

    public MeasurementBase() { }

    public MeasurementBase(XElement root)
    {
        ActualNominal = root.Attribute("ActualNominal") is { Value: var an } ? an.ToEnum<ActualNominal>() : ActualNominal;
        WithGrain = root.Attribute("WithGrain") is { Value: var wg } ? wg.ToEnum<WithGrain>() : WithGrain;
        Value = root.Element("Value") is { } value ? new(value) : Value;
        RangeMin = root.Element("RangeMin") is { } min ? new(min) : RangeMin;
        RangeMax = root.Element("RangeMax") is { } max ? new(max) : RangeMax;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
    }

    public override string ToString()
    {
        return new XElement(LocalName,
            ActualNominal != ActualNominal.Unset ? new XAttribute("ActualNominal", ActualNominal) : null,
            WithGrain != WithGrain.Unset ? new XAttribute("WithGrain", WithGrain) : null,
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null,
            AdditionalText.Select(at => new XElement("AdditionalText", at))
        ).ToString();
    }
}

public class TotalNumberOfUnits : MeasurementBase
{
    public override string LocalName => "TotalNumberOfUnits";
    public TotalNumberOfUnits() { }
    public TotalNumberOfUnits(XElement root) : base(root) { }
}

public class PurchaseOrderInformation
{
    public string? PurchaseOrderNumber { get; set; } = null;
    public string? PurchaseOrderReleaseNumber { get; set; } = null;
    public PurchaseOrderIssuedDate? PurchaseOrderIssuedDate { get; set; } = null;
    public List<PurchaseOrderReference> PurchaseOrderReference { get; } = [];
    public string Value = string.Empty;  

    public PurchaseOrderInformation() { }

    public PurchaseOrderInformation(XElement root)
    {
        PurchaseOrderNumber = root.Element("PurchaseOrderNumber")?.Value ?? PurchaseOrderNumber;
        PurchaseOrderReleaseNumber = root.Element("PurchaseOrderReleaseNumber")?.Value ?? PurchaseOrderReleaseNumber;
        PurchaseOrderIssuedDate = root.Element("PurchaseOrderIssuedDate") is { } e ? new(e) : PurchaseOrderIssuedDate;
        PurchaseOrderReference = [.. root.Elements("PurchaseOrderReference").Select(e => new PurchaseOrderReference(e))];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("PurchaseOrderInformation",
            PurchaseOrderNumber != null ? new XElement("PurchaseOrderNumber", PurchaseOrderNumber) : null,
            PurchaseOrderReleaseNumber != null ? new XElement("PurchaseOrderReleaseNumber", PurchaseOrderReleaseNumber) : null,
            PurchaseOrderIssuedDate != null ? XElement.Parse($"{PurchaseOrderIssuedDate}") : null,
            PurchaseOrderReference.Select(obj => XElement.Parse($"{obj}"))
        ).ToString();
    }
}

public class PurchaseOrderReference : AssignedByReferenceValueBase
{
    public ReferenceType PurchaseOrderReferenceType = ReferenceType.Other;

    public PurchaseOrderReference() : base() { }

    public PurchaseOrderReference(XElement root) : base(root)
    {
        PurchaseOrderReferenceType = root.Attribute("PurchaseOrderReferenceType") is { Value: var v } ? Enum.Parse<ReferenceType>(v) : PurchaseOrderReferenceType;
    }

    public override string LocalName => "PurchaseOrderReference";

    public override string ToString()
    {
        return new XElement(LocalName,
            new XAttribute("PurchaseOrderReferenceType", PurchaseOrderReferenceType.GetMemberValue()),
            AssignedBy != null ? new XAttribute("AssignedBy", AssignedBy) : null,
            Value
        ).ToString();
    }
}

public class PurchaseOrderIssuedDate : DateTimeBase
{
    public override string LocalName => "PurchaseOrderIssuedDate";
    public PurchaseOrderIssuedDate() { }
    public PurchaseOrderIssuedDate(XElement root) : base(root) { }
}

public class DeliveryMessageWoodHeader
{
    private readonly ILogger<DeliveryMessageWood>? _logger;

    public string DeliveryMessageNumber = string.Empty;
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
    public string Value = string.Empty;  

    public DeliveryMessageWoodHeader() { }

    public DeliveryMessageWoodHeader(XElement root, ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;
        DeliveryMessageNumber = root.Element("DeliveryMessageNumber")?.Value ?? DeliveryMessageNumber;
        TransactionHistoryNumber = root.Element("TransactionHistoryNumber")?.Value ?? TransactionHistoryNumber;
        DeliveryMessageDate = root.Element("DeliveryMessageDate") is { } dmd ? new(dmd) : DeliveryMessageDate;
        DeliveryMessageReference = [.. root.Elements("DeliveryMessageReference").Select(e => new DeliveryMessageReference(e))];
        DocumentReferenceInformation = [.. root.Elements("DocumentReferenceInformation").Select(e => new DocumentReferenceInformation(e))];
        BuyerParty = root.Element("BuyerParty") is { } bp ? new(bp) : BuyerParty;
        BillToParty = root.Element("BillToParty") is { } btp ? new(btp) : BillToParty;
        SupplierParty = root.Element("SupplierParty") is { } supa ? new(supa) : SupplierParty;
        OtherParty = [.. root.Elements("OtherParty").Select(e => new OtherParty(e))];
        SenderParty = root.Element("SenderParty") is { } sepa ? new(sepa) : SenderParty;
        ReceiverParty = [.. root.Elements("ReceiverParty").Select(e => new ReceiverParty(e))];
        ShipToInformation = [.. root.Elements("ShipToInformation").Select(e => new ShipToInformation(e))];
        CountryOfOrigin = root.Element("CountryOfOrigin") is { } coo ? new(coo) : CountryOfOrigin;
        CountryOfDestination = root.Element("CountryOfDestination") is { } cod ? new(cod) : CountryOfDestination;
        CountryOfConsumption = root.Element("CountryOfConsumption") is { } coc ? new(coc) : CountryOfConsumption;
        Insurance = root.Element("Insurance") is { } i ? new(i) : Insurance;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        DocumentInformation = [.. root.Elements("DocumentInformation").Select(e => new DocumentInformation(e))];
        Value = root.Value;

        _logger?.LogInformation("New delivery message header has been added.");
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
            BillToParty != null ? XElement.Parse($"{BillToParty}") : null,
            XElement.Parse($"{SupplierParty}"),
            OtherParty.Select(party => XElement.Parse($"{party}")),
            SenderParty != null ? XElement.Parse($"{SenderParty}") : null,
            ReceiverParty.Select(obj => XElement.Parse($"{obj}")),
            ShipToInformation.Select(information => XElement.Parse($"{information}")),
            CountryOfOrigin != null ? XElement.Parse($"{CountryOfOrigin}") : null,
            CountryOfDestination != null ? XElement.Parse($"{CountryOfDestination}") : null,
            CountryOfConsumption != null ? XElement.Parse($"{CountryOfConsumption}") : null,
            Insurance != null ? XElement.Parse($"{Insurance}") : null,
            AdditionalText.Select(text => new XElement("AdditionalText", text)),
            DocumentInformation.Select(information => XElement.Parse($"{information}"))
        ).ToString();
    }
}

public class ReceiverParty : Party
{
    public ReceiverParty() : base() { }

    public ReceiverParty(XElement root) : base(root) { }

    public override string LocalName => "ReceiverParty";
}

public class SenderParty : Party
{
    public SenderParty() : base() { }

    public SenderParty(XElement root) : base(root) { }

    public override string LocalName => "SenderParty";
}

public class SupplierParty : Party
{
    public SupplierParty() : base() { }

    public SupplierParty(XElement root) : base(root) { }

    public override string LocalName => "SupplierParty";
}

public class BillToParty : Party
{
    public BillToParty() : base() { }

    public BillToParty(XElement root) : base(root) { }

    public override string LocalName => "BillToParty";
}

public class BuyerParty : Party
{
    public BuyerParty() : base() { }

    public BuyerParty(XElement root) : base(root) { }

    public override string LocalName => "BuyerParty";
}

public class DocumentInformation
{
    public DocumentType DocumentType = DocumentType.DeliveryNote;
    public List<string> NumberOfDocuments { get; } = [];
    public List<string> AdditionalText { get; } = [];
    public string Value = string.Empty;  

    public DocumentInformation() { }

    public DocumentInformation(XElement root)
    {
        DocumentType = root.Attribute("DocumentType") is { Value: var dt } ? Enum.Parse<DocumentType>(dt) : DocumentType;
        NumberOfDocuments = [.. root.Elements("NumberOfDocuments").Select(e => e.Value)];
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("DocumentInformation",
            new XAttribute("DocumentType", DocumentType),
            NumberOfDocuments.Select(number => new XElement("NumberOfDocuments", number)),
            AdditionalText.Select(text => new XElement("AdditionalText", text)),
            Value
        ).ToString();
    }
}

public class Insurance
{
    public string? Insurer { get; set; } = null;
    public string? InsuranceContractNo { get; set; } = null;
    public InsuredValue? InsuredValue { get; set; } = null;
    public string? InsuranceInfo { get; set; } = null;
    public string Value = string.Empty;  

    public Insurance() { }

    public Insurance(XElement root)
    {
        Insurer = root.Element("Insurer")?.Value ?? Insurer;
        InsuranceContractNo = root.Element("InsuranceContractNo")?.Value ?? InsuranceContractNo;
        InsuredValue = root.Element("InsuredValue") is { } iv ? new(iv) : InsuredValue;
        InsuranceInfo = root.Element("InsuranceInfo")?.Value ?? InsuranceInfo;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("Insurance",
            Insurer != null ? new XElement("Insurer", Insurer) : null,
            InsuranceContractNo != null ? new XElement("InsuranceContractNo", InsuranceContractNo) : null,
            InsuredValue != null ? XElement.Parse($"{InsuredValue}") : null,
            InsuranceInfo != null ? new XElement("InsuranceInfo", InsuranceInfo) : null,
            Value
        ).ToString();
    }
}

public class InsuredValue
{
    public string CurrencyValue = string.Empty;
    public string Value = string.Empty;  

    public InsuredValue() { }

    public InsuredValue(XElement root)
    {
        CurrencyValue = root.Element("CurrencyValue")?.Value ?? CurrencyValue;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("InsuredValue",
            new XElement("CurrencyValue", CurrencyValue),
            Value
        ).ToString();
    }
}

public class CountryOfConsumption
{
    public string Country = string.Empty;
    public ISOCountryCode ISOCountryCode { get; set; } = ISOCountryCode.Unset;
    public string Value = string.Empty;  

    public CountryOfConsumption() { }

    public CountryOfConsumption(XElement root)
    {
        Country = root.Element("Country")?.Value ?? Country;
        ISOCountryCode = root.Attribute("ISOCountryCode") is { Value: var isocc } ? Enum.Parse<ISOCountryCode>(isocc) : ISOCountryCode;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("CountryOfConsumption",
            ISOCountryCode != ISOCountryCode.Unset ? new XAttribute("ISOCountryCode", ISOCountryCode) : null,
            new XElement("Country", Country)
        ).ToString();
    }
}

public class CountryOfDestination
{
    public string Country = string.Empty;
    public ISOCountryCode ISOCountryCode { get; set; } = ISOCountryCode.Unset;
    public string Value = string.Empty;  

    public CountryOfDestination() { }

    public CountryOfDestination(XElement root)
    {
        Country = root.Element("Country")?.Value ?? Country;
        ISOCountryCode = root.Attribute("ISOCountryCode") is { Value: var isocc } ? Enum.Parse<ISOCountryCode>(isocc) : ISOCountryCode;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("CountryOfDestination",
            ISOCountryCode != ISOCountryCode.Unset ? new XAttribute("ISOCountryCode", ISOCountryCode) : null,
            new XElement("Country", Country)
        ).ToString();
    }
}

public class CountryOfOrigin
{
    public string Country = string.Empty;
    public ISOCountryCode ISOCountryCode { get; set; } = ISOCountryCode.Unset;
    public string Value = string.Empty;  

    public CountryOfOrigin() { }

    public CountryOfOrigin(XElement root)
    {
        Country = root.Element("Country")?.Value ?? Country;
        ISOCountryCode = root.Attribute("ISOCountryCode") is { Value: var isocc } ? Enum.Parse<ISOCountryCode>(isocc) : ISOCountryCode;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("CountryOfOrigin",
            ISOCountryCode != ISOCountryCode.Unset ? new XAttribute("ISOCountryCode", ISOCountryCode) : null,
            new XElement("Country", Country)
        ).ToString();
    }
}

public class ShipToInformation
{
    public ShipToCharacteristics ShipToCharacteristics { get; set; } = new();
    public List<DeliverySchedule> DeliverySchedule { get; } = [];
    public string Value = string.Empty;  

    public ShipToInformation() { }

    public ShipToInformation(XElement root)
    {
        ShipToCharacteristics = root.Element("ShipToCharacteristics") is { } stc ? new(stc) : ShipToCharacteristics;
        DeliverySchedule = [.. root.Elements("DeliverySchedule").Select(e => new DeliverySchedule(e))];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("ShipToInformation",
            XElement.Parse($"{ShipToCharacteristics}"),
            DeliverySchedule.Select(schedule => XElement.Parse($"{schedule}"))
        ).ToString();
    }
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
    public string Value = string.Empty;  

    public DeliverySchedule() { }

    public DeliverySchedule(XElement root)
    {
        DeliveryLineNumber = root.Element("DeliveryLineNumber")?.Value ?? DeliveryLineNumber;
        ProductionStatus = root.Element("ProductionStatus") is { } ps ? new(ps) : ProductionStatus;
        DeliveryStatus = root.Element("DeliveryStatus") is { } ds ? new(ds) : DeliveryStatus;
        DeliveryDateWindow = [.. root.Elements("DeliveryDateWindow").Select(e => new DeliveryDateWindow(e))];
        Quantity = root.Element("Quantity") is { } q ? new(q) : Quantity;
        InformationalQuantity = [.. root.Elements("InformationalQuantity").Select(e => new InformationalQuantity(e))];
        PriceDetails = root.Element("PriceDetails") is { } pd ? new(pd) : PriceDetails;
        MonetaryAdjustment = [.. root.Elements("MonetaryAdjustment").Select(e => new MonetaryAdjustment(e))];
        DeliveryLeg = [.. root.Elements("DeliveryLeg").Select(e => new DeliveryLeg(e))];
        DeliveryScheduleReference = [.. root.Elements("DeliveryScheduleReference").Select(e => new DeliveryScheduleReference(e))];
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
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
            AdditionalText.Select(text => new XElement("AdditionalText", text))
        ).ToString();
    }
}

public class DeliveryScheduleReference : AssignedByReferenceValueBase
{
    public ReferenceType DeliveryScheduleReferenceType { get; set; } = ReferenceType.Other;

    public DeliveryScheduleReference() : base() { }

    public DeliveryScheduleReference(XElement root) : base(root)
    {
        DeliveryScheduleReferenceType = root.Attribute("DeliveryScheduleReferenceType") is { Value: var dsrt } ? Enum.Parse<ReferenceType>(dsrt) : DeliveryScheduleReferenceType;
    }

    public override string LocalName => "DeliveryScheduleReference";

    public override string ToString()
    {
        return new XElement(LocalName,
            new XAttribute("DeliveryScheduleReferenceType", DeliveryScheduleReferenceType.GetMemberValue()),
            AssignedBy != null ? new XAttribute("AssignedBy", AssignedBy) : null,
            Value
        ).ToString();
    }
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
    public string Value = string.Empty;  

    public DeliveryLeg() { }

    public DeliveryLeg(XElement root)
    {
        DeliveryModeType = root.Attribute("DeliveryModeType") is { Value: var dmt } ? Enum.Parse<DeliveryModeType>(dmt) : DeliveryModeType;
        DeliveryLegType = root.Attribute("DeliveryLegType") is { Value: var dlt } ? Enum.Parse<DeliveryLegType>(dlt) : DeliveryLegType;
        EventType = root.Attribute("EventType") is { Value: var et } ? Enum.Parse<EventType>(et) : EventType;
        LegStageType = root.Attribute("LegStageType") is { Value: var lst } ? Enum.Parse<LegStageType>(lst) : LegStageType;
        DeliveryLegSequenceNumber = root.Element("DeliveryLegSequenceNumber")?.Value ?? DeliveryLegSequenceNumber;
        DeliveryOrigin = root.Element("DeliveryOrigin") is { } deo ? new(deo) : DeliveryOrigin;
        CarrierParty = root.Element("CarrierParty") is { } cp ? new(cp) : CarrierParty;
        OtherParty = [.. root.Elements("OtherParty").Select(e => new OtherParty(e))];
        TransportModeCharacteristics = root.Element("TransportModeCharacteristics") is { } tmc ? new(tmc) : TransportModeCharacteristics;
        TransportVehicleCharacteristics = root.Element("TransportVehicleCharacteristics") is { } tvc ? new(tvc) : TransportVehicleCharacteristics;
        TransportUnitCharacteristics = root.Element("TransportUnitCharacteristics") is { } tunic ? new(tunic) : TransportUnitCharacteristics;
        TransportUnloadingCharacteristics = root.Element("TransportUnloadingCharacteristics") is { } tunlc ? new(tunlc) : TransportUnloadingCharacteristics;
        TransportOtherInstructions = root.Element("TransportOtherInstructions") is { } toi ? new(toi) : TransportOtherInstructions;
        Route = [.. root.Elements("Route").Select(e => new Route(e))];
        DeliveryTransitTime = root.Element("DeliveryTransitTime") is { } dtt ? new(dtt) : DeliveryTransitTime;
        DeliveryDestination = root.Element("DeliveryDestination") is { } dd ? new(dd) : DeliveryDestination;
        DeliveryDateWindow = [.. root.Elements("DeliveryDateWindow").Select(e => new DeliveryDateWindow(e))];
        DeliveryLegReference = [.. root.Elements("DeliveryLegReference").Select(e => new DeliveryLegReference(e))];
        TermsOfChartering = [.. root.Elements("TermsOfChartering").Select(e => new TermsOfChartering(e))];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("DeliveryLeg",
            DeliveryModeType != DeliveryModeType.Unset ? new XAttribute("DeliveryModeType", DeliveryModeType) : null,
            DeliveryLegType != DeliveryLegType.Unset ? new XAttribute("DeliveryLegType", DeliveryLegType) : null,
            EventType != EventType.Unset ? new XAttribute("EventType", EventType) : null,
            LegStageType != LegStageType.Unset ? new XAttribute("LegStageType", LegStageType) : null,
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
            TermsOfChartering.Select(chartering => XElement.Parse($"{chartering}"))
        ).ToString();
    }
}

public class CarrierParty : Party
{
    public CarrierParty() : base() { }

    public CarrierParty(XElement root) : base(root) { }

    public override string LocalName => "CarrierParty";
}

public class TermsOfChartering
{
    public TermsOfCharteringType TermsOfCharteringType { get; set; } = TermsOfCharteringType.Unset;
    public string Value = string.Empty;  

    public TermsOfChartering() { }

    public TermsOfChartering(XElement root)
    {
        TermsOfCharteringType = root.Attribute("TermsOfCharteringType") is { Value: var toct } ? Enum.Parse<TermsOfCharteringType>(toct) : TermsOfCharteringType;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TermsOfChartering",
            TermsOfCharteringType != TermsOfCharteringType.Unset ? new XAttribute("TermsOfCharteringType", TermsOfCharteringType) : null,
            Value
        ).ToString();
    }
}

public class DeliveryLegReference
{
    public ReferenceType DeliveryLegReferenceType = ReferenceType.Other;
    public AssignedBy AssignedBy = AssignedBy.Unset;
    public string Value = string.Empty;

    public DeliveryLegReference() { }

    public DeliveryLegReference(XElement root)
    {
        DeliveryLegReferenceType = root.Attribute("DeliveryLegReferenceType")?.Value.ToEnum<ReferenceType>() ?? DeliveryLegReferenceType;
        AssignedBy = root.Attribute("AssignedBy")?.Value.ToEnum<AssignedBy>() ?? AssignedBy;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("DeliveryLegReference",
            new XAttribute("DeliveryLegReferenceType", DeliveryLegReferenceType.GetMemberValue()),
            AssignedBy != AssignedBy.Unset ? new XAttribute("AssignedBy", AssignedBy) : null,
            Value
        ).ToString();
    }
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
    public string Value = string.Empty;  

    public DeliveryDestination() { }

    public DeliveryDestination(XElement root)
    {
        Date = root.Element("Date") is { } d ? new(d) : Date;
        Time = root.Element("Time") is { } t ? new(t) : Time;
        LocationParty = root.Element("LocationParty") is { } lp ? new(lp) : LocationParty;
        LocationCode = root.Element("LocationCode") is { } lc ? new(lc) : LocationCode;
        GPSCoordinates = root.Element("GPSCoordinates") is { } gpsc ? new(gpsc) : GPSCoordinates;
        MapCoordinates = root.Element("MapCoordinates") is { } mp ? new(mp) : MapCoordinates;
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
            MapCoordinates != null ? XElement.Parse($"{MapCoordinates}") : null
        ).ToString();
    }
}

public class DeliveryTransitTime
{
    public string Days = string.Empty;
    public string? Hours { get; set; } = null;
    public string? Minutes { get; set; } = null;

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
    public List<string> RouteComment { get; } = [];
    public List<SupplyPoint> SupplyPoint { get; } = [];
    public List<MapPoint> MapPoint { get; } = [];
    public string? RouteLength { get; set; } = null;
    public string? RouteDefinition { get; set; } = null;
    public eAttachment? eAttachment { get; set; } = null;
    public List<RouteLeg> RouteLeg { get; } = [];
    public string RootValue = string.Empty;

    public Route() { }

    public Route(XElement root)
    {
        RouteType = root.Attribute("RouteType") is { Value: var rt } ? Enum.Parse<RouteType>(rt) : RouteType;
        RouteName = root.Element("RouteName")?.Value ?? RouteName;
        RouteComment = [.. root.Elements("RouteComment").Select(e => e.Value)];
        SupplyPoint = [.. root.Elements("SupplyPoint").Select(e => new SupplyPoint(e))];
        MapPoint = [.. root.Elements("MapPoint").Select(e => new MapPoint(e))];
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
    public string? RouteLegName { get; set; } = null;
    public List<OtherParty> OtherParty { get; } = [];
    public MapPoint? MapPoint { get; set; } = null;
    public RouteLegLength? RouteLegLength { get; set; } = null;
    public RoadCharacteristics? RoadCharacteristics { get; set; } = null;
    public eAttachment? eAttachment { get; set; } = null;
    public List<string> AdditionalText { get; } = [];

    public RouteLeg() { }

    public RouteLeg(XElement root)
    {
        RouteLegNumber = root.Element("RouteLegNumber")?.Value ?? RouteLegNumber;
        RouteLegName = root.Element("RouteLegName")?.Value ?? RouteLegName;
        OtherParty = [.. root.Elements("OtherParty").Select(e => new OtherParty(e))];
        MapPoint = root.Element("MapPoint") is { } mp ? new(mp) : MapPoint;
        RouteLegLength = root.Element("RouteLegLength") is { } rll ? new(rll) : RouteLegLength;
        RoadCharacteristics = root.Element("RoadCharacteristics") is { } rc ? new(rc) : RoadCharacteristics;
        eAttachment = root.Element("eAttachment") is { } ea ? new(ea) : eAttachment;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
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

public class OtherParty : Party
{
    public OtherParty() : base() { }

    public OtherParty(XElement root) : base(root) { }

    public override string LocalName => "OtherParty";
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

    public RoadCharacteristics() { }

    public RoadCharacteristics(XElement root)
    {
        RoadOwnerType = root.Attribute("RoadOwnerType") is { Value: var rot } ? Enum.Parse<RoadOwnerType>(rot) : RoadOwnerType;
        RoadKeeperType = root.Attribute("RoadKeeperType") is { Value: var rkt } ? Enum.Parse<RoadKeeperType>(rkt) : RoadKeeperType;
        RoadAccessibilityType = root.Attribute("RoadAccessibilityType") is { Value: var rat } ? Enum.Parse<RoadAccessibilityType>(rat) : RoadAccessibilityType;
        RoadTurningPossibilityType = root.Attribute("RoadTurningPossibilityType") is { Value: var rtpost } ? Enum.Parse<RoadTurningPossibilityType>(rtpost) : RoadTurningPossibilityType;
        RoadTurningPointType = root.Attribute("RoadTurningPointType") is { Value: var rtpoit } ? Enum.Parse<RoadTurningPointType>(rtpoit) : RoadTurningPointType;
        RoadPassingPossibility = root.Attribute("RoadPassingPossibility") is { Value: var rpp } ? Enum.Parse<RoadPassingPossibility>(rpp) : RoadPassingPossibility;
        RoadName = root.Element("RoadName")?.Value ?? RoadName;
        RoadNumber = root.Element("RoadNumber")?.Value ?? RoadNumber;
        RoadClassification = [.. root.Elements("RoadClassification").Select(e => new RoadClassification(e))];
        RoadAvailability = [.. root.Elements("RoadAvailability").Select(e => Enum.Parse<RoadAvailability>(e.Value))];
        RoadBearingCapacity = [.. root.Elements("RoadBearingCapacity").Select(e => new RoadBearingCapacity(e))];
        RoadObstruction = [.. root.Elements("RoadObstruction").Select(e => new RoadObstruction(e))];
    }

    public override string ToString()
    {
        return new XElement("RoadCharacteristics",
            RoadOwnerType != RoadOwnerType.Unset ? new XAttribute("RoadOwnerType", RoadOwnerType) : null,
            RoadKeeperType != RoadKeeperType.Unset ? new XAttribute("RoadKeeperType", RoadKeeperType) : null,
            RoadAccessibilityType != RoadAccessibilityType.Unset ? new XAttribute("RoadAccessibilityType", RoadAccessibilityType) : null,
            RoadTurningPossibilityType != RoadTurningPossibilityType.Unset ? new XAttribute("RoadTurningPossibilityType", RoadTurningPossibilityType) : null,
            RoadTurningPointType != RoadTurningPointType.Unset ? new XAttribute("RoadTurningPointType", RoadTurningPointType) : null,
            RoadPassingPossibility != RoadPassingPossibility.Unset ? new XAttribute("RoadPassingPossibility", RoadPassingPossibility) : null,
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

    public RoadObstruction() { }

    public RoadObstruction(XElement root)
    {
        RoadObstructionType = root.Attribute("RoadObstructionType") is { Value: var rot } ? Enum.Parse<RoadObstructionType>(rot) : RoadObstructionType;
        MapPointName = root.Element("MapPointName")?.Value ?? MapPointName;
        MapPointComment = [.. root.Elements("MapPointComment").Select(e => e.Value)];
        MapCoordinates = [.. root.Elements("MapCoordinates").Select(e => new MapCoordinates(e))];
        RoadSlopePercent = root.Element("RoadSlopePercent")?.Value ?? RoadSlopePercent;
        RoadBearingCapacity = [.. root.Elements("RoadBearingCapacity").Select(e => new RoadBearingCapacity(e))];
        Length = root.Element("Length") is { } l ? new(l) : Length;
        Width = root.Element("Width") is { } w ? new(w) : Width;
        Height = root.Element("Height") is { } h ? new(h) : Height;
        eAttachment = root.Element("eAttachment") is { } ea ? new(ea) : eAttachment;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
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

public class Height : MeasurementBase
{
    public Height() { }

    public Height(XElement root) : base(root) { }

    public override string LocalName => "Height";
}

public class Width : MeasurementBase
{
    public Width() { }

    public Width(XElement root) : base(root) { }

    public override string LocalName => "Width";
}

public class Length : MeasurementBase
{
    public Length() { }

    public Length(XElement root) : base(root) { }

    public override string LocalName => "Length";
}

public class RoadBearingCapacity
{
    public RoadBearingCapacityType RoadBearingCapacityType { get; set; } = RoadBearingCapacityType.Unset;
    public Value Value { get; set; } = new();
    public RangeMin? RangeMin { get; set; } = null;
    public RangeMax? RangeMax { get; set; } = null;

    public RoadBearingCapacity() { }

    public RoadBearingCapacity(XElement root)
    {
        RoadBearingCapacityType = root.Attribute("RoadBearingCapacityType") is { Value: var rbct } ? Enum.Parse<RoadBearingCapacityType>(rbct) : RoadBearingCapacityType;
        Value = root.Element("Value") is { } v ? new(v) : Value;
        RangeMin = root.Element("RangeMin") is { } rmin ? new(rmin) : RangeMin;
        RangeMax = root.Element("RangeMax") is { } rmax ? new(rmax) : RangeMax;
    }

    public override string ToString()
    {
        return new XElement("RoadBearingCapacity",
            RoadBearingCapacityType != RoadBearingCapacityType.Unset ? new XAttribute("RoadBearingCapacityType", RoadBearingCapacityType) : null,
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class RoadClassification
{
    public string? RoadClassificationCode { get; set; } = null;
    public List<string> RoadClassificationDescription { get; } = [];
    public string RootValue = string.Empty;

    public RoadClassification() { }

    public RoadClassification(XElement root)
    {
        RoadClassificationCode = root.Element("RoadClassificationCode")?.Value ?? RoadClassificationCode;
        RoadClassificationDescription = [.. root.Elements("RoadClassificationDescription").Select(e => e.Value)];
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

public class RouteLegLength : MeasurementBase
{
    public RouteLegLength() { }

    public RouteLegLength(XElement root) : base(root) { }

    public override string LocalName => "RouteLegLength";
}

public class eAttachment
{
    public string? AttachmentFileName { get; set; } = null;
    public string? NumberOfAttachments { get; set; } = null;
    public List<URL> URL { get; } = [];
    public string RootValue = string.Empty;

    public eAttachment() { }

    public eAttachment(XElement root)
    {
        AttachmentFileName = root.Element("AttachmentFileName")?.Value ?? AttachmentFileName;
        NumberOfAttachments = root.Element("NumberOfAttachments")?.Value ?? NumberOfAttachments;
        URL = [.. root.Elements("URL").Select(e => new URL(e))];
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
    public MapPointType MapPointType { get; set; } = MapPointType.Unset;
    public string MapPointName = string.Empty;
    public List<string> MapPointComment { get; } = [];
    public List<MapCoordinates> MapCoordinates { get; } = [];
    public string Value = string.Empty;  

    public MapPoint() { }

    public MapPoint(XElement root)
    {
        MapPointType = root.Attribute("MapPointType") is { Value: var mpt } ? Enum.Parse<MapPointType>(mpt) : MapPointType;
        MapPointName = root.Element("MapPointName")?.Value ?? MapPointName;
        MapPointComment = [.. root.Elements("MapPointComment").Select(e => e.Value)];
        MapCoordinates = [.. root.Elements("MapCoordinates").Select(e => new MapCoordinates(e))];
        Value = root.Value;
    }
    
    public override string ToString()
    {
        return new XElement("MapPoint",
            MapPointType != MapPointType.Unset ? new XAttribute("MapPointType", MapPointType) : null,
            new XElement("MapPointName", MapPointName),
            MapPointComment.Select(comment => new XElement("MapPointComment", comment)),
            MapCoordinates.Select(coordinates => XElement.Parse($"{coordinates}")),
            Value
        ).ToString();
    }
}

public class TransportOtherInstructions
{
    public TransportInstructionType TransportInstructionType { get; set; } = TransportInstructionType.Unset;
    public TransportInstructionCode? TransportInstructionCode { get; set; } = null;
    public List<string> TransportInstructionText { get; } = [];
    public string Value = string.Empty;  

    public TransportOtherInstructions() { }

    public TransportOtherInstructions(XElement root)
    {
        TransportInstructionType = root.Attribute("TransportInstructionType") is { Value: var tit } ? Enum.Parse<TransportInstructionType>(tit) : TransportInstructionType;
        TransportInstructionCode = root.Element("TransportInstructionCode") is { } tic ? new(tic) : TransportInstructionCode;
        TransportInstructionText = [.. root.Elements("TransportInstructionText").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportOtherInstructions",
            TransportInstructionType != TransportInstructionType.Unset ? new XAttribute("TransportInstructionType", TransportInstructionType) : null,
            TransportInstructionCode != null ? XElement.Parse($"{TransportInstructionCode}") : null,
            TransportInstructionText.Select(text => new XElement("TransportInstructionText", text)),
            Value
        ).ToString();
    }
}

public class TransportInstructionCode : AgencyValueBase
{
    public TransportInstructionCode() : base() { Agency = PapiNet.Agency.Other; }

    public TransportInstructionCode(XElement root) : base(root) { }

    public override string LocalName => "TransportInstructionCode";
}

public class TransportUnloadingCharacteristics
{
    public TransportUnloadingType TransportUnloadingType { get; set; } = TransportUnloadingType.Unset;
    public DirectUnloading DirectUnloading { get; set; } = DirectUnloading.Unset;
    public TransportUnloadingCode? TransportUnloadingCode { get; set; } = null;
    public TransportUnloadingCodeDescription? TransportUnloadingCodeDescription { get; set; } = null;
    public List<string> TransportUnloadingText { get; } = [];
    public string Value = string.Empty;  

    public TransportUnloadingCharacteristics() { }

    public TransportUnloadingCharacteristics(XElement root)
    {
        TransportUnloadingType = root.Attribute("TransportUnloadingType") is { Value: var tut } ? Enum.Parse<TransportUnloadingType>(tut) : TransportUnloadingType;
        DirectUnloading = root.Attribute("DirectUnloading") is { Value: var du } ? Enum.Parse<DirectUnloading>(du) : DirectUnloading;
        TransportUnloadingCode = root.Element("TransportUnloadingCode") is { } tuc ? new(tuc) : TransportUnloadingCode;
        TransportUnloadingCodeDescription = root.Element("TransportUnloadingCodeDescription") is { } tucd ? new(tucd) : TransportUnloadingCodeDescription;
        TransportUnloadingText = [.. root.Elements("TransportUnloadingText").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportUnloadingCharacteristics",
            TransportUnloadingType != TransportUnloadingType.Unset ? new XAttribute("TransportUnloadingType", TransportUnloadingType) : null,
            DirectUnloading != DirectUnloading.Unset ? new XAttribute("DirectUnloading", DirectUnloading) : null,
            TransportUnloadingCode != null ? XElement.Parse($"{TransportUnloadingCode}") : null,
            TransportUnloadingCodeDescription != null ? XElement.Parse($"{TransportUnloadingCodeDescription}") : null,
            TransportUnloadingText.Select(text => new XElement("TransportUnloadingText", text)),
            Value
        ).ToString();
    }
}

public class TransportUnloadingCodeDescription
{
    public List<string> AdditionalText { get; } = [];
    public e_Attachment? e_Attachment { get; set; } = null;
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
    public string? AttachmentFileName { get; set; } = null;
    public string? NumberOfAttachments { get; set; } = null;
    public URL? URL { get; set; } = null;
    public string Value = string.Empty;  

    public e_Attachment() { }

    public e_Attachment(XElement root)
    {
        AttachmentFileName = root.Element("AttachmentFileName")?.Value ?? AttachmentFileName;
        NumberOfAttachments = root.Element("NumberOfAttachments")?.Value ?? NumberOfAttachments;
        URL = root.Element("URL") is { } url ? new(url) : URL;
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
    public string? URLContext { get; set; } = null;
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

public class TransportUnloadingCode : AgencyValueBase
{
    public TransportUnloadingCode() : base() { Agency = PapiNet.Agency.Other; }

    public TransportUnloadingCode(XElement root) : base(root) { }

    public override string LocalName => "TransportUnloadingCode";
}

public class TransportUnitCharacteristics
{
    public TransportUnitType TransportUnitType = TransportUnitType.Other;
    public TransportUnitVariable TransportUnitVariable { get; set; } = TransportUnitVariable.Unset;
    public string? TransportUnitLevel { get; set; } = null;
    public TransportUnitCode? TransportUnitCode { get; set; } = null;
    public TransportUnitMeasurements? TransportUnitMeasurements { get; set; } = null;
    public List<TransportUnitEquipment> TransportUnitEquipment { get; } = [];
    public string? TransportUnitCount { get; set; } = null;
    public List<TransportUnitIdentifier> TransportUnitIdentifier { get; } = [];
    public string? TransportUnitText { get; set; } = null;
    public TransportUnitDetail? TransportUnitDetail { get; set; } = null;

    public TransportUnitCharacteristics() { }

    public TransportUnitCharacteristics(XElement root)
    {
        TransportUnitType = root.Attribute("TransportUnitType") is { Value: var tut } ? Enum.Parse<TransportUnitType>(tut) : TransportUnitType;
        TransportUnitVariable = root.Attribute("TransportUnitVariable") is { Value: var tuv } ? Enum.Parse<TransportUnitVariable>(tuv) : TransportUnitVariable;
        TransportUnitLevel = root.Attribute("TransportUnitLevel")?.Value ?? TransportUnitLevel;
        TransportUnitCode = root.Element("TransportUnitCode") is { } tuc ? new(tuc) : TransportUnitCode;
        TransportUnitMeasurements = root.Element("TransportUnitMeasurements") is { } tum ? new(tum) : TransportUnitMeasurements;
        TransportUnitEquipment = [.. root.Elements("TransportUnitEquipment").Select(e => new TransportUnitEquipment(e))];
        TransportUnitCount = root.Element("TransportUnitCount")?.Value ?? TransportUnitCount;
        TransportUnitIdentifier = [.. root.Elements("TransportUnitIdentifier").Select(e => new TransportUnitIdentifier(e))];
        TransportUnitText = root.Element("TransportUnitText")?.Value ?? TransportUnitText;
        TransportUnitDetail = root.Element("TransportUnitDetail") is { } tud ? new(tud) : TransportUnitDetail;
    }

    public override string ToString()
    {
        return new XElement("TransportUnitCharacteristics",
            new XAttribute("TransportUnitType", TransportUnitType),
            TransportUnitVariable != TransportUnitVariable.Unset ? new XAttribute("TransportUnitVariable", TransportUnitVariable) : null,
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
    public TransportUnitDetailType TransportUnitDetailType { get; set; } = TransportUnitDetailType.Unset;
    public LoadOpeningSide LoadOpeningSide { get; set; } = LoadOpeningSide.Unset;
    public TransportUnitDetailCode? TransportUnitDetailCode { get; set; } = null;
    public List<string> AdditionalText { get; } = [];

    public TransportUnitDetail() { }

    public TransportUnitDetail(XElement root)
    {
        TransportUnitDetailType = root.Attribute("TransportUnitDetailType") is { Value: var tudt } ? Enum.Parse<TransportUnitDetailType>(tudt) : TransportUnitDetailType;
        LoadOpeningSide = root.Attribute("LoadOpeningSide") is { Value: var los } ? Enum.Parse<LoadOpeningSide>(los) : LoadOpeningSide;
        TransportUnitDetailCode = root.Element("TransportUnitDetailCode") is { } tudc ? new(tudc) : TransportUnitDetailCode;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
    }

    public override string ToString()
    {
        return new XElement("TransportUnitDetail",
            TransportUnitDetailType != TransportUnitDetailType.Unset ? new XAttribute("TransportUnitDetailType", TransportUnitDetailType) : null,
            LoadOpeningSide != LoadOpeningSide.Unset ? new XAttribute("LoadOpeningSide", LoadOpeningSide) : null,
            TransportUnitDetailCode != null ? XElement.Parse($"{TransportUnitDetailCode}") : null,
            AdditionalText.Select(text => new XElement("AdditionalText", text))
        ).ToString();
    }
}

public class TransportUnitDetailCode : AgencyValueBase
{
    public TransportUnitDetailCode() : base() { Agency = PapiNet.Agency.Other; }

    public TransportUnitDetailCode(XElement root) : base(root) { }

    public override string LocalName => "TransportUnitDetailCode";
}

public class TransportUnitIdentifier
{
    public TransportUnitIdentifierType TransportUnitIdentifierType = TransportUnitIdentifierType.Other;
    public string? StateOrProvince { get; set; } = null;
    public ISOCountryCode ISOCountryCode { get; set; } = ISOCountryCode.Unset;
    public string Value = string.Empty;  

    public TransportUnitIdentifier() { }

    public TransportUnitIdentifier(XElement root)
    {
        TransportUnitIdentifierType = root.Attribute("TransportUnitIdentifierType") is { Value: var tuit } ? Enum.Parse<TransportUnitIdentifierType>(tuit) : TransportUnitIdentifierType;
        StateOrProvince = root.Attribute("StateOrProvince")?.Value ?? StateOrProvince;
        ISOCountryCode = root.Attribute("ISOCountryCode") is { Value: var isocc } ? Enum.Parse<ISOCountryCode>(isocc) : ISOCountryCode;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportUnitIdentifier",
            new XAttribute("TransportUnitIdentifierType", TransportUnitIdentifierType),
            StateOrProvince != null ? new XAttribute("StateOrProvince", StateOrProvince) : null,
            ISOCountryCode != ISOCountryCode.Unset ? new XAttribute("ISOCountryCode", ISOCountryCode) : null,
            Value
        ).ToString();
    }
}

public class TransportUnitEquipment
{
    public TransportUnitEquipmentCode? TransportUnitEquipmentCode { get; set; } = null;
    public List<TransportUnitEquipmentDescription> TransportUnitEquipmentDescription { get; } = [];

    public TransportUnitEquipment() { }

    public TransportUnitEquipment(XElement root)
    {
        TransportUnitEquipmentCode = root.Element("TransportUnitEquipmentCode") is { } tuec ? new(tuec) : TransportUnitEquipmentCode;
        TransportUnitEquipmentDescription = [.. root.Elements("TransportUnitEquipmentDescription").Select(e => new TransportUnitEquipmentDescription(e))];
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
    public Language Language { get; set; } = Language.Unset;
    public string Value = string.Empty;  

    public TransportUnitEquipmentDescription() { }

    public TransportUnitEquipmentDescription(XElement root)
    {
        Language = root.Attribute("Language") is { Value: var l } ? Enum.Parse<Language>(l) : Language;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportUnitEquipmentDescription",
            Language != Language.Unset ? new XAttribute("Language", Language) : null,
            Value
        ).ToString();
    }
}

public class TransportUnitEquipmentCode : AgencyValueBase
{
    public TransportUnitEquipmentCode() : base() { Agency = PapiNet.Agency.Other; }

    public TransportUnitEquipmentCode(XElement root) : base(root) { }

    public override string LocalName => "TransportUnitEquipmentCode";
}

public class TransportUnitMeasurements
{
    public AppliesTo AppliesTo { get; set; } = AppliesTo.Unset;
    public TransportUnitLength? TransportUnitLength { get; set; } = null;
    public TransportUnitWidth? TransportUnitWidth { get; set; } = null;
    public TransportUnitHeight? TransportUnitHeight { get; set; } = null;
    public TransportUnitWeight? TransportUnitWeight { get; set; } = null;

    public TransportUnitMeasurements() { }

    public TransportUnitMeasurements(XElement root)
    {
        AppliesTo = root.Attribute("AppliesTo") is { Value: var at } ? Enum.Parse<AppliesTo>(at) : AppliesTo;
        TransportUnitLength = root.Element("TransportUnitLength") is { } length ? new(length) : TransportUnitLength;
        TransportUnitWidth = root.Element("TransportUnitWidth") is { } width ? new(width) : TransportUnitWidth;
        TransportUnitHeight = root.Element("TransportUnitHeight") is { } height ? new(height) : TransportUnitHeight;
        TransportUnitWeight = root.Element("TransportUnitWeight") is { } weight ? new(weight) : TransportUnitWeight;
    }

    public override string ToString()
    {
        return new XElement("TransportUnitMeasurements",
            AppliesTo != AppliesTo.Unset ? new XAttribute("AppliesTo", AppliesTo) : null,
            TransportUnitLength != null ? XElement.Parse($"{TransportUnitLength}") : null,
            TransportUnitWidth != null ? XElement.Parse($"{TransportUnitWidth}") : null,
            TransportUnitHeight != null ? XElement.Parse($"{TransportUnitHeight}") : null,
            TransportUnitWeight != null ? XElement.Parse($"{TransportUnitWeight}") : null
        ).ToString();
    }
}

public class TransportUnitWeight : MeasurementBase
{
    public TransportUnitWeight() { }

    public TransportUnitWeight(XElement root) : base(root) { }

    public override string LocalName => "TransportUnitWeight";
}

public class TransportUnitHeight : MeasurementBase
{
    public TransportUnitHeight() { }

    public TransportUnitHeight(XElement root) : base(root) { }

    public override string LocalName => "TransportUnitHeight";
}

public class TransportUnitWidth : MeasurementBase
{
    public TransportUnitWidth() { }

    public TransportUnitWidth(XElement root) : base(root) { }

    public override string LocalName => "TransportUnitWidth";
}

public class TransportUnitLength : MeasurementBase
{
    public TransportUnitLength() { }

    public TransportUnitLength(XElement root) : base(root) { }

    public override string LocalName => "TransportUnitLength";
}

public class TransportUnitCode : AgencyValueBase
{
    public TransportUnitCode() : base() { Agency = PapiNet.Agency.Other; }

    public TransportUnitCode(XElement root) : base(root) { }

    public override string LocalName => "TransportUnitCode";
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

    public TransportVehicleCharacteristics() { }

    public TransportVehicleCharacteristics(XElement root)
    {
        TransportVehicleType = root.Attribute("TransportVehicleType") is { Value: var tvt } ? Enum.Parse<TransportVehicleType>(tvt) : TransportVehicleType;
        TransportVehicleCode = root.Element("TransportVehicleCode") is { } tvc ? new(tvc) : TransportVehicleCode;
        TransportVehicleMeasurements = root.Element("TransportVehicleMeasurements") is { } tvm ? new(tvm) : TransportVehicleMeasurements;
        TransportVehicleEquipment = [.. root.Elements("TransportVehicleEquipment").Select(e => new TransportVehicleEquipment(e))];
        TransportVehicleCount = root.Element("TransportVehicleCount")?.Value ?? TransportVehicleCount;
        TransportVehicleIdentifier = root.Element("TransportVehicleIdentifier") is { } tvi ? new(tvi) : TransportVehicleIdentifier;
        TransportVehicleText = root.Element("TransportVehicleText")?.Value ?? TransportVehicleText;
    }

    public override string ToString()
    {
        return new XElement("TransportVehicleCharacteristics",
            TransportVehicleType != TransportVehicleType.Unset ? new XAttribute("TransportVehicleType", TransportVehicleType) : null,
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
    public TransportVehicleIdentifierType TransportVehicleIdentifierType { get; set; } = TransportVehicleIdentifierType.Unset;
    public string? StateOrProvince { get; set; } = null;
    public ISOCountryCode ISOCountryCode { get; set; } = ISOCountryCode.Unset;
    public string Value = string.Empty;  

    public TransportVehicleIdentifier() { }

    public TransportVehicleIdentifier(XElement root)
    {
        TransportVehicleIdentifierType = root.Attribute("TransportVehicleIdentifierType") is { Value: var tvit } ? Enum.Parse<TransportVehicleIdentifierType>(tvit) : TransportVehicleIdentifierType;
        StateOrProvince = root.Attribute("StateOrProvince")?.Value ?? StateOrProvince;
        ISOCountryCode = root.Attribute("ISOCountryCode") is { Value: var isocc } ? Enum.Parse<ISOCountryCode>(isocc) : ISOCountryCode;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportVehicleIdentifier",
            TransportVehicleIdentifierType != TransportVehicleIdentifierType.Unset ? new XAttribute("TransportVehicleIdentifierType", TransportVehicleIdentifierType) : null,
            StateOrProvince != null ? new XAttribute("StateOrProvince", StateOrProvince) : null,
            ISOCountryCode != ISOCountryCode.Unset ? new XAttribute("ISOCountryCode", ISOCountryCode) : null,
            Value
        ).ToString();
    }
}

public class TransportVehicleEquipment
{
    public TransportVehicleEquipmentCode? TransportVehicleEquipmentCode { get; set; } = null;
    public List<TransportVehicleEquipmentDescription> TransportVehicleEquipmentDescription { get; } = [];

    public TransportVehicleEquipment() { }

    public TransportVehicleEquipment(XElement root)
    {
        TransportVehicleEquipmentCode = root.Element("TransportVehicleEquipmentCode") is { } tvec ? new(tvec) : TransportVehicleEquipmentCode;
        TransportVehicleEquipmentDescription = [.. root.Elements("TransportVehicleEquipmentDescription").Select(e => new TransportVehicleEquipmentDescription(e))];
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
    public Language Language { get; set; } = Language.Unset;
    public string Value = string.Empty;  

    public TransportVehicleEquipmentDescription() { }

    public TransportVehicleEquipmentDescription(XElement root)
    {
        Language = root.Attribute("Language") is { Value: var l } ? Enum.Parse<Language>(l) : Language;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportVehicleEquipmentDescription",
            Language != Language.Unset ? new XAttribute("Language", Language) : null,
            Value
        ).ToString();
    }
}

public class TransportVehicleEquipmentCode : AgencyValueBase
{
    public TransportVehicleEquipmentCode() : base() { Agency = PapiNet.Agency.Other; }

    public TransportVehicleEquipmentCode(XElement root) : base(root) { }

    public override string LocalName => "TransportVehicleEquipmentCode";
}

public class TransportVehicleMeasurements
{
    public TransportVehicleLength? TransportVehicleLength { get; set; } = null;
    public TransportVehicleWidth? TransportVehicleWidth { get; set; } = null;
    public TransportVehicleHeight? TransportVehicleHeight { get; set; } = null;
    public TransportVehicleWeight? TransportVehicleWeight { get; set; } = null;

    public TransportVehicleMeasurements() { }

    public TransportVehicleMeasurements(XElement root)
    {
        TransportVehicleLength = root.Element("TransportVehicleLength") is { } length ? new(length) : TransportVehicleLength;
        TransportVehicleWidth = root.Element("TransportVehicleWidth") is { } width ? new(width) : TransportVehicleWidth;
        TransportVehicleHeight = root.Element("TransportVehicleHeight") is { } height ? new(height) : TransportVehicleHeight;
        TransportVehicleWeight = root.Element("TransportVehicleWeight") is { } weight ? new(weight) : TransportVehicleWeight;
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

public class TransportVehicleWeight : MeasurementBase
{
    public TransportVehicleWeight() { }

    public TransportVehicleWeight(XElement root) : base(root) { }

    public override string LocalName => "TransportVehicleWeight";
}

public class TransportVehicleHeight : MeasurementBase
{
    public TransportVehicleHeight() { }

    public TransportVehicleHeight(XElement root) : base(root) { }

    public override string LocalName => "TransportVehicleHeight";
}

public class TransportVehicleWidth : MeasurementBase
{
    public TransportVehicleWidth() { }

    public TransportVehicleWidth(XElement root) : base(root) { }

    public override string LocalName => "TransportVehicleWidth";
}

public class TransportVehicleLength : MeasurementBase
{
    public TransportVehicleLength() { }

    public TransportVehicleLength(XElement root) : base(root) { }

    public override string LocalName => "TransportVehicleLength";
}

public class TransportVehicleCode : AgencyValueBase
{
    public TransportVehicleCode() : base() { Agency = PapiNet.Agency.Other; }

    public TransportVehicleCode(XElement root) : base(root) { }

    public override string LocalName => "TransportVehicleCode";
}

public class TransportModeCharacteristics
{
    public TransportModeType TransportModeType { get; set; } = TransportModeType.Unset;
    public TransportModeCode? TransportModeCode { get; set; } = null;
    public string? TransportModeText { get; set; } = null;

    public TransportModeCharacteristics() { }

    public TransportModeCharacteristics(XElement root)
    {
        TransportModeType = root.Attribute("TransportModeType") is { Value: var tmt } ? Enum.Parse<TransportModeType>(tmt) : TransportModeType;
        TransportModeCode = root.Element("TransportModeCode") is { } tmc ? new(tmc) : TransportModeCode;
        TransportModeText = root.Element("TransportModeText")?.Value ?? TransportModeText;
    }

    public override string ToString()
    {
        return new XElement("TransportModeCharacteristics",
            TransportModeType != TransportModeType.Unset ? new XAttribute("TransportModeType", TransportModeType) : null,
            TransportModeCode != null ? XElement.Parse($"{TransportModeCode}") : null,
            TransportModeText != null ? new XElement("TransportModeText", TransportModeText) : null
        ).ToString();
    }
}

public class TransportModeCode : AgencyValueBase
{
    public TransportModeCode() { Agency = PapiNet.Agency.Other; }

    public TransportModeCode(XElement root) : base(root) { }

    public override string LocalName => "TransportModeCode";
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

    public DeliveryOrigin() { }

    public DeliveryOrigin(XElement root)
    {
        Date = root.Element("Date") is { } d ? new(d) : Date;
        Time = root.Element("Time") is { } t ? new(t) : Time;
        LocationParty = root.Element("LocationParty") is { } lp ? new(lp) : LocationParty;
        SupplyPoint = root.Element("SupplyPoint") is { } sp ? new(sp) : SupplyPoint;
        LocationCode = root.Element("LocationCode") is { } lc ? new(lc) : LocationCode;
        GPSCoordinates = root.Element("GPSCoordinates") is { } gpsc ? new(gpsc) : GPSCoordinates;
        MapCoordinates = root.Element("MapCoordinates") is { } mc ? new(mc) : MapCoordinates;
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

public class LocationParty : Party
{
    public LocationParty() : base() { }

    public LocationParty(XElement root) : base(root) { }

    public override string LocalName => "LocationParty";
}

public class SupplyPoint
{
    public LocationType LocationType = LocationType.Destination;
    public SupplyPointCode SupplyPointCode { get; set; } = new();
    public List<string> SupplyPointDescription { get; } = [];
    public List<MapCoordinates> MapCoordinates { get; } = [];

    public SupplyPoint() { }

    public SupplyPoint(XElement root)
    {
        LocationType = root.Attribute("LocationType") is { Value: var lt } ? Enum.Parse<LocationType>(lt) : LocationType;
        SupplyPointCode = root.Element("SupplyPointCode") is { } spc ? new(spc) : SupplyPointCode;
        SupplyPointDescription = [.. root.Elements("SupplyPointDescription").Select(e => e.Value)];
        MapCoordinates = [.. root.Elements("MapCoordinates").Select(e => new MapCoordinates(e))];
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

public class SupplyPointCode : AgencyValueBase
{
    public SupplyPointCode() : base() { Agency = PapiNet.Agency.Other; }

    public SupplyPointCode(XElement root) : base(root) { }

    public override string LocalName => "SupplyPointCode";
}

public class PriceDetails
{
    public PriceQuantityBasis PriceQuantityBasis = PriceQuantityBasis.ActualVolume;
    public PriceTaxBasis PriceTaxBasis { get; set; } = PriceTaxBasis.Unset;
    public PricePerUnit PricePerUnit { get; set; } = new();
    public List<InformationalPricePerUnit> InformationalPricePerUnit { get; } = [];
    public List<string> AdditionalText { get; } = [];
    public ExchangeRate ExchangeRate { get; set; } = new();
    public MonetaryAdjustment? MonetaryAdjustment { get; set; } = null;
    public GeneralLedgerAccount? GeneralLedgerAccount { get; set; } = null;

    public PriceDetails() { }

    public PriceDetails(XElement root)
    {
        PriceQuantityBasis = root.Attribute("PriceQuantityBasis") is { Value: var pqb } ? Enum.Parse<PriceQuantityBasis>(pqb) : PriceQuantityBasis;
        PriceTaxBasis = root.Attribute("PriceTaxBasis") is { Value: var ptb } ? Enum.Parse<PriceTaxBasis>(ptb) : PriceTaxBasis;
        PricePerUnit = root.Element("PricePerUnit") is { } ppu ? new(ppu) : PricePerUnit;
        InformationalPricePerUnit = [.. root.Elements("InformationalPricePerUnit").Select(e => new InformationalPricePerUnit(e))];
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        ExchangeRate = root.Element("ExchangeRate") is { } er ? new(er) : ExchangeRate;
        MonetaryAdjustment = root.Element("MonetaryAdjustment") is { } ma ? new(ma) : MonetaryAdjustment;
        GeneralLedgerAccount = root.Element("GeneralLedgerAccount") is { } gla ? new(gla) : GeneralLedgerAccount;
    }

    public override string ToString()
    {
        return new XElement("PriceDetails",
            new XAttribute("PriceQuantityBasis", PriceQuantityBasis),
            PriceTaxBasis != PriceTaxBasis.Unset ? new XAttribute("PriceTaxBasis", PriceTaxBasis) : null,
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

    public MonetaryAdjustment() { }

    public MonetaryAdjustment(XElement root)
    {
        AdjustmentType = root.Attribute("AdjustmentType") is { Value: var at } ? Enum.Parse<AdjustmentType_Financial>(at) : AdjustmentType;
        MonetaryAdjustmentLine = root.Element("MonetaryAdjustmentLine")?.Value ?? MonetaryAdjustmentLine;
        MonetaryAdjustmentStartAmount = root.Element("MonetaryAdjustmentStartAmount") is { } masa ? new(masa) : MonetaryAdjustmentStartAmount;
        MonetaryAdjustmentStartQuantity = root.Element("MonetaryAdjustmentStartQuantity") is { } masq ? new(masq) : MonetaryAdjustmentStartQuantity;
        PriceAdjustment = root.Element("PriceAdjustment") is { } pa ? new(pa) : PriceAdjustment;
        FlatAmountAdjustment = root.Element("FlatAmountAdjustment") is { } faa ? new(faa) : FlatAmountAdjustment;
        TaxAdjustment = root.Element("TaxAdjustment") is { } ta ? new(ta) : TaxAdjustment;
        InformationalAmount = root.Element("InformationalAmount") is { } ia ? new(ia) : InformationalAmount;
        MonetaryAdjustmentReferenceLine = root.Element("MonetaryAdjustmentReferenceLine")?.Value ?? MonetaryAdjustmentReferenceLine;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        GeneralLedgerAccount = root.Element("GeneralLedgerAccount") is { } gla ? new(gla) : GeneralLedgerAccount;
        MonetaryAdjustmentAmount = root.Element("MonetaryAdjustmentAmount") is { } maa ? new(maa) : MonetaryAdjustmentAmount;
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
            MonetaryAdjustmentReferenceLine != null ? new XElement("MonetaryAdjustmentReferenceLine", MonetaryAdjustmentReferenceLine) : null,
            AdditionalText.Select(text => new XElement("AdditionalText", text)),
            GeneralLedgerAccount != null ? XElement.Parse($"{GeneralLedgerAccount}") : null,
            MonetaryAdjustmentAmount != null ? XElement.Parse($"{MonetaryAdjustmentAmount}") : null,
            AdjustmentTypeReason != null ? new XElement("AdjustmentTypeReason", AdjustmentTypeReason) : null
        ).ToString();
    }
}

public class MonetaryAdjustmentAmount
{
    public CurrencyValue CurrencyValue { get; set; } = new();

    public MonetaryAdjustmentAmount() { }

    public MonetaryAdjustmentAmount(XElement root)
    {
        CurrencyValue = root.Element("CurrencyValue") is { } cv ? new(cv) : CurrencyValue;
    }

    public override string ToString()
    {
        return new XElement("MonetaryAdjustmentAmount",
            XElement.Parse($"{CurrencyValue}")
        ).ToString();
    }
}

public class GeneralLedgerAccount : AgencyValueBase
{
    public GeneralLedgerAccount() { }

    public GeneralLedgerAccount(XElement root) : base(root) { }

    public override string LocalName => "GeneralLedgerAccount";
}

public class TaxAdjustment
{
    public TaxCategoryType TaxCategoryType { get; set; } = TaxCategoryType.Unset;
    public TaxType TaxType = TaxType.VAT;
    public string? TaxPercent { get; set; } = null;
    public TaxAmount? TaxAmount { get; set; } = null;
    public string TaxLocation = string.Empty;
    public List<InformationalAmount> InformationalAmount { get; } = [];

    public TaxAdjustment() { }

    public TaxAdjustment(XElement root)
    {
        TaxCategoryType = root.Attribute("TaxCategoryType") is { Value: var tct } ? Enum.Parse<TaxCategoryType>(tct) : TaxCategoryType;
        TaxType = root.Attribute("TaxType") is { Value: var tt } ? Enum.Parse<TaxType>(tt) : TaxType;
        TaxPercent = root.Element("TaxPercent")?.Value ?? TaxPercent;
        TaxAmount = root.Element("TaxAmount") is { } ta ? new(ta) : TaxAmount;
        TaxLocation = root.Element("TaxLocation")?.Value ?? TaxLocation;
        InformationalAmount = [.. root.Elements("InformationalAmount").Select(e => new InformationalAmount(e))];
    }

    public override string ToString()
    {
        return new XElement("TaxAdjustment",
            TaxCategoryType != TaxCategoryType.Unset ? new XAttribute("TaxCategoryType", TaxCategoryType) : null,
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
    public AmountType AmountType { get; set; } = AmountType.Unset;
    public CurrencyValue CurrencyValue { get; set; } = new();
    public ExchangeRate? ExchangeRate { get; set; } = null;
    public List<string> AdditionalText { get; } = [];

    public InformationalAmount() { }

    public InformationalAmount(XElement root)
    {
        AmountType = root.Attribute("AmountType") is { Value: var at } ? Enum.Parse<AmountType>(at) : AmountType;
        CurrencyValue = root.Element("CurrencyValue") is { } cv ? new(cv) : CurrencyValue;
        ExchangeRate = root.Element("ExchangeRate") is { } er ? new(er) : ExchangeRate;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
    }

    public override string ToString()
    {
        return new XElement("InformationalAmount",
            AmountType != AmountType.Unset ? new XAttribute("AmountType", AmountType) : null,
            XElement.Parse($"{CurrencyValue}"),
            ExchangeRate != null ? XElement.Parse($"{ExchangeRate}") : null,
            AdditionalText.Select(text => new XElement("AdditionalText", text))
        ).ToString();
    }
}

public class TaxAmount
{
    public CurrencyValue CurrencyValue { get; set; } = new();

    public TaxAmount() { }

    public TaxAmount(XElement root)
    {
        CurrencyValue = root.Element("CurrencyValue") is { } cv ? new(cv) : CurrencyValue;
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
    public AdjustmentPercentage? AdjustmentPercentage { get; set; } = null;
    public AdjustmentFixedAmount? AdjustmentFixedAmount { get; set; } = null;
    public string Value = string.Empty;  

    public FlatAmountAdjustment() { }

    public FlatAmountAdjustment(XElement root)
    {
        AdjustmentPercentage = root.Element("AdjustmentPercentage") is { } ap ? new(ap) : AdjustmentPercentage;
        AdjustmentFixedAmount = root.Element("AdjustmentFixedAmount") is { } afa ? new(afa) : AdjustmentFixedAmount;
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
    public CurrencyValue CurrencyValue { get; set; } = new();
    public string Value = string.Empty;  

    public AdjustmentFixedAmount() { }

    public AdjustmentFixedAmount(XElement root)
    {
        CurrencyValue = root.Element("CurrencyValue") is { } cv ? new(cv) : CurrencyValue;
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
    public AdjustmentPercentage? AdjustmentPercentage { get; set; } = null;
    public AdjustmentValue? AdjustmentValue { get; set; } = null;
    public string Value = string.Empty;  

    public PriceAdjustment() { }

    public PriceAdjustment(XElement root)
    {
        AdjustmentPercentage = root.Element("AdjustmentPercentage") is { } ap ? new(ap) : AdjustmentPercentage;
        AdjustmentValue = root.Element("AdjustmentValue") is { } av ? new(av) : AdjustmentValue;
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

public class AdjustmentValue : MeasurementBase
{
    public CurrencyValue CurrencyValue { get; set; } = new();

    public AdjustmentValue() { }

    public AdjustmentValue(XElement root) : base(root)
    {
        CurrencyValue = root.Element("CurrencyValue") is { } cv ? new(cv) : CurrencyValue;
    }

    public override string LocalName => "AdjustmentValue";

    public override string ToString()
    {
        return new XElement(LocalName,
            XElement.Parse($"{CurrencyValue}"),
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class AdjustmentPercentage : MeasurementBase
{
    public AdjustmentPercentage() { }

    public AdjustmentPercentage(XElement root) : base(root) { }

    public override string LocalName => "AdjustmentPercentage";
}

public class MonetaryAdjustmentStartQuantity : MeasurementBase
{
    public MonetaryAdjustmentStartQuantity() { }

    public MonetaryAdjustmentStartQuantity(XElement root) : base(root) { }

    public override string LocalName => "MonetaryAdjustmentStartQuantity";
}

public class MonetaryAdjustmentStartAmount
{
    public CurrencyValue CurrencyValue { get; set; } = new();
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
    public CurrencyFromType CurrencyFromType { get; set; } = CurrencyFromType.Unset;
    public CurrencyValue? CurrencyValue { get; set; } = null;
    public MinCurrencyValue MinCurrencyValue { get; set; } = new();
    public MaxCurrencyValue MaxCurrencyValue { get; set; } = new();
    public Date? Date { get; set; } = null;

    public ExchangeRate() { }

    public ExchangeRate(XElement root)
    {
        ExchangeRateType = root.Attribute("ExchangeRateType") is { Value: var ert } ? Enum.Parse<ExchangeRateType>(ert) : ExchangeRateType;
        CurrencyFromType = root.Attribute("CurrencyFromType") is { Value: var cft } ? Enum.Parse<CurrencyFromType>(cft) : CurrencyFromType;
        CurrencyValue = root.Element("CurrencyValue") is { } ct ? new(ct) : CurrencyValue;
        MinCurrencyValue = root.Element("MinCurrencyValue") is { } mincv ? new(mincv) : MinCurrencyValue;
        MaxCurrencyValue = root.Element("MaxCurrencyValue") is { } maxcv ? new(maxcv) : MaxCurrencyValue;
        Date = root.Element("Date") is { } d ? new(d) : Date;
    }

    public override string ToString()
    {
        return new XElement("ExchangeRate",
            new XAttribute("ExchangeRateType", ExchangeRateType),
            CurrencyFromType != CurrencyFromType.Unset ? new XAttribute("CurrencyFromType", CurrencyFromType) : null,
            MinCurrencyValue != null ? XElement.Parse($"{MinCurrencyValue}") : null,
            MaxCurrencyValue != null ? XElement.Parse($"{MaxCurrencyValue}") : null,
            Date != null ? XElement.Parse($"{Date}") : null
        ).ToString();
    }
}

public class MaxCurrencyValue : CurrencyValueBase
{
    public MaxCurrencyValue() : base() { }

    public MaxCurrencyValue(XElement root) : base(root) { }

    public override string LocalName => "MaxCurrencyValue";
}

public class MinCurrencyValue : CurrencyValueBase
{
    public MinCurrencyValue() : base() { }

    public MinCurrencyValue(XElement root) : base(root) { }

    public override string LocalName => "MinCurrencyValue";
}

public abstract class CurrencyValueBase
{
    public CurrencyType CurrencyType { get; set; } = CurrencyType.Unset;
    public string Value = string.Empty;  

    public abstract string LocalName { get; }

    public CurrencyValueBase() { }

    public CurrencyValueBase(XElement root)
    {
        CurrencyType = root.Attribute("CurrencyType") is { Value: var ct } ? Enum.Parse<CurrencyType>(ct) : CurrencyType;
        Value = root.Value;
    }
    
    public override string ToString()
    {
        return new XElement(LocalName,
            CurrencyType != CurrencyType.Unset ? new XAttribute("CurrencyType", CurrencyType) : null,
            Value
        ).ToString();
    }
}

public class InformationalPricePerUnit : MeasurementBase
{
    public InformationalPricePerUnitType InformationalPricePerUnitType = InformationalPricePerUnitType.ProductPrice;
    public CurrencyValue CurrencyValue { get; set; } = new();

    public InformationalPricePerUnit() { }

    public InformationalPricePerUnit(XElement root) : base(root)
    {
        InformationalPricePerUnitType = root.Attribute("InformationalPricePerUnitType") is { Value: var ipput } ? Enum.Parse<InformationalPricePerUnitType>(ipput) : InformationalPricePerUnitType;
        CurrencyValue = root.Element("CurrencyValue") is { } cv ? new(cv) : CurrencyValue;
    }

    public override string LocalName => "InformationalPricePerUnit";

    public override string ToString()
    {
        return new XElement(LocalName,
            new XAttribute("InformationalPricePerUnitType", InformationalPricePerUnitType),
            XElement.Parse($"{CurrencyValue}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class PricePerUnit : MeasurementBase
{
    public CurrencyValue CurrencyValue { get; set; } = new();

    public PricePerUnit() { }

    public PricePerUnit(XElement root) : base(root)
    {
        CurrencyValue = root.Element("CurrencyValue") is { } cv ? new(cv) : CurrencyValue;
    }

    public override string LocalName => "PricePerUnit";

    public override string ToString()
    {
        return new XElement(LocalName,
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
    public QuantityTypeContext QuantityTypeContext { get; set; } = QuantityTypeContext.Unset;
    public AdjustmentType_Tare AdjustmentType { get; set; } = AdjustmentType_Tare.Unset;
    public MeasuringAgency MeasuringAgency { get; set; } = MeasuringAgency.Unset;
    public string? MeasuringMethod { get; set; } = null;
    public Value Value { get; set; } = new();
    public RangeMin? RangeMin { get; set; } = null;
    public RangeMax? RangeMax { get; set; } = null;

    public Quantity() { }

    public Quantity(XElement root)
    {
        QuantityType = root.Attribute("QuantityType") is { Value: var qt } ? Enum.Parse<QuantityType>(qt) : QuantityType;
        QuantityTypeContext = root.Attribute("QuantityTypeContext") is { Value: var qtc } ? Enum.Parse<QuantityTypeContext>(qtc) : QuantityTypeContext;
        AdjustmentType = root.Attribute("AdjustmentType") is { Value: var at } ? Enum.Parse<AdjustmentType_Tare>(at) : AdjustmentType;
        MeasuringAgency = root.Attribute("MeasuringAgency") is { Value: var ma } ? Enum.Parse<MeasuringAgency>(ma) : MeasuringAgency;
        MeasuringMethod = root.Attribute("MeasuringMethod")?.Value ?? MeasuringMethod;
        Value = root.Element("Value") is { } v ? new(v) : Value;
        RangeMin = root.Element("RangeMin") is { } rmin ? new(rmin) : RangeMin;
        RangeMax = root.Element("RangeMax") is { } rmax ? new(rmax) : RangeMax;
    }

    public override string ToString()
    {
        return new XElement("Quantity",
            new XAttribute("QuantityType", QuantityType),
            QuantityTypeContext != QuantityTypeContext.Unset ? new XAttribute("QuantityTypeContext", QuantityTypeContext) : null,
            AdjustmentType != AdjustmentType_Tare.Unset ? new XAttribute("AdjustmentType", AdjustmentType) : null,
            MeasuringAgency != MeasuringAgency.Unset ? new XAttribute("MeasuringAgency", MeasuringAgency) : null,
            MeasuringMethod != null ? new XAttribute("MeasuringMethod", MeasuringMethod) : null,
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class RangeMin : ValueBase
{
    public RangeMin() : base() { }

    public RangeMin(XElement root) : base(root) { }

    public override string LocalName => "RangeMin";
}

public class RangeMax : ValueBase
{
    public RangeMax() : base() { }

    public RangeMax(XElement root) : base(root) { }

    public override string LocalName => "RangeMax";
}

public class Value : ValueBase
{
    public Value() : base() { }

    public Value(XElement root) : base(root) { }

    public override string LocalName => "Value";
}

public abstract class ValueBase
{
    public UOM UOM { get; set; } = UOM.Unit;
    public string Value { get; set; } = string.Empty;  

    public abstract string LocalName { get; }

    public ValueBase() { }

    public ValueBase(XElement root)
    {
        UOM = root.Attribute("UOM") is { Value: var uom } ? Enum.Parse<UOM>(uom) : UOM;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement(LocalName,
            new XAttribute("UOM", UOM),
            Value
        ).ToString();
    }
}

public class DeliveryDateWindow
{
    public DeliveryDateType DeliveryDateType = DeliveryDateType.ActualArrivalDate;
    public DateTimeRange? DateTimeRange { get; set; } = null;
    public string? Month { get; set; } = null;
    public string? Week { get; set; } = null;
    public Date Date { get; set; } = new();
    public Time? Time { get; set; } = null;

    public DeliveryDateWindow() { }

    public DeliveryDateWindow(XElement root)
    {
        DeliveryDateType = root.Attribute("DeliveryDateType") is { Value: var ddt } ? Enum.Parse<DeliveryDateType>(ddt) : DeliveryDateType;
        DateTimeRange = root.Element("DateTimeRange") is { } dtr ? new(dtr) : DateTimeRange;
        Month = root.Element("Month")?.Value ?? Month;
        Week = root.Element("Week")?.Value ?? Week;
        Date = root.Element("Date") is { } d ? new(d) : Date;
        Time = root.Element("Time") is { } t ? new(t) : Time;
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
    public DateTimeFrom DateTimeFrom { get; set; } = new();
    public DateTimeTo DateTimeTo { get; set; } = new();

    public DateTimeRange() { }

    public DateTimeRange(XElement root)
    {
        DateTimeFrom = root.Element("DateTimeFrom") is { } dtf ? new(dtf) : DateTimeFrom;
        DateTimeTo = root.Element("DateTimeTo") is { } dtt ? new(dtt) : DateTimeTo;
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
    public Date Date { get; set; } = new();
    public Time? Time { get; set; } = null;

    public DateTimeTo() { }

    public DateTimeTo(XElement root)
    {
        Date = root.Element("Date") is { } d ? new(d) : Date;
        Time = root.Element("Time") is { } t ? new(t) : Time;
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
    public Date Date { get; set; } = new();
    public Time? Time { get; set; } = null;

    public DateTimeFrom() { }

    public DateTimeFrom(XElement root)
    {
        Date = root.Element("Date") is { } d ? new(d) : Date;
        Time = root.Element("Time") is { } t ? new(t) : Time;
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
    public DeliveryStatusType DeliveryStatusType { get; set; } = DeliveryStatusType.Unset;
    public DeliveryLastDateOfChange? DeliveryLastDateOfChange { get; set; } = null;

    public DeliveryStatus() { }

    public DeliveryStatus(XElement root)
    {
        DeliveryStatusType = root.Attribute("DeliveryStatusType") is { Value: var dst } ? Enum.Parse<DeliveryStatusType>(dst) : DeliveryStatusType;
        DeliveryLastDateOfChange = root.Element("DeliveryLastDateOfChange") is { } dldoc ? new(dldoc) : DeliveryLastDateOfChange;
    }

    public override string ToString()
    {
        return new XElement("DeliveryStatus",
            DeliveryStatusType != DeliveryStatusType.Unset ? new XAttribute("DeliveryStatusType", DeliveryStatusType) : null,
            DeliveryLastDateOfChange != null ? XElement.Parse($"{DeliveryLastDateOfChange}") : null
        ).ToString();
    }
}

public class DeliveryLastDateOfChange
{
    public Date Date { get; set; } = new();
    public Time? Time { get; set; } = null;

    public DeliveryLastDateOfChange() { }

    public DeliveryLastDateOfChange(XElement root)
    {
        Date = root.Element("Date") is { } d ? new(d) : Date;
        Time = root.Element("Time") is { } t ? new(t) : Time;
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
    public ProductionLastDateOfChange? ProductionLastDateOfChange { get; set; } = null;

    public ProductionStatus() { }

    public ProductionStatus(XElement root)
    {
        ProductionStatusType = root.Attribute("ProductionStatusType") is { Value: var pst } ? Enum.Parse<ProductionStatusType>(pst) : ProductionStatusType;
        ProductionLastDateOfChange = root.Element("ProductionLastDateOfChange") is { } pldoc ? new(pldoc) : ProductionLastDateOfChange;
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
    public Date Date { get; set; } = new();
    public Time? Time { get; set; } = null;

    public ProductionLastDateOfChange() { }

    public ProductionLastDateOfChange(XElement root)
    {
        Date = root.Element("Date") is { } d ? new(d) : Date;
        Time = root.Element("Time") is { } t ? new(t) : Time;
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
    public ShipToParty ShipToParty { get; set; } = new();
    public LocationCode? LocationCode { get; set; } = null;
    public TermsOfDelivery? TermsOfDelivery { get; set; } = null;
    public DeliveryRouteCode? DeliveryRouteCode { get; set; } = null;

    public ShipToCharacteristics() { }

    public ShipToCharacteristics(XElement root)
    {
        ShipToParty = root.Element("ShipToParty") is { } stp ? new(stp) : ShipToParty;
        LocationCode = root.Element("LocationCode") is { } lc ? new(lc) : LocationCode;
        TermsOfDelivery = root.Element("TermsOfDelivery") is { } tod ? new(tod) : TermsOfDelivery;
        DeliveryRouteCode = root.Element("DeliveryRouteCode") is { } drc ? new(drc) : DeliveryRouteCode;
    }

    public override string ToString()
    {
        return new XElement("ShipToCharacteristics",
            XElement.Parse($"{ShipToParty}"),
            LocationCode != null ? XElement.Parse($"{LocationCode}") : null,
            TermsOfDelivery != null ? XElement.Parse($"{TermsOfDelivery}") : null,
            DeliveryRouteCode != null ? XElement.Parse($"{DeliveryRouteCode}") : null
        ).ToString();
    }
}

public class ShipToParty : Party
{
    public ShipToParty() : base() { }
    
    public ShipToParty(XElement root) : base(root) { }

    public override string LocalName => "ShipToParty";
}

public class LocationCode : AgencyValueBase
{
    public LocationCode() : base() { Agency = PapiNet.Agency.Other; }

    public LocationCode(XElement root) : base(root) { }

    public override string LocalName => "LocationCode";
}

public class DeliveryRouteCode : AgencyValueBase
{
    public DeliveryRouteCode() : base() { Agency = PapiNet.Agency.Other; }

    public DeliveryRouteCode(XElement root) : base(root) { }

    public override string LocalName => "DeliveryRouteCode";
}

public class TermsOfDelivery
{
    public IncotermsLocation? IncotermsLocation { get; set; } = null;
    public ShipmentMethodOfPayment? ShipmentMethodOfPayment { get; set; } = null;
    public string? FreightPayableAt { get; set; } = null;
    public string? AdditionalText { get; set; } = null;

    public TermsOfDelivery() { }

    public TermsOfDelivery(XElement root)
    {
        IncotermsLocation = root.Element("IncotermsLocation") is { } il ? new(il) : IncotermsLocation;
        ShipmentMethodOfPayment = root.Element("ShipmentMethodOfPayment") is { } smop ? new(smop) : ShipmentMethodOfPayment;
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
    public LocationQualifier LocationQualifier { get; set; } = LocationQualifier.Unset;
    public Method? Method { get; set; } = null;
    public string Value = string.Empty;  

    public ShipmentMethodOfPayment() { }

    public ShipmentMethodOfPayment(XElement root)
    {
        LocationQualifier = root.Attribute("LocationQualifier") is { Value: var lq } ? Enum.Parse<LocationQualifier>(lq) : LocationQualifier;
        Method = root.Attribute("Method") is { Value: var m } ? Enum.Parse<Method>(m) : Method;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("ShipmentMethodOfPayment",
            LocationQualifier != LocationQualifier.Unset ? new XAttribute("LocationQualifier", LocationQualifier) : null,
            Method != null ? new XAttribute("Method", Method) : null,
            Value
        ).ToString();
    }
}

public class IncotermsLocation
{
    public Incoterms Incoterms = Incoterms.Other;
    public string? IncotermsVersion { get; set; } = null;
    public string Value = string.Empty;  

    public IncotermsLocation() { }

    public IncotermsLocation(XElement root)
    {
        Incoterms = root.Attribute("Incoterms") is { Value: var i } ? Enum.Parse<Incoterms>(i) : Incoterms;
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

public abstract class Party
{
    private readonly ILogger<DeliveryMessageWood>? _logger;
    public PartyType PartyType { get; set; } = PartyType.Unset;
    public LogisticsRole LogisticsRole { get; set; } = LogisticsRole.Unset;
    public List<PartyIdentifier> PartyIdentifier { get; } = [];
    public NameAddress NameAddress { get; set; } = new();
    public string? URL { get; set; } = null;
    public CommonContact? CommonContact { get; set; } = null;
    public string Value = string.Empty;  

    public abstract string LocalName { get; }

    public Party(ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;

        _logger?.LogInformation($"New {LocalName} has been added.");
    }

    public Party(XElement root, ILogger<DeliveryMessageWood>? logger = null)
    {
        _logger = logger;
        PartyType = root.Attribute("PartyType") is { Value: var pt } ? Enum.Parse<PartyType>(pt) : PartyType;
        LogisticsRole = root.Attribute("LogisticsRole") is { Value: var lr } ? Enum.Parse<LogisticsRole>(lr) : LogisticsRole;
        PartyIdentifier = [.. root.Elements("PartyIdentifier").Select(e => new PartyIdentifier(e))];
        NameAddress = root.Element("NameAddress") is { } na ? new(na) : NameAddress;
        URL = root.Element("URL")?.Value ?? URL;
        CommonContact = root.Element("CommonContact") is { } cc ? new(cc) : CommonContact;
        Value = root.Value;

        _logger?.LogInformation($"New {LocalName} has been added.");
    }

    public override string ToString()
    {
        return new XElement(LocalName,
            PartyType != PartyType.Unset ? new XAttribute("PartyType", PartyType) : null,
            LogisticsRole != LogisticsRole.Unset ? new XAttribute("LogisticsRole", LogisticsRole) : null,
            PartyIdentifier.Select(identifier => XElement.Parse($"{identifier}")),
            XElement.Parse($"{NameAddress}"),
            URL != null ? new XElement("URL", URL) : null,
            CommonContact != null ? XElement.Parse($"{CommonContact}") : null
        ).ToString();
    }
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

    public CommonContact() { }

    public CommonContact(XElement root)
    {
        ContactType = root.Attribute("ContactType") is { Value: var ct } ? Enum.Parse<ContactType>(ct) : ContactType;
        ContactName = root.Element("ContactName")?.Value ?? ContactName;
        ContactIdentifier = root.Element("ContactIdentifier")?.Value ?? ContactIdentifier;
        Telephone = root.Element("Telephone")?.Value ?? Telephone;
        MobilePhone = root.Element("MobilePhone")?.Value ?? MobilePhone;
        Email = root.Element("Email")?.Value ?? Email;
        Fax = root.Element("Fax")?.Value ?? Fax;
        GPSCoordinates = root.Element("GPSCoordinates") is { } gpsc ? new(gpsc) : GPSCoordinates;
        MapCoordinates = root.Element("MapCoordinates") is { } mp ? new(mp) : MapCoordinates;
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
    public MapReferenceSystem MapReferenceSystem = MapReferenceSystem.NTF;
    public MapCoordinateType MapCoordinateType = MapCoordinateType.UTM;
    public string Coordinates = string.Empty;
    public string? Altitude { get; set; } = null;

    public MapCoordinates() { }

    public MapCoordinates(XElement root)
    {
        MapReferenceSystem = root.Attribute("MapReferenceSystem") is { Value: var mrs } ? Enum.Parse<MapReferenceSystem>(mrs) : MapReferenceSystem;
        MapCoordinateType = root.Attribute("MapCoordinateType") is { Value: var mct } ? Enum.Parse<MapCoordinateType>(mct) : MapCoordinateType;
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

    public NameAddress() { }

    public NameAddress(XElement root)
    {
        CommunicationRole = root.Attribute("CommunicationRole") is { Value: var cr } ? Enum.Parse<CommunicationRole>(cr) : CommunicationRole;
        Name1 = root.Element("Name1")?.Value ?? Name1;
        Name2 = root.Element("Name2")?.Value ?? Name2;
        Name3 = root.Element("Name3")?.Value ?? Name3;
        OrganisationUnit = root.Element("OrganisationUnit")?.Value ?? OrganisationUnit;
        Address1 = root.Element("Address1")?.Value ?? Address1;
        Address2 = root.Element("Address2")?.Value ?? Address2;
        Address3 = root.Element("Address3")?.Value ?? Address3;
        Address4 = root.Element("Address4")?.Value ?? Address4;
        City = root.Element("City")?.Value ?? City;
        County = root.Element("County")?.Value ?? County;
        StateOrProvince = root.Element("StateOrProvince")?.Value ?? StateOrProvince;
        PostalCode = root.Element("PostalCode")?.Value ?? PostalCode;
        Country = root.Element("Country") is { } c ? new(c) : Country;
        GPSCoordinates = root.Element("GPSCoordinates") is { } gpsc ? new(gpsc) : GPSCoordinates;
        MapCoordinates = root.Element("MapCoordinates") is { } mc ? new(mc) : MapCoordinates;
    }

    public override string ToString()
    {
        return new XElement("NameAddress",
            CommunicationRole != CommunicationRole.Unset ? new XAttribute("CommunicationRole", CommunicationRole) : null,
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
            Country != null ? XElement.Parse($"{Country}") : null,
            GPSCoordinates != null ? XElement.Parse($"{GPSCoordinates}") : null,
            MapCoordinates != null ? XElement.Parse($"{MapCoordinates}") : null
        ).ToString();
    }
}

public class Country
{
    public ISOCountryCode ISOCountryCode { get; set; } = ISOCountryCode.Unset;
    public string Value = string.Empty;  

    public Country() { }

    public Country(XElement root)
    {
        ISOCountryCode = root.Attribute("ISOCountryCode") is { Value: var v } ? Enum.Parse<ISOCountryCode>(v) : ISOCountryCode;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("Country",
            ISOCountryCode != ISOCountryCode.Unset ? new XAttribute("ISOCountryCode", ISOCountryCode) : null,
            Value
        ).ToString();
    }
}

public class GPSCoordinates
{
    public GPSSystem GPSSystem { get; set; } = GPSSystem.Unset;
    public string Latitude = string.Empty;
    public string Longitude = string.Empty;
    public string? Height { get; set; } = null;

    public GPSCoordinates() { }

    public GPSCoordinates(XElement root)
    {
        GPSSystem = root.Attribute("GPSSystem") is { Value: var gpss } ? Enum.Parse<GPSSystem>(gpss) : GPSSystem;
        Latitude = root.Element("Latitude")?.Value ?? Latitude;
        Longitude = root.Element("Longitude")?.Value ?? Longitude;
        Height = root.Element("Height")?.Value ?? Height;
    }

    public override string ToString()
    {
        return new XElement("GPSCoordinates",
            GPSSystem != GPSSystem.Unset ? new XAttribute("GPSSystem", GPSSystem) : null,
            new XElement("Latitude", Latitude),
            new XElement("Longitude", Longitude),
            Height != null ? new XElement("Height", Height) : null
        ).ToString();
    }
}

public class PartyIdentifier
{
    public PartyIdentifierType PartyIdentifierType { get; set; } = PartyIdentifierType.Other;
    public Agency Agency { get; set; } = Agency.Unset;
    public string Value { get; set; } = string.Empty;  

    public PartyIdentifier() { }

    public PartyIdentifier(XElement root)
    {
        PartyIdentifierType = root.Attribute("PartyIdentifierType")?.Value.ToEnum<PartyIdentifierType>() ?? PartyIdentifierType;
        Agency = root.Attribute("Agency")?.Value.ToEnum<Agency>() ?? Agency;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("PartyIdentifier",
            new XAttribute("PartyIdentifierType", PartyIdentifierType.GetMemberValue()),
            Agency != Agency.Unset ? new XAttribute("Agency", Agency.GetMemberValue()) : null,
            Value
        ).ToString();
    }
}

public class DocumentReferenceInformation
{
    public string DocumentReferenceID = string.Empty;
    public string? DocumentReferenceIDLineItemNumber { get; set; } = null;
    public Date? Date { get; set; } = null;
    public Time? Time { get; set; } = null;
    public string? NumberOfDocumentsRequired { get; set; } = null;

    public DocumentReferenceInformation() { }

    public DocumentReferenceInformation(XElement root)
    {
        DocumentReferenceID = root.Element("DocumentReferenceID")?.Value ?? DocumentReferenceID;
        DocumentReferenceIDLineItemNumber = root.Element("DocumentReferenceIDLineItemNumber")?.Value ?? DocumentReferenceIDLineItemNumber;
        Date = root.Element("Date") is XElement date ? new Date(date) : Date;
        Time = root.Element("Time") is XElement time ? new Time(time) : Time;
        NumberOfDocumentsRequired = root.Element("NumberOfDocumentsRequired")?.Value ?? NumberOfDocumentsRequired;
    }

    public override string ToString()
    {
        return new XElement("DocumentReferenceInformation",
            new XElement("DocumentReferenceID", DocumentReferenceID),
            DocumentReferenceIDLineItemNumber != null ? new XElement("DocumentReferenceIDLineItemNumber", DocumentReferenceIDLineItemNumber) : null,
            Date != null ? XElement.Parse($"{Date}") : null,
            Time != null ? XElement.Parse($"{Time}") : null,
            NumberOfDocumentsRequired != null ? new XElement("NumberOfDocumentsRequired", NumberOfDocumentsRequired) : null
        ).ToString();
    }
}

public class DeliveryMessageReference
{
    public ReferenceType DeliveryMessageReferenceType = ReferenceType.Other;
    public AssignedBy AssignedBy = AssignedBy.Unset;
    public string Value = string.Empty;

    public DeliveryMessageReference() { }

    public DeliveryMessageReference(XElement root)
    {
        DeliveryMessageReferenceType = root.Attribute("DeliveryMessageReferenceType")?.Value.ToEnum<ReferenceType>() ?? DeliveryMessageReferenceType;
        AssignedBy = root.Attribute("AssignedBy")?.Value.ToEnum<AssignedBy>() ?? AssignedBy;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("DeliveryMessageReference",
            new XAttribute("DeliveryMessageReferenceType", DeliveryMessageReferenceType),
            AssignedBy != AssignedBy.Unset ? new XAttribute("AssignedBy", AssignedBy) : null,
            Value
        ).ToString();
    }
}

public abstract class AgencyValueBase
{
    public Agency Agency { get; set; } = Agency.Unset;
    public string Value = string.Empty;  

    public abstract string LocalName { get; }

    public AgencyValueBase() { }

    public AgencyValueBase(XElement root)
    {
        Agency = root.Attribute("Agency") is { Value: var a } ? Enum.Parse<Agency>(a) : Agency;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement(LocalName,
            Agency != Agency.Unset ? new XAttribute("Agency", Agency) : null,
            Value
        ).ToString();
    }
}

public abstract class AssignedByReferenceValueBase
{
    public AssignedBy AssignedBy { get; set; } = AssignedBy.Unset;
    public string Value = string.Empty;  

    public abstract string LocalName { get; }

    public AssignedByReferenceValueBase() { }

    public AssignedByReferenceValueBase(XElement root)
    {
        AssignedBy = root.Attribute("AssignedBy") is { Value: var ab } ? Enum.Parse<AssignedBy>(ab) : AssignedBy;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement(LocalName,
            AssignedBy != AssignedBy.Unset ? new XAttribute("AssignedBy", AssignedBy) : null
        ).ToString();
    }
}