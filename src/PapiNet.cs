using System.Net.Http.Headers;
using System.Runtime;
using System.Xml.Linq;

namespace PapiNet;

public class DeliveryMessageWood
{
    public DeliveryMessageType DeliveryMessageType = DeliveryMessageType.DeliveryMessage;
    public DeliveryMessageStatusType DeliveryMessageStatusType = DeliveryMessageStatusType.Original;
    public DeliveryMessageContextType? DeliveryMessageContextType = null;
    public bool? Reissued = null;
    public Language? Language = null;
    public DeliveryMessageWoodHeader DeliveryMessageWoodHeader = new();
    public List<DeliveryMessageShipment> DeliveryMessageShipment = [];
    public DeliveryMessageWoodSummary? DeliveryMessageWoodSummary = null;

    public DeliveryMessageWood() { }

    public DeliveryMessageWood(XElement root)
    {

    }

    public override string ToString()
    {
        return new XElement("DeliveryMessageWood",
            new XAttribute("DeliveryMessageType", DeliveryMessageType),
            new XAttribute("DeliveryMessageStatusType", DeliveryMessageStatusType),
            DeliveryMessageContextType != null ? new XAttribute("DeliveryMessageContextType", DeliveryMessageContextType) : null,
            Reissued != null ? new XAttribute("Reissued", Reissued) : null,
            XElement.Parse($"{DeliveryMessageWoodHeader}"),
            DeliveryMessageShipment.Select(shipment => XElement.Parse($"{shipment}")),
            DeliveryMessageWoodSummary != null ? XElement.Parse($"{DeliveryMessageWoodSummary}") : null
        ).ToString();
    }
}

public class DeliveryMessageWoodSummary
{
    public DeliveryMessageWoodSummary(XElement root)
    {
    }
}

public class DeliveryMessageDate
{
    public Date Date = new();

    public DeliveryMessageDate() { }

    public DeliveryMessageDate(Date date) { Date = date; }

    public DeliveryMessageDate(XElement root)
    {
        Date = root.Element("Date") is XElement date ? new Date(date) : Date;
    }

    public override string ToString()
    {
        return new XElement("DeliveryMessageDate", 
            XElement.Parse($"{Date}")            
        ).ToString();
    }
}

public class Date
{
    public string Year = string.Empty;
    public string Month = string.Empty;
    public string Day = string.Empty;

    public Date() { }

    public Date(XElement root)
    {
        Year = root.Element("Year")?.Value ?? Year;
        Month = root.Element("Month")?.Value ?? Month;
        Day = root.Element("Day")?.Value ?? Day;
    }

    public override string ToString()
    {
        return new XElement("Date",
            new XElement("Year", Year),
            new XElement("Month", Month),
            new XElement("Day", Day)
        ).ToString();
    }
}

public class Time
{
    public string Value = string.Empty;

    public Time() { }

    public Time(string value) { Value = value; }

    public Time(XElement root) { Value = root.Value; }

    public override string ToString()
    {
        return new XElement("Time",
            Value
        ).ToString();
    }
}

public class DeliveryMessageShipment
{
    public string? ShipmentID = null;
    public List<DeliveryMessageProductGroup> DeliveryMessageProductGroup = [];

    public DeliveryMessageShipment() { }

    public DeliveryMessageShipment(XElement root)
    {
    }

    public override string ToString()
    {
        return new XElement("DeliveryMessageShipment"
            
        ).ToString();
    }
}

public class DeliveryMessageProductGroup
{
    public string? ProductGroupID = null;
    public List<DeliveryShipmentLineItem> DeliveryShipmentLineItem = [];
}

public class DeliveryShipmentLineItem
{
    public string DeliveryShipmentLineItemNumber = string.Empty;
    public PurchaseOrderInformation PurchaseOrderInformation = new();
    public string? PurchaseOrderLineItemNumber = null;
    public List<DeliveryMessageReference> DeliveryMessageReference = [];
    public List<DocumentReferenceInformation> DocumentReferenceInformation = [];
    public CountryOfOrigin? CountryOfOrigin = null;
    public CountryOfDestination? CountryOfDestination = null;
    public CountryOfConsumption? CountryOfConsumption = null;
    public TotalNumberOfUnits? TotalNumberOfUnits = null;
    public List<DeliveryDateWindow> DeliveryDateWindow = [];
    public MillProductionInformation? MillProductionInformation = null;
    public QuantityOrderedInformation? QuantityOrderedInformation = null;
    public List<TransportLoadingCharacteristics> TransportLoadingCharacteristics = [];
    public TransportUnloadingCharacteristics? TransportUnloadingCharacteristics = null;
    public List<TransportOtherInstructions> TransportOtherInstructions = [];
    public List<SafetyAndEnvironmentalInformation> SafetyAndEnvironmentalInformation = [];
    public Party? BillToParty = null;
    public Product? Product = null;
}

public class Product
{
    public string ProductIdentifier = string.Empty;
    public List<string> ProductDescription = [];
    public List<Classification> Classification = [];
    public BookManufacturing? BookManufacturing = null;
}

public class BookManufacturing
{
    public List<BookClassification> BookClassification = [];
    public List<ProofInformationalQuantity> ProofInformationalQuantity = [];
    public List<PrepInformation> PrepInformation = [];
    public List<SuppliedComponentInformation> SuppliedComponentInformation = [];
}

public class SuppliedComponentInformation
{
    public Party SupplierParty = new Party() { LocalName = "SupplierParty" };
    public ProductIdentifier ProductIdentifier = new();
    public List<ProductDescription>? ProductDescription = [];
    public List<Classification> Classification = [];
    public List<BookClassification> BookClassification = [];
    public Paper? Paper = null;

}

public class Paper
{
    public PaperCharacteristics? PaperCharacteristics = null;
}

public class PaperCharacteristics
{
    public CoatingTop? CoatingTop = null;
    public CoatingBottom? CoatingBottom = null;
    public FinishType? FinishType = null;
    public PrintType? PrintType = null;
    public List<Abrasion> Abrasion = [];
}

public class Abrasion
{
    public TestMethod? TestMethod = null;
    public TestAgency? TestAgency = null;
    public SampleType? SampleType = null;
    public ResultSource? ResultSource = null;
    public DetailValue? DetailValue = null;
    public DetailRangeMin? DetailRangeMin = null;
    public DetailRangeMax? DetailRangeMax = null;
    public StandardDeviation? StandardDeviation = null;
    public SampleSize? SampleSize = null;
}

public class SampleSize
{
    public string Value = string.Empty;

    public SampleSize() { }

    public SampleSize(XElement root)
    {
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("SampleSize", Value).ToString();
    }
}

public class StandardDeviation : ValueBase
{
    public StandardDeviation(XElement root) : base(root) { }

    public override string LocalName => throw new NotImplementedException();
}

public class DetailRangeMax : ValueBase
{
    public DetailRangeMax(XElement root) : base(root) { }

    public override string LocalName => "DetailRangeMax";
}

public class DetailRangeMin : ValueBase
{
    public DetailRangeMin(XElement root) : base(root) { }

    public override string LocalName => "DetailRangeMin";
}

public class DetailValue : ValueBase
{
    public DetailValue(XElement root) : base(root) { }

    public override string LocalName => "DetailValue";
}

public class ProductDescription
{
    public Language? Language = null;
    public string Value = string.Empty;

    public ProductDescription() { }

    public ProductDescription(XElement root)
    {
        Language = root.Element("Language") is { Value: var l } ? Enum.Parse<Language>(l) : Language;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("ProductDescription",
            Language != null ? new XAttribute("Language", Language) : null,
            Value
        ).ToString();
    }
}

public class ProductIdentifier
{
    public Agency Agency = Agency.Other;
    public ProductIdentifierType ProductIdentifierType = ProductIdentifierType.Other;
    public string Value = string.Empty;

    public ProductIdentifier() { }

    public ProductIdentifier(XElement root)
    {
        Agency = root.Attribute("Agency") is { Value: var a } ? Enum.Parse<Agency>(a) : Agency;
        ProductIdentifierType = root.Attribute("ProductIdentifierType") is { Value: var pit } ? Enum.Parse<ProductIdentifierType>(pit) : ProductIdentifierType;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("ProductIdentifier",
            new XAttribute("Agency", Agency),
            new XAttribute("ProductIdentifierType", ProductIdentifierType),
            Value
        ).ToString();
    }
}

public class PrepInformation
{
    public PrepType? PrepType = null;
    public Party SupplierParty = new() { LocalName = "SupplierParty" };
    public PrepShipDate? PrepShipDate = null;
    public PrepDueDate? PrepDueDate = null;
    public PrepNeededDate? PrepNeededDate = null;
    public List<string> AdditionalText = [];
    public string Value = string.Empty;

    public PrepInformation() { }

    public PrepInformation(XElement root)
    {
        PrepType = root.Element("PrepType") is { Value: var pt } ? Enum.Parse<PrepType>(pt) : PrepType;
        SupplierParty = root.Element("SupplierParty") is { } sp ? new(sp) : SupplierParty;
        PrepShipDate = root.Element("PrepShipDate") is { } psd ? new(psd) : PrepShipDate;
        PrepDueDate = root.Element("PrepDueDate") is { } pdd ? new(pdd) : PrepDueDate;
        PrepNeededDate = root.Element("PrepNeededDate") is { } pnd ? new(pnd) : PrepNeededDate;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
    }

    public override string ToString()
    {
        return new XElement("PrepInformation",
            PrepType != null ? new XAttribute("PrepType", PrepType) : null,
            XElement.Parse($"{SupplierParty}"),
            PrepShipDate != null ? XElement.Parse($"{PrepShipDate}") : null,
            PrepDueDate != null ? XElement.Parse($"{PrepDueDate}") : null,
            PrepNeededDate != null ? XElement.Parse($"{PrepNeededDate}") : null,
            AdditionalText.Select(at => new XElement("AdditionalText", at)),
            Value
        ).ToString();
    }
}

public class PrepNeededDate : DateTimeBase
{
    public override string LocalName => "PrepNeededDate";
    public PrepNeededDate() { }
    public PrepNeededDate(XElement root) : base(root) { }
}

public class PrepDueDate : DateTimeBase
{
    public override string LocalName => "PrepDueDate";
    public PrepDueDate() { }
    public PrepDueDate(XElement root) : base(root) { }
}

public class PrepShipDate : DateTimeBase 
{ 
    public override string LocalName => "PrepShipDate";
    public PrepShipDate() { }
    public PrepShipDate(XElement root) : base(root) { }
}

public abstract class DateTimeBase
{
    public Date Date = new();
    public Time? Time = null;
    public string Value = string.Empty;

    public abstract string LocalName { get; }

    public DateTimeBase() { }

    public DateTimeBase(XElement root)
    {
        Date = root.Element("Date") is { } d ? new(d) : Date;
        Time = root.Element("Time") is { } t ? new(t) : Time;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement(LocalName,
            XElement.Parse($"{Date}"),
            Time != null ? XElement.Parse($"{Time}") : null,
            Value
        ).ToString();
    }
}

public class ProofInformationalQuantity
{
    public ProofType? ProofType = null;
    public Quantity Quantity = new();
    public List<InformationalQuantity> InformationalQuantity = [];
    public Party? OtherParty = null;
    public ProofApprovalDate? ProofApprovalDate = null;
    public ProofDueDate? ProofDueDate = null;
    public List<string> AdditionalText = [];
    public string Value = string.Empty;

    public ProofInformationalQuantity() { }

