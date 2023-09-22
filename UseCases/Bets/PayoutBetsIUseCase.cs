using Domain.Bets;
using Domain.Layouts;

namespace UseCases.Bets;

public class PayoutBetsIUseCase
{
    private readonly Field _field;

    public PayoutBetsIUseCase(Field field)
    {
        _field = field;
    }

    public void Execute()
    {
        foreach (var bet in _field.Bets)
        {
            bet.Player.Balance = CalculateNewBalance(bet);
        }

        _field.Bets = new List<Bet>();
    }

    private static int CalculateNewBalance(Bet bet)
    {
        var player = bet.Player;
        return player.Balance + bet.Amount +
               (int)Math.Round((double)(bet.Amount * bet.PayoutMultiplier), MidpointRounding.ToZero);
    }
}