using System;
using System.Collections.Generic;
using System.Linq;


namespace Files
{
    class Files
    {
        public string Root { get; set; }
        public SortedDictionary<string, long> ExtensionAndSize { get; set; }
    }

    class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Files> allFiles = new List<Files>();
            for (int i = 0; i < n; i++)
            {
                string[] file = Console.ReadLine()
               .Split(new char[] { '\\', ';' });

                var fileRoot = file[0];
                var fileExtension = file[file.Length - 2];
                long fileSize = long.Parse(file[file.Length - 1]);
                var dictionary = new SortedDictionary<string, long>() { { fileExtension, fileSize } };

                var files = new Files();
                files.Root = fileRoot;
                files.ExtensionAndSize = dictionary;
                bool doesExist = false;

                foreach (var f in allFiles)
                {
                    if (fileRoot == f.Root)
                    {
                        doesExist = true;
                        if (!f.ExtensionAndSize.ContainsKey(fileExtension))
                        {
                            f.ExtensionAndSize.Add(fileExtension, fileSize);
                        }
                        else
                        {
                            f.ExtensionAndSize[fileExtension] = fileSize;
                        }
                    }
                }

                

                if (doesExist == false)
                {
                    allFiles.Add(files);
                }


            }
            var print = Console.ReadLine().Split(' ');
            var extentionPrint = print[0];
            var rootPrint = print[2];

           
            var counter = 0;

            foreach (var file in allFiles    
                .Where(r => r.Root == rootPrint))                
                
            {
                foreach (var f in file.ExtensionAndSize.Where(x => x.Key.EndsWith(extentionPrint)).OrderByDescending(s => s.Value))
                {
                    Console.WriteLine($"{f.Key} - {f.Value} KB");
                    counter++;
                }
               
            }
            if (counter == 0)
            {
                Console.WriteLine("No");
            }
           
            
        }
    }
}
