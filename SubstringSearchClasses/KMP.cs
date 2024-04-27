using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringSearchClasses
{
    public class KMPAlgorithm: ISubstringSearch
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

        public int[] MygetPrefixFunction(string s)
        {
            int n = s.Length;
            int[] pi = new int[n];
            pi[0] = 0;
            for (int i = 1; i < n; i++)
            {
                pi[i] = 0;
                int count = 0;
                int maxCount = 0;
                for(int j = i - 1; j > 0; j--)
                {
                    int k = i;
                    if (s[k] == s[j])
                    {
                        while (s[k] == s[j]&&j>=0)
                        {
                            count++;
                            k--;
                            j--;
                        }
                    }
                    if (count>maxCount) maxCount= count;
                }
                pi[i] = maxCount;
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
