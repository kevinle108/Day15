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
    class PatientSchedulerProblem2
    {
        List<int> _doctors;
        List<int> _patients;
        List<string> _result;

        public PatientSchedulerProblem2(int[] doctorHours, int[] patientHours)
        {
            _doctors = doctorHours.ToList();
            _patients = patientHours.ToList();
            _result = new List<string>();
            for (int i = 0; i < _doctors.Count; i++)
            {
                _result.Add($"Doctor {i + 1}'s Appointments: ");
            }
        }

        public void Solve() 
        {
            Console.WriteLine("Solution by PatientSchedulerProblem2:");
            PrintList("Doctors", _doctors);
            PrintList("Patients", _patients);
            if (Scheduler())
            {
                Console.WriteLine("  Yes, all patients can be scheduled:");
                PrintResult();
            }
            else
            {
                Console.WriteLine("  No, not enough doctor availability.");
            }
            Console.WriteLine();
        }

        public bool Scheduler()
        {
            if (_patients.Count == 0)
            {
                return true;
            }
            for (int i = 0; i < _doctors.Count; i++)
            {
                var savedDocs = new List<int>(_doctors);
                var savedPats = new List<int>(_patients);
                if (_doctors[i] >= _patients[0])
                {
                    int savedStringLength = _result[i].Length;
                    _result[i] += $"{_patients[0]}hr ";
                    _doctors[i] -= _patients[0];
                    _patients.RemoveAt(0);
                    if (Scheduler()) return true;
                    else
                    {
                        _doctors = savedDocs;
                        _patients = savedPats;
                        _result[i] = _result[i].Substring(0, savedStringLength);
                    }
                }
            }
            return false;
        }

        void PrintResult()
        {
            Console.WriteLine();
            _result.ForEach(x => Console.WriteLine("    " + x));
        }

        void PrintList(string listName, List<int> list)
        {

            Console.Write($"  {listName}: {{");
            foreach (var item in list)
            {
                Console.Write($" {item} ");
            }
            Console.Write("}\n");
        }
    }
}
