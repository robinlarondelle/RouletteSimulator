using Domain.Layouts;
using Domain.Players;

namespace Domain.Bets;

public record Bet
{
    public required Player Player { get; init; }
    public required decimal Amount { get; init; }
    public required decimal Multiplier { get; init; }
}
