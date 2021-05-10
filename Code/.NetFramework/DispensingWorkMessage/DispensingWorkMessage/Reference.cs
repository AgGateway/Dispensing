using System;
using System.Runtime.Serialization;

namespace DispensingWorkMessage
{
 [DataContract]
 public class Reference
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember(Name = "ReferenceType")]
  public string ReferenceTypeString;

  [IgnoreDataMember]
  public ReferenceTypes? ReferenceType
  {
   get => Enum.TryParse(ReferenceTypeString, out ReferenceTypes value) ? value : (ReferenceTypes?)null;
   set => ReferenceTypeString = value?.ToString();
  }

  [DataMember]
  public string Value;

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
