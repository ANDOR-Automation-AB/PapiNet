using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

    public string Number { get; set; } = "1";
    public BindingList<Reference> References { get; set; } = [];
    public Product Product { get; set; } = new();
    public BindingList<Package> Packages { get; set; } = [];

    public static implicit operator XElement(Shipment o) =>
        new XElement(LocalName,
            new XElement("DeliveryMessageProductGroup",
                new XElement("DeliveryShipmentLineItem",
                    new XElement("DeliveryShipmentLineItemNumber", o.Number),
                    o.References.Select(i => (XElement)i),
                    (XElement)o.Product,
                    o.Packages.Select(i => (XElement)i))));

    public static implicit operator Shipment(XElement e) => new()
    {
        Number = e.First("DeliveryShipmentLineItemNumber") ?? string.Empty,
        References = new BindingList<Reference>(
            e.Descendants("DeliveryMessageReference").Select(e => (Reference)e).ToList()),
        Product = e.First<Product>("Product") ?? new()
    };

    public override string ToString() => ((XElement)this).ToString();
}

public class Package
{
    public static string LocalName => "TransportPackageInformation";

    public PackageType Type { get; set; } = PackageType.LengthPackage;
    public string Identifier { get; set; } = string.Empty;
    public string Pieces { get; set; } = string.Empty;
    public string CubicMeter { get; set; } = string.Empty;
    public string Meter { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;

    public static implicit operator XElement(Package o) =>
        new XElement(LocalName,
            new XAttribute("PackageType", o.Type),
            new XElement("Identifier",
                new XAttribute("IdentifierCodeType", "Supplier"),
                new XAttribute("IdentifierType", "Primary"),
                o.Identifier),
            new XElement("ItemCount",
                new XElement("Value",
                    new XAttribute("UOM", "Piece"),
                    o.Pieces)),
            new XElement("Quantity",
                new XAttribute("QuantityType", "Volume"),
                new XAttribute("QuantityTypeContext", "Delivered"),
                new XElement("Value",
                    new XAttribute("UOM", "CubicMeter"),
                    o.CubicMeter)),
            new XElement("InformationalQuantity",
                new XAttribute("QuantityType", "RunningLength"),
                new XAttribute("QuantityTypeContext", "Delivered"),
                new XElement("Value",
                    new XAttribute("UOM", "Meter"),
                    o.Meter)),
            new XElement("WoodItem",
                new XElement("LengthSpecification",
                    new XElement("LengthCategory",
                        new XAttribute("UOM", "Millimeter"),
                        o.Category),
                    new XElement("TotalNumberOfUnits",
                        new XElement("Value",
                            new XAttribute("UOM", "Piece"),
                            o.Pieces)))));

    public override string ToString() => ((XElement)this).ToString();
}

public class PackageViewModel
{
    public Package Package { get; set; } = new();

    public string Identifier
    {
        get => Package.Identifier;
        set => Package.Identifier = value;
    }

    public string Meter
    {
        get => Package.Meter;
        set => Package.Meter = value;
    }

    public string CubicMeter
    {
        get => Package.CubicMeter;
        set => Package.CubicMeter = value;
    }

    private string GetLength(string category) => Package.Category == category ? Package.Pieces : "";
    private void SetLength(string category, string? value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            Package.Category = category;
            Package.Pieces = value;
        }
    }

    public string Length1800
    {
        get => GetLength("1800");
        set => SetLength("1800", value);
    }

    public string Length2100
    {
        get => GetLength("2100");
        set => SetLength("2100", value);
    }

    public string Length2400
    {
        get => GetLength("2400");
        set => SetLength("2400", value);
    }

    public string Length2700
    {
        get => GetLength("2700");
        set => SetLength("2700", value);
    }

    public string Length3000
    {
        get => GetLength("3000");
        set => SetLength("3000", value);
    }

    public string Length3300
    {
        get => GetLength("3300");
        set => SetLength("3300", value);
    }

    public string Length3600
    {
        get => GetLength("3600");
        set => SetLength("3600", value);
    }

