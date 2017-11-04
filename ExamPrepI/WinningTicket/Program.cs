using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace WinningTicket
{
    class Program
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var count = 0;
            var maxCount = 0;
            foreach (var item in input)
            {
                if (item.Length == 20)
                {
                    var pattern = @"([$|#|^|@]{6,10}).*?([$|#|^|@]{6,10})";
                    var match = Regex.Match(item, pattern);
                    bool isMatch = true;
                    var symbol = 'a';
                    if (match.Groups[1].Value.Length == match.Groups[2].Value.Length && match.Groups[1].Value.Length > 5)
                    {

                        for (int i = 0; i < match.Groups[1].Value.Length; i++)
                        {
                            symbol = match.Groups[1].Value[i];
                            if (isMatch == false)
                            {
                                Console.WriteLine($"ticket \"{item}\" - no match");
                                break;
                            }
                            for (int k = 0; k < match.Groups[2].Value.Length; k++)
                            {
                                if (match.Groups[1].Value[i] == match.Groups[1].Value[k])
                                {
                                    count++;
                                    isMatch = true;
                                    break;
                                }
                                else
                                {
                                    isMatch = false;
                                    maxCount = count;
                                    break;
                                }
                            }
                        }
                        if (count <= maxCount)
                        {
                            count = maxCount;
                        }
                        if (isMatch == true)
                        {
                            if (match.Groups[1].Value.Length == 10)
                            {
                                Console.WriteLine($"ticket \"{item}\" - {count}{symbol} Jackpot!");
                            }
                            else if (match.Groups[1].Value.Length < 10)
                            {
                                Console.WriteLine($"ticket \"{item}\" - {count}{symbol}");
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{item}\" - no match");
                    }


                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }

        }
    }
}