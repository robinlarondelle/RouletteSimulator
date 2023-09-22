using Domain.Layouts;
using Domain.Players;
using Domain.Wheels;

namespace Domain.Games;

public record Game
{
    public required Wheel Wheel { get; init; } 
    public required Layout Layout { get; init; }
    public required IList<Player> Players { get; init; }
}