using Domain.Game;
using Domain.Numbers;
using FluentAssertions;
using NSubstitute;
using TestUtilities;
using UseCases.Utils.Interfaces;
using UseCases.Wheels;
using UseCasesTests.Helpers;
using Xunit;

namespace UseCasesTests.WheelTests;

public class SpinWheelUseCaseTests
{
    public static IEnumerable<object[]> NumbersRouletteType { get; } = NumberHelpers.NumbersRouletteType;

    [Theory, AutoPropertyData(nameof(NumbersRouletteType))]
    public void SpinWheel_ShouldReturnRandomNumber(
        IList<Number> pockets,
        RouletteType rouletteType,
        IRandomIntGenerator randomIntGenerator)
    {
        // Arrange
        const int index = 1;
        randomIntGenerator.GenerateInt(Arg.Any<int>(), Arg.Any<int>()).Returns(index);
        var spinWheel = new SpinWheelUseCase(randomIntGenerator, WheelTestsHelpers.CreateWheel(rouletteType));
        
        // Act
        var result = spinWheel.Spin();
        
        // Assert
        result.Should().Be(pockets[index]);
    }
}