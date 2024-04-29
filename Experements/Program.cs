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
            BruteForceAlgorithm bruteForceAlgorithm = new BruteForceAlgorithm();

            //string text = "aaaaaaaaaa";
            //string pattern = "Дарья Александровна";
            //using (StreamReader sr = new StreamReader("anna.txt"))
            //{
            //    text = sr.ReadToEnd();
            //}
            string text = "abababbabababb"; 
            string pattern = "abababbabababaabababbabababaabababbabababa";


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
            Console.WriteLine(bruteForceAlgorithm.IndexesOf(pattern, text).Count() + " - кол-во");
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds.ToString() + " - Brute\n");

            Console.ReadKey();
        }
    }
}
