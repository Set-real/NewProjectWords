using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"C:\Users\maest\Downloads\Text1.txt");

            var noPunctualitenText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            char[] delitThere = { ' ', '\r', '\t' };

            var words = noPunctualitenText.Split(delitThere, StringSplitOptions.RemoveEmptyEntries);
            var RepeetedWords = new Dictionary<string, int>();

            foreach (var word in words)
            {
                bool condition = RepeetedWords.ContainsKey(word);

                int count;

                if (condition is true)
                {
                    RepeetedWords.TryGetValue(word, out count);
                    RepeetedWords.Remove(word);
                    RepeetedWords.Add(word, count+1);
                }
                else
                {
                    RepeetedWords.Add(word, 1);
                }
            }

            int resalt = 0;

            foreach (KeyValuePair<string, int> word in RepeetedWords.OrderByDescending(key => key.Value))
            {
                if (resalt < 10)
                {
                    Console.WriteLine($"Слово: {word.Key}, число упоминаний: {word.Value}");
                    resalt++;
                }
            }

            Console.ReadLine();
        }
    }
}
