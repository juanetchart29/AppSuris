using System.IO;
using System.Text.Json;

public static class JsonFileHelper<T>
{

    public static T LeerArchivo(string filePath)
    {
        if (!File.Exists(filePath)) return default(T);

        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(json) ?? default(T);
    }

    public static void EscribirArchivo(string filePath, T data)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
}
