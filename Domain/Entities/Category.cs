namespace Domain.Entities;

public class Category
{
    public int CategoryId { get; set; }
    public string Title { get; set; }

    public virtual List<Movie> Movies { get; set; }
}
