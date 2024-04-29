using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using SubstringSearchClasses;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

namespace UnitTestProjectForSubstringSearch
{
    
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void SearchPatternCrushTests()
        {
            var algms = new List<ISubstringSearch>()
            {
                new BoyerMooreAlgorithm(),
                new BruteForceAlgorithm(),
                new RabinKarpAlgorithm(),
                new KMPAlgorithm()
            };
            string text = "abababbabababb"; //
            string pattern = "abababbabababaabababbabababaabababbabababa";
            var expected = 0;
            foreach (var algm in algms)
            {
                var actual = algm.IndexesOf(pattern, text).Count;
                Assert.AreEqual(expected, actual);
            }
        }
        [TestMethod]
        public void SearchPatternWithOutPatterns()
        {
            var algms = new List<ISubstringSearch>()
            {
                new BoyerMooreAlgorithm(),
                new BruteForceAlgorithm(),
                new RabinKarpAlgorithm(),
                new KMPAlgorithm()
            };
            string text = "aabaabaabaabaab"; //
            string pattern = "aaab";
            var expected = 0;
            foreach (var algm in algms)
            {
                var actual = algm.IndexesOf(pattern, text).Count;
                Assert.AreEqual(expected, actual);
            }
        }
        [TestMethod]
        public void SearchPatternWithPolindroms()
        {
            var algms = new List<ISubstringSearch>()
            {
                new BoyerMooreAlgorithm(),
                new BruteForceAlgorithm(),
                new RabinKarpAlgorithm(),
                new KMPAlgorithm()
            };
            string text = "топотопотопот"; //3 слова
            string pattern = "топот";
            var expected = 3;
            foreach (var algm in algms)
            {
                var actual = algm.IndexesOf(pattern, text).Count;
                Assert.AreEqual(expected, actual);
            }
        }
        [TestMethod]
        public void SearchPatternWithSpace()
        {
            var algms = new List<ISubstringSearch>()
            {
                new BoyerMooreAlgorithm(),
                new BruteForceAlgorithm(),
                new RabinKarpAlgorithm(),
                new KMPAlgorithm()
            };
            string text = "aa a aaa a aa aa"; //5 пробелов
            string pattern = "a a";
            var expected = 5;
            foreach (var algm in algms)
            {
                var actual = algm.IndexesOf(pattern, text).Count;
                Assert.AreEqual(expected, actual);
            }
        }
        [TestMethod]
        public void SearchTest()
        {
            var algms = new List<ISubstringSearch>()
            {
                new BoyerMooreAlgorithm(),
                new BruteForceAlgorithm(),
                new RabinKarpAlgorithm(),
                new KMPAlgorithm()
            };
            string text = "aaaaaaaaaa"; //10
            string pattern = "aa";
            var expected = Enumerable.Range(0, 9).ToList();
            foreach (var algm in algms)
            {
                var actual = algm.IndexesOf(pattern, text);
                CollectionAssert.AreEqual(expected, actual);
            }
        }

        //[TestMethod]
        //public void SearchBagOfWordsOnAnnaTxt()
        //{
        //    var algms = new List<ISubstringSearch>()
        //    {
        //        new BoyerMooreAlgorithm(),
        //    new RabinKarpAlgorithm(),
        //    new KMPAlgorithm()
        //    };
        //    string text;
        //    using (StreamReader sr = new StreamReader("anna.txt", Encoding.UTF8))
        //    {
        //        text = sr.ReadToEnd().ToLower();
        //    }

        //    int number = 100;
        //    Regex rg = new Regex(@"\w+");
        //    var bag = new HashSet<string>();
        //    var matches = rg.Matches(text);
        //    foreach (var match in matches)
        //    {
        //        bag.Add(match.ToString());
        //        if (bag.Count > number) break;
        //    }
        //    foreach (var pattern in bag)
        //    {
        //        var BF = new BruteForceAlgorithm();
        //        var expected = BF.IndexesOf(pattern, text);
        //        foreach (var algm in algms)
        //        {
        //            var actual = algm.IndexesOf(pattern, text);
        //            CollectionAssert.AreEqual(expected, actual);
        //        }
        //    }
        //}

    }
}
