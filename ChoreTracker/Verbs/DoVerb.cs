using ChoreTracker.Repositories;
using CommandLine;

namespace ChoreTracker.Verbs;

[Verb("do", HelpText = "Do specified chores, updating their date to today.")]
public sealed class DoVerb : Verb
{
	[Value(0, Required = true)]
	public required IEnumerable<string> Chores { get; set; }

	public override int Run(IChoresRepository repository) {
		return repository.Do(Chores);
	}
}