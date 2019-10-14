using System;
using System.Security.Cryptography;
using Extensions;
using System.Numerics;
using System.Threading;

namespace Generators {
    public class NumGen {
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        private int bytes;
        private int count;
        private int primesGenerated;
        private object LockObject = new object();


        public NumGen(int bytes, int count = 1) {
            this.bytes = bytes;
            this.count = count;
            this.primesGenerated = 0;
        }

        public void generatePrimes() {
            BigInteger[] bigInts = new BigInteger[this.count];

            while (true) {
                lock(this.LockObject) {
                    if (this.primesGenerated == this.count) {
                        break;
                    }
                }

                new Thread(generatePrime).Start();
            }
        }

        private void generatePrime() {
            var bi = this.generateRandomBigInt();

            if (bi.IsProbablyPrime()) {
                lock(this.LockObject) {
                    if (this.primesGenerated < this.count) {
                        this.primesGenerated++;
                        Console.WriteLine(this.primesGenerated.ToString() + ": " + bi + "\n");
                    }
                }
            }
        }

        private BigInteger generateRandomBigInt() {
            byte[] randomNumber = new byte[this.bytes];
            rngCsp.GetBytes(randomNumber);
            return new BigInteger(randomNumber, true);
        }
    }
}
