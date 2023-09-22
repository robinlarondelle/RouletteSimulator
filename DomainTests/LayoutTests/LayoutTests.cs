using Domain.Bets;
using Domain.Layouts;

namespace DomainTests.LayoutTests;

public class LayoutTests
{
    [Theory, AutoNSubstituteData]
    public void Layout_ShouldOnlyBeInitializedWithCorrectProperties(
        IList<Field> fields)
    {
        // Arrange
        var layout = new Layout
        {
            Fields = fields
        };
        
        // Assert
        layout.Fields.Should().NotBeNull().And.BeEquivalentTo(fields);
    }
}