using System.Collections.Generic;
using System.Linq;

namespace LMonkeys.Library
{
    public class Algorithm
    {
        private readonly LuckyMonkeyGenome[] _genomes;

        public Algorithm(AlgorithmSettings settings, params LuckyMonkeyGenome[] genomes)
        {
            // if any _genomes are initially provided then use them. Else generate your own genomes randomly.
            _genomes = genomes == null || genomes.Length == 0 
                ?  GenomeBuilder.BuildInitialGenomes(settings.InitialPopulationSize).ToArray() 
                : genomes;
        }

        public IEnumerable<CalculationResult> Calculate()
        {
            // iterate over each genome, then make them calculate.
            return _genomes.Select(luckyMonkeyGenome => new CalculationResult
            {
                Result = luckyMonkeyGenome.Calculate(),
                ResponsibleMonkey = luckyMonkeyGenome
            });
        }
    }
}