using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using CowsAndBulls;
using System.Collections.Generic;


namespace CowsAndBullsUnitTests
{
    [TestClass]
    public class ScoreBoardTests
    {
        private string fileName = "testFile.txt";

        [TestInitialize]
        public void createFile()
        {
            if (File.Exists(fileName) == false)
            {
                File.Create(fileName).Close();
            }

        }

        [TestMethod]
        public void TestConstructor_CorrectFileName()
        {
            //createFile();
            Scoreboard testBoard = new Scoreboard(fileName);
        }

        [TestMethod]
        public void TestAddAndSave()
        {
            //createFile();

            Scoreboard testBoard = new Scoreboard(fileName);
            testBoard.AddScore("lolminator", 1337);
            testBoard.AddScore("asdf", 1337);
            testBoard.AddScore("3rqwe", 1337);

            testBoard.SaveToFile();
        }

        [TestMethod]
        public void TestRead()
        {
            //createFile();
            Scoreboard testBoard = new Scoreboard(fileName);
            testBoard.AddScore("qweqwe", 1337);
            testBoard.AddScore("gtegrge", 12);
            testBoard.AddScore("rwetwehhg", 18);

            //testBoard.
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestIncorrectFileName_FileNotFound()
        {
            Scoreboard testBoard = new Scoreboard("aoiheiqwhe");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIncorrectFileName_NullPath()
        {
            Scoreboard testBoard = new Scoreboard(null);
        }
    }
}
