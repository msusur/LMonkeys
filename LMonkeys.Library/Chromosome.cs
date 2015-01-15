using System;
using System.Collections;
using System.Linq;

namespace LMonkeys.Library
{
    public class Chromosome
    {
        public int Core { get; private set; }

        public static Chromosome operator *(Chromosome mother, Chromosome father)
        {
            var motherBits = new BitArray(new[] { mother.Core });
            var fatherBits = new BitArray(new[] { father.Core });
            var mArray = new bool[motherBits.Length];
            var fArray = new bool[fatherBits.Length];

            motherBits.CopyTo(mArray,0);
            fatherBits.CopyTo(fArray,0);

            var childArray = new bool[32];

            Array.Copy(mArray, 0, childArray, 0, 16);
            Array.Copy(fArray, 16, childArray, 16, 16);

            var childBits = new BitArray(childArray);

            var value = new int[1];
            childBits.CopyTo(value, 0);
            return new Chromosome(value[0]);
        }

        private Chromosome(int value)
        {
            Core = value;
        }

        public static Chromosome Random()
        {
            // all is random!
            return new Chromosome(GenomeBuilder.Random.Next());
        }
    }
}