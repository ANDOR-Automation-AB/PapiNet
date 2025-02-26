using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PapiNet.WoodX.old2
{
    public class DeliveryMessage(string number, DateTime date)
    {
        public string Number { get; set; } = number;
        public DateTime Date { get; set; } = date;
        public string Type { get; set; }
        public string Status { get; set; }
        public List<Reference> References { get; set; } = [];
        public Party Buyer { get; set; } = new("BuyerParty");
        public Party Supplier { get; set; } = new("SupplierParty");
        public List<Party> Other { get; set; } = [];
        public Party Sender { get; set; } = new("SenderParty", "Seller");
        public Party Receiver { get; set; } = new("ReceiverParty", "Consignee");
        public Party ShipTo { get; set; } = new("ShipToParty", "PlaceOfDischarge");
        public Terms Terms { get; set; } = new();
        public Shipment Shipment { get; set; } = new();
        public Summary Summary { get; set; } = new();

        public override string ToString()
        {
            return new XDocument(
                new XElement("DeliveryMessageWood",
                    new XAttribute("DeliveryMessageType", Type),
                    new XAttribute("DeliveryMessageStatusType", Status),
                    new XElement("DeliveryMessageWoodHeader",
                        new XElement("DeliveryMessageNumber", Number),
                        new XElement("DeliveryMessageDate",
                            new XElement("Date",
                                new XElement("Year", Date.Year),
                                new XElement("Month", $"{Date.Month:XX}"),
                                new XElement("Day", $"{Date.Day:XX}"))),
                        References.Select(reference => new XElement("DeliveryMessageReference",
                            new XAttribute("DeliveryMessageReferenceType", reference.Type),
                            new XAttribute("AssignedBy", reference.AssignedBy),
                            reference.Number)),
                        new XElement(Buyer.Name,
                            Buyer.Identifiers.Select(identifier => new XElement("PartyIdentifier",
                                new XAttribute("PartyIdentifierType", identifier.Type),
                                identifier.Value)),
                            $"{Buyer.NameAddress}"),
                        new XElement(Supplier.Name,
                            Supplier.Identifiers.Select(identifier => new XElement("PartyIdentifier",
                                new XAttribute("PartyIdentifierType", identifier.Type),
                                identifier.Value)),
                            $"{Supplier.NameAddress}"),
                        Other.Select(party => new XElement(party.Name,
                            party.Identifiers.Select(identifier => new XElement("PartyIdentifier",
                                new XAttribute("PartyIdentifierType", identifier.Type),
                                identifier.Value)),
                            $"{party.NameAddress}")),
                        new XElement(Sender.Name,
                            Sender.Type != null ? new XAttribute("PartyType", Sender.Type) : null,
                            Sender.Identifiers.Select(identifier => new XElement("PartyIdentifier",
                                new XAttribute("PartyIdentifierType", identifier.Type),
                                identifier.Value)),
                            $"{Sender.NameAddress}"),
                        new XElement(Receiver.Name,
                            Receiver.Type != null ? new XAttribute("PartyType", Receiver.Type) : null,
                            Receiver.Identifiers.Select(identifier => new XElement("PartyIdentifier",
                                new XAttribute("PartyIdentifierType", identifier.Type),
                                identifier.Value)),
                            $"{Receiver.NameAddress}"),
                        new XElement("ShipToInformation",
                            new XElement("ShipToCharacteristics",
                                new XElement(ShipTo.Name,
                                    ShipTo.Type != null ? new XAttribute("PartyType", ShipTo.Type) : null,
                                    ShipTo.Identifiers.Select(identifier => new XElement("PartyIdentifier",
                                        new XAttribute("PartyIdentifierType", identifier.Type),
                                        identifier.Value)),
                                    $"{ShipTo.NameAddress}"),
                                new XElement("TermsOfDelivery",
                                    new XElement("IncotermsLocation",
                                        new XAttribute("Incoterms", Terms.Incoterms),
                                        new XAttribute("IncotermsVersion", Terms.Version),
                                        Terms.Location),
                                    Terms.AdditionalText != null ? new XElement("AdditionalText", Terms.AdditionalText) : null)))),
                    new XElement("DeliveryMessageShipment",
                        new XElement("DeliveryMessageProductGroup",
                            Shipment.Items.Select(item => new XElement("DeliveryShipmentLineItem",
                                new XElement("DeliveryShipmentLineItemNumber", item.DeliveryNumber),
                                new XElement("PurchaseOrderInformation",
                                    new XElement("PurchaseOrderNumber", item.OrderNumber)),
                                new XElement("PurchaseOrderLineItemNumber", item.PurchaseNumber),
                                item.References.Select(reference => new XElement("DeliveryMessageReference",
                                    new XAttribute("DeliveryMessageReferenceType", reference.Type),
                                    new XAttribute("AssignedBy", reference.AssignedBy),
                                    reference.Number)),
                                new XElement("Product",
                                    item.Product.Identifiers.Select(identifier => new XElement("ProductIdentifier",
                                        new XAttribute("Agency", identifier.Agency),
                                        new XAttribute("ProductIdentifierType", identifier.Type),
                                        identifier.Value)),
                                    item.Product.Description.Select(description => new XElement("ProductDescription", description)),
                                    new XElement("WoodProducts",
                                        new XElement("WoodTimbersDimensionalLumberBoards",
                                            new XElement("SoftwoodLumber",
                                                new XElement("SoftwoodLumberCharacteristics",
                                                    new XElement("LumberSpecies",
                                                        new XAttribute("SpeciesType", item.Product.Species),
                                                        new XElement("SpeciesCode", item.Product.SpeciesCode)),
                                                    new XElement("LumberGrade",
                                                        new XElement("GradeName", item.Product.Grade),
                                                        new XElement("GradeCode", item.Product.GradeCode)),
                                                    new XElement("Width",
                                                        new XAttribute("ActualNominal", item.Product.Width.Type),
                                                        new XElement("Value",
                                                            new XAttribute("UOM", item.Product.Width.Unit),
                                                            item.Product.Width.Value)),
                                                    new XElement("Thickness",
                                                        new XAttribute("ActualNominal", item.Product.Width.Type),
                                                        new XElement("Value",
                                                            new XAttribute("UOM", item.Product.Width.Unit),
                                                            item.Product.Width.Value)),
                                                    new XElement("Seasoning",
                                                        new XAttribute("SeasoningType", item.Product.Seasoning)),
                                                    new XElement("MoistureContent",
                                                        new XAttribute("MoistureContentPercentage", item.Product.Moisture)),
                                                    new XElement("ManufacturingProcess",
                                                        new XAttribute("ManufacturingProcessType", item.Product.Process),
                                                        new XAttribute("ManufacturingProcessAgency", item.Product.ProcessAgency)),
                                                    new XElement("PatternProfile",
                                                        new XAttribute("PatternProfileType", item.Product.Profile),
                                                        new XAttribute("PatternProfileAgency", item.Product.ProcessAgency),
                                                        new XElement("PatternProfileCode", item.Product.ProfileCode),
                                                        item.Product.ProfileText != null ? new XElement("AdditionalText", item.Product.ProfileText) : null)))))),
                                new XElement("TransportPackageInformation"))))),
                    new XElement("DeliveryMessageWoodSummary",
                        new XElement("TotalNumberOfShipments", Summary.ShipmentCount),
                        new XElement("TotalQuantity",
                            new XAttribute("QuantityType", Summary.TotalQuantity.Type),
                            new XAttribute("QuantityTypeContext", Summary.TotalQuantity.Context),
                                new XElement("Value",
                                    new XAttribute("UOM", Summary.TotalQuantity.Unit),
                                    Summary.TotalQuantity.Value)),
                        Summary.InformationalQuantities.Select(quantity => new XElement("TotalInformationalQuantity",
                            new XAttribute("QuantityType", quantity.Type),
                            new XAttribute("QuantityTypeContext", quantity.Context),
                                new XElement("Value",
                                    new XAttribute("UOM", quantity.Unit),
                                    quantity.Value))),
                        Summary.Specifications.Select(specification => new XElement("LengthSpecification",
                            new XElement("LengthCategory",
                                new XAttribute("UOM", specification.CategoryUnit),
                                specification.Category),
                            new XElement("TotalNumberOfUnits",
                                new XElement("Value",
                                    new XAttribute("UOM", specification.CountUnit),
                                    specification.Count)))))))
                .ToString();
        }
    }

    public class Reference(string number)
    {
        public string Type { get; set; }
        public string AssignedBy { get; set; }
        public string Number { get; set; } = number;
    }

    public class Party(string name = "OtherParty", string? type = null)
    {
        public string Name { get; set; } = name;
        public string? Type { get; set; } = type;
        public List<Identifier> Identifiers { get; set; } = [];
        public NameAddress NameAddress { get; set; }
    }

    public class Identifier(string value, string type, string? agency = null)
    {
        public string Type { get; set; } = type;
        public string Value { get; set; } = value;
        public string? Agency { get; set; } = agency;
    }

    public class NameAddress
    {
        public string? Name1 { get; set; } = null;
        public string? Name2 { get; set; } = null;
        public string? Address1 { get; set; } = null;
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
                Name2 != null ? new XElement("Name2", Name2) : null,
                Address1 != null ? new XElement("Address1", Address1) : null,
                Address2 != null ? new XElement("Address2", Address2) : null,
                City != null ? new XElement("City", City) : null,
                Country != null ? new XElement("County", Country) : null,
                PostalCode != null ? new XElement("PostalCode", PostalCode) : null,
                Country != null ? new XElement("Country",
                    CountryCode != null ? new XAttribute("CountryCode", CountryCode) : null,
                    Country) : null
            ).ToString();                
        }
    }

    public class Terms
    {
        public string Incoterms { get; set; }
        public string Version { get; set; }
        public string Location { get; set; }
        public string? AdditionalText { get; set; } = null;
    }

    public class Shipment
    {
        public List<LineItem> Items { get; set; } = [];
    }

    public class LineItem
    {
        public string DeliveryNumber { get; set; }
        public string PurchaseNumber { get; set; }
        public string OrderNumber { get; set; }
        public List<Reference> References { get; set; } = [];
        public Product Product { get; set; }
    }

    public class Product
    {
        public List<Identifier> Identifiers { get; set; }
        public List<string> Description { get; set; } = [];
        public string Species { get; set; }
        public string SpeciesCode { get; set; }
        public string Grade { get; set; }
        public string GradeCode { get; set; }
        public Dimension Width { get; set; }
        public Dimension Thickness { get; set; }
        public string Seasoning { get; set; }
        public string Moisture { get; set; }
        public string Process { get; set; }
        public string ProcessAgency { get; set; }
        public string Profile { get; set; }
        public string ProfileAgency { get; set; }
        public string ProfileCode { get; set; }
        public string? ProfileText { get; set; } = null;
    }

    public class Dimension(bool actual)
    {
        public bool Actual { get; set; } = actual;
        public string Type => Actual ? "Actual" : "Nominal";
        public string Unit { get; set; }
        public string Value { get; set; }
    }

    public class Summary
    {
        public string ShipmentCount { get; set; }
        public Quantity TotalQuantity { get; set; }
        public List<Quantity> InformationalQuantities { get; set; }
        public List<Specification> Specifications { get; set; }
    }
    
    public class Quantity
    {
        public string Type { get; set; }
        public string Context { get; set; }
        public string Unit { get; set; }
        public string Value { get; set; }
    }

    public class Specification
    {
        public string Category { get; set; }
        public string CategoryUnit { get; set; }
        public string Count { get; set; }
        public string CountUnit { get; set; }
    }
}
