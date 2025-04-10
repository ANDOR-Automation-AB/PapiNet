using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Xml.PapiNet.V2R31;

public class DeliveryMessageWood
{
    public DeliveryMessageType_Wood Type { get; set; }
    public DeliveryMessageStatusType Status{ get; set; }
    public DeliveryMessageWoodHeader Header { get; set; } = new();
    public BindingList<DeliveryMessageShipment?> Shipment { get; set; } = [];

    public static implicit operator DeliveryMessageWood?(XElement? e) => e == null ? null : new()
    {
        Type = e.Attribute("DeliveryMessageType")!.Value.ParseMember<DeliveryMessageType_Wood>(),
        Status = e.Attribute("DeliveryMessageStatusType")!.Value.ParseMember<DeliveryMessageStatusType>(),
        Header = e.Element("DeliveryMessageWoodHeader")!,
        Shipment = new([.. e.Elements("DeliveryMessageShipment").Select(e => e)])
    };
    public static implicit operator XElement(DeliveryMessageWood o) => new(
        "DeliveryMessageWood",
        new XAttribute("DeliveryMessageType", o.Type.GetMemberValue()),
        new XAttribute("DeliveryMessageStatusType", o.Status.GetMemberValue()),
        (XElement)o.Header,
        o.Shipment.Select(i => (XElement)i!)
    );

    public override string ToString() => ((XElement)this).ToString();
}

public class DeliveryMessageShipment
{
    public BindingList<DeliveryMessageProductGroup?> ProductGroup { get; set; } = [];

    public static implicit operator DeliveryMessageShipment?(XElement? e) => e == null ? null : new()
    {
        ProductGroup = new([.. e.Elements("DeliveryMessageProductGroup").Select(e => e)])
    };
    public static implicit operator XElement(DeliveryMessageShipment o) => new(
        "DeliveryMessageShipment",
        o.ProductGroup.Select(i => (XElement)i!)
    );

    public override string ToString() => ((XElement)this).ToString();
}

public class DeliveryMessageProductGroup
{
    public BindingList<DeliveryShipmentLineItem?> Item { get; set; } = [];

    public static implicit operator DeliveryMessageProductGroup?(XElement? e) => e == null ? null : new()
    {
        Item = new([.. e.Elements("DeliveryShipmentLineItem").Select(e => e)])
    };
    public static implicit operator XElement(DeliveryMessageProductGroup o) => new(
        "DeliveryMessageProductGroup",
        o.Item.Select(i => (XElement)i!)
    );

    public override string ToString() => ((XElement)this).ToString();
}

public class DeliveryShipmentLineItem
{
    public DeliveryShipmentLineItemNumber Number { get; set; } = new();
    public PurchaseOrderInformation? Order { get; set; } = null;
    public PurchaseOrderLineItemNumber? OrderItemNumber { get; set; } = null;
    public BindingList<DeliveryMessageReference?> Reference { get; set; } = [];
    public Product Product { get; set; } = new();
    public BindingList<TransportPackageInformation?> Package { get; set; } = [];

    public static implicit operator DeliveryShipmentLineItem?(XElement? e) => e == null ? null : new()
    {
        Number = e.Element("DeliveryShipmentLineItemNumber")!,
        Order = e.Element("PurchaseOrderInformation"),
        OrderItemNumber = e.Element("PurchaseOrderLineItemNumber").As<PurchaseOrderLineItemNumber>(),
        Reference = new([.. e.Elements("DeliveryMessageReference").Select(e => e)]),
        Product = e.Element("Product")!
    };
    public static implicit operator XElement(DeliveryShipmentLineItem o) => new(
        "DeliveryShipmentLineItem",
        (XElement)o.Number,
        o.Order != null ? (XElement)o.Order : null,
        o.OrderItemNumber != null ? (XElement)o.OrderItemNumber : null,
        o.Reference.Select(i => (XElement)i!),
        (XElement)o.Product,
        o.Package.Select(i => (XElement)i!)
    );

    public override string ToString() => ((XElement)this).ToString();
}

public class TransportPackageInformation
{
    public static implicit operator TransportPackageInformation(XElement e) => new()
    {

    };
    public static implicit operator XElement(TransportPackageInformation o) => new(
        "TransportPackageInformation"
    );

    public override string ToString() => ((XElement)this).ToString();
}

public class Product
{
    public static implicit operator Product?(XElement? e) => e == null ? null : new()
    {

    };
    public static implicit operator XElement(Product o) => new(
        "Product"
    );

    public override string ToString() => ((XElement)this).ToString();
}

public class PurchaseOrderLineItemNumber
{
    public string Value { get; set; } = string.Empty;

    public static implicit operator PurchaseOrderLineItemNumber?(XElement? e) => e == null ? null : new()
    {
        Value = e.Value
    };
    public static implicit operator XElement(PurchaseOrderLineItemNumber o) => new(
        "PurchaseOrderLineItemNumber",
        o.Value
    );

    public static implicit operator string(PurchaseOrderLineItemNumber o) => o.Value;
    public static implicit operator PurchaseOrderLineItemNumber(string s) => new() { Value = s };

    public override string ToString() => ((XElement)this).ToString();
}

public class PurchaseOrderInformation
{
    public PurchaseOrderNumber? Number { get; set; } = null;

    public static implicit operator PurchaseOrderInformation?(XElement? e) => e == null ? null : new()
    {
        Number = e.Element("PurchaseOrderNumber")
    };
    public static implicit operator XElement(PurchaseOrderInformation o) => new(
        "PurchaseOrderInformation",
        o.Number != null ? (XElement)o.Number : null
    );
}

public class PurchaseOrderNumber
{
    public string Value { get; set; } = string.Empty;

    public static implicit operator PurchaseOrderNumber(XElement e) => new()
    {
        Value = e.Value
    };
    public static implicit operator XElement(PurchaseOrderNumber o) => new(
        "PurchaseOrderNumber",
        o.Value
    );

    public static implicit operator string(PurchaseOrderNumber o) => o.Value;
    public static implicit operator PurchaseOrderNumber(string s) => new() { Value = s };

    public override string ToString() => ((XElement)this).ToString();
}

public class DeliveryShipmentLineItemNumber
{
    public string Value { get; set; } = string.Empty;

    public static implicit operator DeliveryShipmentLineItemNumber(XElement e) => new()
    {
        Value = e.Value
    };
    public static implicit operator XElement(DeliveryShipmentLineItemNumber o) => new(
        "DeliveryShipmentLineItemNumber",
        o.Value
    );

    public static implicit operator string(DeliveryShipmentLineItemNumber o) => o.Value;
    public static implicit operator DeliveryShipmentLineItemNumber(string s) => new() { Value = s };

    public override string ToString() => ((XElement)this).ToString();
}

public enum DeliveryMessageType_Wood
{
    DeliveryMessage,
    InitialShipmentAdvice,
    LoadingOrder,
    PackingSpecification,
    ShipmentAdvice,
}

public enum DeliveryMessageStatusType
{
    Original,
    Cancelled,
    Replaced,
}

public class DeliveryMessageWoodHeader
{
    public DeliveryMessageNumber Number { get; set; } = new();
    public DeliveryMessageDate Date { get; set; } = new();
    public BindingList<DeliveryMessageReference> Reference { get; set; } = [];
    public BuyerParty Buyer { get; set; } = new();
    public SupplierParty Supplier { get; set; } = new();
    public BindingList<OtherParty> OtherParty { get; set; } = [];
    public SenderParty? Sender { get; set; } = null;
    public ReceiverParty? Receiver { get; set; } = null;
    public BindingList<ShipToInformation> ShipTo { get; set; } = [];

    public static implicit operator DeliveryMessageWoodHeader(XElement e) => new()
    {
        Number = (DeliveryMessageNumber)e.Element("DeliveryMessageNumber")!,
        Date = (DeliveryMessageDate)e.Element("DeliveryMessageDate")!,
        Reference = new([.. e.Elements("DeliveryMessageReference").Select(e => (DeliveryMessageReference)e)]),
        Buyer = (BuyerParty)e.Element("BuyerParty")!,
        Supplier = (SupplierParty)e.Element("SupplierParty")!,
        OtherParty = new([.. e.Elements("OtherParty").Select(e => (OtherParty)e)]),
        Sender = e.Element("SenderParty") is XElement s ? (SenderParty)s : null,
        Receiver = e.Element("ReceiverParty") is XElement r ? (ReceiverParty)r : null,
        ShipTo = new([.. e.Elements("ShipToInformation").Select(e => (ShipToInformation)e)])
    };
    public static implicit operator XElement(DeliveryMessageWoodHeader o) => new(
        "DeliveryMessageWoodHeader",
        (XElement)o.Number,
        (XElement)o.Date,
        o.Reference.Select(i => (XElement)i),
        (XElement)o.Buyer,
        (XElement)o.Supplier,
        o.OtherParty.Select(i => (XElement)i),
        o.Sender != null ? (XElement)o.Sender : null,
        o.Receiver != null ? (XElement)o.Receiver : null,
        o.ShipTo.Select(i => (XElement)i)
    );