    public string Length3900
    {
        get => GetLength("3900");
        set => SetLength("3900", value);
    }

    public string Length4200
    {
        get => GetLength("4200");
        set => SetLength("4200", value);
    }

    public string Length4500
    {
        get => GetLength("4500");
        set => SetLength("4500", value);
    }

    public string Length4800
    {
        get => GetLength("4800");
        set => SetLength("4800", value);
    }

    public string Length5100
    {
        get => GetLength("5100");
        set => SetLength("5100", value);
    }

    public string Length5400
    {
        get => GetLength("5400");
        set => SetLength("5400", value);
    }

    public string Length5700
    {
        get => GetLength("5700");
        set => SetLength("5700", value);
    }

    public string Length6000
    {
        get => GetLength("6000");
        set => SetLength("6000", value);
    }

    public static implicit operator PackageViewModel(Package package) =>
        new() { Package = package };

    public static implicit operator Package(PackageViewModel viewModel) =>
        viewModel.Package;
}

public static class PackageExtensions
{
    public static BindingList<Package> ToPackages(this IEnumerable<PackageViewModel> viewModels) =>
        new(viewModels.Select(vm => vm.Package).ToList());

    public static BindingList<PackageViewModel> ToViewModels(this IEnumerable<Package> packages) =>
        new(packages.Select(p => new PackageViewModel { Package = p }).ToList());
}

public enum PackageType
{
    [Display(Name = "Längdpaket")]
    LengthPackage,

    [Display(Name = "Truckpaket")]
    TruckPackage
}

public class Product
{
    public static string LocalName => "Product";
    public static string FileName => $"{LocalName}.xml";

    public string DisplayMember => string.IsNullOrEmpty(PartNumber) ? "" :
        $"{Description} " +
        $"({PartNumber}) " +
        $"Width {WidthActual}/{WidthNominal} " +
        $"Thickness {ThicknessActual}/{ThicknessNominal}";

    public string PartNumber { get; set; } = string.Empty;
    public BindingList<ProductIdentifier> Identifiers { get; set; } = [];
    public string Description { get; set; } = string.Empty;
    public SpeciesType Species { get; set; } = SpeciesType.Redwood;
    public string SpeciesCode => Species switch
    {
        SpeciesType.Redwood => "1",
        SpeciesType.WhiteWood => "2",
        _ => "3"
    };
    public string GradeName { get; set; } = string.Empty;
    public string GradeCode { get; set; } = string.Empty;
    public string WidthActual { get; set; } = string.Empty;
    public string WidthNominal { get; set; } = string.Empty;
    public string ThicknessActual { get; set; } = string.Empty;
    public string ThicknessNominal { get; set; } = string.Empty;

    public static implicit operator XElement(Product o) =>
        new XElement(LocalName,
            new XElement("ProductIdentifier", 
                new XAttribute("Agency", "Supplier"),
                new XAttribute("ProductIdentifierType", "PartNumber"),
                o.PartNumber),
            //o.Identifiers.Select(i => (XElement)i),
            new XElement("ProductDescription", o.Description),
            new XElement("WoodProducts",
                new XElement("WoodTimbersDimensionalLumberBoards",
                    new XElement("SoftwoodLumber",
                        new XElement("SoftwoodLumberCharacteristics",
                            new XElement("LumberSpecies",
                                new XAttribute("SpeciesType", o.Species),
                                new XElement("SpeciesCode", o.SpeciesCode)),
                            new XElement("LumberGrade",
                                new XElement("GradeName", o.GradeName),
                                new XElement("GradeCode", o.GradeCode)),
                            new XElement("Width",
                                new XAttribute("ActualNominal", "Nominal"),
                                new XElement("Value",
                                    new XAttribute("UOM", "Millimeter"),
                                    o.WidthNominal)),
                            new XElement("Width",
                                new XAttribute("ActualNominal", "Actual"),
                                new XElement("Value",
                                    new XAttribute("UOM", "Millimeter"),
                                    o.WidthActual)),
                            new XElement("Thickness",
                                new XAttribute("ActualNominal", "Nominal"),
                                new XElement("Value",
                                    new XAttribute("UOM", "Millimeter"),
                                    o.ThicknessNominal)),
                            new XElement("Thickness",
                                new XAttribute("ActualNominal", "Actual"),
                                new XElement("Value",
                                    new XAttribute("UOM", "Millimeter"),
                                    o.ThicknessActual)))))));

