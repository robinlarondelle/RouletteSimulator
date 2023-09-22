using Domain.Numbers;
using Domain.Wheels;
using UseCases.Wheels.Interfaces;

namespace UseCases.Wheels;

public class CreateWheelUseCase : ICreateWheelUseCase
{
    public Wheel CreateEuropeanWheel()
    {
        return new Wheel()
        {
            Pockets = NumberConstants.EuropeanNumbers
        };
    }
    
    public Wheel CreateAmericanWheel()
    {
        return new Wheel()
        {
            Pockets = NumberConstants.AmericanNumbers
        };
    }
}