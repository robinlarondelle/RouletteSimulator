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
        const int balance = 100;
        
        // Act
        var player = new Player
        {
            Name = name,
            Balance = balance
        };
        
        // Assert
        player.Name.Should().Be(name);
        player.Balance.Should().Be(balance);
    }
}