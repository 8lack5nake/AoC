using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class Calculator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nBitte zahlen eingeben zum Prüfen:");
            String s = Console.ReadLine();
            Calculator calc = new Calculator();
            double ergebnis = calc.summUp(s);
            Console.WriteLine("Ergebnis: {0}", ergebnis);
            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();
        }

        // method under test 
        public double summUp(string wert)
        {
            double summ = 0;
            return summ;
        }
    }
}
