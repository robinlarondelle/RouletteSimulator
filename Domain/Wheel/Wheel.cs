using Domain.Numbers;

namespace Domain.Wheel;

public class Wheel
{
    public IList<Number> Pockets { get; set; }

    public Wheel()
    {
        Pockets = new List<Number>();
    }
    
    public void SetEuropeanPockets()
    {
        Pockets = NumberConstants.EuropeanNumbers;
    }
    
    public void SetAmericanPockets()
    {
        Pockets = NumberConstants.AmericanNumbers;
    }
}