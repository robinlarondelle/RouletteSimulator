using Domain.Game;
using Domain.Numbers;
using FluentAssertions;
using NSubstitute;
using TestUtilities;
using UseCases.Utils.Interfaces;
using UseCases.Wheels;
using UseCases.Wheels.Interfaces;
using Xunit;

namespace UseCasesTests.WheelTests;

public class SpinWheelUseCaseTests
{
    [Theory, AutoNSubstituteData]
    public void SpinWheel_ShouldReturnRandomNumber(
        IRandomIntGenerator randomIntGenerator)
    {
        // Arrange
        const int index = 1;
        randomIntGenerator.GenerateInt(Arg.Any<int>(), Arg.Any<int>()).Returns(index);
        var spinWheel = new SpinWheelUseCase(randomIntGenerator, WheelTestsHelpers.CreateWheel(RouletteType.European));
        
        // Act
        var result = spinWheel.Spin();
        
        // Assert
        result.Should().Be(NumberConstants.EuropeanNumbers[index]);
    }
}