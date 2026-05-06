Console.WriteLine("Welcome to Guessing Game!");
Console.Write("Enter Your Guess:");
string playerGuess = Console.ReadLine();
int secretNumber = 42;
int.TryParse(playerGuess, out int guessNumber);

if (guessNumber == secretNumber)
{
    Console.WriteLine("You Win!");
}
else
{
    Console.WriteLine("You Lose!");
}