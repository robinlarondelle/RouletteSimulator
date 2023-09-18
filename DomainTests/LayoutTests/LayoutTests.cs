using Domain.Layout;
using Domain.Numbers;
using Domain.Shared;
using FluentAssertions;
using Xunit;

namespace DomainTests.LayoutTests;

public class LayoutTests
{
    [Theory]
    [InlineData(RouletteType.European)]
    [InlineData(RouletteType.American)]
    public void Layout_ShouldHaveFields_BasedOnRouletteType(RouletteType rouletteType)
    {
        // Arrange
        var layout = new Layout(rouletteType);
        
        // Assert
        layout.Fields.Select(f => f.Number).Should().BeEquivalentTo(rouletteType == RouletteType.American
            ? NumberConstants.AmericanNumbers
            : NumberConstants.EuropeanNumbers);
    }
    
    [Fact]
    public void Layout_ShouldHaveBetsProperty()
    {
        // Arrange
        var layout = new Layout(RouletteType.European);
        
        // Assert
        layout.Bets.Should().NotBeNull();
    }
}