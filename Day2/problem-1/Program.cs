using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
namespace problem_1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Program ps=new Program();
            ps.ValidatePasswordPolicy();
            
        }
        void ValidatePasswordPolicy()
        {
            List<PasswordPolicy> inputText = new List<PasswordPolicy>();
            ReadInput(inputText);
            var validPasswordCount=0;
            foreach(var item in inputText){
                int occurenceCount=0;
                occurenceCount = item.password.Count(l => l == item.letter);
                
                if(occurenceCount>=item.min && occurenceCount<=item.max)
                    validPasswordCount++;
                // System.Console.WriteLine($"{item.password} {item.letter} {item.min} {item.max} {occurenceCount}");
            }
            System.Console.WriteLine("Valid passwords count: "+ validPasswordCount);
        }
        void ReadInput(List<PasswordPolicy> inputText){
            inputText.Clear();
            var path=@".\input.txt";
            if(File.Exists(path)){
                using (StreamReader sr=File.OpenText(path)){
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] policyList=s.Split(" ");
                        PasswordPolicy policy=new PasswordPolicy{
                            min=Int32.Parse(policyList[0].Substring(0,policyList[0].IndexOf("-"))),
                            max=Int32.Parse(policyList[0].Substring(policyList[0].IndexOf("-")+1)),
                            letter=Char.Parse(policyList[1].Substring(0,policyList[1].IndexOf(":"))),
                            password=policyList[2]
                        };
                        inputText.Add(policy);
                    }
                }
            }
            }
        
       
    }
}