    public override string ToString() => ((XElement)this).ToString();
}

public class ShipToInformation
{
    public ShipToCharacteristics Characteristics { get; set; } = new();

    public static implicit operator ShipToInformation(XElement e) => new()
    {
        Characteristics = (ShipToCharacteristics)e.Element("ShipToCharacteristics")!
    };
    public static implicit operator XElement(ShipToInformation o) => new(
        "ShipToInformation",
        (XElement)o.Characteristics
    );
}

public class ShipToCharacteristics
{
    public ShipToParty Party { get; set; } = new();
    public TermsOfDelivery? Terms { get; set; } = null;

    public static implicit operator ShipToCharacteristics(XElement e) => new()
    {
        Party = (ShipToParty)e.Element("ShipToParty")!,
        Terms = e.Element("TermsOfDelivery") is XElement t ? (TermsOfDelivery)t : null
    };
    public static implicit operator XElement(ShipToCharacteristics o) => new(
        "ShipToCharacteristics",
        (XElement)o.Party,
        o.Terms != null ? (XElement)o.Terms : null
    );

    public override string ToString() => ((XElement)this).ToString();
}

public class TermsOfDelivery
{
    public IncotermsLocation Location { get; set; } = new();
    public BindingList<AdditionalText> Text { get; set; } = [];

    public static implicit operator TermsOfDelivery(XElement e) => new()
    {
        Location = (IncotermsLocation)e.Element("IncotermsLocation")!,
        Text = new([.. e.Elements("AdditionalText").Select(e => (AdditionalText)e)])
    };
    public static implicit operator XElement(TermsOfDelivery o) => new(
        "TermsOfDelivery",
        (XElement)o.Location,
        o.Text.Select(i => (XElement)i)
    );

    public override string ToString() => ((XElement)this).ToString();
}

public class AdditionalText
{
    public string Value { get; set; } = string.Empty;

    public static implicit operator AdditionalText(XElement e) => new()
    {
        Value = e.Value
    };
    public static implicit operator XElement(AdditionalText o) => new(
        "AdditionalText",
        o.Value
    );

    public static implicit operator string(AdditionalText o) => o.Value;
    public static implicit operator AdditionalText(string s) => new() { Value = s };

    public override string ToString() => ((XElement)this).ToString();
}

public class IncotermsLocation
{
    public Incoterms Incoterms { get; set; }
    public IncotermsVersion? IncotermsVersion { get; set; }
    public string Value { get; set; } = string.Empty;

    public static implicit operator IncotermsLocation(XElement e) => new()
    {
        Value = e.Value,
        Incoterms = e.Attribute("Incoterms")!.Value.ParseMember<Incoterms>(),
        IncotermsVersion = e.Attribute("IncotermsVersion")?.Value.ParseMember<IncotermsVersion>()
    };
    public static implicit operator XElement(IncotermsLocation o) => new(
        "IncotermsLocation",
        o.Value,
        new XAttribute("Incoterms", o.Incoterms.GetMemberValue()),
        o.IncotermsVersion != null ? new XAttribute("AssignedBy", o.IncotermsVersion.GetMemberValue()) : null
    );

    public override string ToString() => ((XElement)this).ToString();
}

public enum Incoterms
{
    [EnumMember(Value = "CFR")] CFR,
    [EnumMember(Value = "CIF")] CIF,
    [EnumMember(Value = "CIP")] CIP,
    [EnumMember(Value = "CPT")] CPT,
    [EnumMember(Value = "DAF")] DAF,
    [EnumMember(Value = "DDP")] DDP,
    [EnumMember(Value = "DDU")] DDU,
    [EnumMember(Value = "DEQ")] DEQ,
    [EnumMember(Value = "DES")] DES,
    [EnumMember(Value = "EXW")] EXW,
    [EnumMember(Value = "FAS")] FAS,
    [EnumMember(Value = "FCA")] FCA,
    [EnumMember(Value = "FOB")] FOB,
    [EnumMember(Value = "Other")] Other,
}

public enum IncotermsVersion
{
    [EnumMember(Value = "1980")] _1980,
    [EnumMember(Value = "1990")] _1990,
    [EnumMember(Value = "2000")] _2000,
    [EnumMember(Value = "20xx")] _20xx,
}

public class ShipToParty : Party
{
    public override string LocalName => "ShipToParty";

    public static implicit operator ShipToParty(XElement e) => new()
    {
        Type = e.Attribute("PartyType")?.Value.ParseMember<PartyType>(),
        Identifier = new([.. e.Elements("PartyIdentifier").Select(e => (PartyIdentifier)e)]),
        Address = (NameAddress)e.Element("PartyIdentifier")!
    };

    public override string ToString() => ((XElement)this).ToString();
}

public class ReceiverParty : Party
{
    public override string LocalName => "ReceiverParty";

    public static implicit operator ReceiverParty(XElement e) => new()
    {
        Type = e.Attribute("PartyType")?.Value.ParseMember<PartyType>(),
        Identifier = new([.. e.Elements("PartyIdentifier").Select(e => (PartyIdentifier)e)]),
        Address = (NameAddress)e.Element("PartyIdentifier")!
    };

    public override string ToString() => ((XElement)this).ToString();
}

public class SenderParty : Party
{
    public override string LocalName => "SenderParty";

    public static implicit operator SenderParty(XElement e) => new()
    {
        Type = e.Attribute("PartyType")?.Value.ParseMember<PartyType>(),
        Identifier = new([.. e.Elements("PartyIdentifier").Select(e => (PartyIdentifier)e)]),
        Address = (NameAddress)e.Element("PartyIdentifier")!
    };

    public override string ToString() => ((XElement)this).ToString();
}

public class BuyerParty : Party
{
    public override string LocalName => "BuyerParty";

    public static implicit operator BuyerParty(XElement e) => new()
    {
        Type = e.Attribute("PartyType")?.Value.ParseMember<PartyType>(),
        Identifier = new([.. e.Elements("PartyIdentifier").Select(e => (PartyIdentifier)e)]),
        Address = (NameAddress)e.Element("PartyIdentifier")!
    };

    public override string ToString() => ((XElement)this).ToString();
}

public class SupplierParty : Party
{
    public override string LocalName => "SupplierParty";

    public static implicit operator SupplierParty(XElement e) => new()
    {
        Type = e.Attribute("PartyType")?.Value.ParseMember<PartyType>(),
        Identifier = new([.. e.Elements("PartyIdentifier").Select(e => (PartyIdentifier)e)]),
        Address = (NameAddress)e.Element("PartyIdentifier")!
    };

    public override string ToString() => ((XElement)this).ToString();
}

public class OtherParty : Party
{
    public override string LocalName => "OtherParty";

    public static implicit operator OtherParty(XElement e) => new()
    {
        Type = e.Attribute("PartyType")?.Value.ParseMember<PartyType>(),
        Identifier = new([.. e.Elements("PartyIdentifier").Select(e => (PartyIdentifier)e)]),
        Address = (NameAddress)e.Element("PartyIdentifier")!
    };

    public override string ToString() => ((XElement)this).ToString();
}

public abstract class Party
{
    public abstract string LocalName { get; }
    public PartyType? Type { get; set; } = null;
    public BindingList<PartyIdentifier> Identifier { get; set; } = [];
    public NameAddress Address { get; set; } = new();

    public static implicit operator XElement(Party o) => new(
        o.LocalName,
        o.Type != null ? new XAttribute("PartyType", o.Type) : null,
        o.Identifier.Select(i => (XElement)i),
        (XElement)o.Address
    );

    public override string ToString() => ((XElement)this).ToString();
}

