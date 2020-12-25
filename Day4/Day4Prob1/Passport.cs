namespace Day4problem1
{
    public class Passport
    {
        public string byr { get; set; }
        public string iyr { get; set; }
        public string eyr { get; set; }
        public string hgt { get; set; }
        public string hcl { get; set; }
        public string ecl { get; set; }
        public string pid { get; set; }
        public string cid { get; set; }

        public bool IsValidRecord => byr!=null && iyr!=null && eyr!=null && hgt!=null && hcl!=null && ecl!=null && pid!=null;
    }
}