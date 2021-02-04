using System;
using System.Diagnostics;

using OpenJijDotNet;
using OpenJijDotNet.Algorithms;
using OpenJijDotNet.Graphs;
using OpenJijDotNet.Results;
using OpenJijDotNet.Systems;
using OpenJijDotNet.Updaters;

namespace Tutorial
{
    internal class Program
    {

        #region Methods

        private static void Main(string[] args)
        {
            //generate dense graph with size N=5
            const uint N = 500;
            using var dense = new Dense<double>(N);

            //set interactions
            for (uint i = 0; i < N; i++)
            {
                for (uint j = 0; j < N; j++)
                {
                    dense.J[i, j] = (i == j) ? 0 : -1;
                }
            }

            //set local fields
            for (uint i = 0; i < N; i++)
            {
                dense.H[i] = -1;
            }

            //generate random engine (mersenne twister)
            using var randRngine = new StdMt19937(0x1234);

            //create classical Ising system
            using var system = OpenJij.MakeClassicalIsing<Dense<double>>(dense.GenSpin(randRngine), dense);

            //generate schedule list
            //from beta=0.1 to beta=100, 10 samples, 10 Monte Carlo step for each tempearature
            using var scheduleList = OpenJij.MakeClassicalScheduleList(0.1, 100, 10, 200);

            //do annealing (updater: SingleSpinFlip)
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Algorithm<SingleSpinFlip>.Run(system, randRngine, scheduleList);
            stopWatch.Stop();

            double ticks = stopWatch.ElapsedTicks;
            double time = (ticks / Stopwatch.Frequency) * 1000;
            Console.WriteLine($"time {time}[ms]");

            //show spins
            Console.Write("The result spins are [");
            foreach (var elem in Result.GetSolution(system))
                Console.Write($"{elem} ");

            Console.WriteLine("]");
        }
        
        #endregion

    }

}
