/*
 * Colin Reilly
 * Project 2
 * CSCI.251.03 - Conc of Par and Dist Systems
 * Rochester Institute of Technology
 * 10/16/19
*/

using System;
using System.Numerics;
using Extensions;
using Generators;

namespace CSCI._251_Proj2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                printHelp();
            }
            else if (args.Length == 1)
            {
                Console.WriteLine(args[0]);
                var numGen = new NumGen(int.Parse(args[0]));
                var bi = new BigInteger(numGen.generateRandomNum(), true);
                Console.WriteLine(bi);
                Console.WriteLine(bi.IsProbablyPrime());
            }
            else if (args.Length == 2)
            {
                Console.WriteLine(args[0]);
                Console.WriteLine(args[1]);
            }
            else
            {
                printHelp();
            }
        }

        static void printHelp()
        {
            Console.WriteLine("dotnet run PrimeGen <bits> <count=1>");
            Console.WriteLine("\t- bits - the number of bits of the prime number, this must be a");
            Console.WriteLine("\t  multiple of 8, and at least 32 bits.");
            Console.WriteLine("\t- count - the number of prime numbers to generate, defaults to 1");
        }
    }
}
