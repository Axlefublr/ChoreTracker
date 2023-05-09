using System.Globalization;

namespace ChoreTracker;

public static class StringExtensions
{
    public static string AlignByFirstSpace(string text)
    {
        string[] lines = text.Split(Environment.NewLine);
        int maxSpaceIndex = 0;

        // Find max space index
        foreach (string line in lines)
        {
            int spaceIndex = line.IndexOf(' ');
            if (spaceIndex >= 0 && spaceIndex > maxSpaceIndex)
            {
                maxSpaceIndex = spaceIndex;
            }
        }

        // Align lines by padding spaces before the first space
        for (int i = 0; i < lines.Length; i++)
        {
            int spaceIndex = lines[i].IndexOf(' ');
            if (spaceIndex >= 0 && spaceIndex < maxSpaceIndex)
            {
                int padding = maxSpaceIndex - spaceIndex;
                lines[i] = lines[i].Insert(spaceIndex, new string(' ', padding));
            }
        }

        return string.Join(Environment.NewLine, lines);
    }

    public static string GetDaysDifference(string date)
    {
        bool success = DateTime.TryParseExact(date!, "yyyy.MM.dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);
        if (!success)
        {
            throw new ArgumentException("Invalid date format. Use 'yyyy.MM.dd' or 'Never'");
        }
        TimeSpan difference = parsedDate - DateTime.Now;
        int daysDifference = Math.Abs((int)difference.TotalDays);
        return daysDifference.ToString();
    }

}