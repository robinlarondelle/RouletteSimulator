using Domain.Bets;
using Domain.Layouts;
using Domain.Numbers;
using FluentAssertions;
using Xunit;

namespace DomainTests.LayoutTests;

public class FieldTests
{
    [Theory, AutoNSubstituteData]
    public void Field_ShouldOnlyBeInitializedWithRequiredProperties(
        Number number,
        IList<Bet> bets)
    {
        var field = new Field
        {
            Number = number,
            Bets = bets
        };
        
        // Assert
        field.Number.Should().Be(number);
        field.Bets.Should().BeEquivalentTo(bets);
    }
}