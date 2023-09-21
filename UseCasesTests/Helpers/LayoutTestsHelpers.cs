using Domain.Bets;
using Domain.Game;
using Domain.Layouts;
using Domain.Numbers;

namespace UseCasesTests.Helpers;

internal static class LayoutTestsHelpers
{
    internal static Layout CreateLayout(RouletteType rouletteType = RouletteType.European)
    {
        return new Layout
        {
            Fields = rouletteType is RouletteType.American
                ? NumberConstants.AmericanNumbers.Select(n => new Field(n)).ToList()
                : NumberConstants.EuropeanNumbers.Select(n => new Field(n)).ToList(),
            Bets = new List<Bet>()
        };
    }
}