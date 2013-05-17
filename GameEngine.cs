using System;

namespace CowsAndBulls
{
    public class GameEngine
    {
        private const string SCORES_FILE = "scores.txt";
        private const string WELCOME_MESSAGE = "Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit " +
                                                "number.\nUse 'top' to view the top scoreboard, 'restart' to start a new " +
                                                "game and 'help' \nto cheat and 'exit' to quit the game.";
        private const string WRONG_NUMBER_MESSAGE = "Wrong number!";
        private const string INVALID_COMMAND_MESSAGE = "Incorrect guess or command!";
        private const string NUMBER_GUESSED_WITHOUT_CHEATS = "Congratulations! You guessed the secret number in {0} {1}." +
                                                            "\nPlease enter your name for the top scoreboard: ";
        private const string NUMBER_GUESSED_WITH_CHEATS = "Congratulations! You guessed the secret number in {0} {1} and {2} {3}." +
                                                            "\nYou are not allowed to enter the top scoreboard.";
        public const string GOOD_BYE_MESSAGE = "Good bye!";
        public const string INPUT_MESSAGE = "Enter your guess or command: ";

        private const string EXIT_COMMAND = "exit";
        private const string TOP_COMMAND = "top";
        private const string RESTART_COMMAND = "restart";
        private const string HELP_COMMAND = "help";

        /// <summary>
        /// Represents the Cows And Bulls game UI
        /// </summary>
        public static void Main()
        {
            SecretNumber bullsAndCowsNumber = new SecretNumber();
            Scoreboard scoreBoard = new Scoreboard(SCORES_FILE);

            Console.WriteLine(WELCOME_MESSAGE);

            string command = string.Empty;

            while (true)
            {
                Console.Write(INPUT_MESSAGE);

                command = Console.ReadLine();

                if (command == EXIT_COMMAND) //this stays here, not in the swich, because break the while loop
                {
                    Console.WriteLine(GOOD_BYE_MESSAGE);
                    break;
                }

                switch (command)
                {
                    case TOP_COMMAND:
                        Console.Write(scoreBoard);
                        break;
                    case RESTART_COMMAND:
                        Console.WriteLine();
                        Console.WriteLine(WELCOME_MESSAGE);
                        bullsAndCowsNumber = new SecretNumber();
                        break;
                    case HELP_COMMAND:
                        Console.WriteLine("The number looks like {0}.", bullsAndCowsNumber.GetCheat());
                        break;
                    default:
                        try
                        {
                            Result guessResult = bullsAndCowsNumber.CheckUserGuess(command);
                            if (guessResult.Bulls == 4)
                            {
                                string attempt = bullsAndCowsNumber.GuessesCount == 1 ? "attempt" : "attempts";
                                string cheat = bullsAndCowsNumber.CheatsCount == 1 ? "cheat" : "cheats";

                                if (bullsAndCowsNumber.CheatsCount == 0)
                                {
                                    Console.Write(NUMBER_GUESSED_WITHOUT_CHEATS, bullsAndCowsNumber.GuessesCount, attempt);
                                    string name = Console.ReadLine();
                                    scoreBoard.AddScore(name, bullsAndCowsNumber.GuessesCount);
                                }
                                else
                                {
                                    Console.WriteLine(NUMBER_GUESSED_WITH_CHEATS, bullsAndCowsNumber.GuessesCount, attempt,
                                                                                    bullsAndCowsNumber.CheatsCount, cheat);
                                }

                                Console.Write(scoreBoard);
                                Console.WriteLine();
                                Console.WriteLine(WELCOME_MESSAGE);

                                bullsAndCowsNumber = new SecretNumber();
                            }
                            else
                            {
                                Console.WriteLine("{0} {1}", WRONG_NUMBER_MESSAGE, guessResult);
                            }
                        }
                        catch (Exception ex)
                        {
                            //Modified by KrisNickson => this way it will catch all 
                            //expcetions the new validation in CheckUserGuess throws
                            if (ex is ArgumentException || ex is FormatException)
                            {
                                Console.WriteLine(INVALID_COMMAND_MESSAGE);
                            }
                        }

                        Console.WriteLine("kur");
                        break;
                }
            }

            scoreBoard.SaveToFile(SCORES_FILE);
        }
    }
}
