using System;
using System.Collections.Generic;
using System.Linq;


namespace PokemonEvolution
{
    class Pokemon
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Index { get; set; }
    }                                        
    class Program
    {
        public static void Main()
        {            
            List<Pokemon> pokemons = new List<Pokemon>();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "wubbalubbadubdub")
                {
                    break;
                }
                
                string[] input = line.Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                if (input.Length == 1)
                {


                    bool hasName = false;

                    foreach (var pok in pokemons.Where(c => c.Name == input[0]))
                    {
                        if (pok.Name == input[0] && hasName == false)
                        {
                            Console.WriteLine($"# {pok.Name}");
                            hasName = true;
                        }
                        if (hasName == true)
                        {
                            Console.WriteLine($"{pok.Type} <-> {pok.Index}");
                        }
                        
                    }
                    
                    continue;
                }
                var name = input[0];
                var evolutionType = input[1];
                var evolutionIndex = int.Parse(input[2]);

                var pokemon = new Pokemon();
                pokemon.Name = name;
                pokemon.Type = evolutionType;
                pokemon.Index = evolutionIndex;               
                pokemons.Add(pokemon);
            
            }

            foreach (var pok in pokemons.Select(n => n.Name).Distinct())
            {
                Console.WriteLine($"# {pok}");
                foreach (var item in pokemons.Where(i => i.Name == pok).OrderByDescending(v => v.Index))
                {
                    Console.WriteLine($"{item.Type} <-> {item.Index}");
                }
            }
        
        }
    }
}
