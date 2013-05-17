using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CowsAndBulls
{
    public class Scoreboard
    {
        private SortedSet<PlayerScore> scores;
        private const int MaxPlayersToShowInScoreboard = 10;

        /// <summary>
        /// Reads score results from the score file.
        /// </summary>
        /// <param name="filename">The score file name or path.</param>
        public Scoreboard(string filename)
        {
            this.scores = new SortedSet<PlayerScore>();

            try
            {
                StreamReader inputStream = new StreamReader(filename);
                using (inputStream)
                {
                    while (!inputStream.EndOfStream)
                    {
                        string scoreString = inputStream.ReadLine();
                        this.scores.Add(PlayerScore.Deserialize(scoreString));
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                {
                    Console.WriteLine("Path is an empty string or incorrect syntax.");
                }
                else if (ex is ArgumentNullException)
                {
                    Console.WriteLine("Path is null.");
                }
                else if (ex is FileNotFoundException)
                {
                    Console.WriteLine("The file cannot be found.");
                }
                else if (ex is DirectoryNotFoundException)
                {
                    Console.WriteLine("The specified path is invalid, such as being on an unmapped drive.");
                }
                else if (ex is IOException)
                {
                    Console.WriteLine("Path is null.");
                }
                else if (ex is OutOfMemoryException)
                {
                    Console.WriteLine("Unable to store file. Out of memory.");
                }

            }
        }

        /// <summary>
        /// Create new object to be storred in the score file.
        /// </summary>
        /// <param name="name">Name of the player</param>
        /// <param name="guesses">Number of guesses</param>
        public void AddScore(string name, int guesses)
        {
            PlayerScore newScore = new PlayerScore(name, guesses);
            this.scores.Add(newScore);
        }

        /// <summary>
        /// Save the generated scores from scores to the file.
        /// </summary>
        /// <param name="filename">The score file name or path.</param>
        public void SaveToFile(string filename)
        {
            try
            {
                using (StreamWriter outputStream = new StreamWriter(filename))
                {
                    foreach (PlayerScore gameScore in scores)
                    {
                        outputStream.WriteLine(gameScore.Serialize());
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                {
                    Console.WriteLine("Path is an empty string or incorrect syntax.");
                }
                else if (ex is ArgumentNullException)
                {
                    Console.WriteLine("Path is null.");
                }
                else if (ex is FileNotFoundException)
                {
                    Console.WriteLine("The file cannot be found.");
                }
                else if (ex is DirectoryNotFoundException)
                {
                    Console.WriteLine("The specified path is invalid, such as being on an unmapped drive.");
                }
                else if (ex is IOException)
                {
                    Console.WriteLine("Path is null.");
                }
                else if (ex is UnauthorizedAccessException)
                {
                    Console.WriteLine("Unautorized access to the file.");
                }
                else if (ex is PathTooLongException)
                {
                    Console.WriteLine("Path to the file is too long.");
                }
                else if (ex is System.Security.SecurityException)
                {
                    Console.WriteLine("The caller does not have the required permission.");
                }
            }
        }

        public override string ToString()
        {
            if (scores.Count == 0)
            {
                return "Top scoreboard is empty." + Environment.NewLine;
            }

            StringBuilder scoreBoard = new StringBuilder();
            scoreBoard.AppendLine("Scoreboard:");
            int count = 0;

            foreach (PlayerScore gameScore in scores)
            {
                count++;
                scoreBoard.AppendLine(string.Format("{0}. {1}", count, gameScore));

                if (count > MaxPlayersToShowInScoreboard)
                {
                    break;
                }
            }
            return scoreBoard.ToString();
        }
    }
}
