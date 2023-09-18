using Domain.Bets;

namespace Domain.Layout;

public class Layout
{   
    public IList<Field> Fields { get; set; }
    public IList<Bet> Bets { get; set; }
    
    public Layout()
    {
        Fields = new List<Field>();
        Bets = new List<Bet>();
    }
}