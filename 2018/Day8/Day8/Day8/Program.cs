using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    class LicenceCounter
    {
        static void Main(string[] args)
        {
            List<string> intListe = new List<string>();
            string lines = System.IO.File.ReadAllText(@"..\..\..\input.txt");

            LicenceCounter lc = new LicenceCounter();
            double ergebnis = lc.counting(lines);
            Console.WriteLine("Ergebnis: {0}", ergebnis);
            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();
        }

        public double counting(string lines)
        {
            double result = 0;  
           

            List<int> lineListe = lines.Split(' ').ToList().Select(s => int.Parse(s)).ToList();

            int maxHeader = lineListe.Count();
            List<int[,]> listMetaData = new List<int[,]>();
            int zaehler = 0;
            int value = 0;

                countNode(ref lineListe, ref maxHeader, ref zaehler, ref listMetaData, ref value);

           foreach(var el in listMetaData)
           {
               for(int i = 0; i < 500; i++)
               {
                   result = result + el[0, i];
               }
           }

                return result;
        }

        private static void countNode(ref List<int> lineListe, ref int maxHeader, ref int zaehler, ref List<int[,]> listMetaData, ref int valueOfNode)
        {
            int[,] metaData = new int[1, 500];
            int[] nodeValues = new int[30];
            if (zaehler <= maxHeader)
            { 
                int quantChildNodes = lineListe[zaehler];
                int quantMetaData = lineListe[zaehler + 1];
                if (quantChildNodes != 0)
                {
                    if (zaehler == 0)
                    {
                        zaehler = zaehler + 1;
                    }
                    else
                    {
                        if (zaehler + quantMetaData > maxHeader)
                        {
                            return;
                        }
                        else
                        {
                            zaehler = zaehler + 1;
                        }
                    }

                    //Schleife für die Anzahl der ChildNodes
                    for (int i = 0; i < quantChildNodes; i++)
                    {
                        int value = 0;
                        zaehler++;
                        countNode(ref lineListe, ref maxHeader, ref zaehler, ref listMetaData, ref value);
                        nodeValues[i+1] = value;                        
                    }
                    zaehler--;
                }
            
                int counter = 0;
                zaehler++;
                int result = zaehler + quantMetaData;
                //int valueOfNode = 0;
                while (zaehler < result)
                {
                    zaehler++;
                    metaData[0, counter] = lineListe[zaehler];
                    counter++;

                    if (quantChildNodes == 0)
                    {
                        valueOfNode += lineListe[zaehler];
                    }
                }

                for (int i = 0; i < counter;i++ )
                {
                    valueOfNode += nodeValues[metaData[0, i]];
                }

                    listMetaData.Add(metaData);

            }
        }
    }
}
