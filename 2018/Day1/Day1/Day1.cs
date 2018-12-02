using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class checkFrequency
    {
        static void Main(string[] args)
        {
            List<string> intListe = new List<string>();
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\input.txt");
            foreach (string line in lines)
            {
                intListe.Add(line);
            }

            checkFrequency checker = new checkFrequency();
            //double ergebnis = checker.calcFrequency(intListe);
            double ergebnis = checker.findDouble(intListe);
            Console.WriteLine("Ergebnis: {0}", ergebnis);
            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();

        }

        public double calcFrequency(List<string> stringList)
        {
            double sum = 0;
            int count = 0;

            foreach (var el in stringList)
            {
                count++;
                sum += int.Parse(el);
            }
            Console.WriteLine("Count: {0}", count);
            return sum;
        }

        public double findDouble(List<string> stringList)
        {
            double sum = 0;
            double result = 0;
            bool found = false;

            List<double> saveList = new List<double>();

            while (found != true)
            { 
                foreach (var el in stringList)
                {
                    sum += int.Parse(el);
                    if (saveList.Contains(sum) == true)
                    {
                        found = true;
                        return sum;
                    }
                    else
                    {
                        saveList.Add(sum);
                    }
                }
            }

            return result;
        }

    }
}
