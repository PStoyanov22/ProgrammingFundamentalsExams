using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace Regexmon
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var count = 0;
            var matches = Regex.Matches(input, @"([^a-zA-Z-\t\s]+)([a-zA-Z]+-[a-zA-Z]+)*");
           

            foreach (Match match in matches)
            {
                var didimon = match.Groups[1].Value.ToString();
                var bojomon = match.Groups[2].Value.ToString();
                if (match.Groups[1].Value != string.Empty || match.Groups[2].Value != string.Empty)
                {
                    if (count % 2 != 0 && didimon != string.Empty)
                    {
                        if (match.Groups[1].Success)
                        {
                            Console.WriteLine(didimon);
                            count++;
                        }
                    }
                    if (count % 2 == 0 && bojomon != string.Empty)
                    {
                        if (match.Groups[2].Success)
                        {
                            Console.WriteLine(bojomon);
                            count++;
                        }
                    }
                }
               else
               {
                   return;
               }
            }
        }
    }
}