    public static implicit operator Product(XElement e) => new()
    {
        PartNumber = e.Elements("ProductIdentifier")
            .FirstOrDefault(i => i.Attribute("ProductIdentifierType")?.Value == "PartNumber")?.Value
            ?? string.Empty,
        Identifiers = new ([.. e.Elements("ProductIdentifier").Select(i => (ProductIdentifier)i)]),
        Description = e.Element("ProductDescription")?.Value ?? string.Empty,
        Species = Enum.TryParse<SpeciesType>(
            e.Descendants("LumberSpecies").FirstOrDefault()?.Attribute("SpeciesType")?.Value,
            out var species) ? species : default,
        GradeName = e.Descendants("GradeName").FirstOrDefault()?.Value ?? string.Empty,
        GradeCode = e.Descendants("GradeCode").FirstOrDefault()?.Value ?? string.Empty,
        WidthNominal = e.Descendants("Width")
            .FirstOrDefault(e => e.Attribute("ActualNominal")?.Value == "Nominal")?
            .Element("Value")?.Value ?? string.Empty,
        WidthActual = e.Descendants("Width")
            .FirstOrDefault(e => e.Attribute("ActualNominal")?.Value == "Actual")?
            .Element("Value")?.Value ?? string.Empty,
        ThicknessNominal = e.Descendants("Thickness")
            .FirstOrDefault(e => e.Attribute("ActualNominal")?.Value == "Nominal")?
            .Element("Value")?.Value ?? string.Empty,
        ThicknessActual = e.Descendants("Thickness")
            .FirstOrDefault(e => e.Attribute("ActualNominal")?.Value == "Actual")?
            .Element("Value")?.Value ?? string.Empty
    };

    public static void Save(BindingList<Product> list) =>
        Data.Write(FileName, list.Select(i => (XElement)i));

    public static BindingList<Product> Load() =>
        Data.Read(FileName, LocalName, e => (Product)e);

    public override string ToString() => ((XElement)this).ToString();
}

public enum ActualNominal
{
    [Display(Name = "Aktuell")]
    Actual,

    [Display(Name = "Nominell")]
    Nominal
}

public class ProductIdentifier
{
    public static string LocalName => "ProductIdentifier";
    public static string FileName => $"{LocalName}.xml";

    public Agency Agency { get; set; } = Agency.Supplier;
    public ProductIdentifierType Type { get; set; } = ProductIdentifierType.PartNumber;
    public string Value { get; set; } = string.Empty;

    public static implicit operator XElement(ProductIdentifier o) =>
        new XElement(LocalName,
            new XAttribute("Agency", o.Agency),
            new XAttribute("ProductIdentifierType", o.Type),
            o.Value);

    public static implicit operator ProductIdentifier(XElement e) => new()
    {
        Agency = Enum.TryParse<Agency>(
            e.Attribute("Agency")?.Value,
            out var agency) ? agency : Agency.Supplier,
        Type = Enum.TryParse<ProductIdentifierType>(
            e.Attribute("ProductIdentifierType")?.Value,
            out var type)? type : ProductIdentifierType.PartNumber,
        Value = e.Value
    };

    public static void Save(BindingList<ProductIdentifier> list) =>
        Data.Write(FileName, list.Select(i => (XElement)i));

    public static BindingList<ProductIdentifier> Load() =>
        Data.Read(FileName, LocalName, e => (ProductIdentifier)e);

    public override string ToString() => ((XElement)this).ToString();
}

public enum ProductIdentifierType
{
    [Display(Name = "Varumärke")]
    BrandName,

    [Display(Name = "Katalognummer")]
    CatalogueNumber,

