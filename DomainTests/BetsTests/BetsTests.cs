using Domain.Bets;
using Domain.Numbers;
using Domain.Players;
using FluentAssertions;
using Xunit;
using Field = Domain.Layouts.Field;

namespace DomainTests.BetsTests;

public class BetsTests
{
    [Theory, AutoNSubstituteData]
    public void Bets_ShouldOnlyBeInitializedWithRequiredProperties(
        Player player,
        decimal multiplier,
        decimal amount)
    {
        // Act
        var bet = new Bet
        {
            Player = player,
            Multiplier = multiplier,
            Amount = amount
        };
        
        // Assert
        bet.Player.Should().Be(player);
        bet.Amount.Should().Be(amount);
        bet.Multiplier.Should().Be(multiplier);
    }
}