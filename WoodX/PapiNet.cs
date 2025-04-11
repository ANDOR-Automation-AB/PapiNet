using System.ComponentModel;
using System.Xml.Linq;

namespace PapiNet.WoodX;

static class Data
{
    static string CommonApplication => 
        Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
    public static string FolderPath => 
        Path.Combine(CommonApplication, "Andor", "PapiNet");

    public static BindingList<T> Read<T>(string uri, string e, Func<XElement, T> func) =>
        new(File.Exists(uri) ? XDocument.Load(uri).Root?.Elements(e).Select(func).ToList() ?? [] : []);

    public static void Write<T>(string uri, IEnumerable<T> items) =>
        new XDocument(new XElement("PapiNet", items.Select(i => (XElement)(dynamic)i!)))
        .Save(Path.Combine(FolderPath, uri));

}

public class DeliveryMessage
{
    public MessageType Type { get; set; }
    public MessageStatus Status { get; set; }
    public string Number { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.Now;
    public BindingList<Reference> References { get; set; } = [];
    public Party Buyer { get; set; } = new() { LocalName = "BuyerParty" };
    public Party Supplier { get; set; } = new() { LocalName = "SupplierParty" };
    public BindingList<Party> OtherParties { get; set; } = [];

    public static implicit operator XElement(DeliveryMessage o) =>
        new XElement("DeliveryMessageWood",
            new XAttribute("DeliveryMessageType", o.Type),
            new XAttribute("DeliveryMessageStatusType", o.Status),
            new XElement("DeliveryMessageHeader",
                new XElement("DeliveryMessageNumber", o.Number),
                new XElement("DeliveryMessageDate",
                    new XElement("Date",
                        new XElement("Year", o.Date.Year),
                        new XElement("Month", o.Date.Month),
                        new XElement("Day", o.Date.Day))),
                o.References.Select(i => (XElement)i),
                (XElement)o.Buyer,
                (XElement)o.Supplier,
                o.OtherParties.Select(i => (XElement)i))
            );

    public static void Init()
    {
        if (!Directory.Exists(Data.FolderPath))
            Directory.CreateDirectory(Data.FolderPath);
    }

    public override string ToString() => ((XElement)this).ToString();
}

public class Party
{
    public string LocalName { get; set; } = string.Empty;
    public string FileName => $"{LocalName}.xml";

    public BindingList<PartyIdentifier> Identifiers { get; set; } = [];
    public string Name => Address.Name1;
    public Address Address { get; set; } = new();

    public static implicit operator XElement(Party o) =>
        new XElement(o.LocalName,
            o.Identifiers.Select(i => (XElement)i),
            (XElement)o.Address);

    public static implicit operator Party(XElement e) => new()
    {
        LocalName = e.Name.LocalName,
        Identifiers = new BindingList<PartyIdentifier>(
            e.Elements("PartyIdentifier").Select(x => (PartyIdentifier)x).ToList()),
        Address = (Address)e.Element("NameAddress")!
    };

    public static void Save(BindingList<Party> list) =>
        Data.Write(list.FirstOrDefault()!.FileName, list.Select(i => (XElement)i));

    public static BindingList<Party> Load(string localName) =>
        Data.Read($"{localName}.xml", localName, e => (Party)e);

    public override string ToString() => ((XElement)this).ToString();
}

public enum PartyType
{
    Seller,
    Consignee,
    PlaceOfDischarge
}

public class Address
{
    public static string LocalName => "NameAddress";
    public static string FileName => $"{LocalName}.xml";

    public string Name1 { get; set; } = string.Empty;
    public string Address1 { get; set; } = string.Empty;
    public string Address2 { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public ISOCountryCode ISO { get; set; }

    public static implicit operator XElement(Address o) =>
        new XElement(LocalName,
            new XElement("Name1", o.Name1),
            new XElement("Address1", o.Address1),
            new XElement("Address2", o.Address2),
            new XElement("Country",
                new XAttribute("ISOCountryCode", o.ISO),
                o.Country));

    public static implicit operator Address(XElement e) => new()
    {
        Name1 = e.Element("Name1")?.Value ?? string.Empty,
        Address1 = e.Element("Address1")?.Value ?? string.Empty,
        Address2 = e.Element("Address2")?.Value ?? string.Empty,
        Country = e.Element("Country")?.Value ?? string.Empty,
        ISO = Enum.TryParse<ISOCountryCode>(
            e.Element("Country")?.Attribute("ISOCountryCode")?.Value,
            out var iso) ? iso : default
    };

    public static void Save(BindingList<Address> list) =>
        Data.Write(FileName, list.Select(i => (XElement)i));

    public static BindingList<Address> Load() =>
        Data.Read(FileName, LocalName, e => (Address)e);

    public override string ToString() => ((XElement)this).ToString();
}

public enum ISOCountryCode
{
    SE,
    DK,
}

public class PartyIdentifier
{
    public static string LocalName => "PartyIdentifier";
    public static string FileName => $"{LocalName}.xml";

    public PartyIdentifierType Type { get; set; }
    public string Value { get; set; } = string.Empty;

    public static implicit operator XElement(PartyIdentifier o) =>
        new(LocalName,
            new XAttribute("PartyIdentifierType", o.Type),
            o.Value);

    public static implicit operator PartyIdentifier(XElement e) => new()
    {
        Type = Enum.TryParse<PartyIdentifierType>(
            e.Attribute("PartyIdentifierType")?.Value,
            out var type) ? type : default,
        Value = e.Value
    };

    public static void Save(BindingList<PartyIdentifier> list) =>
        Data.Write(FileName, list.Select(i => (XElement)i));

    public static BindingList<PartyIdentifier> Load() =>
        Data.Read(FileName, LocalName, e => (PartyIdentifier)e);

    public override string ToString() => ((XElement)this).ToString();
}

public enum PartyIdentifierType
{
    AssignedBySeller,
    VATIdentificationNumber
}

public class Reference
{
    public static string LocalName => "DeliveryMessageReference";
    public static string FileName => $"{LocalName}.xml";

    public ReferenceType Type { get; set; }
    public AssignedBy AssignedBy { get; set; }
    public string Value { get; set; } = string.Empty;

    public static implicit operator XElement(Reference o) =>
        new (LocalName,
            new XAttribute("DeliveryMessageReferenceType", o.Type),
            new XAttribute("AssignedBy", o.AssignedBy),
            o.Value);

    public static implicit operator Reference(XElement e) => new()
    {
        Type = Enum.TryParse<ReferenceType>(
            e.Attribute("DeliveryMessageReferenceType")?.Value,
            out var type) ? type : default,
        AssignedBy = Enum.TryParse<AssignedBy>(
            e.Attribute("AssignedBy")?.Value,
            out var assignedBy) ? assignedBy : default,
        Value = e.Value
    };

    public static void Save(BindingList<Reference> list) =>
        Data.Write(FileName, list.Select(i => (XElement)i));

    public static BindingList<Reference> Load() =>
        Data.Read(FileName, LocalName, e => (Reference)e);

    public override string ToString() => ((XElement)this).ToString();
}

public enum AssignedBy
{
    Seller,
    Buyer
}

public enum ReferenceType
{
    InvoiceNumber,
    OrderNumber,
    ReferenceNumber,
}

public enum MessageType
{
    DeliveryMessage,
    PackingSpecification
}
public enum MessageStatus
{
    Original
}