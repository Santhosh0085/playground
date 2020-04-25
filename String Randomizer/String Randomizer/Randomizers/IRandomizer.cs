using System;

namespace String_Randomizer
{
    /// <summary>
    /// Interface to be implemented by all the Randomizers
    /// </summary>
    public interface IRandomizer: IDisposable
    {
        /// <summary>
        /// Method that will return a random integer between the min and max values
        /// </summary>
        /// <param name="min"> Minimum value </param>
        /// <param name="max"> Maximum value </param>
        /// <returns>Return a random integer between the min and max values</returns>
        int GetRandomInt(int min, int max);
    }
}
