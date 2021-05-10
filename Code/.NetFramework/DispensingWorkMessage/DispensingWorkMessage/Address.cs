using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DispensingWorkMessage
{
 [DataContract]
 public class Address
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember(EmitDefaultValue = false, Name = "AddressType")]
  public string AddressTypeString;

  [IgnoreDataMember]
  public AddressTypes? AddressType
  {
   get => Enum.TryParse(AddressTypeString, out AddressTypes value) ? value : (AddressTypes?)null;
   set => AddressTypeString = value?.ToString();
  }

  [DataMember(EmitDefaultValue = false)]
  public List<string> AddressLine;

  [DataMember(EmitDefaultValue = false)]
  public string CityName;

  [DataMember(EmitDefaultValue = false)]
  public string Region;

  [DataMember(EmitDefaultValue = false)]
  public string County;

  [DataMember(EmitDefaultValue = false)]
  public string Township;

  [DataMember(EmitDefaultValue = false)]
  public string PostalCode;

  [DataMember(EmitDefaultValue = false)]
  public string CountryCode;

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion

  #region Wrapper Members
  /////////////////////////////////////////////////////////////////////////////////////////////

  [IgnoreDataMember]
  public string CountryName => Country.Codes[CountryCode];

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
