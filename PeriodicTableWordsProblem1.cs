using System;
using System.Collections.Generic;
using System.Linq;

/*
Problem 17: 
Some words can be spelled out using only element symbols from the periodic table. For example, the world “canine” can be spelled as  CaNiNe  (calcium, nickel, neon). Some words,
like “element,” cannot. Write a function that accepts as input a string and a set of all the
element symbols in the periodic table, then returns whether the word can or cannot be
spelled using element symbols. Even better, if the string can be spelled this way, return
the string with the capitalization changed to reflect that spelling
*/

namespace Day15
{
    class PeriodicTableWordsProblem1
    {
        string _originalWord;
        string _word;
        static Dictionary<string, string> _pTable = new Dictionary<string, string>
        {
            {"H", "Hydrogen"},
            {"He", "Helium"},
            {"Li", "Lithium"},
            { "Be", "Beryllium"},
            { "B", "Boron"},
            { "C", "Carbon"},
            { "N", "Nitrogen"},
            { "O", "Oxygen"},
            { "F", "Fluorine"},
            { "Ne", "Neon"},
            { "Na", "Sodium"},
            { "Mg", "Magnesium"},
            { "Al", "Aluminum"},
            { "Si", "Silicon"},
            { "P", "Phosphorus"},
            { "S", "Sulfur"},
            { "Cl", "Chlorine"},
            { "Ar", "Argon"},
            { "K", "Potassium"},
            { "Ca", "Calcium"},
            { "Sc", "Scandium"},
            { "Ti", "Titanium"},
            { "V", "Vanadium"},
            { "Cr", "Chromium"},
            { "Mn", "Manganese"},
            { "Fe", "Iron"},
            { "Co", "Cobalt"},
            { "Ni", "Nickel"},
            { "Cu", "Copper"},
            { "Zn", "Zinc"},
            { "Ga", "Gallium"},
            { "Ge", "Germanium"},
            { "As", "Arsenic"},
            { "Se", "Selenium"},
            { "Br", "Bromine"},
            { "Kr", "Krypton"},
            { "Rb", "Rubidium"},
            { "Sr", "Strontium"},
            { "Y", "Yttrium"},
            { "Zr", "Zirconium"},
            { "Nb", "Niobium"},
            { "Mo", "Molybdenum"},
            { "Tc", "Technetium"},
            { "Ru", "Ruthenium"},
            { "Rh", "Rhodium"},
            { "Pd", "Palladium"},
            { "Ag", "Silver"},
            { "Cd", "Cadmium"},
            { "In", "Indium"},
            { "Sn", "Tin"},
            { "Sb", "Antimony"},
            { "Te", "Tellurium"},
            { "I", "Iodine"},
            { "Xe", "Xenon"},
            { "Cs", "Cesium"},
            { "Ba", "Barium"},
            { "La", "Lanthanum"},
            { "Ce", "Cerium"},
            { "Pr", "Praseodymium"},
            { "Nd", "Neodymium"},
            { "Pm", "Promethium"},
            { "Sm", "Samarium"},
            { "Eu", "Europium"},
            { "Gd", "Gadolinium"},
            { "Tb", "Terbium"},
            { "Dy", "Dysprosium"},
            { "Ho", "Holmium"},
            { "Er", "Erbium"},
            { "Tm", "Thulium"},
            { "Yb", "Ytterbium"},
            { "Lu", "Lutetium"},
            { "Hf", "Hafnium"},
            { "Ta", "Tantalum"},
            { "W", "Tungsten"},
            { "Re", "Rhenium"},
            { "Os", "Osmium"},
            { "Ir", "Iridium"},
            { "Pt", "Platinum"},
            { "Au", "Gold"},
            { "Hg", "Mercury"},
            { "Tl", "Thallium"},
            { "Pb", "Lead"},
            { "Bi", "Bismuth"},
            { "Po", "Polonium"},
            { "At", "Astatine"},
            { "Rn", "Radon"},
            { "Fr", "Francium"},
            { "Ra", "Radium"},
            { "Ac", "Actinium"},
            { "Th", "Thorium"},
            { "Pa", "Protactinium"},
            { "U", "Uranium"},
            { "Np", "Neptunium"},
            { "Pu", "Plutonium"},
            { "Am", "Americium"},
            { "Cm", "Curium"},
            { "Bk", "Berkelium"},
            { "Cf", "Californium"},
            { "Es", "Einsteinium"},
            { "Fm", "Fermium"},
            { "Md", "Mendelevium"},
            { "No", "Nobelium"},
            { "Lr", "Lawrencium"},
            { "Rf", "Rutherfordium"},
            { "Db", "Dubnium"},
            { "Sg", "Seaborgium"},
            { "Bh", "Bohrium"},
            { "Hs", "Hassium"},
            { "Mt", "Meitnerium"},
            { "Ds", "Darmstadtium"},
            { "Rg", "Roentgenium"},
            { "Cn", "Copernicium"},
            { "Nh", "Nihonium"},
            { "Fl", "Flerovium"},
            { "Mc", "Moscovium"},
            { "Lv", "Livermorium"},
            { "Ts", "Tennessine"},
            { "Og", "Oganesson"}
        };
        List<string> _elements = _pTable.Keys.ToList().ConvertAll(ele => ele.ToUpper());

        public PeriodicTableWordsProblem1(string word)
        {
            _originalWord = word;
            _word = word.ToUpper();
        }

        public void Solve()
        {
            Console.WriteLine("Solution by PeriodicTableWordsProblem1:");
            if (PeriodicTableWords())
            {
                Console.WriteLine($"   Yes, \"{_originalWord}\" can be spelled with elements.");
            }
            else Console.WriteLine($"   No, \"{_originalWord}\" cannot spelled with elements.");
            Console.WriteLine();
        }

        private bool PeriodicTableWords()
        {
            if (_word == "")
            {
                return true;
            }
            string saved = _word;
            if (_elements.Contains(_word.Substring(0, 2)))
            {
                _word = _word.Substring(2);
                if (PeriodicTableWords()) return true;
                else _word = saved;
            }
            if (_elements.Contains(_word.Substring(0, 1)))
            {
                _word = _word.Substring(1);
                if (PeriodicTableWords()) return true;
                else _word = saved;
            }
            return false;
        }
    }
}
