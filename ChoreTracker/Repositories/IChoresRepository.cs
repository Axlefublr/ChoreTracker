namespace ChoreTracker.Repositories;

public interface IChoresRepository
{
	void Save();
	void EnsureExists();
	void Add(IEnumerable<string> chores);
	void List(IEnumerable<string> chores);
	int Remove(IEnumerable<string> chores);
	int Do(IEnumerable<string> chores);
}