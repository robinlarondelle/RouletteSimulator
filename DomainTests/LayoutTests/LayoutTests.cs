using Domain.Bets;
using Domain.Layouts;

namespace DomainTests.LayoutTests;

public class LayoutTests
{
    [Theory, AutoNSubstituteData]
    public void Layout_ShouldOnlyBeInitializedWithCorrectProperties(
        IList<Field> fields,
        IList<Bet> bets)
    {
        // Arrange
        var layout = new Layout
        {
            Fields = fields,
            Bets = bets
        };
        
        // Assert
        layout.Bets.Should().NotBeNull().And.BeEquivalentTo(bets);
        layout.Fields.Should().NotBeNull().And.BeEquivalentTo(fields);
    }
}