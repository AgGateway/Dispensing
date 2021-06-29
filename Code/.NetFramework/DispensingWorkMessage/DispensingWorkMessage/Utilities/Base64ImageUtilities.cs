using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace DispensingWorkMessage.Utilities
{
 /// <summary>
 /// Base64ImageUtilities
 /// </summary>
 public static class Base64ImageUtilities
 {
  /// <summary>
  /// Creates a BitmapImage from a base64 image string.
  /// </summary>
  public static BitmapImage CreateBitmapImageFromBase64String(string base64String)
  {
   BitmapImage bitmapImage = null;
   bitmapImage = new BitmapImage();
   bitmapImage.BeginInit();
   using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(base64String)))
   {
    bitmapImage.StreamSource = memoryStream;
    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
    bitmapImage.EndInit();
   }
   return bitmapImage;
  }

  /// <summary>
  /// Creates a base64 image string from a BitmapImage.
  /// </summary>
  public static string CreateBase64StringFromBitmapImage(BitmapImage bitmapImage)
  {
   byte[] bitmapdata = null;
   using (MemoryStream memoryStream = new MemoryStream())
   {
    PngBitmapEncoder encoder = new PngBitmapEncoder();
    encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
    encoder.Save(memoryStream);
    bitmapdata = memoryStream.ToArray();
   }
   return Convert.ToBase64String(bitmapdata);
  }
 }
}
