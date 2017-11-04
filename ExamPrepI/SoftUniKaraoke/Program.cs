using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SoftUniKaraoke
{
    public class Program
    {
        static void Main()
        {

            string part = Console.ReadLine();
            List<string> participants = Regex.Split(part, @",\s+").ToList();
            string s = Console.ReadLine();
            List<string> songs = Regex.Split(s, @",\s+").ToList();
            var awardedContestants = new Dictionary<string, List<string>>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "dawn")
                {
                    break;
                }
                var commmandArgs = Regex.Split(command, @",\s+").ToArray();
                var participant = commmandArgs[0];
                var song = commmandArgs[1];
                var award = commmandArgs[2];

                if (participants.Contains(participant) && songs.Contains(song))
                {

                    if (!awardedContestants.ContainsKey(participant))
                    {
                        awardedContestants.Add(participant, new List<string> { award });
                    }
                    else
                    {
                        if (!awardedContestants[participant].Contains(award))
                        {
                            awardedContestants[participant].Add(award);
                        }
                    }
                }
            }

            foreach (var perf in awardedContestants
            .Where(c => c.Value.Count > 0)
            .OrderByDescending(a => a.Value.Count)
            .ThenBy(c => c.Key))
            {
                Console.WriteLine($"{perf.Key}: {perf.Value.Count} awards");
                foreach (var item in perf.Value.ToArray().OrderBy(p => p))
                {
                    Console.WriteLine($"--{item}");
                }
            }

            if (awardedContestants.Count == 0)
            {
                Console.WriteLine("No awards");
            }
        }
    }
}



