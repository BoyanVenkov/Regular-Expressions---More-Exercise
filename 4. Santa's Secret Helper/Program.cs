using System;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        int key = int.Parse(Console.ReadLine());

        Regex regex = new Regex(@"@(?<name>[A-Za-z]+)[^@\-!:>]*!(?<behavior>[GN])!");

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "end")
                break;

            StringBuilder decrypted = new StringBuilder();

            foreach (char c in input)
            {
                decrypted.Append((char)(c - key));
            }

            string message = decrypted.ToString();

            Match match = regex.Match(message);

            if (match.Success)
            {
                string name = match.Groups["name"].Value;
                string behavior = match.Groups["behavior"].Value;

                if (behavior == "G")
                    Console.WriteLine(name);
            }
        }
    }
}
