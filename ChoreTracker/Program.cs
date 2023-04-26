namespace ChoreTracker;

internal class Program
{

    private static void Main(string[] args)
    {

        string[]? arguments = ValidateArguments(args);
        if (arguments is null)
        {
            return;
        }

        ChoreManager cm = new("chores.json");

        string option = arguments[0].ToLower();
        switch (option)
        {
            case "add":
                cm.Add(arguments[1]);
                break;
            case "remove": break;
            case "do": break;
            case "list": break;
            case "last": break;
            case "--help":
            case "-h":
            case "help":
                // help section appears
                break;
            default:
                Console.WriteLine("No such option!");
                // help section appears
                break;
        }

        Console.WriteLine(cm.Read());

    }

    private static string[]? ValidateArguments(string[] arguments)
    {

        if (arguments.Length != 0)
        {
            return arguments;
        }

        Console.Write("Waiting for input: ");
        string? input = Console.ReadLine();
        if (input is null)
        {
            return null;
        }

        return input.Split(' ');
    }

}