using Domain.Game.Interfaces;
using Domain.Layout;
using Domain.Numbers;
using Domain.Shared;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace DomainTests.LayoutTests;

public class LayoutTests
{
    [Theory]
    [InlineData(RouletteType.European)]
    [InlineData(RouletteType.American)]
    public void Layout_ShouldHaveFields_BasedOnRouletteType(RouletteType rouletteType)
    {
        // Arrange
        var gameSettingsMock = Substitute.For<IGameSettings>();
        gameSettingsMock.GetRouletteType().Returns(rouletteType);
        var layout = new Layout(gameSettingsMock);
        
        // Assert
        layout.Fields.Select(f => f.Number).Should().BeEquivalentTo(rouletteType == RouletteType.American
            ? NumberConstants.AmericanNumbers
            : NumberConstants.EuropeanNumbers);
    }
    
    [Fact]
    public void Layout_ShouldHaveBetsProperty()
    {
        // Arrange
        var gameSettingsMock = Substitute.For<IGameSettings>();
        var layout = new Layout(gameSettingsMock);
        
        // Assert
        layout.Bets.Should().NotBeNull();
    }
}