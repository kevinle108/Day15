using System;
using System.Collections.Generic;
using System.Linq;

/*
Problem 16: 
A shrinkable word is a word that can be reduced down to the empty string by deleting
one letter at a time such that, at each stage, the remaining string is a word. For example,
the word “startling” is shirnkable because of this sequence of words:
startling -> starting -> staring -> string -> sting -> sing -> sin -> in -> i -> (empty)
Write a function that accepts as input a string and a set of all the words in English, then
reports whether the input word is shrinkable.
*/

namespace Day15
{
    class ShrinkableWordsProblem2
    {
        string _originalWord;
        string _word;
        List<string> _vocab;
        Stack<string> _result;

        public ShrinkableWordsProblem2(string word, List<string> vocab)
        {
            _originalWord = word;
            _word = word;
            _vocab = vocab;
            _result = new Stack<string>();
        }

        public void Solve()
        {
            Console.WriteLine("Solution by ShrinkableWordsProblem2:");
            if (ShrinkableWords())
            {
                Console.WriteLine($"   Yes, your word {_originalWord} is shrinkable.");
                PrintResult();
            }
            else Console.WriteLine($"   No, your word {_originalWord} is not shrinkable.");
            Console.WriteLine();
        }

        private bool ShrinkableWords()
        {
            if (_word == "") return true;
            if (!_vocab.Contains(_word)) return false;
            for (int i = 0; i < _word.Length; i++)
            {
                string saved = _word;
                _result.Push(saved + $" -> will remove {saved[i]} next");
                _word = _word.Remove(i, 1);
                if (ShrinkableWords()) return true;
                else
                {
                    _word = saved;
                    _result.Pop();
                }
            }
            return false;
        }

        public void PrintResult()
        {
            string txt = "";
            int numOfLines = _result.Count;
            for (int i = 0; i < numOfLines; i++)
            {
                txt = "   " + _result.Pop() + "\n" + txt;
            }
            Console.WriteLine();
            Console.WriteLine(txt);
        }

        public void PrintVariables()
        {
            Console.WriteLine("Printing ShrinkableWords variables:");
            Console.WriteLine($" _word: {_word}");
            Console.WriteLine($" _vocab:");
            foreach (var word in _vocab)
            {
                Console.WriteLine($"        {word}");
            }
            Console.WriteLine($" _vocab:");
            foreach (var word in _vocab)
            {
                Console.WriteLine($"        {word}");
            }
        }
    }
}
