using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DispensingWorkMessage
{
 [DataContract]
 public class TransportInformation
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember]
  public List<Identifier> Identifier;

  [DataMember]
  public ValueUnit GrossWeight;

  [DataMember]
  public ValueUnit TareWeight;

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
