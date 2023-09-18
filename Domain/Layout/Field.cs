using Domain.Numbers;

namespace Domain.Layout;

public class Field
{
    public Number Number { get; set; }
    
    public Field(Number number)
    {
        Number = number;
    }
}