public enum PartyType
{
    [EnumMember(Value = "Bank")] Bank,
    [EnumMember(Value = "BillTo")] BillTo,
    [EnumMember(Value = "BorderCrossing")] BorderCrossing,
    [EnumMember(Value = "Broker")] Broker,
    [EnumMember(Value = "Buyer")] Buyer,
    [EnumMember(Value = "BuyerAgent")] BuyerAgent,
    [EnumMember(Value = "Carrier")] Carrier,
    [EnumMember(Value = "CarrierAssignmentResponsible")] CarrierAssignmentResponsible,
    [EnumMember(Value = "ComponentVendor")] ComponentVendor,
    [EnumMember(Value = "Consignee")] Consignee,
    [EnumMember(Value = "Consignor")] Consignor,
    [EnumMember(Value = "Consuming")] Consuming,
    [EnumMember(Value = "Converter")] Converter,
    [EnumMember(Value = "CreditDepartment")] CreditDepartment,
    [EnumMember(Value = "CrossDock")] CrossDock,
    [EnumMember(Value = "CustomerFacility")] CustomerFacility,
    [EnumMember(Value = "CustomerStock")] CustomerStock,
    [EnumMember(Value = "Customs")] Customs,
    [EnumMember(Value = "CustomsForwarder")] CustomsForwarder,
    [EnumMember(Value = "DomesticForwarder")] DomesticForwarder,
    [EnumMember(Value = "EndUser")] EndUser,
    [EnumMember(Value = "ExportForwarder")] ExportForwarder,
    [EnumMember(Value = "ForestForwarder")] ForestForwarder,
    [EnumMember(Value = "Forwarder")] Forwarder,
    [EnumMember(Value = "FreightPayer")] FreightPayer,
    [EnumMember(Value = "Insurer")] Insurer,
    [EnumMember(Value = "Landowner")] Landowner,
    [EnumMember(Value = "LoadingOperator")] LoadingOperator,
    [EnumMember(Value = "LoggingArea")] LoggingArea,
    [EnumMember(Value = "MainCarrier")] MainCarrier,
    [EnumMember(Value = "Measurer")] Measurer,
    [EnumMember(Value = "Merchant")] Merchant,
    [EnumMember(Value = "Mill")] Mill,
    [EnumMember(Value = "NotifyParty")] NotifyParty,
    [EnumMember(Value = "OnBehalfOf")] OnBehalfOf,
    [EnumMember(Value = "OrderParty")] OrderParty,
    [EnumMember(Value = "OriginalSupplier")] OriginalSupplier,
    [EnumMember(Value = "Payee")] Payee,
    [EnumMember(Value = "Payer")] Payer,
    [EnumMember(Value = "PlaceFinalDestination")] PlaceFinalDestination,
    [EnumMember(Value = "PlaceOfAccept")] PlaceOfAccept,
    [EnumMember(Value = "PlaceOfDespatch")] PlaceOfDespatch,
    [EnumMember(Value = "PlaceOfDischarge")] PlaceOfDischarge,
    [EnumMember(Value = "PlaceOfLoading")] PlaceOfLoading,
    [EnumMember(Value = "PlaceOfReloading")] PlaceOfReloading,
    [EnumMember(Value = "Port")] Port,
    [EnumMember(Value = "PreCarrier")] PreCarrier,
    [EnumMember(Value = "PrinterFacility")] PrinterFacility,
    [EnumMember(Value = "ProFormaInvoice")] ProFormaInvoice,
    [EnumMember(Value = "Producer")] Producer,
    [EnumMember(Value = "RemitTo")] RemitTo,
    [EnumMember(Value = "Requestor")] Requestor,
    [EnumMember(Value = "RoadKeeper")] RoadKeeper,
    [EnumMember(Value = "RoadOwner")] RoadOwner,
    [EnumMember(Value = "SalesAgent")] SalesAgent,
    [EnumMember(Value = "SalesOffice")] SalesOffice,
    [EnumMember(Value = "Seller")] Seller,
    [EnumMember(Value = "ShipFromLocation")] ShipFromLocation,
    [EnumMember(Value = "ShipOwner")] ShipOwner,
    [EnumMember(Value = "ShipTo")] ShipTo,
    [EnumMember(Value = "SubCarrier")] SubCarrier,
    [EnumMember(Value = "Supplier")] Supplier,
    [EnumMember(Value = "Terminal")] Terminal,
    [EnumMember(Value = "TerminalOperator")] TerminalOperator,
    [EnumMember(Value = "UnloadingOperator")] UnloadingOperator,
    [EnumMember(Value = "Warehouse")] Warehouse,
    [EnumMember(Value = "WillAdvise")] WillAdvise,
    [EnumMember(Value = "Other")] Other,

}

public class NameAddress
{
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

    public static implicit operator NameAddress(XElement e) => new()
    {
        Name1 = e.Element("Name1")!.Value,
        Name2 = e.Element("Name2")?.Value ?? null,
        Name3 = e.Element("Name3")?.Value,
        OrganisationUnit = e.Element("OrganisationUnit")?.Value,
        Address1 = e.Element("Address1")?.Value,
        Address2 = e.Element("Address2")?.Value,
        Address3 = e.Element("Address3")?.Value,
        Address4 = e.Element("Address4")?.Value,
        City = e.Element("City")?.Value,
        County = e.Element("County")?.Value,
        StateOrProvince = e.Element("StateOrProvince")?.Value,
        PostalCode = e.Element("PostalCode")?.Value,
        Country = e.Element("Country") is XElement c ? (Country)c : null
    };
    public static implicit operator XElement(NameAddress o) => new(
        "NameAddress",
        new XElement("Name1", o.Name1),
        o.Name2 != null ? new XElement("Name2", o.Name2) : null,
        o.Name3 != null ? new XElement("Name3", o.Name3) : null,
        o.OrganisationUnit != null ? new XElement("OrganisationUnit", o.OrganisationUnit) : null,
        o.Address1 != null ? new XElement("Address1", o.Address1) : null,
        o.Address2 != null ? new XElement("Address2", o.Address2) : null,
        o.Address3 != null ? new XElement("Address3", o.Address3) : null,
        o.Address4 != null ? new XElement("Address4", o.Address4) : null,
        o.City != null ? new XElement("City", o.City) : null,
        o.County != null ? new XElement("County", o.County) : null,
        o.StateOrProvince != null ? new XElement("StateOrProvince", o.StateOrProvince) : null,
        o.PostalCode != null ? new XElement("PostalCode", o.PostalCode) : null,
        o.Country != null ? (XElement)o.Country : null
    );

    public override string ToString() => ((XElement)this).ToString();
}

public class Country
{
    public ISOCountryCode Code { get; set; }
    public string Value { get; set; } = string.Empty;

    public static implicit operator Country(XElement e) => new()
    {
        Value = e.Value,
        Code = e.Attribute("ISOCountryCode")!.Value.ParseMember<ISOCountryCode>()
    };
    public static implicit operator XElement(Country o) => new(
        "Country",
        o.Value,
        new XAttribute("ISOCountryCode", o.Code.GetMemberValue())
    );

    public override string ToString() => ((XElement)this).ToString();
}

