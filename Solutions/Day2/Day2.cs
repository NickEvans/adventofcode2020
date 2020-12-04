using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCode2020.Day2
{
    class Solution : Problem
    {
        record passwordData(int n1, int n2, char ch, string pass);
        private string[] lines;

        public Solution() : base(2, "Password Philosophy")
        {
            lines = Input.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );
        }

        protected override string PartOne()
        {
            return lines.Select(parsePassword)
                .Count(p => isValidOne(p))
                .ToString();
        }

        protected override string PartTwo()
        {
            return lines.Select(parsePassword)
                .Count(p => isValidTwo(p))
                .ToString();
        }

        static bool isValidOne(passwordData p)
        {
            if (p.pass == "") return false;
            int count = p.pass.Count(c => c == p.ch);
            return (p.n1 <= count && count <= p.n2);
        }

        static bool isValidTwo(passwordData p)
        {
            if (p.pass == "") return false;
            return (p.pass[p.n1 - 1] == p.ch ^ p.pass[p.n2 - 1] == p.ch);
        }

        static passwordData parsePassword(string p)
        {
            Regex rx = new Regex(@"^(\d+)-(\d+) ([a-z]): ([a-z]+)$");
            Match m = rx.Match(p);
            int.TryParse(m.Groups[1].Value, out int n1);
            int.TryParse(m.Groups[2].Value, out int n2);
            char.TryParse(m.Groups[3].Value, out char ch);
            string pass = m.Groups[4].Value;
            return new passwordData(n1, n2, ch, pass);
        }
    }
}