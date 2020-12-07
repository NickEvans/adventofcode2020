using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day4
{
    class Solution : Problem
    {
        readonly string[] reqFields = 
        {
            "byr", "iyr", "eyr", "hgt",
            "hcl", "ecl", "pid"
        };

        string[] passports;

        public Solution() : base(4, "Passport Processing") 
        {
            passports = Input.Split( new string[] { "\r\n\r\n", "\r\r", "\n\n" },
                StringSplitOptions.RemoveEmptyEntries);
        }

        protected override string PartOne()
        {
            return passports.Count(p => hasReqFields(p)).ToString();
        }

        protected override string PartTwo()
        {
            return passports.Count(p => hasValidFields(p)).ToString();
        }

        private bool hasReqFields(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return false;
            }

            foreach (var f in reqFields)
            {
                if (!s.Contains(f))
                {
                    return false;
                }
            }

            return true;
        }

        private bool hasValidFields(string s)
        {
            // Validate birthyear (4 digits, between 1920 & 2002 inclusive)
            Regex byrRx = new Regex(@"byr:([0-9]{4})\b");
            Match m = byrRx.Match(s);
            int byr = 0;
            int.TryParse(m.Groups[1].Value, out byr);
            if (byr > 2002 || byr < 1920) return false;

            // Issue year (between 2010 and 2020 inclusive)
            Regex iyrRx = new Regex(@"iyr:([0-9]{4})\b");
            int iyr = 0;
            int.TryParse(iyrRx.Match(s).Groups[1].Value, out iyr);
            if (iyr < 2010 || iyr > 2020) return false;

            // Expiration year (at least 2020, at most 2030)
            Regex eyrRx = new Regex(@"eyr:([0-9]{4})\b");
            int eyr = 0;
            int.TryParse(eyrRx.Match(s).Groups[1].Value, out eyr);
            if (eyr < 2020 || eyr > 2030) return false;

            // Height
            // for cm, at least 150, at most 193
            // for in, at least 59, at most 76
            Regex hgtRx = new Regex(@"hgt:([0-9]+)(cm|in)\b");
            Match hm = hgtRx.Match(s);
            int hgt = 0;
            int.TryParse(hm.Groups[1].Value, out hgt);
            switch (hm.Groups[2].Value)
            {
                case "cm":
                    if (hgt < 150 || hgt > 193) return false;
                    break;
                case "in":
                    if (hgt < 59 || hgt > 76) return false;
                    break;
                default:
                    return false;
            }

            // Hair color
            Regex hclRx = new Regex(@"hcl:#([0-9]|[a-f]){6}\b");
            if (!hclRx.IsMatch(s)) return false;

            // Eye color
            Regex eclRx = new Regex(@"ecl:(amb|blu|brn|gry|grn|hzl|oth)\b");
            if (!eclRx.IsMatch(s)) return false;

            // Passport ID
            Regex pidRx = new Regex(@"pid:[0-9]{9}\b");
            if (!pidRx.IsMatch(s)) return false;

            return true;
        }
    }
}