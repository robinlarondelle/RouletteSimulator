using Domain.Game;
using Domain.Wheel;
using UseCases.Wheels.Interfaces;

namespace UseCases.Wheels;

public class CreateWheelUseCase : ICreateWheelUseCase
{
    public Wheel CreateWheel(RouletteType rouletteType)
    {
        var wheel = new Wheel();

        if (rouletteType is RouletteType.European)
        {
            wheel.SetEuropeanPockets();
        }
        else
        {
            wheel.SetAmericanPockets();
        }

        return wheel;
    }
}