Console.WriteLine("Welcome to Guessing Game!");
int secretNumber = 42;
bool won = false;
for (int guessCount = 1; guessCount <=4; guessCount++)
{
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
