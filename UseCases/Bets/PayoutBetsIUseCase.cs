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
            var player = bet.Player;
            player.Balance = player.Balance + bet.Amount * bet.Multiplier;
        }

        _field.Bets = new List<Bet>();
    }
}