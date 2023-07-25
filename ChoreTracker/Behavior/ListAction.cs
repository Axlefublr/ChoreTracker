using ChoreTracker.Repositories;
using ChoreTracker.Verbs;

namespace ChoreTracker.Behavior;

public static class ListAction {
	public static int Run(this ListVerb options, IChoresRepository repository) {
		repository.List(options.Chores);
		return 0;
	}
}