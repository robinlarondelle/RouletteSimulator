using Domain.Games;
using Domain.Numbers;

namespace TestUtilities.Helpers;

public static class NumberHelpers
{
    public static IEnumerable<object[]> NumbersRouletteType
    {
        get
        {
            yield return new object[] { NumberConstants.AmericanNumbers, RouletteType.American };
            yield return new object[] { NumberConstants.EuropeanNumbers, RouletteType.European };
        }
    }
}