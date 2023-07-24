using CommandLine;

namespace ChoreTracker.Verbs;

[Verb("remove", HelpText = "Remove specified chores from the list.")]
public class RemoveVerb {
	[Value(0, Required = true)]
	public required IEnumerable<string> Chores { get; set; }
}