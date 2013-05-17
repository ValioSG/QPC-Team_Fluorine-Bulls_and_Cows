using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CowsAndBulls
{
    public class PlayerScore : IComparable
    {

        private string name;
        private int guessesCount;

        /// <summary>
        /// Gets tha name of the player
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The passed name is null or empty");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets the number og gusses
        /// </summary>
        public int GuessesCount
        {
            get
            {
                return this.guessesCount;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The guess cunt cant be a negative number");
                }

                this.guessesCount = value;
            }
        }

        /// <summary>
        /// Create a player score object with name and number of guesses
        /// </summary>
        /// <param name="name">Name of the player</param>
        /// <param name="guessesCount">number of guesses</param>
        public PlayerScore(string name, int guessesCount)
        {
            this.Name = name;
            this.GuessesCount = guessesCount;
        }

        public override bool Equals(object obj)
        {
            PlayerScore objectToCompare;

            if (obj is PlayerScore)
            {
                objectToCompare = obj as PlayerScore;
            }
            else
            {
                throw new ArgumentException("The passed object is not comparable to PlayerScore");
            }

            if (objectToCompare == null)
            {
                return false;
            }
            else
            {
                return this.GuessesCount.Equals(objectToCompare) && this.Name.Equals(objectToCompare);
            }
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.GuessesCount.GetHashCode();
        }

        public override string ToString()
        {
            string  guessForm = this.GuessesCount == 1 ? "guess" : "guesses";
            return string.Format("{0} --> {1} {2}", this.Name, this.GuessesCount, guessForm);
        }

        public int CompareTo(object obj)
        {
            PlayerScore objectToCompare;

            if (obj is PlayerScore)
            {
                objectToCompare = obj as PlayerScore;
            }
            else
            {
                throw new ArgumentException("The passed object is not comparable to PlayerScore");
            }

            if (objectToCompare == null)
            {
                return -1;
            }

            if (this.GuessesCount.CompareTo(objectToCompare.GuessesCount) == 0)
            {	
				return this.Name.CompareTo(objectToCompare.Name);
            }
            else
            {
                return this.GuessesCount.CompareTo(objectToCompare.GuessesCount);
            }
        }

        /// <summary>
        /// Serializes the object
        /// </summary>
        /// <returns>Serialized version of the object in a string form</returns>
        public string Serialize()
        {
            return string.Format("{0}_:::_{1}", this.Name, this.GuessesCount);
        }

        /// <summary>
        /// Deserializes an object
        /// </summary>
        /// <param name="data">Serialized object data</param>
        /// <returns>PlayerScoreObject</returns>
        public static PlayerScore Deserialize(string data)
        {
            string[] dataAsStringArray = data.Split(new string[] { "_:::_" }, StringSplitOptions.None);
            if (dataAsStringArray.Length != 2) return null;

            string name = dataAsStringArray[0];

            int guesses = 0;
            int.TryParse(dataAsStringArray[1], out guesses);

            return new PlayerScore(name, guesses);
        }
    }
}
