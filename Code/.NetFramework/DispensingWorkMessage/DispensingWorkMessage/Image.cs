using DispensingWorkMessage.Utilities;
using System.Runtime.Serialization;
using System.Windows.Media.Imaging;

namespace DispensingWorkMessage
{
 [DataContract]
 public class Image
 {
  #region Serializable Properties
  /////////////////////////////////////////////////////////////////////////////////////////////

  [DataMember]
  public string Descrpition;

  [DataMember(EmitDefaultValue = false)]
  public string Base64Image;

  [DataMember(EmitDefaultValue = false)]
  public string FileName;

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion

  #region Wrapper Members
  /////////////////////////////////////////////////////////////////////////////////////////////

  [IgnoreDataMember]
  public BitmapImage BitmapImage
  {
   get => Base64ImageUtilities.CreateBitmapImageFromBase64String(Base64Image);
   set => Base64Image = Base64ImageUtilities.CreateBase64StringFromBitmapImage(value);
  }

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
