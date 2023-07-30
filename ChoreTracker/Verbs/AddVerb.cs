using ChoreTracker.Repositories;
using CommandLine;

namespace ChoreTracker.Verbs;

[Verb("add", HelpText = "Add specified chores to the list.")]
public sealed class AddVerb : Verb
{
	[Value(0, Required = true)]
	public required IEnumerable<string> Chores { get; set; }

	public override int Run(IChoresRepository repository)
	{
		repository.Add(Chores);
		return 0;
	}
}