using Domain.Bets;
using Domain.Layouts;
using Domain.Players;
using UseCases.Bets;

namespace UseCasesTests.GameTests;

public class PayoutBetsIUseCaseTests
{
    [Theory, AutoNSubstituteData]
    public void PayoutBetsUseCase_ShouldAddPayoutToPlayerBalance_GivenField(
        Player player,
        decimal startingBalance,
        decimal amount,
        decimal multiplier,
        Field field
    )
    {
        // Arrange
        player.Balance = startingBalance;

        var bet = new Bet
        {
            Player = player,
            Amount = amount,
            Multiplier = multiplier
        };
        
        field.Bets.Add(bet);
        
        var payoutBetsUseCase = new PayoutBetsIUseCase(field);

        // Act
        payoutBetsUseCase.Execute();
        
        // Assert
        player.Balance.Should().Be(startingBalance + amount * multiplier);
    }
    
    [Theory, AutoNSubstituteData]
    public void PayoutBetsUseCase_ShouldRemoveBetsFromField_AfterPayout(
        Player player,
        decimal startingBalance,
        decimal amount,
        decimal multiplier,
        Field field
    )
    {
        // Arrange
        player.Balance = startingBalance;

        var bet = new Bet
        {
            Player = player,
            Amount = amount,
            Multiplier = multiplier
        };
        
        field.Bets.Add(bet);
        
        var payoutBetsUseCase = new PayoutBetsIUseCase(field);

        // Act
        payoutBetsUseCase.Execute();
        
        // Assert
        field.Bets.Should().BeEmpty();
    }
}