using Domain.Numbers;

namespace UseCases.Bets.Interfaces;

public interface IBets
{
    void PlaceBet(IList<Number> field, double amount);
}