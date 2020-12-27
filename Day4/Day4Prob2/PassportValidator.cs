using System.Text.RegularExpressions;
using System;
namespace Day4problem2{
    public static class PassportValidator{
        public static bool IsValidByr(this string byr){
            return byr!=null && byr.Length==4 && Int32.TryParse(byr, out int val) && (val>=1920 && val<=2002);
        }
        public static bool IsValidIyr(this string iyr){
            return iyr!=null && iyr.Length==4 && Int32.TryParse(iyr, out int val) && (val>=2010 && val<=2020);
        }

        public static bool IsValidEyr(this string eyr){
            return eyr!=null && eyr.Length==4 && Int32.TryParse(eyr, out int val) && (val>=2010 && val<=2030);
        }

        public static bool IsValidHgt(this string hgt){
            if(hgt==null || hgt.Length<4){
                return false;
            }
            var unit=hgt.ReverseString().Substring(0,2).ReverseString();
            var result=false;
            var hasParsed = Int32.TryParse(hgt.Substring(0,hgt.Length-2), out int val);
            if(hasParsed){
            switch(unit){
                case "cm":
                    if(val>=150 && val<=193) result=true; break;
                case "in":
                    if(val>=59 && val<=76) result=true; break;
                default: break;
            }}
            return result;
        }
        public static bool IsValidHcl(this string hcl){
            if(hcl==null || hcl.Length<7){
                return false;
            }
           //  a # followed by exactly six characters 0-9 or a-f.
            Regex rgx = new Regex(@"\A#[0-9A-Fa-f]{6}\b");
            var result=false;
            if (rgx.IsMatch(hcl)){
                result= true;
            }            
            return result;
        }

        public static bool IsValidEcl(this string ecl){
            if(ecl==null || ecl.Length!=3){
                return false;
            }
           //  exactly one of: amb blu brn gry grn hzl oth.
            Regex rgx = new Regex(@"\b(?:amb|blu|brn|gry|grn|hzl|oth){1}\b");            
            var result=false;
            if (rgx.IsMatch(ecl)){
                result= true;
            }            
            return result;
        }

        public static bool IsValidPid(this string pid){
            if(pid==null || pid.Length!=9){
                return false;
            }
           //  a # followed by exactly six characters 0-9 or a-f.
            Regex rgx = new Regex(@"\b[0-9]{9}\b");
            var result=false;
            if (rgx.IsMatch(pid)){
                result= true;
            }            
            return result;
        }
        static string ReverseString(this string s)
            {
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            return new string(array);
            }                                           
    }
}