namespace ChoreTracker.Repositories;

public interface IRepository
{
	Dictionary<string, DateTime> Parse();
	void Save(Dictionary<string, DateTime> data);
	IRepository EnsureExists();
}