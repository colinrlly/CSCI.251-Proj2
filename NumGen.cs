/*
 * Colin Reilly
 * Project 2
 * CSCI.251.03 - Conc of Par and Dist Systems
 * Rochester Institute of Technology
 * 10/16/19
*/

using System;
using System.Security.Cryptography;
using Extensions;
using System.Numerics;
using System.Threading;

namespace Generators {
    /*
     * Main logic for the PrimeGen program. Generates prime numbers and prints them to the
     * command line.
     */
    public class NumGen {
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        private int bytes;
        private int count;
        private int primesGenerated;
        private object LockObject = new object();

        /*
         * Constructor for the NumGen class.
         */
        public NumGen(int bytes, int count = 1) {
            this.bytes = bytes;
            this.count = count;
            this.primesGenerated = 0;
        }

        /*
         * Spawns threads to generate prime numbers. Stops spawning when the
         * predefined count of prime numbers has been printed.
         */
        public void generatePrimes() {
            while (true) {
                lock(this.LockObject) {
                    if (this.primesGenerated == this.count) {
                        break;
                    }
                }

                new Thread(generatePosiblePrime).Start();
            }
        }

        /*
        * Generates a single number. If that number is prime, prints it to the console.
        */
        private void generatePosiblePrime() {
            var bi = this.generateRandomBigInt();

            if (bi.IsProbablyPrime()) {
                lock(this.LockObject) {
                    if (this.primesGenerated < this.count) {
                        this.primesGenerated++;
                        Console.WriteLine(this.primesGenerated.ToString() + ": " + bi);

                        // Used for formatting.
                        if (this.primesGenerated != this.count) {
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        /*
         * Generate a single bigInteger.
         */
        private BigInteger generateRandomBigInt() {
            byte[] randomNumber = new byte[this.bytes];
            rngCsp.GetBytes(randomNumber);
            return new BigInteger(randomNumber, true);
        }
    }
}
