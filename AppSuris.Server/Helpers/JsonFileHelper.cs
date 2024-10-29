using Newtonsoft.Json;

public static class JsonFileHelper
{
    public static void EscribirArchivo<T>(string filePath, T objectToWrite, bool indented = false)
    {
        var formatting = indented ? Formatting.Indented : Formatting.None;
        var json = JsonConvert.SerializeObject(objectToWrite, formatting);

        File.WriteAllText(filePath, json);
    }

    public static T LeerArchivo<T>(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"El archivo '{filePath}' no fue encontrado.");
        }

        var json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<T>(json);
    }
}
