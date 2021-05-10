using System.Runtime.Serialization;

namespace DispensingWorkMessage.WorkRecord
{
 [DataContract]
 public class RecordContainer : Container
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember(EmitDefaultValue = false)]
  public ValueUnit ActualQuantity;

  [DataMember(EmitDefaultValue = false)]
  public Identifier LotIdentifier;

  [DataMember(EmitDefaultValue = false)]
  public bool? IsEmpty;

  [DataMember(EmitDefaultValue = false)]
  public bool? IsClean;

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
