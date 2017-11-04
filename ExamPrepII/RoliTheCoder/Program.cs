using System;
using System.Collections.Generic;
using System.Linq;

namespace RoliTheCoder
{
    class Program
    {
        public static void Main()
        {

            var events = new Dictionary<string, string>();
            var members = new SortedDictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Time for Code")
                {
                    break;
                }
                string[] line = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (!line[1].StartsWith("#"))
                {
                    continue;
                }

                string id = line[0];
                string eventN = line[1];
                string eventName = eventN.Remove(0, 1);
                // string eventName= eventN.Remove;
                List<string> participants = line.Skip(2).ToList();
                foreach (var item in participants)
                {
                    if (!item.StartsWith("@"))
                    {
                        continue;
                    }
                }

                if (!events.ContainsKey(id))
                {
                    events.Add(id, eventName);
                    if (!members.ContainsKey(eventName))
                    {
                        members.Add(eventName, new List<string>());
                    }
                    foreach (var member in participants.OrderBy(a => a))
                    {
                        members[eventName].Add(member);
                    }
                }
                else if (events.ContainsKey(id))
                {
                    if (events[id] == eventName)
                    {
                        foreach (var member in participants.OrderBy(a => a))
                        {
                            members[eventName].Add(member);
                        }
                    }
                }
            }
            foreach (var participant in members.Distinct().OrderByDescending(v => v.Value.Count).ThenBy(n => n.Key))
            {
                Console.WriteLine($"{participant.Key} - {participant.Value.Distinct().Count()}");
                foreach (var member in participant.Value.Distinct().OrderBy(a => a))
                {
                    Console.WriteLine(member);
                }
            }
        }
    }
}
