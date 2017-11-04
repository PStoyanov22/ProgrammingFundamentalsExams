using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace _03.Hornet_Assault
{
    class Program
    {
        static void Main(string[] args)
        {
            List<decimal> beehives = Console.ReadLine()
                .Split(' ')
                .Select(decimal.Parse)
                .ToList();
            List<decimal> hornets = Console.ReadLine()
                .Split(' ')
                .Select(decimal.Parse)
                .ToList();

            decimal hornetsTotalPower = 0m;
            var beesAlive = new List<decimal>();
            var hornetsAlive = new List<decimal>();
        //  foreach (var beehive in beehives)
        //  {
        //      beesAlive.Add(beehive);
        //  }
         

            for (int i = 0; i < hornets.Count; i++)
            {
                hornetsTotalPower = hornetsTotalPower + hornets[i];
            }


            for (int i = 0; i < beehives.Count; i++)
            {
                if (hornets.Count == 0)
                {
                    break;
                }
                
                else if (hornetsTotalPower > beehives[i])
                {
                    beehives[i] = 0;
                    
                }
                else
                {
                    
                    beehives[i] = beehives[i] - hornetsTotalPower;                 

                    hornetsTotalPower -= hornets[0];
                    hornets.RemoveAt(0);
                    
                }
            }
            foreach (var beehive in beehives.Where(b => b > 0))
            {
                beesAlive.Add(beehive);
            }
            
            if (beesAlive.Count > 0)
            {
                    Console.Write(string.Join(" ", beesAlive));
            }
            else
            {
                    Console.Write(string.Join(" ", hornets));
            }
            Console.WriteLine();
        }
    }
}
