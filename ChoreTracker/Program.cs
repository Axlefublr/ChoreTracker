using ChoreTracker.Verbs;
using CommandLine;
using ChoreTracker.Repositories;

IChoresRepository repository = new FileJsonChoresRepository();

var result = Parser.Default.ParseArguments<
	DoVerb,
	AddVerb,
	ListVerb,
	RemoveVerb
>(args)
.MapResult(
	(Verb options) => options.Run(repository),
	errors => 1
);

repository.Save();

return result;