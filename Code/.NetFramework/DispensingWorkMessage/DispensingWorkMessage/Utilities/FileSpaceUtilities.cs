using System.IO;

namespace DispensingWorkMessage.Utilities
{
 public static class FileSpaceUtilities
 {
  /// <summary>
  /// Constructs a full file path.
  /// </summary>
  public static string ValidateAndBuildFullFilePath(string directoryPath, string fileName, string fileExtension)
  {
   if (!Directory.Exists(directoryPath))
    Directory.CreateDirectory(directoryPath);

   fileName = fileName.StripOutInvalidFileNameCharacters();
   if (fileName.Length > 244)
    fileName = fileName.Substring(0, 244);

   string file = Path.Combine(directoryPath, fileName);
   if (file.Length > 255)
    file = file.Substring(0, 255);
   file = file.StripOutInvalidFilePathCharacters();

   return $"{file}.{fileExtension}";
  }
 }
}
