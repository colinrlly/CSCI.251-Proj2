using System;
using System.Security.Cryptography;

namespace Generators {
    public class NumGen {
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        private int bytes;

        public NumGen(int bytes) {
            this.bytes = bytes;
        }

        public byte[] generateRandomNum() {
            byte[] randomNumber = new byte[this.bytes];
            rngCsp.GetBytes(randomNumber);   
            return randomNumber;
        }
    }
}
