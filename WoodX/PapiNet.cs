using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PapiNet.WoodX;

public class DeliveryMessage
{
    public MessageType Type { get; set; }
    public MessageStatus Status { get; set; }
    public string Number { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.Now;
    public BindingList<Reference> References { get; set; } = [];

    public static implicit operator XElement(DeliveryMessage o) =>
        new XElement("DeliveryMessageWood",
            new XAttribute("DeliveryMessageType", o.Type),
            new XAttribute("DeliveryMessageStatusType", o.Status),
            new XElement("DeliveryMessageNumber", o.Number),
            new XElement("DeliveryMessageDate",
                new XElement("Date",
                    new XElement("Year", o.Date.Year),
                    new XElement("Month", o.Date.Month),
                    new XElement("Day", o.Date.Day))),
            o.References.Select(i => (XElement)i)
        );

    public override string ToString() => ((XElement)this).ToString();
}

public class Party
{
    public BindingList<PartyIdentifier> Identifiers { get; set; } = [];
    //public Address Address { get; set; } = new();
    public string LocalName { get; set; } = string.Empty;
    public PartyType? Type { get; set; } = null;
    public string Name1 { get; set; } = string.Empty;
    public string Address1 { get; set; } = string.Empty;
    public string Address2 { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public ISOCountryCode ISO { get; set; }

    public static implicit operator XElement(Party o) =>
        new XElement(o.LocalName,
            o.Identifiers.Select(i => (XElement)i),
            new XElement("NameAddress",
                new XElement("Name1", o.Name1),
                new XElement("Address1", o.Address1),
                new XElement("Address2", o.Address2),
                new XElement("Country",
                    new XAttribute("ISOCountryCode", o.ISO),
                    o.Country))
            );
}

public enum PartyType
{
    Seller,
    Consignee,
    PlaceOfDischarge
}

public class Address
{
    public string Name1 { get; set; } = string.Empty;
    public string Address1 { get; set; } = string.Empty;
    public string Address2 { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public ISOCountryCode ISO { get; set; }

    public static implicit operator XElement(Address o) =>
        new XElement("NameAddress",
            new XElement("Name1", o.Name1),
            new XElement("Address1", o.Address1),
            new XElement("Address2", o.Address2),
            new XElement("Country",
                new XAttribute("ISOCountryCode", o.ISO),
                o.Country))

    public override string ToString() => ((XElement)this).ToString();
}

public enum ISOCountryCode
{
    SE,
    DK,
}

public class PartyIdentifier
{
    public PartyIdentifierType Type { get; set; }
    public string Value { get; set; } = string.Empty;

    public static implicit operator XElement(PartyIdentifier o) =>
        new XElement("PartyIdentifier",
            new XAttribute("PartyIdentifierType", o.Type),
            o.Value);

    public override string ToString() => ((XElement)this).ToString();
}

public enum PartyIdentifierType
{
    AssignedBySeller,
    VATIdentificationNumber
}

public class Reference
{
    public ReferenceType Type { get; set; }
    public AssignedBy AssignedBy { get; set; }
    public string Value { get; set; } = string.Empty;

    public static implicit operator XElement(Reference o) =>
        new XElement("DeliveryMessageReference",
            new XAttribute("DeliveryMessageReferenceType", o.Type),
            new XAttribute("AssignedBy", o.AssignedBy),
            o.Value);

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