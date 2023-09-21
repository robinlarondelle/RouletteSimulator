using Domain.Layouts;
using Domain.Players;
using Domain.Wheels;

namespace Domain.Games;

public record Game
{
    public required Wheel Wheel { get; set; } 
    public required Layout Layout { get; set; }
    public required IList<Player> Players { get; set; }
}