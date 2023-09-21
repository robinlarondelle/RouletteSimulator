using Domain.Bets;
using Domain.Layouts;

namespace UseCases.Bets;

public class PlaceBetUseCase
{
    private readonly Layout _layout;
    private readonly Bet _bet;

    public PlaceBetUseCase(Layout layout, Bet bet)
    {
        _layout = layout;
        _bet = bet;
    }
    
    public Layout Execute()
    {
        _layout.Bets.Add(_bet);
        return _layout;
    }
}