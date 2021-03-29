using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day15
{
    class PatientSchedulerProblem1
    {
        List<int> _doctors;
        List<int> _patients;

        public PatientSchedulerProblem1(int[] doctorHours, int[] patientHours)
        {
            _doctors = doctorHours.ToList();
            _patients = patientHours.ToList();
        }

        public void Solve() 
        {
            Console.WriteLine("Solution by PatientSchedulerProblem1:");
            PrintList("Doctors", _doctors);
            PrintList("Patients", _patients);
            if (Scheduler())
            {
                // print yes
                Console.WriteLine("    Yes, all patients can be scheduled.");
            }
            else
            {
                // print no
                Console.WriteLine("    No, not enough doctor availability.");
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
                    _doctors[i] -= _patients[0];
                    _patients.RemoveAt(0);
                    if (Scheduler()) return true;
                    else
                    {
                        _doctors = savedDocs;
                        _patients = savedPats;
                    }
                }
            }
            return false;
        }

        static void PrintList(string listName, List<int> list)
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
