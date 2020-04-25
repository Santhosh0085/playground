using String_Randomizer.Randomizers;
using System;
using System.Linq;

namespace String_Randomizer
{
    /// <summary>
    /// Randomizer type enum
    /// </summary>
    public enum RandomizerType
    {
        Random = 1,
        Crypto = 2
    }

    /// <summary>
    /// String randomizer class
    /// </summary>
    public class StrRandomizer: IDisposable
    {
        #region Private members
        private IRandomizer _random; // Random API randomizer
        private IRandomizer _crypto; // Crypto API randomizer
        #endregion


        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public StrRandomizer()
        {
            this._random = new RandomAPI();
            this._crypto = new CryptoServiceAPI();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Return the randomizer type enum
        /// </summary>
        /// <param name="type"> string type</param>
        /// <returns>Enum randomizer type</returns>
        public RandomizerType GetType(string type)
        {
            return RandomizerType.Random;
        }

        /// <summary>
        /// Shuffle the input string using the given type
        /// </summary>
        /// <param name="input"> Input string </param>
        /// <param name="type"> Randomizer type </param>
        /// <returns>Shuffled string</returns>
        public string Shuffle(string input, RandomizerType type)
        {
            if(type == RandomizerType.Random)
            {
                return Shuffle(input, this._random);
            }
            else
            {
                return Shuffle(input, this._crypto);
            }
        }

        /// <summary>
        /// Dispose randomizers
        /// </summary>
        public void Dispose()
        {
            this._random.Dispose();
            this._crypto.Dispose();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Shuffle the input string using the given type
        /// </summary>
        /// <param name="input"> Input string</param>
        /// <param name="randomizer"> Randomizer to use </param>
        /// <returns>Shuffled string</returns>
        private string Shuffle(string input, IRandomizer randomizer)
        {
            // If the input is empty or of length 1 then just return the input string
            if(string.IsNullOrEmpty(input) || input.Length < 2)
            {
                return input;
            }

            // We will just randomize string characters based on the input string's length
            // We could have chosen a random number but input length will add some more randomness
            int length = input.Length - 1;

            // Since strings are immutables, we will convert the input string to char array for easy swapping
            char[] charArray = input.ToArray<char>();

            // Just loop the length of the string and swap random characters
            for(int index = 0; index < length; index++)
            {
                int rngIdx = randomizer.GetRandomInt(0, length); // Get a random index from the range
                char temp = charArray[index];
                charArray[index] = charArray[rngIdx];
                charArray[rngIdx] = temp;
            }

            return new string(charArray);
        }
        #endregion
    }
}
