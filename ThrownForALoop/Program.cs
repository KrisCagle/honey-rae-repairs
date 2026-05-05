List<Product> products = new List<Product>()
{
    new Product()
    { 
        Name = "Football", 
        Price = 15, 
        Sold = false,
        StockDate = new DateTime(2022,10,20),
        ManufactureYear = 2010
    },
    new Product() 
    { 
        Name = "Hockey Stick", 
        Price = 12, 
        Sold = false,
        StockDate = new DateTime(2023,12,01),
        ManufactureYear = 2009
    },
    new Product()
    {
        Name = "Baseball",
        Price = 9,
        Sold = false,
        StockDate = new DateTime(2021,03,12),
        ManufactureYear = 2008
    },
    new Product()
    {
        Name = "Skateboard",
        Price = 100,
        Sold = true,
        StockDate = new DateTime(2010,04,04),
        ManufactureYear = 2005
    },
    new Product()
    {
        Name = "Soccer Ball",
        Price = 15,
        Sold = false,
        StockDate = new DateTime(2007, 03,20),
        ManufactureYear = 1991
    },
    new Product()
    {
        Name = "Golf Ball",
        Price = 7,
        Sold = false,
        StockDate = new DateTime(2013,04,19),
        ManufactureYear = 1995
    }
};

Console.WriteLine("Products:");
for (int i = 0; i < products.Count; i++)
{
    Console.WriteLine($"{i + 1}. {products[i].Name}");
}
Console.WriteLine("Please enter a product number: ");
int response = int.Parse((Console.ReadLine() ?? "").Trim());

while (response > products.Count || response < 1)
{
    Console.WriteLine($"Choose a number between 1 and {products.Count}!");
    response = int.Parse(Console.ReadLine().Trim());
}

Product chosenProduct = products[response - 1]; 
DateTime now = DateTime.Now;                      

TimeSpan timeInStock = now - chosenProduct.StockDate;
Console.WriteLine(@$"You chose: 
{chosenProduct.Name}, which costs {chosenProduct.Price} dollars.
It is {now.Year - chosenProduct.ManufactureYear} years old. 
It {(chosenProduct.Sold ? "is not available." : $"has been in stock for {timeInStock.Days} days.")}");