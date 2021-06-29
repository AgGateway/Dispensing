using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DispensingWorkMessage
{
 [DataContract]
 public class AssociatedDocument
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember]
  public List<Identifier> Identifier;

  [DataMember]
  public string Extension;

  [DataMember(EmitDefaultValue = false)]
  public string File;

  [DataMember(EmitDefaultValue = false)]
  public string FileName;

  [DataMember(Name = "DocumentType")]
  public string DocumentTypeString;

  [IgnoreDataMember]
  public DocumentTypes? DocumentType
  {
   get => Enum.TryParse(DocumentTypeString, out DocumentTypes value) ? value : (DocumentTypes?)null;
   set => DocumentTypeString = value?.ToString();
  }

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
