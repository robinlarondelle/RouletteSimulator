using Domain.Numbers;
using UseCases.Wheels;

namespace UseCasesTests.WheelTests;

public class CreateWheelUseCaseTests
{
    [Fact]
    public void CreateWheelUseCase_ShouldHaveCreateEuropeanWheelMethod()
    {
        // Arrange
        var createWheelUseCase = new CreateWheelUseCase();
        
        // Act
        var wheel = createWheelUseCase.CreateEuropeanWheel();
        
        // Assert
        wheel.Should().NotBeNull();
        wheel.Pockets.Should().BeEquivalentTo(NumberConstants.EuropeanNumbers);
    }
    
    [Fact]
    public void CreateWheelUseCase_ShouldHaveCreateAmericanWheelMethod()
    {
        // Arrange
        var createWheelUseCase = new CreateWheelUseCase();
        
        // Act
        var wheel = createWheelUseCase.CreateAmericanWheel();
        
        // Assert
        wheel.Should().NotBeNull();
        wheel.Pockets.Should().BeEquivalentTo(NumberConstants.AmericanNumbers);
    }
}