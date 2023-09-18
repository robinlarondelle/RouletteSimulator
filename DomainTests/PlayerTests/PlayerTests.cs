using Domain.Players;
using FluentAssertions;
using Xunit;

namespace DomainTests.PlayerTests;

public class PlayerTests
{
    [Fact]
    public void Player_ShouldHaveANameAndBalanceProperty()
    {
        // Arrange
        const string name = "John Doe";
        const decimal balance = 100;
        var player = new Player(name, balance);
        
        // Assert
        player.Name.Should().Be(name);
        player.Balance.Should().Be(balance);
    }
}