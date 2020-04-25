using System;
using System.Security.Cryptography;

namespace String_Randomizer.Randomizers
{
    /// <summary>
    /// Class that uses Crypto API for generating random numbers
    /// </summary>
    internal class CryptoServiceAPI : IRandomizer
    {
        private RNGCryptoServiceProvider _crypto;
        private byte[] _randomByte;

        /// <summary>
        /// Base constructor
        /// </summary>
        internal CryptoServiceAPI()
        {
            this._crypto = new RNGCryptoServiceProvider();
            this._randomByte = new byte[4]; //number of bytes used for an integer
        }

        /// <summary>
        /// Method that will return a random integer between the min and max values usn Crypto API
        /// </summary>
        /// <param name="min"> Minimum value </param>
        /// <param name="max"> Maximum value </param>
        /// <returns>Return a random integer between the min and max values</returns>
        public int GetRandomInt(int min, int max)
        {
            this._crypto.GetBytes(_randomByte);
            int value = unchecked((int)(BitConverter.ToUInt32(_randomByte, 0) & Int32.MaxValue)); // Avoid getting negative numbers & max value overflow
            return ((value) % (max - min + 1)) + min;
        }

        /// <summary>
        /// Properly dispose crypto object
        /// </summary>
        public void Dispose()
        {
            this._crypto.Dispose();
        }
    }
}
