using ChoreTracker.Repositories;
using CommandLine;

namespace ChoreTracker.Verbs;

[Verb("list", HelpText = "List specified chores' last done date. Pass nothing to display all.")]
public sealed class ListVerb : Verb
{
	[Value(0)]
	public IEnumerable<string> Chores { get; set; } = Array.Empty<string>();

	public override int Run(IChoresRepository repository)
	{
		repository.List(Chores);
		return 0;
	}
}