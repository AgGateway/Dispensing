using System.Runtime.Serialization;

namespace DispensingWorkMessage
{
 [DataContract]
 public class Contact
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember]
  public string Name;

  [DataMember(EmitDefaultValue = false)]
  public string Phone;

  [DataMember(EmitDefaultValue = false)]
  public string Email;

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
