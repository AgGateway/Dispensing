using System;
using System.Runtime.Serialization;

namespace DispensingWorkMessage
{
 [DataContract]
 public class Header
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember]
  public Party Sender;

  [DataMember]
  public Party Receiver;

  [DataMember]
  public Guid ThisDocumentIdentifier;

  [DataMember(EmitDefaultValue = false)]
  public Guid CorrelationIdentifier;

  [DataMember]
  public DateTime CreationDateTime;

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
