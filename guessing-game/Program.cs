Console.WriteLine("Welcome to Guessing Game!");
int secretNumber = new Random().Next(1, 101);
int maxGuesses = 4;
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
}

if (!won)
{
    Console.WriteLine("You Lose!");
}
