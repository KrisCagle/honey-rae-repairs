public class book
{
    public int Id {get; set; }
    public int GenreId {get; set; }
    public string Name {get; set; }
    public bool IsCheckedOut {get; set;}
    public int DaysCheckedOut {get; set; }
    public DateTime DateAdded {get; set;}
    public int DaysOnShelf 
    {get
        {
            return (DateTime.Now - DateAdded).Days;
        }
    }
}