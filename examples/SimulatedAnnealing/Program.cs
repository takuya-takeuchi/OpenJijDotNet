using System;

using OpenJijDotNet;

namespace SimulatedAnnealing
{
    internal class Program
    {

        #region Methods

        private static void Main(string[] args)
        {
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
