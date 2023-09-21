using Domain.Numbers;
using Domain.Wheels;

namespace DomainTests.WheelTests;

public class WheelTests
{
    [Theory, AutoNSubstituteData]
    public void Wheel_ShouldOnlyBeInitializedWithCorrectProperties(
        IList<Number> pockets)
    {
        // Arrange
        var wheel = new Wheel()
        {
            Pockets = pockets,
        };
        
        // Assert
        wheel.Pockets.Should().NotBeNull().And.BeEquivalentTo(pockets);
    }
}