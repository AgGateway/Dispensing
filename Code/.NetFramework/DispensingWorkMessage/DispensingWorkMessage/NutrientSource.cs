using System.Runtime.Serialization;

namespace DispensingWorkMessage
{
 [DataContract]
 public class NutrientSource
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember(EmitDefaultValue = false)]
  public string SourceDescription;

  [DataMember(EmitDefaultValue = false)]
  public double? Percentage;

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
