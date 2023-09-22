using Domain.Players;

namespace Domain.Bets;

public record Bet
{
    public required Player Player { get; init; }
    public required int Amount { get; init; }
    public required decimal PayoutMultiplier { get; init; }
}
