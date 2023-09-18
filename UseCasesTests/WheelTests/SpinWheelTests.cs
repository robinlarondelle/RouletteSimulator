using TestUtilities;
using UseCases.Wheel.Interfaces;
using Xunit;

namespace UseCasesTests.WheelTests;

public class SpinWheelTests
{
    [Theory, AutoNSubstituteData]
    public void SpinWheel_ShouldReturnRandomNumber(
        IRandomIntGenerator randomIntGenerator)
    {
        // // Arrange
        // var index = 1;
        // randomIntGenerator.GenerateInt(Arg.Any<int>(), Arg.Any<int>()).Returns(index);
        // var spinWheel = new SpinWheel(randomIntGenerator);
        //
        // // Act
        // var result = spinWheel.Spin();
        //
        // // Assert
        
    }
}