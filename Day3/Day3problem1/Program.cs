using System;
using System.IO;
namespace Day3problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Program ps=new Program();
            ps.CalculateTreeCount();
        }
        void CalculateTreeCount(){
            var path=@".\input.txt";
            var treeCount=0;
            if(File.Exists(path)){
                using (StreamReader sr=File.OpenText(path)){
                    string s;
                    var threeOneDownItemIndex=3;
                    var lineNumber=0;
                    while ((s = sr.ReadLine()) != null)
                    {
                        lineNumber++;
                        if(lineNumber==1) continue;
                        var lineLength=s.Length;
                        var targetIndex=threeOneDownItemIndex;
                        if(threeOneDownItemIndex>=lineLength){
                            targetIndex=threeOneDownItemIndex%lineLength;
                        }
                        
                        //System.Console.WriteLine($"Line {lineNumber} Length {lineLength} threeIndex {threeOneDownItemIndex} targetIndex {targetIndex} value {s.Substring(targetIndex,1)} ");
                        
                        if(s.Substring(targetIndex,1)=="#"){
                            treeCount++;
                            //System.Console.WriteLine($" treeCount {treeCount}");
                        }
                        
                        threeOneDownItemIndex+=3;
                    }
                }
                System.Console.WriteLine($"Tree count: {treeCount}");
            }
            }
    }
}
