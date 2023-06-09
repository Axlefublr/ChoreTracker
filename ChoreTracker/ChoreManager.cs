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
	list - List all your added chores with the last time you did them.
	- Chores that you haven't done yet will display "Never" in them
	add choreName1 choreName2 - Add new chores to your list
	remove choreName1 choreName2 - Remove chores from your list
	do choreName1 choreName2 - Do chores, setting the current time as their value
	literally anything else - Display this help message
	""";

	public static void Help()
	{
		Console.WriteLine(StringExtensions.AlignByFirstChar(HelpMessage, '-'));
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
		foreach (KeyValuePair<string, JsonNode?> subObj in jsonObj)
		{
			AppendChoreString(sb, subObj.Key, (string)subObj.Value!);
		}
		return StringExtensions.AlignByFirstChar(sb.ToString(), '&').Replace('&', '-');
	}

	private void AppendChoreString(StringBuilder sb, string choreName, string date)
	{
		string dateString;
		if (date == "Never")
		{
			dateString = "Never";
		}
		else
		{
			dateString = StringExtensions.GetDaysDifference(date) + " days ago";
		}
		sb.AppendLine(choreName + " & " + dateString);
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

	public void ViewRange(string[] chores)
	{
		StringBuilder sb = new();
		foreach (string chore in chores)
		{
			AppendChoreString(sb, chore, (string)jsonObj[chore]!);
		}
		Console.Write(StringExtensions.AlignByFirstChar(sb.ToString(), ' '));
	}

	public void View(string chore)
	{
		StringBuilder sb = new();
		AppendChoreString(sb, chore, (string)jsonObj[chore]!);
		Console.WriteLine(sb.ToString());
	}

}
