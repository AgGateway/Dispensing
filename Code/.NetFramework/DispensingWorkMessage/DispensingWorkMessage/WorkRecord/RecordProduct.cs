using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DispensingWorkMessage.WorkRecord
{
 [DataContract]
 public class RecordProduct : Product
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember]
  public ValueUnit ActualQuantity;

  [DataMember(EmitDefaultValue = false)]
  public new List<RecordContainer> SourceContainer
  {
   get => (List<RecordContainer>)base.SourceContainer;
   set => base.SourceContainer = value;
  }

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
