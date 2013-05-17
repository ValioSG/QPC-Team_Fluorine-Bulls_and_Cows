using System;
using System.Linq;

namespace CowsAndBulls
{
    /// <summary>
    /// Keeps track of the result after each guess and returns it in a clear string format.
    /// </summary>
    public struct Result
    {
        private int bulls;
        private int cows;

        public int Bulls
        {
            get
            {
                return this.bulls;
            }

            internal set
            {
                this.bulls = value;
            }
        }

        public int Cows
        {
            get
            {
                return this.cows;
            }

            internal set
            {
                this.cows = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Bulls: {0}, Cows: {1}", this.Bulls, this.Cows);
        }
    }
}
