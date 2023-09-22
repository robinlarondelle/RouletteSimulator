using Domain.Bets;
using Domain.Exceptions;
using Domain.Layouts;
using Domain.Players;
using UseCases.Bets;

namespace UseCasesTests.LayoutTests;

public class PlaceBetsUseCaseTests
{
    [Theory, AutoNSubstituteData]
    public void PlaceBetUseCase_ShouldAddBet_ToGivenField(
        Player player,
        decimal multiplier,
        Field field)
    {
        // Arrange
        const int balance = 100;
        const int amount = 20;
        player.Balance = balance;
        field.Bets = new List<Bet>();
        var bet = new Bet
        {
            Player = player,
            Multiplier = multiplier,
            Amount = amount
        };
        
        var placeBetUseCase = new PlaceBetUseCase(field, bet);
        
        // Act
        var updatedField = placeBetUseCase.Execute();
        
        // Assert
        updatedField.Bets.Should().HaveCount(1).And.Contain(bet);
    }

    [Theory, AutoNSubstituteData]
    public void PlaceBetUseCase_ShouldThrowNotEnoughBalanceException_WhenBetIsHigherThanPlayerBalance(
        Player player,
        decimal multiplier,
        decimal balance,
        Field field)
    {
        // Arrange
        player.Balance = balance;
        var bet = new Bet
        {
            Player = player,
            Multiplier = multiplier,
            Amount = balance + 10
        };

        var placeBetUseCase = new PlaceBetUseCase(field, bet);

        // Act
        placeBetUseCase
            .Invoking(x => x.Execute())
            .Should().Throw<NotEnoughBalanceException>();
    }

    [Theory, AutoNSubstituteData]
    public void PlaceBetUseCase_ShouldUpdatePlayerBalance_AfterSuccessfulBetPlaced(
        Player player,
        decimal multiplier,
        Field field)
    {
        // Arrange
        const int balance = 100;
        const int amount = 20;
        player.Balance = balance;
        field.Bets = new List<Bet>();
        var bet = new Bet
        {
            Player = player,
            Multiplier = multiplier,
            Amount = amount
        };

        var placeBetUseCase = new PlaceBetUseCase(field, bet);
        
        // Act
        placeBetUseCase.Execute();
        
        // Assert
        player.Balance.Should().Be(balance - amount);
    }
}