using AutoFixture;
using Domain.Players;

namespace TestUtilities.Helpers;

public static class PlayerTestsHelpers
{
    public static Player CreatePlayer()
    {
        var fixture = new CustomAutoFixture();
        return fixture.Create<Player>();
    }
}