using Domain.Bets;
using Domain.Players;
using UseCases.Bets;
using UseCasesTests.Helpers;

namespace UseCasesTests.LayoutTests;

public class PlaceBetsUseCaseTests
{
    [Theory, AutoNSubstituteData]
    public void PlaceBetUseCase_ShouldPlaceBet_OnGivenField(
        Player player)
    {
        // Arrange
        var layout = LayoutTestsHelpers.CreateLayout();
        var bet = new Bet(player, layout.Fields.First(), 10);
        var placeBetUseCase = new PlaceBetUseCase(layout, bet);

        
        // Act
        var updatedLayout = placeBetUseCase.Execute();
        
        // Assert
        updatedLayout.Bets.Should().Contain(bet);
    }
}