    public ProofInformationalQuantity(XElement root)
    {
        ProofType = root.Attribute("ProofType") is { Value: var pt } ? Enum.Parse<ProofType>(pt) : ProofType;
        Quantity = root.Element("Quantity") is { } q ? new(q) : Quantity;
        InformationalQuantity = [.. root.Elements("InformationalQuantity").Select(iq => new InformationalQuantity(iq))];
        OtherParty = root.Element("OtherParty") is { } op ? new(op) { LocalName = "OtherParty" } : OtherParty;
        ProofApprovalDate = root.Element("ProofApprovalDate") is { } pad ? new(pad) : ProofApprovalDate;
        ProofDueDate = root.Element("ProofDueDate") is { } pdd ? new(pdd) : ProofDueDate;
        AdditionalText = [.. root.Elements("AdditionalText").Select(at => at.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("ProofInformationalQuantity",
            ProofType != null ? new XAttribute("ProofType", ProofType) : null,
            XElement.Parse($"{Quantity}"),
            InformationalQuantity.Select(iq => XElement.Parse($"{iq}")),
            OtherParty != null ? XElement.Parse($"{OtherParty}") : null,
            ProofApprovalDate != null ? XElement.Parse($"{ProofApprovalDate}") : null,
            ProofDueDate != null ? XElement.Parse($"{ProofDueDate}") : null,
            AdditionalText.Select(at => new XElement("AdditionalText", at)),
            Value
        ).ToString();
    }
}

public class ProofDueDate : DateTimeBase
{
    public override string LocalName => "ProofDueDate";
    public ProofDueDate() { }
    public ProofDueDate(XElement root) : base(root) { }
}

public class ProofApprovalDate : DateTimeBase
{
    public override string LocalName => "ProofApprovalDate";
    public ProofApprovalDate() { }
    public ProofApprovalDate(XElement root) : base(root) { }
}

public class BookClassification
{
    public BookClassificationType BookClassificationType = BookClassificationType.Assembly;
    public List<string> ClassificationDescription = [];
    public List<BookSubClassification> BookSubClassification = [];
    public string Value = string.Empty;

    public BookClassification() { }

    public BookClassification(XElement root)
    {
        BookClassificationType = root.Attribute("BookClassificationType") is { Value: var bct } ? Enum.Parse<BookClassificationType>(bct) : BookClassificationType;
        ClassificationDescription = [.. root.Elements("ClassificationDescription").Select(cd => cd.Value)];
        BookSubClassification = [.. root.Elements("BookSubClassification").Select(bsc => new BookSubClassification(bsc))];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("BookClassification",
            new XAttribute("BookClassificationType", BookClassificationType),
            ClassificationDescription.Select(cd => new XElement("ClassificationDescription", cd)),
            BookSubClassification.Select(bsc => XElement.Parse($"{bsc}")),
            Value
        ).ToString();
    }
}

public class BookSubClassification
{
    public BookSubClassificationType BookSubClassificationType;
    public List<string> ClassificationDescription = [];
    public string Value = string.Empty;

    public BookSubClassification() { }

    public BookSubClassification(XElement root)
    {
        BookSubClassificationType = root.Attribute("BookSubClassificationType") is { Value: var bsct } ? Enum.Parse<BookSubClassificationType>(bsct) : BookSubClassificationType;
        ClassificationDescription = [.. root.Elements("ClassificationDescription").Select(cd => cd.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("BookSubClassification",
            new XAttribute("BookSubClassificationType", BookSubClassificationType),
            ClassificationDescription.Select(cd => new XElement("ClassificationDescription", cd)),
            Value
        ).ToString();
    }
}

public class Classification
{
    public string ClassificationCode = string.Empty;
    public string? ClassificationDescription = string.Empty;
    public string Value = string.Empty;

    public Classification() { }

    public Classification(XElement root)
    {
        ClassificationCode = root.Element("ClassificationCode")?.Value ?? ClassificationCode;
        ClassificationDescription = root.Element("ClassificationDescription")?.Value ?? ClassificationDescription;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("Classification",
            new XElement("ClassificationCode", ClassificationCode),
            ClassificationDescription != null ? new XElement("ClassificationDescription", ClassificationDescription) : null,
            Value
        ).ToString();
    }
}

public class SafetyAndEnvironmentalInformation
{
    public SafetyAndEnvironmentalType SafetyAndEnvironmentalType = SafetyAndEnvironmentalType.MaterialSafetyData;
    public Agency Agency = Agency.Other;
    public string? LicenceNumber = null;
    public string? ChainOfCustody = null;
    public SafetyAndEnvironmentalCertification? SafetyAndEnvironmentalCertification = null;
    public List<string> AdditionalText = [];
    public string Value = string.Empty;

    public SafetyAndEnvironmentalInformation() { }

    public SafetyAndEnvironmentalInformation(XElement root)
    {
        SafetyAndEnvironmentalType = root.Attribute("SafetyAndEnvironmentalType") is { Value: var saet } ? Enum.Parse<SafetyAndEnvironmentalType>(saet) : SafetyAndEnvironmentalType;
        Agency = root.Attribute("Agency") is { Value: var a } ? Enum.Parse<Agency>(a) : Agency;
        LicenceNumber = root.Element("LicenceNumber")?.Value ?? LicenceNumber;
        ChainOfCustody = root.Element("ChainOfCustody")?.Value ?? ChainOfCustody;
        SafetyAndEnvironmentalCertification = root.Element("SafetyAndEnvironmentalCertification") is { } saec ? new(saec) : SafetyAndEnvironmentalCertification;
        AdditionalText = [.. root.Elements("AdditionalText").Select(at => at.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("SafetyAndEnvironmentalInformation",
            new XAttribute("SafetyAndEnvironmentalType", SafetyAndEnvironmentalType),
            new XAttribute("Agency", Agency),
            LicenceNumber != null ? new XElement("LicenceNumber", LicenceNumber) : null,
            ChainOfCustody != null ? new XElement("ChainOfCustody", ChainOfCustody) : null,
            SafetyAndEnvironmentalCertification != null ? XElement.Parse($"{SafetyAndEnvironmentalCertification}") : null,
            AdditionalText.Select(at => new XElement("AdditionalText", at)),
            Value
        ).ToString();
    }
}

public class SafetyAndEnvironmentalCertification : RangeValueBase
{
    public SafetyAndEnvironmentalCertification() : base() { }

    public SafetyAndEnvironmentalCertification(XElement root) : base(root) { }

    public override string LocalName => "SafetyAndEnvironmentalCertification";
}

public class TransportLoadingCharacteristics
{
    public MixProductIndicator? MixProductIndicator = null;
    public TransportLoadingType? TransportLoadingType = null;
    public TransportDeckOption? TransportDeckOption = null;
    public LoadingTolerance? LoadingTolerance = null;
    public DirectLoading? DirectLoading = null;
    public GoodsLoadingPrinciple? GoodsLoadingPrinciple = null;
    public LabelOrientation? LabelOrientation = null;
    public string? TransportLoadingCode = null;
    public TransportLoadingCodeDescription? TransportLoadingCodeDescription = null;
    public List<string> TransportLoadingText = [];
    public string Value = string.Empty;

    public TransportLoadingCharacteristics() { }

    public TransportLoadingCharacteristics(XElement root)
    {
        MixProductIndicator = root.Attribute("MixProductIndicator") is { Value: var mpi } ? Enum.Parse<MixProductIndicator>(mpi) : MixProductIndicator;
        TransportLoadingType = root.Attribute("TransportLoadingType") is { Value: var tlp } ? Enum.Parse<TransportLoadingType>(tlp) : TransportLoadingType;
        TransportDeckOption = root.Attribute("TransportDeckOption") is { Value: var tdo } ? Enum.Parse<TransportDeckOption>(tdo) : TransportDeckOption;
        LoadingTolerance = root.Attribute("LoadingTolerance") is { Value: var lt } ? Enum.Parse<LoadingTolerance>(lt) : LoadingTolerance;
        DirectLoading = root.Attribute("DirectLoading") is { Value: var dl } ? Enum.Parse<DirectLoading>(dl) : DirectLoading;
        GoodsLoadingPrinciple = root.Attribute("GoodsLoadingPrinciple") is { Value: var glp } ? Enum.Parse<GoodsLoadingPrinciple>(glp) : GoodsLoadingPrinciple;
        LabelOrientation = root.Attribute("LabelOrientation") is { Value: var lo } ? Enum.Parse<LabelOrientation>(lo) : LabelOrientation;
        TransportLoadingCode = root.Element("TransportLoadingCode")?.Value ?? TransportLoadingCode;
        TransportLoadingCodeDescription = root.Element("TransportLoadingCodeDescription") is { } tlcd ? new(tlcd) : TransportLoadingCodeDescription;
        TransportLoadingText = [.. root.Elements("TransportLoadingText").Select(tlt => tlt.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportLoadingCharacteristics",
            MixProductIndicator != null ? new XAttribute("MixProductIndicator", MixProductIndicator) : null,
            TransportLoadingType != null ? new XAttribute("TransportLoadingType", TransportLoadingType) : null,
            TransportDeckOption != null ? new XAttribute("TransportDeckOption", TransportDeckOption) : null,
            LoadingTolerance != null ? new XAttribute("LoadingTolerance", LoadingTolerance) : null,
            DirectLoading != null ? new XAttribute("DirectLoading", DirectLoading) : null,
            GoodsLoadingPrinciple != null ? new XAttribute("GoodsLoadingPrinciple", GoodsLoadingPrinciple) : null,
            LabelOrientation != null ? new XAttribute("LabelOrientation", LabelOrientation) : null,
            TransportLoadingCode != null ? new XElement("TransportLoadingCode", TransportLoadingCode) : null,
            TransportLoadingCodeDescription != null ? XElement.Parse($"{TransportLoadingCodeDescription}") : null,
            TransportLoadingText.Select(tlt => new XElement("TransportLoadingText", tlt)),
            Value
        ).ToString();
    }
}

public class TransportLoadingCodeDescription
{
    public List<string> AdditionalText = [];
    public e_Attachment? e_Attachment = null;
    public string Value = string.Empty;

    public TransportLoadingCodeDescription() { }

    public TransportLoadingCodeDescription(XElement root)
    {
        AdditionalText = [.. root.Elements("AdditionalText").Select(t => t.Value)];
        e_Attachment = root.Element("e-Attachment") is { } a ? new(a) : e_Attachment;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportLoadingCodeDescription",
            AdditionalText.Select(t => new XElement("AdditionalText", t)),
            e_Attachment != null ? XElement.Parse($"{e_Attachment}") : null,
            Value
        ).ToString();
    }
}

public class QuantityOrderedInformation
{
    public Quantity Quantity = new();
    public List<InformationalQuantity> InformationalQuantity = [];
    public List<string> AdditionalText = [];
    public List<Length_Object> Length = [];
    public string Value = string.Empty;

    public QuantityOrderedInformation() { }

    public QuantityOrderedInformation(XElement root)
    {
        Quantity = root.Element("Quantity") is { } q ? new(q) : Quantity;
        InformationalQuantity = [.. root.Elements("InformationalQuantity").Select(iq => new InformationalQuantity(iq))];
        AdditionalText = [.. root.Elements("AdditionalText").Select(t => t.Value)];
        Length = [.. root.Elements("Length").Select(l => new Length_Object(l))];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("QuantityOrderedInformation",
            Quantity != null ? XElement.Parse($"{Quantity}") : null,
            InformationalQuantity.Select(iq => XElement.Parse($"{iq}")),
            AdditionalText.Select(t => new XElement("AdditionalText", t)),
            Length.Select(l => XElement.Parse($"{l}")),
            Value
        ).ToString();
    }
}

public class MillProductionInformation
{
    public MillCharacteristics? MillCharacteristics = null;
    public string? MillOrderNumber = null;
    public Quantity? Quantity = null;
    public string Value = string.Empty;

    public MillProductionInformation() { }

    public MillProductionInformation(XElement root)
    {
        MillCharacteristics = root.Element("MillCharacteristics") is { } c ? new(c) : MillCharacteristics;
        MillOrderNumber = root.Element("MillOrderNumber")?.Value ?? MillOrderNumber;
        Quantity = root.Element("Quantity") is { } q ? new(q) : Quantity;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("MillProductionInformation",
            MillCharacteristics != null ? XElement.Parse($"{MillCharacteristics}") : null,
            MillOrderNumber != null ? new XElement("MillOrderNumber", MillOrderNumber) : null,
            Quantity != null ? XElement.Parse($"{Quantity}") : null,
            Value
        ).ToString();
    }
}

public class MillCharacteristics
{
    public Party? MillParty = null;
    public string? MachineID = null;
    public string Value = string.Empty;

    public MillCharacteristics() { }

    public MillCharacteristics(XElement root)
    {
        MillParty = root.Element("MillParty") is { } party ? new(party) { LocalName = "MillParty" } : MillParty;
        MachineID = root.Element("MachineID")?.Value ?? MachineID;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("MillCharacteristics",
            MillParty != null ? XElement.Parse($"{MillParty}") : null,
            MachineID != null ? new XElement("MachineID", MachineID) : null,
            Value
        ).ToString();
    }
}

public abstract class RangeValueBase
{
    public Value Value = new();
    public RangeMin? RangeMin = null;
    public RangeMax? RangeMax = null;

    public abstract string LocalName { get; }

    public RangeValueBase() { }

    public RangeValueBase(XElement root)
    {
        Value = root.Element("Value") is { } value ? new(value) : Value;
        RangeMin = root.Element("RangeMin") is { } min ? new(min) : RangeMin;
        RangeMax = root.Element("RangeMax") is { } max ? new(max) : RangeMax;
    }

    public override string ToString()
    {
        return new XElement(LocalName,
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class TotalNumberOfUnits : RangeValueBase
{
    public override string LocalName => "TotalNumberOfUnits";
    public TotalNumberOfUnits() { }
    public TotalNumberOfUnits(XElement root) : base(root) { }
}

public class PurchaseOrderInformation
{
    public string? PurchaseOrderNumber = null;
    public string? PurchaseOrderReleaseNumber = null;
    public PurchaseOrderIssuedDate? PurchaseOrderIssuedDate = null;
    public List<PurchaseOrderReference> PurchaseOrderReference = [];
    public string Value = string.Empty;

    public PurchaseOrderInformation() { }

    public PurchaseOrderInformation(XElement root)
    {
        PurchaseOrderNumber = root.Element("PurchaseOrderNumber")?.Value ?? PurchaseOrderNumber;
        PurchaseOrderReleaseNumber = root.Element("PurchaseOrderReleaseNumber")?.Value ?? PurchaseOrderReleaseNumber;
        PurchaseOrderIssuedDate = root.Element("PurchaseOrderIssuedDate") is { } e ? new(e) : PurchaseOrderIssuedDate;
        PurchaseOrderReference = [.. root.Elements("PurchaseOrderReference").Select(e => new PurchaseOrderReference(e))];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("PurchaseOrderInformation",
            PurchaseOrderNumber != null ? new XElement("PurchaseOrderNumber", PurchaseOrderNumber) : null,
            PurchaseOrderReleaseNumber != null ? new XElement("PurchaseOrderReleaseNumber", PurchaseOrderReleaseNumber) : null,
            PurchaseOrderIssuedDate != null ? XElement.Parse($"{PurchaseOrderIssuedDate}") : null,
            PurchaseOrderReference.Select(obj => XElement.Parse($"{obj}")),
            Value
        ).ToString();
    }
}

public class PurchaseOrderReference : AssignedByReferenceValueBase
{
    public PurchaseOrderReferenceType PurchaseOrderReferenceType = PurchaseOrderReferenceType.Other;

    public PurchaseOrderReference() : base() { }

    public PurchaseOrderReference(XElement root) : base(root)
    {
        PurchaseOrderReferenceType = root.Attribute("PurchaseOrderReferenceType") is { Value: var v } ? Enum.Parse<PurchaseOrderReferenceType>(v) : PurchaseOrderReferenceType;
    }

    public override string LocalName => "PurchaseOrderReference";

    public override string ToString()
    {
        return new XElement(LocalName,
            new XAttribute("PurchaseOrderReferenceType", PurchaseOrderReferenceType),
            AssignedBy != null ? new XAttribute("AssignedBy", AssignedBy) : null,
            Value
        ).ToString();
    }
}

public class PurchaseOrderIssuedDate : DateTimeBase
{
    public override string LocalName => "PurchaseOrderIssuedDate";
    public PurchaseOrderIssuedDate() { }
    public PurchaseOrderIssuedDate(XElement root) : base(root) { }
}

public class DeliveryMessageWoodHeader
{
    public string DeliveryMessageNumber = string.Empty;
    public string? TransactionHistoryNumber = null;
    public DeliveryMessageDate DeliveryMessageDate = new();
    public List<DeliveryMessageReference> DeliveryMessageReference = [];
    public List<DocumentReferenceInformation> DocumentReferenceInformation = [];
    public Party BuyerParty = new() { LocalName = "BuyerParty" };
    public Party? BillToParty = new() { LocalName = "BillToParty" };
    public Party SupplierParty = new() { LocalName = "SupplierParty" };
    public List<Party> OtherParty = [];
    public Party? SenderParty = new() { LocalName = "SenderParty" };
    public Party? ReceiverParty = new() { LocalName = "ReceiverParty" };
    public List<ShipToInformation> ShipToInformation = [];
    public CountryOfOrigin? CountryOfOrigin = null;
    public CountryOfDestination? CountryOfDestination = null;
    public CountryOfConsumption? CountryOfConsumption = null;
    public Insurance? Insurance = null;
    public List<string> AdditionalText = [];
    public List<DocumentInformation> DocumentInformation = [];
    public string Value = string.Empty;

    public DeliveryMessageWoodHeader() { }

    public DeliveryMessageWoodHeader(XElement root)
    {
        DeliveryMessageNumber = root.Element("DeliveryMessageNumber")?.Value ?? DeliveryMessageNumber;
        TransactionHistoryNumber = root.Element("TransactionHistoryNumber")?.Value ?? TransactionHistoryNumber;
        DeliveryMessageDate = root.Element("DeliveryMessageDate") is { } dmd ? new(dmd) : DeliveryMessageDate;
        DeliveryMessageReference = [.. root.Elements("DeliveryMessageReference").Select(e => new DeliveryMessageReference(e))];
        DocumentReferenceInformation = [.. root.Elements("DocumentReferenceInformation").Select(e => new DocumentReferenceInformation(e))];
        BuyerParty = root.Element("BuyerParty") is { } bp ? new(bp) : BuyerParty;
        BillToParty = root.Element("BillToParty") is { } btp ? new(btp) : BillToParty;
        SupplierParty = root.Element("SupplierParty") is { } supa ? new(supa) : SupplierParty;
        OtherParty = [.. root.Elements("OtherParty").Select(e => new Party(e))];
        SenderParty = root.Element("SenderParty") is { } sepa ? new(sepa) : SenderParty;
        ReceiverParty = root.Element("ReceiverParty") is { } rp ? new(rp) : ReceiverParty;
        ShipToInformation = [.. root.Elements("ShipToInformation").Select(e => new ShipToInformation(e))];
        CountryOfOrigin = root.Element("CountryOfOrigin") is { } coo ? new(coo) : CountryOfOrigin;
        CountryOfDestination = root.Element("CountryOfDestination") is { } cod ? new(cod) : CountryOfDestination;
        CountryOfConsumption = root.Element("CountryOfConsumption") is { } coc ? new(coc) : CountryOfConsumption;
        Insurance = root.Element("Insurance") is { } i ? new(i) : Insurance;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        DocumentInformation = [.. root.Elements("DocumentInformation").Select(e => new DocumentInformation(e))];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("DeliveryMessageWoodHeader",
            new XElement("DeliveryMessageNumber", DeliveryMessageNumber),
            TransactionHistoryNumber != null ? new XElement("TransactionHistoryNumber", TransactionHistoryNumber) : null,
            XElement.Parse($"{DeliveryMessageDate}"),
            DeliveryMessageReference.Select(reference => XElement.Parse($"{reference}")),
            DocumentReferenceInformation.Select(information => XElement.Parse($"{information}")),
            XElement.Parse($"{BuyerParty}"),
            BillToParty != null ? XElement.Parse($"{BillToParty}") : null,
            XElement.Parse($"{SupplierParty}"),
            OtherParty.Select(party => XElement.Parse($"{party}")),
            SenderParty != null ? XElement.Parse($"{SenderParty}") : null,
            ReceiverParty != null ? XElement.Parse($"{ReceiverParty}") : null,
            ShipToInformation.Select(information => XElement.Parse($"{information}")),
            CountryOfOrigin != null ? XElement.Parse($"{CountryOfOrigin}") : null,
            CountryOfDestination != null ? XElement.Parse($"{CountryOfDestination}") : null,
            CountryOfConsumption != null ? XElement.Parse($"{CountryOfConsumption}") : null,
            Insurance != null ? XElement.Parse($"{Insurance}") : null,
            AdditionalText.Select(text => new XElement("AdditionalText", text)),
            DocumentInformation.Select(information => XElement.Parse($"{information}")),
            Value
        ).ToString();
    }
}

public class DocumentInformation
{
    public DocumentType DocumentType = DocumentType.DeliveryNote;
    public List<string> NumberOfDocuments = [];
    public List<string> AdditionalText = [];
    public string Value = string.Empty;

    public DocumentInformation() { }

    public DocumentInformation(XElement root)
    {
        DocumentType = root.Attribute("DocumentType") is { Value: var dt } ? Enum.Parse<DocumentType>(dt) : DocumentType;
        NumberOfDocuments = [.. root.Elements("NumberOfDocuments").Select(e => e.Value)];
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("DocumentInformation",
            new XAttribute("DocumentType", DocumentType),
            NumberOfDocuments.Select(number => new XElement("NumberOfDocuments", number)),
            AdditionalText.Select(text => new XElement("AdditionalText", text)),
            Value
        ).ToString();
    }
}

public class Insurance
{
    public string? Insurer = null;
    public string? InsuranceContractNo = null;
    public InsuredValue? InsuredValue = null;
    public string? InsuranceInfo = null;
    public string Value = string.Empty;

    public Insurance() { }

    public Insurance(XElement root)
    {
        Insurer = root.Element("Insurer")?.Value ?? Insurer;
        InsuranceContractNo = root.Element("InsuranceContractNo")?.Value ?? InsuranceContractNo;
        InsuredValue = root.Element("InsuredValue") is { } iv ? new(iv) : InsuredValue;
        InsuranceInfo = root.Element("InsuranceInfo")?.Value ?? InsuranceInfo;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("Insurance",
            Insurer != null ? new XElement("Insurer", Insurer) : null,
            InsuranceContractNo != null ? new XElement("InsuranceContractNo", InsuranceContractNo) : null,
            InsuredValue != null ? XElement.Parse($"{InsuredValue}") : null,
            InsuranceInfo != null ? new XElement("InsuranceInfo", InsuranceInfo) : null,
            Value
        ).ToString();
    }
}

public class InsuredValue
{
    public string CurrencyValue = string.Empty;
    public string Value = string.Empty;

    public InsuredValue() { }

    public InsuredValue(XElement root)
    {
        CurrencyValue = root.Element("CurrencyValue")?.Value ?? CurrencyValue;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("InsuredValue",
            new XElement("CurrencyValue", CurrencyValue),
            Value
        ).ToString();
    }
}

public class CountryOfConsumption
{
    public string Country = string.Empty;
    public ISOCountryCode? ISOCountryCode = null;
    public string Value = string.Empty;

    public CountryOfConsumption() { }

    public CountryOfConsumption(XElement root)
    {
        Country = root.Element("Country")?.Value ?? Country;
        ISOCountryCode = root.Attribute("ISOCountryCode") is { Value: var isocc } ? Enum.Parse<ISOCountryCode>(isocc) : ISOCountryCode;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("CountryOfConsumption",
            ISOCountryCode != null ? new XAttribute("ISOCountryCode", ISOCountryCode) : null,
            new XElement("Country", Country),
            Value
        ).ToString();
    }
}

public class CountryOfDestination
{
    public string Country = string.Empty;
    public ISOCountryCode? ISOCountryCode = null;
    public string Value = string.Empty;

    public CountryOfDestination() { }

    public CountryOfDestination(XElement root)
    {
        Country = root.Element("Country")?.Value ?? Country;
        ISOCountryCode = root.Attribute("ISOCountryCode") is { Value: var isocc } ? Enum.Parse<ISOCountryCode>(isocc) : ISOCountryCode;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("CountryOfDestination",
            ISOCountryCode != null ? new XAttribute("ISOCountryCode", ISOCountryCode) : null,
            new XElement("Country", Country),
            Value
        ).ToString();
    }
}

public class CountryOfOrigin
{
    public string Country = string.Empty;
    public ISOCountryCode? ISOCountryCode = null;
    public string Value = string.Empty;

    public CountryOfOrigin() { }

    public CountryOfOrigin(XElement root)
    {
        Country = root.Element("Country")?.Value ?? Country;
        ISOCountryCode = root.Attribute("ISOCountryCode") is { Value: var isocc } ? Enum.Parse<ISOCountryCode>(isocc) : ISOCountryCode;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("CountryOfOrigin",
            ISOCountryCode != null ? new XAttribute("ISOCountryCode", ISOCountryCode) : null,
            new XElement("Country", Country),
            Value
        ).ToString();
    }
}

public class ShipToInformation
{
    public ShipToCharacteristics ShipToCharacteristics = new();
    public List<DeliverySchedule> DeliverySchedule = [];
    public string Value = string.Empty;

    public ShipToInformation() { }

    public ShipToInformation(XElement root)
    {
        ShipToCharacteristics = root.Element("ShipToCharacteristics") is { } stc ? new(stc) : ShipToCharacteristics;
        DeliverySchedule = [.. root.Elements("DeliverySchedule").Select(e => new DeliverySchedule(e))];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("ShipToInformation",
            XElement.Parse($"{ShipToCharacteristics}"),
            DeliverySchedule.Select(schedule => XElement.Parse($"{schedule}")),
            Value
        ).ToString();
    }
}

public class DeliverySchedule
{
    public string DeliveryLineNumber = string.Empty;
    public ProductionStatus? ProductionStatus = null;
    public DeliveryStatus? DeliveryStatus = null;
    public List<DeliveryDateWindow> DeliveryDateWindow = [];
    public Quantity Quantity = new();
    public List<InformationalQuantity> InformationalQuantity = [];
    public PriceDetails? PriceDetails = null;
    public List<MonetaryAdjustment> MonetaryAdjustment = [];
    public List<DeliveryLeg> DeliveryLeg = [];
    public List<DeliveryScheduleReference> DeliveryScheduleReference = [];
    public List<string> AdditionalText = [];
    public string Value = string.Empty;

    public DeliverySchedule() { }

    public DeliverySchedule(XElement root)
    {
        DeliveryLineNumber = root.Element("DeliveryLineNumber")?.Value ?? DeliveryLineNumber;
        ProductionStatus = root.Element("ProductionStatus") is { } ps ? new(ps) : ProductionStatus;
        DeliveryStatus = root.Element("DeliveryStatus") is { } ds ? new(ds) : DeliveryStatus;
        DeliveryDateWindow = [.. root.Elements("DeliveryDateWindow").Select(e => new DeliveryDateWindow(e))];
        Quantity = root.Element("Quantity") is { } q ? new(q) : Quantity;
        InformationalQuantity = [.. root.Elements("InformationalQuantity").Select(e => new InformationalQuantity(e))];
        PriceDetails = root.Element("PriceDetails") is { } pd ? new(pd) : PriceDetails;
        MonetaryAdjustment = [.. root.Elements("MonetaryAdjustment").Select(e => new MonetaryAdjustment(e))];
        DeliveryLeg = [.. root.Elements("DeliveryLeg").Select(e => new DeliveryLeg(e))];
        DeliveryScheduleReference = [.. root.Elements("DeliveryScheduleReference").Select(e => new DeliveryScheduleReference(e))];
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("DeliverySchedule",
            new XElement("DeliveryLineNumber", DeliveryLineNumber),
            ProductionStatus != null ? XElement.Parse($"{ProductionStatus}") : null,
            DeliveryStatus != null ? XElement.Parse($"{DeliveryStatus}") : null,
            DeliveryDateWindow.Select(window => XElement.Parse($"{window}")),
            Quantity != null ? XElement.Parse($"{Quantity}") : null,
            InformationalQuantity.Select(quantity => XElement.Parse($"{quantity}")),
            PriceDetails != null ? XElement.Parse($"{PriceDetails}") : null,
            MonetaryAdjustment.Select(adjustment => XElement.Parse($"{adjustment}")),
            DeliveryLeg.Select(leg => XElement.Parse($"{leg}")),
            DeliveryScheduleReference.Select(reference => XElement.Parse($"{reference}")),
            AdditionalText.Select(text => new XElement("AdditionalText", text)),
            Value
        ).ToString();
    }
}

public class DeliveryScheduleReference : AssignedByReferenceValueBase
{
    public DeliveryScheduleReferenceType DeliveryScheduleReferenceType = DeliveryScheduleReferenceType.Other;

    public DeliveryScheduleReference() : base() { }

    public DeliveryScheduleReference(XElement root) : base(root)
    {
        DeliveryScheduleReferenceType = root.Attribute("DeliveryScheduleReferenceType") is { Value: var dsrt } ? Enum.Parse<DeliveryScheduleReferenceType>(dsrt) : DeliveryScheduleReferenceType;
    }

    public override string LocalName => "DeliveryScheduleReference";

    public override string ToString()
    {
        return new XElement(LocalName,
            new XAttribute("DeliveryScheduleReferenceType", DeliveryScheduleReferenceType),
            AssignedBy != null ? new XAttribute("AssignedBy", AssignedBy) : null,
            Value
        ).ToString();
    }
}

public class DeliveryLeg
{
    public DeliveryModeType? DeliveryModeType = null;
    public DeliveryLegType? DeliveryLegType = null;
    public EventType? EventType = null;
    public LegStageType? LegStageType = null;
    public string DeliveryLegSequenceNumber = string.Empty;
    public DeliveryOrigin DeliveryOrigin = new();
    public Party? CarrierParty = new Party() { LocalName = "CarrierParty" };
    public List<Party> OtherParty = [];
    public TransportModeCharacteristics? TransportModeCharacteristics = null;
    public TransportVehicleCharacteristics? TransportVehicleCharacteristics = null;
    public TransportUnitCharacteristics? TransportUnitCharacteristics = null;
    public TransportUnloadingCharacteristics? TransportUnloadingCharacteristics = null;
    public TransportOtherInstructions? TransportOtherInstructions = null;
    public List<Route> Route = [];
    public DeliveryTransitTime? DeliveryTransitTime = null;
    public DeliveryDestination? DeliveryDestination = null;
    public List<DeliveryDateWindow> DeliveryDateWindow = [];
    public List<DeliveryLegReference> DeliveryLegReference = [];
    public List<TermsOfChartering> TermsOfChartering = [];
    public string Value = string.Empty;

    public DeliveryLeg() { }

    public DeliveryLeg(XElement root)
    {
        DeliveryModeType = root.Attribute("DeliveryModeType") is { Value: var dmt } ? Enum.Parse<DeliveryModeType>(dmt) : DeliveryModeType;
        DeliveryLegType = root.Attribute("DeliveryLegType") is { Value: var dlt } ? Enum.Parse<DeliveryLegType>(dlt) : DeliveryLegType;
        EventType = root.Attribute("EventType") is { Value: var et } ? Enum.Parse<EventType>(et) : EventType;
        LegStageType = root.Attribute("LegStageType") is { Value: var lst } ? Enum.Parse<LegStageType>(lst) : LegStageType;
        DeliveryLegSequenceNumber = root.Element("DeliveryLegSequenceNumber")?.Value ?? DeliveryLegSequenceNumber;
        DeliveryOrigin = root.Element("DeliveryOrigin") is { } deo ? new(deo) : DeliveryOrigin;
        CarrierParty = root.Element("CarrierParty") is { } cp ? new(cp) : CarrierParty;
        OtherParty = [.. root.Elements("OtherParty").Select(e => new Party(e))];
        TransportModeCharacteristics = root.Element("TransportModeCharacteristics") is { } tmc ? new(tmc) : TransportModeCharacteristics;
        TransportVehicleCharacteristics = root.Element("TransportVehicleCharacteristics") is { } tvc ? new(tvc) : TransportVehicleCharacteristics;
        TransportUnitCharacteristics = root.Element("TransportUnitCharacteristics") is { } tunic ? new(tunic) : TransportUnitCharacteristics;
        TransportUnloadingCharacteristics = root.Element("TransportUnloadingCharacteristics") is { } tunlc ? new(tunlc) : TransportUnloadingCharacteristics;
        TransportOtherInstructions = root.Element("TransportOtherInstructions") is { } toi ? new(toi) : TransportOtherInstructions;
        Route = [.. root.Elements("Route").Select(e => new Route(e))];
        DeliveryTransitTime = root.Element("DeliveryTransitTime") is { } dtt ? new(dtt) : DeliveryTransitTime;
        DeliveryDestination = root.Element("DeliveryDestination") is { } dd ? new(dd) : DeliveryDestination;
        DeliveryDateWindow = [.. root.Elements("DeliveryDateWindow").Select(e => new DeliveryDateWindow(e))];
        DeliveryLegReference = [.. root.Elements("DeliveryLegReference").Select(e => new DeliveryLegReference(e))];
        TermsOfChartering = [.. root.Elements("TermsOfChartering").Select(e => new TermsOfChartering(e))];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("DeliveryLeg",
            DeliveryModeType != null ? new XAttribute("DeliveryModeType", DeliveryModeType) : null,
            DeliveryLegType != null ? new XAttribute("DeliveryLegType", DeliveryLegType) : null,
            EventType != null ? new XAttribute("EventType", EventType) : null,
            LegStageType != null ? new XAttribute("LegStageType", LegStageType) : null,
            new XElement("DeliveryLegSequenceNumber", DeliveryLegSequenceNumber),
            XElement.Parse($"{DeliveryOrigin}"),
            CarrierParty != null ? XElement.Parse($"{CarrierParty}") : null,
            OtherParty.Select(party => XElement.Parse($"{party}")),
            TransportModeCharacteristics != null ? XElement.Parse($"{TransportModeCharacteristics}") : null,
            TransportVehicleCharacteristics != null ? XElement.Parse($"{TransportVehicleCharacteristics}") : null,
            TransportUnitCharacteristics != null ? XElement.Parse($"{TransportUnitCharacteristics}") : null,
            TransportUnloadingCharacteristics != null ? XElement.Parse($"{TransportUnloadingCharacteristics}") : null,
            TransportOtherInstructions != null ? XElement.Parse($"{TransportOtherInstructions}") : null,
            Route.Select(route => XElement.Parse($"{route}")),
            DeliveryTransitTime != null ? XElement.Parse($"{DeliveryTransitTime}") : null,
            DeliveryDestination != null ? XElement.Parse($"{DeliveryDestination}") : null,
            DeliveryDateWindow.Select(window => XElement.Parse($"{window}")),
            DeliveryLegReference.Select(reference => XElement.Parse($"{reference}")),
            TermsOfChartering.Select(chartering => XElement.Parse($"{chartering}")),
            Value
        ).ToString();
    }
}

public class TermsOfChartering
{
    public TermsOfCharteringType? TermsOfCharteringType = null;
    public string Value = string.Empty;

    public TermsOfChartering() { }

    public TermsOfChartering(XElement root)
    {
        TermsOfCharteringType = root.Attribute("TermsOfCharteringType") is { Value: var toct } ? Enum.Parse<TermsOfCharteringType>(toct) : TermsOfCharteringType;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TermsOfChartering",
            TermsOfCharteringType != null ? new XAttribute("TermsOfCharteringType", TermsOfCharteringType) : null,
            Value
        ).ToString();
    }
}

public class DeliveryLegReference : AssignedByReferenceValueBase
{
    public DeliveryLegReferenceType DeliveryLegReferenceType = DeliveryLegReferenceType.Other;

    public DeliveryLegReference() : base() { }

    public DeliveryLegReference(XElement root) : base(root)
    {
        DeliveryLegReferenceType = root.Attribute("DeliveryLegReferenceType") is { Value: var dlft } ? Enum.Parse<DeliveryLegReferenceType>(dlft) : DeliveryLegReferenceType;
    }

    public override string LocalName => "DeliveryLegReference";

    public override string ToString()
    {
        return new XElement(LocalName,
            new XAttribute("DeliveryLegReferenceType", DeliveryLegReferenceType),
            AssignedBy != null ? new XAttribute("AssignedBy", AssignedBy) : null,
            Value
        ).ToString();
    }
}

public class DeliveryDestination
{
    public Date? Date = null;
    public Time? Time = null;
    public Party LocationParty = new() { LocalName = "LocationParty" };
    public SupplyPoint? SupplyPoint = null;
    public LocationCode? LocationCode = null;
    public GPSCoordinates? GPSCoordinates = null;
    public MapCoordinates? MapCoordinates = null;
    public string Value = string.Empty;

    public DeliveryDestination() { }

    public DeliveryDestination(XElement root)
    {
        Date = root.Element("Date") is { } d ? new(d) : Date;
        Time = root.Element("Time") is { } t ? new(t) : Time;
        LocationParty = root.Element("LocationParty") is { } lp ? new(lp) : LocationParty;
        LocationCode = root.Element("LocationCode") is { } lc ? new(lc) : LocationCode;
        GPSCoordinates = root.Element("GPSCoordinates") is { } gpsc ? new(gpsc) : GPSCoordinates;
        MapCoordinates = root.Element("MapCoordinates") is { } mp ? new(mp) : MapCoordinates;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("DeliveryDestination",
            Date != null ? XElement.Parse($"{Date}") : null,
            Time != null ? XElement.Parse($"{Time}") : null,
            LocationParty != null ? XElement.Parse($"{LocationParty}") : null,
            LocationCode != null ? XElement.Parse($"{LocationCode}") : null,
            GPSCoordinates != null ? XElement.Parse($"{GPSCoordinates}") : null,
            MapCoordinates != null ? XElement.Parse($"{MapCoordinates}") : null,
            Value
        ).ToString();
    }
}

public class DeliveryTransitTime
{
    public string Days = string.Empty;
    public string? Hours = null;
    public string? Minutes = null;

    public DeliveryTransitTime() { }

    public DeliveryTransitTime(XElement root)
    {
        Days = root.Element("Days")?.Value ?? Days;
        Hours = root.Element("Hours")?.Value ?? Hours;
        Minutes = root.Element("Minutes")?.Value ?? Minutes;
    }

    public override string ToString()
    {
        return new XElement("DeliveryTransitTime",
            new XElement("Days", Days),
            Hours != null ? new XElement("Hours", Hours) : null,
            Minutes != null ? new XElement("Minutes", Minutes) : null
        ).ToString();
    }
}

public class Route
{
    public RouteType RouteType = RouteType.DeliveryOriginToDeliveryDestination;
    public string RouteName = string.Empty;
    public List<string> RouteComment = [];
    public List<SupplyPoint> SupplyPoint = [];
    public List<MapPoint> MapPoint = [];
    public string? RouteLength = null;
    public string? RouteDefinition = null;
    public eAttachment? eAttachment = null;
    public List<RouteLeg> RouteLeg = [];
    public string RootValue = string.Empty;

    public Route() { }

    public Route(XElement root)
    {
        RouteType = root.Attribute("RouteType") is { Value: var rt } ? Enum.Parse<RouteType>(rt) : RouteType;
        RouteName = root.Element("RouteName")?.Value ?? RouteName;
        RouteComment = [.. root.Elements("RouteComment").Select(e => e.Value)];
        SupplyPoint = [.. root.Elements("SupplyPoint").Select(e => new SupplyPoint(e))];
        MapPoint = [.. root.Elements("MapPoint").Select(e => new MapPoint(e))];
        RootValue = root.Value;
    }

    public override string ToString()
    {
        return new XElement("Route",
            new XAttribute("RouteType", RouteType),
            new XElement("RouteName", RouteName),
            RouteComment.Select(comment => new XElement("RouteComment", comment)),
            SupplyPoint.Select(point => XElement.Parse($"{point}")),
            MapPoint.Select(point => XElement.Parse($"{point}")),
            RootValue
        ).ToString();
    }
}

public class RouteLeg
{
    public string RouteLegNumber = string.Empty;
    public string? RouteLegName = null;
    public List<Party> OtherParty = [];
    public MapPoint? MapPoint = null;
    public RouteLegLength? RouteLegLength = null;
    public RoadCharacteristics? RoadCharacteristics = null;
    public eAttachment? eAttachment = null;
    public List<string> AdditionalText = [];

    public RouteLeg() { }

    public RouteLeg(XElement root)
    {
        RouteLegNumber = root.Element("RouteLegNumber")?.Value ?? RouteLegNumber;
        RouteLegName = root.Element("RouteLegName")?.Value ?? RouteLegName;
        OtherParty = [.. root.Elements("OtherParty").Select(e => new Party(e))];
        MapPoint = root.Element("MapPoint") is { } mp ? new(mp) : MapPoint;
        RouteLegLength = root.Element("RouteLegLength") is { } rll ? new(rll) : RouteLegLength;
        RoadCharacteristics = root.Element("RoadCharacteristics") is { } rc ? new(rc) : RoadCharacteristics;
        eAttachment = root.Element("eAttachment") is { } ea ? new(ea) : eAttachment;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
    }

    public override string ToString()
    {
        return new XElement("RouteLeg",
            RouteLegNumber != null ? new XElement("RouteLegNumber", RouteLegNumber) : null,
            RouteLegName != null ? new XElement("RouteLegName", RouteLegName) : null,
            OtherParty.Select(party => XElement.Parse($"{party}")),
            MapPoint != null ? XElement.Parse($"{MapPoint}") : null,
            RouteLegLength != null ? XElement.Parse($"{RouteLegLength}") : null,
            RoadCharacteristics != null ? XElement.Parse($"{RoadCharacteristics}") : null,
            eAttachment != null ? XElement.Parse($"{eAttachment}") : null,
            AdditionalText.Select(text => new XElement("AdditionalText", text))
        ).ToString();
    }
}

public class RoadCharacteristics
{
    public RoadOwnerType? RoadOwnerType = null;
    public RoadKeeperType? RoadKeeperType = null;
    public RoadAccessibilityType? RoadAccessibilityType = null;
    public RoadTurningPossibilityType? RoadTurningPossibilityType = null;
    public RoadTurningPointType? RoadTurningPointType = null;
    public RoadPassingPossibility? RoadPassingPossibility = null;
    public string? RoadName = null;
    public string? RoadNumber = null;
    public List<RoadClassification> RoadClassification = [];
    public List<RoadAvailability> RoadAvailability = [];
    public List<RoadBearingCapacity> RoadBearingCapacity = [];
    public List<RoadObstruction> RoadObstruction = [];

    public RoadCharacteristics() { }

    public RoadCharacteristics(XElement root)
    {
        RoadOwnerType = root.Attribute("RoadOwnerType") is { Value: var rot } ? Enum.Parse<RoadOwnerType>(rot) : RoadOwnerType;
        RoadKeeperType = root.Attribute("RoadKeeperType") is { Value: var rkt } ? Enum.Parse<RoadKeeperType>(rkt) : RoadKeeperType;
        RoadAccessibilityType = root.Attribute("RoadAccessibilityType") is { Value: var rat } ? Enum.Parse<RoadAccessibilityType>(rat) : RoadAccessibilityType;
        RoadTurningPossibilityType = root.Attribute("RoadTurningPossibilityType") is { Value: var rtpost } ? Enum.Parse<RoadTurningPossibilityType>(rtpost) : RoadTurningPossibilityType;
        RoadTurningPointType = root.Attribute("RoadTurningPointType") is { Value: var rtpoit } ? Enum.Parse<RoadTurningPointType>(rtpoit) : RoadTurningPointType;
        RoadPassingPossibility = root.Attribute("RoadPassingPossibility") is { Value: var rpp } ? Enum.Parse<RoadPassingPossibility>(rpp) : RoadPassingPossibility;
        RoadName = root.Element("RoadName")?.Value ?? RoadName;
        RoadNumber = root.Element("RoadNumber")?.Value ?? RoadNumber;
        RoadClassification = [.. root.Elements("RoadClassification").Select(e => new RoadClassification(e))];
        RoadAvailability = [.. root.Elements("RoadAvailability").Select(e => Enum.Parse<RoadAvailability>(e.Value))];
        RoadBearingCapacity = [.. root.Elements("RoadBearingCapacity").Select(e => new RoadBearingCapacity(e))];
        RoadObstruction = [.. root.Elements("RoadObstruction").Select(e => new RoadObstruction(e))];
    }

    public override string ToString()
    {
        return new XElement("RoadCharacteristics",
            RoadOwnerType != null ? new XAttribute("RoadOwnerType", RoadOwnerType) : null,
            RoadKeeperType != null ? new XAttribute("RoadKeeperType", RoadKeeperType) : null,
            RoadAccessibilityType != null ? new XAttribute("RoadAccessibilityType", RoadAccessibilityType) : null,
            RoadTurningPossibilityType != null ? new XAttribute("RoadTurningPossibilityType", RoadTurningPossibilityType) : null,
            RoadTurningPointType != null ? new XAttribute("RoadTurningPointType", RoadTurningPointType) : null,
            RoadPassingPossibility != null ? new XAttribute("RoadPassingPossibility", RoadPassingPossibility) : null,
            RoadName != null ? new XElement("RoadName", RoadName) : null,
            RoadNumber != null ? new XElement("RoadNumber", RoadNumber) : null,
            RoadClassification.Select(classification => XElement.Parse($"{classification}")),
            RoadAvailability.Select(availability => XElement.Parse($"{availability}")),
            RoadBearingCapacity.Select(capacity => XElement.Parse($"{capacity}")),
            RoadObstruction.Select(obstruction => XElement.Parse($"{obstruction}"))
        ).ToString();
    }
}

public class RoadObstruction
{
    public RoadObstructionType RoadObstructionType = RoadObstructionType.Passage;
    public string? MapPointName = null;
    public List<string> MapPointComment = [];
    public List<MapCoordinates> MapCoordinates = [];
    public string? RoadSlopePercent = null;
    public List<RoadBearingCapacity> RoadBearingCapacity = [];
    public Length_Object? Length = null;
    public Width? Width = null;
    public Height? Height = null;
    public eAttachment? eAttachment = null;
    public List<string> AdditionalText = [];

    public RoadObstruction() { }

    public RoadObstruction(XElement root)
    {
        RoadObstructionType = root.Attribute("RoadObstructionType") is { Value: var rot } ? Enum.Parse<RoadObstructionType>(rot) : RoadObstructionType;
        MapPointName = root.Element("MapPointName")?.Value ?? MapPointName;
        MapPointComment = [.. root.Elements("MapPointComment").Select(e => e.Value)];
        MapCoordinates = [.. root.Elements("MapCoordinates").Select(e => new MapCoordinates(e))];
        RoadSlopePercent = root.Element("RoadSlopePercent")?.Value ?? RoadSlopePercent;
        RoadBearingCapacity = [.. root.Elements("RoadBearingCapacity").Select(e => new RoadBearingCapacity(e))];
        Length = root.Element("Length") is { } l ? new(l) : Length;
        Width = root.Element("Width") is { } w ? new(w) : Width;
        Height = root.Element("Height") is { } h ? new(h) : Height;
        eAttachment = root.Element("eAttachment") is { } ea ? new(ea) : eAttachment;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
    }

    public override string ToString()
    {
        return new XElement("RoadObstruction",
            new XAttribute("RoadObstructionType", RoadObstructionType),
            MapPointName != null ? new XElement("MapPointName", MapPointName) : null,
            MapPointComment.Select(comment => new XElement("MapPointComment", comment)),
            MapCoordinates.Select(coordinates => XElement.Parse($"{coordinates}")),
            RoadSlopePercent != null ? new XElement("RoadSlopePercent", RoadSlopePercent) : null,
            RoadBearingCapacity.Select(capacity => XElement.Parse($"{capacity}")),
            Length != null ? XElement.Parse($"{Length}") : null,
            Width != null ? XElement.Parse($"{Width}") : null,
            Height != null ? XElement.Parse($"{Height}") : null,
            eAttachment != null ? XElement.Parse($"{eAttachment}") : null,
            AdditionalText.Select(text => new XElement("AdditionalText", text))
        ).ToString();
    }
}

public class Height : RangeValueBase
{
    public Height() { }

    public Height(XElement root) : base(root) { }

    public override string LocalName => "Height";
}

public class Width : RangeValueBase
{
    public Width() { }

    public Width(XElement root) : base(root) { }

    public override string LocalName => "Width";
}

public class Length_Object : RangeValueBase
{
    public Length_Object() { }

    public Length_Object(XElement root) : base(root) { }

    public override string LocalName => "Length";
}

public class RoadBearingCapacity
{
    public RoadBearingCapacityType? RoadBearingCapacityType = null;
    public Value Value = new();
    public RangeMin? RangeMin = null;
    public RangeMax? RangeMax = null;

    public RoadBearingCapacity() { }

    public RoadBearingCapacity(XElement root)
    {
        RoadBearingCapacityType = root.Attribute("RoadBearingCapacityType") is { Value: var rbct } ? Enum.Parse<RoadBearingCapacityType>(rbct) : RoadBearingCapacityType;
        Value = root.Element("Value") is { } v ? new(v) : Value;
        RangeMin = root.Element("RangeMin") is { } rmin ? new(rmin) : RangeMin;
        RangeMax = root.Element("RangeMax") is { } rmax ? new(rmax) : RangeMax;
    }

    public override string ToString()
    {
        return new XElement("RoadBearingCapacity",
            RoadBearingCapacityType != null ? new XAttribute("RoadBearingCapacityType", RoadBearingCapacityType) : null,
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class RoadClassification
{
    public string? RoadClassificationCode = null;
    public List<string> RoadClassificationDescription = [];
    public string RootValue = string.Empty;

    public RoadClassification() { }

    public RoadClassification(XElement root)
    {
        RoadClassificationCode = root.Element("RoadClassificationCode")?.Value ?? RoadClassificationCode;
        RoadClassificationDescription = [.. root.Elements("RoadClassificationDescription").Select(e => e.Value)];
        RootValue = root.Value;
    }

    public override string ToString()
    {
        return new XElement("RoadClassification",
            RoadClassificationCode != null ? new XElement("RoadClassificationCode", RoadClassificationCode) : null,
            RoadClassificationDescription.Select(description => new XElement("RoadClassificationDescription", description)),
            RootValue
        ).ToString();
    }
}

public class RouteLegLength : RangeValueBase
{
    public RouteLegLength() { }

    public RouteLegLength(XElement root) : base(root) { }

    public override string LocalName => "RouteLegLength";
}

public class eAttachment
{
    public string? AttachmentFileName = null;
    public string? NumberOfAttachments = null;
    public List<URL> URL = [];
    public string RootValue = string.Empty;

    public eAttachment() { }

    public eAttachment(XElement root)
    {
        AttachmentFileName = root.Element("AttachmentFileName")?.Value ?? AttachmentFileName;
        NumberOfAttachments = root.Element("NumberOfAttachments")?.Value ?? NumberOfAttachments;
        URL = [.. root.Elements("URL").Select(e => new URL(e))];
        RootValue = root.Value;
    }

    public override string ToString()
    {
        return new XElement("eAttachment",
            AttachmentFileName != null ? new XElement("AttachmentFileName", AttachmentFileName) : null,
            NumberOfAttachments != null ? new XElement("NumberOfAttachments", NumberOfAttachments) : null,
            URL.Select(url => XElement.Parse($"{url}")),
            RootValue
        ).ToString();
    }
}

public class MapPoint
{
    public MapPointType? MapPointType = null;
    public string MapPointName = string.Empty;
    public List<string> MapPointComment = [];
    public List<MapCoordinates> MapCoordinates = [];
    public string Value = string.Empty;

    public MapPoint() { }

    public MapPoint(XElement root)
    {
        MapPointType = root.Attribute("MapPointType") is { Value: var mpt } ? Enum.Parse<MapPointType>(mpt) : MapPointType;
        MapPointName = root.Element("MapPointName")?.Value ?? MapPointName;
        MapPointComment = [.. root.Elements("MapPointComment").Select(e => e.Value)];
        MapCoordinates = [.. root.Elements("MapCoordinates").Select(e => new MapCoordinates(e))];
        Value = root.Value;
    }
    
    public override string ToString()
    {
        return new XElement("MapPoint",
            MapPointType != null ? new XAttribute("MapPointType", MapPointType) : null,
            new XElement("MapPointName", MapPointName),
            MapPointComment.Select(comment => new XElement("MapPointComment", comment)),
            MapCoordinates.Select(coordinates => XElement.Parse($"{coordinates}")),
            Value
        ).ToString();
    }
}

public class TransportOtherInstructions
{
    public TransportInstructionType? TransportInstructionType = null;
    public TransportInstructionCode? TransportInstructionCode = null;
    public List<string> TransportInstructionText = [];
    public string Value = string.Empty;

    public TransportOtherInstructions() { }

    public TransportOtherInstructions(XElement root)
    {
        TransportInstructionType = root.Attribute("TransportInstructionType") is { Value: var tit } ? Enum.Parse<TransportInstructionType>(tit) : TransportInstructionType;
        TransportInstructionCode = root.Element("TransportInstructionCode") is { } tic ? new(tic) : TransportInstructionCode;
        TransportInstructionText = [.. root.Elements("TransportInstructionText").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportOtherInstructions",
            TransportInstructionType != null ? new XAttribute("TransportInstructionType", TransportInstructionType) : null,
            TransportInstructionCode != null ? XElement.Parse($"{TransportInstructionCode}") : null,
            TransportInstructionText.Select(text => new XElement("TransportInstructionText", text)),
            Value
        ).ToString();
    }
}

public class TransportInstructionCode : AgencyValueBase
{
    public TransportInstructionCode() : base() { Agency = PapiNet.Agency.Other; }

    public TransportInstructionCode(XElement root) : base(root) { }

    public override string LocalName => "TransportInstructionCode";
}

public class TransportUnloadingCharacteristics
{
    public TransportUnloadingType? TransportUnloadingType = null;
    public DirectUnloading? DirectUnloading = null;
    public TransportUnloadingCode? TransportUnloadingCode = null;
    public TransportUnloadingCodeDescription? TransportUnloadingCodeDescription = null;
    public List<string> TransportUnloadingText = [];
    public string Value = string.Empty;

    public TransportUnloadingCharacteristics() { }

    public TransportUnloadingCharacteristics(XElement root)
    {
        TransportUnloadingType = root.Attribute("TransportUnloadingType") is { Value: var tut } ? Enum.Parse<TransportUnloadingType>(tut) : TransportUnloadingType;
        DirectUnloading = root.Attribute("DirectUnloading") is { Value: var du } ? Enum.Parse<DirectUnloading>(du) : DirectUnloading;
        TransportUnloadingCode = root.Element("TransportUnloadingCode") is { } tuc ? new(tuc) : TransportUnloadingCode;
        TransportUnloadingCodeDescription = root.Element("TransportUnloadingCodeDescription") is { } tucd ? new(tucd) : TransportUnloadingCodeDescription;
        TransportUnloadingText = [.. root.Elements("TransportUnloadingText").Select(e => e.Value)];
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportUnloadingCharacteristics",
            TransportUnloadingType != null ? new XAttribute("TransportUnloadingType", TransportUnloadingType) : null,
            DirectUnloading != null ? new XAttribute("DirectUnloading", DirectUnloading) : null,
            TransportUnloadingCode != null ? XElement.Parse($"{TransportUnloadingCode}") : null,
            TransportUnloadingCodeDescription != null ? XElement.Parse($"{TransportUnloadingCodeDescription}") : null,
            TransportUnloadingText.Select(text => new XElement("TransportUnloadingText", text)),
            Value
        ).ToString();
    }
}

public class TransportUnloadingCodeDescription
{
    public List<string> AdditionalText = [];
    public e_Attachment? e_Attachment = null;
    public string Value = string.Empty;

    public TransportUnloadingCodeDescription() { }

    public TransportUnloadingCodeDescription(XElement root)
    {
        AdditionalText = root.Elements("AdditionalText")
            .Select(text => text.Value)
            .ToList();
        e_Attachment = root.Element("Attachment") is XElement attachment
            ? new e_Attachment(attachment)
            : e_Attachment;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportUnloadingCodeDescription",
            AdditionalText.Select(text => new XElement("AdditionalText", text)),
            e_Attachment != null ? XElement.Parse($"{e_Attachment}") : null,
            Value
        ).ToString();
    }
}

public class e_Attachment
{
    public string? AttachmentFileName = null;
    public string? NumberOfAttachments = null;
    public URL? URL = null;
    public string Value = string.Empty;

    public e_Attachment() { }

    public e_Attachment(XElement root)
    {
        AttachmentFileName = root.Element("AttachmentFileName")?.Value ?? AttachmentFileName;
        NumberOfAttachments = root.Element("NumberOfAttachments")?.Value ?? NumberOfAttachments;
        URL = root.Element("URL") is { } url ? new(url) : URL;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("e-Attachment",
            AttachmentFileName != null ? new XElement("AttachmentFileName", AttachmentFileName) : null,
            NumberOfAttachments != null ? new XElement("NumberOfAttachments", NumberOfAttachments) : null,
            URL != null ? XElement.Parse($"{URL}") : null,
            Value
        ).ToString();
    }
}

public class URL
{
    public string? URLContext = null;
    public string Value = string.Empty;

    public URL() { }

    public URL(XElement root)
    {
        URLContext = root.Attribute("URLContext")?.Value ?? URLContext;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("URL",
            URLContext != null ? new XAttribute("URLContext", URLContext) : null,
            Value
        ).ToString();
    }
}

public class TransportUnloadingCode : AgencyValueBase
{
    public TransportUnloadingCode() : base() { Agency = PapiNet.Agency.Other; }

    public TransportUnloadingCode(XElement root) : base(root) { }

    public override string LocalName => "TransportUnloadingCode";
}

public class TransportUnitCharacteristics
{
    public TransportUnitType TransportUnitType = TransportUnitType.Other;
    public TransportUnitVariable? TransportUnitVariable = null;
    public string? TransportUnitLevel = null;
    public TransportUnitCode? TransportUnitCode = null;
    public TransportUnitMeasurements? TransportUnitMeasurements = null;
    public List<TransportUnitEquipment> TransportUnitEquipment = [];
    public string? TransportUnitCount = null;
    public List<TransportUnitIdentifier> TransportUnitIdentifier = [];
    public string? TransportUnitText = null;
    public TransportUnitDetail? TransportUnitDetail = null;

    public TransportUnitCharacteristics() { }

    public TransportUnitCharacteristics(XElement root)
    {
        TransportUnitType = root.Attribute("TransportUnitType") is { Value: var tut } ? Enum.Parse<TransportUnitType>(tut) : TransportUnitType;
        TransportUnitVariable = root.Attribute("TransportUnitVariable") is { Value: var tuv } ? Enum.Parse<TransportUnitVariable>(tuv) : TransportUnitVariable;
        TransportUnitLevel = root.Attribute("TransportUnitLevel")?.Value ?? TransportUnitLevel;
        TransportUnitCode = root.Element("TransportUnitCode") is { } tuc ? new(tuc) : TransportUnitCode;
        TransportUnitMeasurements = root.Element("TransportUnitMeasurements") is { } tum ? new(tum) : TransportUnitMeasurements;
        TransportUnitEquipment = [.. root.Elements("TransportUnitEquipment").Select(e => new TransportUnitEquipment(e))];
        TransportUnitCount = root.Element("TransportUnitCount")?.Value ?? TransportUnitCount;
        TransportUnitIdentifier = [.. root.Elements("TransportUnitIdentifier").Select(e => new TransportUnitIdentifier(e))];
        TransportUnitText = root.Element("TransportUnitText")?.Value ?? TransportUnitText;
        TransportUnitDetail = root.Element("TransportUnitDetail") is { } tud ? new(tud) : TransportUnitDetail;
    }

    public override string ToString()
    {
        return new XElement("TransportUnitCharacteristics",
            new XAttribute("TransportUnitType", TransportUnitType),
            TransportUnitVariable != null ? new XAttribute("TransportUnitVariable", TransportUnitVariable) : null,
            TransportUnitLevel != null ? new XAttribute("TransportUnitLevel", TransportUnitLevel) : null,
            TransportUnitCode != null ? XElement.Parse($"{TransportUnitCode}") : null,
            TransportUnitMeasurements != null ? XElement.Parse($"{TransportUnitMeasurements}") : null,
            TransportUnitEquipment.Select(equipment =>  XElement.Parse($"{equipment}")),
            TransportUnitCount != null ? new XElement("TransportUnitCount", TransportUnitCount) : null,
            TransportUnitIdentifier.Select(identifier => XElement.Parse($"{identifier}")),
            TransportUnitText != null ? new XElement("TransportUnitText", TransportUnitText) : null,
            TransportUnitDetail != null ? XElement.Parse($"{TransportUnitDetail}") : null
        ).ToString();
    }
}

public class TransportUnitDetail
{
    public TransportUnitDetailType? TransportUnitDetailType = null;
    public LoadOpeningSide? LoadOpeningSide = null;
    public TransportUnitDetailCode? TransportUnitDetailCode = null;
    public List<string> AdditionalText = [];

    public TransportUnitDetail() { }

    public TransportUnitDetail(XElement root)
    {
        TransportUnitDetailType = root.Attribute("TransportUnitDetailType") is { Value: var tudt } ? Enum.Parse<TransportUnitDetailType>(tudt) : TransportUnitDetailType;
        LoadOpeningSide = root.Attribute("LoadOpeningSide") is { Value: var los } ? Enum.Parse<LoadOpeningSide>(los) : LoadOpeningSide;
        TransportUnitDetailCode = root.Element("TransportUnitDetailCode") is { } tudc ? new(tudc) : TransportUnitDetailCode;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
    }

    public override string ToString()
    {
        return new XElement("TransportUnitDetail",
            TransportUnitDetailType != null ? new XAttribute("TransportUnitDetailType", TransportUnitDetailType) : null,
            LoadOpeningSide != null ? new XAttribute("LoadOpeningSide", LoadOpeningSide) : null,
            TransportUnitDetailCode != null ? XElement.Parse($"{TransportUnitDetailCode}") : null,
            AdditionalText.Select(text => new XElement("AdditionalText", text))
        ).ToString();
    }
}

public class TransportUnitDetailCode : AgencyValueBase
{
    public TransportUnitDetailCode() : base() { Agency = PapiNet.Agency.Other; }

    public TransportUnitDetailCode(XElement root) : base(root) { }

    public override string LocalName => "TransportUnitDetailCode";
}

public class TransportUnitIdentifier
{
    public TransportUnitIdentifierType TransportUnitIdentifierType = TransportUnitIdentifierType.Other;
    public string? StateOrProvince = null;
    public ISOCountryCode? ISOCountryCode = null;
    public string Value = string.Empty;

    public TransportUnitIdentifier() { }

    public TransportUnitIdentifier(XElement root)
    {
        TransportUnitIdentifierType = root.Attribute("TransportUnitIdentifierType") is { Value: var tuit } ? Enum.Parse<TransportUnitIdentifierType>(tuit) : TransportUnitIdentifierType;
        StateOrProvince = root.Attribute("StateOrProvince")?.Value ?? StateOrProvince;
        ISOCountryCode = root.Attribute("ISOCountryCode") is { Value: var isocc } ? Enum.Parse<ISOCountryCode>(isocc) : ISOCountryCode;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportUnitIdentifier",
            new XAttribute("TransportUnitIdentifierType", TransportUnitIdentifierType),
            StateOrProvince != null ? new XAttribute("StateOrProvince", StateOrProvince) : null,
            ISOCountryCode != null ? new XAttribute("ISOCountryCode", ISOCountryCode) : null,
            Value
        ).ToString();
    }
}

public class TransportUnitEquipment
{
    public TransportUnitEquipmentCode? TransportUnitEquipmentCode = null;
    public List<TransportUnitEquipmentDescription> TransportUnitEquipmentDescription = [];

    public TransportUnitEquipment() { }

    public TransportUnitEquipment(XElement root)
    {
        TransportUnitEquipmentCode = root.Element("TransportUnitEquipmentCode") is { } tuec ? new(tuec) : TransportUnitEquipmentCode;
        TransportUnitEquipmentDescription = [.. root.Elements("TransportUnitEquipmentDescription").Select(e => new TransportUnitEquipmentDescription(e))];
    }

    public override string ToString()
    {
        return new XElement("TransportUnitEquipment",
            TransportUnitEquipmentCode != null ? XElement.Parse($"{TransportUnitEquipmentCode}") : null,
            TransportUnitEquipmentDescription.Select(description => XElement.Parse($"{description}"))
        ).ToString();
    }
}

public class TransportUnitEquipmentDescription
{
    public Language? Language = null;
    public string Value = string.Empty;

    public TransportUnitEquipmentDescription() { }

    public TransportUnitEquipmentDescription(XElement root)
    {
        Language = root.Attribute("Language") is { Value: var l } ? Enum.Parse<Language>(l) : Language;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportUnitEquipmentDescription",
            Language != null ? new XAttribute("Language", Language) : null,
            Value
        ).ToString();
    }
}

public class TransportUnitEquipmentCode : AgencyValueBase
{
    public TransportUnitEquipmentCode() : base() { Agency = PapiNet.Agency.Other; }

    public TransportUnitEquipmentCode(XElement root) : base(root) { }

    public override string LocalName => "TransportUnitEquipmentCode";
}

public class TransportUnitMeasurements
{
    public AppliesTo? AppliesTo = null;
    public TransportUnitLength? TransportUnitLength = null;
    public TransportUnitWidth? TransportUnitWidth = null;
    public TransportUnitHeight? TransportUnitHeight = null;
    public TransportUnitWeight? TransportUnitWeight = null;

    public TransportUnitMeasurements() { }

    public TransportUnitMeasurements(XElement root)
    {
        AppliesTo = root.Attribute("AppliesTo") is { Value: var at } ? Enum.Parse<AppliesTo>(at) : AppliesTo;
        TransportUnitLength = root.Element("TransportUnitLength") is { } length ? new(length) : TransportUnitLength;
        TransportUnitWidth = root.Element("TransportUnitWidth") is { } width ? new(width) : TransportUnitWidth;
        TransportUnitHeight = root.Element("TransportUnitHeight") is { } height ? new(height) : TransportUnitHeight;
        TransportUnitWeight = root.Element("TransportUnitWeight") is { } weight ? new(weight) : TransportUnitWeight;
    }

    public override string ToString()
    {
        return new XElement("TransportUnitMeasurements",
            AppliesTo != null ? new XAttribute("AppliesTo", AppliesTo) : null,
            TransportUnitLength != null ? XElement.Parse($"{TransportUnitLength}") : null,
            TransportUnitWidth != null ? XElement.Parse($"{TransportUnitWidth}") : null,
            TransportUnitHeight != null ? XElement.Parse($"{TransportUnitHeight}") : null,
            TransportUnitWeight != null ? XElement.Parse($"{TransportUnitWeight}") : null
        ).ToString();
    }
}

public class TransportUnitWeight : RangeValueBase
{
    public TransportUnitWeight() { }

    public TransportUnitWeight(XElement root) : base(root) { }

    public override string LocalName => "TransportUnitWeight";
}

public class TransportUnitHeight : RangeValueBase
{
    public TransportUnitHeight() { }

    public TransportUnitHeight(XElement root) : base(root) { }

    public override string LocalName => "TransportUnitHeight";
}

public class TransportUnitWidth : RangeValueBase
{
    public TransportUnitWidth() { }

    public TransportUnitWidth(XElement root) : base(root) { }

    public override string LocalName => "TransportUnitWidth";
}

public class TransportUnitLength : RangeValueBase
{
    public TransportUnitLength() { }

    public TransportUnitLength(XElement root) : base(root) { }

    public override string LocalName => "TransportUnitLength";
}

public class TransportUnitCode : AgencyValueBase
{
    public TransportUnitCode() : base() { Agency = PapiNet.Agency.Other; }

    public TransportUnitCode(XElement root) : base(root) { }

    public override string LocalName => "TransportUnitCode";
}

public class TransportVehicleCharacteristics
{
    public TransportVehicleType? TransportVehicleType = null;
    public TransportVehicleCode? TransportVehicleCode = null;
    public TransportVehicleMeasurements? TransportVehicleMeasurements = null;
    public List<TransportVehicleEquipment> TransportVehicleEquipment = [];
    public string? TransportVehicleCount = null;
    public TransportVehicleIdentifier? TransportVehicleIdentifier = null;
    public string? TransportVehicleText = null;

    public TransportVehicleCharacteristics() { }

    public TransportVehicleCharacteristics(XElement root)
    {
        TransportVehicleType = root.Attribute("TransportVehicleType") is { Value: var tvt } ? Enum.Parse<TransportVehicleType>(tvt) : TransportVehicleType;
        TransportVehicleCode = root.Element("TransportVehicleCode") is { } tvc ? new(tvc) : TransportVehicleCode;
        TransportVehicleMeasurements = root.Element("TransportVehicleMeasurements") is { } tvm ? new(tvm) : TransportVehicleMeasurements;
        TransportVehicleEquipment = [.. root.Elements("TransportVehicleEquipment").Select(e => new TransportVehicleEquipment(e))];
        TransportVehicleCount = root.Element("TransportVehicleCount")?.Value ?? TransportVehicleCount;
        TransportVehicleIdentifier = root.Element("TransportVehicleIdentifier") is { } tvi ? new(tvi) : TransportVehicleIdentifier;
        TransportVehicleText = root.Element("TransportVehicleText")?.Value ?? TransportVehicleText;
    }

    public override string ToString()
    {
        return new XElement("TransportVehicleCharacteristics",
            TransportVehicleType != null ? new XAttribute("TransportVehicleType", TransportVehicleType) : null,
            TransportVehicleCode != null ? XElement.Parse($"{TransportVehicleCode}") : null,
            TransportVehicleMeasurements != null ? XElement.Parse($"{TransportVehicleMeasurements}") : null,
            TransportVehicleEquipment.Select(equipment => XElement.Parse($"{equipment}")),
            TransportVehicleCount != null ? new XElement("TransportVehicleCount", TransportVehicleCount) : null,
            TransportVehicleIdentifier != null ? XElement.Parse($"{TransportVehicleIdentifier}") : null,
            TransportVehicleText != null ? new XElement("TransportVehicleText", TransportVehicleText) : null
        ).ToString();
    }
}

public class TransportVehicleIdentifier
{
    public TransportVehicleIdentifierType? TransportVehicleIdentifierType = null;
    public string? StateOrProvince = null;
    public ISOCountryCode? ISOCountryCode = null;
    public string Value = string.Empty;

    public TransportVehicleIdentifier() { }

    public TransportVehicleIdentifier(XElement root)
    {
        TransportVehicleIdentifierType = root.Attribute("TransportVehicleIdentifierType") is { Value: var tvit } ? Enum.Parse<TransportVehicleIdentifierType>(tvit) : TransportVehicleIdentifierType;
        StateOrProvince = root.Attribute("StateOrProvince")?.Value ?? StateOrProvince;
        ISOCountryCode = root.Attribute("ISOCountryCode") is { Value: var isocc } ? Enum.Parse<ISOCountryCode>(isocc) : ISOCountryCode;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportVehicleIdentifier",
            TransportVehicleIdentifierType != null ? new XAttribute("TransportVehicleIdentifierType", TransportVehicleIdentifierType) : null,
            StateOrProvince != null ? new XAttribute("StateOrProvince", StateOrProvince) : null,
            ISOCountryCode != null ? new XAttribute("ISOCountryCode", ISOCountryCode) : null,
            Value
        ).ToString();
    }
}

public class TransportVehicleEquipment
{
    public TransportVehicleEquipmentCode? TransportVehicleEquipmentCode = null;
    public List<TransportVehicleEquipmentDescription> TransportVehicleEquipmentDescription = [];

    public TransportVehicleEquipment() { }

    public TransportVehicleEquipment(XElement root)
    {
        TransportVehicleEquipmentCode = root.Element("TransportVehicleEquipmentCode") is { } tvec ? new(tvec) : TransportVehicleEquipmentCode;
        TransportVehicleEquipmentDescription = [.. root.Elements("TransportVehicleEquipmentDescription").Select(e => new TransportVehicleEquipmentDescription(e))];
    }

    public override string ToString()
    {
        return new XElement("TransportVehicleEquipment",
            TransportVehicleEquipmentCode != null ? XElement.Parse($"{TransportVehicleEquipmentCode}") : null,
            TransportVehicleEquipmentDescription.Select(description => XElement.Parse($"{description}"))
        ).ToString();
    }
}

public class TransportVehicleEquipmentDescription
{
    public Language? Language = null;
    public string Value = string.Empty;

    public TransportVehicleEquipmentDescription() { }

    public TransportVehicleEquipmentDescription(XElement root)
    {
        Language = root.Attribute("Language") is { Value: var l } ? Enum.Parse<Language>(l) : Language;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("TransportVehicleEquipmentDescription",
            Language != null ? new XAttribute("Language", Language) : null,
            Value
        ).ToString();
    }
}

public class TransportVehicleEquipmentCode : AgencyValueBase
{
    public TransportVehicleEquipmentCode() : base() { Agency = PapiNet.Agency.Other; }

    public TransportVehicleEquipmentCode(XElement root) : base(root) { }

    public override string LocalName => "TransportVehicleEquipmentCode";
}

public class TransportVehicleMeasurements
{
    public TransportVehicleLength? TransportVehicleLength = null;
    public TransportVehicleWidth? TransportVehicleWidth = null;
    public TransportVehicleHeight? TransportVehicleHeight = null;
    public TransportVehicleWeight? TransportVehicleWeight = null;

    public TransportVehicleMeasurements() { }

    public TransportVehicleMeasurements(XElement root)
    {
        TransportVehicleLength = root.Element("TransportVehicleLength") is { } length ? new(length) : TransportVehicleLength;
        TransportVehicleWidth = root.Element("TransportVehicleWidth") is { } width ? new(width) : TransportVehicleWidth;
        TransportVehicleHeight = root.Element("TransportVehicleHeight") is { } height ? new(height) : TransportVehicleHeight;
        TransportVehicleWeight = root.Element("TransportVehicleWeight") is { } weight ? new(weight) : TransportVehicleWeight;
    }

    public override string ToString()
    {
        return new XElement("TransportVehicleMeasurements",
            TransportVehicleLength != null ? XElement.Parse($"{TransportVehicleLength}") : null,
            TransportVehicleWidth != null ? XElement.Parse($"{TransportVehicleWidth}") : null,
            TransportVehicleHeight != null ? XElement.Parse($"{TransportVehicleHeight}") : null,
            TransportVehicleWeight != null ? XElement.Parse($"{TransportVehicleWeight}") : null
        ).ToString();
    }
}

public class TransportVehicleWeight : RangeValueBase
{
    public TransportVehicleWeight() { }

    public TransportVehicleWeight(XElement root) : base(root) { }

    public override string LocalName => "TransportVehicleWeight";
}

public class TransportVehicleHeight : RangeValueBase
{
    public TransportVehicleHeight() { }

    public TransportVehicleHeight(XElement root) : base(root) { }

    public override string LocalName => "TransportVehicleHeight";
}

public class TransportVehicleWidth : RangeValueBase
{
    public TransportVehicleWidth() { }

    public TransportVehicleWidth(XElement root) : base(root) { }

    public override string LocalName => "TransportVehicleWidth";
}

public class TransportVehicleLength : RangeValueBase
{
    public TransportVehicleLength() { }

    public TransportVehicleLength(XElement root) : base(root) { }

    public override string LocalName => "TransportVehicleLength";
}

public class TransportVehicleCode : AgencyValueBase
{
    public TransportVehicleCode() : base() { Agency = PapiNet.Agency.Other; }

    public TransportVehicleCode(XElement root) : base(root) { }

    public override string LocalName => "TransportVehicleCode";
}

public class TransportModeCharacteristics
{
    public TransportModeType? TransportModeType = null;
    public TransportModeCode? TransportModeCode = null;
    public string? TransportModeText = null;

    public TransportModeCharacteristics() { }

    public TransportModeCharacteristics(XElement root)
    {
        TransportModeType = root.Attribute("TransportModeType") is { Value: var tmt } ? Enum.Parse<TransportModeType>(tmt) : TransportModeType;
        TransportModeCode = root.Element("TransportModeCode") is { } tmc ? new(tmc) : TransportModeCode;
        TransportModeText = root.Element("TransportModeText")?.Value ?? TransportModeText;
    }

    public override string ToString()
    {
        return new XElement("TransportModeCharacteristics",
            TransportModeType != null ? new XAttribute("TransportModeType", TransportModeType) : null,
            TransportModeCode != null ? XElement.Parse($"{TransportModeCode}") : null,
            TransportModeText != null ? new XElement("TransportModeText", TransportModeText) : null
        ).ToString();
    }
}

public class TransportModeCode : AgencyValueBase
{
    public TransportModeCode() { Agency = PapiNet.Agency.Other; }

    public TransportModeCode(XElement root) : base(root) { }

    public override string LocalName => "TransportModeCode";
}

public class DeliveryOrigin
{
    public Date? Date = null;
    public Time? Time = null;
    public Party LocationParty = new() { LocalName = "LocationParty" };
    public SupplyPoint? SupplyPoint = null;
    public LocationCode? LocationCode = null;
    public GPSCoordinates? GPSCoordinates = null;
    public MapCoordinates? MapCoordinates = null;

    public DeliveryOrigin() { }

    public DeliveryOrigin(XElement root)
    {
        Date = root.Element("Date") is { } d ? new(d) : Date;
        Time = root.Element("Time") is { } t ? new(t) : Time;
        LocationParty = root.Element("LocationParty") is { } lp ? new(lp) : LocationParty;
        SupplyPoint = root.Element("SupplyPoint") is { } sp ? new(sp) : SupplyPoint;
        LocationCode = root.Element("LocationCode") is { } lc ? new(lc) : LocationCode;
        GPSCoordinates = root.Element("GPSCoordinates") is { } gpsc ? new(gpsc) : GPSCoordinates;
        MapCoordinates = root.Element("MapCoordinates") is { } mc ? new(mc) : MapCoordinates;
    }

    public override string ToString()
    {
        return new XElement("DeliveryOrigin",
            Date != null ? XElement.Parse($"{Date}") : null,
            Time != null ? XElement.Parse($"{Time}") : null,
            LocationParty != null ? XElement.Parse($"{LocationParty}") : null,
            GPSCoordinates != null ? XElement.Parse($"{GPSCoordinates}") : null,
            MapCoordinates != null ? XElement.Parse($"{MapCoordinates}") : null
        ).ToString();
    }
}

public class SupplyPoint
{
    public LocationType LocationType = LocationType.Destination;
    public SupplyPointCode SupplyPointCode = new();
    public List<string> SupplyPointDescription = [];
    public List<MapCoordinates> MapCoordinates = [];

    public SupplyPoint() { }

    public SupplyPoint(XElement root)
    {
        LocationType = root.Attribute("LocationType") is { Value: var lt } ? Enum.Parse<LocationType>(lt) : LocationType;
        SupplyPointCode = root.Element("SupplyPointCode") is { } spc ? new(spc) : SupplyPointCode;
        SupplyPointDescription = [.. root.Elements("SupplyPointDescription").Select(e => e.Value)];
        MapCoordinates = [.. root.Elements("MapCoordinates").Select(e => new MapCoordinates(e))];
    }

    public override string ToString()
    {
        return new XElement("SupplyPoint",
            new XAttribute("LocationType", LocationType),
            XElement.Parse($"{SupplyPointCode}"),
            SupplyPointDescription.Select(description => new XElement("SupplyPointDescription", description)),
            MapCoordinates.Select(coordinates => XElement.Parse($"{coordinates}"))
        ).ToString();
    }
}

public class SupplyPointCode : AgencyValueBase
{
    public SupplyPointCode() : base() { Agency = PapiNet.Agency.Other; }

    public SupplyPointCode(XElement root) : base(root) { }

    public override string LocalName => "SupplyPointCode";
}

public class PriceDetails
{
    public PriceQuantityBasis PriceQuantityBasis = PriceQuantityBasis.ActualVolume;
    public PriceTaxBasis? PriceTaxBasis = null;
    public PricePerUnit PricePerUnit = new();
    public List<InformationalPricePerUnit> InformationalPricePerUnit = [];
    public List<string> AdditionalText = [];
    public ExchangeRate ExchangeRate = new();
    public MonetaryAdjustment? MonetaryAdjustment = null;
    public GeneralLedgerAccount? GeneralLedgerAccount = null;

    public PriceDetails() { }

    public PriceDetails(XElement root)
    {
        PriceQuantityBasis = root.Attribute("PriceQuantityBasis") is { Value: var pqb } ? Enum.Parse<PriceQuantityBasis>(pqb) : PriceQuantityBasis;
        PriceTaxBasis = root.Attribute("PriceTaxBasis") is { Value: var ptb } ? Enum.Parse<PriceTaxBasis>(ptb) : PriceTaxBasis;
        PricePerUnit = root.Element("PricePerUnit") is { } ppu ? new(ppu) : PricePerUnit;
        InformationalPricePerUnit = [.. root.Elements("InformationalPricePerUnit").Select(e => new InformationalPricePerUnit(e))];
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        ExchangeRate = root.Element("ExchangeRate") is { } er ? new(er) : ExchangeRate;
        MonetaryAdjustment = root.Element("MonetaryAdjustment") is { } ma ? new(ma) : MonetaryAdjustment;
        GeneralLedgerAccount = root.Element("GeneralLedgerAccount") is { } gla ? new(gla) : GeneralLedgerAccount;
    }

    public override string ToString()
    {
        return new XElement("PriceDetails",
            new XAttribute("PriceQuantityBasis", PriceQuantityBasis),
            PriceTaxBasis != null ? new XAttribute("PriceTaxBasis", PriceTaxBasis) : null,
            PricePerUnit != null ? XElement.Parse($"{PricePerUnit}") : null,
            InformationalPricePerUnit.Select(unit => XElement.Parse($"{unit}")),
            AdditionalText.Select(text => XElement.Parse($"{text}")),
            ExchangeRate != null ? XElement.Parse($"{ExchangeRate}") : null,
            MonetaryAdjustment != null ? XElement.Parse($"{MonetaryAdjustment}") : null,
            GeneralLedgerAccount != null ? XElement.Parse($"{GeneralLedgerAccount}") : null
        ).ToString();
    }
}

public class MonetaryAdjustment
{
    public AdjustmentType_Financial AdjustmentType = AdjustmentType_Financial.Other;
    public string MonetaryAdjustmentLine = string.Empty;
    public MonetaryAdjustmentStartAmount? MonetaryAdjustmentStartAmount = null;
    public MonetaryAdjustmentStartQuantity? MonetaryAdjustmentStartQuantity = null;
    public PriceAdjustment? PriceAdjustment = null;
    public FlatAmountAdjustment? FlatAmountAdjustment = null;
    public TaxAdjustment? TaxAdjustment = null;
    public InformationalAmount? InformationalAmount = null;
    public string? MonetaryAdjustmentReferenceLine = null;
    public List<string> AdditionalText = [];
    public GeneralLedgerAccount? GeneralLedgerAccount = null;
    public MonetaryAdjustmentAmount? MonetaryAdjustmentAmount = null;
    public string? AdjustmentTypeReason = null;

    public MonetaryAdjustment() { }

    public MonetaryAdjustment(XElement root)
    {
        AdjustmentType = root.Attribute("AdjustmentType") is { Value: var at } ? Enum.Parse<AdjustmentType_Financial>(at) : AdjustmentType;
        MonetaryAdjustmentLine = root.Element("MonetaryAdjustmentLine")?.Value ?? MonetaryAdjustmentLine;
        MonetaryAdjustmentStartAmount = root.Element("MonetaryAdjustmentStartAmount") is { } masa ? new(masa) : MonetaryAdjustmentStartAmount;
        MonetaryAdjustmentStartQuantity = root.Element("MonetaryAdjustmentStartQuantity") is { } masq ? new(masq) : MonetaryAdjustmentStartQuantity;
        PriceAdjustment = root.Element("PriceAdjustment") is { } pa ? new(pa) : PriceAdjustment;
        FlatAmountAdjustment = root.Element("FlatAmountAdjustment") is { } faa ? new(faa) : FlatAmountAdjustment;
        TaxAdjustment = root.Element("TaxAdjustment") is { } ta ? new(ta) : TaxAdjustment;
        InformationalAmount = root.Element("InformationalAmount") is { } ia ? new(ia) : InformationalAmount;
        MonetaryAdjustmentReferenceLine = root.Element("MonetaryAdjustmentReferenceLine")?.Value ?? MonetaryAdjustmentReferenceLine;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
        GeneralLedgerAccount = root.Element("GeneralLedgerAccount") is { } gla ? new(gla) : GeneralLedgerAccount;
        MonetaryAdjustmentAmount = root.Element("MonetaryAdjustmentAmount") is { } maa ? new(maa) : MonetaryAdjustmentAmount;
        AdjustmentTypeReason = root.Element("AdjustmentTypeReason")?.Value ?? AdjustmentTypeReason;
    }

    public override string ToString()
    {
        return new XElement("MonetaryAdjustment",
            new XAttribute("AdjustmentType", AdjustmentType),
            new XElement("MonetaryAdjustmentLine", MonetaryAdjustmentLine),
            MonetaryAdjustmentStartAmount != null ? XElement.Parse($"{MonetaryAdjustmentStartAmount}") : null,
            MonetaryAdjustmentStartQuantity != null ? XElement.Parse($"{MonetaryAdjustmentStartQuantity}") : null,
            PriceAdjustment != null ? XElement.Parse($"{PriceAdjustment}") : null,
            FlatAmountAdjustment != null ? XElement.Parse($"{FlatAmountAdjustment}") : null,
            TaxAdjustment != null ? XElement.Parse($"{TaxAdjustment}") : null,
            InformationalAmount != null ? XElement.Parse($"{InformationalAmount}") : null,
            MonetaryAdjustmentReferenceLine != null ? new XElement("MonetaryAdjustmentReferenceLine", MonetaryAdjustmentReferenceLine) : null,
            AdditionalText.Select(text => new XElement("AdditionalText", text)),
            GeneralLedgerAccount != null ? XElement.Parse($"{GeneralLedgerAccount}") : null,
            MonetaryAdjustmentAmount != null ? XElement.Parse($"{MonetaryAdjustmentAmount}") : null,
            AdjustmentTypeReason != null ? new XElement("AdjustmentTypeReason", AdjustmentTypeReason) : null
        ).ToString();
    }
}

public class MonetaryAdjustmentAmount
{
    public CurrencyValue CurrencyValue = new();

    public MonetaryAdjustmentAmount() { }

    public MonetaryAdjustmentAmount(XElement root)
    {
        CurrencyValue = root.Element("CurrencyValue") is { } cv ? new(cv) : CurrencyValue;
    }

    public override string ToString()
    {
        return new XElement("MonetaryAdjustmentAmount",
            XElement.Parse($"{CurrencyValue}")
        ).ToString();
    }
}

public class GeneralLedgerAccount : AgencyValueBase
{
    public GeneralLedgerAccount() { }

    public GeneralLedgerAccount(XElement root) : base(root) { }

    public override string LocalName => "GeneralLedgerAccount";
}

public class TaxAdjustment
{
    public TaxCategoryType? TaxCategoryType = null;
    public TaxType TaxType = TaxType.VAT;
    public string? TaxPercent = null;
    public TaxAmount? TaxAmount = null;
    public string TaxLocation = string.Empty;
    public List<InformationalAmount> InformationalAmount = [];

    public TaxAdjustment() { }

    public TaxAdjustment(XElement root)
    {
        TaxCategoryType = root.Attribute("TaxCategoryType") is { Value: var tct } ? Enum.Parse<TaxCategoryType>(tct) : TaxCategoryType;
        TaxType = root.Attribute("TaxType") is { Value: var tt } ? Enum.Parse<TaxType>(tt) : TaxType;
        TaxPercent = root.Element("TaxPercent")?.Value ?? TaxPercent;
        TaxAmount = root.Element("TaxAmount") is { } ta ? new(ta) : TaxAmount;
        TaxLocation = root.Element("TaxLocation")?.Value ?? TaxLocation;
        InformationalAmount = [.. root.Elements("InformationalAmount").Select(e => new InformationalAmount(e))];
    }

    public override string ToString()
    {
        return new XElement("TaxAdjustment",
            TaxCategoryType != null ? new XAttribute("TaxCategoryType", TaxCategoryType) : null,
            new XAttribute("TaxType", TaxType),
            TaxPercent != null ? XElement.Parse($"{TaxPercent}") : null,
            TaxAmount != null ? XElement.Parse($"{TaxAmount}") : null,
            new XElement("TaxLocation", TaxLocation),
            InformationalAmount.Select(amount => XElement.Parse($"{amount}"))
        ).ToString();
    }
}

public class InformationalAmount
{
    public AmountType? AmountType = null;
    public CurrencyValue CurrencyValue = new();
    public ExchangeRate? ExchangeRate = null;
    public List<string> AdditionalText = [];

    public InformationalAmount() { }

    public InformationalAmount(XElement root)
    {
        AmountType = root.Attribute("AmountType") is { Value: var at } ? Enum.Parse<AmountType>(at) : AmountType;
        CurrencyValue = root.Element("CurrencyValue") is { } cv ? new(cv) : CurrencyValue;
        ExchangeRate = root.Element("ExchangeRate") is { } er ? new(er) : ExchangeRate;
        AdditionalText = [.. root.Elements("AdditionalText").Select(e => e.Value)];
    }

    public override string ToString()
    {
        return new XElement("InformationalAmount",
            AmountType != null ? new XAttribute("AmountType", AmountType) : null,
            XElement.Parse($"{CurrencyValue}"),
            ExchangeRate != null ? XElement.Parse($"{ExchangeRate}") : null,
            AdditionalText.Select(text => new XElement("AdditionalText", text))
        ).ToString();
    }
}

public class TaxAmount
{
    public CurrencyValue CurrencyValue = new();

    public TaxAmount() { }

    public TaxAmount(XElement root)
    {
        CurrencyValue = root.Element("CurrencyValue") is { } cv ? new(cv) : CurrencyValue;
    }

    public override string ToString()
    {
        return new XElement("TaxAmount",
            XElement.Parse($"{CurrencyValue}")
        ).ToString();
    }
}

public class FlatAmountAdjustment
{
    public AdjustmentPercentage? AdjustmentPercentage = null;
    public AdjustmentFixedAmount? AdjustmentFixedAmount = null;
    public string Value = string.Empty;

    public FlatAmountAdjustment() { }

    public FlatAmountAdjustment(XElement root)
    {
        AdjustmentPercentage = root.Element("AdjustmentPercentage") is { } ap ? new(ap) : AdjustmentPercentage;
        AdjustmentFixedAmount = root.Element("AdjustmentFixedAmount") is { } afa ? new(afa) : AdjustmentFixedAmount;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("FlatAmountAdjustment",
            AdjustmentPercentage != null ? XElement.Parse($"{AdjustmentPercentage}") : null,
            AdjustmentFixedAmount != null ? XElement.Parse($"{AdjustmentFixedAmount}") : null,
            Value
        ).ToString();
    }
}

public class AdjustmentFixedAmount
{
    public CurrencyValue CurrencyValue = new();
    public string Value = string.Empty;

    public AdjustmentFixedAmount() { }

    public AdjustmentFixedAmount(XElement root)
    {
        CurrencyValue = root.Element("CurrencyValue") is { } cv ? new(cv) : CurrencyValue;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("AdjustmentFixedAmount",
            XElement.Parse($"{CurrencyValue}"),
            Value
        ).ToString();
    }
}

public class PriceAdjustment
{
    public AdjustmentPercentage? AdjustmentPercentage = null;
    public AdjustmentValue? AdjustmentValue = null;
    public string Value = string.Empty;

    public PriceAdjustment() { }

    public PriceAdjustment(XElement root)
    {
        AdjustmentPercentage = root.Element("AdjustmentPercentage") is { } ap ? new(ap) : AdjustmentPercentage;
        AdjustmentValue = root.Element("AdjustmentValue") is { } av ? new(av) : AdjustmentValue;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("PriceAdjustment",
            AdjustmentPercentage != null ? XElement.Parse($"{AdjustmentPercentage}") : null,
            AdjustmentValue != null ? XElement.Parse($"{AdjustmentValue}") : null,
            Value
        ).ToString();
    }
}

public class AdjustmentValue : RangeValueBase
{
    public CurrencyValue CurrencyValue = new();

    public AdjustmentValue() { }

    public AdjustmentValue(XElement root) : base(root)
    {
        CurrencyValue = root.Element("CurrencyValue") is { } cv ? new(cv) : CurrencyValue;
    }

    public override string LocalName => "AdjustmentValue";

    public override string ToString()
    {
        return new XElement(LocalName,
            XElement.Parse($"{CurrencyValue}"),
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class AdjustmentPercentage : RangeValueBase
{
    public AdjustmentPercentage() { }

    public AdjustmentPercentage(XElement root) : base(root) { }

    public override string LocalName => "AdjustmentPercentage";
}

public class MonetaryAdjustmentStartQuantity : RangeValueBase
{
    public MonetaryAdjustmentStartQuantity() { }

    public MonetaryAdjustmentStartQuantity(XElement root) : base(root) { }

    public override string LocalName => "MonetaryAdjustmentStartQuantity";
}

public class MonetaryAdjustmentStartAmount
{
    public CurrencyValue CurrencyValue = new();
    public string Value = string.Empty;

    public MonetaryAdjustmentStartAmount() { }

    public MonetaryAdjustmentStartAmount(XElement root)
    {
        CurrencyValue = root.Element("CurrencyValue") is XElement currencyValue
            ? new CurrencyValue(currencyValue)
            : CurrencyValue;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("MonetaryAdjustmentStartAmount",
            XElement.Parse($"{CurrencyValue}"),
            Value
        ).ToString();
    }
}

public class ExchangeRate
{
    public ExchangeRateType ExchangeRateType = ExchangeRateType.Fixed;
    public CurrencyFromType? CurrencyFromType = null;
    public CurrencyValue? CurrencyValue = null;
    public MinCurrencyValue MinCurrencyValue = new();
    public MaxCurrencyValue MaxCurrencyValue = new();
    public Date? Date = null;

    public ExchangeRate() { }

    public ExchangeRate(XElement root)
    {
        ExchangeRateType = root.Attribute("ExchangeRateType") is { Value: var ert } ? Enum.Parse<ExchangeRateType>(ert) : ExchangeRateType;
        CurrencyFromType = root.Attribute("CurrencyFromType") is { Value: var cft } ? Enum.Parse<CurrencyFromType>(cft) : CurrencyFromType;
        CurrencyValue = root.Element("CurrencyValue") is { } ct ? new(ct) : CurrencyValue;
        MinCurrencyValue = root.Element("MinCurrencyValue") is { } mincv ? new(mincv) : MinCurrencyValue;
        MaxCurrencyValue = root.Element("MaxCurrencyValue") is { } maxcv ? new(maxcv) : MaxCurrencyValue;
        Date = root.Element("Date") is { } d ? new(d) : Date;
    }

    public override string ToString()
    {
        return new XElement("ExchangeRate",
            new XAttribute("ExchangeRateType", ExchangeRateType),
            CurrencyFromType != null ? new XAttribute("CurrencyFromType", CurrencyFromType) : null,
            MinCurrencyValue != null ? XElement.Parse($"{MinCurrencyValue}") : null,
            MaxCurrencyValue != null ? XElement.Parse($"{MaxCurrencyValue}") : null,
            Date != null ? XElement.Parse($"{Date}") : null
        ).ToString();
    }
}

public class MaxCurrencyValue : CurrencyValueBase
{
    public MaxCurrencyValue() : base() { }

    public MaxCurrencyValue(XElement root) : base(root) { }

    public override string LocalName => "MaxCurrencyValue";
}

public class MinCurrencyValue : CurrencyValueBase
{
    public MinCurrencyValue() : base() { }

    public MinCurrencyValue(XElement root) : base(root) { }

    public override string LocalName => "MinCurrencyValue";
}

public abstract class CurrencyValueBase
{
    public CurrencyType? CurrencyType = null;
    public string Value = string.Empty;

    public abstract string LocalName { get; }

    public CurrencyValueBase() { }

    public CurrencyValueBase(XElement root)
    {
        CurrencyType = root.Attribute("CurrencyType") is { Value: var ct } ? Enum.Parse<CurrencyType>(ct) : CurrencyType;
        Value = root.Value;
    }
    
    public override string ToString()
    {
        return new XElement(LocalName,
            CurrencyType != null ? new XAttribute("CurrencyType", CurrencyType) : null,
            Value
        ).ToString();
    }
}

public class InformationalPricePerUnit : RangeValueBase
{
    public InformationalPricePerUnitType InformationalPricePerUnitType = InformationalPricePerUnitType.ProductPrice;
    public CurrencyValue CurrencyValue = new();

    public InformationalPricePerUnit() { }

    public InformationalPricePerUnit(XElement root) : base(root)
    {
        InformationalPricePerUnitType = root.Attribute("InformationalPricePerUnitType") is { Value: var ipput } ? Enum.Parse<InformationalPricePerUnitType>(ipput) : InformationalPricePerUnitType;
        CurrencyValue = root.Element("CurrencyValue") is { } cv ? new(cv) : CurrencyValue;
    }

    public override string LocalName => "InformationalPricePerUnit";

    public override string ToString()
    {
        return new XElement(LocalName,
            new XAttribute("InformationalPricePerUnitType", InformationalPricePerUnitType),
            XElement.Parse($"{CurrencyValue}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class PricePerUnit : RangeValueBase
{
    public CurrencyValue CurrencyValue = new();

    public PricePerUnit() { }

    public PricePerUnit(XElement root) : base(root)
    {
        CurrencyValue = root.Element("CurrencyValue") is { } cv ? new(cv) : CurrencyValue;
    }

    public override string LocalName => "PricePerUnit";

    public override string ToString()
    {
        return new XElement(LocalName,
            XElement.Parse($"{CurrencyValue}"),
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class CurrencyValue
{
    public string CurrencyType = string.Empty;
    public string Value = string.Empty;

    public CurrencyValue() { }

    public CurrencyValue(XElement root)
    {
        CurrencyType = root.Attribute("CurrencyType")?.Value ?? CurrencyType;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("CurrencyValue",
            new XAttribute("CurrencyType", CurrencyType),
            Value
        ).ToString();
    }
}

public class InformationalQuantity : Quantity
{
    public InformationalQuantity() : base() { }

    public InformationalQuantity(XElement root) : base(root) { }

    public override string ToString()
    {
        return new XElement("InformationalQuantity",
            new XAttribute("QuantityType", QuantityType),
            QuantityTypeContext != null ? new XAttribute("QuantityTypeContext", QuantityTypeContext) : null,
            AdjustmentType != null ? new XAttribute("AdjustmentType", AdjustmentType) : null,
            MeasuringAgency != null ? new XAttribute("MeasuringAgency", MeasuringAgency) : null,
            MeasuringMethod != null ? new XAttribute("MeasuringMethod", MeasuringMethod) : null,
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class Quantity
{
    public QuantityType QuantityType = QuantityType.ActualVolume;
    public QuantityTypeContext? QuantityTypeContext = null;
    public AdjustmentType_Tare? AdjustmentType = null;
    public MeasuringAgency? MeasuringAgency = null;
    public string? MeasuringMethod = null;
    public Value Value = new();
    public RangeMin? RangeMin = null;
    public RangeMax? RangeMax = null;

    public Quantity() { }

    public Quantity(XElement root)
    {
        QuantityType = root.Attribute("QuantityType") is { Value: var qt } ? Enum.Parse<QuantityType>(qt) : QuantityType;
        QuantityTypeContext = root.Attribute("QuantityTypeContext") is { Value: var qtc } ? Enum.Parse<QuantityTypeContext>(qtc) : QuantityTypeContext;
        AdjustmentType = root.Attribute("AdjustmentType") is { Value: var at } ? Enum.Parse<AdjustmentType_Tare>(at) : AdjustmentType;
        MeasuringAgency = root.Attribute("MeasuringAgency") is { Value: var ma } ? Enum.Parse<MeasuringAgency>(ma) : MeasuringAgency;
        MeasuringMethod = root.Attribute("MeasuringMethod")?.Value ?? MeasuringMethod;
        Value = root.Element("Value") is { } v ? new(v) : Value;
        RangeMin = root.Element("RangeMin") is { } rmin ? new(rmin) : RangeMin;
        RangeMax = root.Element("RangeMax") is { } rmax ? new(rmax) : RangeMax;
    }

    public override string ToString()
    {
        return new XElement("Quantity",
            new XAttribute("QuantityType", QuantityType),
            QuantityTypeContext != null ? new XAttribute("QuantityTypeContext", QuantityTypeContext) : null,
            AdjustmentType != null ? new XAttribute("AdjustmentType", AdjustmentType) : null,
            MeasuringAgency != null ? new XAttribute("MeasuringAgency", MeasuringAgency) : null,
            MeasuringMethod != null ? new XAttribute("MeasuringMethod", MeasuringMethod) : null,
            XElement.Parse($"{Value}"),
            RangeMin != null ? XElement.Parse($"{RangeMin}") : null,
            RangeMax != null ? XElement.Parse($"{RangeMax}") : null
        ).ToString();
    }
}

public class RangeMin : ValueBase
{
    public RangeMin() : base() { }

    public RangeMin(XElement root) : base(root) { }

    public override string LocalName => "RangeMin";
}

public class RangeMax : ValueBase
{
    public RangeMax() : base() { }

    public RangeMax(XElement root) : base(root) { }

    public override string LocalName => "RangeMax";
}

public class Value : ValueBase
{
    public Value() : base() { }

    public Value(XElement root) : base(root) { }

    public override string LocalName => "Value";
}

public abstract class ValueBase
{
    public UOM UOM = UOM.Unit;
    public string Value = string.Empty;

    public abstract string LocalName { get; }

    public ValueBase() { }

    public ValueBase(XElement root)
    {
        UOM = root.Attribute("UOM") is { Value: var uom } ? Enum.Parse<UOM>(uom) : UOM;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement(LocalName,
            new XAttribute("UOM", UOM),
            Value
        ).ToString();
    }
}

public class DeliveryDateWindow
{
    public DeliveryDateType DeliveryDateType = DeliveryDateType.ActualArrivalDate;
    public DateTimeRange? DateTimeRange = null;
    public string? Month = null;
    public string? Week = null;
    public Date Date = new();
    public Time? Time = null;

    public DeliveryDateWindow() { }

    public DeliveryDateWindow(XElement root)
    {
        DeliveryDateType = root.Attribute("DeliveryDateType") is { Value: var ddt } ? Enum.Parse<DeliveryDateType>(ddt) : DeliveryDateType;
        DateTimeRange = root.Element("DateTimeRange") is { } dtr ? new(dtr) : DateTimeRange;
        Month = root.Element("Month")?.Value ?? Month;
        Week = root.Element("Week")?.Value ?? Week;
        Date = root.Element("Date") is { } d ? new(d) : Date;
        Time = root.Element("Time") is { } t ? new(t) : Time;
    }

    public override string ToString()
    {
        return new XElement("DeliveryDateWindow",
            new XAttribute("DeliveryDateType", DeliveryDateType),
            DateTimeRange != null ? XElement.Parse($"{DateTimeRange}") : null,
            Month != null ? XElement.Parse($"{Month}") : null,
            Week != null ? XElement.Parse($"{Week}") : null,
            Date != null ? XElement.Parse($"{Date}") : null,
            Time != null ? XElement.Parse($"{Time}") : null
        ).ToString();
    }
}

public class DateTimeRange
{
    public DateTimeFrom DateTimeFrom = new();
    public DateTimeTo DateTimeTo = new();

    public DateTimeRange() { }

    public DateTimeRange(XElement root)
    {
        DateTimeFrom = root.Element("DateTimeFrom") is { } dtf ? new(dtf) : DateTimeFrom;
        DateTimeTo = root.Element("DateTimeTo") is { } dtt ? new(dtt) : DateTimeTo;
    }

    public override string ToString()
    {
        return new XElement("DateTimeRange",
            XElement.Parse($"{DateTimeFrom}"),
            XElement.Parse($"{DateTimeTo}")
        ).ToString();
    }
}

public class DateTimeTo
{
    public Date Date = new();
    public Time? Time = null;

    public DateTimeTo() { }

    public DateTimeTo(XElement root)
    {
        Date = root.Element("Date") is { } d ? new(d) : Date;
        Time = root.Element("Time") is { } t ? new(t) : Time;
    }

    public override string ToString()
    {
        return new XElement("DateTimeTo",
            XElement.Parse($"{Date}"),
            Time != null ? XElement.Parse($"{Time}") : null
        ).ToString();
    }
}

public class DateTimeFrom
{
    public Date Date = new();
    public Time? Time = null;

    public DateTimeFrom() { }

    public DateTimeFrom(XElement root)
    {
        Date = root.Element("Date") is { } d ? new(d) : Date;
        Time = root.Element("Time") is { } t ? new(t) : Time;
    }

    public override string ToString()
    {
        return new XElement("DateTimeFrom",
            XElement.Parse($"{Date}"),
            Time != null ? XElement.Parse($"{Time}") : null
        ).ToString();
    }
}

public class DeliveryStatus
{
    public DeliveryStatusType? DeliveryStatusType = null;
    public DeliveryLastDateOfChange? DeliveryLastDateOfChange = null;

    public DeliveryStatus() { }

    public DeliveryStatus(XElement root)
    {
        DeliveryStatusType = root.Attribute("DeliveryStatusType") is { Value: var dst } ? Enum.Parse<DeliveryStatusType>(dst) : DeliveryStatusType;
        DeliveryLastDateOfChange = root.Element("DeliveryLastDateOfChange") is { } dldoc ? new(dldoc) : DeliveryLastDateOfChange;
    }

    public override string ToString()
    {
        return new XElement("DeliveryStatus",
            DeliveryStatusType != null ? new XAttribute("DeliveryStatusType", DeliveryStatusType) : null,
            DeliveryLastDateOfChange != null ? XElement.Parse($"{DeliveryLastDateOfChange}") : null
        ).ToString();
    }
}

public class DeliveryLastDateOfChange
{
    public Date Date = new();
    public Time? Time = null;

    public DeliveryLastDateOfChange() { }

    public DeliveryLastDateOfChange(XElement root)
    {
        Date = root.Element("Date") is { } d ? new(d) : Date;
        Time = root.Element("Time") is { } t ? new(t) : Time;
    }

    public override string ToString()
    {
        return new XElement("DeliveryLastDateOfChange",
            new XElement("Date", Date),
            Time != null ? new XElement("Time") : null
        ).ToString();
    }
}

public class ProductionStatus
{
    public ProductionStatusType ProductionStatusType = ProductionStatusType.Free;
    public ProductionLastDateOfChange? ProductionLastDateOfChange = null;

    public ProductionStatus() { }

    public ProductionStatus(XElement root)
    {
        ProductionStatusType = root.Attribute("ProductionStatusType") is { Value: var pst } ? Enum.Parse<ProductionStatusType>(pst) : ProductionStatusType;
        ProductionLastDateOfChange = root.Element("ProductionLastDateOfChange") is { } pldoc ? new(pldoc) : ProductionLastDateOfChange;
    }

    public override string ToString()
    {
        return new XElement("ProductionLastDateOfChange",
            new XAttribute("ProductionStatusType", ProductionStatusType),
            ProductionLastDateOfChange != null ? XElement.Parse($"{ProductionLastDateOfChange}") : null
        ).ToString();
    }
}

public class ProductionLastDateOfChange
{
    public Date Date = new();
    public Time? Time = null;

    public ProductionLastDateOfChange() { }

    public ProductionLastDateOfChange(XElement root)
    {
        Date = root.Element("Date") is { } d ? new(d) : Date;
        Time = root.Element("Time") is { } t ? new(t) : Time;
    }

    public override string ToString()
    {
        return new XElement("ProductionLastDateOfChange",
            new XElement("Date", Date),
            Time != null ? new XElement("Time") : null
        ).ToString();
    }
}

public class ShipToCharacteristics
{
    public Party ShipToParty = new() { LocalName = "ShipToParty" };
    public LocationCode? LocationCode = null;
    public TermsOfDelivery? TermsOfDelivery = null;
    public DeliveryRouteCode? DeliveryRouteCode = null;

    public ShipToCharacteristics() { }

    public ShipToCharacteristics(XElement root)
    {
        ShipToParty = root.Element("ShipToParty") is { } stp ? new(stp) : ShipToParty;
        LocationCode = root.Element("LocationCode") is { } lc ? new(lc) : LocationCode;
        TermsOfDelivery = root.Element("TermsOfDelivery") is { } tod ? new(tod) : TermsOfDelivery;
        DeliveryRouteCode = root.Element("DeliveryRouteCode") is { } drc ? new(drc) : DeliveryRouteCode;
    }

    public override string ToString()
    {
        return new XElement("ShipToCharacteristics",
            new XElement("ShipToParty", ShipToParty),
            LocationCode != null ? XElement.Parse($"{LocationCode}") : null,
            TermsOfDelivery != null ? XElement.Parse($"{TermsOfDelivery}") : null,
            DeliveryRouteCode != null ? XElement.Parse($"{DeliveryRouteCode}") : null
        ).ToString();
    }
}

public class LocationCode : AgencyValueBase
{
    public LocationCode() : base() { Agency = PapiNet.Agency.Other; }

    public LocationCode(XElement root) : base(root) { }

    public override string LocalName => "LocationCode";
}

public class DeliveryRouteCode : AgencyValueBase
{
    public DeliveryRouteCode() : base() { Agency = PapiNet.Agency.Other; }

    public DeliveryRouteCode(XElement root) : base(root) { }

    public override string LocalName => "DeliveryRouteCode";
}

public class TermsOfDelivery
{
    public IncotermsLocation? IncotermsLocation = null;
    public ShipmentMethodOfPayment? ShipmentMethodOfPayment = null;
    public string? FreightPayableAt = null;
    public string? AdditionalText = null;

    public TermsOfDelivery() { }

    public TermsOfDelivery(XElement root)
    {
        IncotermsLocation = root.Element("IncotermsLocation") is { } il ? new(il) : IncotermsLocation;
        ShipmentMethodOfPayment = root.Element("ShipmentMethodOfPayment") is { } smop ? new(smop) : ShipmentMethodOfPayment;
        FreightPayableAt = root.Element("FreightPayableAt")?.Value ?? FreightPayableAt;
        AdditionalText = root.Element("AdditionalText")?.Value ?? AdditionalText;
    }

    public override string ToString()
    {
        return new XElement("TermsOfDelivery",
            IncotermsLocation != null ? XElement.Parse($"{IncotermsLocation}") : null,
            ShipmentMethodOfPayment != null ? XElement.Parse($"{ShipmentMethodOfPayment}") : null,
            FreightPayableAt != null ? new XElement("FreightPayableAt", FreightPayableAt) : null,
            AdditionalText != null ? new XElement("AdditionalText", AdditionalText) : null
        ).ToString();
    }
}

public class ShipmentMethodOfPayment
{
    public LocationQualifier? LocationQualifier = null;
    public Method? Method = null;
    public string Value = string.Empty;

    public ShipmentMethodOfPayment() { }

    public ShipmentMethodOfPayment(XElement root)
    {
        LocationQualifier = root.Attribute("LocationQualifier") is { Value: var lq } ? Enum.Parse<LocationQualifier>(lq) : LocationQualifier;
        Method = root.Attribute("Method") is { Value: var m } ? Enum.Parse<Method>(m) : Method;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("ShipmentMethodOfPayment",
            LocationQualifier != null ? new XAttribute("LocationQualifier", LocationQualifier) : null,
            Method != null ? new XAttribute("Method", Method) : null,
            Value
        ).ToString();
    }
}

public class IncotermsLocation
{
    public Incoterms Incoterms = Incoterms.Other;
    public string? IncotermsVersion = null;
    public string Value = string.Empty;

    public IncotermsLocation() { }

    public IncotermsLocation(XElement root)
    {
        Incoterms = root.Attribute("Incoterms") is { Value: var i } ? Enum.Parse<Incoterms>(i) : Incoterms;
        IncotermsVersion = root.Attribute("IncotermsVersion")?.Value ?? IncotermsVersion;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("IncotermsLocation",
            new XAttribute("Incoterms", Incoterms),
            IncotermsVersion != null ? new XAttribute("IncotermsVersion", IncotermsVersion) : null,
            Value
        ).ToString();
    }
}

public class Party
{
    public string LocalName = "OtherParty";
    public PartyType? PartyType = null;
    public LogisticsRole? LogisticsRole = null;
    public List<PartyIdentifier> PartyIdentifier = [];
    public NameAddress NameAddress = new();
    public string? URL = null;
    public CommonContact? CommonContact = null;

    public Party() { }

    public Party(XElement root)
    {
        LocalName = root.Name.LocalName;
        PartyType = root.Attribute("PartyType") is { Value: var pt } ? Enum.Parse<PartyType>(pt) : PartyType;
        LogisticsRole = root.Attribute("LogisticsRole") is { Value: var lr } ? Enum.Parse<LogisticsRole>(lr) : LogisticsRole;
        PartyIdentifier = [.. root.Elements("PartyIdentifier").Select(e => new PartyIdentifier(e))];
        NameAddress = root.Element("NameAddress") is { } na ? new(na) : NameAddress;
        URL = root.Element("URL")?.Value ?? URL;
        CommonContact = root.Element("CommonContact") is { } cc ? new(cc) : CommonContact;
    }

    public override string ToString()
    {
        return new XElement(LocalName,
            PartyType != null ? new XAttribute("PartyType", PartyType) : null,
            LogisticsRole != null ? new XAttribute("LogisticsRole", LogisticsRole) : null,
            PartyIdentifier.Select(identifier => XElement.Parse($"{identifier}")),
            XElement.Parse($"{NameAddress}"),
            URL != null ? new XElement("URL", URL) : null,
            CommonContact != null ? XElement.Parse($"{CommonContact}") : null
        ).ToString();
    }
}

public class CommonContact
{
    public ContactType ContactType = ContactType.Other;
    public string ContactName = string.Empty;
    public string? ContactIdentifier = null;
    public string? Telephone = null;
    public string? MobilePhone = null;
    public string? Email = null;
    public string? Fax = null;
    public GPSCoordinates? GPSCoordinates = null;
    public MapCoordinates? MapCoordinates = null;

    public CommonContact() { }

    public CommonContact(XElement root)
    {
        ContactType = root.Attribute("ContactType") is { Value: var ct } ? Enum.Parse<ContactType>(ct) : ContactType;
        ContactName = root.Element("ContactName")?.Value ?? ContactName;
        ContactIdentifier = root.Element("ContactIdentifier")?.Value ?? ContactIdentifier;
        Telephone = root.Element("Telephone")?.Value ?? Telephone;
        MobilePhone = root.Element("MobilePhone")?.Value ?? MobilePhone;
        Email = root.Element("Email")?.Value ?? Email;
        Fax = root.Element("Fax")?.Value ?? Fax;
        GPSCoordinates = root.Element("GPSCoordinates") is { } gpsc ? new(gpsc) : GPSCoordinates;
        MapCoordinates = root.Element("MapCoordinates") is { } mp ? new(mp) : MapCoordinates;
    }

    public override string ToString()
    {
        return new XElement("CommonContact",
            new XAttribute("ContactType", ContactType),
            new XElement("ContactName", ContactName),
            ContactIdentifier != null ? new XElement("ContactIdentifier", ContactIdentifier) : null,
            Telephone != null ? new XElement("Telephone", Telephone) : null,
            MobilePhone != null ? new XElement("MobilePhone", MobilePhone) : null,
            Email != null ? new XElement("Email", Email) : null,
            Fax != null ? new XElement("Fax", Fax) : null,
            GPSCoordinates != null ? XElement.Parse($"{GPSCoordinates}") : null,
            MapCoordinates != null ? XElement.Parse($"{MapCoordinates}") : null
        ).ToString();
    }
}

public class MapCoordinates
{
    public MapReferenceSystem MapReferenceSystem = MapReferenceSystem.NTF;
    public MapCoordinateType MapCoordinateType = MapCoordinateType.UTM;
    public string Coordinates = string.Empty;
    public string? Altitude = null;

    public MapCoordinates() { }

    public MapCoordinates(XElement root)
    {
        MapReferenceSystem = root.Attribute("MapReferenceSystem") is { Value: var mrs } ? Enum.Parse<MapReferenceSystem>(mrs) : MapReferenceSystem;
        MapCoordinateType = root.Attribute("MapCoordinateType") is { Value: var mct } ? Enum.Parse<MapCoordinateType>(mct) : MapCoordinateType;
        Coordinates = root.Element("Coordinates")?.Value ?? Coordinates;
        Altitude = root.Element("Altitude")?.Value ?? Altitude;
    }

    public override string ToString()
    {
        return new XElement("MapCoordinates",
            new XAttribute("MapReferenceSystem", MapReferenceSystem),
            new XAttribute("MapCoordinateType", MapCoordinateType),
            new XElement("Coordinates"),
            Altitude != null ? new XElement("Altitude", Altitude) : null
        ).ToString();
    }
}

public class NameAddress
{
    public CommunicationRole? CommunicationRole = null;
    public string Name1 = string.Empty;
    public string? Name2 = null;
    public string? Name3 = null;
    public string? OrganisationUnit = null;
    public string? Address1 = null;
    public string? Address2 = null;
    public string? Address3 = null;
    public string? Address4 = null;
    public string? City = null;
    public string? County = null;
    public string? StateOrProvince = null;
    public string? PostalCode = null;
    public Country? Country = null;
    public GPSCoordinates? GPSCoordinates = null;
    public MapCoordinates? MapCoordinates = null;

    public NameAddress() { }

    public NameAddress(XElement root)
    {
        CommunicationRole = root.Attribute("CommunicationRole") is { Value: var cr } ? Enum.Parse<CommunicationRole>(cr) : CommunicationRole;
        Name1 = root.Element("Name1")?.Value ?? Name1;
        Name2 = root.Element("Name2")?.Value ?? Name2;
        Name3 = root.Element("Name3")?.Value ?? Name3;
        OrganisationUnit = root.Element("OrganisationUnit")?.Value ?? OrganisationUnit;
        Address1 = root.Element("Address1")?.Value ?? Address1;
        Address2 = root.Element("Address2")?.Value ?? Address2;
        Address3 = root.Element("Address3")?.Value ?? Address3;
        Address4 = root.Element("Address4")?.Value ?? Address4;
        City = root.Element("City")?.Value ?? City;
        County = root.Element("County")?.Value ?? County;
        StateOrProvince = root.Element("StateOrProvince")?.Value ?? StateOrProvince;
        PostalCode = root.Element("PostalCode")?.Value ?? PostalCode;
        Country = root.Element("Country") is { } c ? new(c) : Country;
        GPSCoordinates = root.Element("GPSCoordinates") is { } gpsc ? new(gpsc) : GPSCoordinates;
        MapCoordinates = root.Element("MapCoordinates") is { } mc ? new(mc) : MapCoordinates;
    }

    public override string ToString()
    {
        return new XElement("NameAddress",
            new XElement("Name1", Name1),
            Name2 != null ? new XElement("Name2", Name2) : null,
            Name3 != null ? new XElement("Name3", Name3) : null,
            OrganisationUnit != null ? new XElement("OrganisationUnit", OrganisationUnit) : null,
            Address1 != null ? new XElement("Address1", Address1) : null,
            Address2 != null ? new XElement("Address2", Address2) : null,
            Address3 != null ? new XElement("Address3", Address3) : null,
            Address4 != null ? new XElement("Address4", Address4) : null,
            City != null ? new XElement("City", City) : null,
            County != null ? new XElement("County", County) : null,
            StateOrProvince != null ? new XElement("StateOrProvince", StateOrProvince) : null,
            PostalCode != null ? new XElement("PostalCode", PostalCode) : null,
            Country != null ? XElement.Parse($"{Country}") : null,
            GPSCoordinates != null ? XElement.Parse($"{GPSCoordinates}") : null,
            MapCoordinates != null ? XElement.Parse($"{MapCoordinates}") : null
        ).ToString();
    }
}

public class Country
{
    public ISOCountryCode? ISOCountryCode = null;
    public string Value = string.Empty;

    public Country() { }

    public Country(XElement root)
    {
        ISOCountryCode = root.Attribute("ISOCountryCode") is { Value: var v } ? Enum.Parse<ISOCountryCode>(v) : ISOCountryCode;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement("Country",
            ISOCountryCode != null ? new XAttribute("ISOCountryCode", ISOCountryCode) : null,
            Value
        ).ToString();
    }
}

public class GPSCoordinates
{
    public GPSSystem? GPSSystem = null;
    public string Latitude = string.Empty;
    public string Longitude = string.Empty;
    public string? Height = null;

    public GPSCoordinates() { }

    public GPSCoordinates(XElement root)
    {
        GPSSystem = root.Attribute("GPSSystem") is { Value: var gpss } ? Enum.Parse<GPSSystem>(gpss) : GPSSystem;
        Latitude = root.Element("Latitude")?.Value ?? Latitude;
        Longitude = root.Element("Longitude")?.Value ?? Longitude;
        Height = root.Element("Height")?.Value ?? Height;
    }

    public override string ToString()
    {
        return new XElement("GPSCoordinates",
            GPSSystem != null ? new XAttribute("GPSSystem", GPSSystem) : null,
            new XElement("Latitude", Latitude),
            new XElement("Longitude", Longitude),
            Height != null ? new XElement("Height", Height) : null
        ).ToString();
    }
}

public class PartyIdentifier : AgencyValueBase
{
    public PartyIdentifierType PartyIdentifierType = PartyIdentifierType.Other;

    public PartyIdentifier() : base() { }

    public PartyIdentifier(XElement root) : base(root)
    {
        PartyIdentifierType = root.Attribute("PartyIdentifierType") is { Value: var pit } ? Enum.Parse<PartyIdentifierType>(pit) : PartyIdentifierType;
    }

    public override string LocalName => "PartyIdentifier";

    public override string ToString()
    {
        return new XElement(LocalName,
            new XAttribute("PartyIdentifierType", PartyIdentifierType),
            Agency != null ? new XAttribute("Agency", Agency) : null,
            Value
        ).ToString();
    }
}

public class DocumentReferenceInformation
{
    public string DocumentReferenceID = string.Empty;
    public string? DocumentReferenceIDLineItemNumber = null;
    public Date? Date = null;
    public Time? Time = null;
    public string? NumberOfDocumentsRequired = null;

    public DocumentReferenceInformation() { }

    public DocumentReferenceInformation(XElement root)
    {
        DocumentReferenceID = root.Element("DocumentReferenceID")?.Value ?? DocumentReferenceID;
        DocumentReferenceIDLineItemNumber = root.Element("DocumentReferenceIDLineItemNumber")?.Value ?? DocumentReferenceIDLineItemNumber;
        Date = root.Element("Date") is XElement date ? new Date(date) : Date;
        Time = root.Element("Time") is XElement time ? new Time(time) : Time;
        NumberOfDocumentsRequired = root.Element("NumberOfDocumentsRequired")?.Value ?? NumberOfDocumentsRequired;
    }

    public override string ToString()
    {
        return new XElement("DocumentReferenceInformation",
            new XElement("DocumentReferenceID", DocumentReferenceID),
            DocumentReferenceIDLineItemNumber != null ? new XElement("DocumentReferenceIDLineItemNumber", DocumentReferenceIDLineItemNumber) : null,
            Date != null ? XElement.Parse($"{Date}") : null,
            Time != null ? XElement.Parse($"{Time}") : null,
            NumberOfDocumentsRequired != null ? new XElement("NumberOfDocumentsRequired", NumberOfDocumentsRequired) : null
        ).ToString();
    }
}

public class DeliveryMessageReference : AssignedByReferenceValueBase
{
    public DeliveryMessageReferenceType DeliveryMessageReferenceType = DeliveryMessageReferenceType.Other;

    public DeliveryMessageReference() : base() { }

    public DeliveryMessageReference(XElement root) : base(root)
    {
        DeliveryMessageReferenceType = root.Attribute("DeliveryMessageReferenceType") is { Value: var dmrt } ? Enum.Parse<DeliveryMessageReferenceType>(dmrt) : DeliveryMessageReferenceType;
    }

    public override string LocalName => "DeliveryMessageReference";

    public override string ToString()
    {
        return new XElement(LocalName,
            new XAttribute("DeliveryMessageReferenceType", DeliveryMessageReferenceType),
            AssignedBy != null ? new XAttribute("AssignedBy", AssignedBy) : null,
            Value
        ).ToString();
    }
}

public abstract class AgencyValueBase
{
    public Agency? Agency = null;
    public string Value = string.Empty;

    public abstract string LocalName { get; }

    public AgencyValueBase() { }

    public AgencyValueBase(XElement root)
    {
        Agency = root.Attribute("Agency") is { Value: var a } ? Enum.Parse<Agency>(a) : Agency;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement(LocalName,
            Agency != null ?new XAttribute("Agency", Agency) : null,
            Value
        ).ToString();
    }
}

public abstract class AssignedByReferenceValueBase
{
    public AssignedBy? AssignedBy;
    public string Value = string.Empty;

    public abstract string LocalName { get; }

    public AssignedByReferenceValueBase() { }

    public AssignedByReferenceValueBase(XElement root)
    {
        AssignedBy = root.Attribute("AssignedBy") is { Value: var ab } ? Enum.Parse<AssignedBy>(ab) : AssignedBy;
        Value = root.Value;
    }

    public override string ToString()
    {
        return new XElement(LocalName,
            AssignedBy != null ? new XAttribute("AssignedBy", AssignedBy) : null,
            Value
        ).ToString();
    }
}