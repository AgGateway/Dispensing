using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;

namespace DispensingWorkMessage.Utilities
{
 public static class JsonUtilities
 {
  #region Serialization Members
  /////////////////////////////////////////////////////////////////////////////////////////////

  /// <summary>
  /// DateTime format.
  /// </summary>
  public static string DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss.fffzzz";

  /// <summary>
  /// Serializes an object into a JSON file.
  /// </summary>
  public static void SerializeToFile(
   object obj,
   string file)
  {
   SerializeToFile(
    obj,
    Path.GetDirectoryName(file),
    Path.GetFileNameWithoutExtension(file),
    Path.GetExtension(file).Replace(".", string.Empty));
  }

  /// <summary>
  /// Serializes an object into a JSON file.
  /// </summary>
  public static void SerializeToFile(
   object obj,
   string filePath,
   string fileName,
   string fileExtension)
  {
   try
   {
    string json = Serialize(obj);
    if (string.IsNullOrEmpty(json))
     return;

    File.WriteAllText(FileSpaceUtilities.ValidateAndBuildFullFilePath(filePath, fileName, fileExtension), json);
   }
   catch (Exception e)
   {
    //MessageBox.Show(
    // $"Could not write to file '{fileName}'.\n\n{e.Message}",
    // "JSON Write Failure",
    // MessageBoxButton.OK,
    // MessageBoxImage.Error);
   }
  }

  /// <summary>
  /// Deserializes a JSON file into an object of type T.
  /// </summary>
  public static T DeserializeFromFile<T>(string filePathAndName)
  {
   if (File.Exists(filePathAndName))
    try
    { return Deserialize<T>(File.ReadAllText(filePathAndName)); }
    catch (Exception e)
    {
     //MessageBox.Show(
     // $"Could not read to file '{Path.GetFileName(filePathAndName)}'.\n\n{e.Message}",
     // "JSON Write Failure",
     // MessageBoxButton.OK,
     // MessageBoxImage.Error);
    }
   return default;
  }

  /// <summary>
  /// Serializes an object into a JSON string.
  /// </summary>
  public static string Serialize(object obj)
  {
   string json = null;
   DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings
   { DateTimeFormat = new DateTimeFormat(DateTimeFormat) };
   DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType(), settings);
   using (MemoryStream ms = new MemoryStream())
   {
    using (XmlDictionaryWriter writer = JsonReaderWriterFactory.CreateJsonWriter(ms, Encoding.UTF8, true, true))
    {
     serializer.WriteObject(writer, obj);
     writer.Flush();
     json = Encoding.UTF8.GetString(ms.ToArray());
    }
    ms.Close();
   }
   return json;
  }

  /// <summary>
  /// Deserializes a JSON string into an object of type T.
  /// </summary>
  public static T Deserialize<T>(string json)
  {
   T obj = Activator.CreateInstance<T>();
   using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
   {
    DataContractJsonSerializer serializer = new DataContractJsonSerializer(
     obj.GetType(),
     new DataContractJsonSerializerSettings { DateTimeFormat = new DateTimeFormat(DateTimeFormat) });
    obj = (T)serializer.ReadObject(ms);
    ms.Close();
   }
   return obj;
  }

  /////////////////////////////////////////////////////////////////////////////////////////////
  #endregion
 }
}
