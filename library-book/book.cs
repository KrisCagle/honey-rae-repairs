public class book
{
    public int Id {get; set; }
    public int GenreId {get; set; }
    public string Name {get; set; }
    public bool IsCheckedOut {get; set;}
    public DateTime DateAdded {get; set;}
    public DateTime CheckedOutDate {get; set;}
    public int DaysOnShelf 
    {get
        {
            return (DateTime.Now - DateAdded).Days;
        }
    }
    public int DaysCheckedOut 
    { get
        {
            return (DateTime.Now - CheckedOutDate).Days;
        }
}
}