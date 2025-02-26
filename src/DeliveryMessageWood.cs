using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PapiNet.WoodX
{
    using static XHelpers;

    public enum DeliveryMessageType
    {
        LoadingOrder,
        PackingSpecification,
        DeliveryMessage,
        ShipmentAdvice,
        InitialShipmentAdvice
    }

    public enum DeliveryMessageStatusType
    {
        Cancelled,
        Original,
        Replaced
    }

    public enum PartyType
    {
        PlaceFinalDestination,
        SalesAgent,
        SalesOffice,
        Seller,
        Supplier,
        BillTo,
        Buyer,
        BuyerAgent
    }

    public enum IncotermsType
    {
        EXW,
        DAP,
        DDP,
        CIP,
        DPU,
        FCA,
        CPT
    }

    public class DeliveryMessage
    {
        const string xsi = "http://www.w3.org/2001/XMLSchema-instance";
        public List<string> Stylesheet { get; set; } = new()
        {
            "ISSsubset_papiNetWoodX_DeliveryMessageWood_V2R31_Build20081207.xls"
        };
        public DeliveryMessageType Type { get; set; } = DeliveryMessageType.DeliveryMessage;
        public DeliveryMessageStatusType Status { get; set; } = DeliveryMessageStatusType.Original;
        public string Number { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public List<Reference> References { get; set; } = [];
        public Party Buyer { get; set; } = new("BuyerParty");
        public Party Supplier { get; set; } = new("SupplierParty");
        public Party Seller { get; set; } = new("OtherParty", "Seller");
        public Party Sender { get; set; } = new("SenderParty");
        public Party Receiver { get; set; } = new("ReceiverParty");
        public Party ShipTo { get; set; } = new("ShipToParty", "PlaceOfDischarge");
        public List<Shipment> Shipments { get; set; } = [];

        public DeliveryMessage(string number, DateTime date) 
        {
            Number = number;
            Date = date;
        }

        DeliveryMessage()
        {

        }

        public static DeliveryMessage Parse(string uri)
        {
            var xml = XElement.Load(uri);
            var header = xml.Element("DeliveryMessageWoodHeader")!;

            return new DeliveryMessage
            {
                Type = Enum.Parse<DeliveryMessageType>(xml.Attribute("DeliveryMessageType")!.Value),
                Status = Enum.Parse<DeliveryMessageStatusType>(xml.Attribute("DeliveryMessageStatusType")!.Value),
                Number = header.Element("DeliveryMessageNumber")!.Value,
                Date = new DateTime(
                    year: int.Parse(header.Element("DeliveryMessageDate")!.Element("Date")!.Element("Year")!.Value),
                    month: int.Parse(header.Element("DeliveryMessageDate")!.Element("Date")!.Element("Month")!.Value),
                    day: int.Parse(header.Element("DeliveryMessageDate")!.Element("Date")!.Element("Day")!.Value)),
                References = header.Elements("DeliveryMessageReference").Select(reference => new Reference(
                    reference.Attribute("DeliveryMessageReferenceType")!.Value, reference.Value, reference.Attribute("AssignedBy")?.Value ?? null))
                    .ToList(),
                Buyer = Party.Parse(header.Element("BuyerParty"))!,
                Supplier = Party.Parse(header.Element("SupplierParty"))!,
                Seller = Party.Parse(header.Elements("OtherParty")
                    .Where(element => element.Attribute("PartyType")!.Value == "Seller")
                    .FirstOrDefault())!,
                Sender = Party.Parse(header.Element("SenderParty"))!,
                Receiver = Party.Parse(header.Element("ReceiverParty"))!,
                ShipTo = Party.Parse(header.Element("ShipToInformation")!.Element("ShipToCharacteristics")!.Element("ShipToParty"))!
            }; 
        }

        public override string ToString()
        {
            return
                new XDocument(
                    Stylesheet.Select(stylesheet => new XProcessingInstruction("xml-stylesheet", "type=\"text/xls\" " + $"href=\"{stylesheet}\"")),
                    new XElement("DeliveryMessageWood",
                        new XAttribute("DeliveryMessageType", Type),
                        new XAttribute("DeliveryMessageStatusType", Status),
                        new XElement("DeliveryMessageWoodHeader",
                            new XElement("DeliveryMessageNumber", Number),
                            new XElement("DeliveryMessageDate", GetXDate(Date)),
                            References.Select(reference => XElement.Parse($"{reference}")),
                            XElement.Parse($"{Buyer}"),
                            XElement.Parse($"{Supplier}"),
                            XElement.Parse($"{Seller}"),
                            XElement.Parse($"{Sender}"),
                            XElement.Parse($"{Receiver}"),
                            new XElement("ShipToInformation",
                                new XElement("ShipToCharacteristics",
                                    XElement.Parse($"{ShipTo}")
                                )
                            )
                        ),
                        Shipments.Select(shipment => XElement.Parse($"{shipment}")),
                        new XElement("DeliveryMessageWoodSummary",
                            new XElement("TotalNumberOfShipments", Shipments.Count)
                        )
                    )
                ).ToString();
        }
    }

    public class Reference(string type, string value, string? assignedBy = null)
    {
        public string Type { get; set; } = type;
        public string Value { get; set; } = value;
        public string? AssignedBy { get; set; } = assignedBy;

        public override string ToString()
        {
            return new XElement("DeliveryMessageReference",
                new XAttribute("DeliveryMessageReferenceType", Type),
                AssignedBy != null ? new XAttribute("AssignedBy", AssignedBy) : null,
                Value
            ).ToString();
        }

        public static List<Reference> Parse(string path)
        {
            var xml = XElement.Load(path);

            return xml.Elements("DeliveryMessageReference")
                .Select(reference => new Reference(
                    type: reference.Attribute("DeliveryMessageReferenceType")?.Value,
                    value: reference.Value,
                    assignedBy: reference.Attribute("AssignedBy")?.Value
                    ))
                .ToList();                
        }
    }

    public class Party(string name = "OtherParty", string? type = null, params Identifier[] identifiers)
    {
        public string Name { get; set; } = name;
        public string? Type { get; set; } = type;
        public List<Identifier> Identifiers { get; set; } = identifiers.ToList();
        public NameAddress NameAddress { get; set; } = new();

        public static Party? Parse(XElement? xElement)
        {
            if (xElement == null)
                return null;

            return new Party(xElement.Name.LocalName, xElement.Attribute("PartyType")?.Value, xElement.Elements("PartyIdentifier")
                .Select(identifier => new Identifier(identifier.Attribute("PartyIdentifierType")!.Value, identifier.Value))
                .ToArray())
            {
                NameAddress = NameAddress.Parse(xElement.Element("NameAddress"))!
            };
        }

        public override string ToString()
        {
            return new XElement(Name,
                Type != null ? new XAttribute("PartyType", $"{Type}") : null,
                Identifiers.Select(identifier => XElement.Parse($"{identifier}")),
                XElement.Parse($"{NameAddress}")
            ).ToString();
        }
    }

    public class Identifier(string type, string number)
    {
        public string Type { get; set; } = type;
        public string Number { get; set; } = number;

        public override string ToString()
        {
            return new XElement("PartyIdentifier",
                new XAttribute("PartyIdentifierType", $"{Type}"),
                Number
            ).ToString();
        }
    }

    public class NameAddress
    {
        public string? Name1 { get; set; } = null;
        public string? Address1 { get; set; } = null;
        public string? Name2 { get; set; } = null;
        public string? Address2 { get; set; } = null;
        public string? City { get; set; } = null;
        public string? County { get; set; } = null;
        public string? PostalCode { get; set; } = null;
        public string? Country { get; set; } = null;
        public string? CountryCode { get; set; } = null;

        public static NameAddress? Parse(XElement? xElement)
        {
            if (xElement == null)
                return null;

            return new NameAddress
            {
                Name1 = xElement.Element("Name1")?.Value ?? null,
                Address1 = xElement.Element("Address1")?.Value ?? null,
                Name2 = xElement.Element("Name2")?.Value ?? null,
                Address2 = xElement.Element("Address2")?.Value ?? null,
                City = xElement.Element("City")?.Value ?? null,
                County = xElement.Element("County")?.Value ?? null,
                PostalCode = xElement.Element("PostalCode")?.Value ?? null,
                Country = xElement.Element("Country")?.Value ?? null,
                CountryCode = xElement.Attribute("ISOCountryCode")?.Value ?? null
            };
        }

        public override string ToString()
        {
            return new XElement("NameAddress",
                Name1 != null ? new XElement("Name1", Name1) : null,
                Address1 != null ? new XElement("Address1", Address1) : null,
                Name2 != null ? new XElement("Name2", Name2) : null,
                Address2 != null ? new XElement("Address2", Address2) : null,
                City != null ? new XElement("City", City) : null,
                County != null ? new XElement("County", County) : null,
                PostalCode != null ? new XElement("PostalCode", PostalCode) : null,
                Country != null ? new XElement("Country",
                    CountryCode != null ? new XAttribute("CountryCode", CountryCode) : null,
                    Country) : null
            ).ToString();
        }
    }

    public class Shipment
    {
        public List<ProductGroup> ProductGroups { get; set; } = [];

        public override string ToString()
        {
            return new XElement("DeliveryMessageShipment",
                ProductGroups.Select(group => XElement.Parse($"{group}"))
            ).ToString();
        }
    }

    public class ProductGroup
    {
        public List<LineItem> LineItems { get; set; } = [];

        public override string ToString()
        {
            return new XElement("DeliveryMessageProductGroup",
                LineItems.Select(item => XElement.Parse($"{item}"))
            ).ToString();
        }
    }

    public class LineItem(string number)
    {
        public string Number { get; set; } = number;
        public List<Product> Products { get; set; } = [];

        public override string ToString()
        {
            return new XElement("DeliveryShipmentLineItem",
                new XElement("DeliveryShipmentLineItemNumber", Number),
                Products.Select(product => XElement.Parse($"{product}"))
            ).ToString();
        }
    }

    public class Product
    {
        public List<ProductIdentifier> Identifiers { get; set; } = [];
        public List<string> Descriptions { get; set; } = [];
        public Classification Species { get; set; }
        public Classification Grade { get; set; }
        public Dimension Width { get; set; }
        public Dimension Thickness { get; set; }

        public Product(List<string> descriptions, Classification species, Classification grade, Dimension width, Dimension thickness)
        {
            Descriptions = descriptions;
            Species = species;
            Grade = grade;
            Width = width;
            Thickness = thickness;
        }

        Product()
        {

        }

        public static Product Parse(XElement xElement)
        {
            return new Product
            {
                Identifiers = xElement.Elements("ProductIdentifier")!
                    .Select(identifier => new ProductIdentifier(
                        identifier.Value,
                        identifier.Attribute("ProductIdentifierType")!.Value,
                        identifier.Attribute("Agency")!.Value))
                    .ToList(),
                Descriptions = xElement.Elements("ProductDescription")
                    .Select(description => description.Value)
                    .ToList(),    
                //Species = new Classification("LumberSpecies"
            };
        }

        public override string ToString()
        {
            return new XElement("Product",
                Identifiers.Select(identifier => XElement.Parse($"{identifier}")),
                Descriptions.Select(description => new XElement("ProductDescription", description)),
                new XElement("WoodProducts",
                    new XElement("WoodTimbersDimensionalLumberBoards",
                        new XElement("SoftwoodLumber",
                            new XElement("SoftwoodLumberCharacteristics",
                                new XElement("LumberSpecies",
                                    new XAttribute("SpeciesType", Species.Name),
                                    new XElement("SpeciesCode", Species.Code)
                                ),
                                new XElement("LumberGrade",
                                    Grade.Agency != null ? new XAttribute("GradeAgency", Grade.Agency) : null,
                                    new XElement("GradeName", Grade.Name),
                                    new XElement("GradeCode", Grade.Code)
                                ),
                                new XElement("Width", 
                                    new XAttribute("ActualNominal", Width.Type),
                                    new XElement("Value",
                                        new XAttribute("UOM", Width.Unit),
                                        Width.Value
                                    )
                                ),
                                new XElement("Thickness",
                                    new XAttribute("ActualNominal", Thickness.Type),
                                    new XElement("Value",
                                        new XAttribute("UOM", Thickness.Unit),
                                        Thickness.Value
                                    )
                                )
                            )
                        )
                    )
                )
            ).ToString();
        }
    }

    public class ProductIdentifier(string number, string type, string agency)
    {
        public string Number { get; set; } = number;
        public string Type { get; set; } = type;
        public string Agency { get; set; } = agency;

        public override string ToString()
        {
            return new XElement("ProductIdentifier",
                new XAttribute("Agency", Agency),
                new XAttribute("ProductIdentifierType", Type),
                Number
            ).ToString();
        }
    }

    public class Dimension(bool actual, string unit, string value)
    {
        public bool Actual { get; set; } = actual;
        public string Type => Actual ? "Actual" : "Nominal";
        public string Unit { get; set; } = unit;
        public string Value { get; set; } = value;
    }

    public class Classification
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string? Agency { get; set; }

        public Classification(string name, string code, string? type = null, string? agency = null)
        {
            Name = name;
            Code = code;
            Type = type ?? string.Empty;
            Agency = agency;
        }
    }
}
