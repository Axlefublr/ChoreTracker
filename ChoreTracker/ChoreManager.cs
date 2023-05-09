using System.Globalization;
using System.Text;
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

    public const string HelpMessage =
    """
    list - list all your added chores with the last time you did them
    chores that you haven't done yet will display "Never" in them
    add choreName1 choreName2 - add new chores to your list
    remove choreName1 choreName2 - remove chores from your list
    do choreName1 choreName2 - do chores, setting the current time as their value
    literally anything else - display this help message
    """;

    public static void Help()
    {
        Console.WriteLine(HelpMessage);
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


    public string GetListString()
    {
        StringBuilder sb = new();
        string dateString;
        foreach (KeyValuePair<string, JsonNode?> subObj in jsonObj)
        {
            if ((string)subObj.Value! == "Never")
            {
                dateString = "Never";
            }
            else
            {
                dateString = GetDaysDifference(subObj.Value!) + " days ago";
            }
            sb.AppendLine(subObj.Key + " - " + dateString);
        }
        return sb.ToString();
    }

    private static string GetDaysDifference(JsonNode date)
    {
        bool success = DateTime.TryParseExact((string)date!, "yyyy.MM.dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);
        if (!success)
        {
            throw new ArgumentException("Invalid date format. Use 'yyyy.MM.dd' or 'Never'");
        }
        TimeSpan difference = parsedDate - DateTime.Now;
        int daysDifference = Math.Abs((int)difference.TotalDays);
        return daysDifference.ToString();
    }

    public void List()
    {
        Console.WriteLine(GetListString());
    }

    private static JsonNode? DateTimeString => DateTime.Now.ToString("yyyy.MM.dd");

    private JsonObject Parse() => (JsonObject)JsonNode.Parse(File.ReadAllText(jsonPath))!;

    private void MakeSureExists()
    {
        if (!File.Exists(jsonPath))
        {
            File.WriteAllText(jsonPath, "{}");
        }
    }

}
