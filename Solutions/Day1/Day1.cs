using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Day1
{
    class Solution : Problem
    {
        HashSet<int> entries;

        public Solution() : base(1, "Report Repair")
        {
            entries = new HashSet<int>();

            string[] lines = Input.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );

            foreach (var line in lines)
            {
                if (int.TryParse(line, out int i))
                {
                    entries.Add(i);
                }
            }
        }

        protected override string partOne() 
        {
            foreach(int e in entries) 
            {
                int i = 2020 - e;
                if (entries.Contains(i)) 
                {
                    return $"{e * i}";
                }
            }
            
            return "Error: No result found";
        }

        protected override string partTwo() 
        {
             foreach(int i in entries)
            {
                foreach(int j in entries)
                {
                    if (j == i) continue;

                    int k = 2020 - j - i;
                    if (entries.Contains(k)) 
                    {
                        return $"{i * j * k}";
                    }
                }
            }

            return "Error: No result found";
        }
    }
}