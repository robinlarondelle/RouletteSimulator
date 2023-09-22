using Domain.Wheels;

namespace UseCases.Wheels.Interfaces;

public interface ICreateWheelUseCase
{
    Wheel CreateEuropeanWheel();
    Wheel CreateAmericanWheel();
}