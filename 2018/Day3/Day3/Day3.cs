using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class fabric
    {
        static void Main(string[] args)
        {
            List<string> intListe = new List<string>();
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\input.txt");
            foreach (string line in lines)
            {
                intListe.Add(line);
            }

            fabric counter = new fabric();
            double ergebnis = counter.findMatchSquares(intListe);
            Console.WriteLine("Ergebnis: {0}", ergebnis);
            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();
        }

        public double findMatchSquares(List<string> stringList)
        {
            double result = 0;
            int maxZeile = 1050;
            int maxSpalte = 1050;
            //array2D[Zeile, Spalte]
            int[,] array2D = new int[maxZeile, maxSpalte];
            string possibleID = "";

            foreach (string el in stringList)
            {
                string[] valueString = el.Split('@');
                string[] keyValues = valueString[1].Split(':');
                string[] stringStartPositions = keyValues[0].Split(',');
                string[] stringSizeValues = keyValues[1].Split('x');
                int[] startPositions = Array.ConvertAll(stringStartPositions, s => int.Parse(s));
                int[] sizeValues = Array.ConvertAll(stringSizeValues, s => int.Parse(s));

                for (int i = 1; i <= sizeValues[0]; i++)
                {
                    for (int j = 1; j <= sizeValues[1]; j++)
                    {
                        array2D[startPositions[0] + i, startPositions[1] + j]++;
                    }
                }
            }

            foreach (string el in stringList)
            {
                string[] valueString = el.Split('@');
                string[] keyValues = valueString[1].Split(':');
                string[] stringStartPositions = keyValues[0].Split(',');
                string[] stringSizeValues = keyValues[1].Split('x');
                int[] startPositions = Array.ConvertAll(stringStartPositions, s => int.Parse(s));
                int[] sizeValues = Array.ConvertAll(stringSizeValues, s => int.Parse(s));
                string possibleIDtmp = valueString[0];

                for (int i = 1; i <= sizeValues[0]; i++)
                {
                    for (int j = 1; j <= sizeValues[1]; j++)
                    {
                        int aktuellerWert = array2D[startPositions[0] + i, startPositions[1] + j];
                        if (aktuellerWert > 1)
                        {
                            possibleIDtmp = "";
                        }
                    }
                }
                var good = true;

                if (possibleIDtmp != "")
                    possibleID = possibleIDtmp;
            }



            for (int i = 0; i< maxZeile; i++)
            {
                for (int j = 0; j< maxSpalte; j++)
                {
                    if (array2D[i,j] >= 2)
                    {
                        result++;
                    }
                }
            }
            Console.WriteLine("PossibleID: {0}", possibleID);
            return result;
        }
    }
}
