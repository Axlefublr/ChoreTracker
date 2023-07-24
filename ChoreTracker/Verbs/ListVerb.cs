using CommandLine;

namespace ChoreTracker.Verbs;

[Verb("list", HelpText = "List specified chores' last done date.")]
public class ListVerb {
	[Value(0)]
	public IEnumerable<string> Chores { get; set; } = Array.Empty<string>();
}