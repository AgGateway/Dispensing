using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DispensingWorkMessage
{
 [DataContract]
 public class Coordinates
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember(Name = "CoordinateType")]
  public string CoordinateTypeString;

  [IgnoreDataMember]
  public CoordinateTypes? CoordinateType
  {
   get => Enum.TryParse(CoordinateTypeString, out CoordinateTypes value) ? value : (CoordinateTypes?)null;
   set => CoordinateTypeString = value?.ToString();
  }

  [DataMember]
  public List<Point> Point;

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
