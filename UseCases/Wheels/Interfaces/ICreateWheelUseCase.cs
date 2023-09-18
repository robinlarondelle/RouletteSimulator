using Domain.Game;
using Domain.Wheel;

namespace UseCases.Wheels.Interfaces;

public interface ICreateWheelUseCase
{
    Wheel CreateWheel(RouletteType rouletteType);
}