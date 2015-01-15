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
                ? GenomeBuilder.BuildInitialGenomes(settings.InitialPopulationSize).ToArray()
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

        public LuckyMonkeyGenome[] CrossingOver(IEnumerable<LuckyMonkeyGenome> list)
        {
            var luckyMonkeyGenomes = list as LuckyMonkeyGenome[] ?? list.ToArray();
            var genomes = new List<LuckyMonkeyGenome>();

            for (int i = 0; i < luckyMonkeyGenomes.Length; i += 2)
            {
                var child = CrossingOver(luckyMonkeyGenomes[i], luckyMonkeyGenomes[i + 1]);
                genomes.Add(child);
            }
            genomes.AddRange(luckyMonkeyGenomes);
            return genomes.ToArray();
        }

        private LuckyMonkeyGenome CrossingOver(LuckyMonkeyGenome mother, LuckyMonkeyGenome father)
        {
            var motherChromosome = mother.Chromosome;
            var fatherChromosome = father.Chromosome;

            return new LuckyMonkeyGenome(motherChromosome * fatherChromosome);
        }
    }
}