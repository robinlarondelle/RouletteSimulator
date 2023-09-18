using Domain.Numbers;
using Domain.Shared;
using RouletteSimulator.Engine.Interfaces;

namespace RouletteSimulator.Engine.Generators;

public class NumberGenerator : INumberGenerator
{
    private readonly IList<Number> _pocketNumbers;
    private readonly IRandomIntGenerator _randomIntGenerator;

    public NumberGenerator(IRandomIntGenerator randomIntGenerator, RouletteType rouletteType)
    {
        _randomIntGenerator = randomIntGenerator;
        _pocketNumbers = rouletteType == RouletteType.European ? NumberConstants.EuropeanNumbers : NumberConstants.AmericanNumbers;
    }
    
    public Number GenerateNumber()
    {
        var index = _randomIntGenerator.GenerateInt(0, _pocketNumbers.Count - 1);
        var pocketNum = _pocketNumbers[index];
        return _pocketNumbers[index];
    }
}