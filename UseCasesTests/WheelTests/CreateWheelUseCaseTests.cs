using Domain.Game;
using Domain.Numbers;
using FluentAssertions;
using TestUtilities;
using UseCases.Wheels;
using Xunit;

namespace UseCasesTests.WheelTests;

public class CreateWheelUseCaseTests
{
    [Theory, AutoPropertyData(nameof(NumbersRouletteType))]
    public void CreateWheelUseCase_ShouldCreateAWheel(IList<Number> pockets, RouletteType rouletteType)
    {
        // Arrange
        var createWheelUseCase = new CreateWheelUseCase();
        
        // Act
        var wheel = createWheelUseCase.CreateWheel(rouletteType);
        
        // Assert
        wheel.Should().NotBeNull();
        wheel.Pockets.Should().BeEquivalentTo(pockets);
    }
    
    public static IEnumerable<object[]> NumbersRouletteType
    {
        get
        {
            yield return new object[] { NumberConstants.AmericanNumbers, RouletteType.American };
            yield return new object[] { NumberConstants.EuropeanNumbers, RouletteType.European };
        }
    }
}