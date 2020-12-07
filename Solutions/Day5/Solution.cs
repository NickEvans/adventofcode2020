using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Day5
{
    class Solution : Problem
    {
        private string[] BoardingPasses;

        public Solution() : base(5, "Binary Boarding")
        {
            BoardingPasses = Input.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );
        }

        protected override string PartOne()
        {
            int highestSeatID = 0;
            foreach (var b in BoardingPasses)
            {
                var seatID = getSeatID(b);
                highestSeatID = Math.Max(highestSeatID, seatID);
            }
            return highestSeatID.ToString();
        }

        protected override string PartTwo()
        {
            var seatMap = new HashSet<int>();
            foreach (var b in BoardingPasses)
            {
                seatMap.Add(getSeatID(b));
            }

            int maxID = Int32.Parse(PartOne());
            for (var i = 0; i <= maxID; i++)
            {
                if (!seatMap.Contains(i))
                {
                    if (seatMap.Contains(i + 1) && seatMap.Contains(i - 1))
                    {
                        return i.ToString();
                    }
                }
            }

            return "ERROR: No seat found!";
        }

        private int getSeatID(string pass)
        {
            string binarySeat = pass.Replace('B', '1')
                .Replace('F', '0')
                .Replace('R', '1')
                .Replace('L', '0');

            int row = Convert.ToInt32(binarySeat.Substring(0, 7), 2);
            int seat = Convert.ToInt32(binarySeat.Substring(7, 3), 2);

            return (row * 8) + seat;
        }
    }
}
