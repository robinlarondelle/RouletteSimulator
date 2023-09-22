using Domain.Bets;
using Domain.Exceptions;
using Domain.Layouts;
using Domain.Players;
using UseCases.Bets.Interfaces;

namespace UseCases.Bets;

public class PlaceBetUseCase : IPlaceBetUseCase
{
    private readonly IList<Field> _fields;
    private readonly Player _player;
    private readonly int _amount;

    public PlaceBetUseCase(IList<Field> fields, Player player, int amount)
    {
        _fields = fields;
        _player = player;
        _amount = amount;
    }
    
    public void Execute()
    {
        if (_player.Balance - _amount < 0)
        {
            throw new NotEnoughBalanceException();
        }

        foreach (var field in _fields)
        {
            field.Bets.Add(new Bet
            {
                Player = _player,
                Amount = _amount,
                PayoutMultiplier = CalculatePayoutMultiplier()
            });
        }

        _player.Balance -= _amount;
    }

    private int CalculatePayoutMultiplier()
    {
        return (int) Math.Round(decimal.Divide(35, _fields.Count), MidpointRounding.ToZero);
    }
}