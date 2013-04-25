using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CowsAndBulls
{
    public struct Result
    {
        private int bulls;
        private int cows;

        public int Bulls
        {
            get
            {
                //get
                return this.bulls;
            }

            set
            {
                this.bulls = value;
            }
        }

        public int Cows
        {
            get
            {
                //set
                return this.cows;
            }

            set
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
