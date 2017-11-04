using System;
using System.Collections.Generic;
using System.Linq;


namespace PokemonDon_tGo
{
    class Program
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            List<int> removed = new List<int>();
            var removedNumber = 0;
            while (numbers.Count > 0)
            {
                var input = int.Parse(Console.ReadLine());

                if (input >= 0 && input < numbers.Count)
                {
                    removedNumber = numbers[input];
                    numbers.RemoveAt(input);
                    removed.Add(removedNumber);
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] <= removedNumber)
                        {
                            numbers[i] += removedNumber;
                        }
                        else
                        {
                            numbers[i] -= removedNumber;
                        }
                    }
                }
                else if (input < 0)
                {
                    removedNumber = numbers[0];
                    numbers.RemoveAt(0);                    
                    removed.Add(removedNumber);
                    numbers.Insert(0, numbers[numbers.Count - 1]);
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] <= removedNumber)
                        {
                            numbers[i] += removedNumber;
                        }
                        else
                        {
                            numbers[i] -= removedNumber;
                        }
                    }
                }
                else if(input >= numbers.Count)
                {
                    removedNumber = numbers[numbers.Count-1];
                    numbers.RemoveAt(numbers.Count - 1);
                    removed.Add(removedNumber);
                    numbers.Add(numbers[0]);
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] <= removedNumber)
                        {
                            numbers[i] += removedNumber;
                        }
                        else
                        {
                            numbers[i] -= removedNumber;
                        }
                    }
                }
            }
            var sum = 0;
            for (int i = 0; i < removed.Count; i++)
            {
                sum += removed[i];
            }
            Console.WriteLine(sum);
        }
    }
}
