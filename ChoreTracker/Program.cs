namespace ChoreTracker;

internal class Program
{
    private static void Main(string[] args)
    {
        string option = args[0].ToLower();
        switch (option)
        {
            case "add": break;
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
    }
}