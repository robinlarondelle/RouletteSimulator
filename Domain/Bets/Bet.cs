using Domain.Layout;
using Domain.Players;

namespace Domain.Bets;

public record Bet(Player Player, Field Field, decimal Amount);