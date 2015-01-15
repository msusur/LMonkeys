using System;

namespace LMonkeys.Library
{
    public class LuckyMonkeyGenome
    {
        private readonly Chromosome _chromosome;
        private static readonly ThreadSafeRandom RandomGenerator = new ThreadSafeRandom();

        private LuckyMonkeyGenome(Chromosome chromosome)
        {
            _chromosome = chromosome;
        }

        public int[] Calculate()
        {
            var array = new int[6];

            for (int i = 0; i < array.Length; i++)
            {
                // make prediction of 6 numbers with the factor of current chromosome. keep them less than 49.
                // this place is the core of the operation!! We need to discuss on this one.

                array[i] = Math.Abs((RandomGenerator.Next(1, 49) * _chromosome.Core) % 49);

                // [Not implemented yet]: check if the created random number is in the series. If so, create another one.


                if (array[i] == 0)
                {
                    array[i] = 1;
                }
            }

            return array;
        }

        public static LuckyMonkeyGenome Random()
        {
            // each random monkey has their own random chromosome.
            return new LuckyMonkeyGenome(Chromosome.Random());
        }
    }
}