using ChoreTracker.Repositories;
using CommandLine;

namespace ChoreTracker.Verbs;

[Verb("do", HelpText = "Do specified chores, updating their date to today.")]
public class DoVerb
{
	[Value(0, Required = true)]
	public required IEnumerable<string> Chores { get; set; }

	public int Run(IChoresRepository repository) {
		return repository.Do(Chores);
	}
}