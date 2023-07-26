using System.Text;

namespace ChoreTracker;

public class Lister
{

	private readonly Dictionary<string, DateTime> data;
	private readonly int maxLength;

	public Lister(Dictionary<string, DateTime> data)
	{
		this.data = data;
		maxLength = GetHighestLength();
	}

	public void ListAll()
	{
		if (data.Count < 0)
		{
			return;
		}
		StringBuilder sb = new();
		foreach (KeyValuePair<string, DateTime> pair in data)
		{
			int choreNameLength = pair.Key.Length;
			string paddedChore = pair.Key + GenerateSpacePadding(maxLength - choreNameLength);
			sb.AppendLine($"{paddedChore} — {GetRelativeDays(pair.Value)}");
		}
		Console.Write(sb.ToString());
	}

	public void ListSome(IEnumerable<string> selected)
	{
		if (data.Count < 0)
		{
			return;
		}
		StringBuilder sb = new();
		foreach (KeyValuePair<string, DateTime> pair in data)
		{
			if (selected.Contains(pair.Key))
			{
				int choreNameLength = pair.Key.Length;
				string paddedChore = pair.Key + GenerateSpacePadding(maxLength - choreNameLength);
				sb.AppendLine($"{paddedChore} — {GetRelativeDays(pair.Value)}");
			}
		}
		Console.Write(sb.ToString());
	}

	private List<KeyValuePair<string, DateTime>> Sort()
	{
		return data
			.OrderByDescending(pair => pair.Value)
			.ToList();
	}

	private int GetHighestLength()
	{
		if (data.Count > 0)
		{
			return data.Keys.Max(chore => chore.Length);
		}
		else
		{
			return 0;
		}
	}

	private static string GenerateSpacePadding(int amount) => new(' ', amount);

	private static int GetRelativeDays(DateTime date)
	{
		double totalDays = (DateTime.Now - date).TotalDays;
		return (int)Math.Round(totalDays);
	}
}