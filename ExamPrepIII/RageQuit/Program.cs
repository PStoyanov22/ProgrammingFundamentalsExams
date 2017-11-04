using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace RageQuit
{
    class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            var pattern = @"(\D+)(\d+)";

            var matches = Regex.Matches(input, pattern);
            StringBuilder sb = new StringBuilder();
          
            foreach (Match match in matches)
            {
               
                var count = int.Parse(match.Groups[2].Value);
                var resultedString = match.Groups[1].Value.ToString().ToUpper();
                for (int i = 0; i < count; i++)
                {
                    sb.Append(resultedString);
                }
                
            }
            var unique = sb.ToString().Distinct().Count();
            
            
            Console.WriteLine($"Unique symbols used: {unique}");
            Console.WriteLine(string.Join("", sb));
        }
    }
}
