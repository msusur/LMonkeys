using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LMonkeys.Library
{
    public static class ResultComparer
    {
        static class ArrayComparer
        {
            public static int CompareAndCreateScore(IEnumerable<int> array1, IEnumerable<int> array2)
            {
                var a1 = array1.OrderBy(i => i).ToArray();
                var a2 = array2.OrderBy(i => i).ToArray();
                return a1.Count(t => a2.Any(x => x == t));
            }
        }

        public static IEnumerable<CompareResult> CompareScore(IEnumerable<int> ints, IEnumerable<CalculationResult> results)
        {
            return from calculationResult in results
                   let score = ArrayComparer.CompareAndCreateScore(ints, calculationResult.Result)
                   select new CompareResult
                    {
                        Genome = calculationResult.ResponsibleMonkey,
                        Score = score
                    };
        }

        public static IEnumerable<LuckyMonkeyGenome> SortByScoreAverage(IEnumerable<CompareResult> compareResults)
        {
            // should we think of average score?
            var enumerable = compareResults as CompareResult[] ?? compareResults.ToArray();

            var avg = enumerable.Average(r => r.Score);
            
            Console.WriteLine("Average Score is : '{0}'; Number of results over average: '{1}'.", 
                avg, 
                enumerable.Count(r => r.Score > avg));

            return enumerable.OrderBy(r => r.Score).Select(g => g.Genome);
        }
    }
}