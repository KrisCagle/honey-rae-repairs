using System.Transactions;

List <book> books = new List<book>()
{
    new book()
    {
    Id = 1,
    Name = "Where the Red Fern Grows",
    GenreId = 1,
    DateAdded = new DateTime (1991,02,21),
    IsCheckedOut = true
    },

    new book()
    {
    Id = 2,
    Name = "Mr. Popper's Penguins",
    GenreId = 1,
    DateAdded = new DateTime (2001,05,20),
    IsCheckedOut = false 
    },
    
    new book()
    {
    Id = 3,
    Name = "The guy from Parks and Recs: Ron Swanson",
    GenreId = 2,
    DateAdded = new DateTime (2012,01,12),
    IsCheckedOut = true
    }
};




List <genre> genres = new List<genre>()
    {
    new genre() 
                      {
    
    Id = 1,
    genreName = "Fiction",


                      },
    new genre()
{
    Id = 2,
    genreName = "Non-Fiction"
},                
 };

 Console.WriteLine("Welcome to the Library Online Catalog!");

 string choice = null;
 while (choice != "0")
 {
 Console.WriteLine (@"Choose an Option
 0: Exit
 1: View all Books
 2. View Books by Genre
 3: Add a Book
 4: Delete a Book
 5: Update a Book
 6: Checkout a Book
 7: View Overdue Books");
choice= Console.ReadLine();

if (choice == "0")
    {
        Console.WriteLine("Thank you for using the Library Online Checkout, HAVE A GREAT DAY!");
    }
else if (choice == "1")
    {
        ViewAllBooks();
    }
else if (choice == "2")
    {
        ViewBooksByGenre();
    }
else if (choice == "3")
    {
        AddBook();
    }
else if (choice == "4")
    {
        DeleteBook();
    }
else if (choice == "5") 
    {
        UpdateBook();
    }
// else if (choice == "6")
//     {
//         CheckoutBook();
//     }
// else if (choice == "7")
//     {
//         ViewOverdueBook();
//     }
 }

 void ViewAllBooks()
{
    Console.WriteLine ("All Books: ");
    Console.WriteLine(string.Join("\n", books.Select((b, i) =>
    $"{i + 1}.{b.Name} - {(b.IsCheckedOut ? "Available to checkout" : "Currently checkedout")} {b.DaysOnShelf} Days on Shelf")));
}

void ViewBooksByGenre()
{
    Console.WriteLine("Choose a Genre");
    Console.WriteLine(string.Join("\n", genres.Select((bg, i) =>
    $"{i + 1}.{bg.genreName}")));

    genre chosenType = null;
    while (chosenType == null)
    {
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenType = genres[response -1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please only type integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine ("Please choose an existing genre only!");
        }
    }
List <book> FilteredBooks = books.Where(b => b.GenreId == chosenType.Id).ToList();
if (FilteredBooks.Count == 0)
    {
        Console.WriteLine($"No Books Found in {chosenType.genreName}");
        return;
    }
Console.WriteLine($"{chosenType.genreName}: ");
Console.WriteLine(string.Join("\n", FilteredBooks.Select((b,i ) =>
$"{i + 1}.{b.Name} - {(b.IsCheckedOut ? "Available to checkout" : "Currently checked out")} {b.DaysOnShelf} Days on Shelf")));
}

void AddBook()
{
    Console.WriteLine("Enter the Book Title: ");
    string name = Console.ReadLine().Trim();

    Console.WriteLine("Fiction Or Non-Fiction?: ");
    Console.WriteLine(string.Join("\n", genres.Select((g, i) =>
        $"{i + 1}. {g.genreName}")));

    genre chosenType = null;
    while (chosenType == null)
    {
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenType = genres[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please only type the number choice.");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing genre only!");
        }
    }

    int newId = books.Count > 0 ? books.Max(b => b.Id) + 1 : 1;

    books.Add(new book()
    {
        Id = newId,
        Name = name,
        GenreId = chosenType.Id,
        DateAdded = DateTime.Now,
        IsCheckedOut = false
    });

    Console.WriteLine($"{name} has been added to the library.");
}

void DeleteBook()
{
    ViewAllBooks();

    book chosenBook = null;
    while (chosenBook == null)
    {
        Console.WriteLine("Enter the Number of the Book You Want to Delete.");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenBook = books[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please Choose an existing Book Only!");
        }
    }
    Console.WriteLine($"Are you sure you want to delete {chosenBook.Name}? (y/n)");
    string confirm = Console.ReadLine().Trim().ToLower();
    if (confirm == "y")
    {
        books.Remove(chosenBook);
        Console.WriteLine($"{chosenBook.Name} has been removed from inventory.");
    }
    else
    {
        Console.WriteLine("Delete Canceled...");
    }
} // <-- this was missing the whole time

void UpdateBook()
{
    ViewAllBooks();

    book chosenBook = null;
    while (chosenBook == null)
    {
        Console.WriteLine("Enter the number of the book you want to update.");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenBook = books[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing book only!");
        }
    }

    Console.WriteLine($"Editing {chosenBook.Name}");
    Console.WriteLine($"Is This Book Checked Out? (Current: {(chosenBook.IsCheckedOut ? "Checked Out" : "Available")})");
    Console.WriteLine("1. Available");
    Console.WriteLine("2. Checked Out");

    bool validAvailability = false;
    while (!validAvailability)
    {
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            if (response == 1)
            {
                chosenBook.IsCheckedOut = false;
                validAvailability = true;
            }
            else if (response == 2)
            {
                chosenBook.IsCheckedOut = true;
                validAvailability = true;
            }
            else
            {
                Console.WriteLine("Please Choose 1 or 2.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Please Type Only Integers...");
        }
    }
    Console.WriteLine($"{chosenBook.Name} Has Been Updated.");
}