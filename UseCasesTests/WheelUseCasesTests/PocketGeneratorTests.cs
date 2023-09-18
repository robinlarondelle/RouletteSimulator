using Domain.Numbers;
using Domain.Shared;
using FluentAssertions;
using NSubstitute;
using RouletteSimulator.Engine.Generators;
using RouletteSimulator.Engine.Interfaces;
using TestUtilities;
using Xunit;

namespace UseCasesTests.WheelUseCasesTests;

public class PocketGeneratorTests
{
    private readonly IList<Number> _europeanWheelNumbers = NumberConstants.EuropeanNumbers;
    private readonly IList<Number> _americanWheelNumbers = NumberConstants.AmericanNumbers;
    
    [Theory, AutoNSubstituteData]
    public void EuropeanGeneratePocket_ShouldReturnCorrectPocket(IRandomIntGenerator randomIntGenerator)
    {
        // Arrange
        var random = new Random();
        var randomInt = random.Next(0, 37);
        randomIntGenerator.GenerateInt(Arg.Any<int>(), Arg.Any<int>()).Returns(randomInt);
        var sut = new NumberGenerator(randomIntGenerator, RouletteType.European);
        
        // Act
        var number = sut.GenerateNumber();
        
        // Assert
        number.Should().Be(_europeanWheelNumbers[randomInt]);
    }
    
    [Theory, AutoNSubstituteData]
    public void AmericanGeneratePocket_ShouldReturnCorrectPocket(IRandomIntGenerator randomIntGenerator)
    {
        // Arrange
        var random = new Random();
        var randomInt = random.Next(0, 38);
        randomIntGenerator.GenerateInt(Arg.Any<int>(), Arg.Any<int>()).Returns(randomInt);
        var sut = new NumberGenerator(randomIntGenerator, RouletteType.American);
        
        // Act
        var number = sut.GenerateNumber();
        
        // Assert
        number.Should().Be(_americanWheelNumbers[randomInt]);
    }
}