using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CowsAndBulls
{
    public class SecretNumber
    {
        private const int MAX_CHEATS_COUNT = 4;

        private Random randomGenerator;
        private char[] cheatNumber;
        private int cheatsCount;
        private int guessesCount;
        private int firstDigit;
        private int secondDigit;
        private int thirdDigit;
        private int fourthDigit;

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
                return this.firstDigit;
            }

            private set
            {
                this.firstDigit = value;
            }
        }

        public int SecondDigit
        {
            get
            {
                return this.secondDigit;
            }

            private set
            {
                this.secondDigit = value;
            }
        }

        public int ThirdDigit
        {
            get
            {
                return this.thirdDigit;
            }

            private set
            {
                this.thirdDigit = value;
            }
        }

        public int FourthDigit
        {
            get
            {
                return this.fourthDigit;
            }

            private set
            {
                this.fourthDigit = value;
            }
        }

        public SecretNumber()
        {
            randomGenerator = new Random();
            cheatNumber = new char[4] { 'X', 'X', 'X', 'X' };
            this.CheatsCount = 0;
            this.GuessesCount = 0;
            this.GenerateRandomNumbers();
        }

        public string GetCheat()
        {
            if (this.CheatsCount < MAX_CHEATS_COUNT)
            {
                while (true)
                {
                    int randPossition = randomGenerator.Next(0, 4);
                    if (cheatNumber[randPossition] == 'X')

                    {
                        switch (randPossition)
	                    {
                            case 0: 
                                cheatNumber[randPossition] = (char)(FirstDigit + '0'); 
                                break;
                            case 1: 
                                cheatNumber[randPossition] = (char)(SecondDigit + '0');
                                break;
                            case 2: 
                                cheatNumber[randPossition] = (char)(ThirdDigit + '0');
                                break;
                            case 3: 
                                cheatNumber[randPossition] = (char)(FourthDigit + '0');
                                break;
	                    }

                        break;
                    }
                }

                CheatsCount++;
            }

            return new String(cheatNumber);
        }

        public Result CheckUserGuess(string number)
        {
            if (string.IsNullOrEmpty(number) || number.Trim().Length != 4)
            {
                throw new ArgumentException("Invalid string number");
            }

            return TryToGuess(number[0] - '0', number[1] - '0', number[2] - '0', number[3] - '0');
        }

        private Result TryToGuess(int firstDigit, int secondDigit, int thirdDigit, int fourthDigit)
        {
            if (firstDigit < 0 || firstDigit > 9)
            {
                throw new ArgumentException("Invalid first digit");
            }

            if (secondDigit < 0 || secondDigit > 9)
            {
                throw new ArgumentException("Invalid second digit");
            }

            if (thirdDigit < 0 || thirdDigit > 9)
            {
                throw new ArgumentException("Invalid third digit");
            }

            if (fourthDigit < 0 || fourthDigit > 9)
            {
                throw new ArgumentException("Invalid fourth digit");
            }

            this.GuessesCount++;

            int bulls = 0;

            bool isFirstDigitBullOrCow = false;
            // checks if firstDigit is a bull:
            if (this.FirstDigit == firstDigit)
            {
                isFirstDigitBullOrCow = true;
                bulls++;
            }

            bool isSecondDigitBullOrCow = false;
            // checks if secondDigit is a bull:
            if (this.SecondDigit == secondDigit)
            {
                isSecondDigitBullOrCow = true;
                bulls++;
            }

            bool isThirdDigitBullOrCow = false;
            // checks if thirdDigit is a bull:
            if (this.ThirdDigit == thirdDigit)
            {
                isThirdDigitBullOrCow = true;
                bulls++;
            }

            bool isFourthDigitBullOrCow = false;
            // checks if fourthDigit is a bull:
            if (this.FourthDigit == fourthDigit)
            {
                isFourthDigitBullOrCow = true;
                bulls++;
            }

            int cows = 0;
            // checks if firstDigit is cow:
            if (!isSecondDigitBullOrCow && firstDigit == SecondDigit)
            {
                isSecondDigitBullOrCow = true;
                cows++;
            }
            else if (!isThirdDigitBullOrCow && firstDigit == ThirdDigit)
            {
                isThirdDigitBullOrCow = true;
                cows++;
            }
            else if (!isFourthDigitBullOrCow && firstDigit == FourthDigit)
            {
                isFourthDigitBullOrCow = true;
                cows++;
            }

            // checks if secondDigit is cow:
            if (!isFirstDigitBullOrCow && secondDigit == FirstDigit)
            {
                isFirstDigitBullOrCow = true;
                cows++;
            }
            else if (!isThirdDigitBullOrCow && secondDigit == ThirdDigit)
            {
                isThirdDigitBullOrCow = true;
                cows++;
            }
            else if (!isFourthDigitBullOrCow && secondDigit == FourthDigit)
            {
                isFourthDigitBullOrCow = true;
                cows++;
            }

            // checks if thirdDigit is cow:
            if (!isFirstDigitBullOrCow && thirdDigit == FirstDigit)
            {
                isFirstDigitBullOrCow = true;
                cows++;
            }
            else if (!isSecondDigitBullOrCow && thirdDigit == SecondDigit)
            {
                isSecondDigitBullOrCow = true;
                cows++;
            }
            else if (!isFourthDigitBullOrCow && thirdDigit == FourthDigit)
            {
                isFourthDigitBullOrCow = true;
                cows++;
            }

            // checks if fourthDigit is cow:
            if (!isFirstDigitBullOrCow && fourthDigit == FirstDigit)
            {
                isFirstDigitBullOrCow = true;
                cows++;
            }
            else if (!isSecondDigitBullOrCow && fourthDigit == SecondDigit)
            {
                isSecondDigitBullOrCow = true;
                cows++;
            }
            else if (!isThirdDigitBullOrCow && fourthDigit == ThirdDigit)
            {
                isThirdDigitBullOrCow = true;
                cows++;
            }

            Result guessResult = new Result();
            guessResult.Bulls = bulls;
            guessResult.Cows = cows;
            return guessResult;

        }

        private void GenerateRandomNumbers()
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
                return (FirstDigit == objectToCompare.FirstDigit &&
                        SecondDigit == objectToCompare.SecondDigit &&
                        ThirdDigit == objectToCompare.ThirdDigit &&
                        FourthDigit == objectToCompare.FourthDigit);
            }
        }

        public override int GetHashCode()
        {
            return FirstDigit.GetHashCode() ^ SecondDigit.GetHashCode() ^ ThirdDigit.GetHashCode() ^ FourthDigit.GetHashCode();
        }
    }
}
