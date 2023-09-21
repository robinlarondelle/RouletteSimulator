using Domain.Game;
using Domain.Games;
using Domain.Layouts;
using Domain.Players;
using Domain.Wheels;

namespace DomainTests.GameTests;

public class GameTests
{
    [Theory, AutoNSubstituteData]
    public void Game_ShouldHaveCorrectProperties(
        Wheel wheel,
        Layout layout,
        IList<Player> players)
    {
        // Arrange
        var game = new Game
        {
            Wheel = wheel,
            Layout = layout,
            Players = players
        };
        
        // Assert
        game.Wheel.Should().NotBeNull().And.Be(wheel);
        game.Layout.Should().NotBeNull().And.Be(layout);
        game.Players.Should().NotBeNull().And.BeEquivalentTo(players);
    }
}