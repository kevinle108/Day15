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

        public RadioTowersProblem1(double[,] towers, double d)
        {
            _towers = new List<Position>();
            for (int i = 0; i < towers.GetLength(0); i++)
            {
                _towers.Add(new Position(towers[i, 0], towers[i, 1]));
            }
            _distance = d;
        }

        public void Solve() 
        {
            Console.WriteLine("Solution by RadioTowersProblem1:");
            FindFrequency();
            Console.WriteLine();
        }

        public int FindFrequency()
        {
            PrintDistances();
            return 1;
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
