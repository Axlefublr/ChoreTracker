namespace ChoreTracker.Repositories;

public interface IChoresRepository
{
	void Save();
	void EnsureExists();
}