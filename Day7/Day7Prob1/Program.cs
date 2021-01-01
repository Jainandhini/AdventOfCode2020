using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day7Prob1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!-7.1");
            Program ps = new Program();
            var bagsCount = ps.CalculateBagCount();
            System.Console.WriteLine($"Final bagsCount: {bagsCount}"); //378
        }
        int CalculateBagCount()
        {
            var path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName,"input.txt");
            var bagsCount = 0;
            var bags = new Dictionary<string, List<string>>();
            if (File.Exists(path))
            {
                string[] lines = System.IO.File.ReadAllLines(path);
                System.Console.WriteLine($"Lines in file: {lines.Length}");
                foreach (var line in lines)
                {
                    var key = line.Substring(0, line.IndexOf("contain")).Trim();
                    var strValues = line.Substring((line.IndexOf("contain") + "contain".Length + 1));
                    var values = strValues.Split(",").ToList();
                    //remove the last character 's' to save key in singular form.
                    bags.Add(key.Remove(key.Length-1), values);
                }
                Console.WriteLine("Total records: " + bags.Count);
                bagsCount = CountValidBags(bags);
            }
            Console.WriteLine($"CalculateBagCount returning count {bagsCount}");
            return bagsCount;
        }

        private int CountValidBags(Dictionary<string, List<string>> bags)
        {
            var myBag = "shiny gold";
            var bagsCount = 0;
            var parents = bags.Where(c=> c.Value.Any(v=>v.IndexOf(myBag) >= 0));
            var finalParents = parents.Select(c => c.Key).ToHashSet();
            /*Console.WriteLine($"finalParents size: {finalParents.Count}");
            foreach(var i in finalParents)
            {
                Console.WriteLine($"{i}");
            }*/
            while (parents.Count() > 0)
            {
                var newParents = new Dictionary<string, List<string>>();
                //Console.WriteLine("Next level parents..");
                foreach (var p in parents)
                {
                    var sub = bags.Where(c => c.Key.Trim()!=myBag && c.Value.Any(v => v.IndexOf(p.Key) >=0)).ToList();
                    //Console.WriteLine($"sub parent {p.Key} size: {sub.Count}");
                    sub.ForEach(l =>  {
                        if (!newParents.ContainsKey(l.Key)) {
                            //Console.WriteLine($"sub item: {l.Key}");
                            newParents.Add(l.Key, l.Value);
                            finalParents.Add(l.Key);
                        }
                        
                    });
                }
                //Console.WriteLine($"newParents size: {newParents.Count}");
                //Console.WriteLine($"finalParents size: {finalParents.Count}");

                parents = newParents;
                //Console.WriteLine($"parents size: {parents.Count()}");

            }
            bagsCount = finalParents.Count();
            Console.WriteLine($"CountValidBags returning {bagsCount}");
            return bagsCount;
        }
    }
}
