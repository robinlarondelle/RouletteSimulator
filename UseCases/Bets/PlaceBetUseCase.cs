using Domain.Bets;
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
        _field.Bets.Add(_bet);
        return _field;
    }
}