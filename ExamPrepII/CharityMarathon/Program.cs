using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityMarathon
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal days = decimal.Parse(Console.ReadLine());
            decimal participants = decimal.Parse(Console.ReadLine());
            decimal laps = decimal.Parse(Console.ReadLine());
            decimal length = decimal.Parse(Console.ReadLine());
            decimal capacity = decimal.Parse(Console.ReadLine());
            decimal money = decimal.Parse(Console.ReadLine());

            decimal totalRunners = days * capacity;
            decimal moneyRaised = 0;

            if (participants <= totalRunners)
            {
                moneyRaised = (participants * laps * length * money) / 1000;
                Console.WriteLine($"Money raised: {moneyRaised:f2}");
            }
            else
            {
                moneyRaised = (totalRunners * laps * length * money) / 1000;
                Console.WriteLine($"Money raised: {moneyRaised:f2}");
            }
        }
    }
}
