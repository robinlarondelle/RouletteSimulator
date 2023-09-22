using Domain.Bets;
using Domain.Layouts;
using Domain.Players;
using UseCases.Bets;

namespace UseCasesTests.GameTests;

public class PayoutBetsIUseCaseTests
{
    [Theory, AutoNSubstituteData]
    public void PayoutBetsUseCase_ShouldAddBetPlusPayoutMultiplierToPlayerBalance(
        Player player,
        Field field
    )
    {
        // Arrange
        const int startingBalance = 100;
        const int payoutMultiplier = 35;
        const int amount = 20;
        player.Balance = startingBalance;

        var bet = new Bet
        {
            Player = player,
            Amount = amount,
            PayoutMultiplier = payoutMultiplier
        };
        
        field.Bets.Add(bet);
        
        var payoutBetsUseCase = new PayoutBetsIUseCase(field);

        // Act
        payoutBetsUseCase.Execute();
        
        // Assert

        var expectedBalance = startingBalance + amount + (int) Math.Round((double)(amount * payoutMultiplier), MidpointRounding.ToZero);
        player.Balance.Should().Be(expectedBalance);
    }
    
    [Theory, AutoNSubstituteData]
    public void PayoutBetsUseCase_ShouldRemoveBetsFromField_AfterPayout(
        Field field
    )
    {
        // Arrange
        var payoutBetsUseCase = new PayoutBetsIUseCase(field);

        // Act
        payoutBetsUseCase.Execute();
        
        // Assert
        field.Bets.Should().BeEmpty();
    }
}