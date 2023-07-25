using ChoreTracker.Repositories;
using ChoreTracker.Verbs;

namespace ChoreTracker.Behavior;

public static class RemoveAction {
	public static int Run(this RemoveVerb options, IChoresRepository repository) {
		return repository.Remove(options.Chores);
	}
}