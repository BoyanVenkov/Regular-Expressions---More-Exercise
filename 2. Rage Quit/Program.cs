using System.Text;
using System.Text.RegularExpressions;

string input = Console.ReadLine();

StringBuilder result = new StringBuilder();
HashSet<char> uniqueSymbols = new HashSet<char>();

MatchCollection matches = Regex.Matches(input, @"([^\d]+)(\d+)");

foreach (Match match in matches)
{
    string text = match.Groups[1].Value.ToUpper();
    int count = int.Parse(match.Groups[2].Value);

    for (int i = 0; i < count; i++)
    {
        result.Append(text);
    }
}

foreach (char ch in result.ToString())
{
    uniqueSymbols.Add(ch);
}

Console.WriteLine($"Unique symbols used: {uniqueSymbols.Count}");
Console.WriteLine(result.ToString());