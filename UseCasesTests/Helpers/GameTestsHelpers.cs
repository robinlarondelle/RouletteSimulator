using Domain.Games;
using Domain.Players;

namespace UseCasesTests.Helpers;

internal static class GameTestsHelpers
{
    internal static Game CreateGame()
    {
        return new Game
        {
            Layout = LayoutTestsHelpers.CreateLayout(),
            Wheel = WheelTestsHelpers.CreateWheel(),
            Players = new List<Player>()
        };
    }
}