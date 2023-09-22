using Domain.Bets;
using Domain.Layouts;
using Domain.Numbers;
using Domain.Players;
using UseCases.Bets;

namespace UseCasesTests.LayoutTests;

public class PlaceBetsUseCaseTests
{
    [Theory, AutoNSubstituteData]
    public void PlaceBetUseCase_ShouldAddBet_ToGivenField(
        Player player,
        decimal multiplier,
        decimal amount,
        Number number)
    {
        // Arrange
        var bet = new Bet
        {
            Player = player,
            Multiplier = multiplier,
            Amount = amount
        };

        var field = new Field
        {
            Number = number,
            Bets = new List<Bet>()
        };
        
        var placeBetUseCase = new PlaceBetUseCase(field, bet);
        
        // Act
        var updatedField = placeBetUseCase.Execute();
        
        // Assert
        updatedField.Bets.Should().HaveCount(1).And.Contain(bet);
    }
}