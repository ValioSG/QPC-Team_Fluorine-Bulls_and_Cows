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
        private string fileName = string.Empty;

        /// <summary>
        /// Reads score results from the score file.
        /// </summary>
        /// <param name="filename">The score file name or path.</param>
        public Scoreboard(string filename)
        {
            this.fileName = filename;
            this.scores = new SortedSet<PlayerScore>();

            StreamReader inputStream = new StreamReader(this.fileName);
            using (inputStream)
            {
                while (!inputStream.EndOfStream)
                {
                    string scoreString = inputStream.ReadLine();
                    this.scores.Add(PlayerScore.Deserialize(scoreString));
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
        public void SaveToFile()
        {
            using (StreamWriter outputStream = new StreamWriter(this.fileName))
            {
                foreach (PlayerScore gameScore in scores)
                {
                    outputStream.WriteLine(gameScore.Serialize());
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
