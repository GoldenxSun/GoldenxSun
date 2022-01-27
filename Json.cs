using System.Text.Json;
using System.IO;

public class Json
{
    // json at exe directory
    public void writeJsonAtExe<T>(T content, string fileName) => writeAtExe(JsonSerializer.Serialize<T>(content), fileName);
    private void writeAtExe(string content, string fileName) => File.WriteAllText($"{System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}/{fileName}.json", content);

    public bool readJsonAtExe<T>(ref T myObject, string fileName) 
    { 
        FileInfo _fileName = new FileInfo($"{System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}/{fileName}.json");
        if (_fileName.Exists) 
        { 
            myObject = JsonSerializer.Deserialize<T>(readAtExe(fileName)); 
        }
        return _fileName.Exists;
    }

    private string readAtExe(string fileName) => File.ReadAllText($"{System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}/{fileName}.json"); 

    // json at specific path
    public void writeJsonAtPath<T>(T content, string path) => writeAtPath(JsonSerializer.Serialize<T>(content), path);
    private void writeAtPath(string content, string path) => File.WriteAllText($"{path}.json", content);

    public bool readJsonAtPath<T>(ref T myObject, string path) 
    { 
        FileInfo _path = new FileInfo($"{path}.json");
        if (_path.Exists) 
        { 
            myObject = JsonSerializer.Deserialize<T>(readAtPath(path)); 
        }
        return _path.Exists;
    }

    private string readAtPath(string path) => File.ReadAllText($"{path}.json"); 
}