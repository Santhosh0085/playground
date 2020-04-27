using Microsoft.VisualStudio.TestTools.UnitTesting;
using String_Randomizer;
using System.Linq;

namespace StrRandomizerTest
{
    /// <summary>
    /// Test class containing test cases for string randomizers
    /// </summary>
    [TestClass]
    public class RandomAPITest
    {
        /// <summary>
        /// Test Random API randomizer
        /// </summary>
        [TestMethod]
        public void Test_RandomAPIBasic()
        {
            StrRandomizer random = new StrRandomizer();
            string input = "test";
            string result = random.Shuffle(input, RandomizerType.Random);

            // The shuffle works if
            // 1) The input and result lengths are the same
            // 2) The sorted string of input and and result are the same (same number of character counts)
            Assert.IsTrue(result.Length == 4 && new string (input.OrderBy(c => c).ToArray()).Equals(new string(result.OrderBy(r => r).ToArray())));
        }

        /// <summary>
        /// Test Crypto API randomizer
        /// </summary>
        [TestMethod]
        public void Test_CryptoAPIBasic()
        {
            StrRandomizer random = new StrRandomizer();
            string input = "test";
            string result = random.Shuffle(input, RandomizerType.Crypto);

            // The shuffle works if
            // 1) The input and result lengths are the same
            // 2) The sorted string of input and and result are the same (same number of character counts)
            Assert.IsTrue(result.Length == 4 && new string(input.OrderBy(c => c).ToArray()).Equals(new string(result.OrderBy(r => r).ToArray())));
        }

    }
}
