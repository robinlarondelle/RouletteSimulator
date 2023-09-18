namespace RouletteSimulator.Engine.Interfaces;

public interface IRandomIntGenerator
{
    int GenerateInt(int min, int max);
}