using System.Collections.Generic;

namespace LMonkeys.Sandbox
{
    public static class GenomeBuilder
    {
        public static IEnumerable<LuckyMonkeyGenome> BuildInitialGenomes(int populationSize)
        {
            for (int i = 0; i < populationSize; i++)
            {
                yield return LuckyMonkeyGenome.Random();
            }
        }
    }
}