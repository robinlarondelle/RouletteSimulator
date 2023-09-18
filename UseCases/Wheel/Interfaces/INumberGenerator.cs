using Domain.Numbers;

namespace RouletteSimulator.Engine.Interfaces;

public interface INumberGenerator
{
    Number GenerateNumber();
}