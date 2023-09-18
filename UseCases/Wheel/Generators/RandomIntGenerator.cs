using UseCases.Wheel.Interfaces;

namespace UseCases.Wheel.Generators;

public class RandomIntGenerator : IRandomIntGenerator
{
    public int GenerateInt(int min, int max)
    {
        var random = new Random();
        return random.Next(min, max);
    }
}