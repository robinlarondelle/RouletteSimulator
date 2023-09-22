using UseCases.Utils;

namespace UseCasesTests.UtilsTests;

public class RandomGeneratorTests
{
    [Fact]
    public void GenerateInt_GeneratesANumber_BetweenGivenBoundaries()
    {
        // Arrange
        const int min = 0;
        const int max = 10;
        var randomGenerator = new RandomIntGenerator();
        
        // Act
        var result = randomGenerator.GenerateInt(min, max);
        
        // Assert
        result.Should().BeInRange(min, max);
    }
}