using Domain.Bets;
using Domain.Players;

namespace DomainTests.BetsTests;

public class BetsTests
{
    [Theory, AutoNSubstituteData]
    public void Bets_ShouldOnlyBeInitializedWithRequiredProperties(
        Player player,
        decimal PayoutMultiplier,
        int amount)
    {
        // Act
        var bet = new Bet
        {
            Player = player,
            PayoutMultiplier = PayoutMultiplier,
            Amount = amount
        };
        
        // Assert
        bet.Player.Should().Be(player);
        bet.Amount.Should().Be(amount);
        bet.PayoutMultiplier.Should().Be(PayoutMultiplier);
    }
}