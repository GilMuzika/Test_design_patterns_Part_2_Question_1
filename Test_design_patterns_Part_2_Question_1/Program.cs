using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Test_design_patterns_Part_2_Question_1
{
    static class Program
    {
        static List<string> _listofWords;
        static IndexableDictionary<string, int> _keepTrace = new IndexableDictionary<string, int>();
        /*
         Dictionary<char, List<int>> _keepTrace:
         Count of the whole dictionaty: Number of uniqe letters;
         Count of each value list: Now many times each uniqe letter appears

         Important:
         1. Count of the whole dictionaty:
         2. The keys of the dictionary must be the same, the order isn't important.
         3. The Counts of the respective values of the keys must match.
          
         */

        static Program()
        {
            _listofWords = new List<string>()
            {
                "mmaammmmaa", "java", "jjava", "vaj", "aavj", "j", "vjaa", "dan", "and", "ddan", "kaka", "aakk", "aaak"
            };
        }

        static void Main(string[] args)
        {
            foreach (string s in _listofWords)
            {

                _keepTrace.Add(s, 0);
                
                for(int i = 0; i < _keepTrace.Count; i++)
                {                    
                    if (!_keepTrace[i].Key.IsSimilar(s))
                    {
                        try
                        {
                            _keepTrace.Add(s, 1);
                            break;
                        }
                        catch(ArgumentException)
                        {

                        }
                    }
                    else
                    {
                        _keepTrace[_keepTrace[i].Key]++;                    
                        break;
                    }
                    
                }
            }

            Console.WriteLine($"The words that repeating themselves (not regarding the order of the letters) and how many times they do that:\n");

            foreach(var s in _keepTrace)
            {
                if(s.Value != 0)
                Console.WriteLine($"\"{s.Key}\": {s.Value} times.");
            }


            
        }






        static bool ContainsAllTheLetters<T>(this IEnumerable<T> inWhat, IEnumerable<T> input)
        {
            string inWhatAsStr = inWhat.ToString();
            foreach (T s in input)
            {
                string sAsStr = s.ToString();
                if (sAsStr.Length != 1) throw new ArgumentException("the argument mus be a collection of one-byte symbols!");
                if (!inWhatAsStr.Contains(sAsStr)) return false;
            }
            return true;
        }

        static Dictionary<char, List<int>> ZipZipIt(this string input)
        {
            Dictionary<char, List<int>> zipZip = new Dictionary<char, List<int>>();
            for (int i = 0; i < input.Length; i++)
            {
                List<int> places = new List<int>();
                places.Add(i);
                try
                {
                    zipZip.Add(input[i], places);
                }
                catch(ArgumentException)
                {
                    zipZip[input[i]].Add(i);
                }
            }

            return zipZip;
        }

        /*static public List<char> ToCharList<T>(this IEnumerable<T> ie)
        {
            List<char> charlist = new List<char>();
            foreach (T s in ie)
            {
                string sAsStr = s.ToString();
                if (sAsStr.Length == 1) charlist.Add(sAsStr[0]);
                else throw new ArgumentException("the argument mus be a collection of one-byte symbols!");
            }
            return charlist;
        }*/

        static public bool IsSimilar<T>(this IEnumerable<T> d1, IEnumerable<T> d2)
        {
            if (d1.Count() != d2.Count()) return false;
            if (!d1.ContainsAllTheLetters(d2)) return false;

            return true;
        }
    }
}
