using System;
using System.Runtime.Serialization;

namespace DispensingWorkMessage
{
 [DataContract]
 public class Identifier
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember(EmitDefaultValue = false)]
  public string Name;

  [DataMember(EmitDefaultValue = false)]
  public string Description;

  [DataMember]
  public string Number;

  [DataMember(EmitDefaultValue = false)]
  public string Id;

  [DataMember(Name = "Agency")]
  public string AgencyString;

  [IgnoreDataMember]
  public AgencyTypes? Agency
  {
   get => Enum.TryParse(AgencyString, out AgencyTypes value) ? value : (AgencyTypes?)null;
   set => AgencyString = value?.ToString();
  }

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
