// See https://aka.ms/new-console-template for more information
string greeting = @"Welcome to Thrown For a Loop Your one-stop shop for used sporting equipment";
Console.WriteLine(greeting);
Console.WriteLine("Please enter a product name: ");
string response = Console.ReadLine();
Console.WriteLine(@$"You chose: {response}. Thank you for your input!");
