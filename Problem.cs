using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020
{
    abstract class Problem
    {
        public string Title { get; }
        public int Day { get; }
        public string Input;

        private protected Problem(int day, string title)
        {
            (Day, Title) = (day, title);
            Input = loadInput();
        }
        
        public IEnumerable<string> Solve() 
        {
            if (Input == "") yield break;
            yield return PartOne();
            yield return PartTwo();
        }

        protected string loadInput()
        {
            string _input = "";

            string filePath = $"Solutions/Day{Day}/input.txt";
            if (File.Exists(filePath)) 
            {
                _input = File.ReadAllText(filePath);
            } 
            else 
            {
                Console.WriteLine($"  Missing input.txt for Day {Day}");
            }
            

            return _input;
        }

        protected abstract string PartOne();
        protected abstract string PartTwo();
    }
}