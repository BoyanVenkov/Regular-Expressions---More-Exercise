using System.Text.RegularExpressions;

string[] tickets = Console.ReadLine()
            .Split(',')
            .Select(t => t.Trim())
            .ToArray();

char[] symbols = { '@', '#', '$', '^' };

foreach (string ticket in tickets)
{
    if (ticket.Length != 20)
    {
        Console.WriteLine("invalid ticket");
        continue;
    }

    string left = ticket.Substring(0, 10);
    string right = ticket.Substring(10, 10);

    bool isMatch = false;

    foreach (char symbol in symbols)
    {
        string pattern = $@"\{symbol}{{6,10}}";

        Match leftMatch = Regex.Match(left, pattern);
        Match rightMatch = Regex.Match(right, pattern);

        if (leftMatch.Success && rightMatch.Success)
        {
            int matchLength = Math.Min(
                leftMatch.Value.Length,
                rightMatch.Value.Length
            );

            if (matchLength == 10)
            {
                Console.WriteLine(
                    $"ticket \"{ticket}\" - {matchLength}{symbol} Jackpot!"
                );
            }
            else
            {
                Console.WriteLine(
                    $"ticket \"{ticket}\" - {matchLength}{symbol}"
                );
            }

            isMatch = true;
            break;
        }
    }

    if (!isMatch)
    {
        Console.WriteLine($"ticket \"{ticket}\" - no match");
    }
}