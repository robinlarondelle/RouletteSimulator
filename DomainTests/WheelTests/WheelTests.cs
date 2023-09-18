using Domain.Numbers;
using Domain.Wheel;
using FluentAssertions;
using Xunit;

namespace DomainTests.WheelTests;

public class WheelTests
{
    [Fact]
    public void Wheel_ShouldHaveFPocketsProperty()
    {
        // Arrange
        var wheel = new Wheel();
        
        // Assert
        wheel.Pockets.Should().NotBeNull();
    }
    
    [Fact]
    public void Wheel_SetEuropeanPockets_ShouldSetPocketsToEuropeanNumbers()
    {
        // Arrange
        var wheel = new Wheel();
        
        // Act
        wheel.SetEuropeanPockets();
        
        // Assert
        wheel.Pockets.Should().BeEquivalentTo(NumberConstants.EuropeanNumbers);
    }
    
    [Fact]
    public void Wheel_SetAmericanPockets_ShouldSetPocketsToAmericanNumbers()
    {
        // Arrange
        var wheel = new Wheel();
        
        // Act
        wheel.SetAmericanPockets();
        
        // Assert
        wheel.Pockets.Should().BeEquivalentTo(NumberConstants.AmericanNumbers);
    }
}