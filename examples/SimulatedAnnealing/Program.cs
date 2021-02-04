using System;

using OpenJijDotNet;

namespace SimulatedAnnealing
{
    internal class Program
    {

        #region Methods

        private static void Main(string[] args)
        {
            using var rd = new StdRandomDevice();
            using var mt = new StdMt19937(rd);
            using var dist = new StdUniformRealDistribution<double>(1.0, -1.0);
        }

        #region Helpers
        
        private static void ShowSpins(Spins spins)
        {
            foreach (var s in spins)
                Console.Write($"{s} ");
            Console.WriteLine();
        }
        
        #endregion

        #endregion
        
    }

}
