using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
Problem 18:
Suppose you have n doctors, each of which are free for a certain number of hours per day,
and  m  patients, each of whom needs to be seen for a certain number of hours. Write a
function that determines whether it's possible for all the patients to be scheduled so that
none of the doctors spends more time than they have available. Better yet, tell us which
people should see which doctors.
*/
namespace Day15
{
    class RadioTowersProblem1 
    {
        List<Position> _towers;
        double _distance;
        int _numOfFreq;
        List<int> _result;

        public RadioTowersProblem1(double[,] towers, double d)
        {
            _towers = new List<Position>();
            for (int i = 0; i < towers.GetLength(0); i++)
            {
                _towers.Add(new Position(towers[i, 0], towers[i, 1]));
            }
            _distance = d;            
            _numOfFreq = 0;
            _result = new List<int>();
        }

        public void Solve() 
        {
            Console.WriteLine("Solution by RadioTowersProblem1:");
            for (int i = 0; i <= _towers.Count; i++)
            {
                _numOfFreq = i;
                if (FindFrequency()) break;
                _result = new List<int>();
            }
            Console.WriteLine($" {_numOfFreq} frequencies required:");
            PrintResult();
            Console.WriteLine();
        }

        bool FindFrequency()
        {
            int towerIndex = _result.Count;
            if (towerIndex == _towers.Count) return true;
            for (int freqIndex = 0; freqIndex < _numOfFreq; freqIndex++)
            {
                if (IsValidFreq(freqIndex))
                {
                    _result.Add(freqIndex);
                    if (FindFrequency()) return true;
                    _result.RemoveAt(_result.Count - 1);
                }
            }
            return false;
        }

        private bool IsValidFreq(int freq)
        {
            for (int i = 0; i < _result.Count; i++)
            {
                if (_result[i] == freq && TowersTooClose(_towers[i], _towers[_result.Count])) return false;
            }
             return true;
        }

        private bool TowersTooClose(Position p1, Position p2)
        {
            double dx = p1.X - p2.X;
            double dy = p1.Y - p2.Y;
            return Math.Sqrt(dx*dx + dy*dy) <= _distance;
        }

        private void PrintResult()
        {
            for (int i = 0; i < _result.Count; i++)
            {
                Console.WriteLine($"  Tower {i+1} gets Frequency {_result[i]+1}");
            }
            Console.WriteLine();
        }

        void PrintDistances()
        {
            for (int i = 0; i < _towers.Count; i++)
            {
                Console.WriteLine($"For Tower {_towers[i].AsText()}");
                List<Position> outOfRange = new List<Position>();
                List<Position> withinRange = new List<Position>();
                for (int j = 0; j < _towers.Count; j++)
                {
                    if (j == i) continue;
                    double d = _towers[j].DistanceFrom(_towers[i]);
                    if (_towers[j].DistanceFrom(_towers[i]) > d)
                    {
                        outOfRange.Add(_towers[j]);
                    }
                    else
                    {
                        withinRange.Add(_towers[j]);
                    }
                    Console.WriteLine($"  {_towers[j].AsText()}: {d}");
                }
            }
        }
    }
}
