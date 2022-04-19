using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HashTableForStudents;

namespace TimeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict;
            ChainHashTable<string, int> hashTable;
            CreateFrequencyDictionary(out dict,out hashTable);
            RemoveElementsFromDictionary(dict, hashTable);
            Console.ReadKey();
        }

        static void CreateFrequencyDictionary(out Dictionary<string,int> dict,out ChainHashTable<string,int> hashTable)
        {
            dict = new Dictionary<string, int>();
            hashTable = new ChainHashTable<string, int>();
            Regex wordsPatter = new Regex("([А-Я][а-я]*)|([а-я]*)");
            using (StreamReader sr = new StreamReader("WarAndWorld.txt"))
            {
                MatchCollection allWords = wordsPatter.Matches(sr.ReadToEnd());
                Stopwatch sw = new Stopwatch();
                sw.Start();
                foreach (Match word in allWords)
                {
                    if (!dict.ContainsKey(word.Value))
                    {
                        dict.Add(word.Value, 1);
                    }
                    else
                    {
                        dict[word.Value]++;
                    }
                }
                sw.Stop();
                Console.WriteLine($"В словарь слова были добавлены за {sw.ElapsedMilliseconds} мс");

                sw.Restart();
                foreach (Match word in allWords)
                {
                    if (!hashTable.ContainsKey(word.Value))
                    {
                        hashTable.Add(word.Value, 1);
                    }
                    else
                    {
                        dict[word.Value]++;
                    }
                }
                sw.Stop();
                Console.WriteLine($"В хэш слова были добавлены за {sw.ElapsedMilliseconds} мс");
            }
        }

        static void RemoveElementsFromDictionary(Dictionary<string,int> dict, ChainHashTable<string,int> hashTable)
        {
            Regex wordsPatter = new Regex("([А-Я][а-я]*)|([а-я]*)");
            using (StreamReader sr = new StreamReader("WarAndWorld.txt"))
            {
                MatchCollection allWords = wordsPatter.Matches(sr.ReadToEnd());
                Stopwatch sw = new Stopwatch();
                List<string> wordsWithFreqMT27 = new List<string>();

                foreach(Match word in allWords)
                {
                    if (dict[word.Value] > 27)
                    {
                        if (wordsWithFreqMT27.Contains(word.Value) == false)
                            wordsWithFreqMT27.Add(word.Value);
                    }
                }
                Console.WriteLine("Частотный словарь создан");

                sw.Start();
                foreach (var word in wordsWithFreqMT27)
                {
                        dict.Remove(word);   
                }
                sw.Stop();
                Console.WriteLine($"Из словаря слова были удалены за {sw.ElapsedMilliseconds} мс");

                sw.Restart();
                foreach (var word in wordsWithFreqMT27)
                {
                        hashTable.Remove(word);               
                }
                sw.Stop();
                Console.WriteLine($"Из хэша слова были удалены за {sw.ElapsedMilliseconds} мс");
            }
        }
    }
}
