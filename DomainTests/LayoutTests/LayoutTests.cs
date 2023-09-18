using Domain.Layout;
using FluentAssertions;
using Xunit;

namespace DomainTests.LayoutTests;

public class LayoutTests
{
    [Fact]
    public void Layout_ShouldHaveBetsProperty()
    {
        // Arrange
        var layout = new Layout();
        
        // Assert
        layout.Bets.Should().NotBeNull();
    }
        
    [Fact]
    public void Layout_ShouldHaveFieldProperty()
    {
        // Arrange
        var layout = new Layout();
        
        // Assert
        layout.Bets.Should().NotBeNull();
    }
}