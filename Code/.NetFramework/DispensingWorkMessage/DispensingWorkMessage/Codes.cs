namespace DispensingWorkMessage
{
 public enum AddressTypes
 {
  Billing,
  Mailing,
  Operational,
  Physical,
 }

 public enum AgencyTypes
 {
  GS,
  GLN,
  GTIN,
  AssignedBySender,
  AssignedByReciever,
  AssignedByOriginator,
  AssignedBySeller,
  AssignedByBuyer,
  AssignedByManufacturer,
  AssignedByMixer,
  AGIIS,
  UN_REC_20,
  ANSI,
  Custom,
 }

 public enum CoordinateTypes
 {
  Line,
  MultiLine,
  MultiPoint,
  MultiPolygon,
  Point,
  Polygon,
 }

 public enum DocumentTypes
 {
  ApplicationInstructions,
  BillOfLading,
  CustomDocument,
  Customs,
  Invoice,
  Manifest,
  Order,
  PurchaseOrder,
  Waybill,
 }

 public enum OrderStatuses
 {
  Cancelled,
  Complete,
  InProgress,
 }

 public enum PartyTypes
 {
  Beneficial,
  BillTo,
  Buyer,
  Carrier,
  DeliverTo,
  Dispenser,
  DispensingPoint,
  Driver,
  Consignee,
  ConsigneePoint,
  Farm,
  Field,
  Grower,
  Other,
  Payer,
  Seller,
  ShipTo,
  ShipToPoint,
  ThirdParty,
 }

 public enum PhysicalStates
 {
  Dry,
  Liquid,
 }

 public enum ReferenceTypes
 {
  ApplicationInstructions,
  BillingInstructions,
  BillOfLading,
  Crop,
  Customs,
  Comment,
  Farm,
  Field,
  Invoice,
  Manifest,
  Order,
  PlatCounty,
  PlatTownShip,
  PlatSection,
  PriorCrop,
  PurchaseOrder,
  Release,
  SalesOrder,
  Transaction,
  Waybill,

  NurseTruck,
  ApplicationVehicle,
  ApplicationMethod,
  ApplicatorName,
  CertificationNumber,
  CertificationDate,
  PesticideLicense,
  PesticideLicenseDate,
  PlantFoodPerAcre,
  TransferHeader,
 }

 public enum WorkOrderTypes
 {
  Create,
  Update,
  Cancel,
  Hold,
 }

 public enum CommentTypes
 {
  BolComment,
  MixingInstructions,
  ApplicatorNotes,
 }
}
