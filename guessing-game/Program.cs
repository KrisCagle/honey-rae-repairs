Console.WriteLine("Welcome to Guessing Game!");
Console.WriteLine("Choose difficulty: 1 - Easy (8 guesses), 2 - Medium (6 guesses), 3 - Hard (4 guesses)");
string difficultyChoice = Console.ReadLine();
int maxGuesses;
switch (difficultyChoice)
{
    case "1":
        maxGuesses = 8;
        break;
    case "2":
        maxGuesses = 6;
        break;
    case "3":
        maxGuesses = 4;
        break;
    default:
        maxGuesses = 4;
        break;
}
int secretNumber = new Random().Next(1, 101);
bool won = false;
for (int guessCount = 1; guessCount <= maxGuesses; guessCount++)
{
    Console.WriteLine($"{maxGuesses - guessCount + 1} guesses remaining.");
    Console.Write("Enter Your Guess:");
    string playerGuess = Console.ReadLine();
    int.TryParse(playerGuess, out int guessNumber);
    if (guessNumber == secretNumber)
    {
        won = true;
        Console.WriteLine("You Win!");
        break;
    }
    else if (guessNumber > secretNumber)
    {
        Console.WriteLine("Too High!");
    }
    else if (guessNumber < secretNumber)
    {
        Console.WriteLine("Too Low!");
    }
}

if (!won)
{
    Console.WriteLine("You Lose!");
}
