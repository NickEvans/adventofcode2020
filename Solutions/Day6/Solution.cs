using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Day6
{
    class Solution : Problem
    {
        string[] responses;

        public Solution() : base(6, "Custom Customs")
        {
            responses = Input.Split( new string[] { "\r\n\r\n", "\r\r", "\n\n" },
                StringSplitOptions.RemoveEmptyEntries);
        }

        protected override string PartOne()
        {
            int sum = 0;
            var responseSet = new HashSet<char>();
            foreach (string s in responses)
            {
                foreach (char c in s)
                {
                    if (Char.IsLetter(c))
                        responseSet.Add(c);
                }
                sum = sum + responseSet.Count;
                responseSet.Clear();
            }
            return sum.ToString();
        }

        protected override string PartTwo()
        {
            int sum = 0;
            var resDict = new Dictionary<char, int>();

            foreach (string r in responses)
            {
                string[] lines = r.Split( new string[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);

                foreach (var l in lines)
                {
                    foreach (char c in l)
                    {
                        if (Char.IsLetter(c))
                        {
                            if (resDict.ContainsKey(c))
                                resDict[c]++;
                            else
                                resDict.Add(c, 1);
                        }
                    }
                }

                foreach (var d in resDict)
                {
                    if (d.Value == lines.Length)
                        sum++;
                }

                resDict.Clear();
            }

            return sum.ToString();
        }
    }
}