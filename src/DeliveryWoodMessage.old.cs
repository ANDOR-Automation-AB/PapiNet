using System.Xml.Linq;
namespace PapiNet.WoodX.Old
{
    public class DeliveryMessage(string type, string status, string number, DateTime date, DeliveryMessageShipment shipment)
    {
        public string Type { get; set; } = type;
        public string Status { get; set; } = status;
        public string Number => Header.Number;
        public DateTime Date => Header.Date;
        public List<DeliveryMessageReference> References => Header.References;

        public Party Buyer
        {
            get => Header.BuyerParty;
            set => Header.BuyerParty = value;
        }

        public Party Supplier
        {
            get => Header.SupplierParty;
            set => Header.SupplierParty = value;
        }

        public List<Party> Other
        {
            get => Header.OtherParty;
            set => Header.OtherParty = value;
        }

        public Party Sender
        {
            get => Header.SenderParty;
            set => Header.SenderParty = value;
        }

        public Party Receiver
        {
            get => Header.ReceiverParty;
            set => Header.ReceiverParty = value;
        }

        public Party Consignee
        {
            get => Header.ShipToInformation.Characteristics.ShipToParty;
            set => Header.ShipToInformation.Characteristics.ShipToParty = value;
        }

        public DeliveryMessageShipment Shipment { get; set; } = shipment;
        private DeliveryMessageHeader Header { get; set; } = new(number, date);
        public DeliveryMessageWoodSummary Summary => new(Shipment);

        public static DeliveryMessage Read(string path)
        {
            var doc = XDocument.Load(path);
            var root = doc.Root;

            if (root == null || root.Name.LocalName != "DeliveryMessageWood")
                throw new InvalidDataException("XML-filen innehåller inget DeliveryMessageWood-element.");

            var type = root.Attribute("DeliveryMessageType")?.Value ?? "Unknown";
            var status = root.Attribute("DeliveryMessageStatusType")?.Value ?? "Unknown";

            var headerElement = root.Element("DeliveryMessageWoodHeader");
            var number = headerElement?.Element("DeliveryMessageNumber")?.Value ?? "Unknown";
            var dateElement = headerElement?.Element("DeliveryMessageDate")?.Element("Date");
            var date = XHelpers.ParseDate(dateElement) ?? DateTime.MinValue;

            var references = headerElement?.Elements("DeliveryMessageReference")
                .Select(x => new DeliveryMessageReference(
                    x.Attribute("AssignedBy")?.Value ?? "Unknown",
                    x.Attribute("DeliveryMessageReferenceType")?.Value ?? "Unknown",
                    x.Value
                )).ToList() ?? new List<DeliveryMessageReference>();

            var buyer = Party.Parse(headerElement?.Element("BuyerParty"));
            var supplier = Party.Parse(headerElement?.Element("SupplierParty"));
            var sender = Party.Parse(headerElement?.Element("SenderParty"));
            var receiver = Party.Parse(headerElement?.Element("ReceiverParty"));

            var otherParties = headerElement?.Elements("OtherParty")
                .Select(Party.Parse)
                .ToList() ?? new List<Party>();

            var shipmentElement = root.Element("DeliveryMessageShipment");
            var shipment = DeliveryMessageShipment.Parse(shipmentElement);

            return new DeliveryMessage(type, status, number, date, shipment)
            {
                Buyer = buyer,
                Supplier = supplier,
                Sender = sender,
                Receiver = receiver,
                Other = otherParties
            };
        }


        public override string ToString()
        {
            return new XElement("DeliveryMessageWood",
                XElement.Parse($"{Header}"),
                XElement.Parse($"{Shipment}"),
                XElement.Parse($"{Summary}")
            ).ToString();
        }
    }

    public class DeliveryMessageHeader(string number, DateTime date)
    {
        public string Number { get; set; } = number;
        public DateTime Date { get; set; } = date;
        public Party BuyerParty { get; set; } = new("BuyerParty");
        public Party SupplierParty { get; set; } = new("SupplierParty");
        public List<Party> OtherParty { get; set; } = [];
        public Party SenderParty { get; set; } = new("SenderParty");
        public Party ReceiverParty { get; set; } = new("ReceiverParty");
        public List<DeliveryMessageReference> References { get; set; } = [];
        public ShipToInformation ShipToInformation { get; set; } = new();

