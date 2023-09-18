using Domain.Game.Interfaces;
using Domain.Numbers;
using Domain.Shared;
using Domain.Wheel;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace DomainTests.WheelTests;

public class WheelTests
{
    [Theory]
    [InlineData(RouletteType.European)]
    [InlineData(RouletteType.American)]
    public void AWheel_ShouldHaveNumbersWithColors_BasedOnRouletteType(
        RouletteType rouletteType
        )
    {
        // Arrange
        var gameSettingsMock = Substitute.For<IGameSettings>();
        gameSettingsMock.GetRouletteType().Returns(rouletteType);
        var wheel = new Wheel(gameSettingsMock);
        
        // Assert
        wheel.Numbers.Should().BeEquivalentTo(rouletteType == RouletteType.American
            ? NumberConstants.AmericanNumbers
            : NumberConstants.EuropeanNumbers);
    }
    
    [Fact]
    public void Wheel_ShouldThrowArgumentOutOfRangeException_WhenRouletteTypeIsInvalid()
    {
        // Arrange
        var gameSettingsMock = Substitute.For<IGameSettings>();
        gameSettingsMock.GetRouletteType().Returns((RouletteType) 99);
        
        // Act
        Action act = () => new Wheel(gameSettingsMock);
        
        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}