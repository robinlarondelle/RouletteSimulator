using Domain.Bets;
using Domain.Numbers;
using Domain.Players;
using FluentAssertions;
using Xunit;
using Field = Domain.Layouts.Field;

namespace DomainTests.BetsTests;

public class BetsTests
{
    [Fact]
    public void Bet_ShouldContainAField_Amount_AndPlayer()
    {
        // Arrange
        var player = new Player("John Doe", 100);
        var field = new Field(new Number("1", NumberColor.Black));
        const decimal amount = 10;
        var bet = new Bet(player, field, amount);
        
        // Assert
        bet.Player.Should().Be(player);
        bet.Amount.Should().Be(amount);
        bet.Field.Should().Be(field);
    }
}