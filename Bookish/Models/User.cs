namespace Bookish;

public class User
{
    public int Id { get; set; }    
    public string? Name { get; set; }

    public List<Loan>? Loans { get; set; }
    
}