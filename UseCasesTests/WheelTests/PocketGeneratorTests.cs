using Domain.Game.Interfaces;
using Domain.Numbers;
using Domain.Shared;
using FluentAssertions;
using NSubstitute;
using TestUtilities;
using UseCases.Wheel.Generators;
using UseCases.Wheel.Interfaces;
using Xunit;

namespace UseCasesTests.WheelTests;

public class PocketGeneratorTests
{
    [Theory, AutoPropertyData(nameof(Numbers_RouletteType))]
    public void GeneratePocket_ShouldReturnCorrectPocket(
        IList<Number> numbers,
        RouletteType rouletteType,
        IGameSettings gameSettings,
        IRandomIntGenerator randomIntGenerator)
    {
        // Arrange
        var random = new Random();
        var randomInt = random.Next(0, numbers.Count());
        randomIntGenerator.GenerateInt(Arg.Any<int>(), Arg.Any<int>()).Returns(randomInt);

        gameSettings.GetRouletteType().Returns(rouletteType);
        var sut = new NumberGenerator(randomIntGenerator, gameSettings);
        
        // Act
        var number = sut.GenerateNumber();
        
        // Assert
        number.Should().Be(numbers[randomInt]);
    }

    public static IEnumerable<object[]> Numbers_RouletteType
    {
        get
        {
            yield return new object[] { NumberConstants.AmericanNumbers, RouletteType.American };
            yield return new object[] { NumberConstants.EuropeanNumbers, RouletteType.European };
        }
    }
}