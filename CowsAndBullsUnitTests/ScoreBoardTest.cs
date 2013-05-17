using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using CowsAndBulls;

namespace CowsAndBullsUnitTests
{
    [TestClass]
    public class ScoreBoardTest
    {
        private string fileName = "testFile.txt";

        [TestInitialize]
        private void prepareForTestz()
        {
            if (File.Exists(fileName) == false)
            {
                File.Create(fileName);
            }
        }

        [TestMethod]
        public void ConstructorTest()
        {
            Scoreboard newScoreBoard = new Scoreboard(fileName);
        }

        [TestMethod]
        public void SaveToFileTest()
        {
            Scoreboard newScoreBoard = new Scoreboard(fileName);

            newScoreBoard.AddScore("Doncho", 35);
            newScoreBoard.AddScore("Svetlin", 88);
            newScoreBoard.AddScore("Niki", 35);
            newScoreBoard.AddScore("Joro", 35);
            newScoreBoard.AddScore("Ina", 3898);

            newScoreBoard.SaveToFile();
        }

        //[TestMethod]
        //[ExpectedException(typeof(Exception))]
        //public void InvalidFileNameTest()
        //{
        //    Scoreboard newScoreBoard = new Scoreboard("unexisted");
        //}

    }


}
