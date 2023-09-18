using Domain.Numbers;
using Domain.Wheel;
using UseCases.Utils.Interfaces;
using UseCases.Wheels.Interfaces;

namespace UseCases.Wheels;

public class SpinWheelUseCase : ISpinWheel
{
    private readonly IRandomIntGenerator _randomIntGenerator;
    private readonly Wheel _wheel;

    public SpinWheelUseCase(IRandomIntGenerator randomIntGenerator, Wheel wheel)
    {
        _randomIntGenerator = randomIntGenerator;
        _wheel = wheel;
    }

    public Number Spin()
    {
         var index = _randomIntGenerator.GenerateInt(0, _wheel.Pockets.Count - 1);
         return _wheel.Pockets[index];
    }
}