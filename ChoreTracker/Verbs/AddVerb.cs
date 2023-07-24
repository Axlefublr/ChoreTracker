using CommandLine;

namespace ChoreTracker.Verbs;

[Verb("add", HelpText = "Add specified chores to the list.")]
public class AddVerb {
	[Value(0, Required = true)]
	public required IEnumerable<string> Chores { get; set; }
}