public enum ISOCountryCode
{
    [EnumMember(Value = "AF")] AF,
    [EnumMember(Value = "AL")] AL,
    [EnumMember(Value = "DZ")] DZ,
    [EnumMember(Value = "AS")] AS,
    [EnumMember(Value = "AD")] AD,
    [EnumMember(Value = "AO")] AO,
    [EnumMember(Value = "AI")] AI,
    [EnumMember(Value = "AQ")] AQ,
    [EnumMember(Value = "AG")] AG,
    [EnumMember(Value = "AR")] AR,
    [EnumMember(Value = "AM")] AM,
    [EnumMember(Value = "AW")] AW,
    [EnumMember(Value = "AU")] AU,
    [EnumMember(Value = "AT")] AT,
    [EnumMember(Value = "AZ")] AZ,
    [EnumMember(Value = "BS")] BS,
    [EnumMember(Value = "BH")] BH,
    [EnumMember(Value = "BD")] BD,
    [EnumMember(Value = "BB")] BB,
    [EnumMember(Value = "BY")] BY,
    [EnumMember(Value = "BE")] BE,
    [EnumMember(Value = "BZ")] BZ,
    [EnumMember(Value = "BJ")] BJ,
    [EnumMember(Value = "BM")] BM,
    [EnumMember(Value = "BT")] BT,
    [EnumMember(Value = "BO")] BO,
    [EnumMember(Value = "BQ")] BQ,
    [EnumMember(Value = "BA")] BA,
    [EnumMember(Value = "BW")] BW,
    [EnumMember(Value = "BV")] BV,
    [EnumMember(Value = "BR")] BR,
    [EnumMember(Value = "IO")] IO,
    [EnumMember(Value = "BN")] BN,
    [EnumMember(Value = "BG")] BG,
    [EnumMember(Value = "BF")] BF,
    [EnumMember(Value = "BI")] BI,
    [EnumMember(Value = "CV")] CV,
    [EnumMember(Value = "KH")] KH,
    [EnumMember(Value = "CM")] CM,
    [EnumMember(Value = "CA")] CA,
    [EnumMember(Value = "KY")] KY,
    [EnumMember(Value = "CF")] CF,
    [EnumMember(Value = "TD")] TD,
    [EnumMember(Value = "CL")] CL,
    [EnumMember(Value = "CN")] CN,
    [EnumMember(Value = "CX")] CX,
    [EnumMember(Value = "CC")] CC,
    [EnumMember(Value = "CO")] CO,
    [EnumMember(Value = "KM")] KM,
    [EnumMember(Value = "CD")] CD,
    [EnumMember(Value = "CG")] CG,
    [EnumMember(Value = "CK")] CK,
    [EnumMember(Value = "CR")] CR,
    [EnumMember(Value = "HR")] HR,
    [EnumMember(Value = "CU")] CU,
    [EnumMember(Value = "CW")] CW,
    [EnumMember(Value = "CY")] CY,
    [EnumMember(Value = "CZ")] CZ,
    [EnumMember(Value = "CI")] CI,
    [EnumMember(Value = "DK")] DK,
    [EnumMember(Value = "DJ")] DJ,
    [EnumMember(Value = "DM")] DM,
    [EnumMember(Value = "DO")] DO,
    [EnumMember(Value = "EC")] EC,
    [EnumMember(Value = "EG")] EG,
    [EnumMember(Value = "SV")] SV,
    [EnumMember(Value = "GQ")] GQ,
    [EnumMember(Value = "ER")] ER,
    [EnumMember(Value = "EE")] EE,
    [EnumMember(Value = "SZ")] SZ,
    [EnumMember(Value = "ET")] ET,
    [EnumMember(Value = "FK")] FK,
    [EnumMember(Value = "FO")] FO,
    [EnumMember(Value = "FJ")] FJ,
    [EnumMember(Value = "FI")] FI,
    [EnumMember(Value = "FR")] FR,
    [EnumMember(Value = "GF")] GF,
    [EnumMember(Value = "PF")] PF,
    [EnumMember(Value = "TF")] TF,
    [EnumMember(Value = "GA")] GA,
    [EnumMember(Value = "GM")] GM,
    [EnumMember(Value = "GE")] GE,
    [EnumMember(Value = "DE")] DE,
    [EnumMember(Value = "GH")] GH,
    [EnumMember(Value = "GI")] GI,
    [EnumMember(Value = "GR")] GR,
    [EnumMember(Value = "GL")] GL,
    [EnumMember(Value = "GD")] GD,
    [EnumMember(Value = "GP")] GP,
    [EnumMember(Value = "GU")] GU,
    [EnumMember(Value = "GT")] GT,
    [EnumMember(Value = "GG")] GG,
    [EnumMember(Value = "GN")] GN,
    [EnumMember(Value = "GW")] GW,
    [EnumMember(Value = "GY")] GY,
    [EnumMember(Value = "HT")] HT,
    [EnumMember(Value = "HM")] HM,
    [EnumMember(Value = "VA")] VA,
    [EnumMember(Value = "HN")] HN,
    [EnumMember(Value = "HK")] HK,
    [EnumMember(Value = "HU")] HU,
    [EnumMember(Value = "IS")] IS,
    [EnumMember(Value = "IN")] IN,
    [EnumMember(Value = "ID")] ID,
    [EnumMember(Value = "IR")] IR,
    [EnumMember(Value = "IQ")] IQ,
    [EnumMember(Value = "IE")] IE,
    [EnumMember(Value = "IM")] IM,
    [EnumMember(Value = "IL")] IL,
    [EnumMember(Value = "IT")] IT,
    [EnumMember(Value = "JM")] JM,
    [EnumMember(Value = "JP")] JP,
    [EnumMember(Value = "JE")] JE,
    [EnumMember(Value = "JO")] JO,
    [EnumMember(Value = "KZ")] KZ,
    [EnumMember(Value = "KE")] KE,
    [EnumMember(Value = "KI")] KI,
    [EnumMember(Value = "KP")] KP,
    [EnumMember(Value = "KR")] KR,
    [EnumMember(Value = "KW")] KW,
    [EnumMember(Value = "KG")] KG,
    [EnumMember(Value = "LA")] LA,
    [EnumMember(Value = "LV")] LV,
    [EnumMember(Value = "LB")] LB,
    [EnumMember(Value = "LS")] LS,
    [EnumMember(Value = "LR")] LR,
    [EnumMember(Value = "LY")] LY,
    [EnumMember(Value = "LI")] LI,
    [EnumMember(Value = "LT")] LT,
    [EnumMember(Value = "LU")] LU,
    [EnumMember(Value = "MO")] MO,
    [EnumMember(Value = "MG")] MG,
    [EnumMember(Value = "MW")] MW,
    [EnumMember(Value = "MY")] MY,
    [EnumMember(Value = "MV")] MV,
    [EnumMember(Value = "ML")] ML,
    [EnumMember(Value = "MT")] MT,
    [EnumMember(Value = "MH")] MH,
    [EnumMember(Value = "MQ")] MQ,
    [EnumMember(Value = "MR")] MR,
    [EnumMember(Value = "MU")] MU,
    [EnumMember(Value = "YT")] YT,
    [EnumMember(Value = "MX")] MX,
    [EnumMember(Value = "FM")] FM,
    [EnumMember(Value = "MD")] MD,
    [EnumMember(Value = "MC")] MC,
    [EnumMember(Value = "MN")] MN,
    [EnumMember(Value = "ME")] ME,
    [EnumMember(Value = "MS")] MS,
    [EnumMember(Value = "MA")] MA,
    [EnumMember(Value = "MZ")] MZ,
    [EnumMember(Value = "MM")] MM,
    [EnumMember(Value = "NA")] NA,
    [EnumMember(Value = "NR")] NR,
    [EnumMember(Value = "NP")] NP,
    [EnumMember(Value = "NL")] NL,
    [EnumMember(Value = "NC")] NC,
    [EnumMember(Value = "NZ")] NZ,
    [EnumMember(Value = "NI")] NI,
    [EnumMember(Value = "NE")] NE,
    [EnumMember(Value = "NG")] NG,
    [EnumMember(Value = "NU")] NU,
    [EnumMember(Value = "NF")] NF,
    [EnumMember(Value = "MK")] MK,
    [EnumMember(Value = "MP")] MP,
    [EnumMember(Value = "NO")] NO,
    [EnumMember(Value = "OM")] OM,
    [EnumMember(Value = "PK")] PK,
    [EnumMember(Value = "PW")] PW,
    [EnumMember(Value = "PS")] PS,
    [EnumMember(Value = "PA")] PA,
    [EnumMember(Value = "PG")] PG,
    [EnumMember(Value = "PY")] PY,
    [EnumMember(Value = "PE")] PE,
    [EnumMember(Value = "PH")] PH,
    [EnumMember(Value = "PN")] PN,
    [EnumMember(Value = "PL")] PL,
    [EnumMember(Value = "PT")] PT,
    [EnumMember(Value = "PR")] PR,
    [EnumMember(Value = "QA")] QA,
    [EnumMember(Value = "RO")] RO,
    [EnumMember(Value = "RU")] RU,
    [EnumMember(Value = "RW")] RW,
    [EnumMember(Value = "RE")] RE,
    [EnumMember(Value = "BL")] BL,
    [EnumMember(Value = "SH")] SH,
    [EnumMember(Value = "KN")] KN,
    [EnumMember(Value = "LC")] LC,
    [EnumMember(Value = "MF")] MF,
    [EnumMember(Value = "PM")] PM,
    [EnumMember(Value = "VC")] VC,
    [EnumMember(Value = "WS")] WS,
    [EnumMember(Value = "SM")] SM,
    [EnumMember(Value = "ST")] ST,
    [EnumMember(Value = "SA")] SA,
    [EnumMember(Value = "SN")] SN,
    [EnumMember(Value = "RS")] RS,
    [EnumMember(Value = "SC")] SC,
    [EnumMember(Value = "SL")] SL,
    [EnumMember(Value = "SG")] SG,
    [EnumMember(Value = "SX")] SX,
    [EnumMember(Value = "SK")] SK,
    [EnumMember(Value = "SI")] SI,
    [EnumMember(Value = "SB")] SB,
    [EnumMember(Value = "SO")] SO,
    [EnumMember(Value = "ZA")] ZA,
    [EnumMember(Value = "GS")] GS,
    [EnumMember(Value = "SS")] SS,
    [EnumMember(Value = "ES")] ES,
    [EnumMember(Value = "LK")] LK,
    [EnumMember(Value = "SD")] SD,
    [EnumMember(Value = "SR")] SR,
    [EnumMember(Value = "SJ")] SJ,
    [EnumMember(Value = "SE")] SE,
    [EnumMember(Value = "CH")] CH,
    [EnumMember(Value = "SY")] SY,
    [EnumMember(Value = "TW")] TW,
    [EnumMember(Value = "TJ")] TJ,
    [EnumMember(Value = "TZ")] TZ,
    [EnumMember(Value = "TH")] TH,
    [EnumMember(Value = "TL")] TL,
    [EnumMember(Value = "TG")] TG,
    [EnumMember(Value = "TK")] TK,
    [EnumMember(Value = "TO")] TO,
    [EnumMember(Value = "TT")] TT,
    [EnumMember(Value = "TN")] TN,
    [EnumMember(Value = "TM")] TM,
    [EnumMember(Value = "TC")] TC,
    [EnumMember(Value = "TV")] TV,
    [EnumMember(Value = "TR")] TR,
    [EnumMember(Value = "UG")] UG,
    [EnumMember(Value = "UA")] UA,
    [EnumMember(Value = "AE")] AE,
    [EnumMember(Value = "GB")] GB,
    [EnumMember(Value = "UM")] UM,
    [EnumMember(Value = "US")] US,
    [EnumMember(Value = "UY")] UY,
    [EnumMember(Value = "UZ")] UZ,
    [EnumMember(Value = "VU")] VU,
    [EnumMember(Value = "VE")] VE,
    [EnumMember(Value = "VN")] VN,
    [EnumMember(Value = "VG")] VG,
    [EnumMember(Value = "VI")] VI,
    [EnumMember(Value = "WF")] WF,
    [EnumMember(Value = "EH")] EH,
    [EnumMember(Value = "YE")] YE,
    [EnumMember(Value = "ZM")] ZM,
    [EnumMember(Value = "ZW")] ZW,
    [EnumMember(Value = "AX")] AX,

}

