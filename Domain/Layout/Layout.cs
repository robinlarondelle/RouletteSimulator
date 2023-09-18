using Domain.Bets;
using Domain.Numbers;
using Domain.Shared;

namespace Domain.Layout;

public class Layout
{   
    public IList<Field> Fields { get; set; }
    public IList<Bet> Bets { get; set; }
    
    public Layout(RouletteType rouletteType)
    {
        if (rouletteType == RouletteType.American)
        {
            Fields = NumberConstants.AmericanNumbers.Select(n => new Field(n)).ToList();
        }
        else
        {
            Fields = NumberConstants.EuropeanNumbers.Select(n => new Field(n)).ToList();
        }

        Bets = new List<Bet>();
    }
}