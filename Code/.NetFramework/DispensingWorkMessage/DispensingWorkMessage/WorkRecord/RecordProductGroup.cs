using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DispensingWorkMessage.WorkRecord
{
 [DataContract]
 public class RecordProductGroup : ProductGroup
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember(EmitDefaultValue = false)]
  public ValueUnit ActualQuantity;

  [DataMember(EmitDefaultValue = false)]
  public new List<RecordContainer> DestinationContainer
  {
   get => (List<RecordContainer>)base.DestinationContainer;
   set => base.DestinationContainer = value;
  }

  [DataMember]
  public new List<RecordProduct> Product
  {
   get => (List<RecordProduct>)base.Product;
   set => base.Product = value;
  }

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
