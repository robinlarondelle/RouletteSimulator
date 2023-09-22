using Domain.Bets;
using Domain.Exceptions;
using Domain.Layouts;
using Domain.Players;
using UseCases.Bets;

namespace UseCasesTests.LayoutTests;

public class PlaceBetsUseCaseTests
{
    [Theory, AutoNSubstituteData]
    public void PlaceBetUseCase_ShouldSetPayoutMultiplierTo35_WhenBettingOnOneField(
        Player player,
        Field field)
    {
        // Arrange
        const int balance = 100;
        const int amount = 20;
        player.Balance = balance;
        field.Bets = new List<Bet>();
        var fields = new List<Field> { field };

        // Act
        var placeBetUseCase = new PlaceBetUseCase(fields, player, amount);
        placeBetUseCase.Execute();

        // Assert
        var expectedPayoutMultiplier = Math.Round(decimal.Round(35, fields.Count), MidpointRounding.ToZero);
        fields.Should().AllSatisfy(f =>
        {
            f.Bets.Should().HaveCount(1);
            f.Bets.Select(b => b.PayoutMultiplier).Should().AllBeEquivalentTo(expectedPayoutMultiplier);
        });
    }
    
    [Theory, AutoNSubstituteData]
    public void PlaceBetUseCase_ShouldAddBet_ToGivenField(
        Player player,
        Field field)
    {
        // Arrange
        const int balance = 100;
        const int amount = 20;
        player.Balance = balance;
        field.Bets = new List<Bet>();
        var fields = new List<Field>() { field };
        var placeBetUseCase = new PlaceBetUseCase(fields, player, amount);
        
        // Act
        placeBetUseCase.Execute();
        
        // Assert
        fields.Should().AllSatisfy(f =>
        {
            f.Bets.Should().HaveCount(1);
        });
    }
    
    [Theory, AutoNSubstituteData]
    public void PlaceBetUseCase_ShouldThrowNotEnoughBalanceException_WhenBetIsHigherThanPlayerBalance(
        Player player,
        int balance,
        Field field)
    {
        // Arrange
        player.Balance = balance;
        var amount = balance + 20;
        var fields = new List<Field>() { field };
        var placeBetUseCase = new PlaceBetUseCase(fields, player, amount);
    
        // Act
        placeBetUseCase
            .Invoking(x => x.Execute())
            .Should().Throw<NotEnoughBalanceException>();
    }
    
    [Theory, AutoNSubstituteData]
    public void PlaceBetUseCase_ShouldUpdatePlayerBalance_AfterSuccessfulBetPlaced(
        Player player,
        Field field)
    {
        // Arrange
        const int balance = 100;
        const int amount = 20;
        player.Balance = balance;
        field.Bets = new List<Bet>();
        var fields = new List<Field>() { field };
        
        var placeBetUseCase = new PlaceBetUseCase(fields, player, amount);
        
        // Act
        placeBetUseCase.Execute();
        
        // Assert
        player.Balance.Should().Be(balance - amount);
    }
}