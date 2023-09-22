using Domain.Games;
using Domain.Players;

namespace TestUtilities.Helpers;

public static class GameTestsHelpers
{
    public static Game CreateGame(RouletteType rouletteType = RouletteType.European)
    {
        return new Game
        {
            Layout = LayoutTestsHelpers.CreateLayout(rouletteType),
            Wheel = WheelTestsHelpers.CreateWheel(rouletteType),
            Players = new List<Player>()
        };
    }
}