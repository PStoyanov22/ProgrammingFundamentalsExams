using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace _04.Hornet_Armada
{
    class Legion
    {
        public decimal LastActivity { get; set; }
        public string Name { get; set; }
        public Dictionary<string, decimal> SoldierTypeAndCount { get; set; }

    }


    class Program
    {
        public static void Main()
        {
            var n = decimal.Parse(Console.ReadLine());
            var legions = new List<Legion>();

            for (decimal i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new char[] { ' ', '=', '-', ':', '>' }, StringSplitOptions.RemoveEmptyEntries);

                var legionActivity = decimal.Parse(input[0]);
                var legionName = input[1];
                var soldierType = input[2];
                var soldCount = decimal.Parse(input[3]);
                var TypeAndCount = new Dictionary<string, decimal> { { soldierType, soldCount } };

                Legion legion = new Legion();
                legion.LastActivity = legionActivity;
                legion.Name = legionName;
                legion.SoldierTypeAndCount = TypeAndCount;
                bool legionExist = false;
                foreach (var l in legions)
                {
                    if (l.Name == legionName)
                    {
                        legionExist = true;
                        if (l.SoldierTypeAndCount.ContainsKey(soldierType))
                        {
                            l.SoldierTypeAndCount[soldierType] += soldCount;
                            if (l.LastActivity < legionActivity)
                            {
                                l.LastActivity = legionActivity;
                            }
                            
                        }
                        else
                        {
                            l.SoldierTypeAndCount.Add(soldierType, soldCount);
                            if (l.LastActivity < legionActivity)
                            {
                                l.LastActivity = legionActivity;
                            }
                            
                        }
                    }
                }
                if (legionExist == false)
                {
                    legions.Add(legion);
                }
            }

            string[] printLine = Console.ReadLine().Split('\\');

            if (printLine.Length > 1)
            {
                
                var printActivity = decimal.Parse(printLine[0]);
                var printSoldiers = printLine[1];
                var result = legions.OrderByDescending(x => x.SoldierTypeAndCount.Values);
                foreach (var l in legions
                    .Where(a => a.LastActivity < printActivity)
                    .Where(x => x.SoldierTypeAndCount.ContainsKey(printSoldiers))
                    .OrderByDescending(s => s.SoldierTypeAndCount[printSoldiers]))
                {
                    
                    Console.WriteLine($"{l.Name} -> {l.SoldierTypeAndCount[printSoldiers]}");
                }
                
            }
            foreach (var l in legions
                .Where(t => t.SoldierTypeAndCount.ContainsKey(printLine[0]))
                .OrderByDescending( a => a.LastActivity))
            {
                Console.WriteLine($"{l.LastActivity} : {l.Name}");
            }
        }
    }
}
