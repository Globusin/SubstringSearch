using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringSearchClasses
{
    public class RabinKarpAlgorithm: ISubstringSearch
    {
        int q = 163, n, m, p, t0, h = 1;

        private void PreparationForSearch(string pattern, string text)
        {
            p = pattern[0];
            t0 = text[0];
            for (int i = 1; i < m; i++) // правило Горнера
            {
                p = ((p << 8) + pattern[i]) % q;
                t0 = ((t0 << 8) + text[i]) % q;
                h = (h << 8) % q;
            }

            if (m == 1)
            {
                h = (h << 8) % q;
            }
        }

        private bool EqualityOfWords(string s1, string s2, int startIndex)
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
            List<int> indexes = new List<int>();

            n = text.Length;
            m = pattern.Length;
            h = 1;

            PreparationForSearch(pattern, text);

            int ts = t0;
            for (int s = 0; s <= n - m; s++)
            {
                if (p == ts && EqualityOfWords(pattern, text, s))
                    indexes.Add(s);

                if (s < n - m)
                {
                    ts = (((ts - (text[s] * h)) << 8) + text[s + m]) % q; // Сдвиг поиска в тексте
                    // ( (изнач число) - (первая цифра этого числа) ) умножаем + ( новая цифра в конец )
                    if (ts < 0) ts += q;
                }
            }

            return indexes;
        }
    }
}
