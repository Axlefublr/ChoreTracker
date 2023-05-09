using System.Globalization;

namespace ChoreTracker;

public static class StringExtensions
{
    public static string AlignByFirstChar(string text, char alignChr)
    {
        string[] lines = text.Split('\n');
        int maxIndex = 0;

        foreach (string line in lines)
        {
            int charIndex = line.IndexOf(alignChr);
            if (charIndex >= 0 && charIndex > maxIndex)
            {
                maxIndex = charIndex;
            }
        }

        // Align lines by padding spaces before the first space
        for (int i = 0; i < lines.Length; i++)
        {
            int charIndex = lines[i].IndexOf(alignChr);
            if (charIndex >= 0 && charIndex < maxIndex)
            {
                int padding = maxIndex - charIndex;
                lines[i] = lines[i].Insert(charIndex, new string(' ', padding));
            }
        }

        return string.Join('\n', lines);
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