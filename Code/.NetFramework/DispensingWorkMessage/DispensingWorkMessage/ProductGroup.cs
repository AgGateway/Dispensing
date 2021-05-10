using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DispensingWorkMessage
{
 [DataContract]
 public class ProductGroup
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember(EmitDefaultValue = false)]
  public List<Identifier> Identifier;

  [DataMember(EmitDefaultValue = false)]
  public string Formulation;

  [DataMember(EmitDefaultValue = false)]
  public string GuaranteedAnalysis;

  [DataMember(EmitDefaultValue = false)]
  public List<GuaranteedAnalysisDetail> GuaranteedAnalysisDetail;

  [DataMember(EmitDefaultValue = false)]
  public string Version;

  [DataMember(EmitDefaultValue = false)]
  public string WeighupType;

  [DataMember(EmitDefaultValue = false)]
  public bool? UpdateFormulaDefinition;

  [DataMember(EmitDefaultValue = false)]
  public ValueUnit Density;

  [IgnoreDataMember]
  public IEnumerable DestinationContainer;

  [IgnoreDataMember]
  public IEnumerable Product;

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
