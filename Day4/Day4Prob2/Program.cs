using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
namespace Day4problem2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!-4.1");
            Program ps=new Program();            
            int count=0;
            count=ps.CalculateValidPassports();
            System.Console.WriteLine($"Valid passports: {count}"); //156
        }
        int CalculateValidPassports(){
            var path=@".\input.txt";
            var count=0;
            var recordCounter=0; 
            List<Passport> passports=new List<Passport>();
            if(File.Exists(path)){
                string[] lines=System.IO.File.ReadAllLines(path);
                var details=new Passport();
                var lineCounter=0;              
                System.Console.WriteLine($"Lines in file: {lines.Length}");
                foreach(var line1 in lines){
                    lineCounter++;
                    var line=line1.Trim();
                    //if new line, it means end of record so add the current passport record to list and create new instance for next record.
                    if(line==null || line.Length==0) {
                        ++recordCounter;
                        if(details.IsValidRecord){
                            count++;
                        }
                        System.Console.WriteLine($"Record#{recordCounter} line {lineCounter} byr {details.byr} pid {details.pid} etc isValidRecord {details.IsValidRecord}, #validrecords {count}");

                        passports.Add(details);
                        details=new Passport();
                        continue;
                    }
                    var pairs=line.Split(" ");
                    if(pairs.Length==0){
                        var item=line.Split(":");
                        MapToPassport(details, item[0],item[1]);
                    }
                    else{
                        foreach(var pair in pairs){
                        var item=pair.Split(":");
                        MapToPassport(details,item[0],item[1]);
                        }
                    }
                    
                }
                //last record
                if(details.IsValidRecord){
                    count++;
                }
                passports.Add(details);
                System.Console.WriteLine($"Total lines {lineCounter}");
            }
            System.Console.WriteLine($"Final count: {count} ");
            return count;
            }
            public void MapToPassport(Passport passport, string key, string value){
                switch (key)
                {
                    case "byr":
                    passport.byr=value;
                    break;

                    case "iyr":
                    passport.iyr=value;
                    break;

                    case "eyr":
                    passport.eyr=value;
                    break;

                    case "hgt":
                    passport.hgt=value;
                    break;

                    case "hcl":
                    passport.hcl=value;
                    break;

                    case "ecl":
                    passport.ecl=value;
                    break;

                    case "pid":
                    passport.pid=value;
                    break;

                    case "cid":
                    passport.cid=value;
                    break;
                    default:
                    break;
                }
            }

    }
}
