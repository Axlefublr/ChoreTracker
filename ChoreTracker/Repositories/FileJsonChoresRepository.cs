using System.Text.Json;

namespace ChoreTracker.Repositories;

public class FileJsonChoresRepository : IChoresRepository
{

	private const string EMPTY_JSON_OBJECT = "{}";

	private static readonly string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
	private static readonly string applicationDirectory = Path.Combine(localAppData, "ChoreTracker");
	private static readonly string applicationFilename = "ChoreTracker.json";
	private static readonly string path = Path.Combine(applicationDirectory, applicationFilename);

	private Dictionary<string, DateTime>? data;

	public FileJsonChoresRepository()
	{
		EnsureExists();
		data = Parse();
	}

	public void EnsureExists()
	{
		if (!Directory.Exists(applicationDirectory))
		{
			Directory.CreateDirectory(applicationDirectory);
		}
		if (!File.Exists(path))
		{
			File.WriteAllText(path, EMPTY_JSON_OBJECT);
		}
	}

	public void Save() => File.WriteAllText(path, JsonSerializer.Serialize(data));

	private static Dictionary<string, DateTime>? Parse()
	{
		return JsonSerializer.Deserialize<Dictionary<string, DateTime>>(JsonString);
	}

	private static string JsonString => File.ReadAllText(path);

}