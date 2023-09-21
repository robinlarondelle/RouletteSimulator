using Domain.Game;
using Domain.Games;
using UseCases.Layouts.Interfaces;
using UseCases.Wheels.Interfaces;

namespace UseCases.Games.Interfaces;

public interface IInitializeGameUseCase
{
    Game Execute(RouletteType rouletteType, ICreateWheelUseCase createWheelUseCase, ICreateLayoutUseCase createLayoutUseCase);
}