using DispensingWorkMessage.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DispensingWorkMessage.WorkRecord
{
 [DataContract]
 public class DispensingWorkRecord : DispensingWorkMessage
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember]
  public Identifier WorkRecordIdentifier;

  [DataMember]
  public DateTime WorkRecordCreationDateTime;

  [DataMember(EmitDefaultValue = false)]
  public int? BatchNumber;

  [DataMember(EmitDefaultValue = false)]
  public ValueUnit ActualArea;

  [DataMember(EmitDefaultValue = false)]
  public List<Location> ActualLocation;

  [DataMember(EmitDefaultValue = false, Name = "OrderStatus")]
  public string OrderStatusString;

  [IgnoreDataMember]
  public OrderStatuses? OrderStatus
  {
   get => Enum.TryParse(OrderStatusString, out OrderStatuses value) ? value : (OrderStatuses?)null;
   set => OrderStatusString = value?.ToString();
  }

  [DataMember(EmitDefaultValue = false)]
  public new RecordParties Parties
  {
   get => (RecordParties)base.Parties;
   set => base.Parties = value;
  }

  [DataMember]
  public new List<RecordProductGroup> ProductGroup
  {
   get => (List<RecordProductGroup>)base.ProductGroup;
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
  { JsonUtilities.SerializeToFile(new List<DispensingWorkRecord>() { this }, file); }

  /// <summary>
  /// Serializes this object into a specified JSON file.
  /// </summary>
  public static void SerializeToFile(List<DispensingWorkRecord> workRecords, string file)
  { JsonUtilities.SerializeToFile(workRecords, file); }

  /// <summary>
  /// Serializes this object into a JSON string.
  /// </summary>
  public string Serialize()
  { return JsonUtilities.Serialize(new List<DispensingWorkRecord>() { this }); }

  /// <summary>
  /// Serializes this object into a JSON string.
  /// </summary>
  public static string Serialize(List<DispensingWorkRecord> workRecords)
  { return JsonUtilities.Serialize(workRecords); }

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion

  #region Deserialization Members
  /////////////////////////////////////////////////////////////////////////////////////////////

  /// <summary>
  /// Deserializes a specified JSON file into an instance of this class.
  /// </summary>
  public static List<DispensingWorkRecord> DeserializeFromFile(string filePathAndName)
  { return JsonUtilities.DeserializeFromFile<List<DispensingWorkRecord>>(filePathAndName); }

  /// <summary>
  /// Deserializes a JSON string into an instance of this class.
  /// </summary>
  public static List<DispensingWorkRecord> Deserialize(string json)
  { return JsonUtilities.Deserialize<List<DispensingWorkRecord>>(json); }

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
