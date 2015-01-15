using LMonkeys.Library;

namespace LMonkeys.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new AlgorithmSettings { InitialPopulationSize = 100 };

            var algorithm = new Algorithm(settings);
        }
    }
}
