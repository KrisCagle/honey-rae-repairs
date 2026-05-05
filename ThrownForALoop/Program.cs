List<Product> products = new List<Product>()
{
    new Product()
    { 
        Name = "Football", 
        Price = 15.00M, 
        Sold = false,
        StockDate = new DateTime(2022,10,20),
        ManufactureYear = 2010,
        Condition = 3.5
    },
    new Product() 
    { 
        Name = "Hockey Stick", 
        Price = 12.95M, 
        Sold = false,
        StockDate = new DateTime(2023,12,01),
        ManufactureYear = 2009,
        Condition = 9.9
    },
    new Product()
    {
        Name = "Baseball",
        Price = 9.50M,
        Sold = false,
        StockDate = new DateTime(2021,03,12),
        ManufactureYear = 2008,
        Condition = 6.4
    },
    new Product()
    {
        Name = "Skateboard",
        Price = 100.01M,
        Sold = true,
        StockDate = new DateTime(2010,04,04),
        ManufactureYear = 2005,
        Condition = 4.2
    },
    new Product()
    {
        Name = "Soccer Ball",
        Price = 15.99M,
        Sold = false,
        StockDate = new DateTime(2007, 03,20),
        ManufactureYear = 1991,
        Condition = 2.3
    },
    new Product()
    {
        Name = "Golf Ball",
        Price = 7.50M,
        Sold = false,
        StockDate = new DateTime(2013,04,19),
        ManufactureYear = 1995,
        Condition = 1.7
    }
};
decimal totalValue = 0.0M;
foreach (Product product in products)
{
    if (!product.Sold)
    {
        totalValue += product.Price;
    }
}
Console.WriteLine($"Total inventory value: ${totalValue}");
Console.WriteLine("Products:");
for (int i = 0; i < products.Count; i++)
{
    Console.WriteLine($"{i + 1}. {products[i].Name}");
}
Product chosenProduct = null;

while (chosenProduct == null)
{
    Console.WriteLine("Please enter a product number: ");
    try
{
   int response = int.Parse(Console.ReadLine().Trim());
   chosenProduct = products[response - 1];
}
catch (FormatException)
{
   Console.WriteLine("Please type only integers!");
}
catch (ArgumentOutOfRangeException)
{
   Console.WriteLine("Please choose an existing item only!");
}
catch (Exception ex)
{
   Console.WriteLine(ex);
   Console.WriteLine("Do Better!");
}}
DateTime now = DateTime.Now;                      

TimeSpan timeInStock = now - chosenProduct.StockDate;
Console.WriteLine(@$"You chose: 
{chosenProduct.Name}, which costs {chosenProduct.Price} dollars.
It is {now.Year - chosenProduct.ManufactureYear} years old. 
It {(chosenProduct.Sold ? "is not available." : $"has been in stock for {timeInStock.Days} days.")} The item's condition rating is: {chosenProduct.Condition}");