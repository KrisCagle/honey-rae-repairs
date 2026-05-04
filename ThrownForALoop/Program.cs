string greeting = @"Welcome to Thrown for a Loop
Your one-stop shop for used sporting equipment";

Console.WriteLine(greeting);
Console.WriteLine("Please enter a product name: ");

string response = Console.ReadLine();

while (string.IsNullOrWhiteSpace(response))
{
    Console.WriteLine("You didn't choose anything, try again!");
    response = Console.ReadLine().Trim();
}

Console.WriteLine($"You chose: {response}");
