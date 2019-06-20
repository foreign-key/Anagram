using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram
{
    class Anagram
    {
        static void Main(string[] args)
        {
            Console.Write("Input first string: ");
            var firstStr = Console.ReadLine();

            Console.Write("Input second string: ");
            var secondStr = Console.ReadLine();

            var isAnagram = AnagramChecker(firstStr.Replace(" ", string.Empty), secondStr.Replace(" ", string.Empty));

            Console.Write($"{firstStr} and {secondStr} {(isAnagram ? "are" : "are not")} anagrams");
            Console.Read();
        }

        static bool AnagramChecker(string firstStr, string secondStr)
        {
            if (firstStr.Length != secondStr.Length)
                return false;

            var stringChars = new Dictionary<char, int>();

            foreach(char letter in firstStr.ToCharArray())
            {
                if (stringChars.ContainsKey(letter))
                    stringChars[letter]++;
                else
                    stringChars.Add(letter, 1);
            }

            foreach(char letter in secondStr.ToCharArray())
            {
                if (!stringChars.ContainsKey(letter))
                    return false;

                if (--stringChars[letter] == 0)
                    stringChars.Remove(letter);
            }

            return stringChars.Count == 0;
        }
    }
}
