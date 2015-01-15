namespace LMonkeys.Library
{
    public class Chromosome
    {
        public int Core { get; private set; }

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