using System.Linq;
using LMonkeys.Library;

namespace LMonkeys.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new AlgorithmSettings { InitialPopulationSize = 100 };

            var algorithm = new Algorithm(settings);

            var results = algorithm.Calculate().ToArray();

            // after making the calculations, we need to compare the real numbers with the results.
            //results = ResultComparer.Compare(new int[] { 12, 33, 45, 67, 22, 55 }, results);

            // after making the comparation, order them by the rating 

            // kill the last half of it.

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
