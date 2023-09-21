using Domain.Game;
using Domain.Games;
using Domain.Players;
using UseCases.Games.Interfaces;
using UseCases.Layouts.Interfaces;
using UseCases.Wheels.Interfaces;

namespace UseCases.Games;

public class InitializeGameUseCase : IInitializeGameUseCase
{
    public Game Execute(RouletteType rouletteType, ICreateWheelUseCase createWheelUseCase, ICreateLayoutUseCase createLayoutUseCase)
    {
        if (rouletteType is RouletteType.American)
        {
            return new Game
            {
                Wheel = createWheelUseCase.CreateAmericanWheel(),
                Layout = createLayoutUseCase.CreateAmericanLayout(),
                Players = new List<Player>()
            };
        }

        return new Game
        {
            Wheel = createWheelUseCase.CreateEuropeanWheel(),
            Layout = createLayoutUseCase.CreateEuropeanLayout(),
            Players = new List<Player>()
        };
    }
}