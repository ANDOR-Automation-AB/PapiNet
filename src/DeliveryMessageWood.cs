using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PapiNet.WoodX
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
        public Terms Terms { get; set; }
        public Shipment Shipment { get; set; } = new();

        public void Write(string path)
        {
            var doc = new XDocument(
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
                                identifier.Name)),
                            new XElement("NameAddress",
                                Buyer.NameAddress.Name1 != null ? new XElement("Name1", Buyer.NameAddress.Name1) : null,
                                Buyer.NameAddress.Name2 != null ? new XElement("Name2", Buyer.NameAddress.Name2) : null,
                                Buyer.NameAddress.Address1 != null ? new XElement("Address1", Buyer.NameAddress.Address1) : null,
                                Buyer.NameAddress.Address2 != null ? new XElement("Address2", Buyer.NameAddress.Address2) : null,
                                Buyer.NameAddress.City != null ? new XElement("City", Buyer.NameAddress.City) : null,
                                Buyer.NameAddress.Country != null ? new XElement("County", Buyer.NameAddress.Country) : null,
                                Buyer.NameAddress.PostalCode != null ? new XElement("PostalCode", Buyer.NameAddress.PostalCode) : null,
                                Buyer.NameAddress.Country != null ? new XElement("Country",
                                    Buyer.NameAddress.CountryCode != null ? new XAttribute("CountryCode", Buyer.NameAddress.CountryCode) : null,
                                    Buyer.NameAddress.Country) : null)),
                        new XElement(Supplier.Name,
                            Supplier.Identifiers.Select(identifier => new XElement("PartyIdentifier",
                                new XAttribute("PartyIdentifierType", identifier.Type),
                                identifier.Name)),
                            new XElement("NameAddress",
                                Supplier.NameAddress.Name1 != null ? new XElement("Name1", Supplier.NameAddress.Name1) : null,
                                Supplier.NameAddress.Name2 != null ? new XElement("Name2", Supplier.NameAddress.Name2) : null,
                                Supplier.NameAddress.Address1 != null ? new XElement("Address1", Supplier.NameAddress.Address1) : null,
                                Supplier.NameAddress.Address2 != null ? new XElement("Address2", Supplier.NameAddress.Address2) : null,
                                Supplier.NameAddress.City != null ? new XElement("City", Supplier.NameAddress.City) : null,
                                Supplier.NameAddress.Country != null ? new XElement("County", Supplier.NameAddress.Country) : null,
                                Supplier.NameAddress.PostalCode != null ? new XElement("PostalCode", Supplier.NameAddress.PostalCode) : null,
                                Supplier.NameAddress.Country != null ? new XElement("Country",
                                    Supplier.NameAddress.CountryCode != null ? new XAttribute("CountryCode", Supplier.NameAddress.CountryCode) : null,
                                    Supplier.NameAddress.Country) : null)),
                        Other.Select(party => new XElement(party.Name,
                            party.Identifiers.Select(identifier => new XElement("PartyIdentifier",
                                new XAttribute("PartyIdentifierType", identifier.Type),
                                identifier.Name)),
                            new XElement("NameAddress",
                                party.NameAddress.Name1 != null ? new XElement("Name1", party.NameAddress.Name1) : null,
                                party.NameAddress.Name2 != null ? new XElement("Name2", party.NameAddress.Name2) : null,
                                party.NameAddress.Address1 != null ? new XElement("Address1", party.NameAddress.Address1) : null,
                                party.NameAddress.Address2 != null ? new XElement("Address2", party.NameAddress.Address2) : null,
                                party.NameAddress.City != null ? new XElement("City", party.NameAddress.City) : null,
                                party.NameAddress.Country != null ? new XElement("County", party.NameAddress.Country) : null,
                                party.NameAddress.PostalCode != null ? new XElement("PostalCode", party.NameAddress.PostalCode) : null,
                                party.NameAddress.Country != null ? new XElement("Country",
                                    party.NameAddress.CountryCode != null ? new XAttribute("CountryCode", party.NameAddress.CountryCode) : null,
                                    party.NameAddress.Country) : null))),
                        new XElement(Sender.Name,
                            Sender.Type != null ? new XAttribute("PartyType", Sender.Type) : null,
                            Sender.Identifiers.Select(identifier => new XElement("PartyIdentifier",
                                new XAttribute("PartyIdentifierType", identifier.Type),
                                identifier.Name)),
                            new XElement("NameAddress",
                                Sender.NameAddress.Name1 != null ? new XElement("Name1", Sender.NameAddress.Name1) : null,
                                Sender.NameAddress.Name2 != null ? new XElement("Name2", Sender.NameAddress.Name2) : null,
                                Sender.NameAddress.Address1 != null ? new XElement("Address1", Sender.NameAddress.Address1) : null,
                                Sender.NameAddress.Address2 != null ? new XElement("Address2", Sender.NameAddress.Address2) : null,
                                Sender.NameAddress.City != null ? new XElement("City", Sender.NameAddress.City) : null,
                                Sender.NameAddress.Country != null ? new XElement("County", Sender.NameAddress.Country) : null,
                                Sender.NameAddress.PostalCode != null ? new XElement("PostalCode", Sender.NameAddress.PostalCode) : null,
                                Sender.NameAddress.Country != null ? new XElement("Country",
                                    Sender.NameAddress.CountryCode != null ? new XAttribute("CountryCode", Sender.NameAddress.CountryCode) : null,
                                    Sender.NameAddress.Country) : null)),
                        new XElement(Receiver.Name,
                            Receiver.Type != null ? new XAttribute("PartyType", Receiver.Type) : null,
                            Receiver.Identifiers.Select(identifier => new XElement("PartyIdentifier",
                                new XAttribute("PartyIdentifierType", identifier.Type),
                                identifier.Name)),
                            new XElement("NameAddress",
                                Receiver.NameAddress.Name1 != null ? new XElement("Name1", Receiver.NameAddress.Name1) : null,
                                Receiver.NameAddress.Name2 != null ? new XElement("Name2", Receiver.NameAddress.Name2) : null,
                                Receiver.NameAddress.Address1 != null ? new XElement("Address1", Receiver.NameAddress.Address1) : null,
                                Receiver.NameAddress.Address2 != null ? new XElement("Address2", Receiver.NameAddress.Address2) : null,
                                Receiver.NameAddress.City != null ? new XElement("City", Receiver.NameAddress.City) : null,
                                Receiver.NameAddress.Country != null ? new XElement("County", Receiver.NameAddress.Country) : null,
                                Receiver.NameAddress.PostalCode != null ? new XElement("PostalCode", Receiver.NameAddress.PostalCode) : null,
                                Receiver.NameAddress.Country != null ? new XElement("Country",
                                    Receiver.NameAddress.CountryCode != null ? new XAttribute("CountryCode", Receiver.NameAddress.CountryCode) : null,
                                    Receiver.NameAddress.Country) : null)),
                        new XElement("ShipToInformation",
                            new XElement("ShipToCharacteristics",
                                new XElement(ShipTo.Name,
                                    ShipTo.Type != null ? new XAttribute("PartyType", ShipTo.Type) : null,
                                    ShipTo.Identifiers.Select(identifier => new XElement("PartyIdentifier",
                                        new XAttribute("PartyIdentifierType", identifier.Type),
                                        identifier.Name)),
                                    new XElement("NameAddress",
                                        ShipTo.NameAddress.Name1 != null ? new XElement("Name1", ShipTo.NameAddress.Name1) : null,
                                        ShipTo.NameAddress.Name2 != null ? new XElement("Name2", ShipTo.NameAddress.Name2) : null,
                                        ShipTo.NameAddress.Address1 != null ? new XElement("Address1", ShipTo.NameAddress.Address1) : null,
                                        ShipTo.NameAddress.Address2 != null ? new XElement("Address2", ShipTo.NameAddress.Address2) : null,
                                        ShipTo.NameAddress.City != null ? new XElement("City", ShipTo.NameAddress.City) : null,
                                        ShipTo.NameAddress.Country != null ? new XElement("County", ShipTo.NameAddress.Country) : null,
                                        ShipTo.NameAddress.PostalCode != null ? new XElement("PostalCode", ShipTo.NameAddress.PostalCode) : null,
                                        ShipTo.NameAddress.Country != null ? new XElement("Country",
                                            ShipTo.NameAddress.CountryCode != null ? new XAttribute("CountryCode", ShipTo.NameAddress.CountryCode) : null,
                                            ShipTo.NameAddress.Country) : null)),
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
                                        identifier.Name)),
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
                    new XElement("DeliveryMessageWoodSummary")));
            doc.Save(path);
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

    public class Identifier(string name, string type, string? agency = null)
    {
        public string Type { get; set; } = type;
        public string Name { get; set; } = name;
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
        public string Type { get; set; } = actual ? "Actual" : "Nominal";
        public string Unit { get; set; }
        public string Value { get; set; }
    }
}
