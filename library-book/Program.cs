using System.Collections.Concurrent;
using System.Data.Common;
using System.Reflection;

List <book> books = new List<book>()
{
    new book()
    {
    Id = 1,
    Name = "Where the Red Fern Grows",
    DaysCheckedOut = 24,
    GenreId = 1,
    DateAdded = new DateTime (1991,02,21),
    IsCheckedOut = true
    },

    new book()
    {
    Id = 2,
    Name = "Mr. Popper's Penguins",
    DaysCheckedOut = 36,
    GenreId = 1,
    DateAdded = new DateTime (2001,05,20),
    IsCheckedOut = false 
    },
    
    new book()
    {
    Id = 3,
    Name = "The guy from Parks and Recs: Ron Swanson",
    DaysCheckedOut = 14,
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
// else if (choice == "4")
//     {
//         DeleteBook();
//     }
// else if (choice == "5") 
//     {
//         UpdateBook();
//     }
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
