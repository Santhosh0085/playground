using System;

namespace String_Randomizer
{
    /// <summary>
    /// Class that uses Random API for generating random numbers
    /// </summary>
    internal class RandomAPI: IRandomizer
    {
        private Random _random;

        /// <summary>
        /// Base constructor
        /// </summary>
        internal RandomAPI()
        {
            this._random = new Random();
        }

        /// <summary>
        /// Method that will return a random integer between the min and max values suing Random API
        /// </summary>
        /// <param name="min"> Minimum value </param>
        /// <param name="max"> Maximum value </param>
        /// <returns>Return a random integer between the min and max values</returns>
        public int GetRandomInt(int min, int max)
        {
            // Random alredy has the in-built API NEXT to support randomizing numbers between a range
            return this._random.Next(min, max);
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            // Random object doesn't have disposable method so just release the object
            this._random = null;
        }
    }
}
