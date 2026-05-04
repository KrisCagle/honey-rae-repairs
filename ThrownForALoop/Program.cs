string greeting = @"Welcome to Thrown for a Loop
Your one-stop shop for used sporting equipment";

Console.WriteLine(greeting);
Console.WriteLine(@"Products:
1. Football
2. Hockey Stick
3. Boomerang
4. Frisbee
5. Golf Putter");
Console.WriteLine("Please enter a product number: ");
int response = int.Parse(Console.ReadLine().Trim());

while (response > 5 || response < 1)
{
    Console.WriteLine("Choose a number between 1 and 5!");
    response = int.Parse(Console.ReadLine().Trim());
}

