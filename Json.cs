using System;
using System.Text.Json;

static internal class Json
{
    // json at exe directory
    static public void WriteJsonAtExe<T>(T content, string fileName) => WriteAtExe(JsonSerializer.Serialize<T>(content), fileName);
    static private void WriteAtExe(string content, string fileName) => File.WriteAllText($"{AppDomain.CurrentDomain.BaseDirectory}{fileName}.json", content);

    static public bool ReadJsonAtExe<T>(ref T? myObject, string fileName)
    {
        FileInfo _fileName = new($"{AppDomain.CurrentDomain.BaseDirectory}{fileName}.json");
        if (_fileName.Exists)
        {
            myObject = JsonSerializer.Deserialize<T>(ReadAtExe(fileName));
        }
        return _fileName.Exists;
    }

    static private string ReadAtExe(string fileName) => File.ReadAllText($"{System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}/{fileName}.json");

    // json at specific path
    static public void WriteJsonAtPath<T>(T content, string path) => WriteAtPath(JsonSerializer.Serialize<T>(content), path);
    static private void WriteAtPath(string content, string path) => File.WriteAllText($"{path}.json", content);

    static public bool ReadJsonAtPath<T>(ref T myObject, string path)
    {
        FileInfo _path = new FileInfo($"{path}.json");
        if (_path.Exists)
        {
            myObject = JsonSerializer.Deserialize<T>(ReadAtPath(path));
        }
        return _path.Exists;
    }

    static private string ReadAtPath(string path) => File.ReadAllText($"{path}.json");
}
