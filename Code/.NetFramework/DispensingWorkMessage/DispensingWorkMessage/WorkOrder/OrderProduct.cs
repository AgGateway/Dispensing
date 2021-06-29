using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DispensingWorkMessage.WorkOrder
{
 [DataContract]
 public class OrderProduct : Product
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember(EmitDefaultValue = false)]
  public new List<Container> SourceContainer
  {
   get => (List<Container>)base.SourceContainer;
   set => base.SourceContainer = value;
  }

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