        public override string ToString()
        {
            return new XElement("DeliveryMessageHeader",
                new XElement("DeliveryMessageNumber", Number),
                XHelpers.GetXDate(Date),
                References.Select(reference => XElement.Parse($"{reference}")),
                XElement.Parse($"{BuyerParty}"),
                XElement.Parse($"{SupplierParty}"),
                OtherParty.Select(party => XElement.Parse($"{party}")),
                XElement.Parse($"{SenderParty}"),
                XElement.Parse($"{ReceiverParty}"),
                XElement.Parse($"{ShipToInformation}")
            ).ToString();
        }
    }

    public class DeliveryMessageReference(string assignedBy, string type, string number)
    {
        public string AssignedBy { get; set; } = assignedBy;
        public string Type { get; set; } = type;
        public string Number { get; set; } = number;

        public override string ToString()
        {
            return new XElement("DeliveryMessageReference",
                new XAttribute("DeliveryMessageReferenceType", $"{Type}"),
                new XAttribute("AssignedBy", $"{AssignedBy}"),
                Number
            ).ToString();
        }
    }

    public class Party(string name = "OtherParty", string? type = null,  params PartyIdentifier[] identifiers)
    {
        public string Name { get; set; } = name;
        public string? Type { get; set; } = type;
        public List<PartyIdentifier> Identifiers { get; set; } = identifiers.ToList();
        public NameAddress NameAddress { get; set; } = new();

