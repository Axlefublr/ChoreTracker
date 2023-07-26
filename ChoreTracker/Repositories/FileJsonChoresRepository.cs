using System.Text.Json;

namespace ChoreTracker.Repositories;

public class FileJsonChoresRepository : IChoresRepository
{

	private const string EMPTY_JSON_OBJECT = "{}";

	private static readonly string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
	private static readonly string applicationDirectory = Path.Combine(localAppData, "ChoreTracker");
	private static readonly string applicationFilename = "ChoreTracker.json";
	private static readonly string path = Path.Combine(applicationDirectory, applicationFilename);

	private readonly Dictionary<string, DateTime> data;

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

	public void Add(IEnumerable<string> chores)
	{
		foreach (string chore in chores)
		{
			data.Add(chore, DateTime.Now);
		}
	}

	public void List(IEnumerable<string> chores)
	{
		if (!chores.Any())
		{
			new Lister(data).ListAll();
		}
		else
		{
			new Lister(data).ListSome(chores);
		}
	}

	public int Remove(IEnumerable<string> chores)
	{
		int missings = 0;
		foreach (string chore in chores)
		{
			try
			{
				data.Remove(chore);
			}
			catch
			{
				Console.Error.WriteLine($"Chore '{chore}' doesn't exist");
				missings++;
			}
		}
		return missings;
	}

	public int Do(IEnumerable<string> chores)
	{
		int missings = 0;
		foreach (string chore in chores)
		{
			try
			{
				data[chore] = DateTime.Now;
			}
			catch
			{
				Console.Error.WriteLine($"Chore '{chore}' doesn't exist");
				missings++;
			}
		}
		return missings;
	}

	private static Dictionary<string, DateTime> Parse()
	{
		return JsonSerializer.Deserialize<Dictionary<string, DateTime>>(JsonString) ?? new Dictionary<string, DateTime>();
	}

	private static string JsonString => File.ReadAllText(path);

}