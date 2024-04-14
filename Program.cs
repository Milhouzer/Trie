using System;
using System.Text.RegularExpressions;

namespace Trie
{
    public class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> wordLib = System.IO.File.ReadAllLines(@"Data\WordLib.txt").ToList();

            //The max distance from word, we'll generate all the "brothers" of given word - those words whose distance are within MaxDist from given word.
            //So the bigger MaxDist is, the more "brothers" we will generate based on given words, the longer it takes in overall fuzzy searching.
            const int MaxDist = 1;
            
            Console.WriteLine("----Automaton way----");

            TrieStructure trieStruct = TrieStructure.BuildTrieStructure(wordLib.GetEnumerator());

            Console.WriteLine("User input : ");
            string input = Console.ReadLine();
            
            List<string> res = trieStruct.Autocomplete(input);

            Console.WriteLine("found " + res.Count + " matches : ");
            foreach(string word in res)
            {
                Console.WriteLine(word);
            }
        }
    }
}
