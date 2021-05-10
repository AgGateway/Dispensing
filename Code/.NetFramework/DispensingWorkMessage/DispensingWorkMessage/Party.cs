using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DispensingWorkMessage
{
 [DataContract]
 public class Party
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember]
  public List<Identifier> Identifier;

  [DataMember(EmitDefaultValue = false, Name = "PartyType")]
  public string PartyTypeString;

  [IgnoreDataMember]
  public PartyTypes? PartyType
  {
   get => Enum.TryParse(PartyTypeString, out PartyTypes value) ? value : (PartyTypes?)null;
   set => PartyTypeString = value?.ToString();
  }

  [DataMember(EmitDefaultValue = false)]
  public List<Address> Address;

  [DataMember(EmitDefaultValue = false)]
  public List<Location> Location;

  [DataMember(EmitDefaultValue = false)]
  public List<Contact> Contact;

  [DataMember(EmitDefaultValue = false)]
  public List<Image> Iamge;

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
