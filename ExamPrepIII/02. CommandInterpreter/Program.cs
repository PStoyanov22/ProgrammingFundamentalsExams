using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace _02.CommandInterpreter
{
    class Program
    {
        public static void Main()
        {
            List<string> input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandArgs = command.Split(' ');

                if (commandArgs[0] == "reverse")
                {
                    var index = int.Parse(commandArgs[2]);
                    var count = int.Parse(commandArgs[4]);
                    if (input.Count <= (index + count - 1) || count < 0 || index < 0 || index >= input.Count)
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    else
                    {
                        input.Reverse(index, count);
                       
                    }
                }
                else if (commandArgs[0] == "sort")
                {
                    var index = int.Parse(commandArgs[2]);
                    var count = int.Parse(commandArgs[4]);
                    if (input.Count <= (index + count - 1) || count < 0 || index < 0 || index >= input.Count)
                        {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    else
                    {
                        input.Sort(index, count, Comparer<string>.Default);
                        
                    }
                }
                else if (commandArgs[0] == "rollLeft")
                {
                    var count = int.Parse(commandArgs[1]);
                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    else
                    {
                        for (int j = 0; j < count; j++)
                        {
                            input.Add(input[0]);
                            input.RemoveAt(0);

                        }
                    }                    
                   
                }
                else if (commandArgs[0] == "rollRight")
                {
                    var count = int.Parse(commandArgs[1]);
                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    else
                    {
                        for (int j = 0; j < count; j++)
                        {
                            input.Insert(0, input[input.Count - 1]);
                            input.RemoveAt(input.Count - 1);

                        }
                    }
                    
                }
                command = Console.ReadLine();
            }
          

             Console.WriteLine($"[{string.Join(", ", input)}]");
        }
    }
}
