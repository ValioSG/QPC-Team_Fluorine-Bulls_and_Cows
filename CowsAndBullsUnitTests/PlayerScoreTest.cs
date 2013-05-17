using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CowsAndBulls;

namespace CowsAndBullsUnitTests
{
    [TestClass]
    public class PlayerScoreTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            PlayerScore testPlayer = new PlayerScore("Looser", 12739812);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorTest_EmptyName()
        {
            PlayerScore testPlayer = new PlayerScore("", 12739812);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorTest_NullName()
        {
            PlayerScore testPlayer = new PlayerScore(null, 12739812);
        }

        [TestMethod]
        public void ToStringTest()
        {
            string expectedString = "Pesho --> 12 guesses";
            PlayerScore testPlayer = new PlayerScore("Pesho", 12);
            Assert.AreEqual(expectedString, testPlayer.ToString());
        }

        [TestMethod]
        public void EqualsTest_True()
        {
            PlayerScore testPlayer1 = new PlayerScore("Pesho", 12);
            PlayerScore testPlayer2 = new PlayerScore("Pesho", 12);

            bool areEqual = testPlayer1.Equals(testPlayer2);

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void EqualsTest_False()
        {
            PlayerScore testPlayer1 = new PlayerScore("Pesho", 12);
            PlayerScore testPlayer2 = new PlayerScore("Pesho", 122);

            bool areEqual = testPlayer1.Equals(testPlayer2);

            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void CompareTo_Equal()
        {
            PlayerScore testPlayer1 = new PlayerScore("Pesho", 122);
            PlayerScore testPlayer2 = new PlayerScore("Pesho", 122);

            Assert.AreEqual(0, testPlayer1.CompareTo(testPlayer2));
        }

        [TestMethod]
        public void CompareTo_Higher()
        {
            PlayerScore testPlayer1 = new PlayerScore("Pesho", 1222);
            PlayerScore testPlayer2 = new PlayerScore("Pesho", 122);

            Assert.AreEqual(1, testPlayer1.CompareTo(testPlayer2));
        }

        [TestMethod]
        public void CompareTo_Lower()
        {
            PlayerScore testPlayer1 = new PlayerScore("Pesho", 12);
            PlayerScore testPlayer2 = new PlayerScore("Pesho", 122);

            Assert.AreEqual(-1, testPlayer1.CompareTo(testPlayer2));
        }
    }
}
