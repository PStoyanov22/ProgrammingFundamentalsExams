using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            var power = int.Parse(Console.ReadLine());
            var distance = int.Parse(Console.ReadLine());
            var exhaustion = int.Parse(Console.ReadLine());
            var left = power;
            var count = 0;

            while (true)
            {
                if (power < distance)
                {
                    break;
                }
                power -= distance;
                count++;
                if (left / 2.0 == power && exhaustion != 0)
                {
                    power /= exhaustion;
                }
            }
            Console.WriteLine(power);
            Console.WriteLine(count);
        }
    }
}
