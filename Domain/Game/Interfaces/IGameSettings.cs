using Domain.Shared;

namespace Domain.Game.Interfaces;

public interface IGameSettings
{
    RouletteType GetRouletteType();
}