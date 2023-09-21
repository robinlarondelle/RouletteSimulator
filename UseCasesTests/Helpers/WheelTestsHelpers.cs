using Domain.Game;
using Domain.Numbers;
using Domain.Wheels;

namespace UseCasesTests.Helpers;

internal static class WheelTestsHelpers
{
    internal static Wheel CreateWheel(RouletteType rouletteType = RouletteType.European)
    {
        return new Wheel
        {
            Pockets = rouletteType is RouletteType.American
                ? NumberConstants.AmericanNumbers
                : NumberConstants.EuropeanNumbers
        };
    }
}