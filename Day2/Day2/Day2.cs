using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class CheckSum
    {
        static void Main(string[] args)
        {
            List<string> intListe = new List<string>();
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\input.txt");
            foreach (string line in lines)
            {
                intListe.Add(line);
            }

            CheckSum checker = new CheckSum();
            double ergebnis = checker.calcDivSum(intListe);
            Console.WriteLine("Ergebnis: {0}", ergebnis);
            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();

        }

        //Convert from array of charactes to array of integers
        private List<int> convertCharToIntArray(char[] charArray)
        {
            List<int> listOfInt = new List<int>();
            charArray.ToList().ForEach(v => listOfInt.Add(int.Parse(v.ToString())));
            return listOfInt;
        }


        public double getDifference(string wert)
        {
            double difference = 0;

            List<int> intList = new List<int>();
            string[] splits = wert.Split('\t');
            foreach (string split in splits)
            {
                intList.Add(int.Parse(split));
            }

            intList.Sort();
            int anzahl = intList.Count();

            int ersteZahl = intList[0];
            int letzteZahl = intList[anzahl - 1];

            difference = letzteZahl - ersteZahl;

            return difference;
        }

        public double calcSum (List<string> stringList)
        {
            double sum = 0;
            int count = 0;

            foreach (var el in stringList)
            {
                count++;
                sum += getDifference(el);
            }
            Console.WriteLine("Count: {0}", count);
            return sum;
        }

        public double evenDivision(string wert)
        {
            double result = 0;

            List<int> intList = new List<int>();
            string[] splits = wert.Split('\t');
            foreach (string split in splits)
            {
                intList.Add(int.Parse(split));
            }

            intList.Sort();
            int anzahl = intList.Count();

            List<int> divList = new List<int>();

            for (int i = anzahl-1; i >= 0; i--)
            {
                for (int j = i-1; j >= 0; j--)
                {
                    if (intList[i] % intList[j] == 0)
                    {
                        divList.Add(intList[i]);
                        divList.Add(intList[j]);
                        j = 0;
                        i = 0;
                    }
                }
            }

            divList.Sort();
            result = divList[1] / divList[0];

            return result;
        }

        public double calcDivSum(List<string> stringList)
        {
            double sum = 0;
            int count = 0;

            foreach (var el in stringList)
            {
                count++;
                sum += evenDivision(el);
            }
            Console.WriteLine("Count: {0}", count);
            return sum;
        }

    }
}
