using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] parts = input.Split('|');

        string firstPart = parts[0];
        string secondPart = parts[1];
        string thirdPart = parts[2];

        Regex lettersRegex = new Regex(@"([#$%*&])([A-Z]+)\1");
        MatchCollection letterMatches = lettersRegex.Matches(firstPart);

        List<char> letters = new List<char>();

        foreach (Match match in letterMatches)
        {
            foreach (char c in match.Groups[2].Value)
                letters.Add(c);
        }

        Regex asciiRegex = new Regex(@"(\d{2,3}):(\d{2})");
        MatchCollection asciiMatches = asciiRegex.Matches(secondPart);

        Dictionary<char, int> letterLengths = new Dictionary<char, int>();

        foreach (Match match in asciiMatches)
        {
            char letter = (char)int.Parse(match.Groups[1].Value);
            int length = int.Parse(match.Groups[2].Value);

            letterLengths[letter] = length;
        }

        List<string> words = new List<string>(
            thirdPart.Split(' ', StringSplitOptions.RemoveEmptyEntries)
        );

        foreach (char letter in letters)
        {
            if (!letterLengths.ContainsKey(letter))
                continue;

            int requiredLength = letterLengths[letter] + 1;

            for (int i = 0; i < words.Count; i++)
            {
                if (words[i][0] == letter && words[i].Length == requiredLength)
                {
                    Console.WriteLine(words[i]);

                    words.RemoveAt(i);

                    break;
                }
            }
        }
    }
}
