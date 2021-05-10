using System;
using System.Runtime.Serialization;

namespace DispensingWorkMessage
{
 [DataContract]
 public class ValueUnit
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember]
  public double Value;

  [DataMember]
  public string Uom;

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
