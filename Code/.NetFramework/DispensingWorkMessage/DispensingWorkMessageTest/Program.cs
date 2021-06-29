using DispensingWorkMessage;
using DispensingWorkMessage.WorkOrder;
using DispensingWorkMessage.WorkRecord;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DispensingWorkOrderRecordTest
{
 class Program
 {
  /// <summary>
  /// Reads in example JSON files if they exist. Writes out example JSON files.
  /// </summary>
  static void Main(string[] args)
  {
   string path = AppDomain.CurrentDomain.BaseDirectory;

   foreach (SampleTypes sampleType in Enum.GetValues(typeof(SampleTypes)))
   {
    // Read in the work order; if it exists.
    string inWorkOrderFile = $"inWorkOrder_{sampleType}.json";
    string inWorkOrderPath = Path.Combine(path, inWorkOrderFile);
    Console.WriteLine($"Attempting to read in: '{inWorkOrderFile}'");
    DispensingWorkOrder workOrder = DispensingWorkOrder.DeserializeFromFile(inWorkOrderPath)?[0] ?? CreateStubWorkOrder(sampleType);

    // Write the work order back out.
    string outWorkOrderFile = $"outWorkOrder_{sampleType}.json";
    Console.WriteLine($"Writing: '{outWorkOrderFile}'");
    workOrder.SerializeToFile(Path.Combine(path, outWorkOrderFile));

    // Read in the work record; if it exists.
    string inWorkRecordFile = $"inWorkRecord_{sampleType}.json";
    string inWorkRecordPath = Path.Combine(path, inWorkRecordFile);
    Console.WriteLine();
    Console.WriteLine($"Attempting to read in: '{inWorkRecordFile}'");
    DispensingWorkRecord workRecord = DispensingWorkRecord.DeserializeFromFile(inWorkRecordPath)?[0] ?? CreateStubWorkRecord(sampleType);

    // Write the work record back out.
    string outWorkRecordFile = $"outWorkRecord_{sampleType}.json";
    Console.WriteLine($"Writing: '{outWorkRecordFile}'");
    workRecord.SerializeToFile(Path.Combine(path, outWorkRecordFile));

    Console.WriteLine();
   }

   Console.WriteLine("Done");
   Console.ReadLine();
  }

  /// <summary>
  /// Sample types.
  /// </summary>
  private enum SampleTypes
  {
   Single,
   Blend,
   Vrt,
  }

  /// <summary>
  /// Creates an example work order.
  /// </summary>
  private static DispensingWorkOrder CreateStubWorkOrder(SampleTypes sampleType)
  {
   Console.WriteLine("\tFile not found. Creating stub work order...");
   DispensingWorkOrder workOrder = new DispensingWorkOrder()
   {
    Header = CreateStubHeader(),
    Parties = new Parties()
    {
     ShipTo = CreateStubParty("Adam's Back 40", "00040", true),
     Buyer = CreateStubParty("Adam's Farm", "00041", true),
     DeliverTo = CreateStubParty("Adam's Back 40", "00040", true),
     OtherParty = new List<Party>() { CreateStubParty("Reseller", "09031") },
    },
    WorkOrderType = WorkOrderTypes.Create,
    WorkOrderIdentifier = new Identifier() { Number = (120 + sampleType).ToString().PadLeft(6, '0'), Agency = AgencyTypes.AssignedByOriginator },
    WorkOrderCreationDateTime = DateTime.Now,
    Reference = new List<Reference>()
    {
     new Reference() { ReferenceType = ReferenceTypes.PurchaseOrder, Value = "FF55500123" },
     new Reference() { ReferenceType = ReferenceTypes.Comment, Value = "This is a sample comment!" },
    },
    PhysicalState = PhysicalStates.Liquid,
    RequestedArea = new ValueUnit() { Value = 1000, Uom = "ACR", Agency = AgencyTypes.UN_REC_20 },
    ProductGroup = new List<OrderProductGroup>()
    {
     new OrderProductGroup()
     {
      Identifier = new List<Identifier>() {new Identifier(){ Name = "32%", Number = "00105", Agency = AgencyTypes.AssignedByOriginator } },
      GuaranteedAnalysis = "32-0-0",
      Product = new List<OrderProduct>()
      {
       new OrderProduct()
       {
        Identifier = new List<Identifier>() {new Identifier(){ Name = "32%", Number = "00054", Agency = AgencyTypes.AssignedByOriginator } },
        IsCarrier = true,
        PhysicalState = PhysicalStates.Liquid,
        Density = new ValueUnit(){ Value = 8.34, Uom = "GE", Agency = AgencyTypes.UN_REC_20 },
        RequestedQuantity = new ValueUnit(){ Value = 4375, Uom = "GLL", Agency = AgencyTypes.UN_REC_20 },
       },
      }
     }
    }
   };

   if (sampleType == SampleTypes.Blend || sampleType == SampleTypes.Vrt)
   {
    workOrder.ProductGroup[0].Identifier = new List<Identifier>() { new Identifier() { Name = "28%", Number = "00133", Agency = AgencyTypes.AssignedByOriginator } };
    workOrder.ProductGroup[0].GuaranteedAnalysis = "28-0-0";
    workOrder.ProductGroup[0].Product.Add(new OrderProduct()
    {
     Identifier = new List<Identifier>() { new Identifier() { Name = "Water", Number = "00023", Agency = AgencyTypes.AssignedByOriginator } },
     IsCarrier = true,
     PhysicalState = PhysicalStates.Liquid,
     Density = new ValueUnit() { Value = 8.34, Uom = "GE", Agency = AgencyTypes.UN_REC_20 },
     RequestedQuantity = new ValueUnit() { Value = 625, Uom = "GLL", Agency = AgencyTypes.UN_REC_20 },
    });
   }

   if (sampleType == SampleTypes.Vrt)
   {
    workOrder.ProductGroup.Add(new OrderProductGroup()
    {
     Identifier = new List<Identifier>() { new Identifier() { Name = "Weed Killer 3000", Number = "05573", Agency = AgencyTypes.AssignedByOriginator } },
     GuaranteedAnalysis = "0-0-0 w/ Weed Killer 3000",
     Product = new List<OrderProduct>()
    });
    workOrder.ProductGroup[1].Product.Add(new OrderProduct()
    {
     Identifier = new List<Identifier>() { new Identifier() { Name = "Weed Killer 3000", Number = "00057", Agency = AgencyTypes.AssignedByOriginator } },
     IsCarrier = false,
     PhysicalState = PhysicalStates.Liquid,
     Density = new ValueUnit() { Value = 8.34, Uom = "GE", Agency = AgencyTypes.UN_REC_20 },
     RequestedQuantity = new ValueUnit() { Value = 50, Uom = "GLL", Agency = AgencyTypes.UN_REC_20 },
    });
   }

   return workOrder;
  }

  /// <summary>
  /// Creates an example work record.
  /// </summary>
  private static DispensingWorkRecord CreateStubWorkRecord(SampleTypes sampleType)
  {
   Console.WriteLine("\tFile not found. Creating stub work record...");
   DispensingWorkRecord workRecord = new DispensingWorkRecord()
   {
    Header = CreateStubHeader(),
    Parties = new RecordParties()
    {
     ShipTo = CreateStubParty("Adam's Back 40", "00040", true),
     Driver = CreateStubParty("Bob Bobson", "00217"),
     OtherParty = new List<Party>() { CreateStubParty("Ray's Fertilizer", "03570", true) },
    },
    WorkOrderIdentifier = new Identifier() { Number = "000123", Agency = AgencyTypes.AssignedByOriginator },
    WorkOrderCreationDateTime = DateTime.Now,
    WorkRecordIdentifier = new Identifier() { Number = "9000524", Agency = AgencyTypes.AssignedByOriginator },
    WorkRecordCreationDateTime = DateTime.Now,
    Reference = new List<Reference>()
    {
     new Reference() { ReferenceType = ReferenceTypes.PurchaseOrder, Value = "FF55500123" },
     new Reference() { ReferenceType = ReferenceTypes.Comment, Value = "This is a sample comment!" },
    },
    PhysicalState = PhysicalStates.Liquid,
    RequestedArea = new ValueUnit() { Value = 1000, Uom = "ACR", Agency = AgencyTypes.UN_REC_20 },
    ActualArea = new ValueUnit() { Value = 1005, Uom = "ACR", Agency = AgencyTypes.UN_REC_20 },
    BatchNumber = 1,
    OrderStatus = OrderStatuses.Complete,
    ProductGroup = new List<RecordProductGroup>()
    {
     new RecordProductGroup()
     {
      Identifier = new List<Identifier>() {new Identifier(){ Name = "32%", Number = "00105", Agency = AgencyTypes.AssignedByOriginator } },
      GuaranteedAnalysis = "32-0-0",
      Product = new List<RecordProduct>()
      {
       new RecordProduct()
       {
        Identifier = new List<Identifier>() {new Identifier(){ Name = "32%", Number = "00054", Agency = AgencyTypes.AssignedByOriginator } },
        IsCarrier = true,
        PhysicalState = PhysicalStates.Liquid,
        Density = new ValueUnit(){ Value = 8.34, Uom = "GE", Agency = AgencyTypes.UN_REC_20 },
        RequestedQuantity = new ValueUnit(){ Value = 4375, Uom = "GLL", Agency = AgencyTypes.UN_REC_20 },
        ActualQuantity = new ValueUnit(){ Value = 4405, Uom = "GLL", Agency = AgencyTypes.UN_REC_20 },
       },
      }
     }
    },
    TransportInformation = new List<TransportInformation>()
    {
     new TransportInformation()
     {
      Identifier = new List<Identifier>() {new Identifier(){ Name = "Bob's Truck", Number = "1", Agency = AgencyTypes.AssignedByOriginator } },
      GrossWeight = new ValueUnit(){ Value = 64000, Uom = "LBR", Agency = AgencyTypes.UN_REC_20 },
      TareWeight = new ValueUnit(){ Value = 12000, Uom = "LBR", Agency = AgencyTypes.UN_REC_20 },
     }
    },
   };

   if (sampleType == SampleTypes.Blend || sampleType == SampleTypes.Vrt)
   {
    workRecord.ProductGroup[0].Identifier = new List<Identifier>() { new Identifier() { Name = "28%", Number = "00133", Agency = AgencyTypes.AssignedByOriginator } };
    workRecord.ProductGroup[0].GuaranteedAnalysis = "28-0-0";
    workRecord.ProductGroup[0].Product.Add(new RecordProduct()
    {
     Identifier = new List<Identifier>() { new Identifier() { Name = "Water", Number = "00023", Agency = AgencyTypes.AssignedByOriginator } },
     IsCarrier = true,
     PhysicalState = PhysicalStates.Liquid,
     Density = new ValueUnit() { Value = 8.34, Uom = "GE", Agency = AgencyTypes.UN_REC_20 },
     RequestedQuantity = new ValueUnit() { Value = 625, Uom = "GLL", Agency = AgencyTypes.UN_REC_20 },
     ActualQuantity = new ValueUnit() { Value = 635, Uom = "GLL", Agency = AgencyTypes.UN_REC_20 },
    });
   }

   if (sampleType == SampleTypes.Vrt)
   {
    workRecord.ProductGroup.Add(new RecordProductGroup()
    {
     Identifier = new List<Identifier>() { new Identifier() { Name = "Weed Killer 3000", Number = "05573", Agency = AgencyTypes.AssignedByOriginator } },
     GuaranteedAnalysis = "0-0-0 w/ Weed Killer 3000",
     Product = new List<RecordProduct>()
    });
    workRecord.ProductGroup[1].Product.Add(new RecordProduct()
    {
     Identifier = new List<Identifier>() { new Identifier() { Name = "Weed Killer 3000", Number = "00057", Agency = AgencyTypes.AssignedByOriginator } },
     IsCarrier = false,
     PhysicalState = PhysicalStates.Liquid,
     Density = new ValueUnit() { Value = 8.34, Uom = "GE", Agency = AgencyTypes.UN_REC_20 },
     RequestedQuantity = new ValueUnit() { Value = 50, Uom = "GLL", Agency = AgencyTypes.UN_REC_20 },
     ActualQuantity = new ValueUnit() { Value = 50, Uom = "GLL", Agency = AgencyTypes.UN_REC_20 },
    });
   }

   return workRecord;
  }

  /// <summary>
  /// Creates an example header.
  /// </summary>
  private static Header CreateStubHeader()
  {
   Header header = new Header()
   {
    Sender = CreateStubParty("Organization 1", "00001"),
    Receiver = CreateStubParty("Organization 2", "00002"),
    ThisDocumentIdentifier = new Guid(),
    CreationDateTime = DateTime.Now,
   };
   return header;
  }

  /// <summary>
  /// 
  /// </summary>
  private static Party CreateStubParty(string name, string id, bool addStuff = false)
  {
   Party party = new Party()
   {
    Identifier = new List<Identifier>() { new Identifier() { Name = name, Agency = AgencyTypes.AssignedByOriginator, Number = id } }
   };
   if (addStuff)
   {
    party.Address = new List<Address>()
    {
     new Address()
     {
      AddressType = AddressTypes.Operational,
      AddressLine = new List<string>() { "ATTN: Adam", "123 Some St." },
      CityName = "Nowhere",
      Region = "WA",
      PostalCode = "12345-AB",
      CountryCode = Country.Codes.FirstOrDefault(x => x.Value == "United States").Key,
     }
    };
    party.Contact = new List<Contact>() { new Contact() { Name = "Adam", Phone = "(555) 555-5555", Email = "email@example.com" } };
   }
   return party;
  }
 }
}
