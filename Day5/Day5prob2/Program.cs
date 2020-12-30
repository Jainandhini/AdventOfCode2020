using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
namespace Day5problem2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!-5.1");
            Program ps=new Program();            
            var seatId=ps.CalculateSeatId();
            System.Console.WriteLine($"Final max seat ID: {seatId}"); //678
        }
        int CalculateSeatId(){
            var path=@".\input.txt";
            var mySeatID=0; 
            SortedSet<int> seatList=new SortedSet<int>();
            if(File.Exists(path)){
                string[] lines=System.IO.File.ReadAllLines(path);
                System.Console.WriteLine($"Lines in file: {lines.Length}");
                foreach(var line1 in lines){
                    var line=line1.Trim();
                    if(line==null || line.Length==0) {
                        continue;
                    }
                    var rowId= CalculateRowId(line.Substring(0,7));
                    var colId= CalculateColumnId(line.Substring(7,3));
                    var currentSeatId= rowId*8+colId;
                    //System.Console.WriteLine($"{line} Row {rowId} Col {colId} Current: {currentSeatId} ");
                    seatList.Add(currentSeatId);
                }
            } 
            var first=seatList.FirstOrDefault();
            var last= seatList.LastOrDefault();
            var firstRowsPrefix=firstDigit(first);
            var lastRowsPrefix=firstDigit(last);
            System.Console.WriteLine($"f {first} i {firstRowsPrefix} l {last} i {lastRowsPrefix}");
            var missingSeats= seatList.Where(s=> ((!seatList.Contains(s-1))&&seatList.Contains(s-2)) || ((!seatList.Contains(s+1))&&seatList.Contains(s+2)))
                            .SkipWhile(s=>firstDigit(s)==firstRowsPrefix || firstDigit(s)==lastRowsPrefix);
            System.Console.WriteLine($"missing seats: {missingSeats.Count()}");
            foreach(var i in missingSeats){
                System.Console.WriteLine($"{i}");
            }
            if(missingSeats.Count()==2){
                mySeatID= missingSeats.Last()-1;
            }
            return mySeatID;
            }
            private int firstDigit(int num){
                return Int32.Parse(num.ToString().Substring(0,1));
            }
            public int CalculateRowId(string value, int index=0, int upper=127, int lower=0){
                var row=0;
                char c;
                c= value.ElementAt(index);
                //System.Console.WriteLine($"String {value} c {c} upper {upper} lower {lower}");
                if(upper-lower==1 ){
                    row= c=='F'? lower:upper;
                    //System.Console.WriteLine($"Returning final row {row}");
                    return row;
                }
                else{
                    var mid= upper- ((upper-lower)/2);
                    //System.Console.WriteLine($"{lower} {upper}  {mid}");
                    switch(c){
                        case 'F':
                            upper= mid-1; 
                           // System.Console.WriteLine($" upper changed to {upper}");
                            break;
                        case 'B':
                            lower= mid; 
                            //System.Console.WriteLine($" lower changed to {lower}");
                            break;
                            }
                    if(index+1==value.Length){
                        row= c=='F'? lower:upper;
                        //System.Console.WriteLine($"Returning final row {row} as index ends");
                        return row;
                    }                                   
                    return CalculateRowId(value,++index,upper, lower);
                }
            }
            public int CalculateColumnId(string value, int index=0, int upper=7, int lower=0){
                var col=0;char c;
                c= value.ElementAt(index);
                //System.Console.WriteLine($"String {value} c {c} upper {upper} lower {lower}");
                if(upper-lower==1){
                    col= c=='L'? lower:upper;
                    //System.Console.WriteLine($"Returning final col {col}");
                    return col;
                }
                else{
                    var mid= upper- ((upper-lower)/2);
                    //System.Console.WriteLine($"{lower} {upper}  {mid}");
                    switch(c){
                        case 'L':
                            upper= mid-1; break;
                        case 'R':
                            lower= mid; break;
                    }
                    if(index+1==value.Length){
                        col= c=='L'? lower:upper;
                        //System.Console.WriteLine($"index going to end Returning final col {col}");
                        return col;
                    }    
                    return CalculateColumnId(value,++index,upper, lower);
                }
            }
    }
}
