using System.Text.Json;
using System.Text.Json.Nodes;

namespace ChoreTracker;

public class ChoreManager
{

    private readonly string jsonPath;

    private readonly JsonObject jsonObj;

    public ChoreManager(string jsonPath)
    {
        this.jsonPath = jsonPath;
        MakeSureExists();
        jsonObj = Parse();
    }

    public void AddRange(string[] chores)
    {
        foreach (string chore in chores)
        {
            Add(chore);
        }
    }

    public void Add(string chore) => jsonObj.Add(chore, DateTimeString);

    public void RemoveRange(string[] chores)
    {
        foreach (string chore in chores)
        {
            Remove(chore);
        }
    }

    public void Remove(string chore) => jsonObj.Remove(chore);

    public void Do(string chore)
    {

    }

    public string Read()
    {
        JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };
        return jsonObj.ToJsonString(jsonSerializerOptions);
    }

    public void SaveChanges()
    {
        File.WriteAllText(jsonPath, Read());
    }


    public void List()
    {
        foreach (KeyValuePair<string, JsonNode?> subObj in jsonObj)
        {
            Console.WriteLine(subObj.Key + "\t" + subObj.Value);
        }
    }

    private static JsonNode? DateTimeString => DateTime.Now.ToString("yyyy.MM.dd HH:mm");

    private JsonObject Parse() => (JsonObject)JsonNode.Parse(File.ReadAllText(jsonPath))!;

    private void MakeSureExists()
    {
        if (!File.Exists(jsonPath))
        {
            File.WriteAllText(jsonPath, "{}");
        }
    }

}