using Domain.Bets;
using Domain.Numbers;

namespace Domain.Layouts;

public record Field
{
    public required Number Number { get; init; }
    public required IList<Bet> Bets { get; init; }
}