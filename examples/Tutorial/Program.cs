using System;

using OpenJijDotNet;

namespace Tutorial
{
    internal class Program
    {

        #region Methods

        private static void Main(string[] args)
        {
            //generate dense graph with size N=5
            const uint N = 500;
            using var dense = new OpenJijDotNet.Graph.Dense<double>(N);

            //set interactions
            for (uint i = 0; i < N; i++)
            {
                for (uint j = 0; j < N; j++)
                {
                    // dense.J(i, j) = (i == j) ? 0 : -1;
                }
            }

            //set local fields
            for (uint i = 0; i < N; i++)
            {
                // dense.h(i) = -1;
            }
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
