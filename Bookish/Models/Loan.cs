namespace Bookish;

public class Loan
{
    public int Id { get; set; }    
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    
    public User? User { get; set; }
    public List<Book>? Books { get; set; }
}