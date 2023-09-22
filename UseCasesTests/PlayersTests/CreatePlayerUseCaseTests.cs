using UseCases.Players;

namespace UseCasesTests.PlayersTests;

public class CreatePlayerUseCaseTests
{
    [Fact]
    public void CreatePlayerUseCase_ShouldCreatePlayer()
    {
        // Arrange
        var createPlayerUseCase = new CreatePlayerUseCase("John Doe", 100);
        
        // Act
        var player = createPlayerUseCase.Execute();
        
        // Assert
        player.Name.Should().Be("John Doe");
        player.Balance.Should().Be(100);
    }
}