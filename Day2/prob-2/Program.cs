using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
namespace prob_2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Program ps=new Program();
            ps.ValidatePasswordPolicyNew();
            
        }
        void ValidatePasswordPolicyNew()
        {
            List<PasswordPolicyNew> inputText = new List<PasswordPolicyNew>();
            ReadInput(inputText);
            var validPasswordCount=0;
            foreach(var item in inputText){
                int occurenceCount=0;
                if(item.password[item.index1-1]==item.letter)
                    occurenceCount++; 
                if(item.password[item.index2-1]==item.letter)
                    occurenceCount++;                 
                if(occurenceCount==1)
                    validPasswordCount++;   
                // System.Console.WriteLine($"{item.password} {item.letter} {item.min} {item.max} {occurenceCount}");
            }
            System.Console.WriteLine("Valid passwords count: "+ validPasswordCount);
        }
        void ReadInput(List<PasswordPolicyNew> inputText){
            inputText.Clear();
            var path=@".\input.txt";
            if(File.Exists(path)){
                using (StreamReader sr=File.OpenText(path)){
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] policyList=s.Split(" ");
                        PasswordPolicyNew policy=new PasswordPolicyNew{
                            index1=Int32.Parse(policyList[0].Substring(0,policyList[0].IndexOf("-"))),
                            index2=Int32.Parse(policyList[0].Substring(policyList[0].IndexOf("-")+1)),
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
