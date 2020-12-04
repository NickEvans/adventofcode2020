using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    class Driver
    {
        private IEnumerable<Problem> solutions;
        public Driver(string[] args)
        {
            solutions = collectSolutions(args);
        }

        public void Run()
        {
            foreach (var sol in solutions)
            {
                int partNo = 1;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"=== Day {sol.Day}: {sol.Title} ===");
                Console.ForegroundColor = ConsoleColor.White;

                var stringEnum = sol.Solve().GetEnumerator();
                while (true)
                {
                    var tick = DateTime.Now;
                    if (!stringEnum.MoveNext()) break;
                    var tock = DateTime.Now;
                    var timeElapsed = (tock - tick).TotalMilliseconds;
                    Console.WriteLine($"  Part {partNo++}: {stringEnum.Current} ({timeElapsed} ms)");
                }
                
                Console.WriteLine();
            }
        }

        private IEnumerable<Problem> collectSolutions(string[] d)
        {
            int[] days = { };

            if (d.Length < 1)
            {
                // Default to all days
                days = Enumerable.Range(1, 25).ToArray();
            }
            else
            {
                int i = 0;
                days = (from str in d
                    where int.TryParse(str, out i)
                    select i).ToArray();
            }

            foreach (var day in days)
            {
                var solution = Type.GetType($"AdventOfCode2020.Day{day}.Solution");
                if (solution != null)
                {
                    yield return (Problem)Activator.CreateInstance(solution);
                }
            }
        }
    }
}
