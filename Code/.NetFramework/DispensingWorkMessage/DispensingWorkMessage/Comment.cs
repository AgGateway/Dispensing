using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DispensingWorkMessage
{
 [DataContract]
 public class Comment
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember(EmitDefaultValue = false)]
  public List<Identifier> Identifier;

  [DataMember(Name = "CommentType")]
  public string CommentTypeString;

  [IgnoreDataMember]
  public CommentTypes? CommentType
  {
   get => Enum.TryParse(CommentTypeString, out CommentTypes value) ? value : (CommentTypes?)null;
   set => CommentTypeString = value?.ToString();
  }

  [DataMember(Name = "Comment")]
  public string CommentValue;

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
