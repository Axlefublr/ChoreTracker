using ChoreTracker.Repositories;
using CommandLine;

namespace ChoreTracker.Verbs;

[Verb("remove", HelpText = "Remove specified chores from the list.")]
public sealed class RemoveVerb : Verb
{
	[Value(0, Required = true)]
	public required IEnumerable<string> Chores { get; set; }

	public override int Run(IChoresRepository repository)
	{
		return repository.Remove(Chores);
	}
}