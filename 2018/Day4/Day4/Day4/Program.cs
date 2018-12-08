using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class logReader
    {
        int[,] logPerGuard = new int[4000,60];
        int[,] logperGuardMinutes = new int[4000, 1];
        

        static void Main(string[] args)
        {
            List<string> intListe = new List<string>();
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\input.txt");
            foreach (string line in lines)
            {
                intListe.Add(line);
            }
            logReader log = new logReader();
            double ergebnis = log.findOverlap(intListe);
            Console.WriteLine("Ergebnis: {0}", ergebnis);
            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();
        }

        public double findOverlap(List<string> stringListe)
        {
            double result = 0;
            string[,] logGroupPerGuard = new string[1000,10];

            stringListe.Sort();
            int zaehler = 0;
            int anzahl = -1;

            foreach(string el in stringListe)
            {
                anzahl++;
                if (el.Contains("begins shift") )
                {
                    zaehler++;
                    anzahl = 0;
                }

                logGroupPerGuard[zaehler, anzahl] = el;
            }

            for (int i = 1; i< 300; i++)
            {
                int startSleep = 0;
                int endSleep = 0;
                bool sleepFound = false;
                string[] guardID = new string[2];

                for (int j = 0; j<10; j++)
                {
                    if (logGroupPerGuard[i, j] == null)
                    {
                        continue;
                    }
                    else
                    {

                        if (logGroupPerGuard[i, j].Contains("begins shift"))
                        {
                            if (sleepFound == true)
                            {

                            }

                            string[] firstHalf = logGroupPerGuard[i, j].Split(']');
                            string[] findID = firstHalf[1].Split('#');
                            string[] stringSeparators = new string[] { "begins" };
                            guardID = findID[1].Split(stringSeparators, StringSplitOptions.None);
                        }

                        if (logGroupPerGuard[i, j].Contains("falls asleep") == true)
                        {
                            string[] firstHalf = logGroupPerGuard[i, j].Split(']');
                            string[] getTime = firstHalf[0].Split(' ');
                            string[] getSleepStartMinute = getTime[1].Split(':');
                            startSleep = int.Parse(getSleepStartMinute[1]);
                            sleepFound = true;
                        }

                        if (logGroupPerGuard[i, j].Contains("wakes up") == true)
                        {
                            string[] firstHalf = logGroupPerGuard[i, j].Split(']');
                            string[] getTime = firstHalf[0].Split(' ');
                            string[] getSleepStartMinute = getTime[1].Split(':');
                            endSleep = int.Parse(getSleepStartMinute[1]);
                            markSleepTime(guardID[0], startSleep, endSleep);
                            sleepFound = false;
                        }
                    }

                }
                
            }

            int maxZeit = 0;
            int selectedGuardID = 0;
            int selectedHighOccurence = 0;
            int zeit = 0;

            //first Part
            /*
            for (int k = 0; k < 4000; k++)
            {
                if (logperGuardMinutes[k,0] > maxZeit)
                {
                    maxZeit = logperGuardMinutes[k, 0];
                    selectedGuardID = k;
                }
            }


            for (int m = 0; m < 60; m++ )
            {
                if (logPerGuard[selectedGuardID, m] > zeit)
                {
                    zeit = logPerGuard[selectedGuardID, m];
                    selectedHighOccurence = m;
                }
            }
             */

            //second Part

            for (int k = 0; k < 4000; k++)
            {
                for (int m = 0; m < 60; m++)
                {
                    if (logPerGuard[k, m] > zeit)
                    {
                        zeit = logPerGuard[k, m];
                        selectedGuardID = k;
                        selectedHighOccurence = m;
                    }
                }
            }

            result = selectedGuardID * selectedHighOccurence;

            return result;
        }

        private void markSleepTime(string guardID, int startSleep, int endSleep)
        {
            for (int i = startSleep; i < endSleep; i++)
            {
                logPerGuard[int.Parse(guardID), i]++;
                logperGuardMinutes[int.Parse(guardID), 0]++;
            }
        }

    }
}
