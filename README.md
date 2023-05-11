# Chore Tracker

Track your chores! What did you expect!

## Storage

Your chores and their states are stored in a json file locally, at this path:

```
./ChoreTracker/bin/Debug/net7.0/chores.json
```

You don't need to interact with the file yourself, but thought it might be useful to know

## Interaction

There are a couple of commands you can use to interact with this json file

### list

```shell
ChoreTracker.exe list
```

Lists all of your chores, along with the date you last did them in

The dates are stored as absolute ones in the json file (`2023.05.01`)

But when you use list, it shows those days relatively (`10 days ago`)

Here's how my list looks, as an example:

```
vacuum           - 8 days ago
bottle           - 10 days ago
keyboard         - Never
dust             - 4 days ago
filter           - 10 days ago
bed-sheets       - 1 days ago
cloths           - 6 days ago
wash-filter      - 10 days ago
guest-bed-sheets - 7 days ago
glasses          - Never
towels           - 1 days ago
windows          - 7 days ago
floor            - Never
mirror           - Never
```

(I'll clean my keyboard eventually, dw about it)

### add

```
ChoreTracker.exe add choreName1 choreName2
```

Add new chores to your list

Your list starts off blank (naturally)

So the first command you'll do is `add`

Once you add a chore, its timestamp will be `"Never"` until you `do` it

You can specify as many new chores at a time as you want, because every argument you pass after `add` is considered

If you want to create a chore with a space in its name, specify it in quotes

### remove

```
ChoreTracker.exe remove choreName1 choreName2
```

Remove chores from your list

Similarly to `add`, you can specify multiple chores to remove in one command

### do

```
ChoreTracker.exe do choreName1 choreName2
```

Do your chores!

Before your first `do` of a chore, its datetime value will be `"Never"`

When you `do` a chore, that value gets changed to today's date

Once again, you can specify multiple at a time

### literally anything else

```
ChoreTracker.exe --help
ChoreTracker.exe -h
ChoreTracker.exe asdf
ChoreTracker.exe please help me 😭
```

(yes, literally anything else)

Displays this help message:

```
list                         - List all your added chores with the last time you did them.
                             - Chores that you haven't done yet will display "Never" in them
add choreName1 choreName2    - Add new chores to your list
remove choreName1 choreName2 - Remove chores from your list
do choreName1 choreName2     - Do chores, setting the current time as their value
literally anything else      - Display this help message
```

## Installation

I haven't figured out how github releases work yet, so you'll have to compile the project yourself

Install [the dotnet 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

Then go to the project directory

```
cd /idk-where-you-installed-it/ChoreTracker/ChoreTracker
```

And run this command to compile the project:

```
dotnet build
```

Once you do, the exe is ready for you to use.

```
/idk-where-you-installed-it/ChoreTracker/ChoreTracker/bin/Debug/net7.0/ChoreTracker.exe list
```

I do realize that this is an annoyingly long path to the execuatable though, so I recommend either:

1. Adding this directory to the [$PATH](https://youtu.be/6M4qMcMKcWk)

```
/idk-where-you-installed-it/ChoreTracker/ChoreTracker/bin/Debug/net7.0
```

2. Making a [symlink](https://youtu.be/_pW0sDmKczs) to the exe in a directory that's already in your path

The benefit of this solution is that you don't add the other files in the `net7.0` directory to your path as well, as you don't actually need to call anything other than the exe

Putting the runtime config and the actual json file in your $PATH isn't useful, and is annoying if anything else

## OS Support

This should in theory be crossplatform

The way I personally use this: compiled with a dotnet sdk installed on windows, the project is stored on windows as well, with a windows symlink in a windows $PATH, but I call the exe through wsl, so on my linux (Ubuntu) system

Create an issue if this is not the case.

Ideally a pull request though, because more likely than not idk how to fix it ahahhahahah