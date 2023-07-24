namespace ChoreTracker.Repositories;

public class JsonRepository : IRepository
{

	private const string EMPTY_JSON_OBJECT = "{}";

	private static readonly string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
	private static readonly string applicationDirectory = Path.Combine(localAppData, "ChoreTracker");
	private static readonly string applicationFilename = "ChoreTracker.json";
	private static readonly string path = Path.Combine(applicationDirectory, applicationFilename);

	public IRepository EnsureExists()
	{
		if (!Directory.Exists(applicationDirectory)) {
			Directory.CreateDirectory(applicationDirectory);
		}
		if (!File.Exists(path)) {
			File.WriteAllText(path, EMPTY_JSON_OBJECT);
		}
		return this;
	}

	public Dictionary<string, DateTime> Parse()
	{
		throw new NotImplementedException();
	}

	public void Save(Dictionary<string, DateTime> data)
	{
		throw new NotImplementedException();
	}
}