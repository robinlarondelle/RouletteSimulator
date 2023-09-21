using AutoFixture;
using Domain.Players;

namespace UseCasesTests.Helpers;

internal static class PlayerTestsHelpers
{
    internal static Player CreatePlayer()
    {
        var fixture = new CustomAutoFixture();
        return fixture.Create<Player>();
    }
}