using Domain.Numbers;
using Domain.Shared;
using Domain.Wheel;
using FluentAssertions;
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
        var wheel = new Wheel(rouletteType);
        
        // Assert
        wheel.Numbers.Should().BeEquivalentTo(rouletteType == RouletteType.American
            ? NumberConstants.AmericanNumbers
            : NumberConstants.EuropeanNumbers);
    }
    
    [Fact]
    public void Wheel_ShouldThrowArgumentOutOfRangeException_WhenRouletteTypeIsInvalid()
    {
        // Arrange
        var rouletteType = (RouletteType) 99; // invalid roulette type
        
        // Act
        Action act = () => new Wheel(rouletteType);
        
        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}