using Domain.Numbers;
using Domain.Shared;
using UseCases.Wheel.Interfaces;

namespace UseCases.Wheel;

public class Wheel: IWheel
{
    private readonly IList<Number> _pocketNumbers;
    private readonly IRandomIntGenerator _randomIntGenerator;

    public Wheel(IRandomIntGenerator randomIntGenerator, RouletteType rouletteType)
    {
        _randomIntGenerator = randomIntGenerator;
        _pocketNumbers = rouletteType == RouletteType.European ? NumberConstants.EuropeanNumbers : NumberConstants.AmericanNumbers;
    }
    
    public Number Spin()
    {
        var index = _randomIntGenerator.GenerateInt(0, _pocketNumbers.Count - 1);
        var pocketNum = _pocketNumbers[index];
        return _pocketNumbers[index];
    }
}