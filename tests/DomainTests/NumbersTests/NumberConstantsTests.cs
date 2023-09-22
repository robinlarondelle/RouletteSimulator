using Domain.Numbers;
using FluentAssertions;
using Xunit;

namespace DomainTests.NumbersTests;

public class NumberConstantsTests
{
    [Fact]
    public void EuropeanNumberConstants_should_have_37_numbers()
    {
        // Arrange
        const int expected = 37;
        
        // Act
        var actual = NumberConstants.EuropeanNumbers.Count;
        
        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void AmericanNumberConstants_should_have_38_numbers()
    {
        // Arrange
        const int expected = 38;
        
        // Act
        var actual = NumberConstants.AmericanNumbers.Count;
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void OnlyAmericanNumbers_ShouldContainDoubleZero()
    {
        NumberConstants.AmericanNumbers.Select(n => n.NumberValue).Should().Contain("00");
        NumberConstants.EuropeanNumbers.Select(n => n.NumberValue).Should().NotContain("00");
    }
    
    [Fact]
    public void Numbers1to10and19to28_OddShouldBeRed_EvenShouldBeBlack()
    {
        // Assert
        ValidateNumbers(NumberConstants.EuropeanNumbers);
        ValidateNumbers(NumberConstants.AmericanNumbers);
    }
    
    private static void ValidateNumbers(IEnumerable<Number> numbers)
    {
        foreach (var (numberValue, numberColor) in numbers)
        {
            if (numberValue is "0" or "00")
            {
                numberColor.Should().Be(NumberColor.Green);
                continue;
            }
            
            var parsedNum = int.Parse(numberValue);
            
            if (parsedNum is >= 1 and <= 10 or >= 19 and <= 28)
            {
                numberColor.Should().Be(parsedNum % 2 == 0 ? NumberColor.Black : NumberColor.Red);
            }
            else
            {
                numberColor.Should().Be(parsedNum % 2 == 0 ? NumberColor.Red : NumberColor.Black);
            }
        }
    }
}