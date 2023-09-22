using Domain.Bets;
using Domain.Games;
using Domain.Layouts;
using Domain.Numbers;

namespace TestUtilities.Helpers;

public static class LayoutTestsHelpers
{
    public static Layout CreateLayout(RouletteType rouletteType = RouletteType.European)
    {
        return new Layout
        {
            Fields = rouletteType is RouletteType.American
                ? NumberConstants.AmericanNumbers.Select(CreateField).ToList()
                : NumberConstants.EuropeanNumbers.Select(CreateField).ToList()
        };
    }
    
    private static Field CreateField(Number number)
    {
        return new Field
        {
            Number = number,
            Bets = new List<Bet>()
        };
    }
}