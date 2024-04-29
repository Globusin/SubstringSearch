using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringSearchClasses
{
    public class BruteForceAlgorithm: ISubstringSearch
    {
        private static bool EqualityOfWords(string s1, string s2, int startIndex)
        {
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i + startIndex])
                    return false;
            }

            return true;
        }

        public List<int> IndexesOf(string pattern, string text)
        {
            if (pattern.Length > text.Length)
                return new List<int>();

            List<int> result = new List<int>();
            for (int i = 0; i < text.Length - pattern.Length + 1; i++)
            {
                if (EqualityOfWords(pattern, text, i))
                    result.Add(i);
            }

            return result;
        }
    }
}