    [Display(Name = "Tullkod (export)")]
    ExportHarmonisedSystemCode,

    [Display(Name = "EAN-8")]
    EAN8,

    [Display(Name = "EAN-13")]
    EAN13,

    [Display(Name = "Tullkod (import)")]
    ImportHarmonisedSystemCode,

    [Display(Name = "Produkt-ID")]
    FinishedGoodIdentifier,

    [Display(Name = "Kvalitetskod")]
    GradeCode,

    [Display(Name = "Kvalitetsnamn")]
    GradeName,

    [Display(Name = "Partinummer")]
    PartNumber,

    [Display(Name = "Artikelnummer (RFQ)")]
    RFQPartNumber,

    [Display(Name = "Tillverkarens kod")]
    ManufacturingGradeCode,

    [Display(Name = "Tillverkarens namn")]
    ManufacturingGradeName,

    [Display(Name = "Ondule")]
    Ondule,

    [Display(Name = "SKU (lagerenhet)")]
    SKU,

    [Display(Name = "UPC")]
    UPC,

    [Display(Name = "Annat")]
    Other
}

public enum Agency
{
    [Display(Name = "Köpare")]
    Buyer,

    [Display(Name = "Leverantör")]
    Supplier
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
    [Display(Name = "Säljare")]
    Seller,

    [Display(Name = "Mottagare")]
    Consignee,

    [Display(Name = "Lossningsplats")]
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
    [Display(Name = "Sverige")]
    SE,

    [Display(Name = "Danmark")]
    DK
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
    [Display(Name = "Tilldelad av säljare")]
    AssignedBySeller,

    [Display(Name = "VAT momsregistreringsnummer")]
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
    [Display(Name = "Säljare")]
    Seller,

    [Display(Name = "Köpare")]
    Buyer
}

public enum ReferenceType
{
    [Display(Name = "Fakturanummer")]
    InvoiceNumber,

    [Display(Name = "Ordernummer")]
    OrderNumber,

    [Display(Name = "Referensnummer")]
    ReferenceNumber,

    [Display(Name = "Kontraktsnummer")]
    ContractNumber,

    [Display(Name = "Kontraktsradnummer")]
    ContractLineNumber,

    [Display(Name = "Avropsnummer")]
    CallOffNumber,

    [Display(Name = "Avropsradnummer")]
    CallOffLineItemNumber,

    [Display(Name = "Orderradnummer")]
    OrderLineItemNumber,

    [Display(Name = "Fraktsedelmarkering")]
    BillOfLadingMark,

    [Display(Name = "Lastningsorderradnummer")]
    LoadingOrderLineNumber
}

public enum MessageType
{
    [Display(Name = "Leveransmeddelande")]
    DeliveryMessage,

    [Display(Name = "Packspecifikation")]
    PackingSpecification
}

public enum MessageStatus
{
    Original
}

