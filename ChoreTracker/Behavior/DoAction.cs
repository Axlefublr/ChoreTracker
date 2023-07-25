using ChoreTracker.Repositories;
using ChoreTracker.Verbs;

namespace ChoreTracker.Behavior;

public static class DoAction {
	public static int Run(this DoVerb options, IChoresRepository repository) {
		return repository.Do(options.Chores);
	}
}