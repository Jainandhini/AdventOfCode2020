using System;
using System.IO;
namespace Day3problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!-3.2");
            Program ps=new Program();
            /*
            Right 1, down 1.
            Right 3, down 1. (This is the slope you already checked.)
            Right 5, down 1.
            Right 7, down 1.
            Right 1, down 2.
            Hello World!-3.2
                ps.CalculateTreeCount(1, 1): 55 count: 55
                ps.CalculateTreeCount(3, 1): 250 count: 13750
                ps.CalculateTreeCount(5, 1): 54 count: 742500
                ps.CalculateTreeCount(7, 1): 55 count: 40837500
                ps.CalculateTreeCount(1, 2): 26 count: 1061775000
                Tree count: 1061775000
            */
            var trees=1;
            trees*=ps.CalculateTreeCount(1, 1);
            System.Console.WriteLine($"ps.CalculateTreeCount(1, 1): {ps.CalculateTreeCount(1, 1)} count: {trees}");
            trees*=ps.CalculateTreeCount(3, 1);
            System.Console.WriteLine($"ps.CalculateTreeCount(3, 1): {ps.CalculateTreeCount(3, 1)} count: {trees}");
            trees*=ps.CalculateTreeCount(5, 1);
            System.Console.WriteLine($"ps.CalculateTreeCount(5, 1): {ps.CalculateTreeCount(5, 1)} count: {trees}");
            trees*=ps.CalculateTreeCount(7, 1);
            System.Console.WriteLine($"ps.CalculateTreeCount(7, 1): {ps.CalculateTreeCount(7, 1)} count: {trees}");
            trees*=ps.CalculateTreeCount(1, 2);
            System.Console.WriteLine($"ps.CalculateTreeCount(1, 2): {ps.CalculateTreeCount(1, 2)} count: {trees}");
            System.Console.WriteLine($"Tree count: {trees}");
        }
        int CalculateTreeCount(int xIndex,int yIndex){
            if(yIndex==0) return 0; //cannot progress to bottom row
            var path=@".\input.txt";
            var treeCount=0;
            var _yIndexCounter=1;
            if(File.Exists(path)){
                using (StreamReader sr=File.OpenText(path)){
                    string s;
                    var lineNumber=0;
                    var targetIndex=xIndex;
                    while ((s = sr.ReadLine()) != null)
                    {
                        lineNumber++;
                        if(lineNumber==1) continue;
                        var lineLength=s.Length;
                        var adjustedTargetIndex=targetIndex;
                        if(targetIndex>=lineLength){
                            adjustedTargetIndex=targetIndex%lineLength;
                        }
                        
                        //System.Console.WriteLine($"Line {lineNumber} Length {lineLength} threeIndex {xIndex} adjustedTargetIndex {adjustedTargetIndex} value {s.Substring(adjustedTargetIndex,1)} ");
                        
                        if(_yIndexCounter==yIndex && s.Substring(adjustedTargetIndex,1)=="#"){
                            treeCount++;
                            //System.Console.WriteLine($" treeCount {treeCount}");
                        }
                        if(_yIndexCounter==yIndex){
                            _yIndexCounter=1;
                        }
                        else{
                            _yIndexCounter++;
                        }
                        
                        targetIndex+=xIndex;
                    }
                }
                //System.Console.WriteLine($"Tree count: {treeCount}");
            }
            return treeCount;
            }
    }
}
