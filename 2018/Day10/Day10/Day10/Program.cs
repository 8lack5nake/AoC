using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day10
{
    class MessageFinder
    {
        static void Main(string[] args)
        {
            MessageFinder mess = new MessageFinder();
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\input.txt");

            foreach (string line in lines)
            {
                
            }

            mess.writeMessage(lines);
            Console.WriteLine("Fertig!f");

            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();
        }

        public void writeMessage(string[] lines)
        {
            List<string> coordinates = new List<string>();
            int positionX = 0;
            int positionY = 0;
            int velocityX = 0;
            int velocityY = 0;
            string position = string.Empty;
            string velocity = string.Empty;
            string line = string.Empty;

            for (int i = 0; i < lines.Length; i++)
            {

                var regex = new Regex(@"position=<\s?(-?\d+), \s?(-?\d+)> velocity=<\s?(-?\d+), \s?(-?\d+)>");
                var match = regex.Match(lines[i]);

                positionX = int.Parse(match.Groups[1].Value);
                positionY = int.Parse(match.Groups[2].Value);
                velocityX = int.Parse(match.Groups[3].Value);
                velocityY = int.Parse(match.Groups[4].Value);

                line = positionX + "," + positionY + "," + velocityX + "," + velocityY;

                coordinates.Add(line);
            }


            for (int i = 0; i < 100000; i++) 
            {
                int minX = 0;
                int minY = 0;
                int maxX = 0;
                int maxY = 0;
                bool found = false;

                

                for(int j = 0; j< coordinates.Count(); j++)
                {
                    string[] split = coordinates[j].Split(',');
                    positionX = int.Parse(split[0]) + int.Parse(split[2]);
                    positionY = int.Parse(split[1]) + int.Parse(split[3]);
                    //velocityX = int.Parse(split[2]);
                    //velocityY = int.Parse(split[3]);

                    if (positionX < minX)
                    {
                        minX = positionX;
                    }

                    if (positionX > maxX)
                    {
                        maxX = positionX;
                    }

                    if (positionY < minY)
                    {
                        minY = positionY;
                    }

                    if (positionY > maxY)
                    {
                        maxY = positionY;
                    }
                    coordinates[j] = positionX + "," + positionY + "," + split[2] + "," + split[3];
                }

                if (i > 10639)
                {
                    Console.WriteLine("----------Second {0}----------", i);
                    for (int m = minY; m <= maxY; m++)
                    {
                        string printLine = string.Empty;
                        for (int j = minX; j <= maxX; j++)
                        {
                            for (int k = 0; k < coordinates.Count(); k++)
                            {

                                string[] split = coordinates[k].Split(',');
                                positionX = int.Parse(split[0]);
                                positionY = int.Parse(split[1]);
                                if (positionX == j && positionY == m)
                                {
                                    found = true;
                                }

                            }

                            if (found == true)
                            {
                                printLine += "#";
                                //Console.Write('#');
                                found = false;
                            }
                            else
                            {
                                printLine += ".";
                                //Console.Write('.');
                            }

                        }

                        Console.WriteLine(printLine);
                    }
                }
            }

        }
    }
}
