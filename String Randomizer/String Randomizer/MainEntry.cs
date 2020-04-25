using System;

namespace String_Randomizer
{

    /// <summary>
    /// This the entry point class for string randomizer test application
    /// </summary>
    class MainEntry
    {
        #region Private Members

        private static StrRandomizer _randomizer = new StrRandomizer(); // Randomizer

        #endregion

        #region Main

        /// <summary>
        /// Main entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            RandomizeStr();
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// Gets the type to randomize string (Crypto or random API)
        /// Randomize the input string
        /// </summary>
        private static void RandomizeStr()
        {
            RandomizerType type;
            string input = string.Empty;
            type = GetRngType();

            while (true)
            {
                Console.Write("Enter a string to randomize: ");
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                Console.WriteLine($"Randomized string : {_randomizer.Shuffle(input, type)}");
            }

            _randomizer.Dispose();
            Console.WriteLine("Press any key to exit.");
            Console.Read();
        }

        /// <summary>
        /// Get the type of randomizer to use
        /// </summary>
        /// <returns>RandomizerEnum -  1- Random and 2 - Crypto </returns>
        private static RandomizerType GetRngType()
        {
            Console.Write("Choose a valid randomizer type (1 - Random, 2 - Crypto) :");

            RandomizerType type = RandomizerType.Random;

            while((!Enum.TryParse(Console.ReadLine(), out type) && Enum.IsDefined(typeof(RandomizerType), type)))
            {
                Console.WriteLine("The value entered must be either 1 or 2.");
            }

            return type;
        }

        #endregion
    }
}
