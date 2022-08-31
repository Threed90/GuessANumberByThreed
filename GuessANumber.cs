Random rdm = new Random();
int number = rdm.Next(1, 101);

while (true)
{
    Console.Write("Guess a number (1-100): ");
    string userInput = Console.ReadLine();

    bool isValid = int.TryParse(userInput, out int userNumber);

    if (isValid)
    {
        if (number == userNumber)
        {
            Console.WriteLine("You guessed it!");
            break;
        }
        else if(number < userNumber)
        {
            Console.WriteLine("Too High");
        }
        else
        {
            Console.WriteLine("Too Low");
        }
    }
    else
    {
        Console.WriteLine("Invalid input.");
    }
    
}
