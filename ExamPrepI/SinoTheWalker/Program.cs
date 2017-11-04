using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SinoTheWalker
{
    class Program
    {
        static void Main(string[] args)
        {
            string time = Console.ReadLine();
            ulong steps = ulong.Parse(Console.ReadLine()) % 86400;
            ulong timeForStep = ulong.Parse(Console.ReadLine()) % 86400;

            ulong totalSec = steps * timeForStep;

            TimeSpan result = TimeSpan.Parse(time).Add(TimeSpan.FromSeconds(totalSec));


            string timeText = string.Format("{0:D2}:{1:D2}:{2:D2}", result.Hours, result.Minutes, result.Seconds);

            Console.WriteLine($"Time Arrival: {timeText}");

        }
    }

   
}
