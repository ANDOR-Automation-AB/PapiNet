using PapiNet.WoodX.src;
using System.Xml.Linq;
namespace PapiNet.WoodX
{
    public class DeliveryMessage(string type, string status, string number, DateTime date, DeliveryMessageShipment shipment)
    {
        public string Type { get; set; } = type;
        public string Status { get; set; } = status;
        public string Number => Header.Number;
        public DateTime Date => Header.Date;
        public List<DeliveryMessageReference> References => Header.References;
        public Party Buyer => Header.BuyerParty;
        public Party Supplier => Header.SupplierParty;
        public List<Party> Other => Header.OtherParty;
        public Party Sender => Header.SenderParty;
        public Party Receiver => Header.ReceiverParty;
        public Party Consignee => Header.ShipToInformation.Characteristics.ShipToParty;
        public DeliveryMessageShipment Shipment { get; set; } = shipment;

        private DeliveryMessageHeader Header { get; set; } = new(number, date);

        public override string ToString()
        {
            return new XElement("DeliveryMessageWood",
                XElement.Parse($"{Header}"),
                XElement.Parse($"{Shipment}")
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
                XHelpers.GetDate(Date),
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

    public class DeliveryMessageProductGroup(string id, string type = "BillOfLadingMark")
    {
        public string Type { get; set; } = type;
        public string Id { get; set; } = id;
        public List<DeliveryShipmentLineItem> Items { get; set; } = [];

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

    public class DeliveryShipmentLineItem(string itemNumber, Product product, params List<TransportPackageInformation> packageInformation)
    {
        public string Number { get; set; } = itemNumber;
        public Product Product { get; set; } = product;
        public List<TransportPackageInformation> PackageInformation { get; set; } = packageInformation;

        // NOT MANDATORY !!!
        //public PurchaseOrderInformation OrderInformation { get; set; } = new(orderNumber);

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

    public class TransportPackageInformation(string type = "LengthPackage")
    {
        public string Type { get; set; } = type;

        public override string ToString() 
        {
            return new XElement("TransportPackageInformation",
                new XAttribute("PackageType", Type)
            ).ToString();
        }
    }
}
