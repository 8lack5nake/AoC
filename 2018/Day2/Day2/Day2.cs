using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class letterCounter
    {
        static void Main(string[] args)
        {
            List<string> intListe = new List<string>();
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\input.txt");
            foreach (string line in lines)
            {
                intListe.Add(line);
            }

            letterCounter counter = new letterCounter();
            string ergebnis = counter.findMatchLine(intListe);
            Console.WriteLine("Ergebnis: {0}", ergebnis);
            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();
        }

        public double countLetters(List<string> stringList)
        {
            double result = 0;
            int twoTimes = 0;
            int threeTimes = 0;
            //int[] c = new int[(int)char.MaxValue];
            bool twoFound = false, threeFound = false;

            foreach (var el in stringList)
            {
                twoFound = false;
                threeFound = false;
                int[] c = new int[(int)char.MaxValue];

                foreach (char t in el)
                {
                    // Increment table.
                    c[(int)t]++;
                }

                for (int i = 0; i < (int)char.MaxValue; i++)
                {
                    if (c[i] == 2 && twoFound == false)
                    {
                        twoTimes++;
                        twoFound = true;
                    }

                    if (c[i] == 3 && threeFound == false)
                    {
                        threeTimes++;
                        threeFound = true;
                    }

                    if (twoFound == true && threeFound == true)
                        break;
                }
            }

            result = twoTimes * threeTimes;

            return result;
        }

        public string findMatchLine(List<string> stringList)
        {
            string result = "";
            string lastString = "";
            int noMatch = 0;

            stringList.Sort();

            for (int i = 0; i < stringList.Count(); i++)
            {
                noMatch = 0;
                if (i > 0)
                {
                    //var diff = lastString.Except(stringList[i]);
                    //if (diff.Count() == 1)
                    //{
                    //    foreach (var value in diff)
                    //        Console.WriteLine("Ergebnis: String: {0}, Unterschied: {1}", lastString, value);
                    //}
                    char[] lastStringArray = lastString.ToCharArray();
                    char[] actualStringArray = stringList[i].ToCharArray();
                    for (int j = 0; j < lastStringArray.Count(); j++)
                    {
                        if (lastStringArray[j] != actualStringArray[j])
                            noMatch++;

                    }

                    if (noMatch == 1)
                    {
                        for (int j = 0; j < lastStringArray.Count(); j++)
                        {
                            if (lastStringArray[j] != actualStringArray[j])
                                Console.WriteLine("Ergebnis: String: {0}, Unterschied: {1}", lastString, lastStringArray[j]);

                        }
                    }

                }
                lastString = stringList[i];
            }

            return result;
        }

    }
}
