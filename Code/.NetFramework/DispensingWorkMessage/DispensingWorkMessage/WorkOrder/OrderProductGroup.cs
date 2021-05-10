using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DispensingWorkMessage.WorkOrder
{
 [DataContract]
 public class OrderProductGroup : ProductGroup
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember(EmitDefaultValue = false)]
  public new List<Container> DestinationContainer
  {
   get => (List<Container>)base.DestinationContainer;
   set => base.DestinationContainer = value;
  }

  [DataMember]
  public new List<OrderProduct> Product
  {
   get => (List<OrderProduct>)base.Product;
   set => base.Product = value;
  }

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
