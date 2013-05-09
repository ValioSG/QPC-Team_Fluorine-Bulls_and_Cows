using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CowsAndBulls;

namespace CowsAndBullsTests
{
    [TestClass]
    public class SecretNumberTest
    {
        [TestMethod]
        public void Test_NumberGeneration()
        {
            for (int counter = 1; counter <= 100000; counter++)
            {
                SecretNumber secretNum = new SecretNumber();
                int parsedSecretNum = int.Parse(secretNum.ToString());

                bool isValidSecretNum = (parsedSecretNum >= 0 && parsedSecretNum <= 9999);

                bool expectedValue = true;

                Assert.AreEqual(expectedValue, isValidSecretNum);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_CheckUserGuess_InputValidation_Over9999()
        {
            SecretNumber secretNum = new SecretNumber();

            string invalidGuess = "99999";

            secretNum.CheckUserGuess(invalidGuess);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_CheckUserGuess_InputValidation_Under0()
        {
            SecretNumber secretNum = new SecretNumber();

            string invalidGuess = "-122";

            secretNum.CheckUserGuess(invalidGuess);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_CheckUserGuess_InputValidation_EmptyString()
        {
            SecretNumber secretNum = new SecretNumber();

            string invalidGuess = "";

            secretNum.CheckUserGuess(invalidGuess);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_CheckUserGuess_InputValidation_NullString()
        {
            SecretNumber secretNum = new SecretNumber();

            string invalidGuess = null;

            secretNum.CheckUserGuess(invalidGuess);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Test_CheckUserGuess_InputValidation_InvalidNumber()
        {
            SecretNumber secretNum = new SecretNumber();

            string invalidGuess = "3asz";

            secretNum.CheckUserGuess(invalidGuess);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Test_CheckUserGuess_InputValidation_InvalidNumber2()
        {
            SecretNumber secretNum = new SecretNumber();

            string invalidGuess = "222";

            secretNum.CheckUserGuess(invalidGuess);
        }

        [TestMethod]
        public void Test_GetMockNumber()
        {
            string mockValue = "2375";

            SecretNumber mockNumber = SecretNumber.GetMockNumber(mockValue);

            Assert.AreEqual(mockValue, mockNumber.ToString());
        }

        [TestMethod]
        public void Test_CheckUserGuess_CorrectGuess()
        {
            SecretNumber sNum = new SecretNumber();

            string guess = sNum.ToString();

            Result guessResult = sNum.CheckUserGuess(guess);

            Assert.AreEqual(4, guessResult.Bulls, "Wrong bullsCount count");
            Assert.AreEqual(0, guessResult.Cows, "Wrong cowsCount count");
        }

        [TestMethod]
        public void Test_CheckUserGuess_1Bulls2Cows()
        {
            string mockValue = "7725";

            SecretNumber mockNumber = SecretNumber.GetMockNumber(mockValue);

            string guess = "2375";

            Result guessResult = mockNumber.CheckUserGuess(guess);

            Assert.AreEqual(1, guessResult.Bulls, "Wrong bullsCount count");
            Assert.AreEqual(2, guessResult.Cows, "Wrong cowsCount count");
        }

        [TestMethod]
        public void Test_CheckUserGuess_0Bulls0Cows()
        {
            string mockValue = "7725";

            SecretNumber mockNumber = SecretNumber.GetMockNumber(mockValue);

            string guess = "8946";

            Result guessResult = mockNumber.CheckUserGuess(guess);

            Assert.AreEqual(0, guessResult.Bulls, "Wrong bullsCount count");
            Assert.AreEqual(0, guessResult.Cows, "Wrong cowsCount count");
        }

        [TestMethod]
        public void Test_CheckUserGuess_1Bulls0Cows()
        {
            string mockValue = "7725";

            SecretNumber mockNumber = SecretNumber.GetMockNumber(mockValue);

            string guess = "1055";

            Result guessResult = mockNumber.CheckUserGuess(guess);

            Assert.AreEqual(1, guessResult.Bulls, "Wrong bullsCount count");
            Assert.AreEqual(0, guessResult.Cows, "Wrong cowsCount count");
        }

        [TestMethod]
        public void Test_CheckUserGuess_0Bulls2Cows()
        {
            string mockValue = "7725";

            SecretNumber mockNumber = SecretNumber.GetMockNumber(mockValue);

            string guess = "2253";

            Result guessResult = mockNumber.CheckUserGuess(guess);

            Assert.AreEqual(0, guessResult.Bulls, "Wrong bullsCount count");
            Assert.AreEqual(2, guessResult.Cows, "Wrong cowsCount count");
        }

        [TestMethod]
        public void Test_CheckUserGuess_2Bulls2Cows()
        {
            string mockValue = "7725";

            SecretNumber mockNumber = SecretNumber.GetMockNumber(mockValue);

            string guess = "2775";

            Result guessResult = mockNumber.CheckUserGuess(guess);

            Assert.AreEqual(2, guessResult.Bulls, "Wrong bullsCount count");
            Assert.AreEqual(2, guessResult.Cows, "Wrong cowsCount count");
        }

        [TestMethod]
        public void Test_CheckUserGuess_0Bulls3Cows_RepeatingDigits()
        {
            string mockValue = "7725";

            SecretNumber mockNumber = SecretNumber.GetMockNumber(mockValue);

            string guess = "2277";

            Result guessResult = mockNumber.CheckUserGuess(guess);

            Assert.AreEqual(0, guessResult.Bulls, "Wrong bullsCount count");
            Assert.AreEqual(3, guessResult.Cows, "Wrong cowsCount count");
        }

        [TestMethod]
        public void Test_CheckUserGuess_1Bulls1Cows_8130()
        {
            string mockValue = "8130";

            SecretNumber mockNumber = SecretNumber.GetMockNumber(mockValue);

            string guess = "1234";

            Result guessResult = mockNumber.CheckUserGuess(guess);

            Assert.AreEqual(1, guessResult.Bulls, "Wrong bullsCount count");
            Assert.AreEqual(1, guessResult.Cows, "Wrong cowsCount count");
        }

        [TestMethod]
        public void Test_CheckUserGuess_0Bulls0Cows_8130()
        {
            string mockValue = "8130";

            SecretNumber mockNumber = SecretNumber.GetMockNumber(mockValue);

            string guess = "4567";

            Result guessResult = mockNumber.CheckUserGuess(guess);

            Assert.AreEqual(0, guessResult.Bulls, "Wrong bullsCount count");
            Assert.AreEqual(0, guessResult.Cows, "Wrong cowsCount count");
        }

        [TestMethod]
        public void Test_CheckUserGuess_1Bulls2Cows_8130()
        {
            string mockValue = "8130";

            SecretNumber mockNumber = SecretNumber.GetMockNumber(mockValue);

            string guess = "8901";

            Result guessResult = mockNumber.CheckUserGuess(guess);

            Assert.AreEqual(1, guessResult.Bulls, "Wrong bullsCount count");
            Assert.AreEqual(2, guessResult.Cows, "Wrong cowsCount count");
        }

        [TestMethod]
        public void Test_CheckUserGuess_0Bulls3Cows_8225()
        {
            string mockValue = "8225";

            SecretNumber mockNumber = SecretNumber.GetMockNumber(mockValue);

            string guess = "2882";

            Result guessResult = mockNumber.CheckUserGuess(guess);

            Assert.AreEqual(0, guessResult.Bulls, "Wrong bullsCount count");
            Assert.AreEqual(3, guessResult.Cows, "Wrong cowsCount count");
        }

        [TestMethod]
        public void Test_CheckUserGuess_0Bulls2Cows_6660()
        {
            string mockValue = "6660";

            SecretNumber mockNumber = SecretNumber.GetMockNumber(mockValue);

            string guess = "0066";

            Result guessResult = mockNumber.CheckUserGuess(guess);

            Assert.AreEqual(1, guessResult.Bulls, "Wrong bullsCount count");
            Assert.AreEqual(2, guessResult.Cows, "Wrong cowsCount count");
        }

        [TestMethod]
        public void Test_GetCheat()
        {
            string mockValue = "1337";
            SecretNumber mockNumber = SecretNumber.GetMockNumber(mockValue);

            string cheat = "";
            for (int counter = 1; counter <= 10; counter++)
            {
                cheat = mockNumber.GetCheat();
            }

            Assert.AreEqual(mockNumber.ToString(), cheat);
        }

    }
}
