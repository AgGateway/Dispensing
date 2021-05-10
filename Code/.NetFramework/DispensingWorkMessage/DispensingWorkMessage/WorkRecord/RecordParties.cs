using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DispensingWorkMessage.WorkRecord
{
 [DataContract]
 public class RecordParties : Parties
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember(EmitDefaultValue = false)]
  public List<Party> DispensingPoint;

  [DataMember(EmitDefaultValue = false)]
  public Party Carrier;

  [DataMember(EmitDefaultValue = false)]
  public Party Driver;

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