public enum SpeciesType
{
    //Afrormosia,
    //Afzelia,
    //Agba,
    //AlaskanCedar,
    //Alder,
    //AlpineFir,
    //AmabilisFir,
    //Amapa,
    //Andoung,
    //Anegre,
    //Antiaris,
    //Ash,
    //Aspen,
    //AspenPolar,
    //AustrianSpruce,
    //Avodire,
    //Ayan,
    //Ayous,
    //Ako,
    //BalsamFir,
    //BalsamPolar,
    //Bamboo,
    //Basswood,
    //Beech,
    //Birch,
    //BirdseyeMaple,
    //BlackCherry,
    //BlackCottonwood,
    //BlackGuarea,
    //BlackSpruce,
    //Bubinga,
    //CaliforniaRedFir,
    //CaribeanPine,
    //CarolinaPine,
    //Cedar,
    //Ceiba,
    //CembraPine,
    //Cherry,
    //Chestnut,
    //CoastSpecies,
    //Cypress,
    //Danta,
    //DouglasFir,
    //Douka,
    //EasternCottonwood,
    //EasternHemlock,
    //EasternSoftwoods,
    //EasternSpruce,
    //EasternWhiteCedar,
    //EasternWhitePine,
    //Elliotti,
    //EngelmanSpruce,
    //Eucalyptus,
    //EuropeanLarch,
    //Exotic,
    //FigureSycamore,
    //Fir,
    //Frake,
    //Framire,
    //Gaboon,
    //GrandFir,
    //GreyElm,
    //HardMaple,
    //Hemlock,
    //Hornbeam,
    //IdahoWhitePine,
    //Ilomba,
    //Imbira,
    //IncCedar,
    //InlRedCedar,
    //Ipe,
    //Iroko,
    //JackPine,
    //Kaya,
    //Koto,
    //Larch,
    //LarricioPine,
    //Lauan,
    //Limba,
    //Locust,
    //LodgepolePine,
    //Mahogany,
    //Macoré,
    //Mansonia,
    //Maple,
    //MaritimePine,
    //Meranti,
    //Merbeau,
    //MexicanPine,
    //MixedSoftwood,
    //MixedSYP,
    //MixedTropicalHardwood,
    //MntnHemlock,
    //Niangon,
    //NobelFir,
    //NorwaySpruce,
    //NorthernAspen,
    //NorthernPine,
    //NorthernSpecies,
    //Oak,
    //Okume,
    //OliverAsh,
    //Olon,
    //Omu,
    //OregonPine,
    //Ozigo,
    //PacificCoastHemlock,
    //PacificSilverFir,
    //Padauk,
    //PaoAmarello,
    //Pear,
    //Pearwood,
    //Pine,
    //Plane,
    //PlywoodComposite,
    //PonderosaPine,
    //PrtOrfCed,
    //Poucouli,
    //Purpleheart,
    //Radiata,
    //RadiataPine,
    //RedCedar,
    //RedElm,
    //RedOak,
    //RedPine,
    //RedSpruce,
    //RedWhitewood,
    Redwood,
    //RioRosewood,
    //Rosewood,
    //SandPine,
    //SantosRosewood,
    //Sapelle,
    //Satinwood,
    //ScotsPine,
    //SilkyOak,
    //SitkaSpruce,
    //SouthernPine,
    //SouthernPondPine,
    //SouthernSprucePine,
    //SPF,
    //Spruce,
    //SugarPine,
    //SwissPear,
    //SwissStonePine,
    //Sycamore,
    //SYP,
    //Taeda,
    //Tamarack,
    //Tauari,
    //Teak,
    //Tiama,
    //Tineo,
    //TropicalOliver,
    //Utile,
    //VirginiaPine,
    //Walnut,
    //Wenge,
    //Wey,
    //WesternCedars,
    //WesternHemlock,
    //WesternRedCedar,
    //WesternWhitePine,
    //WesternWhiteSpruce,
    //WesternWoods,
    //WhitebarkPine,
    //WhiteFir,
    //WhiteOak,
    //WhiteSpruce,
    WhiteWood,
    //YellowCedar,
    //YellowCypress,
    //YellowPoplar,
    //Zebrano,
    //Other,
}

//public enum SpeciesType
//{
//    [Display(Name = "Furu (Redwood)")]
//    Redwood,
//
//    [Display(Name = "Gran (Whitewood)")]
//    WhiteWood
//}

public class EnumDisplayItem<T>
{
    public T Value { get; set; } = default!;
    public string DisplayName { get; set; } = string.Empty;
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

    public static string ToDisplayName(this Enum value)
    {
        var member = value.GetType().GetMember(value.ToString()).FirstOrDefault();
        if (member == null)
            return value.ToString();

        var attribute = member
            .GetCustomAttributes(typeof(DisplayAttribute), false)
            .OfType<DisplayAttribute>()
            .FirstOrDefault();

        return attribute?.Name ?? value.ToString();
    }

    public static List<EnumDisplayItem<TEnum>> GetDisplayList<TEnum>() where TEnum : Enum =>
        Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Select(e => new EnumDisplayItem<TEnum>
            {
                Value = e,
                DisplayName = ((Enum)(object)e).ToDisplayName()
            }).ToList();
}
