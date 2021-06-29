using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DispensingWorkMessage
{
 /// <summary>
 /// See GeoJSON: https://tools.ietf.org/html/rfc7946
 /// </summary>
 [DataContract]
 public class Location
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember]
  public List<Coordinates> InclusionCoordinates;

  [DataMember(EmitDefaultValue = false)]
  public List<Coordinates> ExclusionCoordinates;

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
