using System;
using System.Collections.Generic;
using System.IO;

namespace Day6Prob1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!-6.1");
            Program ps = new Program();
            var questionsCount = ps.CalculateNoQuestions();
            System.Console.WriteLine($"Final questionsCount: {questionsCount}"); //6911
        }
        int CalculateNoQuestions()
        {
            var path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName,"input.txt");
            var questionsCount = 0;
            var questions = new SortedSet<char>();
            if (File.Exists(path))
            {
                string[] lines = System.IO.File.ReadAllLines(path);
                System.Console.WriteLine($"Lines in file: {lines.Length}");
                foreach (var line1 in lines)
                {
                    var line = line1.Trim();
                    if (line == null || line.Length == 0)
                    {
                        questionsCount += questions.Count;
                        questions.Clear();
                        questions = new SortedSet<char>();
                        continue;
                    }
                    foreach(var c in line.ToCharArray())
                    {
                        questions.Add(c);
                    }
                    
                }
                //last group
                questionsCount += questions.Count;
            }
            Console.WriteLine($"returning count {questionsCount}");
            return questionsCount;
        }
    }
}
