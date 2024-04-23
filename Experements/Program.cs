using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SubstringSearchClasses;

namespace Experements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RabinKarpAlgorithm rabinKarpAlgorithm = new RabinKarpAlgorithm();
            BoyerMooreAlgorithm boyerMooreAlgorithm = new BoyerMooreAlgorithm();
            KMPAlgorithm kMPAlgorithm = new KMPAlgorithm();

            string text = "дровна Александровна Александровна";
            string pattern = "под";
            using (StreamReader sr = new StreamReader("anna.txt"))
            {
                text = sr.ReadToEnd();
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine(rabinKarpAlgorithm.IndexesOf(pattern, text).Count() + " - кол-во");
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds.ToString() + " - Karp\n");

            stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine(boyerMooreAlgorithm.IndexesOf(pattern, text).Count() + " - кол-во");
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds.ToString() + " - Boyer\n");

            stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine(kMPAlgorithm.IndexesOf(pattern, text).Count() + " - кол-во");
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds.ToString() + " - KMP\n");

            stopwatch = new Stopwatch();
            stopwatch.Start();
            int cnt = 0;
            for (int i = 0; i < text.Length - pattern.Length + 1; i++)
            {
                if(EqualityOfWords(pattern, text, i))
                    cnt++;
            }
            Console.WriteLine(cnt + " - кол-во");
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds.ToString() + " - Brut\n");

            Console.ReadKey();
        }

        public static bool EqualityOfWords(string s1, string s2, int startIndex)
        {
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i + startIndex])
                    return false;
            }

            return true;
        }
    }
}
