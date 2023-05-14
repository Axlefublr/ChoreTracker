using System.Text;

namespace ChoreTracker;

internal class Program
{

	private static readonly ChoreManager cm = new();

	private static void Main(string[] args)
	{
		Console.OutputEncoding = Encoding.Unicode;
		Console.InputEncoding = Encoding.Unicode;

		string[]? arguments = ValidateArguments(args);
		if (arguments is null)
		{
			return;
		}

		DoAction(arguments);

		cm.SaveChanges();
	}

	private static string[]? ValidateArguments(string[] arguments)
	{

		if (arguments.Length != 0)
		{
			return arguments;
		}

		Console.Write("Waiting for input: ");
		string? input = Console.ReadLine();
		if (string.IsNullOrEmpty(input))
		{
			return null;
		}

		return input.Split(' ');
	}

	private static void DoAction(string[] arguments)
	{

		string command = arguments[0].ToLower();
		string[] options = arguments[1..];

		switch (command)
		{

			case "add":
				cm.AddRange(options);
				break;
			case "remove":
				cm.RemoveRange(options);
				break;
			case "do":
				cm.DoRange(options);
				break;
			case "list":
				cm.List();
				break;
			case "view":
				cm.ViewRange(options);
				break;
			default:
				ChoreManager.Help();
				break;

		}
	}
}