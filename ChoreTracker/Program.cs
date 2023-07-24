using ChoreTracker.Verbs;
using ChoreTracker.Behavior;
using CommandLine;
using ChoreTracker.Repositories;

IRepository repository = new JsonRepository().EnsureExists();

Parser.Default.ParseArguments<
	DoVerb,
	AddVerb,
	ListVerb,
	RemoveVerb
>(args)
.MapResult(
	(DoVerb options) => options.Run(),
	(AddVerb options) => options.Run(),
	(ListVerb options) => options.Run(),
	(RemoveVerb options) => options.Run(),
	errors => 1
);