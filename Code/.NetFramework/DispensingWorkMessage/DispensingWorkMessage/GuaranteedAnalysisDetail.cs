using System.Runtime.Serialization;

namespace DispensingWorkMessage
{
 [DataContract]
 public class GuaranteedAnalysisDetail
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember]
  public Nutrient[] Nutrient;

  [DataMember(EmitDefaultValue = false)]
  public string Warning;

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
