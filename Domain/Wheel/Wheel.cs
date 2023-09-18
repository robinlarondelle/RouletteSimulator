using Domain.Game.Interfaces;
using Domain.Numbers;
using Domain.Shared;

namespace Domain.Wheel;

public class Wheel
{
    public IList<Number> Numbers { get; set; }

    public Wheel(IGameSettings gameSettings)
    {
        Numbers = gameSettings.GetRouletteType() switch
        {
            RouletteType.European => NumberConstants.EuropeanNumbers,
            RouletteType.American => NumberConstants.AmericanNumbers,
            _ => throw new ArgumentOutOfRangeException(nameof(gameSettings.GetRouletteType), gameSettings, null)
        };
    }
}