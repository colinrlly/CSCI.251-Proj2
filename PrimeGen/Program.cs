/*
 * Colin Reilly
 * Project 2
 * CSCI.251.03 - Conc of Par and Dist Systems
 * Rochester Institute of Technology
 * 10/16/19
*/

using System;
using Generators;
using System.Diagnostics;

namespace CSCI._251_Proj2
{
    /*
     * Main Program, handles command line arguments, prints help, and delegates
     * to logic class.
     */
    class Program
    {
        /*
         * Main function.
         */
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            if (args.Length < 1)
            {
                printHelp();
            }
            else if (args.Length == 1)
            {
                sw.Start();
                Console.WriteLine("BitLength: " + args[0] + " bits");
                var numGen = new NumGen(int.Parse(args[0]) / 8);
                numGen.generatePrimes();
                sw.Stop();
                Console.WriteLine("Time to Generate: {0}:{1}:{2}.{3}",
                    sw.Elapsed.Hours,
                    sw.Elapsed.Minutes,
                    sw.Elapsed.Seconds,
                    sw.Elapsed.Ticks);
            }
            else if (args.Length == 2)
            {
                sw.Start();
                Console.WriteLine("BitLength: " + args[0] + " bits");
                var numGen = new NumGen(int.Parse(args[0]) / 8, int.Parse(args[1]));
                numGen.generatePrimes();
                sw.Stop();
                Console.WriteLine("Time to Generate: {0:00}:{1:00}:{2:00}.{3:00}",
                    sw.Elapsed.Hours,
                    sw.Elapsed.Minutes,
                    sw.Elapsed.Seconds,
                    sw.Elapsed.Ticks);
            }
            else
            {
                printHelp();
            }
        }

        /*
         * Help message.
         */
        static void printHelp()
        {
            Console.WriteLine("dotnet run PrimeGen <bits> <count=1>");
            Console.WriteLine("\t- bits - the number of bits of the prime number, this must be a");
            Console.WriteLine("\t  multiple of 8, and at least 32 bits.");
            Console.WriteLine("\t- count - the number of prime numbers to generate, defaults to 1");
        }
    }
}