public class PartyIdentifier
{
    public PartyIdentifierType Type { get; set; }
    public string Value { get; set; } = string.Empty;

    public static implicit operator PartyIdentifier(XElement e) => new()
    {
        Value = e.Value,
        Type = e.Attribute("PartyIdentifierType")!.Value.ParseMember<PartyIdentifierType>()
    };
    public static implicit operator XElement(PartyIdentifier o) => new(
        "PartyIdentifier",
        o.Value,
        new XAttribute("PartyIdentifierType", o.Type.GetMemberValue())
    );

    public override string ToString() => ((XElement)this).ToString();
}


public enum PartyIdentifierType
{
    [EnumMember(Value = "ABINumber")] ABINumber,
    [EnumMember(Value = "ABNNumber")] ABNNumber,
    [EnumMember(Value = "AFPA")] AFPA,
    [EnumMember(Value = "AssignedByAgency")] AssignedByAgency,
    [EnumMember(Value = "AssignedByBuyer")] AssignedByBuyer,
    [EnumMember(Value = "AssignedByReceiver")] AssignedByReceiver,
    [EnumMember(Value = "AssignedBySeller")] AssignedBySeller,
    [EnumMember(Value = "AssignedBySender")] AssignedBySender,
    [EnumMember(Value = "BankIdentificationCode")] BankIdentificationCode,
    [EnumMember(Value = "BankgiroAccountNumber")] BankgiroAccountNumber,
    [EnumMember(Value = "CABNumber")] CABNumber,
    [EnumMember(Value = "ChamberOfCommerceRegistrationNumber")] ChamberOfCommerceRegistrationNumber,
    [EnumMember(Value = "Domicile")] Domicile,
    [EnumMember(Value = "DunsNumber")] DunsNumber,
    [EnumMember(Value = "Duns4Number")] Duns4Number,
    [EnumMember(Value = "EANNumber")] EANNumber,
    [EnumMember(Value = "GlobalLocationNumber")] GlobalLocationNumber,
    [EnumMember(Value = "IBAN")] IBAN,
    [EnumMember(Value = "ISO6523Number")] ISO6523Number,
    [EnumMember(Value = "papiNetGlobalPartyIdentifier")] papiNetGlobalPartyIdentifier,
    [EnumMember(Value = "PatenteNumber")] PatenteNumber,
    [EnumMember(Value = "PayeeAccountNumber")] PayeeAccountNumber,
    [EnumMember(Value = "PayeeInternalAccountNumber")] PayeeInternalAccountNumber,
    [EnumMember(Value = "PayeeFinancialInstitution")] PayeeFinancialInstitution,
    [EnumMember(Value = "PayerAccountNumber")] PayerAccountNumber,
    [EnumMember(Value = "PayerFinancialInstitution")] PayerFinancialInstitution,
    [EnumMember(Value = "PlusgiroAccountNumber")] PlusgiroAccountNumber,
    [EnumMember(Value = "RegisterOfCompaniesSubscriptionNumber")] RegisterOfCompaniesSubscriptionNumber,
    [EnumMember(Value = "StandardAddressNumber")] StandardAddressNumber,
    [EnumMember(Value = "StandardCarrierAlphaCode")] StandardCarrierAlphaCode,
    [EnumMember(Value = "StockCapital")] StockCapital,
    [EnumMember(Value = "SWIFT")] SWIFT,
    [EnumMember(Value = "TaxIdentifier")] TaxIdentifier,
    [EnumMember(Value = "TradeRegNumber")] TradeRegNumber,
    [EnumMember(Value = "UN/ECE")] UN_ECE,
    [EnumMember(Value = "VATIdentificationNumber")] VATIdentificationNumber,
    [EnumMember(Value = "Other")] Other,
}

public class DeliveryMessageReference
{
    public ReferenceType Type { get; set; }
    public AssignedBy AssignedBy { get; set; }
    public string Value { get; set; } = string.Empty;

    public static implicit operator DeliveryMessageReference(XElement e) => new()
    {
        Value = e.Value,
        Type = e.Attribute("DeliveryMessageReferenceType")!.Value.ParseMember<ReferenceType>(),
        AssignedBy = e.Attribute("AssignedBy")!.Value.ParseMember<AssignedBy>()
    };
    public static implicit operator XElement(DeliveryMessageReference o) => new(
        "DeliveryMessageReference",
        o.Value,
        new XAttribute("DeliveryMessageReferenceType", o.Type.GetMemberValue()),
        new XAttribute("AssignedBy", o.AssignedBy.GetMemberValue())
    );

    public override string ToString() => ((XElement)this).ToString();
}

