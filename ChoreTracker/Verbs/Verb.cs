using ChoreTracker.Repositories;

namespace ChoreTracker.Verbs;

public abstract class Verb {
	public abstract int Run(IChoresRepository repository);
}