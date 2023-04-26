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

    public void Add(string chore) => jsonObj.Add(chore, new JsonArray());

    public string Read()
    {
        JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };
        return jsonObj.ToJsonString(jsonSerializerOptions);
    }


    private JsonObject Parse() => (JsonObject)JsonNode.Parse(File.ReadAllText(jsonPath))!;

    private void MakeSureExists()
    {
        // if (!File.Exists(jsonPath))
        // {
        File.WriteAllText(jsonPath, "{}");
        // }
    }
}