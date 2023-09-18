using Domain.Numbers;
using Domain.Shared;

namespace Domain.Wheel;

public class Wheel
{
    public IList<Number> Numbers { get; set; }

    public Wheel(RouletteType rouletteType)
    {
        Numbers = rouletteType switch
        {
            RouletteType.European => NumberConstants.EuropeanNumbers,
            RouletteType.American => NumberConstants.AmericanNumbers,
            _ => throw new ArgumentOutOfRangeException(nameof(rouletteType), rouletteType, null)
        };
    }
}