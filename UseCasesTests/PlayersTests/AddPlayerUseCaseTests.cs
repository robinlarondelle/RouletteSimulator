using UseCases.Players;

namespace UseCasesTests.PlayersTests;

public class AddPlayerUseCaseTests
{
    [Fact]
    public void AddPlayerUseCase_ShouldAddPlayer_ToGivenGame()
    {
        // Arrange
        var game = GameTestsHelpers.CreateGame();
        var player = PlayerTestsHelpers.CreatePlayer();
        var addPlayerUseCase = new AddPlayerUseCase(game, player);
        
        // Act
        addPlayerUseCase.Execute();
        
        // Assert
        game.Players.Should().HaveCount(1).And.Contain(player);
    }
}