public enum AssignedBy
{
    [EnumMember(Value = "Bank")] Bank,
    [EnumMember(Value = "BillTo")] BillTo,
    [EnumMember(Value = "BorderCrossing")] BorderCrossing,
    [EnumMember(Value = "Broker")] Broker,
    [EnumMember(Value = "Buyer")] Buyer,
    [EnumMember(Value = "BuyerAgent")] BuyerAgent,
    [EnumMember(Value = "Carrier")] Carrier,
    [EnumMember(Value = "CarrierAssignmentResponsible")] CarrierAssignmentResponsible,
    [EnumMember(Value = "ComponentVendor")] ComponentVendor,
    [EnumMember(Value = "Consignee")] Consignee,
    [EnumMember(Value = "Consignor")] Consignor,
    [EnumMember(Value = "Consuming")] Consuming,
    [EnumMember(Value = "Converter")] Converter,
    [EnumMember(Value = "CreditDepartment")] CreditDepartment,
    [EnumMember(Value = "CrossDock")] CrossDock,
    [EnumMember(Value = "CustomerFacility")] CustomerFacility,
    [EnumMember(Value = "CustomerStock")] CustomerStock,
    [EnumMember(Value = "Customs")] Customs,
    [EnumMember(Value = "CustomsForwarder")] CustomsForwarder,
    [EnumMember(Value = "DomesticForwarder")] DomesticForwarder,
    [EnumMember(Value = "EndUser")] EndUser,
    [EnumMember(Value = "ExportForwarder")] ExportForwarder,
    [EnumMember(Value = "ForestForwarder")] ForestForwarder,
    [EnumMember(Value = "Forwarder")] Forwarder,
    [EnumMember(Value = "FreightPayer")] FreightPayer,
    [EnumMember(Value = "Insurer")] Insurer,
    [EnumMember(Value = "Landowner")] Landowner,
    [EnumMember(Value = "LoadingOperator")] LoadingOperator,
    [EnumMember(Value = "LoggingArea")] LoggingArea,
    [EnumMember(Value = "MainCarrier")] MainCarrier,
    [EnumMember(Value = "Measurer")] Measurer,
    [EnumMember(Value = "Merchant")] Merchant,
    [EnumMember(Value = "Mill")] Mill,
    [EnumMember(Value = "NotifyParty")] NotifyParty,
    [EnumMember(Value = "OnBehalfOf")] OnBehalfOf,
    [EnumMember(Value = "OrderParty")] OrderParty,
    [EnumMember(Value = "OriginalSupplier")] OriginalSupplier,
    [EnumMember(Value = "Payee")] Payee,
    [EnumMember(Value = "Payer")] Payer,
    [EnumMember(Value = "PlaceFinalDestination")] PlaceFinalDestination,
    [EnumMember(Value = "PlaceOfAccept")] PlaceOfAccept,
    [EnumMember(Value = "PlaceOfDespatch")] PlaceOfDespatch,
    [EnumMember(Value = "PlaceOfDischarge")] PlaceOfDischarge,
    [EnumMember(Value = "PlaceOfLoading")] PlaceOfLoading,
    [EnumMember(Value = "PlaceOfReloading")] PlaceOfReloading,
    [EnumMember(Value = "Port")] Port,
    [EnumMember(Value = "PreCarrier")] PreCarrier,
    [EnumMember(Value = "PrinterFacility")] PrinterFacility,
    [EnumMember(Value = "ProFormaInvoice")] ProFormaInvoice,
    [EnumMember(Value = "Producer")] Producer,
    [EnumMember(Value = "RemitTo")] RemitTo,
    [EnumMember(Value = "Requestor")] Requestor,
    [EnumMember(Value = "RoadKeeper")] RoadKeeper,
    [EnumMember(Value = "RoadOwner")] RoadOwner,
    [EnumMember(Value = "SalesAgent")] SalesAgent,
    [EnumMember(Value = "SalesOffice")] SalesOffice,
    [EnumMember(Value = "Seller")] Seller,
    [EnumMember(Value = "ShipFromLocation")] ShipFromLocation,
    [EnumMember(Value = "ShipOwner")] ShipOwner,
    [EnumMember(Value = "ShipTo")] ShipTo,
    [EnumMember(Value = "SubCarrier")] SubCarrier,
    [EnumMember(Value = "Supplier")] Supplier,
    [EnumMember(Value = "Terminal")] Terminal,
    [EnumMember(Value = "TerminalOperator")] TerminalOperator,
    [EnumMember(Value = "UnloadingOperator")] UnloadingOperator,
    [EnumMember(Value = "Warehouse")] Warehouse,
    [EnumMember(Value = "WillAdvise")] WillAdvise,
    [EnumMember(Value = "Other")] Other,
}

