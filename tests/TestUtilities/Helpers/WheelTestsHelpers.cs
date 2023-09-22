using Domain.Games;
using Domain.Numbers;
using Domain.Wheels;

namespace TestUtilities.Helpers;

public static class WheelTestsHelpers
{
    public static Wheel CreateWheel(RouletteType rouletteType = RouletteType.European)
    {
        return new Wheel
        {
            Pockets = rouletteType is RouletteType.American
                ? NumberConstants.AmericanNumbers
                : NumberConstants.EuropeanNumbers
        };
    }
}