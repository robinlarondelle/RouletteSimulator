using Domain.Bets;

namespace Domain.Layouts;

public record Layout
{   
    public required IList<Field> Fields { get; set; } 
    public required IList<Bet> Bets { get; set; }
}