public enum ReferenceType
{
    [EnumMember(Value = "AccountNumber")] AccountNumber,
    [EnumMember(Value = "AudioVideoSelectionNumber")] AudioVideoSelectionNumber,
    [EnumMember(Value = "Author")] Author,
    [EnumMember(Value = "BarCodedSerialNumber")] BarCodedSerialNumber,
    [EnumMember(Value = "BillAndHoldInvoiceNumber")] BillAndHoldInvoiceNumber,
    [EnumMember(Value = "BillOfLadingMark")] BillOfLadingMark,
    [EnumMember(Value = "BillOfLadingNumber")] BillOfLadingNumber,
    [EnumMember(Value = "BindingStyleType")] BindingStyleType,
    [EnumMember(Value = "BookLanguage")] BookLanguage,
    [EnumMember(Value = "BookingNumber")] BookingNumber,
    [EnumMember(Value = "BudgetCenter")] BudgetCenter,
    [EnumMember(Value = "BuyerBudgetCenter")] BuyerBudgetCenter,
    [EnumMember(Value = "BuyerClaimNumber")] BuyerClaimNumber,
    [EnumMember(Value = "BuyerDivisionIdentifier")] BuyerDivisionIdentifier,
    [EnumMember(Value = "BuyerImprint")] BuyerImprint,
    [EnumMember(Value = "BuyerJobNumber")] BuyerJobNumber,
    [EnumMember(Value = "BuyerRetailPrice")] BuyerRetailPrice,
    [EnumMember(Value = "CallOffConfirmationLineItemNumber")] CallOffConfirmationLineItemNumber,
    [EnumMember(Value = "CallOffConfirmationNumber")] CallOffConfirmationNumber,
    [EnumMember(Value = "CallOffLineItemNumber")] CallOffLineItemNumber,
    [EnumMember(Value = "CallOffNumber")] CallOffNumber,
    [EnumMember(Value = "CallOffReferenceNumber")] CallOffReferenceNumber,
    [EnumMember(Value = "CatalogueReferenceNumber")] CatalogueReferenceNumber,
    [EnumMember(Value = "CIMNumber")] CIMNumber,
    [EnumMember(Value = "CMRNumber")] CMRNumber,
    [EnumMember(Value = "CoLoadingNumber")] CoLoadingNumber,
    [EnumMember(Value = "ComplaintNumber")] ComplaintNumber,
    [EnumMember(Value = "ComplaintLineItemNumber")] ComplaintLineItemNumber,
    [EnumMember(Value = "ComplaintResponseNumber")] ComplaintResponseNumber,
    [EnumMember(Value = "ComplaintResponseLineItemNumber")] ComplaintResponseLineItemNumber,
    [EnumMember(Value = "ConsigneeOrderNumber")] ConsigneeOrderNumber,
    [EnumMember(Value = "ContainerReference")] ContainerReference,
    [EnumMember(Value = "ContentLanguage")] ContentLanguage,
    [EnumMember(Value = "ContractLineNumber")] ContractLineNumber,
    [EnumMember(Value = "ContractNumber")] ContractNumber,
    [EnumMember(Value = "ConvertingReportNumber")] ConvertingReportNumber,
    [EnumMember(Value = "Copyright")] Copyright,
    [EnumMember(Value = "CreditAuthorizationNumber")] CreditAuthorizationNumber,
    [EnumMember(Value = "CreditDebitNoteNumber")] CreditDebitNoteNumber,
    [EnumMember(Value = "CreditNoteNumber")] CreditNoteNumber,
    [EnumMember(Value = "CustomerBookingNumber")] CustomerBookingNumber,
    [EnumMember(Value = "CustomerJobNumber")] CustomerJobNumber,
    [EnumMember(Value = "CustomerJobTitle")] CustomerJobTitle,
    [EnumMember(Value = "CustomerOrderNumber")] CustomerOrderNumber,
    [EnumMember(Value = "CustomerReferenceNumber")] CustomerReferenceNumber,
    [EnumMember(Value = "CustomerSpecificationNumber")] CustomerSpecificationNumber,
    [EnumMember(Value = "DebitNoteNumber")] DebitNoteNumber,
    [EnumMember(Value = "DeliveryBookingNumber")] DeliveryBookingNumber,
    [EnumMember(Value = "DeliveryInstructionNumber")] DeliveryInstructionNumber,
    [EnumMember(Value = "DeliveryInstructionSequenceNumber")] DeliveryInstructionSequenceNumber,
    [EnumMember(Value = "DeliveryInstructionSequenceLineNumber")] DeliveryInstructionSequenceLineNumber,
    [EnumMember(Value = "DeliveryLocation")] DeliveryLocation,
    [EnumMember(Value = "DeliveryMessageNumber")] DeliveryMessageNumber,
    [EnumMember(Value = "DeliveryMessageLineItemNumber")] DeliveryMessageLineItemNumber,
    [EnumMember(Value = "DeliveryNumber")] DeliveryNumber,
    [EnumMember(Value = "DepartmentIdentifier")] DepartmentIdentifier,
    [EnumMember(Value = "DespatchInformationNumber")] DespatchInformationNumber,
    [EnumMember(Value = "DespatchInstructionNumber")] DespatchInstructionNumber,
    [EnumMember(Value = "DivisionIdentifier")] DivisionIdentifier,
    [EnumMember(Value = "DropOffNumber")] DropOffNumber,
    [EnumMember(Value = "Edition")] Edition,
    [EnumMember(Value = "EditionState")] EditionState,
    [EnumMember(Value = "EditionSubject")] EditionSubject,
    [EnumMember(Value = "EducationSubject")] EducationSubject,
    [EnumMember(Value = "EndCallOffDate")] EndCallOffDate,
    [EnumMember(Value = "FlightNumber")] FlightNumber,
    [EnumMember(Value = "FormID")] FormID,
    [EnumMember(Value = "FormLowFolio")] FormLowFolio,
    [EnumMember(Value = "FormPages")] FormPages,
    [EnumMember(Value = "FormType")] FormType,
    [EnumMember(Value = "ForwarderReference")] ForwarderReference,
    [EnumMember(Value = "FromPurchaseOrderNumber")] FromPurchaseOrderNumber,
    [EnumMember(Value = "FromSalesOrderNumber")] FromSalesOrderNumber,
    [EnumMember(Value = "FSCNumber")] FSCNumber,
    [EnumMember(Value = "GeneralAgreement")] GeneralAgreement,
    [EnumMember(Value = "GoodsInBillOfLadingNumber")] GoodsInBillOfLadingNumber,
    [EnumMember(Value = "GoodsInDeliveryNumber")] GoodsInDeliveryNumber,
    [EnumMember(Value = "GoodsInTransportUnitIdentifier")] GoodsInTransportUnitIdentifier,
    [EnumMember(Value = "GoodsInTransportVehicleIdentifier")] GoodsInTransportVehicleIdentifier,
    [EnumMember(Value = "GoodsReceiptNumber")] GoodsReceiptNumber,
    [EnumMember(Value = "GoodsReceiptLineItemNumber")] GoodsReceiptLineItemNumber,
    [EnumMember(Value = "Imprint")] Imprint,
    [EnumMember(Value = "IndentOrderNumber")] IndentOrderNumber,
    [EnumMember(Value = "InitialShipmentAdviceNumber")] InitialShipmentAdviceNumber,
    [EnumMember(Value = "IntraStatNumber")] IntraStatNumber,
    [EnumMember(Value = "InventoryChangeNumber")] InventoryChangeNumber,
    [EnumMember(Value = "InventoryDispositionInstructionsNumber")] InventoryDispositionInstructionsNumber,
    [EnumMember(Value = "InventoryDispositionInstructionsLineNumber")] InventoryDispositionInstructionsLineNumber,
    [EnumMember(Value = "InvoiceNumber")] InvoiceNumber,
    [EnumMember(Value = "ISBN10")] ISBN10,
    [EnumMember(Value = "ISBN10Dash")] ISBN10Dash,
    [EnumMember(Value = "ISBN13")] ISBN13,
    [EnumMember(Value = "ISBN13Dash")] ISBN13Dash,
    [EnumMember(Value = "ISODocumentReference")] ISODocumentReference,
    [EnumMember(Value = "IssueEvent")] IssueEvent,
    [EnumMember(Value = "JobNumber")] JobNumber,
    [EnumMember(Value = "JobTitle")] JobTitle,
    [EnumMember(Value = "LoadPlanNumber")] LoadPlanNumber,
    [EnumMember(Value = "LoadReleaseNumber")] LoadReleaseNumber,
    [EnumMember(Value = "LoadTenderNumber")] LoadTenderNumber,
    [EnumMember(Value = "LoadTenderResponseNumber")] LoadTenderResponseNumber,
    [EnumMember(Value = "LoadingInstructionNumber")] LoadingInstructionNumber,
    [EnumMember(Value = "LoadingInstructionSequenceNumber")] LoadingInstructionSequenceNumber,
    [EnumMember(Value = "LoadingInstructionSequenceLineNumber")] LoadingInstructionSequenceLineNumber,
    [EnumMember(Value = "LoadingOrderNumber")] LoadingOrderNumber,
    [EnumMember(Value = "LoadingOrderLineNumber")] LoadingOrderLineNumber,
    [EnumMember(Value = "LotIdentifier")] LotIdentifier,
    [EnumMember(Value = "MagazineCode")] MagazineCode,
    [EnumMember(Value = "ManufacturerMaterialSafetyDataSheetNumber")] ManufacturerMaterialSafetyDataSheetNumber,
    [EnumMember(Value = "MarketType")] MarketType,
    [EnumMember(Value = "MarketplaceReferenceNumber")] MarketplaceReferenceNumber,
    [EnumMember(Value = "MasterBillOfLading")] MasterBillOfLading,
    [EnumMember(Value = "MasterContractNumber")] MasterContractNumber,
    [EnumMember(Value = "MasterISBN10")] MasterISBN10,
    [EnumMember(Value = "MasterISBN13")] MasterISBN13,
    [EnumMember(Value = "MasterPurchaseOrder")] MasterPurchaseOrder,
    [EnumMember(Value = "MaterialSafetyDataSheetNumber")] MaterialSafetyDataSheetNumber,
    [EnumMember(Value = "MeasuringInstructionNumber")] MeasuringInstructionNumber,
    [EnumMember(Value = "MeasuringNumber")] MeasuringNumber,
    [EnumMember(Value = "MeasuringTicketNumber")] MeasuringTicketNumber,
    [EnumMember(Value = "MeasuringTicketSequenceNumber")] MeasuringTicketSequenceNumber,
    [EnumMember(Value = "MeasuringTicketSequenceLineItemNumber")] MeasuringTicketSequenceLineItemNumber,
    [EnumMember(Value = "MillOrderLineItemNumber")] MillOrderLineItemNumber,
    [EnumMember(Value = "MillOrderNumber")] MillOrderNumber,
    [EnumMember(Value = "MillSalesOfficeNumber")] MillSalesOfficeNumber,
    [EnumMember(Value = "NonconformanceReportNumber")] NonconformanceReportNumber,
    [EnumMember(Value = "OrderConfirmationNumber")] OrderConfirmationNumber,
    [EnumMember(Value = "OrderConfirmationLineItemNumber")] OrderConfirmationLineItemNumber,
    [EnumMember(Value = "OrderNumber")] OrderNumber,
    [EnumMember(Value = "OrderLineItemNumber")] OrderLineItemNumber,
    [EnumMember(Value = "OrderPartyReferenceNumber")] OrderPartyReferenceNumber,
    [EnumMember(Value = "OriginalComplaintResponseNumber")] OriginalComplaintResponseNumber,
    [EnumMember(Value = "OriginalDeliveryNumber")] OriginalDeliveryNumber,
    [EnumMember(Value = "OriginalGoodsReceiptNumber")] OriginalGoodsReceiptNumber,
    [EnumMember(Value = "OriginalInvoiceNumber")] OriginalInvoiceNumber,
    [EnumMember(Value = "OriginalProductQualityMessageNumber")] OriginalProductQualityMessageNumber,
    [EnumMember(Value = "OriginalPurchaseOrderNumber")] OriginalPurchaseOrderNumber,
    [EnumMember(Value = "OriginalSalesOrderNumber")] OriginalSalesOrderNumber,
    [EnumMember(Value = "OriginalScaleTicketNumber")] OriginalScaleTicketNumber,
    [EnumMember(Value = "OriginalUsageNumber")] OriginalUsageNumber,
    [EnumMember(Value = "PackageMark")] PackageMark,
    [EnumMember(Value = "PackageNumber")] PackageNumber,
    [EnumMember(Value = "PackageSpecificationNumber")] PackageSpecificationNumber,
    [EnumMember(Value = "PackageSpecificationLineNumber")] PackageSpecificationLineNumber,
    [EnumMember(Value = "PageCount")] PageCount,
    [EnumMember(Value = "PageCountTotal")] PageCountTotal,
    [EnumMember(Value = "PaymentReferenceNumber")] PaymentReferenceNumber,
    [EnumMember(Value = "PEFCNumber")] PEFCNumber,
    [EnumMember(Value = "PickUpNumber")] PickUpNumber,
    [EnumMember(Value = "PlanningMessageNumber")] PlanningMessageNumber,
    [EnumMember(Value = "PopulationNumber")] PopulationNumber,
    [EnumMember(Value = "PriceContractNumber")] PriceContractNumber,
    [EnumMember(Value = "PriceQuoteNumber")] PriceQuoteNumber,
    [EnumMember(Value = "PriceList")] PriceList,
    [EnumMember(Value = "PrintingCode")] PrintingCode,
    [EnumMember(Value = "PrintingNumber")] PrintingNumber,
    [EnumMember(Value = "PriorPurchaseOrderNumber")] PriorPurchaseOrderNumber,
    [EnumMember(Value = "ProductOriginIdentifier")] ProductOriginIdentifier,
    [EnumMember(Value = "ProFormaInvoiceNumber")] ProFormaInvoiceNumber,
    [EnumMember(Value = "ProNumber")] ProNumber,
    [EnumMember(Value = "ProfitCenter")] ProfitCenter,
    [EnumMember(Value = "ProgramID")] ProgramID,
    [EnumMember(Value = "PromotionNumber")] PromotionNumber,
    [EnumMember(Value = "PubName")] PubName,
    [EnumMember(Value = "PubNumber")] PubNumber,
    [EnumMember(Value = "PublisherReferenceNumber")] PublisherReferenceNumber,
    [EnumMember(Value = "PupilsTeachers")] PupilsTeachers,
    [EnumMember(Value = "PurchaseOrderCorrelationID")] PurchaseOrderCorrelationID,
    [EnumMember(Value = "PurchaseOrderNumber")] PurchaseOrderNumber,
    [EnumMember(Value = "PurchaseOrderLineItemCorrelationID")] PurchaseOrderLineItemCorrelationID,
    [EnumMember(Value = "PurchaseOrderLineItemNumber")] PurchaseOrderLineItemNumber,
    [EnumMember(Value = "QualityReportNumber")] QualityReportNumber,
    [EnumMember(Value = "RandomSampleNumber")] RandomSampleNumber,
    [EnumMember(Value = "ReferenceNumber")] ReferenceNumber,
    [EnumMember(Value = "ReleaseNumber")] ReleaseNumber,
    [EnumMember(Value = "RetailPrice")] RetailPrice,
    [EnumMember(Value = "RFQLineItemNumber")] RFQLineItemNumber,
    [EnumMember(Value = "RFQNumber")] RFQNumber,
    [EnumMember(Value = "RunNumber")] RunNumber,
    [EnumMember(Value = "SalesOfficeNumber")] SalesOfficeNumber,
    [EnumMember(Value = "SalesOrderLineItemNumber")] SalesOrderLineItemNumber,
    [EnumMember(Value = "SalesOrderNumber")] SalesOrderNumber,
    [EnumMember(Value = "ScaleTicketNumber")] ScaleTicketNumber,
    [EnumMember(Value = "SchoolGrade")] SchoolGrade,
    [EnumMember(Value = "SchoolGradeLevel")] SchoolGradeLevel,
    [EnumMember(Value = "SellersInvoiceNumber")] SellersInvoiceNumber,
    [EnumMember(Value = "ServiceNumber")] ServiceNumber,
    [EnumMember(Value = "ShippingInstructionsLineItemNumber")] ShippingInstructionsLineItemNumber,
    [EnumMember(Value = "ShippingInstructionsNumber")] ShippingInstructionsNumber,
    [EnumMember(Value = "SimplifiedCustomsNumber")] SimplifiedCustomsNumber,
    [EnumMember(Value = "SpecificationNumber")] SpecificationNumber,
    [EnumMember(Value = "SpecificationReferenceNumber")] SpecificationReferenceNumber,
    [EnumMember(Value = "SpecificationVersion")] SpecificationVersion,
    [EnumMember(Value = "StockOrderLineItemNumber")] StockOrderLineItemNumber,
    [EnumMember(Value = "StockOrderNumber")] StockOrderNumber,
    [EnumMember(Value = "SupplierCallOffNumber")] SupplierCallOffNumber,
    [EnumMember(Value = "SupplierClaimNumber")] SupplierClaimNumber,
    [EnumMember(Value = "SupplierJobNumber")] SupplierJobNumber,
    [EnumMember(Value = "SupplierReferenceNumber")] SupplierReferenceNumber,
    [EnumMember(Value = "SupplierVoyageNumber")] SupplierVoyageNumber,
    [EnumMember(Value = "T2L")] T2L,
    [EnumMember(Value = "TimeTableNumber")] TimeTableNumber,
    [EnumMember(Value = "Title")] Title,
    [EnumMember(Value = "TitleAlias")] TitleAlias,
    [EnumMember(Value = "ToPurchaseOrderNumber")] ToPurchaseOrderNumber,
    [EnumMember(Value = "TrackingNumber")] TrackingNumber,
    [EnumMember(Value = "TransactionID")] TransactionID,
    [EnumMember(Value = "TransportUnitIdentifier")] TransportUnitIdentifier,
    [EnumMember(Value = "TransportVehicleIdentifier")] TransportVehicleIdentifier,
    [EnumMember(Value = "UniversalProductIdentifier")] UniversalProductIdentifier,
    [EnumMember(Value = "UsageNumber")] UsageNumber,
    [EnumMember(Value = "UsageLineItemNumber")] UsageLineItemNumber,
    [EnumMember(Value = "VendorReferenceNumber")] VendorReferenceNumber,
    [EnumMember(Value = "VesselShipNotice")] VesselShipNotice,
    [EnumMember(Value = "VoucherNumber")] VoucherNumber,
    [EnumMember(Value = "VoyageNumber")] VoyageNumber,
    [EnumMember(Value = "WarehouseDeliveryNumber")] WarehouseDeliveryNumber,
    [EnumMember(Value = "WaybillIdentifier")] WaybillIdentifier,
    [EnumMember(Value = "Other")] Other,
}

