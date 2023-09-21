using Domain.Numbers;
using UseCases.Layouts;

namespace UseCasesTests.LayoutTests;

public class CreateLayoutUseCaseTests
{
    [Fact]
    public void CreateLayoutUseCase_ShouldHaveCreateEuropeanLayoutMethod()
    {
        // Arrange
        var createLayoutUseCase = new CreateLayoutUseCase();
        
        // Act
        var layout = createLayoutUseCase.CreateEuropeanLayout();
        
        // Assert
        layout.Should().NotBeNull();
        layout.Fields.Select(f => f.Number).Should().BeEquivalentTo(NumberConstants.EuropeanNumbers);
    }
    
    [Fact]
    public void CreateLayoutUseCase_ShouldHaveCreateAmericanLayoutMethod()
    {
        // Arrange
        var createLayoutUseCase = new CreateLayoutUseCase();
        
        // Act
        var layout = createLayoutUseCase.CreateAmericanLayout();
        
        // Assert
        layout.Should().NotBeNull();
        layout.Fields.Select(f => f.Number).Should().BeEquivalentTo(NumberConstants.AmericanNumbers);
    }
}