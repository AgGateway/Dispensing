using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DispensingWorkMessage
{
 [DataContract]
 public class Product
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember]
  public List<Identifier> Identifier;

  [DataMember(EmitDefaultValue = false)]
  public int? MixSequence;

  [DataMember(EmitDefaultValue = false)]
  public bool? IsCarrier;

  [DataMember(EmitDefaultValue = false, Name = "PhysicalState")]
  public string PhysicalStateString;

  [IgnoreDataMember]
  public PhysicalStates? PhysicalState
  {
   get => Enum.TryParse(PhysicalStateString, out PhysicalStates value) ? value : (PhysicalStates?)null;
   set => PhysicalStateString = value?.ToString();
  }

  [DataMember(EmitDefaultValue = false)]
  public ValueUnit Density;

  [DataMember]
  public ValueUnit RequestedQuantity;

  [DataMember(EmitDefaultValue = false)]
  public string Crop;

  [DataMember(EmitDefaultValue = false)]
  public string Dot;

  [DataMember(EmitDefaultValue = false)]
  public string Epa;

  [DataMember(EmitDefaultValue = false)]
  public string Permit;

  [DataMember(EmitDefaultValue = false)]
  public string PreviousCrop;

  [IgnoreDataMember]
  public IEnumerable SourceContainer;

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
