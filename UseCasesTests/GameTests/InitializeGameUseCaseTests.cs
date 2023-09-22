using Domain.Games;
using Domain.Numbers;
using UseCases.Games;
using UseCases.Layouts.Interfaces;
using UseCases.Wheels.Interfaces;

namespace UseCasesTests.GameTests;

public class InitializeGameUseCaseTests
{
    [Theory, AutoNSubstituteData]
    public void InitializeGameUseCase_ShouldCreateNewGameWithEuropeanLayoutAndWheel(
        ICreateWheelUseCase createWheelUseCase,
        ICreateLayoutUseCase createLayoutUseCase)
    {
        // Arrange
        var wheel = WheelTestsHelpers.CreateWheel();
        var layout = LayoutTestsHelpers.CreateLayout();
        createWheelUseCase.CreateEuropeanWheel().Returns(wheel);
        createLayoutUseCase.CreateEuropeanLayout().Returns(layout);
        var initializeGameUseCase = new InitializeGameUseCase();
        
        // Act
        var game = initializeGameUseCase.Execute(RouletteType.European, createWheelUseCase, createLayoutUseCase);
        
        // Assert
        game.Players.Should().NotBeNull().And.BeEmpty();
        game.Wheel.Pockets.Should().BeEquivalentTo(NumberConstants.EuropeanNumbers);
        game.Layout.Fields.Select(f => f.Number).Should().BeEquivalentTo(NumberConstants.EuropeanNumbers);
    }
    
    [Theory, AutoNSubstituteData]
    public void InitializeGameUseCase_ShouldCreateNewGameWithAmericanLayoutAndWheel(
        ICreateWheelUseCase createWheelUseCase,
        ICreateLayoutUseCase createLayoutUseCase)
    {
        // Arrange
        var wheel = WheelTestsHelpers.CreateWheel(RouletteType.American);
        var layout = LayoutTestsHelpers.CreateLayout(RouletteType.American);
        createWheelUseCase.CreateAmericanWheel().Returns(wheel);
        createLayoutUseCase.CreateAmericanLayout().Returns(layout);
        var initializeGameUseCase = new InitializeGameUseCase();
        
        // Act
        var game = initializeGameUseCase.Execute(RouletteType.American, createWheelUseCase, createLayoutUseCase);
        
        // Assert
        game.Players.Should().NotBeNull().And.BeEmpty();
        game.Wheel.Pockets.Should().BeEquivalentTo(NumberConstants.AmericanNumbers);
        game.Layout.Fields.Select(f => f.Number).Should().BeEquivalentTo(NumberConstants.AmericanNumbers);
    }
}