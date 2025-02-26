using System.Xml.Linq;

namespace PapiNet.WoodX.old3
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

    public class DeliveryMessage(string number, DateTime date)
    {
        const string xsi = "http://www.w3.org/2001/XMLSchema-instance";
        public List<string> Stylesheet { get; set; } = new()
        {
            "ISSsubset_papiNetWoodX_DeliveryMessageWood_V2R31_Build20081207.xls"
        };
        public DeliveryMessageType Type { get; set; } = DeliveryMessageType.DeliveryMessage;
        public DeliveryMessageStatusType Status { get; set; } = DeliveryMessageStatusType.Original;
        public string Number { get; set; } = number;
        public DateTime Date { get; set; } = date;
        public List<Reference> References { get; set; } = [];
        public Party Buyer { get; set; } = new("BuyerParty");
        public Party Supplier { get; set; } = new("SupplierParty");
        public List<Party> Other { get; set; } = [];
        public Party Seller { get; set; } = new("OtherParty", "Seller");
        public Party Destination { get; set; } = new("OtherParty", "PlaceFinalDestination");
        public Party SalesAgent { get; set; } = new("OtherParty", "SalesAgent");
        public Party SalesOffice { get; set; } = new("OtherParty", "SalesOffice");
        public Party Sender { get; set; } = new("SenderParty");
        public Party Receiver { get; set; } = new("ReceiverParty");
        public Party ShipTo { get; set; } = new("ShipToParty", "PlaceOfDischarge");
        public Terms? Terms { get; set; } = null;
        public List<Shipment> Shipments { get; set; } = [];

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
                            XElement.Parse($"{Destination}"),
                            XElement.Parse($"{SalesAgent}"),
                            XElement.Parse($"{SalesOffice}"),
                            Other.Select(party => XElement.Parse($"{party}")),
                            XElement.Parse($"{Sender}"),
                            XElement.Parse($"{Receiver}"),
                            new XElement("ShipToInformation",
                                new XElement("ShipToCharacteristics",
                                    XElement.Parse($"{ShipTo}"),
                                    Terms != null ? XElement.Parse($"{Terms}") : null
                                )
                            )
                        ),
                        Shipments.Select(shipment => XElement.Parse($"{shipment}"))
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
    }


    public class Party(string name = "OtherParty", string? type = null, params Identifier[] identifiers)
    {
        public string Name { get; set; } = name;
        public string? Type { get; set; } = type;
        public List<Identifier> Identifiers { get; set; } = identifiers.ToList();
        public NameAddress NameAddress { get; set; } = new();

        public static Party Parse(XElement? element)
        {
            if (element == null)
                return new Party();

            var name = element.Name.LocalName;
            var type = element.Attribute("PartyType")?.Value;

            var identifiers = element.Elements("PartyIdentifier")
                .Select(identifier => new Identifier(
                    identifier.Attribute("PartyIdentifierType")?.Value ?? "Unknown",
                    identifier.Value
                )).ToList();

            var nameAddressElement = element.Element("NameAddress");
            var nameAddress = new NameAddress
            {
                Name1 = nameAddressElement?.Element("Name1")?.Value,
                Address1 = nameAddressElement?.Element("Address1")?.Value,
                Name2 = nameAddressElement?.Element("Name2")?.Value,
                Address2 = nameAddressElement?.Element("Address2")?.Value,
                City = nameAddressElement?.Element("City")?.Value,
                County = nameAddressElement?.Element("County")?.Value,
                PostalCode = nameAddressElement?.Element("PostalCode")?.Value,
                Country = nameAddressElement?.Element("Country")?.Value,
                CountryCode = nameAddressElement?.Element("Country")?.Attribute("CountryCode")?.Value
            };

            return new Party(name, type, identifiers.ToArray()) { NameAddress = nameAddress };
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

    public class Identifier(string type, string id)
    {
        public string Type { get; set; } = type;
        public string Id { get; set; } = id;

        public override string ToString()
        {
            return new XElement("PartyIdentifier",
                new XAttribute("PartyIdentifierType", $"{Type}"),
                Id
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

    public class Terms(IncotermsType incoterms, string version, string location, string? additionalText = null)
    {
        public IncotermsType Incoterms { get; set; } = incoterms;
        public string Version { get; set; } = version;
        public string Location { get; set; } = location;
        public string? AdditionalText { get; set; } = additionalText;

        public override string ToString()
        {
            return new XElement("TermsOfDelivery",
                new XElement("IncotermsLocation",
                    new XAttribute("Incoterms", Incoterms),
                    new XAttribute("IncotermsVersion", Version),
                    Location
                ),
                AdditionalText != null ? new XElement("AdditionalText", AdditionalText) : null
            ).ToString();
        }
    }

    public class Shipment(string shipmentNumber, Product product)
    {
        public string Number { get; set; } = shipmentNumber;
        public string? OrderNumber { get; set; } = null;
        public string? ItemNumber { get; set; } = null;
        public List<Reference> References { get; set; } = [];
        public Product Product { get; set; } = product;
        public override string ToString()
        {
            return new XElement("DeliveryMessageShipment",
                new XElement("DeliveryMessageProductGroup",
                    new XElement("DeliveryMessageProductGroup",
                        new XElement("DeliveryShipmentLineItem",
                            new XElement("DeliveryShipmentLineItemNumber", Number),
                            OrderNumber != null ? new XElement("PurchaseOrderInformation",
                                new XElement("PurchaseOrderNumber", OrderNumber)
                            ) : null,
                            ItemNumber != null ? new XElement("PurchaseOrderLineItemNumber", ItemNumber) : null,
                            References.Select(reference => XElement.Parse($"{reference}"))
                        )
                    )
                )
            ).ToString();
        }
    }

    public class ProductGroup
    {

    }

    public class Product
    {
        public List<Identifier> Identifiers { get; set; } = [];

        public override string ToString()
        {
            return new XElement("Product"
                
            ).ToString();
        }
    }
}