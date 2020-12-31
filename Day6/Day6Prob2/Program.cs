using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6Prob2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!-6.2");
            Program ps = new Program();
            var questionsCount = ps.CalculateNoQuestions();
            System.Console.WriteLine($"Final questionsCount: {questionsCount}"); //3473
        }
        int CalculateNoQuestions()
        {
            var path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName,"input.txt");
            var questionsCount = 0;
            var questionsPerPerson = new SortedSet<char>();
            var groupsResponse = new List<SortedSet<char>>();
            if (File.Exists(path))
            {
                string[] lines = System.IO.File.ReadAllLines(path);
                System.Console.WriteLine($"Lines in file: {lines.Length}");
                foreach (var line1 in lines)
                {
                    var line = line1.Trim();
                    if (line == null || line.Length == 0)
                    {
                        questionsCount += CountValidAnswers(groupsResponse);
                        //move to next group
                        groupsResponse = new List<SortedSet<char>>();
                        continue;
                    }
                    foreach(var c in line.ToCharArray())
                    {
                        questionsPerPerson.Add(c);
                    }
                    groupsResponse.Add(questionsPerPerson);
                    //move to next person's response in same group
                    questionsPerPerson = new SortedSet<char>();

                }
                //calculate valid answers for last group
                questionsCount += CountValidAnswers(groupsResponse);
            }
            Console.WriteLine($"returning count {questionsCount}");
            return questionsCount;
        }

        private int CountValidAnswers(List<SortedSet<char>> groupsResponse)
        {
            var peopleCount = groupsResponse.Count;
            var answers = groupsResponse.SelectMany(c => c).GroupBy(c => c).Where(c=>c.Count()==peopleCount).Select(c=>c.Key);
            Console.WriteLine($"returning {answers.Count()}");
            return answers.Count();
        }
    }
}
