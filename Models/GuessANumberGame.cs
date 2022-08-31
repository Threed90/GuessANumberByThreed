using GuessANumber.Contracts;

namespace GuessANumber.Models
{
    public class GuessANumberGame : IGame
    {
        private readonly Random rdm = new Random();
        private int number;
        private bool isStop;
        public GuessANumberGame()
        {
            this.Score = 0;
            isStop = false;
        }
        public int Score { get; private set; }

        public void Restart()
        {
            Console.WriteLine("Game is restarting...");
            Thread.Sleep(1000);
            Console.WriteLine(new string('=', 75));
            this.SetGameDifficulty();
            isStop = false;
        }

        public bool SetGameDifficulty()
        {
            Console.WriteLine("Choose the difficulty of the game:");
            Console.Write("Min value of number for guessing: ");
            string min = Console.ReadLine();
            Console.Write("Max value of number for guessing: ");
            string max = Console.ReadLine();
            Console.Write("Choice the maximum number of tries: ");
            string tries = Console.ReadLine();

            bool isMinValid = int.TryParse(min, out int minValue);
            bool isMaxValid = int.TryParse(max, out int maxValue);
            bool isTriesValid = int.TryParse(tries, out int triesNumber);

            if (isMinValid && isMaxValid && isTriesValid)
            {
                number = rdm.Next(minValue, maxValue + 1);
                this.Score = triesNumber;
            }
            else
            {
                Console.WriteLine("Invalid input!!!");
            }

            return isMinValid && isMaxValid && isTriesValid;
        }

        public void Start()
        {
            this.SetGameDifficulty();

            while (!isStop)
            {
                Console.Write("Guess a number (1-100): ");
                string userInput = Console.ReadLine();

                bool isValid = int.TryParse(userInput, out int userNumber);

                if (isValid)
                {
                    if (number == userNumber)
                    {
                        Console.WriteLine("You guessed it!");
                        Console.WriteLine();

                        Console.Write("Press [y] to play again or any key to stop the game: ");
                        var key = Console.ReadKey();

                        Console.WriteLine();

                        if(key.KeyChar == 'y')
                        {
                            this.Restart();
                        }
                        else
                        {
                            this.Stop();
                        }
                    }
                    else if (number < userNumber)
                    {
                        Console.WriteLine("Too High");
                        this.Score--;
                    }
                    else
                    {
                        Console.WriteLine("Too Low");
                        this.Score--;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }

                if (this.Score <= 0)
                {
                    Console.WriteLine("Game over! You reach the max number of tries.");

                    Console.WriteLine();

                    Console.Write("Press [y] to play again or any key to stop the game: ");
                    var key = Console.ReadKey();

                    Console.WriteLine();

                    if (key.KeyChar == 'y')
                    {
                        this.Restart();
                    }
                    else
                    {
                        this.Stop();
                    }
                }
            }

            
        }

        public void Stop()
        {
            isStop = true;
        }
    }
}
