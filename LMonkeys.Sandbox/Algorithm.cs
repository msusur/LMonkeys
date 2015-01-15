using System;
using System.Linq;

namespace LMonkeys.Sandbox
{
    public class Algorithm
    {
        private readonly LuckyMonkeyGenome[] _genomes;
        private static Lazy<int[]> _availableNumbers = new Lazy<int[]>(BuildAvailableNumbers);
        private static ThreadSafeRandom _random = new ThreadSafeRandom();

        public Algorithm(AlgorithmSettings settings, params LuckyMonkeyGenome[] genomes)
        {
            _genomes = genomes ?? GenomeBuilder.BuildInitialGenomes(settings.InitialPopulationSize).ToArray();
        }

        private static int[] BuildAvailableNumbers()
        {
            var numbers = new int[49];
            for (int i = 0; i < 49; i++)
            {
                numbers[i] = i + 1;
            }
            return numbers;
        }
    }
}