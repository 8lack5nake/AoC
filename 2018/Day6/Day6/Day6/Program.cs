using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    class ManhattanMetrik
    {
        static void Main(string[] args)
        {
            List<string> intListe = new List<string>();
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\input.txt");

            ManhattanMetrik mm = new ManhattanMetrik();
            double ergebnis = mm.findRegion(lines);
            Console.WriteLine("Ergebnis: {0}", ergebnis);
            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();
        }

        public double findFiniteLarge(string[] lines)
        {
            double result = 0;
            int zeilen = 400;
            int spalten = 400;
            string[][] jaggedGrid = new string[zeilen][];
            string[,] infoPoints = new string[50, 1];
            int[,] lowestDistance = new int[50, 1];
            int[,] countLetters = new int[50, 1];
            List<string> borderLetters = new List<string>();
            int asciiNum = 64;
            
            int row = 0;
            int row_next = 0;
            int row_before = 0;
            int col = 0;
            int col_next = 0;
            int col_before = 0;
            string el_before = "";
            string el_next = "";

            for (int i = 0; i < zeilen; i++)
            {
                jaggedGrid[i] = new string[spalten];
                for (int j = 0; j < spalten; j++)
                {
                    jaggedGrid[i][j] = ".";
                }
            }


            List<string> stringListe = new List<string>();

            foreach (string line in lines)
            {
                stringListe.Add(line);
            }

            //stringListe.Sort();

            //Fill coordinates with main points
            foreach(string el in stringListe)
            {
                infoPoints[asciiNum - 64, 0] = el;
                asciiNum++;
                char character = (char) asciiNum;
                getCoordinates(ref row, ref col, el);
                jaggedGrid[row][col] = character.ToString();
            }

            //printJaggedGrid(jaggedGrid);

                int rowActual = 0, colActual = 0;
                int rowFound = 0, colFound = 0;

                //Start checking main points distances
                for (int i = 0; i < zeilen ; i++ )
                {
                    for (int j = 0; j < spalten; j++)
                    {
                        lowestDistance.Initialize();
                        int lowest = 10000;
                        int lowestID = 0;
                        bool multiPoint = false;

                        //Get distances from all points to actual coordinate
                        for (int index = 0; index < stringListe.Count(); index++ )
                        {
                            getCoordinates(ref rowActual, ref colActual, stringListe[index]);

                            lowestDistance[index, 0] = CalculateManhattanDistance(rowActual, colActual, i, j);
                        }

                        //Get lowest distance to all points to actual coordinate
                        for (int check = 0; check < stringListe.Count(); check++)
                        {
                            if (lowestDistance[check,0] < lowest)
                            {
                                lowestID = check;
                                lowest = lowestDistance[check, 0];
                            }
                        }

                        //Check if lowest value is more than once
                        for (int check = 0; check < stringListe.Count(); check++)
                        {
                            if (lowestDistance[check,0] == lowest && check != lowestID)
                            {
                                multiPoint = true;
                            }
                        }

                        if (multiPoint == true)
                        {
                            jaggedGrid[i][j] = "#";
                        }
                        else
                        {
                            char character = (char)(lowestID + 65);
                            jaggedGrid[i][j] = character.ToString();
                        }

                        if (i == 1 || i == zeilen - 1 || j == 1 || j == spalten-1)
                        {
                            char character = (char)(lowestID + 65);
                            addToBoarderLetter(ref borderLetters, character);
                        }
                    }
                }
                //printJaggedGrid(jaggedGrid);
                el_before = stringListe[0];
            //}


                for (int i = 0; i < zeilen; i++ )
                {
                    for (int j = 0; j< spalten; j++)
                    {
                        if (jaggedGrid[i][j] != "#")
                        {
                            char character = jaggedGrid[i][j][0];
                            countLetters[character - 65, 0]++;
                        }
                    }
                }

                int max = 0;

                for (int i = 0; i < countLetters.Length; i++)
                {
                    if (countLetters[i,0] > max)
                    {
                        char character = (char)(i + 65);
                        int index = borderLetters.IndexOf(character.ToString());
                        if (index == -1)
                        {
                            max = countLetters[i, 0];
                        }
                    }
                }

                result = max;
                    return result;
        }

        public double findRegion(string[] lines)
        {
            double result = 0;
            int zeilen = 400;
            int spalten = 400;
            string[][] jaggedGrid = new string[zeilen][];
            string[,] infoPoints = new string[50, 1];
            int[,] lowestDistance = new int[50, 1];
            int[,] countLetters = new int[50, 1];
            List<string> borderLetters = new List<string>();
            int asciiNum = 64;

            int row = 0;
            int row_next = 0;
            int row_before = 0;
            int col = 0;
            int col_next = 0;
            int col_before = 0;
            string el_before = "";
            string el_next = "";

            for (int i = 0; i < zeilen; i++)
            {
                jaggedGrid[i] = new string[spalten];
                for (int j = 0; j < spalten; j++)
                {
                    jaggedGrid[i][j] = ".";
                }
            }


            List<string> stringListe = new List<string>();

            foreach (string line in lines)
            {
                stringListe.Add(line);
            }

            //stringListe.Sort();

            //Fill coordinates with main points
            foreach (string el in stringListe)
            {
                infoPoints[asciiNum - 64, 0] = el;
                asciiNum++;
                char character = (char)asciiNum;
                getCoordinates(ref row, ref col, el);
                jaggedGrid[row][col] = character.ToString();
            }

            //printJaggedGrid(jaggedGrid);
            
            int rowActual = 0, colActual = 0;
            int rowFound = 0, colFound = 0;
            int maxDistance = 10000;

            //Start checking main points distances
            for (int i = 0; i < zeilen; i++)
            {
                for (int j = 0; j < spalten; j++)
                {
                    lowestDistance.Initialize();
                    int totalDistance = 0;

                    //Get distances from all points to actual coordinate
                    for (int index = 0; index < stringListe.Count(); index++)
                    {
                        getCoordinates(ref rowActual, ref colActual, stringListe[index]);

                        lowestDistance[index, 0] = CalculateManhattanDistance(rowActual, colActual, i, j);
                    }

                    //Get lowest distance to all points to actual coordinate
                    for (int check = 0; check < stringListe.Count(); check++)
                    {
                        totalDistance += lowestDistance[check, 0];
                    }

                    if (totalDistance < maxDistance)
                    {
                        jaggedGrid[i][j] = "#";
                    }

                }

            }
            //printJaggedGrid(jaggedGrid);
            el_before = stringListe[0];
            //}

            int max = 0;
            for (int i = 0; i < zeilen; i++)
            {
                for (int j = 0; j < spalten; j++)
                {
                    if (jaggedGrid[i][j] == "#")
                    {
                        max++;
                    }
                }
            }

            result = max;
            return result;
        }

        private void addToBoarderLetter(ref List<string> borderLetters, char character)
        {
            int index = borderLetters.IndexOf(character.ToString());
            if (index == -1)
            {
                borderLetters.Add(character.ToString());
            }
        }

        private static int getPositionOfCoordinates(string[,] infoPoints,string text)
        {
            int pos = 0;
                    for (int i = 0; i< infoPoints.Length; i++)
                    {
                        if (infoPoints[i, 0] == text)
                        {
                            pos = i;
                            break;
                        }
                    }
            return pos;
        }

        private static void printJaggedGrid(string[][] jaggedGrid)
        {
            Console.Clear();
            for (int i = 0; i < jaggedGrid.Length; i++)
            {
                string[] innerArray = jaggedGrid[i];
                for (int a = 0; a < innerArray.Length; a++)
                {
                    Console.Write(innerArray[a] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void getCoordinates(ref int row, ref int col, string stringListe)
        {
            string[] cordinates = stringListe.Split(',');
            col = int.Parse(cordinates[0]);
            row = int.Parse(cordinates[1]);
        }

        public static int CalculateManhattanDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

    }
}
