using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day7
{
    class stepDesigner
    {
        public class Step
        {
            public char Name { get; set; }

            public int Time { get; set; }
            public List<char> Before { get; set; } = new List<char>();
        }

        static void Main(string[] args)
        {
            List<string> intListe = new List<string>();
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\input.txt");

            foreach (string line in lines)
            {
                intListe.Add(line);
            }
            stepDesigner step = new stepDesigner();
            string ergebnis = step.findOrder(lines);
            int run = step.getRunTime(lines);
            Console.WriteLine("Ergebnis: {0}", run);
            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();
        }

        public string findOrder(string[] stringArray)
        {
            List<Step> steps = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Select(c => new Step { Name = c }).ToList();
            Step next = null;
            char before = '\0', after = '\0';
            foreach (string line in stringArray)
            {
                MatchCollection matches = Regex.Matches(line, @"\b[A-Z]\b");
                before = char.Parse(matches[0].Value);
                after = char.Parse(matches[1].Value);

                steps.First(s => s.Name == after).Before.Add(before);
            }

            StringBuilder result = new StringBuilder();
            while (steps.Count > 0)
            {
                next = steps.Where(s => s.Before.Count == 0).OrderBy(s => s.Name).First();
                result.Append(next.Name);
                steps.Remove(next);
                steps.ForEach(s => s.Before.Remove(next.Name));
            }

            return result.ToString();
        }


        public int getRunTime(string[] stringListe)
        {
            List<Step> steps = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Select((c, i) => new Step { Name = c, Time = 61 + i }).ToList();
            List<Step> next;
            char before = '\0', after = '\0';
            int workers = 5;
            int sec = 0;
            foreach (string line in stringListe)
            {
                MatchCollection matches = Regex.Matches(line, @"\b[A-Z]\b");
                before = char.Parse(matches[0].Value);
                after = char.Parse(matches[1].Value);

                steps.First(s => s.Name == after).Before.Add(before);
            }

            while (steps.Count > 0)
            {
                next = steps.Where(s => s.Before.Count == 0).OrderBy(s => s.Time).Take(workers).ToList();
                next.ForEach(s => s.Time--);
                steps.ForEach(s => s.Before.RemoveAll(n => steps.Where(p => p.Time == 0).Select(p => p.Name).Contains(n)));
                steps.RemoveAll(s => s.Time == 0);
                sec++;
            }
            return sec;
        }
    }
}
