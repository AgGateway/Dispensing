using System.Runtime.Serialization;

namespace DispensingWorkMessage
{
 [DataContract]
 public class Nutrient
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember]
  public string Abbreviation;

  [DataMember(EmitDefaultValue = false)]
  public string NutrientDescription;

  [DataMember]
  public double Percentage;

  [DataMember(EmitDefaultValue = false)]
  public double? MinPercentage;

  [DataMember(EmitDefaultValue = false)]
  public double? MaxPercentage;

  [DataMember(EmitDefaultValue = false)]
  public NutrientSource[] NutrientSources;

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
