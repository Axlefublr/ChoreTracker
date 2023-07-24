namespace ChoreTracker.Repositories;

public interface IRepository
{
	Dictionary<string, DateTime> Parse();
	void Save();
	IRepository EnsureExists();
}