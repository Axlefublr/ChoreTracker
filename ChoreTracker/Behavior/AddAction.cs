using ChoreTracker.Repositories;
using ChoreTracker.Verbs;

namespace ChoreTracker.Behavior;

public static class AddAction {
	public static int Run(this AddVerb options, IChoresRepository repository) {
		Console.WriteLine(repository);
		return 0;
	}
}