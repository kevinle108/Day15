using System;
using System.Collections.Generic;
using System.Text;

namespace Day15
{
    class CellTowerProblem
    {
        struct Coordinate
        {
            public double x;
            public double y;
        }

        List<Coordinate> _coordinates;
        double _minDistance;
        int _freqCount;
        List<int> _freqUsed;

        // constructor
        public CellTowerProblem(double[,] coords, double minDistance, int freqCount)
        {
            _coordinates = new List<Coordinate>();
            for (int i = 0; i <= coords.GetUpperBound(0); i++)
            {
                _coordinates.Add(new Coordinate { x = coords[i, 0], y = coords[i, 1] });
            }
            _minDistance = minDistance;
            _freqCount = freqCount;            
        }

        public void Solve()
        {
            _freqUsed = new List<int>();
            CellTower();
        }

        private bool CellTower()
        {
            int towerIndex = _freqUsed.Count;
            if (towerIndex == _coordinates.Count)
            {
                // output result
                OutputResult();
                return true;
            }
            for (int freqIndex = 0; freqIndex < _freqCount; freqIndex++)
            {
                if (IsFreqValid(freqIndex))
                {
                    _freqUsed.Add(freqIndex);
                    if (CellTower()) return true;
                    _freqUsed.RemoveAt(_freqUsed.Count - 1);
                }
            }
            return false;
        }

        private void OutputResult()
        {
            for (int i = 0; i < _freqUsed.Count; i++)
            {
                Console.WriteLine($"Tower {i+1} uses Frequency {_freqUsed[i]+1}");
            }
        }

        private bool IsFreqValid(int freqIndex)
        {
            for (int towerIndex = 0; towerIndex < _freqUsed.Count; towerIndex++)
            {
                if (_freqUsed[towerIndex] == freqIndex && AreTooClose(towerIndex, _freqUsed.Count))
                    return false;
            }
            return true;
        }

        private bool AreTooClose(int towerIndex1, int towerIndex2)
        {
            double dx = _coordinates[towerIndex1].x - _coordinates[towerIndex2].x;
            double dy = _coordinates[towerIndex1].y - _coordinates[towerIndex2].y;
            double dist = Math.Sqrt(dx * dx + dy * dy);
            return dist <= _minDistance;
        }
    }
}
