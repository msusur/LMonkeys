using System;
using System.Collections.Generic;
using System.Linq;
using LMonkeys.Library;

namespace LMonkeys.Sandbox
{
    static class Program
    {
        static void Main()
        {
            var settings = new AlgorithmSettings { InitialPopulationSize = 100 };
            var genomes = new LuckyMonkeyGenome[0];
            var generations = 100;

            while (generations > 0)
            {
                generations--;

                var algorithm = new Algorithm(settings, genomes);

                var results = algorithm.Calculate().ToArray();

                // after making the calculations, we need to compare the real numbers with the results.
                var compareResults = ResultComparer.CompareScore(new[] { 12, 33, 45, 67, 22, 55 }, results);

                // after making the comparation, order them by the rating 
                var genomesList = ResultComparer.SortByScoreAverage(compareResults);

                // kill the last half of it.
                genomesList = genomesList.DivideIntoTwoAndGetTop();

                genomes = algorithm.CrossingOver(genomesList);
                
                //add some random
                var randomGenomes= GenomeBuilder.BuildInitialGenomes(25).ToArray();
                var list = new List<LuckyMonkeyGenome>(genomes);
                list.AddRange(randomGenomes);

                genomes = list.ToArray();
            }

            Console.Read();
            /*
             couple the remainings and create new ones.
                      - Convert the Chromosome to byte[] 
                      - crossing-over between two best genome (
                      example;
                        Chromosome A = 12,34,22,45,66,33,55,44
                        Chromosome B = 23, 4, 2,99,24,45,98,44
             *          A'  => 12,34,22,45 (first half)
             *          A'' => 66,33,55,44 (second half)
             *          B'  => 23, 4, 2,99 (first half)
             *          B'' => 24,45,98,44 (second half)
             *       Pick either A' or B' then if you pick A' pick B'' and if you pick B' then pick A'' to create C.
             *       So C would be;
             *       C = A' + B'' 
             *       or 
             *       C =  B' + A''
             *       add the new born child to the pool.
            */

            // save the new pool to a file and name it second generation.

            // Repeat the cycle.

        }
    }
}