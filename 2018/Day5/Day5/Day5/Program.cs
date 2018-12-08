using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    class scanner
    {
        static void Main(string[] args)
        {
            List<string> intListe = new List<string>();
            string lines = System.IO.File.ReadAllText(@"..\..\..\input.txt");

            scanner scan = new scanner();
            double ergebnis = scan.countRest(lines);
            Console.WriteLine("Ergebnis: {0}", ergebnis);
            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();
        }

        public double countRest(string stringText)
        {
            double result = 0;
            bool nothingFound = false;
            char beforeLetter = ' ';
            int diff;

            char[] zeichenList = stringText.ToCharArray();
            List<char> listOfCHar = new List<char>();
            zeichenList.ToList().ForEach(v => listOfCHar.Add(v));

            List<char> listOfCHarTmp = new List<char>();

            List<int> letterCount = new List<int>();

            for (int j = 65; j <= 90; j++)
            {
                listOfCHarTmp.Clear();
                zeichenList.ToList().ForEach(v => listOfCHarTmp.Add(v));
                char character = (char) j;
                listOfCHarTmp.RemoveAll(item => item == character);
                char character2 = (char) (j+32);
                listOfCHarTmp.RemoveAll(item => item == character2);
                nothingFound = false;
                beforeLetter = ' ';

                while (nothingFound == false)
                {
                    nothingFound = true;
                    for (int i = 0; i < listOfCHarTmp.Count(); i++)
                    {
                        if (beforeLetter != ' ')
                        {
                            diff = beforeLetter - listOfCHarTmp[i];
                            diff = Math.Abs(diff);
                            if (diff == 32)
                            {
                                listOfCHarTmp.RemoveAt(i - 1);
                                listOfCHarTmp.RemoveAt(i - 1);
                                beforeLetter = ' ';
                                nothingFound = false;
                                break;
                            }
                        }

                        beforeLetter = listOfCHarTmp[i];
                    }
                }
                letterCount.Add(listOfCHarTmp.Count());

            }

            letterCount.Sort();

            result = letterCount[0];
            return result;
        }
    }
}