public class DeliveryMessageDate
{
    public Date Date { get; set; } = new();

    public static implicit operator DeliveryMessageDate(DateTime d) => new() { Date = d };
    public static implicit operator DateTime(DeliveryMessageDate d) => (DateTime)d.Date;
    public static implicit operator DeliveryMessageDate(XElement e) => new() { Date = (Date)e.Element("Date")! };
    public static implicit operator XElement(DeliveryMessageDate d) => new("DeliveryMessageDate", (XElement)d.Date);

    public override string ToString() => ((XElement)this).ToString();
}

public class Date
{
    public Year Year { get; set; } = new();
    public Month Month { get; set; } = new();
    public Day Day { get; set; } = new();

    public static implicit operator Date(DateTime d) => new() { Year = d.Year, Month = d.Month, Day = d.Day };
    public static implicit operator DateTime(Date d) => DateTime.Parse($"{d.Year}-{d.Month}-{d.Day}");
    public static implicit operator Date(XElement e) => new()
    {
        Year = (Year)e.Element("Year")!,
        Month = (Month)e.Element("Month")!,
        Day = (Day)e.Element("Day")!
    };
    public static implicit operator XElement(Date d) => new("Date",
        (XElement)d.Year,
        (XElement)d.Month,
        (XElement)d.Day);

    public override string ToString() => ((XElement)this).ToString();
}

public class Day
{
    public string Value { get; set; } = string.Empty;

    public static implicit operator Day(int value) => new() { Value = value.ToString("D2") };
    public static implicit operator Day(string value) => new() { Value = value };
    public static implicit operator Day(XElement e) => new() { Value = e.Value };
    public static implicit operator string(Day day) => day.Value;
    public static implicit operator XElement(Day d) => new("Day", d.Value);

    public override string ToString() => ((XElement)this).ToString();
}

public class Month
{
    public string Value { get; set; } = string.Empty;

    public static implicit operator Month(int value) => new() { Value = value.ToString("D2") };
    public static implicit operator Month(string value) => new() { Value = value };
    public static implicit operator Month(XElement e) => new() { Value = e.Value };
    public static implicit operator string(Month day) => day.Value;
    public static implicit operator XElement(Month d) => new("Month", d.Value);

    public override string ToString() => ((XElement)this).ToString();
}

public class Year
{
    public string Value { get; set; } = string.Empty;

    public static implicit operator Year(int value) => new Year { Value = value.ToString("D4") };
    public static implicit operator Year(string value) => new() { Value = value };
    public static implicit operator Year(XElement? e) => new() { Value = e?.Value ?? string.Empty };
    public static implicit operator string(Year day) => day.Value;
    public static implicit operator XElement(Year d) => new("Year", d.Value);

    public override string ToString() => ((XElement)this).ToString();
}

public class DeliveryMessageNumber
{
    public string Value { get; set; } = string.Empty;

    public static implicit operator DeliveryMessageNumber(int value) => new() { Value = value.ToString() };
    public static implicit operator DeliveryMessageNumber(string value) => new() { Value = value };
    public static implicit operator DeliveryMessageNumber(XElement? e) => new() { Value = e?.Value ?? string.Empty };
    public static implicit operator string(DeliveryMessageNumber obj) => obj.Value;
    public static implicit operator XElement(DeliveryMessageNumber obj) => new("Year", obj.Value);

    public override string ToString() => ((XElement)this).ToString();
}

public static class Extensions
{
    public static T ParseMember<T>(this string? value) where T : struct, Enum =>
        Enum.GetValues<T>().FirstOrDefault(x => x.GetMemberValue() == value);

    public static string GetMemberValue<T>(this T? value) where T : struct, Enum =>
        value == null ? string.Empty :
        typeof(T)
            .GetTypeInfo()
            .DeclaredMembers
            .SingleOrDefault(mi => mi.Name == $"{value}")
            ?.GetCustomAttribute<EnumMemberAttribute>(false)
            ?.Value ?? $"{value}";

    public static string GetMemberValue<T>(this T value) where T : struct, Enum =>
        typeof(T)
            .GetTypeInfo()
            .DeclaredMembers
            .SingleOrDefault(mi => mi.Name == $"{value}")
            ?.GetCustomAttribute<EnumMemberAttribute>(false)
            ?.Value ?? $"{value}";

    public static T? As<T>(this XElement? e) where T : class => e is null ? null : (T)(dynamic)e;
}
