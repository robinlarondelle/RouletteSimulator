using Domain.Game;
using Domain.Numbers;

namespace UseCasesTests.Helpers;

internal static class NumberHelpers
{
    internal static IEnumerable<object[]> NumbersRouletteType
    {
        get
        {
            yield return new object[] { NumberConstants.AmericanNumbers, RouletteType.American };
            yield return new object[] { NumberConstants.EuropeanNumbers, RouletteType.European };
        }
    }
}