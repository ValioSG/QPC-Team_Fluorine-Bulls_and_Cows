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
    }
}
