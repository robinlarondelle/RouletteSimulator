using Domain.Game;
using Domain.Numbers;
using Domain.Wheel;

namespace UseCasesTests.WheelTests;

public static class WheelTestsHelpers
{
    public static Wheel CreateWheel(RouletteType rouletteType)
    {
        var wheel = new Wheel();
        
        if (rouletteType is RouletteType.American)
        {
            wheel.SetAmericanPockets();
        } else
        {
            wheel.SetEuropeanPockets();
        }

        return wheel;
    }
}