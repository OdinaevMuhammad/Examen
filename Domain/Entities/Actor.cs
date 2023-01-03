namespace Domain.Entities;

public class Actor
{
    public int ActorId { get; set; }
    public string FullName { get; set; }
    public int Gender { get; set; }
    public int BirthYear { get; set; }
    public int DeathYear { get; set; }

    public virtual List<Cast> Cast { get; set; }
}