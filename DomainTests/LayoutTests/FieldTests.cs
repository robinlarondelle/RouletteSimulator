using Domain.Layout;
using Domain.Numbers;
using FluentAssertions;
using Xunit;

namespace DomainTests.LayoutTests;

public class FieldTests
{
    [Fact]
    public void Field_ShouldHaveANumberProperty()
    {
        // Arrange
        var number = new Number("1", NumberColor.Black);
        var field = new Field(number);
        
        // Assert
        field.Number.Should().Be(number);
    }
}