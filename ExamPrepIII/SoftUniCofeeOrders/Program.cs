using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace SoftUniCofeeOrders
{
    class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            decimal totalPrice = 0m;
            for (int i = 0; i < n; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                var date = Console.ReadLine();
                DateTime dateFormat = DateTime.ParseExact(date, "d/M/yyyy", null);
                decimal count = decimal.Parse(Console.ReadLine());
                int days = DateTime.DaysInMonth(dateFormat.Year, dateFormat.Month);

                decimal price = (days * pricePerCapsule) * count;
                totalPrice += price;

                Console.WriteLine($"The price for the coffee is: ${price:f2}");
            }
            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}
