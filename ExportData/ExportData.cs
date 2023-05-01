using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Formatting = System.Xml.Formatting;

namespace ExportData;

public static class ExportData<T> where T : class
{
  public static void saveData(string path, FileFormats formats, List<T> data)
  {
    if (string.IsNullOrEmpty(path))
    {
      throw new Exception("File path not informed.");
    }

    if (formats != FileFormats.Xml)
    {
      if (formats != FileFormats.Json)
      {
        throw new Exception("Wanted file format not found.");
      }
    }

    ExportDatas(path, formats, data);
  }

  private static void ExportDatas(string path, FileFormats formats, List<T> data)
  {
    if (formats == FileFormats.Xml)
    {
      var serializer = new XmlSerializer(typeof(List<T>));

      try
      {
        var fileStream = new FileStream($"{path}\\data.xml", FileMode.Create);
        using var streamWriter = new StreamWriter(fileStream);
        serializer.Serialize(streamWriter, data);

        Console.WriteLine($"File saved in the {path}");
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    if (formats == FileFormats.Json)
    {
      var json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);

      try
      {
        var fileStream = new FileStream($"{path}\\data.json", FileMode.Create);
        using var streamWriter = new StreamWriter(fileStream);
        streamWriter.WriteLine(json);

        Console.WriteLine($"File saved in the {path}");
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }

  public enum FileFormats
  {
    Xml = 1,
    Json = 2
  }
}