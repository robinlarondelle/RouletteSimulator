using Domain.Bets;
using Domain.Exceptions;
using Domain.Layouts;
using UseCases.Bets.Interfaces;

namespace UseCases.Bets;

public class PlaceBetUseCase : IPlaceBetUseCase
{
    private readonly Field _field;
    private readonly Bet _bet;

    public PlaceBetUseCase(Field field, Bet bet)
    {
        _field = field;
        _bet = bet;
    }
    
    public Field Execute()
    {
        var playerBalance = _bet.Player.Balance;
        var betAmount = _bet.Amount;

        if (playerBalance - betAmount < 0)
        {
            throw new NotEnoughBalanceException();
        }
        
        _field.Bets.Add(_bet);

        _bet.Player.Balance = playerBalance - betAmount;
        
        return _field;
    }
}