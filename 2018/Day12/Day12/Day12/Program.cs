using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day12
{
    public static class test
    {
        //// str - the source string
        //// index- the start location to replace at (0-based)
        //// length - the number of characters to be removed before inserting
        //// replace - the string that is replacing characters
        private static string ReplaceAt(this string str, int index, int length, string replace)
        {
            return str.Remove(index, Math.Min(length, str.Length - index))
                    .Insert(index, replace);
        }
    }

    class PlantCounter  
    {

        static void Main(string[] args)
        {
            PlantCounter mess = new PlantCounter();
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\input.txt");

            foreach (string line in lines)
            {

            }

            int result = mess.count(lines);
            Console.WriteLine("Anzahl plants: {0} ", result);

            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();
        }



        public int count(string[] lines)
        {
            int result = 0;

            List<string> types = new List<string>();
            List<string> results = new List<string>();


            string[] splits = lines[0].Split(' ');
            string prePost = string.Empty;
            int pre = 3000;
            for (int i = 0; i < pre; i++)
            {
                prePost += ".";
            }
            string initialState = prePost + splits[2] + prePost;
            string workingString = initialState;
            string tmpString = initialState;
            string replaceString = string.Empty;
            bool found = false;
            


            for (int i = 2; i < lines.Length; i++ )
            {
                splits = Regex.Split(lines[i], " => ");;
                types.Add(splits[0]);
                results.Add(splits[1]);
            }

            for (long i = 1; i <= 150; i++)
            {
                workingString = tmpString;
                for (int k = 2; k < workingString.Length-3;k++ )
                {
                    found = false;
                    string searchFor = workingString.Substring(k - 2, 5);
                    for (int j = 0; j < types.Count(); j++)
                    {
                        if (searchFor == types[j])
                        {
                            tmpString = ReplaceAt(tmpString, k, 1, results[j]);
                            //tmpString = tmpString.Remove(k, 1).Insert(k, results[j]);
                            found = true;
                            break;
                        }
                    }
                    if (found == false)
                    {
                        tmpString = ReplaceAt(tmpString, k, 1, ".");
                    }
                }
                //Console.WriteLine("{0}:\t{1}", i, tmpString);
                //if (i % 100 == 0)
                //{
                //    Console.WriteLine(i);
                //}

                char search = '#';
                int test = result;

                for (int m = 0; m < tmpString.Length; m++)
                {
                    if (tmpString[m] == search)
                    {
                        test += m - pre;
                    }
                }

                Console.WriteLine(test);
            }




                return result;

        }

        //private string ReplaceAt(string tmpString, int index, int p, string replaceString)
        //{
        //    throw new NotImplementedException();
        //}

        //// str - the source string
        //// index- the start location to replace at (0-based)
        //// length - the number of characters to be removed before inserting
        //// replace - the string that is replacing characters
        private string ReplaceAt( string str, int index, int length, string replace)
        {
            return str.Remove(index, Math.Min(length, str.Length - index))
                    .Insert(index, replace);
        }

    }
}
