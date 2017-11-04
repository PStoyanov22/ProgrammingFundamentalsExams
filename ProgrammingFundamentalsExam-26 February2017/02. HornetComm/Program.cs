using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace _02.HornetComm
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            var privateMessages = new List<string>();
            var broadcast = new List<string>();

            while (line!= "Hornet is Green")
            {

                var messagePattern = @"^(\d+)\<\-\>([A-Za-z0-9]+)$";
                var broadcastPattern = @"^(\D+)\s\<\-\>\s([A-Za-z0-9]+)$";

                var regexMessage = Regex.Match(line, messagePattern);
                var broadcastMessage = Regex.Match(line, broadcastPattern);

                if (regexMessage.Success)
                {
                    var recipientCode = string.Join("", regexMessage.Groups[1].Value.Reverse());
                    var message = regexMessage.Groups[2].ToString();

                    
                    privateMessages.Add($"{recipientCode} -> {message}");
                }
                else if (broadcastMessage.Success)
                {
                    var encryptedFrequency = "";
                    var frequency = broadcastMessage.Groups[2].Value;
                    foreach (var c in frequency)
                    {
                        if (c >= 65 & c <= 90)
                        {
                            encryptedFrequency += (char)(c + 32);
                        }
                        else if (c >= 97 && c<= 122)
                        {
                            encryptedFrequency += (char)(c - 32);
                        }
                        else
                        {
                            encryptedFrequency += c;
                        }
                    }
                    
                    var message = broadcastMessage.Groups[1].Value;

                    broadcast.Add($"{encryptedFrequency} -> {message}");


                }
                line = Console.ReadLine();
                
            }
            Console.WriteLine("Broadcasts:");
            if (broadcast.Count > 0)
            {
                foreach (var item in broadcast)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("None");
            }
            Console.WriteLine("Messages:");
            if (privateMessages.Count > 0)
            {
                foreach (var item in privateMessages)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("None");
            }
        }
    }
}
