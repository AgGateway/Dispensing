using DispensingWorkMessage.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DispensingWorkMessage.WorkOrder
{
 [DataContract]
 public class DispensingWorkOrder : DispensingWorkMessage
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember(Name = "WorkOrderType")]
  public string WorkOrderTypeString;

  [IgnoreDataMember]
  public WorkOrderTypes? WorkOrderType
  {
   get => Enum.TryParse(WorkOrderTypeString, out WorkOrderTypes value) ? value : (WorkOrderTypes?)null;
   set => WorkOrderTypeString = value?.ToString();
  }

  [DataMember(EmitDefaultValue = false)]
  public new Parties Parties
  {
   get => base.Parties;
   set => base.Parties = value;
  }

  [DataMember]
  public new List<OrderProductGroup> ProductGroup
  {
   get => (List<OrderProductGroup>)base.ProductGroup;
   set => base.ProductGroup = value;
  }

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion

  #region Serialization Members
  /////////////////////////////////////////////////////////////////////////////////////////////

  /// <summary>
  /// Serializes this object into a specified JSON file.
  /// </summary>
  public void SerializeToFile(string file)
  { JsonUtilities.SerializeToFile(new List<DispensingWorkOrder>() { this }, file); }

  /// <summary>
  /// Serializes this object into a specified JSON file.
  /// </summary>
  public static void SerializeToFile(List<DispensingWorkOrder> workOrders, string file)
  { JsonUtilities.SerializeToFile(workOrders, file); }

  /// <summary>
  /// Serializes this object into a JSON string.
  /// </summary>
  public string Serialize()
  { return JsonUtilities.Serialize(new List<DispensingWorkOrder>() { this }); }

  /// <summary>
  /// Serializes this object into a JSON string.
  /// </summary>
  public static string Serialize(List<DispensingWorkOrder> workOrders)
  { return JsonUtilities.Serialize(workOrders); }

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion

  #region Deserialization Members
  /////////////////////////////////////////////////////////////////////////////////////////////

  /// <summary>
  /// Deserializes a specified JSON file into an instance of this class.
  /// </summary>
  public static List<DispensingWorkOrder> DeserializeFromFile(string filePathAndName)
  { return JsonUtilities.DeserializeFromFile<List<DispensingWorkOrder>>(filePathAndName); }

  /// <summary>
  /// Deserializes a JSON string into an instance of this class.
  /// </summary>
  public static List<DispensingWorkOrder> Deserialize(string json)
  { return JsonUtilities.Deserialize<List<DispensingWorkOrder>>(json); }

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
