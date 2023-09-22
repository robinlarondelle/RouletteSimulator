using Domain.Numbers;

namespace Domain.Wheels;

public record Wheel
{
    public required IList<Number> Pockets { get; init; }
}