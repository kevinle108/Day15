using System;
using System.Collections.Generic;

namespace Day15
{
    class Program
    {
        static void Main(string[] args)
        {
            //ShrinkableWords();
            PeriodicTableWords();
        }

        // Problem 16
        static void ShrinkableWords()
        {
            // initialize the needed variables
            List<string> vocab = new List<string>()
            {
                "MTAO", "OF", "TEC", "MXD", "T", "O", "AF", "AE", "A",
                "TAZ", "MTBXAE", "ABCDE", "TAEC", "MTOZE", "MITXFAEC", "MTAFC", "MTSFOC", "MTZABC",
                "MTAFOC", "MITXFFEC", "XAEC", "MTAFEC", "F", "MTBXAEC", "ZAEC", "MFECFEC", "TAX",
                "MTXAFEC", "TAFEC", "MXAFECI", "TAE", "ITXAFC", "MTAFOCC", "MITXAFEOC", "D", "MXITABFEC",
                "AC", "MTAFOC", "MD", "MTXABCD", "OA", "MITXAFEC", "OFMIT", "TED", "MTAEC",
                "MITXFAEE", "TAF", "TAC", "AEOC", "TA", "MITXAFC", "ITXAFEC", "MITXAFE", "MITAFEC"
            };
            string word = "MITXAFEC";

            // create instance of the Class
            var p1 = new ShrinkableWordsProblem1(word, vocab);
            var p2 = new ShrinkableWordsProblem2(word, vocab);

            // solve the problem
            p1.Solve();
            p2.Solve();
        }
        // Problem 17
        static void PeriodicTableWords()
        {
            // initialize the needed variables
            string word1 = "canine";
            string word2 = "procrastinate";
            string word3 = "computer";

            // create instance of the Class
            var p1_1 = new PeriodicTableWordsProblem1(word1);
            var p1_2 = new PeriodicTableWordsProblem1(word2);
            var p1_3 = new PeriodicTableWordsProblem1(word3);

            //var p2_1 = new PeriodicTableWordsProblem1(word1);
            //var p2_2 = new PeriodicTableWordsProblem1(word2);
            //var p2_3 = new PeriodicTableWordsProblem1(word3);

            // solve the problem
            p1_1.Solve();
            p1_2.Solve();
            p1_3.Solve();

            //p2_1.Solve();
            //p2_2.Solve();
            //p2_3.Solve();
        }
    }
}
