using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DispensingWorkMessage
{
 [DataContract]
 public class Parties
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember(EmitDefaultValue = false)]
  public Party Seller;

  [DataMember(EmitDefaultValue = false)]
  public Party Buyer;

  [DataMember(EmitDefaultValue = false)]
  public Party ShipTo;

  [DataMember(EmitDefaultValue = false)]
  public Party DeliverTo;

  [DataMember(EmitDefaultValue = false)]
  public List<Party> OtherParty;

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
