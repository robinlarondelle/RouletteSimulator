using Domain.Game.Interfaces;
using Domain.Numbers;
using Domain.Shared;
using UseCases.Wheel.Interfaces;

namespace UseCases.Wheel.Generators;

public class NumberGenerator : INumberGenerator
{
    private readonly IList<Number> _pocketNumbers;
    private readonly IRandomIntGenerator _randomIntGenerator;

    public NumberGenerator(IRandomIntGenerator randomIntGenerator, IGameSettings gameSettings)
    {
        _randomIntGenerator = randomIntGenerator;
        _pocketNumbers = gameSettings.GetRouletteType() == RouletteType.European ? NumberConstants.EuropeanNumbers : NumberConstants.AmericanNumbers;
    }
    
    public Number GenerateNumber()
    {
        var index = _randomIntGenerator.GenerateInt(0, _pocketNumbers.Count - 1);
        var pocketNum = _pocketNumbers[index];
        return _pocketNumbers[index];
    }
}