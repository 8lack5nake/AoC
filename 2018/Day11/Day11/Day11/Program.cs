using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    class FuelTank
    {
        static void Main(string[] args)
        {
            FuelTank tank = new FuelTank();
            //string[] lines = System.IO.File.ReadAllLines(@"..\..\..\input.txt");

            //foreach (string line in lines)
            //{

            //}
            int posx = 3;
            int posy = 5;
            int gridSerial = 8;

            int tmpResult = tank.calculatePowerLevel(gridSerial, posx, posy);

            int gridSerialNumber = 5235;

            
            string result = tank.getMaxPower1(gridSerialNumber);
            Console.WriteLine("1. Ergebnis von GridSerialNumber {0} ist {1}", gridSerialNumber, result);
            string result2 = string.Empty;
            for (int i = 1; i < 295; i++)
            {
                result2 = tank.getMaxPower2(gridSerialNumber, i);
            }
            Console.WriteLine("2. Ergebnis von GridSerialNumber {0} ist {1}", gridSerialNumber, result2);

            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();

        }

        public string getMaxPower1(int gridSerialNumber)
        {
            string result = string.Empty;
            int maxSize = 300;


            int[,] fuelTank = new int[maxSize + 1, maxSize + 1]; //we need to add here 1, as the first top left cell is 1,1


            for (int x = 1; x < maxSize + 1; x++) //x
            {
                for (int y = 1; y < maxSize + 1; y++) //y
                {
                    fuelTank[x, y] = calculatePowerLevel(gridSerialNumber, x, y);
                }
            }

            int[,] matrixValue = new int[maxSize + 1, maxSize + 1];
            int m = 0;
            int n = 0;

            matrixValue.Initialize();
            for (int i = 1; i < maxSize - 1; i++) //x
            {
                for (int j = 1; j < maxSize - 1; j++) //y
                {
                    m = 0;
                    n = 0;
                    while (m < 3)
                    {
                        n = 0;
                        while (n < 3)
                        {
                            //int value = fuelTank[i + m, j + n];
                            //int newValue = matrixValue[i, j] + value;
                            matrixValue[i, j] += fuelTank[i + m, j + n];
                            n++;
                        }
                        m++;
                    }

                }

            }
            //Console.WriteLine(printLine);

            string maxErgebnis = string.Empty;
            int maxValue = 0;
            int minPositionCalc = 600;

            Console.WriteLine("--------------CoordinateMax---------------");
            for (int i = 1; i < maxSize + 1; i++) //x
            {
                string printLine = string.Empty;
                for (int j = 1; j < maxSize + 1; j++) //y
                {

                    int actualValue = matrixValue[i, j];
                    if (actualValue > maxValue)
                    {
                        maxValue = actualValue;

                        minPositionCalc = i + j;
                        maxErgebnis = i + "x" + j;

                    }
                    else if (actualValue == maxValue)
                    {
                        if (i + j < minPositionCalc)
                        {
                            minPositionCalc = i + j;
                            maxErgebnis = i + "x" + j;
                        }
                    }
                }
                //Console.WriteLine(printLine);

            }


            return maxErgebnis;
        }

        public string getMaxPower2(int gridSerialNumber, int quadrat)
        {



            //var serial = 18;

            //var score = new Func<int, int, int>((x, y) =>
            //{
            //    return ((((((x + 10) * y) + serial) * (x + 10)) % 1000) / 100) - 5;
            //});

            //var cells = Enumerable.Range(1, 300).Select(x =>
            //  Enumerable.Range(1, 300).Select(y =>
            //    score(x, y)).ToArray()).ToArray();

            //var sum = new Func<int, int, int, int>((x, y, n) =>
            //{
            //    var s = 0;
            //    for (int i = 0; i < n; ++i)
            //    {
            //        for (int j = 0; j < n; ++j)
            //        {
            //            s += cells[x + i][y + j];
            //        }
            //    }
            //    return s;
            //});

            //var scores = Enumerable.Range(1, 300).AsParallel().SelectMany(n => Enumerable.Range(0, 300 - n).SelectMany(x =>
            //  Enumerable.Range(0, 300 - n).Select(y => new { n = n, x = x + 1, y = y + 1, sum = sum(x, y, n) }).ToArray()).ToArray()).ToArray();

            //Console.WriteLine(scores.OrderByDescending(s => s.sum).Take(1));


            string result = string.Empty;
            int maxSize = 300;


            int[,] fuelTank = new int[maxSize + 1, maxSize + 1]; //we need to add here 1, as the first top left cell is 1,1


            for (int x = 1; x < maxSize + 1; x++) //x
            {
                for (int y = 1; y < maxSize + 1; y++) //y
                {
                    fuelTank[x, y] = calculatePowerLevel(gridSerialNumber, x, y);
                }
            }

            List<int[,]> MultiMatrixValue = new List<int[,]>();
            int[,] matrixValue = new int[maxSize + 1, maxSize + 1];
            int m = 0;
            int k = 0;

            string maxErgebnis = string.Empty;
            int maxValue = -100000;
            int minPositionCalc = 600;
            int beforeMaxValue = 0;
            string beforeMaxErgebnis = string.Empty;
            List<string> maxElemente = new List<string>();

            for (int s = quadrat; s <= quadrat; s++)
            {
                matrixValue.Initialize();
                beforeMaxValue = 0;
                maxValue = 0;
                m = 0;
                k = 0;
                for (int i = 1; i < maxSize - s + 1; i++) //x
                {
                    for (int j = 1; j < maxSize - s + 1; j++) //y
                    {
                        m = 0;
                        k = 0;
                        while (m < s)
                        {
                            k = 0;
                            while (k < s)
                            {
                                int value = fuelTank[i + m, j + k];
                                int oldValue = matrixValue[i, j];
                                int newValue = oldValue + value;
                                matrixValue[i, j] = newValue; // fuelTank[i + m, j + k];
                                k++;
                            }
                            m++;
                        }

                        int actualValue = matrixValue[i, j];
                        if (actualValue > maxValue)
                        {
                            maxValue = actualValue;

                            minPositionCalc = i + j;
                            maxErgebnis = i + "x" + j + "," + (s);
                        }

                        //maxErgebnis = matrixValue[i, j] + "," + i + "x" + j + "," + (s);
                        //(maxElemente.Add(maxErgebnis);

                    }

                }

                if (beforeMaxValue < maxValue)
                {
                    beforeMaxValue = maxValue;
                    beforeMaxErgebnis = maxErgebnis;
                    Console.WriteLine("Wert:{0} in {1}", maxValue, maxErgebnis);
                }

                ////Console.WriteLine(printLine);
                ////MultiMatrixValue.Add(matrixValue);
                //Console.WriteLine("Matrix {0}", s);
            }

            //maxElemente.Sort();
            //int max = maxElemente.Count();
            //string ergebnis = maxElemente[max - 1];
            //Console.WriteLine("Matrix {0}", ergebnis);

            //Console.WriteLine("--------------CoordinateMax---------------");
            //for (int s = 0; s < maxSize - 1; s++)
            //{
            //    for (int i = 1; i < maxSize + 1; i++) //x
            //    {
            //        string printLine = string.Empty;
            //        for (int j = 1; j < maxSize + 1; j++) //y
            //        {

            //            //int actualValue = matrixValue[i, j];
            //            int actualValue = MultiMatrixValue[s][i, j];
            //            if (actualValue > maxValue)
            //            {
            //                maxValue = actualValue;

            //                minPositionCalc = i + j;
            //                maxErgebnis = i + "x" + j + "," + (s + 1);

            //            }
            //            else if (actualValue == maxValue)
            //            {
            //                if (i + j < minPositionCalc)
            //                {
            //                    minPositionCalc = i + j;
            //                    maxErgebnis = i + "," + j + "," + (s+1);
            //                }
            //            }
            //        }
            //        //Console.WriteLine(printLine);

            //    }
            //}

            return maxErgebnis;
        }

        private int calculatePowerLevel(int gridSerialNumber, int x, int y)
        {
            int rackID = x + 10;
            int tmp = (((rackID * y) + gridSerialNumber) * rackID);
            int hundretDigit = int.Parse(tmp.ToString().Substring(tmp.ToString().Length - 3, 1));
            return hundretDigit - 5;
        }

        
    }

}

