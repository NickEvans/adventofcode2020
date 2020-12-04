using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day3
{
    class Solution : Problem
    {
        private string[] map;
        public Solution() : base(3, "Toboggan Trajectory")
        {
            map = Input.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            ).SkipLast(1).ToArray();
        }

        protected override string PartOne()
        {
            int mapWidth = map[0].Length;
            int mapHeight = map.Length;

            List<int[]> trips = new List<int[]>();
            trips.Add(new[] { 3, 1 });

            return countTrees(trips, map, mapWidth, mapHeight)
                .Aggregate((cur, next) => cur * next)
                .ToString();
        }

        protected override string PartTwo()
        {
            int mapWidth = map[0].Length;
            int mapHeight = map.Length;

            List<int[]> trips = new List<int[]>();
            trips.Add(new[] { 1, 1 });
            trips.Add(new[] { 3, 1 });
            trips.Add(new[] { 5, 1 });
            trips.Add(new[] { 7, 1 });
            trips.Add(new[] { 1, 2 });

            return countTrees(trips, map, mapWidth, mapHeight)
                .Aggregate((cur, next) => cur * next)
                .ToString();
        }

        static IEnumerable<long> countTrees(List<int[]> trips, string[] map, int mapWidth, int mapHeight)
        {
            foreach (var trip in trips)
            {
                int x = 0, y = 0;
                long treeCount = 0;
                while (y < mapHeight)
                {
                    if (map[y][x] == '#') treeCount++;
                    x = (x + trip[0]) % mapWidth;
                    y += trip[1];
                }

                yield return treeCount;
            }
        }
    }
}