using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NetherRealm
{
    class Program
    {
        public static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var dict = new SortedDictionary<string, Dictionary<long, double>>();
            for (int i = 0; i < input.Length; i++)
            {
                var name = input[i];
                var healthPattern = Regex.Matches(name, @"[^0-9*\/+-.]");
                long health = 0;
                foreach (Match match in healthPattern)
                {
                    var ch = char.Parse(match.Value);
                    health += ch;
                }

                var damagePattern = Regex.Matches(name, @"(-?\d+(\.\d+)?)");
                double damage = 0.0;

               // var list = damagePattern.Cast<Match>().Select(match => match.Value).ToList();

                foreach (var item in damagePattern)
                {
                    string numStr = item.ToString();
                    double num = double.Parse(numStr);
                    damage += num;

                }
                foreach (var ch in name)
                {
                    if (ch == '*')
                    {
                        damage *= 2;
                    }
                    else if(ch == '/')
                    {
                        damage /= 2;
                    }
                }
                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new Dictionary<long, double>());
                    dict[name].Add(health, damage);
                }
            }
            foreach (var demon in dict)
            {
                Console.Write($"{demon.Key} -");
                foreach (var item in demon.Value)
                {
                    Console.Write($" {item.Key} health, {item.Value:f2} damage ");
                }
                Console.WriteLine();
            }
        }
    }
}
