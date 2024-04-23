using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringSearchClasses
{
    public class KMPAlgorithm
    {
        public int[] getPrefixFunction(string s)
        {
            int n = s.Length;
            int[] pi = new int[n];
            for (int i = 1; i < n; ++i)
            {
                int j = pi[i - 1];
                while (j > 0 && s[i] != s[j])
                    j = pi[j - 1];
                if (s[i] == s[j]) ++j;
                pi[i] = j;
            }
            return pi;
        }

        public List<int> IndexesOf(string pattern, string text)
        {
            int[] pref = getPrefixFunction(pattern);
            List<int> indexses = new List<int>();

            for (int i = 0, k = 0; i < text.Length; i++)
            {
                if (pattern[k] == text[i])
                {
                    k++;
                    if (k == pattern.Length)
                    {
                        indexses.Add(i - pattern.Length + 1);
                        k = 0;
                    }
                }
                else
                {
                    if (k > 0)
                    {
                        k = pref[k - 1];
                        i--;
                    }
                }
            }
            return indexses;
        }
    }
}
