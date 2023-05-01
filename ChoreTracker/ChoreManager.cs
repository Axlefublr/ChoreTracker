using System.Text.Json;
using System.Text.Json.Nodes;

namespace ChoreTracker;

public class ChoreManager
{

    private readonly string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "chores.json");

    private readonly JsonObject jsonObj;

    public ChoreManager()
    {
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

    public void Add(string chore) => jsonObj.Add(chore, "Never");

    public void RemoveRange(string[] chores)
    {
        foreach (string chore in chores)
        {
            Remove(chore);
        }
    }

    public void Remove(string chore)
    {
        if (jsonObj.ContainsKey(chore))
        {
            jsonObj.Remove(chore);
            return;
        }
        Console.WriteLine("chore \"" + chore + "\" doesn't exist!");
    }

    public void DoRange(string[] chores)
    {
        foreach (string chore in chores)
        {
            Do(chore);
        }
    }

    public void Do(string chore)
    {
        if (jsonObj.ContainsKey(chore))
        {
            jsonObj[chore] = DateTimeString;
            return;
        }
        Console.WriteLine("chore \"" + chore + "\" doesn't exist!");
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