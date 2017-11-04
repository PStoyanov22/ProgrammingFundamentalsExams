using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.HornetWingss
{
    class Program
    {
        static void Main(string[] args)
        {
            uint wingFlaps = uint.Parse(Console.ReadLine());
            double distancePerThousandFlaps = double.Parse(Console.ReadLine());
            uint endurance = uint.Parse(Console.ReadLine());

            var restCount = wingFlaps / endurance;

            var distance = (wingFlaps / 1000) * distancePerThousandFlaps;
            var secondForFlaps = wingFlaps / 100;
        //    while (wingFlaps > 0)
        //    {
        //
        //
        //        wingFlaps -= endurance;
        //        restCount
        //    }
            var secondsRest = 5 * restCount;
            var totalSec = secondsRest + secondForFlaps;

            Console.WriteLine($"{distance:f2} m.");
            Console.WriteLine($"{totalSec} s.");
        }
    }
}
