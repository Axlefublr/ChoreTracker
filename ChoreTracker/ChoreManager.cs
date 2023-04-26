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

    public void Add(string chore) => jsonObj.Add(chore, new JsonArray());

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

    public void List()
    {
        foreach (string chore in ListChores())
        {
            Console.WriteLine(chore);
        }
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


    private List<string> ListChores()
    {
        uint i = 0;
        List<string> chores = new();
        foreach (KeyValuePair<string, JsonNode?> subObj in jsonObj)
        {
            i++;
            var lastDate = subObj.Value ?? "None";
            chores.Add(i + ") " + subObj.Key + " " + lastDate);
        }
        return chores;
    }

    private JsonObject Parse() => (JsonObject)JsonNode.Parse(File.ReadAllText(jsonPath))!;

    private void MakeSureExists()
    {
        if (!File.Exists(jsonPath))
        {
            File.WriteAllText(jsonPath, "{}");
        }
    }

}