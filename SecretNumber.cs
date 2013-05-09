using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CowsAndBulls
{
    public class SecretNumber
    {
        private const int MAX_CHEATS_COUNT = 4;
        private const int NUMBER_OF_DIGITS = 4;

        private Random randomGenerator;
        private char[] cheatNumber;
        private int cheatsCount;
        private int guessesCount;
        private int[] secretNumDigits = new int[NUMBER_OF_DIGITS];
        private bool[] isGuessDigitCowOrBull = new bool[NUMBER_OF_DIGITS];
        private bool[] isSecretNumDigitCowOrBull = new bool[NUMBER_OF_DIGITS];

        public int CheatsCount
        {
            get
            {
                return this.cheatsCount;
            }

            private set
            {
                this.cheatsCount = value;
            }
        }

        public int GuessesCount
        {
            get
            {
                return this.guessesCount;
            }

            private set
            {
                this.guessesCount = value;
            }
        }

        public int FirstDigit
        {
            get
            {
                return this.secretNumDigits[0];
            }

            private set
            {
                this.secretNumDigits[0] = value;
            }
        }

        public int SecondDigit
        {
            get
            {
                return this.secretNumDigits[1];
            }

            private set
            {
                this.secretNumDigits[1] = value;
            }
        }

        public int ThirdDigit
        {
            get
            {
                return this.secretNumDigits[2];
            }

            private set
            {
                this.secretNumDigits[2] = value;
            }
        }

        public int FourthDigit
        {
            get
            {
                return this.secretNumDigits[3];
            }

            private set
            {
                this.secretNumDigits[3] = value;
            }
        }

        public SecretNumber()
        {
            this.randomGenerator = new Random();
            this.cheatNumber = new char[NUMBER_OF_DIGITS] { 'X', 'X', 'X', 'X' };
            this.CheatsCount = 0;
            this.GuessesCount = 0;
            this.GenerateRandomDigits();
        }

        /// <summary>
        /// Reveals a digit of the secret number on each call for up to 4 times
        /// </summary>
        /// <returns>Revealed digits at their respective position</returns>
        public string GetCheat()
        {
            if (this.CheatsCount < MAX_CHEATS_COUNT)
            {
                while (true)
                {
                    int randPossition = this.randomGenerator.Next(0, 4);

                    if (this.cheatNumber[randPossition] == 'X')

                    {
                        //sets reveals a digit from the secretNumber at the selected position
                        switch (randPossition)
	                    {
                            case 0: 
                                this.cheatNumber[randPossition] = (char)(this.FirstDigit + '0'); 
                                break;
                            case 1: 
                                this.cheatNumber[randPossition] = (char)(this.SecondDigit + '0');
                                break;
                            case 2: 
                                this.cheatNumber[randPossition] = (char)(this.ThirdDigit + '0');
                                break;
                            case 3: 
                                this.cheatNumber[randPossition] = (char)(this.FourthDigit + '0');
                                break;
	                    }

                        break;
                    }
                }

                this.CheatsCount++;
            }

            return new String(this.cheatNumber);
        }

        /// <summary>
        /// Validates that the passed number complies with the requirements for a secret number
        /// </summary>
        /// <param name="number">Number to valdiate</param>
        private static void ValidateNumber(string number)
        {

            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentException("Passed number string is null or empty");
            }

            string trimmedNumber = number.Trim();

            int parsedNumber;

            if (trimmedNumber.Length < NUMBER_OF_DIGITS || int.TryParse(trimmedNumber, out parsedNumber) == false)
            {
                throw new FormatException("Invalid number string");
            }

            if (parsedNumber < 0 || parsedNumber > 9999)
            {
                throw new ArgumentOutOfRangeException("The passed number must be positive 4 digit number");
            }

        }

        /// <summary>
        /// Checks for the number of bulls in the passed guess number
        /// </summary>
        /// <param name="guessNumber">Guess number to check for bulls</param>
        /// <returns>The number of bulls in the passed guess number</returns>
        private int CheckBullsCount(string guessNumber)
        {
            this.isGuessDigitCowOrBull = new bool[NUMBER_OF_DIGITS];
            this.isGuessDigitCowOrBull = new bool[NUMBER_OF_DIGITS];

            int bullsCount = 0;

            for (var index = 0; index < NUMBER_OF_DIGITS; index++)
            {
                int secretDigit = this.secretNumDigits[index];
                int guessDigit = int.Parse(guessNumber[index].ToString());

                if (secretDigit == guessDigit)
                {
                    bullsCount++;
                    this.isGuessDigitCowOrBull[index] = true;
                    this.isSecretNumDigitCowOrBull[index] = true;
                }
            }

            return bullsCount;
        }

        /// <summary>
        /// Checks the number of cows in the passed guess number
        /// </summary>
        /// <param name="guessNumber">Guess number to check</param>
        /// <returns>The number of cows in the passed guess number</returns>
        private int CheckCowsCount(string guessNumber)
        {
            int cowsCount = 0;

            for (int guessDigitIndex = 0; guessDigitIndex < NUMBER_OF_DIGITS; guessDigitIndex++)
            {
                if (this.isGuessDigitCowOrBull[guessDigitIndex] == false)
                {
                    for (int secretNumDigitIndex = 0; secretNumDigitIndex < NUMBER_OF_DIGITS; secretNumDigitIndex++)
                    {
                        if (guessDigitIndex == secretNumDigitIndex)
                        {
                            continue;
                        }

                        int secretDigit = this.secretNumDigits[secretNumDigitIndex];
                        int guessDigit = int.Parse(guessNumber[guessDigitIndex].ToString());

                        if (guessDigit == secretDigit && this.isSecretNumDigitCowOrBull[secretNumDigitIndex] == false)
                        {
                            cowsCount++;
                            this.isGuessDigitCowOrBull[guessDigitIndex] = true;
                            this.isSecretNumDigitCowOrBull[secretNumDigitIndex] = true;
                            break;
                        }
                    }
                }
            }

            return cowsCount;
        }

        /// <summary>
        /// Evaluates the user guess against the secret number
        /// </summary>
        /// <param name="guessNumber">Guess number to evaluate</param>
        /// <returns>The result of the guess</returns>
        public Result CheckUserGuess(string guessNumber)
        {
            ValidateNumber(guessNumber);

            guessNumber = guessNumber.Trim();

            this.GuessesCount++;

            int bullsCount = CheckBullsCount(guessNumber);

            int cowsCount = CheckCowsCount(guessNumber);

            Result guessResult = new Result();
            guessResult.Bulls = bullsCount;
            guessResult.Cows = cowsCount;

            return guessResult;
        }

        /// <summary>
        /// Generates the random digits of the secret number
        /// </summary>
        private void GenerateRandomDigits()
        {
            this.FirstDigit = randomGenerator.Next(0, 10);
            this.SecondDigit = randomGenerator.Next(0, 10);
            this.ThirdDigit = randomGenerator.Next(0, 10);
            this.FourthDigit = randomGenerator.Next(0, 10);
        }

        public override string ToString()
        {
            StringBuilder numberStringBuilder = new StringBuilder();
            numberStringBuilder.Append(FirstDigit);
            numberStringBuilder.Append(SecondDigit);
            numberStringBuilder.Append(ThirdDigit);
            numberStringBuilder.Append(FourthDigit);
            return numberStringBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            SecretNumber objectToCompare = obj as SecretNumber;
            if (objectToCompare == null)
            {
                return false;
            }
            else
            {
                return (this.FirstDigit == objectToCompare.FirstDigit &&
                        this.SecondDigit == objectToCompare.SecondDigit &&
                        this.ThirdDigit == objectToCompare.ThirdDigit &&
                        this.FourthDigit == objectToCompare.FourthDigit);
            }
        }

        public override int GetHashCode()
        {
            return this.FirstDigit.GetHashCode() ^ this.SecondDigit.GetHashCode() ^ 
                this.ThirdDigit.GetHashCode() ^ this.FourthDigit.GetHashCode();
        }

        /// <summary>
        /// USED ONLY FOR TESTING!
        /// Creates a SecretNumber object having the passed value
        /// </summary>
        /// <param name="mockValue">Value for the secret number</param>
        /// <returns>Mock secret number with predetermined value</returns>
        public static SecretNumber GetMockNumber(string mockValue)
        {
            ValidateNumber(mockValue);

            SecretNumber mockNumber = new SecretNumber();
            mockNumber.FirstDigit = int.Parse(mockValue[0].ToString());
            mockNumber.SecondDigit = int.Parse(mockValue[1].ToString());
            mockNumber.ThirdDigit = int.Parse(mockValue[2].ToString());
            mockNumber.FourthDigit = int.Parse(mockValue[3].ToString());

            return mockNumber;
        }
    }
}
