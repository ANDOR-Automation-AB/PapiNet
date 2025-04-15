using System.ComponentModel;
using System.Xml.Linq;

namespace PapiNet.WoodX;

static class Data
{
    static string CommonApplication => 
        Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
    public static string FolderPath => 
        Path.Combine(CommonApplication, "Andor", "PapiNet");

    public static string MessagesPath =>
        Path.Combine(FolderPath, "Messages");

    public static BindingList<T> Read<T>(string uri, string e, Func<XElement, T> func) =>
        new(File.Exists(Path.Combine(FolderPath, uri)) ? XDocument.Load(Path.Combine(FolderPath, uri)).Root?.Elements(e).Select(func).ToList() ?? [] : []);

    public static BindingList<T> Read<T>(string uri, Func<XElement, T> func) =>
        new(File.Exists(Path.Combine(FolderPath, uri)) ? XDocument.Load(Path.Combine(FolderPath, uri)).Root?.Elements().Select(func).ToList() ?? [] : []);

    public static void Write<T>(string uri, IEnumerable<T> items) =>
        new XDocument(new XElement("PapiNet", items.Select(i => (XElement)(dynamic)i!)))
        .Save(Path.Combine(FolderPath, uri));

    public static BindingList<DeliveryMessage> Read() =>
        new(Directory.EnumerateFiles(MessagesPath, "*.xml")
            .Select(XDocument.Load)
            .Select(i => (DeliveryMessage)i.Root!)
            .ToList());

    public static void Write(string uri, DeliveryMessage message) =>
        new XDocument(
            new XDeclaration("1.0", "ISO-8859-1", null), 
            (XElement)message).Save(Path.Combine(MessagesPath, uri));

    public static void WriteOver(string oldUri, string uri, DeliveryMessage message)
    {
        Delete(oldUri);
        Write(uri, message);
    }

    public static void Delete(string uri) =>
        File.Delete(Path.Combine(MessagesPath, uri));
}

public class DeliveryMessage
{
    public string LocalName => "DeliveryMessageWood";
    public string FileName => $"{Number}.xml";

    public MessageType Type { get; set; }
    public MessageStatus Status { get; set; }
    public string Number { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.Now;
    public BindingList<Reference> References { get; set; } = [];
    public Party Buyer { get; set; } = new();
    public Party Supplier { get; set; } = new();
    public BindingList<Party> OtherParties { get; set; } = [];
    public Shipment Shipment { get; set; } = new();

    public static implicit operator XElement(DeliveryMessage o) =>
        new XElement(o.LocalName,
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
                new XElement("BuyerParty",
                    ((XElement)o.Buyer).Elements()),
                new XElement("SupplierParty",
                    ((XElement)o.Supplier).Elements()),
                o.OtherParties.Select(i => (XElement)i)),
            (XElement)o.Shipment);

    public static implicit operator DeliveryMessage(XElement e) => new()
    {
        Type = Enum.TryParse<MessageType>(e.Attribute("DeliveryMessageType")?.Value, out var t) ? t : default,
        Status = Enum.TryParse<MessageStatus>(e.Attribute("DeliveryMessageStatusType")?.Value, out var s) ? s : default,
        Number = e.Element("DeliveryMessageHeader")?.Element("DeliveryMessageNumber")?.Value ?? "",
        Date = DateTime.TryParse(string.Join("-",
            e.Element("DeliveryMessageHeader")!
             .Element("DeliveryMessageDate")!
             .Element("Date")!
             .Elements().Select(x => x.Value)), out var date) ? date : DateTime.Now,
        References = new BindingList<Reference>(
            e.Descendants("DeliveryMessageReference").Select(x => (Reference)x).ToList()),
        Buyer = e.First<Party>("BuyerParty") ?? new(),
        Supplier = e.First<Party>("SupplierParty") ?? new(),
        //OtherParties = new BindingList<Party>(
        //    e.Elements().Where(x =>
        //        x.Name.LocalName != "DeliveryMessageHeader" &&
        //        x.Name.LocalName != "BuyerParty" &&
        //        x.Name.LocalName != "SupplierParty")
        //    .Select(x => (Party)x).ToList()),
        Shipment = e.First<Shipment>("DeliveryMessageShipment") ?? new()
    };

    public static void Init()
    {
        Directory.CreateDirectory(Data.FolderPath);
        Directory.CreateDirectory(Data.MessagesPath);
    }

    public void Save() => Data.Write(FileName, this);

    public void SaveOver(string oldUri) => Data.WriteOver($"{oldUri}.xml", FileName, this);

    public void Delete() => Data.Delete(FileName);

    public static BindingList<DeliveryMessage> Load() => Data.Read();

    public override string ToString() => ((XElement)this).ToString();
}

public class Shipment
{
    public static string LocalName => "DeliveryMessageShipment";
    public static string FileName => $"{LocalName}";

    public string Number { get; set; } = string.Empty;
    public BindingList<Reference> References { get; set; } = [];

    public static implicit operator XElement(Shipment o) =>
        new XElement(LocalName,
            new XElement("DeliveryMessageProductGroup",
                new XElement("DeliveryShipmentLineItem",
                    new XElement("DeliveryShipmentLineItemNumber", o.Number))));

    public static implicit operator Shipment(XElement e) => new()
    {
        Number = e.First("DeliveryShipmentLineItemNumber") ?? string.Empty,
        References = new BindingList<Reference>(
            e.Descendants("DeliveryMessageReference").Select(e => (Reference)e).ToList()),
    };
}

public class Party
{
    public static string LocalName => "Party";
    public static string FileName => $"{LocalName}.xml";

    public BindingList<PartyIdentifier> Identifiers { get; set; } = [];
    public string Name => Address.Name1;
    public Address Address { get; set; } = new();
    public PartyType? PartyType { get; set; } = null;

    public static implicit operator XElement(Party o) =>
        new XElement(LocalName,
            o.PartyType != null ? new XAttribute("PartyType", o.PartyType) : null,
            o.Identifiers.Select(i => (XElement)i),
            (XElement)o.Address);

    public static implicit operator Party(XElement e) => new()
    {
        PartyType = Enum.TryParse<PartyType>(
            e.Attribute("PartyType")?.Value, 
            out var type) ? type : null,
        Identifiers = new BindingList<PartyIdentifier>(
            e.Elements("PartyIdentifier").Select(x => (PartyIdentifier)x).ToList()),
        Address = (Address)e.Element("NameAddress")!
    };

    public static void Save(BindingList<Party> list) =>
        Data.Write(FileName, list.Select(i => (XElement)i));

    public static BindingList<Party> Load(string localName) =>
        Data.Read(FileName, localName, e => (Party)e);

    public static BindingList<Party> Load() =>
        Data.Read(FileName, LocalName, e => (Party)e);

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
    ContractNumber,
    ContractLineNumber,
    CallOffNumber,
    CallOffLineItemNumber,
    OrderLineItemNumber,
    BillOfLadingMark,
    LoadingOrderLineNumber
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

public static class Extensions
{
    public static T? First<T>(this XElement source, string name) where T : class
    {
        var e = source.Descendants(name).FirstOrDefault();
        if (e == null) 
            return null;
        var method = typeof(T).GetMethod("op_Implicit", [typeof(XElement)]);
        if (method is null)
            return null;
        return method.Invoke(null, [e]) as T;
    }

    public static string? First(this XElement source, string name) =>
        source.Descendants(name).FirstOrDefault()?.Value;
}

public enum LumberSepcies
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