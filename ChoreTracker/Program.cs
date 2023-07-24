using ChoreTracker.Verbs;
using ChoreTracker.Behavior;
using CommandLine;
using ChoreTracker.Repositories;

IChoresRepository repository = new FileJsonChoresRepository();

Parser.Default.ParseArguments<
	DoVerb,
	AddVerb,
	ListVerb,
	RemoveVerb
>(args)
.MapResult(
	(DoVerb options) => options.Run(repository),
	(AddVerb options) => options.Run(repository),
	(ListVerb options) => options.Run(repository),
	(RemoveVerb options) => options.Run(repository),
	errors => 1
);