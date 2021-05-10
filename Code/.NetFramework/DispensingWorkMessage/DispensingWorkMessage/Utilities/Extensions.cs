using System.IO;

namespace DispensingWorkMessage.Utilities
{
 public static class Extensions
 {
  /// <summary>
  /// Strips out invalid characters for file names.
  /// </summary>
  public static string StripOutInvalidFileNameCharacters(this string s)
  {
   string invalid = new string(Path.GetInvalidFileNameChars());
   foreach (char c in invalid)
    s = s.Replace(c.ToString(), string.Empty);
   return s;
  }

  /// <summary>
  /// Strips out invalid characters for file paths.
  /// </summary>
  public static string StripOutInvalidFilePathCharacters(this string s)
  {
   string invalid = new string(Path.GetInvalidPathChars());
   foreach (char c in invalid)
    s = s.Replace(c.ToString(), string.Empty);
   return s;
  }
 }
}