        public static Party Parse(XElement? element)
        {
            if (element == null)
                return new Party();

            var name = element.Name.LocalName;
            var type = element.Attribute("PartyType")?.Value;

            var identifiers = element.Elements("PartyIdentifier")
                .Select(x => new PartyIdentifier(
                    x.Attribute("PartyIdentifierType")?.Value ?? "Unknown",
                    x.Value
                )).ToList();

            var nameAddressElement = element.Element("NameAddress");
            var nameAddress = new NameAddress
            {
                Name = nameAddressElement?.Element("Name1")?.Value,
                Address = nameAddressElement?.Element("Address1")?.Value,
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

    public class PartyIdentifier(string type, string id)
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
        public string? Name { get; set; } = null;
        public string? Address { get; set; } = null;
        public string? City { get; set; } = null;
        public string? County { get; set; } = null;
        public string? PostalCode { get; set; } = null;
        public string? Country { get; set; } = null;
        public string? CountryCode { get; set; } = null;

        public override string ToString()
        {
            return new XElement("NameAddress",
                Name != null ? new XElement("Name1", Name) : null,
                Address != null ? new XElement("Address1", Address) : null,
                City != null ? new XElement("City", City) : null,
                County != null ? new XElement("County", Country) : null,
                PostalCode != null ? new XElement("PostalCode", PostalCode) : null,
                Country != null ? new XElement("Country",
                    CountryCode != null ? new XAttribute("CountryCode", CountryCode) : null,
                    Country) : null
            ).ToString();
        }
    }

    public class ShipToInformation
    {
        public ShipToCharacteristics Characteristics { get; set; } = new();

        public override string ToString()
        {
            return new XElement("ShipToInformation",
                XElement.Parse($"{Characteristics}")
            ).ToString();
        }
    }

    public class ShipToCharacteristics
    {
        public Party ShipToParty { get; set; } = new("ShipToParty", "Consignee");

        public TermsOfDelivery? TermsOfDelivery { get; set; } = null; // Not mandatory

        public override string ToString()
        {
            return new XElement("ShipToCharacteristics",
                XElement.Parse($"{ShipToParty}")
            ).ToString();
        }
    }

    public class TermsOfDelivery
    {
        // TODO: IncotermsLocation
    }

    public class DeliveryMessageShipment(string id, DeliveryMessageProductGroup productGroup, string shipmentIdType = "LotIdentifier")
    {
        public string Id { get; set; } = id;
        public string Type { get; set; } = shipmentIdType;
        public DeliveryMessageProductGroup ProductGroup { get; set; } = productGroup;

        public static DeliveryMessageShipment Parse(XElement? element)
        {
            if (element == null)
                return new DeliveryMessageShipment("Unknown", new DeliveryMessageProductGroup("Unknown", new List<DeliveryShipmentLineItem>()));

            var id = element.Element("ShipmentID")?.Value ?? "Unknown";

            var productGroupElement = element.Element("DeliveryMessageProductGroup");
            var productGroup = DeliveryMessageProductGroup.Parse(productGroupElement);

            return new DeliveryMessageShipment(id, productGroup);
        }


        public override string ToString()
        {
            return new XElement("DeliveryMessageShipment",
                new XElement("ShipmentID",
                    new XAttribute("ShipmentIDType", Type),
                    Id),
                XElement.Parse($"{ProductGroup}")
            ).ToString();
        }
    }

    public class DeliveryMessageProductGroup(string id, List<DeliveryShipmentLineItem> items, string type = "BillOfLadingMark")
    {
        public string Type { get; set; } = type;
        public string Id { get; set; } = id;
        public List<DeliveryShipmentLineItem> Items { get; set; } = items;

        public static DeliveryMessageProductGroup Parse(XElement? element)
        {
            if (element == null)
                return new DeliveryMessageProductGroup("Unknown", new List<DeliveryShipmentLineItem>());

            var id = element.Element("ProductGroupID")?.Value ?? "Unknown";

            var items = element.Elements("DeliveryShipmentLineItem")
                .Select(DeliveryShipmentLineItem.Parse)
                .ToList();

            return new DeliveryMessageProductGroup(id, items);
        }


        public override string ToString()
        {
            return new XElement("DeliveryMessageProductGroup",
                new XElement("ProductGroupID",
                    new XAttribute("ProductGroupIDType", Type),
                    Id),
                Items.Select(item => XElement.Parse($"{item}"))
            ).ToString();
        }
    }

    public class DeliveryShipmentLineItem(string itemNumber, Product product, List<TransportPackageInformation> packageInformation)
    {
        public string Number { get; set; } = itemNumber;
        public Product Product { get; set; } = product;
        public List<TransportPackageInformation> PackageInformation { get; set; } = packageInformation;

        // NOT MANDATORY !!!
        //public PurchaseOrderInformation OrderInformation { get; set; } = new(orderNumber);

        public static DeliveryShipmentLineItem Parse(XElement? element)
        {
            if (element == null)
                return new DeliveryShipmentLineItem("Unknown", new Product("Unknown", new List<ProductIdentifier>()), new List<TransportPackageInformation>());

            var number = element.Element("DeliveryShipmentLineItemNumber")?.Value ?? "Unknown";

            var productElement = element.Element("Product");
            var product = Product.Parse(productElement);

            var packageInfo = element.Elements("TransportPackageInformation")
                .Select(TransportPackageInformation.Parse)
                .ToList();

            return new DeliveryShipmentLineItem(number, product, packageInfo);
        }


        public override string ToString()
        {
            return new XElement("DeliveryShipmentLineItem",
                new XElement("DeliveryShipmentLineItemNumber", Number),
                XElement.Parse($"{Product}"),
                PackageInformation.Select(information => XElement.Parse($"{information}"))
            ).ToString();
        }
    }

    // NOT MANDATORY !!!
    //public class PurchaseOrderInformation(string number, DateTime? date = null)
    //{
    //    public string Number { get; set; } = number;
    //    public DateTime? Date { get; set; } = date;

    //    public override string ToString()
    //    {
    //        return new XElement("PurchaseOrderInformation",
    //            new XElement("PurchaseOrderNumber", Number),
    //            Date != null ? XHelpers.GetDate(Date) : null
    //        ).ToString();
    //    }
    //}

    public class Product(string description, params List<ProductIdentifier> identifiers)
    {
        public List<ProductIdentifier> Identifiers { get; set; } = identifiers;
        public string Description { get; set; } = description;

        public static Product Parse(XElement? element)
        {
            if (element == null)
                return new Product("Unknown", new List<ProductIdentifier>());

            var description = element.Element("ProductDescription")?.Value ?? "Unknown";

            var identifiers = element.Elements("ProductIdentifier")
                .Select(x => new ProductIdentifier(
                    x.Value,
                    x.Attribute("Agency")?.Value ?? "Unknown",
                    x.Attribute("ProductIdentifierType")?.Value ?? "Unknown"
                )).ToList();

            return new Product(description, identifiers);
        }


        public override string ToString()
        {
            return new XElement("Product",
                Identifiers.Select(identifier => XElement.Parse($"{identifier}")),
                new XElement("ProductDescription", Description)
            ).ToString();
        }
    }

    public class ProductIdentifier(string id, string agency, string type = "PartNumber")
    {
        public string Id { get; set; } = id;
        public string Agency { get; set; } = agency;
        public string Type { get; set; } = type;

        public override string ToString()
        {
            return new XElement("ProductIdentifier",
                new XAttribute("ProductIdentifierType", Type),
                new XAttribute("Agency", Agency),
                Id
            ).ToString();
        }
    }

    public class TransportPackageInformation(string id, string itemCount, string unit, WoodItem item, string type = "LengthPackage")
    {
        public string Type { get; set; } = type;
        public string Id { get; set; } = id;
        public string ItemCount { get; set; } = itemCount;
        public string Unit { get; set; } = unit;
        public WoodItem Item { get; set; } = item;

        public static TransportPackageInformation Parse(XElement? element)
        {
            if (element == null)
                return new TransportPackageInformation("Unknown", "0", "Unknown", new WoodItem("Unknown", "Unknown", "0"));

            var id = element.Element("Identifier")?.Value ?? "Unknown";
            var itemCount = element.Element("ItemCount")?.Element("Value")?.Value ?? "0";
            var unit = element.Element("ItemCount")?.Element("Value")?.Attribute("UOM")?.Value ?? "Unknown";

            var woodItemElement = element.Element("WoodItem");
            var woodItem = WoodItem.Parse(woodItemElement);

            return new TransportPackageInformation(id, itemCount, unit, woodItem);
        }


        public override string ToString() 
        {
            return new XElement("TransportPackageInformation",
                new XAttribute("PackageType", Type),
                new XElement("Identifier", 
                    new XAttribute("IdentifierType", "Primary"),
                    new XAttribute("IdentifierCodeType", "Supplier"),
                    Id),
                new XElement("ItemCount",
                    new XElement("Value",
                        new XAttribute("UOM", Unit),
                        ItemCount)),
                XElement.Parse($"{Item}")
            ).ToString();
        }
    }

    public class WoodItem(string category, string unit, string count)
    {
        public string Category { get; set; } = category;
        public string Unit { get; set; } = unit;
        public string Count { get; set; } = count;

        public static WoodItem Parse(XElement? element)
        {
            if (element == null)
                return new WoodItem("Unknown", "Unknown", "0");

            var category = element.Element("LengthSpecification")?.Element("LengthCategory")?.Value ?? "Unknown";
            var unit = element.Element("LengthSpecification")?.Element("LengthCategory")?.Attribute("UOM")?.Value ?? "Unknown";
            var count = element.Element("TotalNumberOfUnits")?.Element("Value")?.Value ?? "0";

            return new WoodItem(category, unit, count);
        }

        public override string ToString()
        {
            return new XElement("WoodItem",
                new XElement("LengthSpecification",
                    new XElement("LengthCategory",
                        new XAttribute("UOM", Unit),
                        Category)),
                new XElement("TotalNumberOfUnits",
                    new XElement("Value",
                    new XAttribute("UOM", "Piece"),
                    Count))
            ).ToString();
        }
    }

    public class DeliveryMessageWoodSummary(DeliveryMessageShipment shipment)
    {
        DeliveryMessageShipment _shipment = shipment;
        public string ShipmentCount => $"{_shipment.ProductGroup.Items.Count}";

        public override string ToString()
        {
            return new XElement("DeliveryMessageWoodSummary",
                new XElement("TotalNumberOfShipments", ShipmentCount)
            ).ToString();
        }
    }
}
