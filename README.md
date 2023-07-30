# ChoreTracker

Track your chores! What did you expect!

You ever not wash the floor because you think you did it too recently? No? Only me?

Well now it's a non-issue!

ChoreTracker will let you track the amount of days ago you last did any task, for you to decide whether it's worth the effort to do it again already.

## Usage

Add your first task:

```
ChoreTracker add vacuum
```

It will also be considered done at the time you added it.

```
ChoreTracker add floor 'bed sheets'
```

You can actually add multiple!

All subcommands in ChoreTracker support multiple arguments.

Spaces are also supported as you can see.

Let's say a few days passed.

How many is a few? Good question, let's check:

```
ChoreTracker list floor
```

This command will display how many days ago you did the task "floor".

If you want to view all the tasks, don't specify anything after `list`:

```
ChoreTracker list
```

An example output:

```
bottle           — 10
filter           — 10
wash filter      — 10
vacuum           — 8
guest bed sheets — 7
windows          — 7
cloths           — 6
dust             — 4
bed sheets       — 1
towels           — 1
keyboard         — 0
glasses          — 0
floor            — 0
mirror           — 0
```

Alright now it's time to actually do a task: update its date to the current date.

```
ChoreTracker do floor
```

That will make the task be displayed with a 0 in `list`

And the last thing: removing a task from the list permanently:

```
ChoreTracker remove vacuum
```

If you need a refresher, use either of these:

```
ChoreTracker help
ChoreTracker --help
```

## Storage

Your chores and their date are stored in a json file locally, at this path:

Linux
```
~/.local/share/ChoreTracker/ChoreTracker.json
```

Windows
```
idk (PRs welcome!)
```

You don't need to (and shouldn't) interact with the file yourself, but thought it might be useful to know

## Installation

You can just grab the binary from the releases page and copy it to some place that's in your $PATH.

## Uninstallation

1. Delete the binary you put somewhere
2. Delete the json file (if you used the program at least once)