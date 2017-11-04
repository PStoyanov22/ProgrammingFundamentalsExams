using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EnduranceRally
{
    class Program
    {
        public static void Main()
        {
            string[] participants = Console.ReadLine().Split(' ');
            double[] zones = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();
            int[] checkpoints = Console.ReadLine()
               .Split(' ')
               .Select(int.Parse)
               .ToArray();
            
            for (int i = 0; i < participants.Length; i++)
            {
                var name = participants[i].ToCharArray();
                double fuel = name[0];
                bool hasFinished = true;
                for (int z = 0; z < zones.Length; z++)
                {
                    bool isCheckpoint = false;
                    
                    for (int c = 0; c < checkpoints.Length; c++)
                    {
                        if (checkpoints[c] == z)
                        {
                            fuel  += zones[z];
                            isCheckpoint = true;
                        }                        
                    }
                    if (isCheckpoint == false)
                    {
                        fuel -= zones[z];
                    }
                    if (fuel <= 0 )
                    {
                        Console.WriteLine($"{participants[i]} - reached {z}");
                        hasFinished = false;
                        break;
                    }
                }
                if (hasFinished == true)
                {
                    Console.WriteLine($"{participants[i]} - fuel left {fuel:f2}");
                }
            }
        }
    }
}
